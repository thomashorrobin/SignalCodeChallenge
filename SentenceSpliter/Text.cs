using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter
{
    class Text
    {
        public List<Sentence> Sentences { get; private set; }

        public Text(string text)
        {
            Sentences = SplitTextToSentances(text);
        }

        /// <summary>
        /// this takes a full text and splits it into sentances
        /// </summary>
        /// <param name="text">A full text containing multiple sentances</param>
        /// <returns>Return a list of sentance objects</returns>
        private static List<Sentence> SplitTextToSentances(string text)
        {
            List<Sentence> sentences = new List<Sentence>();
            string[] split = text.Split(new char[] { '.', '!', '?' }); // this splits the oririginal text into a set of strings based on sentance terminators 

            return sentences;
        }
    }
}
