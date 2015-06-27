using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter
{
    class Text
    {
        /// <summary>
        /// A list of all sentances in the Text
        /// </summary>
        public List<Sentence> Sentences { get; private set; }

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
        public List<Sentence> SentenceWithMostWords()
        {
            int highestWordCount = Sentences.OrderByDescending(e => e.WordCount).First().WordCount;
            return Sentences.Where(e => e.WordCount == highestWordCount).ToList();
        }

        /// <summary>
        /// The only construtor for the Text class
        /// </summary>
        /// <param name="text">The whole text. The constuctor will handle annominies</param>
        public Text(string text)
        {
            Sentences = Sentence.SplitTextToSentances(text);
        }
    }
}
