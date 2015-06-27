using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter.Exceptions
{
    class InvalidSentenceException
    {
        public string SentenceText { get; set; }

        public InvalidSentenceException(string sentenceText)
        {
            SentenceText = sentenceText;
        }
    }
}
