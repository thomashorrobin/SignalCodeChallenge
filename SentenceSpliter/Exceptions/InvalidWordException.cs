using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter.Exceptions
{
    public class InvalidWordException : Exception
    {
        public string WordText { get; set; }
        public string SentenceText { get; set; }

        public InvalidWordException(string wordText)
        {
            WordText = wordText;
        }
    }
}
