using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using GatherTextStatistics;
using System.Linq;

namespace NUnitTestRingba
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FocusOnCountingLetters()
        {
            string StringToTest = "ASDFASDASAqwerqweqwqZXCVzxcvZXCzxcZXzxZz IIIIIIIIII IIIIIIIIII IIIIIIIIII IIIIIIIIII IIIIIIIIII";

            Dictionary<char, int> ExpectedLetterCount = new Dictionary<char, int>
            {
                ['A'] = 4,
                ['S'] = 3,
                ['D'] = 2,
                ['F'] = 1,

                ['Q'] = 4,
                ['W'] = 3,
                ['E'] = 2,
                ['R'] = 1,

                ['Z'] = 8,
                ['X'] = 6,
                ['C'] = 4,
                ['V'] = 2,

                ['I'] = 50
            };
            int expectedCapitalizationCount = 50 + 8 + 6 + 4 + 2;
            string ExpectedHighestWord = "I";
            int ExpectedHighestWordCount = 46;

            List<string> expectedPrefixes_all = new List<string>
            {
                "Aqwerqweqw",
                "Vzxc",
                "Czx",
                "Xz",
                "Zz"
            };
            List<string> NotExpectedPrefixes_all = new List<string>
            {
                "Aq",
                "Aqw",
                "Aqwe",
                "Aqwer",
                "Aqwerq",
                "Aqwerqw",
                "Aqwerqwe",
                "Aqwerqweq",
                "Vz",
                "Vzx",
                "Cz"
            };
            int ExpectedPrefixCount = 1;

            GatherTextStatistics.Program.CheckEachChar(StringToTest, out AlphaCounterTracker LetterCount,
                out WordCounterTracker WordCount,
                out int CapitalizationCount,
                out PrefixCounterTracker AnyPrefixCount);

            foreach (char c in ExpectedLetterCount.Keys)
            {
                Assert.AreEqual(ExpectedLetterCount[c], LetterCount.GetValue(c));
            }
            Assert.AreEqual(ExpectedHighestWordCount, WordCount.HighestOccuranceCount);
            string HighestWordResults = WordCount.GetGeneralCountResults();

            Assert.IsTrue(HighestWordResults.Contains($"{ExpectedHighestWord}"));

            Assert.AreEqual(expectedCapitalizationCount, CapitalizationCount);
            Assert.AreEqual(ExpectedPrefixCount, AnyPrefixCount.HighestOccuranceCount);
            foreach (string s in expectedPrefixes_all)
            {
                Assert.IsTrue(AnyPrefixCount.HighestIncludes(s));
            }
            foreach (string s in NotExpectedPrefixes_all)
            {
                Assert.IsFalse(AnyPrefixCount.HighestIncludes(s));
            }
        }

        [Test]
        public void FocusOnCountingThreeLetterPrefixes()
        {
            string StringToTest = "PreFixPrefixPredicatePresumeFixateMarsMarylandMakingPrintPristine";

            Dictionary<char, int> ExpectedLetterCount = new Dictionary<char, int>
            {
                ['P'] = 6,
                ['E'] = 8
            };
            int expectedCapitalizationCount = 11;
            List<string> ExpectedHighestWords = new List<string>
            {
                "Pre", "Fix", "Prefix", "Predicate", "Presume", "Fixate", "Mars", "Maryland", "Making", "Print", "Pristine"
            };
            List<string> ExpectedWordsForHighestPrefix = new List<string>
            {
                "Pre","Prefix", "Predicate", "Presume", "Print", "Pristine"
            };
            List<string> NotExpectedWordsForHighestPrefix = new List<string>
            {
                "Fix", "Fixate", "Mars", "Maryland", "Making"
            };
            int ExpectedHighestWordCount = 1;

            List<string> expectedPrefixes_all = new List<string>
            {
                "Pr"
            };
            string expectedPrefix_all = "Pr";
            int ExpectedPrefixCount = 6;

            GatherTextStatistics.Program.CheckEachChar(StringToTest, out AlphaCounterTracker LetterCount,
                out WordCounterTracker WordCount,
                out int CapitalizationCount,
                out PrefixCounterTracker AnyPrefixCount);

            foreach (char c in ExpectedLetterCount.Keys)
            {
                Assert.AreEqual(ExpectedLetterCount[c], LetterCount.GetValue(c));
            }
            Assert.AreEqual(ExpectedHighestWordCount, WordCount.HighestOccuranceCount);
            foreach (string s in ExpectedHighestWords)
            {
                Assert.IsTrue(WordCount.HighestIncludes(s));
            }
            Assert.AreEqual(expectedCapitalizationCount, CapitalizationCount);
            Assert.AreEqual(ExpectedPrefixCount, AnyPrefixCount.HighestOccuranceCount);
            foreach (string s in expectedPrefixes_all)
            {
                Assert.IsTrue(AnyPrefixCount.HighestIncludes(s));
            }
            foreach (string s in ExpectedWordsForHighestPrefix)
            {
                Assert.IsTrue(AnyPrefixCount.AssociatedIncludes(expectedPrefix_all, s));
            }
            foreach (string s in NotExpectedWordsForHighestPrefix)
            {
                Assert.IsFalse(AnyPrefixCount.AssociatedIncludes(expectedPrefix_all, s));
            }
        }

        [Test]
        public void FocusOnCountingLongLetterPrefixes()
        {
            string StringToTest = "AreallylongprefixthatendsinadifferentlettersometimesaAreallylongprefixthatendsinadifferentlettersometimesbAreallylongprefixthatendsinadifferentlettersometimescAreallylongprefixthatendsinadifferentlettersometimesc";

            Dictionary<char, int> ExpectedLetterCount = new Dictionary<char, int>
            {
                ['G'] = 4
            };
            int expectedCapitalizationCount = 4;
            List<string> ExpectedHighestWords = new List<string>
            {
                "Areallylongprefixthatendsinadifferentlettersometimesc"
            };
            int ExpectedHighestWordCount = 2;

            List<string> expectedPrefixes_all = new List<string>
            {
                "Areallylongprefixthatendsinadifferentlettersometimes"
            };
            List<string> expectedPrefixes_Two = new List<string>
            {
                "Ar"
            };
            int ExpectedPrefixTwoCount = 4;

            GatherTextStatistics.Program.CheckEachChar(StringToTest, out AlphaCounterTracker LetterCount,
                out WordCounterTracker WordCount,
                out int CapitalizationCount,
                out PrefixCounterTracker AnyPrefixCount);

            foreach (char c in ExpectedLetterCount.Keys)
            {
                Assert.AreEqual(ExpectedLetterCount[c], LetterCount.GetValue(c));
            }
            Assert.AreEqual(ExpectedHighestWordCount, WordCount.HighestOccuranceCount);
            foreach (string s in ExpectedHighestWords)
            {
                Assert.IsTrue(WordCount.HighestIncludes(s));
            }
            Assert.AreEqual(expectedCapitalizationCount, CapitalizationCount);
            Assert.AreEqual(ExpectedPrefixTwoCount, AnyPrefixCount.HighestOccuranceCount);
            foreach (string s in expectedPrefixes_all)
            {
                Assert.IsTrue(AnyPrefixCount.HighestIncludes(s));
            }
            foreach (string s in expectedPrefixes_Two)
            {
                Assert.IsFalse(AnyPrefixCount.HighestIncludes(s));
            }
        }
        [Test]
        public void EdgeCaseEmptyishFIle()
        {
            string StringToTest = "";

            Dictionary<char, int> ExpectedLetterCount = new Dictionary<char, int>
            {
                ['G'] = 0
            };
            int expectedCapitalizationCount = 0;
            List<string> ExpectedHighestWords = new List<string>
            {
            };
            int ExpectedHighestWordCount = 0;

            List<string> expectedPrefixes_all = new List<string>
            {
            };
            List<string> expectedPrefixes_Two = new List<string>
            {
            };
            int ExpectedPrefixTwoCount = 0;

            GatherTextStatistics.Program.CheckEachChar(StringToTest, out AlphaCounterTracker LetterCount,
                out WordCounterTracker WordCount,
                out int CapitalizationCount,
                out PrefixCounterTracker AnyPrefixCount);

            foreach (char c in ExpectedLetterCount.Keys)
            {
                Assert.AreEqual(ExpectedLetterCount[c], LetterCount.GetValue(c));
            }
            Assert.AreEqual(ExpectedHighestWordCount, WordCount.HighestOccuranceCount);
            foreach (string s in ExpectedHighestWords)
            {
                Assert.IsTrue(WordCount.HighestIncludes(s));
            }
            Assert.AreEqual(expectedCapitalizationCount, CapitalizationCount);
            Assert.AreEqual(ExpectedPrefixTwoCount, AnyPrefixCount.HighestOccuranceCount);
            foreach (string s in expectedPrefixes_all)
            {
                Assert.IsTrue(AnyPrefixCount.HighestIncludes(s));
            }
            foreach (string s in expectedPrefixes_Two)
            {
                Assert.IsFalse(AnyPrefixCount.HighestIncludes(s));
            }
        }
        [Test]
        public void EdgeCaseWordsWithNonLetters()
        {
            string StringToTest = "F123dF1234dD55ssd";

            Dictionary<char, int> ExpectedLetterCount = new Dictionary<char, int>
            {
                ['F'] = 2,
                ['D'] = 4
            };
            int expectedCapitalizationCount = 3;
            List<string> ExpectedHighestWords = new List<string>
            {
                "F123d","F1234d","D55ssd"
            };
            int ExpectedHighestWordCount = 1;

            List<string> expectedPrefixes_all = new List<string>
            {
                "F123"
            };
            List<string> expectedPrefixes_Two = new List<string>
            {
                "F12"
            };
            int ExpectedPrefixAllCount = 2;


            GatherTextStatistics.Program.CheckEachChar(StringToTest, out AlphaCounterTracker LetterCount,
                out WordCounterTracker WordCount,
                out int CapitalizationCount,
                out PrefixCounterTracker AnyPrefixCount);

            foreach (char c in ExpectedLetterCount.Keys)
            {
                Assert.AreEqual(ExpectedLetterCount[c], LetterCount.GetValue(c));
            }
            Assert.AreEqual(ExpectedHighestWordCount, WordCount.HighestOccuranceCount);
            foreach (string s in ExpectedHighestWords)
            {
                Assert.IsTrue(WordCount.HighestIncludes(s));
            }
            Assert.AreEqual(expectedCapitalizationCount, CapitalizationCount);
            Assert.AreEqual(ExpectedPrefixAllCount, AnyPrefixCount.HighestOccuranceCount);
            foreach (string s in expectedPrefixes_all)
            {
                Assert.IsTrue(AnyPrefixCount.HighestIncludes(s));
            }
            foreach (string s in expectedPrefixes_Two)
            {
                Assert.IsFalse(AnyPrefixCount.HighestIncludes(s));
            }
        }
    }
}