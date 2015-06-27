using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter
{
    public class Word
    {
        /// <summary>
        /// A string representing the word including any punctuation
        /// </summary>
        internal string WordTextPunctuation { get; private set; }

        /// <summary>
        /// WordText without punctuation
        /// </summary>
        public string WordText
        {
            get
            {
                return WordTextPunctuation.Trim(new char[]{ '.','!','?',',' });
            }
        }

        /// <summary>
        /// The length of the word excluding punctuation
        /// </summary>
        public int WordLength
        {
            get
            {
                return WordText.Length;
            }
        }

        /// <summary>
        /// Contructs a word object from some text.
        /// </summary>
        /// <param name="word"></param>
        public Word(string word)
        {
            WordTextPunctuation = word.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns>Returns a list of words </returns>
        internal static List<Word> SplitSentenceToWords(string sentence)
        {
            List<Word> words = new List<Word>();
            string[] split = sentence.Split(' ');
            foreach (string word in split)
            {
                words.Add(new Word(word));
            }
            return words;
        }
    }
}
