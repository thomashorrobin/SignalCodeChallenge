using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SentenceSpliter.Exceptions;

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
                return WordTextPunctuation.TrimEnd(new char[]{ '.','!','?',',' }); // this removes puncutation from the END of the word, punctuation and the start of a word is invalid.
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
            string w = word.Trim();
            if (w == "" || w.Contains(' ')) // words that are empty strings or contain spaces are invalid
            {
                InvalidWordException ex = new InvalidWordException(word);
                throw ex;
            }
            WordTextPunctuation = w;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns>Returns a list of words </returns>
        internal static List<Word> SplitSentenceToWords(string sentence)
        {
            List<Word> words = new List<Word>();
            string[] split = sentence.Split(' '); // splits sentances based on a space, the only way to distiguish between words
            foreach (string word in split)
            {
                if (word == "") // words that are empty strings are not useful and should be ignored
                {
                    continue;
                }
                try
                {
                    words.Add(new Word(word)); // attempt to add string as a word
                }
                catch (InvalidWordException ex)
                {
                    ex.SentenceText = sentence; // adding this info to the exception will be useful further upstream 
                    throw ex;
                }
            }
            return words;
        }
    }
}
