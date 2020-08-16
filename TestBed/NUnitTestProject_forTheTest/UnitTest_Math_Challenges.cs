using NUnit.Framework;
using System.Collections.Generic;
using static TestBed.Math_Challenges;


namespace NUnitTestProject_forTheTest
{
    class UnitTest_Math_Challenges
    {
        [Test]
        public void Test_GreatestCommonDenominator()
        {
            Assert.AreEqual(12, GreatestCommonDenominator(60, 96));
            Assert.AreEqual(4, GreatestCommonDenominator(20,8));
        }
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
        public void PrimeTest()
        {
            Assert.IsFalse(IsPrime(21));
            Assert.IsFalse(IsPrime(100));
            Assert.IsFalse(IsPrime(100000));

            Assert.IsTrue(IsPrime(1));
            Assert.IsTrue(IsPrime(2));
            Assert.IsTrue(IsPrime(3));
            Assert.IsTrue(IsPrime(7));

            Assert.IsFalse(IsPrime(-1));
            Assert.IsFalse(IsPrime(0));
        }

    }
}
