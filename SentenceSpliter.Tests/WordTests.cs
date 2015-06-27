using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentenceSpliter;

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
        public void TestWordLength()
        {
            Word word = new Word("biggEr?");
            Assert.AreEqual((int)6, word.WordLength,"Word length should be 6");
        }
    }
}
