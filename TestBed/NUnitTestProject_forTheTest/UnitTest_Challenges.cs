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
        #region Test_GetAllGroupsOfThreeUniqueOperandsForSingleSum
        [Test]
        public void Test_getCountofOpperandOccurancesIn_ThreeUniqueOperandsForSingleSum()
        {
            Dictionary<int, int> CountofOpperandOccurances = GetCountofOpperandOccurancesIn_ThreeUniqueOperandsForSingleSum(15, 1, 9);

            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(1));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(2));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(3));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(4));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(5));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(6));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(7));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(8));
            Assert.IsTrue(CountofOpperandOccurances.ContainsKey(9));
            Assert.IsFalse(CountofOpperandOccurances.ContainsKey(10));
            Assert.IsFalse(CountofOpperandOccurances.ContainsKey(0));
            Assert.IsFalse(CountofOpperandOccurances.ContainsKey(-1));

            Assert.AreEqual(CountofOpperandOccurances[1], 2);
            Assert.AreEqual(CountofOpperandOccurances[2], 3);
            Assert.AreEqual(CountofOpperandOccurances[3], 2);
            Assert.AreEqual(CountofOpperandOccurances[4], 3);
            Assert.AreEqual(CountofOpperandOccurances[5], 4);
            Assert.AreEqual(CountofOpperandOccurances[6], 3);
            Assert.AreEqual(CountofOpperandOccurances[7], 2);
            Assert.AreEqual(CountofOpperandOccurances[8], 3);
            Assert.AreEqual(CountofOpperandOccurances[9], 2);
        }
        [Test]
        public void Test_GetAllGroupsOfThreeUniqueOperandsForSingleSum()
        {
            List<int[]> CountofOpperandOccurances = GetAllGroupsOfThreeUniqueOperandsForSingleSum(15, 1, 9);

            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 6, 5, 4));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 7, 5, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 7, 6, 2));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 8, 4, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 8, 5, 2));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 8, 6, 1));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 9, 4, 2));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 9, 5, 1));

            Assert.IsFalse(ContainsAllInAnyOrder(CountofOpperandOccurances, 10, 4, 1));
            Assert.IsFalse(ContainsAllInAnyOrder(CountofOpperandOccurances, 0, 14, 1));
            Assert.IsFalse(ContainsAllInAnyOrder(CountofOpperandOccurances, 0, 9, 6));

            Assert.IsFalse(IsContainsRepeatedValue(CountofOpperandOccurances));
        }
        [Test]
        public void Test_GetAllGroupsOfThreeUniqueOperandsForSingleSum_Offset()
        {
            List<int[]> CountofOpperandOccurances = GetAllGroupsOfThreeUniqueOperandsForSingleSum(16, 2, 10);

            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 7, 6, 5));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 8, 7, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 9, 6, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 10, 5, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 10, 6, 2));

            Assert.IsFalse(ContainsAllInAnyOrder(CountofOpperandOccurances, 11, 4, 1));
            Assert.IsFalse(ContainsAllInAnyOrder(CountofOpperandOccurances, 0, 14, 2));

            Assert.IsFalse(IsContainsRepeatedValue(CountofOpperandOccurances));
        }
        private bool ContainsAllInAnyOrder(List<int[]> Container, int a, int b, int c)
        {
            List<int[]> allPossibleOrdersOfAll = new List<int[]>{ new int[] { a, b, c }
                                                                , new int[] { a, c, b }
                                                                , new int[] { b, a, c }
                                                                , new int[] { b, c, b }
                                                                , new int[] { c, a, b }
                                                                , new int[] { c, b, a } };
            foreach (int[] groupAll in allPossibleOrdersOfAll)
            {
                foreach (int[] groupContainer in Container)
                {
                    if (groupContainer[0] == groupAll[0] && groupContainer[1] == groupAll[1] && groupContainer[2] == groupAll[2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsContainsRepeatedValue(List<int[]> Container)
        {
            for (int i = 0; i < Container.Count; i++)
            {
                if (IsContainsAllAtIndex_InAnyOrder_ExcludingIndexValue(Container, i))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsContainsAllAtIndex_InAnyOrder_ExcludingIndexValue(List<int[]> Container, int index)
        {
            int a = Container[index][0];
            int b = Container[index][1];
            int c = Container[index][2];
            List<int[]> allPossibleOrdersOfAll = new List<int[]>{ new int[] { a, b, c }
                                                                , new int[] { a, c, b }
                                                                , new int[] { b, a, c }
                                                                , new int[] { b, c, b }
                                                                , new int[] { c, a, b }
                                                                , new int[] { c, b, a } };
            bool IsContains = false;
            for (int i = 0; i < Container.Count; i++)
            {
                if (i != index)
                {
                    foreach (int[] group in allPossibleOrdersOfAll)
                    {
                        if (Container[i] == group)
                        {
                            IsContains = true;
                        }
                    }
                }
            }
            return IsContains;
        }
        #endregion

        [Test]
        public void TwoSum_Test()
        {
            Assert.AreEqual((new int[] { 0, 1 }), TwoSum(new int[] { 1, 2 }, 3));
            Assert.AreEqual((new int[] { 0, 1 }), TwoSum(new int[] { 1, 2, 7, 8, 3, 4546, 3, 67, 3, 4 }, 3));
            Assert.AreEqual((new int[] { 8, 9 }), TwoSum(new int[] { 10, 20, 7, 8, 3, 4546, 3, 67, 1, 2 }, 3));
            Assert.AreEqual((new int[] { 4, 5 }), TwoSum(new int[] { 10, 20, 7, 8, 3, 0, 3, 67, 1, 2 }, 3));

            var ex = Assert.Throws<System.ArgumentException>(() => TwoSum(new int[] { 10, 20, 7, 8, 3, 0, 3, 67, 1, 2 }, 345345));
            Assert.IsTrue(ex.Message.ToLower().Contains("not found"));
            Assert.Throws<System.ArgumentException>(() => TwoSum(new int[] { }, 345345));
            Assert.Throws<System.ArgumentException>(() => TwoSum(new int[] { 345345 }, 345345));
            Assert.Throws<System.ArgumentNullException>(() => TwoSum(null, 345345));
        }

        [Test]
        public void SecondLargestTest()
        {
            int[] testArrayA = new int[] { 2, 3, 45, 4, 60, 5, 1 };
            int[] testArrayB = new int[] { 2, 3, 4, 1 };
            int[] testArrayE = new int[] { -2, -3, 4, -1 };
            int[] testArrayF = new int[] { -2, 3, 4, 4 };
            int[] testArrayC = new int[] { 1 };
            int[] testArrayD = new int[] { };
            int[] testArrayG = new int[] { 2, 3, 45, 4, 60, 5, 1, 60 };

            Assert.AreEqual(45, FindSecondLargeInArray(testArrayA));
            Assert.AreEqual(3, FindSecondLargeInArray(testArrayB));
            Assert.AreEqual(-1, FindSecondLargeInArray(testArrayE));
            Assert.AreEqual(3, FindSecondLargeInArray(testArrayF));
            Assert.AreEqual(45, FindSecondLargeInArray(testArrayG));

            Assert.AreEqual(-1, FindSecondLargeInArray(testArrayD));
            Assert.AreEqual(-1, FindSecondLargeInArray(testArrayC));
            var ex = Assert.Throws<System.ArgumentNullException>(() => FindSecondLargeInArray(null));

            Assert.IsTrue(ex.Message.Contains("InitialValue"));
        }
        [Test]
        public void IntAdditionTest()
        {
            Assert.AreEqual(6, SumOfDigits(123));
            Assert.AreEqual(15, SumOfDigits(168));
            Assert.AreEqual(21, SumOfDigits(1668));
            Assert.AreEqual(1, SumOfDigits(1));
        }

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

        [Test]
        public void PrimeTest()
        {
            Assert.IsFalse( IsPrime(21) );
            Assert.IsFalse( IsPrime(100) );
            Assert.IsFalse( IsPrime(100000) );

            Assert.IsTrue( IsPrime(1) );
            Assert.IsTrue( IsPrime(2) );
            Assert.IsTrue( IsPrime(3) );
            Assert.IsTrue( IsPrime(7) );

            Assert.IsFalse( IsPrime(-1) );
            Assert.IsFalse( IsPrime(0) );
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