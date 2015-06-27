using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSpliter
{
    class Word
    {
        public string WordText { get; private set; }

        public Word(string word)
        {
            WordText = word.Trim();
        }
    }
}
