using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SentenceSpliter.Tests
{
    [TestClass]
    public class TestIntergenExample
    {
        Text text = new Text("Intergen is New Zealand's most experienced provider of Microsoft based business solutions. We focus on delivering business value in our solutions and work closely with Microsoft to ensure we have the best possible understanding of their technologies and directions. Intergen is a Microsoft Gold Certified Partner with this status recognising us as an \"elite business partner\" for implementing solutions based on our capabilities and experience with Microsoft products.");

        [TestMethod]
        public void TestSentanceCount()
        {
            Assert.AreEqual((int)3,text.SentenceCount);
        }

        [TestMethod]
        public void TestWordCount()
        {
            Assert.AreEqual((int)68, text.WordCount);
        }

        [TestMethod]
        public void TestMostCommonWord()
        {
            Assert.AreEqual("Microsoft", text.FindMostCommonWord()[0]);
        }

        [TestMethod]
        public void TestLongestSentence()
        {
            Assert.AreEqual("Microsoft", text.FindSentenceWithMostWords()[0].Words[3].WordText);
        }

        [TestMethod]
        public void TestThirdLongestWords()
        {
            Assert.AreEqual((int)2, text.FindLongestWord(2).Count);
        }
    }
}
