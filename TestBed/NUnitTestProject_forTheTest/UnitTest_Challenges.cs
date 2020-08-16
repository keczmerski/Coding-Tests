using NUnit.Framework;
using System.Collections.Generic;
using static TestBed.Challenges;

namespace NUnitTestProject_forTheTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            if (superBigWords == null || superBigReversedWords == null)
            {
                CreateReveseWordsOnlyTestWords("I am a tomato sandwich ", "I ma a otamot hciwdnas ", 1000);
            }
        }


        #region numbers
        #region Test_Skipping
        [Test]
        public void Test_ValueJump_Exceptions()
        {
            var ex1 = Assert.Throws<System.Exception>(() => Skipping(new int[] { 0 }));
            var ex2 = Assert.Throws<System.Exception>(() => Skipping(new int[] { 1, 0 }));
            var ex3 = Assert.Throws<System.Exception>(() => Skipping(new int[] { 1, 1, 0 }));
            var ex4 = Assert.Throws<System.Exception>(() => Skipping(new int[] { 0, 1, 1 }));
            var ex5 = Assert.Throws<System.Exception>(() => Skipping(new int[] { 0, 1, 1, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsTwo()
        {
            Assert.AreEqual(1, Skipping(new int[] { 0, 0 }));
            Assert.AreEqual(0, Skipping(new int[] { 0, 1 }));
        }
        [Test]
        public void Test_ValueJump_nIsThree()
        {
            Assert.AreEqual(1, Skipping(new int[] { 0, 0, 0 }));
            Assert.AreEqual(1, Skipping(new int[] { 0, 0, 1 }));
            Assert.AreEqual(1, Skipping(new int[] { 0, 1, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsFour()
        {
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 0, 0 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 1, 0 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 1, 0, 0 }));
            Assert.AreEqual(1, Skipping(new int[] { 0, 1, 0, 1 }));
        }
        [Test]
        public void Test_ValueJump_nIsFive()
        {
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 0, 0, 0 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 0, 0, 1 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 1, 0, 0 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 1, 0, 0, 0 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 1, 0, 1 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 1, 0, 0, 1 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 1, 0, 1, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsSix()
        {
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 0, 0, 0 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 0, 0, 0, 1 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 1, 0, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 1, 0, 0, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 1, 0, 0, 0, 0 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 0, 0, 1, 0, 1 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 1, 0, 0, 1 }));
            Assert.AreEqual(2, Skipping(new int[] { 0, 1, 0, 0, 0, 1 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 1, 0, 1, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 1, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 1, 0, 1, 0, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsSeven()
        {
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 0, 0, 0, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 0, 0, 0, 1 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 0, 0, 1, 0 }));
            Assert.AreEqual(4, Skipping(new int[] { 0, 0, 0, 0, 1, 0, 0 }));// this one?
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 1, 0, 0, 0 }));
            Assert.AreEqual(4, Skipping(new int[] { 0, 0, 1, 0, 0, 0, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 1, 0, 0, 0, 0, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 0, 1, 0, 1 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 0, 0, 1, 0, 1, 0 }));
            Assert.AreEqual(4, Skipping(new int[] { 0, 0, 1, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Skipping(new int[] { 0, 1, 0, 0, 0, 1, 0 }));
            Assert.AreEqual(4, Skipping(new int[] { 0, 0, 1, 0, 1, 0, 0 }));
        }
        #endregion


        [Test]
        public void IntArrayRotationRightTest()
        {
            int[] testResultArrayA = new int[] { 1, 2, 3, 4, 5 };
            int[] testArrayA = new int[] { 2, 3, 4, 5, 1 };
            int[] testResultArrayB = new int[] { 1, 2, 3, 4 };
            int[] testArrayB = new int[] { 2, 3, 4, 1 };
            int[] testResultArrayC = new int[] { 1 };
            int[] testArrayC = new int[] { 1 };
            int[] testResultArrayD = new int[] { };
            int[] testArrayD = new int[] { };

            Assert.AreEqual(testResultArrayA, IntArrayRotateRight(testArrayA));
            Assert.AreEqual(testResultArrayB, IntArrayRotateRight(testArrayB));
            Assert.AreEqual(testResultArrayC, IntArrayRotateRight(testArrayC));
            Assert.AreEqual(testResultArrayD, IntArrayRotateRight(testArrayD));
        }

        [Test]
        public void IntArrayRotationTest()
        {
            int[] testArrayA = new int[] { 1, 2, 3, 4, 5 };
            int[] testResultArrayA = new int[] { 2, 3, 4, 5, 1 };
            int[] testArrayB = new int[] { 1, 2, 3, 4 };
            int[] testResultArrayB = new int[] { 2, 3, 4, 1 };
            int[] testArrayC = new int[] { 1 };
            int[] testResultArrayC = new int[] { 1 };
            int[] testArrayD = new int[] { };
            int[] testResultArrayD = new int[] { };

            Assert.AreEqual(testResultArrayA, IntArrayRotate(testArrayA));
            Assert.AreEqual(testResultArrayB, IntArrayRotate(testArrayB));
            Assert.AreEqual(testResultArrayC, IntArrayRotate(testArrayC));
            Assert.AreEqual(testResultArrayD, IntArrayRotate(testArrayD));
        }

        #endregion

        #region Strings and Chars
        [Test]
        public void AllSubStringTest()
        {
            Assert.AreEqual("a ab abc abcd b bc bcd c cd d", AllSubString("abcd"));
            Assert.IsTrue(AllSubString("hello world").Contains("d"));
            Assert.IsTrue(AllSubString("hello world").Contains("world"));
            Assert.IsTrue(AllSubString("hello world").Contains("o w"));
            Assert.AreEqual(null, AllSubString(null));
            Assert.AreEqual("", AllSubString(""));
        }
        [Test]
        public void RemoveDuplicateCharsStringTest()
        {
            Assert.AreEqual("helo wrd", RemoveDuplicateChars("hello world"));
            Assert.AreEqual("csharpone", RemoveDuplicateChars("csharpcorner"));
            Assert.DoesNotThrow(() => RemoveDuplicateChars(null));
            Assert.AreEqual(RemoveDuplicateChars(""), "");
        }
        [Test]
        public void ReverseStringTest()
        {
            Assert.DoesNotThrow(() => Reverse(null));

            //Assert.That(ex.Message == "Not a positive real number");
            Assert.AreEqual("", Reverse(""));
            Assert.AreEqual("dlrow olleh", Reverse("hello world"));
            Assert.AreEqual("tac", Reverse("cat"));
            Assert.AreEqual("ttac", Reverse("catt"));
            Assert.AreEqual("ttacFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", Reverse("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFcatt"));
        }

        
        [Test]
        public void PalendromeStringTest()
        {
            Assert.IsFalse( IsPalendrome(null));

            Assert.IsTrue(IsPalendrome("PAP"));
            Assert.IsTrue(IsPalendrome("PAAP"));
            Assert.IsFalse(IsPalendrome(""));
            Assert.IsFalse(IsPalendrome("PAr"));
            Assert.IsFalse(IsPalendrome("PArt"));
        }
        [Test]
        public void ReverseWordStringTest()
        {
            Assert.AreEqual("sandwich tomato a am I.", ReverseWords(".I am a tomato sandwich") );
            Assert.AreEqual("corner Csharp to Welcome",ReverseWords("Welcome to Csharp corner") );
            Assert.DoesNotThrow(() => ReverseWords(null));
            Assert.AreEqual(ReverseWords(""), "");
        }
        
        [Test]
        public void ReverseWordOnlyStringTest()
        {
            Assert.AreEqual(".I ma a otamot hciwdnas", ReverseOnlyWords(".I am a tomato sandwich"));
            Assert.AreEqual("emocleW ot prahsC renroc", ReverseOnlyWords("Welcome to Csharp corner"));
            Assert.DoesNotThrow(() => ReverseOnlyWords(null));
            Assert.AreEqual(ReverseOnlyWords(""), "");
        }
        [Test]
        public void ReverseOnlyWords_RevisedStringTest()
        {
            Assert.AreEqual("emocleW ot prahsC renroc", ReverseOnlyWords_Revised("Welcome to Csharp corner"));
            Assert.AreEqual(".I ma a otamot hciwdnas", ReverseOnlyWords_Revised(".I am a tomato sandwich"));
            Assert.AreEqual(".I ma a otamot dnas.hciw", ReverseOnlyWords_Revised(".I am a tomato sand.wich"));
            Assert.DoesNotThrow(() => ReverseOnlyWords_Revised(null));
            Assert.AreEqual(ReverseOnlyWords_Revised(""), "");
        }
        [Test]
        public void ReverseWordOnlyStringTest_Suggested()
        {
            //Assert.AreEqual(".I ma a otamot hciwdnas.", ReverseOnlyWords_Suggested(".I am a tomato sandwich."));
            //Assert.AreEqual(".I ma a otamot dnas.hciw.", ReverseOnlyWords_Suggested(".I am a tomato sand.wich."));
            Assert.AreEqual("emocleW ot prahsC renroc", ReverseOnlyWords_Suggested("Welcome to Csharp corner"));
            Assert.DoesNotThrow(() => ReverseOnlyWords_Suggested(null));
            Assert.AreEqual(ReverseOnlyWords_Suggested(""), "");
        }
        [Test]
        public void ReverseWordOnlyStringTest_SpeedTest()
        {
            Assert.DoesNotThrow(() => ReverseOnlyWords(superBigWords));
        }
        [Test]
        public void ReverseWordOnlyStringTest_DoubleSpeedTest()
        {
            Assert.DoesNotThrow(()=>ReverseOnlyWords(superBigWords+superBigWords));
        }
        [Test]
        public void ReverseWordOnlyStringTest_TrippleSpeedTest()
        {
            Assert.DoesNotThrow(() => ReverseOnlyWords(superBigWords + superBigWords + superBigWords + superBigWords));
        }
        [Test]
        public void ReverseWordOnlyStringTest_QuadSpeedTest()
        {
            Assert.DoesNotThrow(() => ReverseOnlyWords(superBigWords + superBigWords + superBigWords + superBigWords + superBigWords + superBigWords + superBigWords + superBigWords));
        }
        [Test]
        public void ReverseOnlyWords_RevisedStringTest_BigTest()
        {
            Assert.AreEqual(superBigReversedWords, ReverseOnlyWords_Revised(superBigWords));
        }
        [Test]
        public void ReverseWordOnlyStringTest_Suggested_BigTest()
        {
            Assert.AreEqual(superBigReversedWords, ReverseOnlyWords_Suggested(superBigWords));
        }

        private string superBigReversedWords = null;
        private string superBigWords = null;

        private void CreateReveseWordsOnlyTestWords(string ToBeReversed, string Reversed, int repeatedHowManyTimes)
        {
            System.Text.StringBuilder ToBe = new System.Text.StringBuilder();
            System.Text.StringBuilder done = new System.Text.StringBuilder();
            for(int i = 0; i<repeatedHowManyTimes; i++)
            {
                ToBe.Append(ToBeReversed);
                done.Append(Reversed);
            }
            superBigReversedWords = done.ToString().Trim();
            superBigWords = ToBe.ToString().Trim();
        }

        [Test]
        public void CharCounterStringTest()
        {
            Assert.IsTrue(LetterCounter("hello world").Contains("e - 1"));
            Assert.IsTrue(LetterCounter("hello world").Contains("o - 2"));
            Assert.IsTrue(LetterCounter("hello world").Contains("l - 3"));
            Assert.IsTrue(LetterCounter("hello world").Contains("d - 1"));
            Assert.AreEqual(null, LetterCounter(null));
            Assert.AreEqual("", LetterCounter(""));
        }
        #endregion
    }
}