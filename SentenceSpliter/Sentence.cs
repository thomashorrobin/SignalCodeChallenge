using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter
{
    public class Sentence
    {
        /// <summary>
        /// An ordered list of Words in the sentance
        /// </summary>
        public List<Word> Words { get; private set; }

        /// <summary>
        /// Gets the word count of the sentance
        /// </summary>
        public int WordCount
        {
            get
            {
                return Words.Count;
            }
        }

        /// <summary>
        /// Creates a sentence object from the text of a sentance.
        /// </summary>
        /// <param name="sentence">The full text of the sentance</param>
        public Sentence(string sentence)
        {
            Words = Word.SplitSentenceToWords(sentence);
        }

        /// <summary>
        /// this takes a full text and splits it into sentances
        /// </summary>
        /// <param name="text">A full text containing multiple sentances</param>
        /// <returns>Return a list of sentance objects</returns>
        internal static List<Sentence> SplitTextToSentances(string text)
        {
            List<Sentence> sentences = new List<Sentence>();
            string[] split = text.Split(new char[] { '.', '!', '?' }); // this splits the oririginal text into a set of strings based on sentance terminators 
            foreach (string sentence in split)
            {
                if (sentence == "")
                {
                    continue;
                }
                sentences.Add(new Sentence(sentence));
            }
            return sentences;
        }
    }
}
