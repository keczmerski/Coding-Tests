using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    public class Math_Challenges
    {
        /// <summary>
        /// Euclid's algorythm: Find the greatest common denominator.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GreatestCommonDenominator(int a, int b)
        {
            if (a < 1 || b < 1)
            {
                return -1;
            }
            while (b != 0)
            {
                int oldA = a;
                a = b;
                b = oldA % b;
            }
            return a;
        }

        /// <summary>
        /// Look at each element in an array of integers and for that element see if any other elements addup to the target.
        /// </summary>
        /// <param name="nums">an array of integers</param>
        /// <param name="target">the target for the sum of two integers in nums</param>
        /// <returns>the array positions of two integers that add up to target</returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums == null) { throw new System.ArgumentNullException(nameof(nums)); }
            for (int FirstPointer = 0; FirstPointer < nums.Length; FirstPointer++)
            {
                for (int SecondPointer = 0; SecondPointer < nums.Length; SecondPointer++)
                {
                    if (FirstPointer != SecondPointer)
                    {
                        if (nums[FirstPointer] + nums[SecondPointer] == target)
                        {
                            return new int[] { FirstPointer, SecondPointer };
                        }
                    }
                }
            }
            throw new System.ArgumentException("Target not found");
        }

        #region GetCountofOpperandOccurancesIn_ThreeUniqueOperandsForSingleSum

        /// <summary>
        /// Given a range of integers, count the number of ways each single integer can be used in unique sets of three 
        /// operands that all add up to a given sum.
        /// </summary>
        /// <param name="sum">The sum that each set of three operands should equal.</param>
        /// <param name="OperandMinimum">The highest integer in the range of integers included as possible opperands.</param>
        /// <param name="OperandMaximum">The lowest integer in the range of integers included as possible opperands.</param>
        /// <returns>A Dictionary of the count (value) of ways a single integer (key) can occur in unique sets of three operands 
        /// that all add up to a given sum.</returns>
        public static Dictionary<int, int> GetCountofOpperandOccurancesIn_ThreeUniqueOperandsForSingleSum(int sum, int OperandMinimum = 1, int OperandMaximum = 9)
        {
            Dictionary<int, int> SumOfOperands = new Dictionary<int, int>();

            List<int[]> ListOfThreeOperands = GetAllGroupsOfThreeUniqueOperandsForSingleSum(sum, OperandMinimum, OperandMaximum);
            foreach (int[] operandsGroup in ListOfThreeOperands)
            {
                foreach (int operand in operandsGroup)
                {
                    if (SumOfOperands.ContainsKey(operand))
                    {
                        SumOfOperands[operand]++;
                    }
                    else
                    {
                        SumOfOperands.Add(operand, 1);
                    }
                }
            }
            return SumOfOperands;
        }

        /// <summary>
        /// Get three unique operands for a single sum such that operand1 + operand2 + operand3 = sum 
        /// where all operands are unique and within a range of adgacent integer values. 
        /// </summary>
        /// <param name="sum">The sum that all int array groups of three returned are equal to.</param>
        /// <param name="OperandMinimum">The maximum value of all unique operators that can be included as part of the int array groups returned.</param>
        /// <param name="OperandMaximum">The minimum value of all unique operators that can be included as part of the int array groups returned.<</param>
        /// <returns>A list of int array groups where all operands in a group are unique and together form a sum passed to the method.</returns>
        public static List<int[]> GetAllGroupsOfThreeUniqueOperandsForSingleSum(int sum, int OperandMinimum = 1, int OperandMaximum = 9)
        {
            List<int[]> ListOfThreeOperands = new List<int[]>();
            int NumberOfOperands = 3;
            int offsetForNonDefaultMinimum = OperandMinimum - 1;
            int offsetOperandMinimum = OperandMinimum - offsetForNonDefaultMinimum;
            int offsetOperandMaximum = OperandMaximum - offsetForNonDefaultMinimum;
            int offsetSum = sum - offsetForNonDefaultMinimum;


            for (int FirstOperand = offsetOperandMaximum; FirstOperand > offsetSum / NumberOfOperands; FirstOperand--)
            {
                for (int SecondOperand = (int)Math.Ceiling((offsetSum - FirstOperand) / 2.0); SecondOperand <= offsetSum - FirstOperand - offsetOperandMinimum && SecondOperand < FirstOperand; SecondOperand++)
                {
                    int ThirdOperand = offsetSum - FirstOperand - SecondOperand;
                    if (SecondOperand != ThirdOperand && SecondOperand != FirstOperand)
                    {
                        ListOfThreeOperands.Add(new int[] { FirstOperand + offsetForNonDefaultMinimum, SecondOperand + offsetForNonDefaultMinimum, ThirdOperand + offsetForNonDefaultMinimum });
                    }
                }
            }
            return ListOfThreeOperands;
        }
        #endregion

        /// <summary>
        /// Given an unsorted integer array, find the second largest integer in the array. 
        /// If there are two values that are both the highest value, then those two values are both the highest value.
        /// </summary>
        /// <param name="InitialValue"></param>
        /// <returns>the second largest integer in the array, or -1 in the case of bad input.</returns>
        /// <remarks>I have realized that the ultimate implementation of this problem is heapsort. 
        /// Questions pointing to the nth largest, or nth smallest are likely targeting heapsort. 
        /// As near as I can tell, C# does not have a builtin heapsort. I have seen implementations of heap sort, 
        /// but there is no way I would come up with that for a coding challenge answer. Perhaps I will inplement it someday but not today.
        /// Unfortunately, </remarks>
        public static int FindSecondLargeInArray(int[] InitialValue)
        {
            if (InitialValue == null)
            {
                throw new ArgumentNullException(nameof(InitialValue));
            }

            int largest = int.MinValue;
            int secondLargest = int.MinValue;
            bool IsLargestAssignedAtLeastOnce = false;
            bool IsSecondLargestAssignedAtLeastOnce = false;
            foreach (int i in InitialValue)
            {
                if (i > largest)
                {
                    secondLargest = largest;
                    largest = i;
                    if (IsLargestAssignedAtLeastOnce)
                    {
                        IsSecondLargestAssignedAtLeastOnce = true;
                    }
                    IsLargestAssignedAtLeastOnce = true;
                }
                else if (i > secondLargest && i != largest)
                {
                    secondLargest = i;
                }
            }
            if (!IsSecondLargestAssignedAtLeastOnce)
            {
                return -1;
            }
            return secondLargest;
        }

        /// <summary>
        /// Given a number return true if the number is prime.
        /// </summary>
        /// <param name="number">a positive real number</param>
        /// <returns>True if the number is prime.</returns>
        static public bool IsPrime(int number)
        {
            if (number < 1)
            {
                return false;
            }
            if (number <= 2) return true;
            if (number % 2 == 0) return false;

            int testValue = 3;
            int stopCondition = (int)Math.Sqrt(number);

            while (testValue <= stopCondition)
            {
                if (number % testValue == 0)
                {
                    return false;
                }
                testValue++;
            }
            return true;
        }

        /// <summary>
        ///  Given a positive integer and the method should return the sum of all the digits in that integer. (i.e: '345' returns the sum of '3 + 4 + 5'.)
        /// </summary>
        /// <param name="num">a positive integer</param>
        /// <returns>The sum of all the digits in the integer</returns>
        public static int SumOfDigits(int num)
        {
            if (num < 0)
            {
                throw new Exception("Input not a positive integer.");
            }
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }

        /// <summary>
        /// Given an integer, return the factorial of that integer.
        /// </summary>
        /// <param name="num">Integer to be calculated.</param>
        /// <returns>Factorial of given integer.</returns>
        public static int FirstFactorial(int num)
        {

            int result = 1;
            int i = num;
            while (i > 1)
            {
                result *= i;
                i--;
            }

            return result;
        }
    }
}
