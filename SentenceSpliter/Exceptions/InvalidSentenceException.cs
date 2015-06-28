using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter.Exceptions
{
    public class InvalidSentenceException : Exception
    {
        public string SentenceText { get; set; }

        public InvalidSentenceException(string sentenceText)
        {
            SentenceText = sentenceText;
        }
    }
}
