using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentenceSpliter;
using SentenceSpliter.Exceptions;

namespace SentenceSpliter.Tests
{
    [TestClass]
    public class WordUnitTest
    {
        [TestMethod]
        public void TestPunctuation()
        {
            Word word = new Word("word?");
            Assert.AreEqual("word", word.WordText, false);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidWordException),"Comma at frount of word should throw an exception")]
        public void TextPunctuationAtStartThrowsException()
        {
            Word word = new Word("ej fwe");
        }

        [TestMethod]
        public void TestWordLength()
        {
            Word word = new Word("biggEr?");
            Assert.AreEqual((int)6, word.WordLength,"Word length should be 6");
        }
    }
}
