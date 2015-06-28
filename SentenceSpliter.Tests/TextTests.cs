using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SentenceSpliter.Tests
{
    [TestClass]
    public class TextTests
    {
        Text text = new Text("a big sentance! Plus another sentance? and this  sentance.");

        [TestMethod]
        public void TestTextWordCount()
        {
            Assert.AreEqual((int)9, text.WordCount);
        }

        [TestMethod]
        public void TestSentenceCount()
        {
            Assert.AreEqual((int)3,text.SentenceCount);
        }

        [TestMethod]
        public void TestSentenceMostCommonWord()
        {
            Assert.AreEqual("sentance", text.FindMostCommonWord(0)[0]);
        }
    }
}
