using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SentenceSpliter.Tests
{
    [TestClass]
    public class SentenceTests
    {
        Sentence sentence = new Sentence("A big nEw sentance, eh?");

        [TestMethod]
        public void TestWordCount()
        {
            Assert.AreEqual((int)5, sentence.WordCount, "Word count should be five");
        }

        [TestMethod]
        public void TestLastWord()
        {
            Assert.AreEqual("eh", sentence.Words[4].WordText);
        }

        [TestMethod]
        public void TestFourthWord()
        {
            Assert.AreEqual("sentance", sentence.Words[3].WordText);
        }
    }
}
