using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    public class Challenges
    {

        /// <summary>
        /// Move through the list as quickly (with as few moves) as possible. 
        /// Skips move two spaces. You must skip all 1's. If the list ends with 1 then the moves end at the last 0 value. What is the least number of moves possible?
        /// Preconditions: c[0] == 0;
        ///                c.Length >= 2;
        ///                c consists of only 1's and 0's;
        ///                c should not contain two consectutive 1's               
        /// </summary>
        /// <param name="c">An int list containing only 1's and 0's.</param>
        /// <returns>The minimum number of moves.</returns>
        public static int Skipping(int[] c)
        {
            if (c.Length < 2) { throw new Exception("There must be at least two values."); }
            if (c[0] != 0) { throw new Exception("The first value must be zero(0)."); }

            return ExtractJumpCount_FromListOfConsecutiveValueCounts(CreateListOfConsecutiveValueCounts(c));
        }
        private enum ValueType { zero = 0, one = 1 };
        struct CountedValue
        {
            public int Count;
            public ValueType TypeOfValue;
            public CountedValue(int count, ValueType value_Type)
            {
                Count = count;
                TypeOfValue = value_Type;
            }
            public CountedValue(int count, int value_Type)
            {
                Count = count;
                TypeOfValue = (ValueType)value_Type;
            }
        }

        private static List<CountedValue> CreateListOfConsecutiveValueCounts(int[] c)
        {
            List<CountedValue> ListOfConsecutiveValueCounts = new List<CountedValue>();
            CountedValue CurrentCountedValue = new CountedValue(0, 0);
            foreach (int CValue in c)
            {
                if ((0 <= CValue) && (CValue <= 1))
                {
                    Console.WriteLine($"Warning: Bad Value Detected in Skipping: {CValue}");
                }
                if (((0 <= CValue) && (CValue <= 1)) && (CValue != (int)CurrentCountedValue.TypeOfValue))
                {
                    ListOfConsecutiveValueCounts.Add(CurrentCountedValue);
                    CurrentCountedValue = new CountedValue(count: 1, value_Type: CValue);
                }
                else
                {
                    CurrentCountedValue.Count++;
                }
            }
            if (CurrentCountedValue.Count > 1)
            {
                ListOfConsecutiveValueCounts.Add(CurrentCountedValue);
            }
            return ListOfConsecutiveValueCounts;
        }
        private static int ExtractJumpCount_FromListOfConsecutiveValueCounts(List<CountedValue> ListOfConsecutiveValueCounts)
        {
            int JumpCount = 0;
            foreach (CountedValue countOfValues in ListOfConsecutiveValueCounts)
            {

                switch (countOfValues.TypeOfValue)
                {
                    case ValueType.zero:
                        {
                            JumpCount += (int)Math.Floor((double)countOfValues.Count / 2);
                            break;
                        }
                    case ValueType.one:
                        {
                            if (countOfValues.Count > 1)
                            {
                                throw new Exception("Impossible Jump required.");
                            }
                            JumpCount++;
                            break;
                        }
                }
            }
            return JumpCount;
        }

        /// <summary>
        /// Given a range of integers, count the number of ways each single integer can be used in unique sets of three 
        /// operands that all add up to a given sum.
        /// </summary>
        /// <param name="sum">The sum that each set of three operands should equal.</param>
        /// <param name="OperandMinimum">The highest integer in the range of integers included as possible opperands.</param>
        /// <param name="OperandMaximum">The lowest integer in the range of integers included as possible opperands.</param>
        /// <returns>A Dictionary of the count (value) of ways a single integer (key) can occur in unique sets of three operands 
        /// that all add up to a given sum.</returns>
        public static Dictionary<int,int> GetCountofOpperandOccurancesIn_ThreeUniqueOperandsForSingleSum(int sum, int OperandMinimum = 1, int OperandMaximum = 9)
            {
                Dictionary<int, int> SumOfOperands = new Dictionary<int, int>();

                List<int[]> ListOfThreeOperands = GetAllGroupsOfThreeUniqueOperandsForSingleSum(sum, OperandMinimum, OperandMaximum);
                foreach(int[] operandsGroup in ListOfThreeOperands)
                {
                    foreach(int operand in operandsGroup)
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


            for (int FirstOperand = offsetOperandMaximum; FirstOperand > offsetSum / NumberOfOperands; FirstOperand--){
                for (int SecondOperand = (int)Math.Ceiling((offsetSum - FirstOperand) / 2.0); SecondOperand <= offsetSum - FirstOperand - offsetOperandMinimum && SecondOperand < FirstOperand; SecondOperand++){
                    int ThirdOperand = offsetSum - FirstOperand - SecondOperand;
                    if (SecondOperand != ThirdOperand && SecondOperand!= FirstOperand)
                    {
                        ListOfThreeOperands.Add(new int[] { FirstOperand + offsetForNonDefaultMinimum, SecondOperand + offsetForNonDefaultMinimum, ThirdOperand + offsetForNonDefaultMinimum });
                    }
                }
            }
            return ListOfThreeOperands;
        }

        public static bool IsAllValuesPersentInEach(int[] A, int[] B)
        {
            if (A.Length != B.Length || A.Length <= 0 || B.Length <= 0)
            {
                throw new Exception("Arrays A and B must contain the same number of values Greater than 0");
            }
            bool IsAllValuesPersent = true;
            foreach( int valPresent in A)
            {
                if (!B.Contains(valPresent))
                {
                    IsAllValuesPersent = false;
                }
            }
            return IsAllValuesPersent;
        }

        /// <summary>
        /// Sort an integer array containing only ones and zeros with the lowest complexity possible.
        /// This algorithm has a complexity of O(n) since it only looks at any value in the array once.
        /// </summary>
        /// <param name="value">A list of values to sort where all values are either one or zero.</param>
        /// <returns></returns>
        public static int[] SortOnesZeros(int[] value)
        {
            int j = value.Length - 1;
            int i = 0;
            while (i < j)
            {
                // commented out to give the fairest speed test in the search for the fastest algorythm:
                //if (value[i] < 0 || value[i] > 1 || value[j] < 0 || value[j] > 1)
                //{
                //    throw new Exception("Value array can only contain 1's and 0's.");
                //}
                while (i < j && value[i] == 0)
                {
                    i++;
                }
                while (i < j && value[j]== 1)
                {
                    j--;
                }
                if (j > i && value[i] > value[j] )
                {
                    value[j] = 1;
                    value[i] = 0;
                    j--;
                    i++;
                }
            }
            return value;
        }
        /// <summary>
        /// credit : https://codereview.stackexchange.com/a/247572/57486
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int[] SortOnesZerosAlternateIII(int[] values)
        {
            int countOfZeros = values.Length - values.Sum();
            //alternative methods to set all values to 0, the fastest is uncommented:
            //for (int i = 0; i < countOfZeros; i++)
            //{
            //    values[i] = 0;
            //}
            //values = new int[values.Length];
            Array.Clear(values, 0, values.Length);
            for (int i = countOfZeros; i < values.Length; i++)
            {
                values[i] = 1;
            }

            return values;
        }

        /// <summary>
        /// Sort an interger array containing only ones and zeros with the lowest complexity possible. 
        /// Alternative Implementation.
        /// This algorythim has a complexity of O(n) since it only looks at any value in the array once. 
        /// The algroythm is slower then "SortOnesZeros" the complexity is O(2n) which is really O(n).
        /// credit: https://codereview.stackexchange.com/a/247584/57486
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int[] SortOnesZerosAlternate(int[] values)
        {
            int NextNewOneLocation = values.Length - 1;
            for (int i = values.Length - 1; i>=0; i--)
            {
                if (values[i] == 1)
                {
                    values[NextNewOneLocation--] = 1;
                }
                // commented out to give the fairest speed test in the search for the fastest algorythm:
                //if (values[i] < 0 || values[i] > 1)
                //{
                //    throw new Exception("Value array can only contain 1's and 0's.");
                //}
            }
            int CountOfZeros = NextNewOneLocation + 1;
            
            Array.Clear(values, 0, CountOfZeros);

            return values;
        }

        /// <summary>
        /// Accept string input and return bolean where the boolean returns true if the input string is a palindrome.
        /// </summary>
        /// <param name="InitialValue">String to be tested</param>
        /// <returns>True if the InitialValue string is a palindrome.</returns>
        static public bool IsPalendrome(string InitialValue)
        {
            if (InitialValue == null)
            {
                throw new System.NullReferenceException();
            }
            if (string.IsNullOrWhiteSpace(InitialValue))
            {
                return false;
            }
            for (int i = 0; i <= (InitialValue.Length / 2); i++)
            {
                if (InitialValue[i] != InitialValue[ReversePosition(InitialValue.Length, i)])
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Given an array length and a position in an array, return the position changed as if the array were in reverse order.
        /// </summary>
        /// <param name="length">The length of the array</param>
        /// <param name="position">The inital position</param>
        /// <returns>The position changed as if the array were in reverse order.</returns>
        static private int ReversePosition(int length, int position)
        {
            return length - 1 - position;
        }

        /// <summary>
        /// Given an unsorted integer array, find the second largest integer in the array.
        /// </summary>
        /// <param name="InitialValue"></param>
        /// <returns>the second largest integer in the array</returns>
        public static int FindSecondLargeInArray(int[] InitialValue)
        {
            if (InitialValue == null)
            {
                throw new System.NullReferenceException();
            }
            int largest = int.MinValue;
            int secondLargest = int.MinValue;
            bool IsLargestAssignedAtLeastOnce = false;
            bool IsSecondLargestAssignedAtLeastOnce = false;
            foreach ( int i in InitialValue)
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
                else if(i > secondLargest && i != largest)
                {
                    secondLargest = i;
                }
            }
            if (!IsSecondLargestAssignedAtLeastOnce)
            {
                throw new System.Exception("Array has less than two unique values.");
            }
            return secondLargest;
        }


        /// <summary>
        /// Given an integer array, shift each element of input array to its Right by one position in circular fashion. 
        /// The logic is to iterate loop from 0 to Length-1 and swap each element with first element
        /// </summary>
        /// <param name="testArrayB"></param>
        /// <returns></returns>
        public static int[] IntArrayRotateRight(int[] InitialValue)
        {

            List<int> result = new List<int>();

            if (InitialValue.Length <= 0) return InitialValue;

            int resultFirst = InitialValue[InitialValue.Length -1];
            result.Add(resultFirst);
            for (int i = 0; i < InitialValue.Length - 1; i++)
            {
                result.Add(InitialValue[i]);
            }
            
            return result.ToArray();
        }

        /// <summary>
        /// Given an integer array, shift each element of input array to its Left by one position in circular fashion. 
        /// The logic is to iterate loop from Length-1 to 0 and swap each element with last element.
        /// </summary>
        /// <param name="InitialValue"></param>
        /// <returns></returns>
        public static int[] IntArrayRotate(int[] InitialValue)
        {
            List<int> result = new List<int>();

            if (InitialValue.Length <= 0) return InitialValue;

            int resultLast = InitialValue[0];
            for(int i =1; i<InitialValue.Length; i++)
            {
                result.Add(InitialValue[i]);
            }
            result.Add(resultLast);
            return result.ToArray();
        }

        /// <summary>
        /// The user will input a string and the method should return the reverse of that string
        /// </summary>
        /// <param name="toBeReversed">String to be reversed</param>
        /// <returns>reversed string</returns>
        static public string Reverse(string toBeReversed)
        {
            if (toBeReversed == null)
            {
                throw new System.NullReferenceException();
            }
            StringBuilder reversedString = new StringBuilder();
            for (int i = (toBeReversed.Length - 1); i >= 0; i--)
            {
                reversedString.Append(toBeReversed[i].ToString());
            }
            return reversedString.ToString();
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
                throw new System.Exception("Not a positive real number");
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
        /// Given a string containing a sentence (Seequence of words) return a string with the words in reverse order.
        /// </summary>
        /// <param name="InitialValue">a string containing a sentence (Seequence of words)</param>
        /// <returns>string with the words in reverse order.</returns>
        public static string ReverseWords(string InitialValue)
        {
            if (InitialValue == null)
            {
                throw new System.NullReferenceException();
            }
            List<String> seperatedValue = new List<string>();
            StringBuilder currentWord = new StringBuilder();
            StringBuilder reversedValue = new StringBuilder();
            foreach (char c in InitialValue)
            {
                if (c == ' ' || c == '.' || c == ',' || c == '?')
                {
                    seperatedValue.Add(currentWord.ToString());
                    seperatedValue.Add(c.ToString());
                    currentWord.Clear();
                }
                else
                {
                    currentWord.Append(c.ToString());
                }
            }
            seperatedValue.Add(currentWord.ToString());
            foreach (string s in Enumerable.Reverse(seperatedValue))
            {
                reversedValue.Append(s);
            }
            return reversedValue.ToString();
        }

        /// <summary>
        ///  Given a string, return a count of all letters.
        /// </summary>
        /// <param name="InitialValue">string</param>
        /// <returns>a count of all letters.</returns>
        public static string LetterCounter(string InitialValue)
        {
            if (InitialValue == null)
            {
                throw new System.NullReferenceException();
            }
            Dictionary<char, int> Counts = new Dictionary<char, int>();
            StringBuilder countResults = new StringBuilder();

            foreach (char c in InitialValue)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    if (Counts.ContainsKey(c))
                    {
                        Counts[c]++;
                    }
                    else
                    {
                        Counts.Add(c, 1);
                    }
                }
            }
            foreach (char c in Counts.Keys)
            {
                countResults.Append($"{c} - {Counts[c]}, ");
            }
            return countResults.ToString();
        }

        /// <summary>
        /// Given a sentence, return a sentance where each word is reversed individually without changing its position in the sentence.
        /// </summary>
        /// <param name="InitialValue">a sentance</param>
        /// <returns>a sentance where each word is reversed individually without changing its position in the sentence</returns>
        public static string ReverseOnlyWords(string InitialValue)
        {
            if (InitialValue == null)
            {
                throw new System.NullReferenceException();
            }
            StringBuilder seperatedValue = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();
            foreach (char c in InitialValue)
            {
                if (c == ' ' || c == '.' || c == ',')
                {
                    seperatedValue.Append(Reverse(currentWord.ToString()));
                    seperatedValue.Append(c.ToString());
                    currentWord.Clear();
                }
                else
                {
                    currentWord.Append(c.ToString());
                }
            }
            seperatedValue.Append(Reverse(currentWord.ToString()));

            string resultValue = seperatedValue.ToString();
            return resultValue;
        }

        /// <summary>
        /// Given a string, remove multiple occurrences of characters in the string
        /// </summary>
        /// <param name="InitialValue">a string</param>
        /// <returns>A string with only unique occurances of chars.</returns>
        public static string RemoveDuplicateChars(string InitialValue)
        {
            if (InitialValue == null)
            {
                throw new System.NullReferenceException();
            }
            String Results = "";

            foreach (char c in InitialValue)
            {
                if (!Results.Contains(c))
                {
                    Results += (c);
                }
            }

            return Results.ToString();
        }

        /// <summary>
        /// Given a string, return all the possible substrings, varying from length 1 to the input string length. 
        /// The output will include the input string also. Each substring will be seperated by a space.
        /// </summary>
        /// <param name="InitialValue">a string</param>
        /// <returns>all the possible substrings, varying from length 1 to the input string length. Each substring will be seperated by a space. The output will include the input string also.</returns>
        public static string AllSubString(string InitialValue)
        {
            if (InitialValue == null)
            {
                throw new System.NullReferenceException();
            }
            int InitalValueLength = InitialValue.Length; 
            StringBuilder result = new StringBuilder();
            string seperator = " ";
            for (int i = 0; i < InitalValueLength; i++)
            {
                for (int j = i; j < InitalValueLength; j++)
                {
                    result.Append(InitialValue.Substring(i, j - i + 1));
                    if ((i != InitalValueLength - 1) || (j != InitalValueLength - 1))
                    {
                        result.Append(seperator);
                    }
                }
            }
            return result.ToString();
        }

        /// <summary>
        ///  Given a positive integer and the method should return the sum of all the digits in that integer.
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
        /// Given a string, return a corresponding string that is sorted so that all chars present are placed in alphebitical order.
        /// </summary>
        /// <param name="str">String to be sorted</param>
        /// <returns>A string of sorted chars.</returns>
        public static string AlphabetSoup(string str)
        {
            if (str == null)
            {
                throw new System.NullReferenceException();
            }
            char[] characters = str.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
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

        /// <summary>
        /// Given a string, retrun the longest word in the string. 
        /// When two words are the same length, the first word occurance is returned.
        /// </summary>
        /// <param name="sen">The string to be searched for the longest word.</param>
        /// <returns>the longest word found in a given string.</returns>
        public static string LongestWord(string sen)
        {
            if (sen == null)
            {
                throw new System.NullReferenceException();
            }
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(@"\w*");
            System.Text.RegularExpressions.MatchCollection matches = rx.Matches(sen);
            string result = "";
            foreach(System.Text.RegularExpressions.Match m in matches)
            {
                if (result.Length < m.Value.Length)
                {
                    result = m.Value;
                }
            }
 
            return result;
        }
    }
}

