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
        public void RestoreIpAddresses_Test()
        {
            

            Assert.DoesNotThrow(()=> RestoreIpAddresses("0279245587303"));
            Assert.AreEqual(new string[] { "0.10.0.10", "0.100.1.0" }, RestoreIpAddresses("010010"));
            Assert.AreEqual(new string[] { "1.1.1.1" }, RestoreIpAddresses("1111"));
            
            Assert.AreEqual(new string[] { "255.255.11.135", "255.255.111.35" }, RestoreIpAddresses("25525511135"));
        }

        [Test]
        public void RepeatedString_Test()
        {


            Assert.AreEqual(4, RepeatedString("a", 4));
            Assert.AreEqual(4, RepeatedString("aa", 4));
            Assert.AreEqual(8, RepeatedString("aa", 8));
            Assert.AreEqual(7, RepeatedString("aa", 7));
            Assert.AreEqual(400, RepeatedString("a", 400));
            Assert.AreEqual(999999999, RepeatedString("a", 999999999));
            Assert.AreEqual(1, RepeatedString("a0", 1));
            Assert.AreEqual(1, RepeatedString("a0", 2));
            Assert.AreEqual(2, RepeatedString("a0", 3));
            Assert.AreEqual(0, RepeatedString("0a", 1));
            Assert.AreEqual(1, RepeatedString("0a", 2));
            Assert.AreEqual(1, RepeatedString("0a", 3));
            Assert.AreEqual(1, RepeatedString("a0a", 1));
            Assert.AreEqual(1, RepeatedString("a0a", 2));
            Assert.AreEqual(2, RepeatedString("a0a", 3));
            Assert.AreEqual(3, RepeatedString("a0a", 4));
            Assert.AreEqual(3, RepeatedString("a0a", 5));
            Assert.AreEqual(4, RepeatedString("a0a", 6));
            Assert.AreEqual(5, RepeatedString("a0a", 7));
            Assert.AreEqual(0, RepeatedString("0a0a0", 1));
            Assert.AreEqual(1, RepeatedString("0a0a0", 2));
            Assert.AreEqual(1, RepeatedString("0a0a0", 3));
            Assert.AreEqual(2, RepeatedString("0a0a0", 4));
            Assert.AreEqual(2, RepeatedString("0a0a0", 5));
            Assert.AreEqual(2, RepeatedString("0a0a0", 6));
            Assert.AreEqual(3, RepeatedString("0a0a0", 7));
            Assert.AreEqual(4, RepeatedString("0a0a0", 9));
            Assert.AreEqual(999999999, RepeatedString("a", 999999999));
            Assert.AreEqual(999999999999999999, RepeatedString("a", 999999999999999999));
            Assert.AreEqual(999999999999999999, RepeatedString("aaa", 999999999999999999));
            Assert.AreEqual(100, RepeatedString("0a", 200));

            Assert.AreEqual(0, RepeatedString("0000", 4));
            Assert.AreEqual(0, RepeatedString("0000", 400000));
            Assert.AreEqual(1, RepeatedString("a", 1));
            Assert.AreEqual(1, RepeatedString("aa", 1));
            Assert.AreEqual(2, RepeatedString("aa", 2));
        }

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