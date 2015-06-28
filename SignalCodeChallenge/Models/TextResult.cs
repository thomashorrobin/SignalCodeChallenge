using SentenceSpliter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCodeChallenge.Models
{
    public class TextResult
    {
        public int SentenceCount { get; private set; }
        public int WordCount { get; private set; }
        public string LongestSentences { get; private set; }
        public string MostCommonWords { get; private set; }
        public string LongestWords { get; private set; }

        public TextResult(Text text)
        {
            SentenceCount = text.SentenceCount;
            WordCount = text.WordCount;
            List<Sentence> sentences = text.FindSentenceWithMostWords(0);
            if (sentences.Count > 0)
            {
                LongestSentences = sentences[0].SentenceSnippet;
                for (int i = 1; i < sentences.Count; i++)
                {
                    LongestSentences += ", " + sentences[i].SentenceSnippet;
                }
            }
            List<string> commonWords = text.FindMostCommonWord(0);
            if (commonWords.Count > 0)
            {
                MostCommonWords = commonWords[0];
                for (int i = 1; i < commonWords.Count; i++)
                {
                    MostCommonWords += ", " + commonWords[i];
                }
            }
            List<string> longestWords = text.FindLongestWord(2);
            if (longestWords.Count > 0)
            {
                LongestWords = longestWords[0];
                for (int i = 1; i < longestWords.Count; i++)
                {
                    LongestWords += ", " + longestWords[i];
                }
            }
        }
    }
}
