using NUnit.Framework;
using System.Collections.Generic;
using TestBed;

namespace NUnitTestProject_forTheTest
{
    public class Tests
    {
        private int[] superLargeTestArrayOfOnesAndZeros = null;
        private int[] superLargeTestArrayOfOnesAndZeros_WorstCase = null;
        [SetUp]
        public void Setup()
        {
            int LengthOfSuperLargeTestArray = 10000000;
            if (superLargeTestArrayOfOnesAndZeros == null)
            {
                superLargeTestArrayOfOnesAndZeros = GetTestArrayOfSize(LengthOfSuperLargeTestArray);
            }
            if (superLargeTestArrayOfOnesAndZeros_WorstCase == null)
            {
                superLargeTestArrayOfOnesAndZeros_WorstCase = GetTestArrayOfSize_Worstcase(LengthOfSuperLargeTestArray);
            }
        }
        [Test]
        public void Test_ValueJump_Exceptions()
        {
            var ex1 = Assert.Throws<System.Exception>(() => Challenges.Skipping(new int[] { 0 }));
            var ex2 = Assert.Throws<System.Exception>(() => Challenges.Skipping(new int[] { 1, 0 }));
            var ex3 = Assert.Throws<System.Exception>(() => Challenges.Skipping(new int[] { 1, 1, 0 }));
            var ex4 = Assert.Throws<System.Exception>(() => Challenges.Skipping(new int[] { 0, 1, 1 }));
            var ex5 = Assert.Throws<System.Exception>(() => Challenges.Skipping(new int[] { 0, 1, 1, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsTwo()
        {
            Assert.AreEqual(1, Challenges.Skipping(new int[] { 0, 0 }));
            Assert.AreEqual(0, Challenges.Skipping(new int[] { 0, 1 }));
        }
        [Test]
        public void Test_ValueJump_nIsThree()
        {
            Assert.AreEqual(1, Challenges.Skipping(new int[] { 0, 0, 0 }));
            Assert.AreEqual(1, Challenges.Skipping(new int[] { 0, 0, 1 }));
            Assert.AreEqual(1, Challenges.Skipping(new int[] { 0, 1, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsFour()
        {
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 0, 0 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 1, 0 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 1, 0, 0 }));
            Assert.AreEqual(1, Challenges.Skipping(new int[] { 0, 1, 0, 1 }));
        }
        [Test]
        public void Test_ValueJump_nIsFive()
        {
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 0, 0, 0 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 0, 0, 1 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 1, 0, 0 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 1, 0, 0, 0 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 1, 0, 1 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 1, 0, 0, 1 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 1, 0, 1, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsSix()
        {
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 0, 0, 0 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 0, 0, 0, 1 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 1, 0, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 1, 0, 0, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 1, 0, 0, 0, 0 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 0, 0, 1, 0, 1 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 1, 0, 0, 1 }));
            Assert.AreEqual(2, Challenges.Skipping(new int[] { 0, 1, 0, 0, 0, 1 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 1, 0, 1, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 1, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 1, 0, 1, 0, 0 }));
        }
        [Test]
        public void Test_ValueJump_nIsSeven()
        {
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 0, 0, 0, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 0, 0, 0, 1 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 0, 0, 1, 0 }));
            Assert.AreEqual(4, Challenges.Skipping(new int[] { 0, 0, 0, 0, 1, 0, 0 }));// this one?
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 1, 0, 0, 0 }));
            Assert.AreEqual(4, Challenges.Skipping(new int[] { 0, 0, 1, 0, 0, 0, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 1, 0, 0, 0, 0, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 0, 1, 0, 1 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 0, 0, 1, 0, 1, 0 }));
            Assert.AreEqual(4, Challenges.Skipping(new int[] { 0, 0, 1, 0, 0, 1, 0 }));
            Assert.AreEqual(3, Challenges.Skipping(new int[] { 0, 1, 0, 0, 0, 1, 0 }));
            Assert.AreEqual(4, Challenges.Skipping(new int[] { 0, 0, 1, 0, 1, 0, 0 }));
        }

        [Test]
        public void Test_getCountofOpperandOccurancesIn_ThreeUniqueOperandsForSingleSum()
        {
            Dictionary<int, int> CountofOpperandOccurances = Challenges.GetCountofOpperandOccurancesIn_ThreeUniqueOperandsForSingleSum(15, 1, 9);

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
            List<int[]> CountofOpperandOccurances = Challenges.GetAllGroupsOfThreeUniqueOperandsForSingleSum(15, 1, 9);

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
            List<int[]> CountofOpperandOccurances = Challenges.GetAllGroupsOfThreeUniqueOperandsForSingleSum(16, 2, 10);

            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 7, 6, 5));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 8, 7, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 9, 6, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 10, 5, 3));
            Assert.IsTrue(ContainsAllInAnyOrder(CountofOpperandOccurances, 10, 6, 2));

            Assert.IsFalse(ContainsAllInAnyOrder(CountofOpperandOccurances, 11, 4, 1));
            Assert.IsFalse(ContainsAllInAnyOrder(CountofOpperandOccurances, 0, 14, 2));
            
            Assert.IsFalse(IsContainsRepeatedValue(CountofOpperandOccurances));
        }
        private bool ContainsAllInAnyOrder(List<int[]>Container, int a, int b, int c)
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
                if(IsContainsAllAtIndex_InAnyOrder_ExcludingIndexValue(Container, i))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsContainsAllAtIndex_InAnyOrder_ExcludingIndexValue(List<int[]> Container,  int index)
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
            for(int i = 0; i < Container.Count; i++)
            {
                if(i != index)
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

        [Test]
        public void SecondLargestTest()
        {
            int[] testArrayA = new int[] { 2, 3, 45,4,60, 5, 1 };
            int[] testArrayB = new int[] { 2, 3, 4, 1 };
            int[] testArrayE = new int[] { -2, -3, 4, -1 };
            int[] testArrayF = new int[] { -2, 3, 4, 4 };
            int[] testArrayC = new int[] { 1 };
            int[] testArrayD = new int[] { };

            var ex = Assert.Throws<System.Exception>(() => TestBed.Challenges.FindSecondLargeInArray(testArrayC));
            // now we can test the exception itself
            string ExpectedError = "Array has less than two unique values.";
            Assert.IsTrue(ex.Message.Contains(ExpectedError));

            Assert.AreEqual(45, Challenges.FindSecondLargeInArray(testArrayA));
            Assert.AreEqual(3, Challenges.FindSecondLargeInArray(testArrayB));
            Assert.AreEqual(-1, Challenges.FindSecondLargeInArray(testArrayE));
            Assert.AreEqual(3, Challenges.FindSecondLargeInArray(testArrayF));
            ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.FindSecondLargeInArray(null));

            ex = Assert.Throws<System.Exception>(() => TestBed.Challenges.FindSecondLargeInArray(testArrayD));
            // now we can test the exception itself
            Assert.IsTrue(ex.Message.Contains(ExpectedError));
        }

        [Test]
        public void SortOnesTest()
        {
            int[] testArrayA = new int[] { 1, 0 };
            int[] testResultArrayA = new int[] { 0, 1 };

            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 0, 1 };
            //testResultArrayA = new int[] { 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 0, 0 };
            testResultArrayA = new int[] { 0, 0 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 0, 1, 0 };
            testResultArrayA = new int[] { 0, 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 0, 0, 1 };
            //testResultArrayA = new int[] { 0, 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 1, 0, 0 };
            //testResultArrayA = new int[] { 0, 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 1, 1, 0 };
            testResultArrayA = new int[] { 0, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 1, 0, 1 };
            //testResultArrayA = new int[] { 0, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 0, 1, 1 };
            //testResultArrayA = new int[] { 0, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));


            testArrayA = new int[] { 0, 1, 1, 1 };
            testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 1, 0, 1, 1 };
            //testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 1, 1, 0, 1 };
            //testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 1, 1, 1, 0 };
            //testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

            testArrayA = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testResultArrayA = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZeros(testArrayA));

        }

        [Test]
        public void SortOnesTest_LargeArraySpeed()
        {
            Assert.DoesNotThrow(() => Challenges.SortOnesZeros(superLargeTestArrayOfOnesAndZeros));
        }
        [Test]
        public void SortOnesTestAlternate_LargeArraySpeed_WorstCase()
        {
            Assert.DoesNotThrow(() => Challenges.SortOnesZerosAlternate(superLargeTestArrayOfOnesAndZeros_WorstCase));
        }
        [Test]
        public void SortOnesTest_LargeArraySpeed_WorstCase()
        {
            Assert.DoesNotThrow(() => Challenges.SortOnesZeros(superLargeTestArrayOfOnesAndZeros_WorstCase));
        }
        [Test]
        public void SortOnesTestAlternate_LargeArraySpeed()
        {
            Assert.DoesNotThrow(() => Challenges.SortOnesZerosAlternate(superLargeTestArrayOfOnesAndZeros));
        }
        [Test]
        public void SortOnesTestAlternateIII_LargeArraySpeed_WorstCase()
        {
            Assert.DoesNotThrow(() => Challenges.SortOnesZerosAlternateIII(superLargeTestArrayOfOnesAndZeros_WorstCase));
        }
        [Test]
        public void SortOnesTestAlternateIII_LargeArraySpeed()
        {
            Assert.DoesNotThrow(() => Challenges.SortOnesZerosAlternateIII(superLargeTestArrayOfOnesAndZeros));
        }
        private int[] GetTestArrayOfSize(int desiredSize)
        {
            System.Random rand = new System.Random(System.Guid.NewGuid().GetHashCode());
            List<int> theBigArray = new List<int>();
            for(int i= 0; i< desiredSize; i++)
            {
                theBigArray.Add(rand.Next(0, 1));
            }
            return theBigArray.ToArray();
        }

        private int[] GetTestArrayOfSize_Worstcase(int desiredSize)
        {
            List<int> theBigArray = new List<int>();
            int half = (int)(desiredSize / 2);
            for (int i = 0; i < half; i++)
            {
                theBigArray.Add(1);
            }
            for (int i = 0; i < half; i++)
            {
                theBigArray.Add(0);
            }
            return theBigArray.ToArray();
        }


        [Test]
        public void SortOnesAlternate_Test()
        {
            int[] testArrayA = new int[] { 1, 0 };
            int[] testResultArrayA = new int[] { 0, 1 };

            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 0, 1 };
            //testResultArrayA = new int[] { 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 0, 1, 0 };
            testResultArrayA = new int[] { 0, 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 0, 0, 1 };
            //testResultArrayA = new int[] { 0, 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 1, 0, 0 };
            //testResultArrayA = new int[] { 0, 0, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 1, 1, 0 };
            testResultArrayA = new int[] { 0, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 1, 0, 1 };
            //testResultArrayA = new int[] { 0, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 0, 1, 1 };
            //testResultArrayA = new int[] { 0, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));


            testArrayA = new int[] { 0, 1, 1, 1 };
            testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 1, 0, 1, 1 };
            //testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 1, 1, 0, 1 };
            //testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 1, 1, 1, 0 };
            //testResultArrayA = new int[] { 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

            testArrayA = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testResultArrayA = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 };
            Assert.AreEqual(testResultArrayA, Challenges.SortOnesZerosAlternate(testArrayA));

        }


        [Test]
        public void IntAdditionTest()
        {
            Assert.AreEqual(6, Challenges.SumOfDigits(123));
            Assert.AreEqual(15, Challenges.SumOfDigits(168));
            Assert.AreEqual(21, Challenges.SumOfDigits(1668));
            Assert.AreEqual(1, Challenges.SumOfDigits(1));
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

            Assert.AreEqual(testResultArrayA, Challenges.IntArrayRotateRight(testArrayA));
            Assert.AreEqual(testResultArrayB, Challenges.IntArrayRotateRight(testArrayB));
            Assert.AreEqual(testResultArrayC, Challenges.IntArrayRotateRight(testArrayC));
            Assert.AreEqual(testResultArrayD, Challenges.IntArrayRotateRight(testArrayD));
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

            Assert.AreEqual(testResultArrayA, Challenges.IntArrayRotate(testArrayA));
            Assert.AreEqual(testResultArrayB, Challenges.IntArrayRotate(testArrayB));
            Assert.AreEqual(testResultArrayC, Challenges.IntArrayRotate(testArrayC));
            Assert.AreEqual(testResultArrayD, Challenges.IntArrayRotate(testArrayD));
        }

        [Test]
        public void AllSubStringTest()
        {
            Assert.AreEqual("a ab abc abcd b bc bcd c cd d", Challenges.AllSubString("abcd"));
            Assert.IsTrue(Challenges.AllSubString("hello world").Contains("d"));
            Assert.IsTrue(Challenges.AllSubString("hello world").Contains("world"));
            Assert.IsTrue(Challenges.AllSubString("hello world").Contains("o w"));
            var ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.AllSubString(null));
            Assert.AreEqual(Challenges.AllSubString(""), "");
        }
        [Test]
        public void RemoveDuplicateCharsStringTest()
        {
            Assert.AreEqual("helo wrd", Challenges.RemoveDuplicateChars("hello world"));
            Assert.AreEqual("csharpone", Challenges.RemoveDuplicateChars("csharpcorner"));
            var ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.RemoveDuplicateChars(null));
            Assert.AreEqual(Challenges.RemoveDuplicateChars(""), "");
        }

        [Test]
        public void PrimeTest()
        {
            Assert.IsFalse(TestBed.Challenges.IsPrime(21));
            Assert.IsFalse(TestBed.Challenges.IsPrime(100));
            Assert.IsFalse(TestBed.Challenges.IsPrime(100000));

            Assert.IsTrue(TestBed.Challenges.IsPrime(1));
            Assert.IsTrue(TestBed.Challenges.IsPrime(2));
            Assert.IsTrue(TestBed.Challenges.IsPrime(3));
            Assert.IsTrue(TestBed.Challenges.IsPrime(7));

            var ex = Assert.Throws<System.Exception>(() => TestBed.Challenges.IsPrime(-1));

            Assert.That(ex.Message == "Not a positive real number");

            ex = Assert.Throws<System.Exception>(() => TestBed.Challenges.IsPrime(0));

            // now we can test the exception itself
            Assert.That(ex.Message == "Not a positive real number");

        }
        [Test]
        public void ReverseStringTest()
        {
            var ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.Reverse(null));

            //Assert.That(ex.Message == "Not a positive real number");
            Assert.AreEqual(TestBed.Challenges.Reverse(""), "");
            Assert.AreEqual(TestBed.Challenges.Reverse("hello world"), "dlrow olleh");
            Assert.AreEqual(TestBed.Challenges.Reverse("cat"), "tac");
            Assert.AreEqual(TestBed.Challenges.Reverse("catt"), "ttac");
            Assert.AreEqual(TestBed.Challenges.Reverse("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFcatt"), "ttacFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");

        }

        [Test]
        public void PalendromeStringTest()
        {
            var ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.IsPalendrome(null));
            Assert.IsTrue(Challenges.IsPalendrome("PAP"));
            Assert.IsTrue(Challenges.IsPalendrome("PAAP"));
            Assert.IsFalse(Challenges.IsPalendrome(""));
            Assert.IsFalse(Challenges.IsPalendrome("PAr"));
            Assert.IsFalse(Challenges.IsPalendrome("PArt"));
        }
        [Test]
        public void ReverseWordStringTest()
        {
            Assert.AreEqual("sandwich tomato a am I.", Challenges.ReverseWords(".I am a tomato sandwich") );
            Assert.AreEqual("corner Csharp to Welcome",Challenges.ReverseWords("Welcome to Csharp corner") );
            var ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.ReverseWords(null));
            Assert.AreEqual(Challenges.ReverseWords(""), "");
        }
        [Test]
        public void ReverseWordOnlyStringTest()
        {
            Assert.AreEqual(".I ma a otamot hciwdnas", Challenges.ReverseOnlyWords(".I am a tomato sandwich"));
            Assert.AreEqual("emocleW ot prahsC renroc", Challenges.ReverseOnlyWords("Welcome to Csharp corner"));
            var ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.ReverseOnlyWords(null));
            Assert.AreEqual(Challenges.ReverseOnlyWords(""), "");
        }
        [Test]
        public void CharCounterStringTest()
        {
            Assert.IsTrue(Challenges.LetterCounter("hello world").Contains("e - 1"));
            Assert.IsTrue(Challenges.LetterCounter("hello world").Contains("o - 2"));
            Assert.IsTrue(Challenges.LetterCounter("hello world").Contains("l - 3"));
            Assert.IsTrue(Challenges.LetterCounter("hello world").Contains("d - 1"));
            var ex = Assert.Throws<System.NullReferenceException>(() => TestBed.Challenges.LetterCounter(null));
            Assert.AreEqual(Challenges.LetterCounter(""), "");
        }
    }
}