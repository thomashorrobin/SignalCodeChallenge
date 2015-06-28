using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter
{
    public class Text
    {
        /// <summary>
        /// A list of all sentances in the Text
        /// </summary>
        public List<Sentence> Sentences { get; private set; }

        /// <summary>
        /// A list of all words in the text. This should be populated on construction
        /// </summary>
        private List<Word> Words;

        /// <summary>
        /// Gets the word count of the entire text
        /// </summary>
        public int WordCount
        {
            get
            {
                int count = 0;
                foreach (Sentence sentence in Sentences)
                {
                    count += sentence.WordCount;
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the number of sentances in the text
        /// </summary>
        public int SentenceCount
        {
            get
            {
                return Sentences.Count;
            }
        }

        /// <summary>
        /// Finds a list of sentances with the highest or highest equal word count
        /// </summary>
        /// <returns>Returns a list containing either a single or mulitple sentences</returns>
        public List<Sentence> FindSentenceWithMostWords(int rank)
        {
            ISet<int> sentenceWordCount = new HashSet<int>(); // a set is needed for this because we need to avoid duplication i.e. two sentances of count 13 should only be counted once
            foreach (Sentence sentence in Sentences) // this loop adds the word count of each sentence to the set
            {
                sentenceWordCount.Add(sentence.WordCount);// if a count already exists, say there has already been a count of 13, it trys to add a different sentence that has a count of 13, this statement will skip over that silently
            }
            List<int> sortedSentenceWordCount = sentenceWordCount.OrderByDescending(e => e).ToList(); // the set in order say { 16, 7, 13 } need to be sorted to { 16, 13, 7 }
            return Sentences.Where(e => e.WordCount == sortedSentenceWordCount[rank]).ToList(); // this gets all the sentances with the requird word count 
        }

        /// <summary>
        /// This gets the longest words excluding punctuation 
        /// </summary>
        /// <param name="rank">How far down the list you want to go. for example if you wanted the 4th equal words you's pass 3</param>
        /// <returns>a list of either one or more strings that represtent the word or words equally tied at that rank</returns>
        public List<string> FindLongestWord(int rank)
        {
            ISet<int> wordLengths = new HashSet<int>(); // a set is needed for this because we need to avoid duplication i.e. two words of length 13 should only be counted once
            foreach (Word word in Words)
            {
                wordLengths.Add(word.WordLength); // add the lengths of all words to the set
            }
            List<int> sortedWordLengths = wordLengths.OrderByDescending(e => e).ToList(); // sort them from highest to lowest so we can fetch highest, 3rd highest, etc
            List<string> longestWords = new List<string>();
            foreach (Word word in Words.Where(e => e.WordLength == sortedWordLengths[rank])) // filter words by their length, the length to use is calc using rank
            {
                longestWords.Add(word.WordText);
            }
            return longestWords;
        }

        /// <summary>
        /// Finds the most common word
        /// </summary>
        /// <param name="rank">How far down the list you want to go. for example if you wanted the 4th equal words you's pass 3</param>
        /// <returns>a list of either one or more strings that represtent the word or words equally tied at that rank</returns>
        public List<string> FindMostCommonWord(int rank)
        {
            var groupedWords = Words.GroupBy(e => e.WordText).Select(group => new { Value = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).ToList();
            ISet<int> commoness = new HashSet<int>();
            foreach (var item in groupedWords)
            {
                commoness.Add(item.Count);
            }
            int i = commoness.OrderByDescending(e => e).ToList()[rank];
            List<string> commonWords = new List<string>();
            foreach (var word in groupedWords.Where(e => e.Count == i))
            {
                commonWords.Add(word.Value);
            }
            return commonWords;
        }

        /// <summary>
        /// The only construtor for the Text class
        /// </summary>
        /// <param name="text">The whole text. The constuctor will handle annominies</param>
        public Text(string text)
        {
            Sentences = Sentence.SplitTextToSentances(text); // this populates the Sentences list
            Words = new List<Word>();
            foreach (Sentence sentence in Sentences) // this loops through the sentences created previously and concats there Words into one list
            {
                Words.AddRange(sentence.Words);
            }
        }
    }
}
