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
        /// Gets the fist four words of the sentance for display purposes 
        /// </summary>
        public string SentenceSnippet
        {
            get
            {
                if (Words.Count == 0) // an empty list is going to give us problems, it's better to just return an empty string
                {
                    return "";
                }
                string sentenceSnippet = Words[0].WordTextPunctuation; // this is seperate from the main loop because the first word goes on with no space 
                for (int i = 1; i < Math.Min(Words.Count,4); i++) // I've used the Math.Min fuction here to aviod IndexOutOfRange exceptions
                {
                    sentenceSnippet += " " + Words[i].WordTextPunctuation;
                }
                if (Words.Count > 4) // if there's more than four words and add trailing dots, they make it easier to read
                {
                    sentenceSnippet += "...";
                }
                return sentenceSnippet;
            }
        }

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
            // these remove carriage returns
            sentence.Replace("\n", String.Empty);
            sentence.Replace("\r", String.Empty);
            sentence.Replace("\r\n", String.Empty);
            sentence.Replace("\n\r", String.Empty);

            if (!ValidSentance(sentence))  // basic check to see if the sentance is valid
            {
                throw new Exceptions.InvalidSentenceException(sentence);
            }
            Words = Word.SplitSentenceToWords(sentence);
        }

        /// <summary>
        /// This tests if a sentence is valid
        /// </summary>
        /// <param name="sentence">any string representing a sentence</param>
        /// <returns>true if the sentence is valid</returns>
        private static bool ValidSentance(string sentence)
        {
            string s = sentence.Substring(0, sentence.Length - 1); // removes the final charcter from the string

            if (s.Contains('?') || s.Contains('!') || s.Contains('.')) // if there exists a sentence terminator in the rest of the string the sentence isn't valid
            {
                return false;
            }
            else
            {
                return true;
            }
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
                if (sentence == "") // empty strings are valid sentences so let's just skip them
                {
                    continue;
                }
                sentences.Add(new Sentence(sentence));
            }
            return sentences;
        }
    }
}
