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
        #region skipping
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
        #endregion

        /// <remarks>Equivilant to: Does Left Join contain no nulls?</remarks>
        /// <todo>Consider making the type of the method more generic by using generics.</todo>
        public static bool IsAllValuesPersentInOther(int[] A, int[] B)
        {
            if (A.Length != B.Length || A.Length < 0 || B.Length < 0)
            {
                return false;
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

        #region IsPalendrome

        /// <summary>
        /// Accept string input and return bolean where the boolean returns true if the input string is a palindrome. 
        /// If the string is empty, then it is not a palindrome.
        /// </summary>
        /// <param name="InitialValue">String to be tested. leading and trailing white space will be trimmed.</param>
        /// <returns>True if the InitialValue string is a palindrome.</returns>
        static public bool IsPalendrome(string InitialValue)
        {
            if (string.IsNullOrWhiteSpace(InitialValue))
            {
                return false;
            }
            InitialValue = InitialValue.Trim();
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

        #endregion




        /// <summary>
        /// Given an integer array, shift each element of input array to its Right by one position in circular fashion. 
        /// The logic is to iterate from 0 to Length-1 and swap each element with first element
        /// </summary>
        /// <param name="testArrayB"></param>
        /// <returns></returns>
        /// <remarks>Consider that this implementation could be made more generic.</remarks>
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
            if (string.IsNullOrWhiteSpace(toBeReversed)) { return toBeReversed; }

            StringBuilder reversedString = new StringBuilder(toBeReversed.Length);

            for (int i = (toBeReversed.Length - 1); i >= 0; i--)
            {
                reversedString.Append(toBeReversed[i]);
            }
            return reversedString.ToString();
        }

        /// <summary>
        /// Given a string containing a sentence (Seequence of words) return a string with the words in reverse order.
        /// </summary>
        /// <param name="InitialValue">a string containing a sentence (Seequence of words)</param>
        /// <returns>string with the words in reverse order.</returns>
        public static string ReverseWords(string InitialValue)
        {
            if (string.IsNullOrWhiteSpace(InitialValue)) { return InitialValue; }

            List<String> seperatedValue = new List<string>();
            StringBuilder reversedValue = new StringBuilder(InitialValue.Length);
            StringBuilder currentWord = new StringBuilder();

            foreach (char c in InitialValue)
            {
                if (char.IsWhiteSpace(c) || char.IsPunctuation(c))
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
            if (string.IsNullOrWhiteSpace(InitialValue)) { return InitialValue; }

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
            if (string.IsNullOrWhiteSpace(InitialValue)) { return InitialValue; }

            StringBuilder ReversedWords = new StringBuilder(InitialValue.Length);
            StringBuilder currentWord = new StringBuilder();
            foreach (char c in InitialValue)
            {
                if (char.IsWhiteSpace(c) || char.IsPunctuation(c))
                {
                    ReversedWords.Append(Reverse(currentWord.ToString()));
                    ReversedWords.Append(c.ToString());
                    currentWord.Clear();
                }
                else
                {
                    currentWord.Append(c.ToString());
                }
            }
            ReversedWords.Append(Reverse(currentWord.ToString()));

            return ReversedWords.ToString();
        }

        /// <summary>
        /// Given a sentence, return a sentance where each word is reversed individually without changing its position in the sentence. 
        /// Leading and trailing whitespace will be trimmed.
        /// This version was revised using tips from https://codereview.stackexchange.com/a/247650/57486 to improve the algorythm's speed in every way possible.
        /// </summary>
        /// <param name="InitialValue">a sentance</param>
        /// <returns>a sentance where each word is reversed individually without changing its position in the sentence</returns>
        public static string ReverseOnlyWords_Revised(string InitialValue)
        {
            if (string.IsNullOrWhiteSpace(InitialValue)) { return InitialValue; }
            InitialValue = InitialValue.Trim();

            StringBuilder ReversedWords = new StringBuilder(InitialValue.Length);

            int StartOfWordPointer = 0;
            for (int EndOfWordPointer = 0; EndOfWordPointer < InitialValue.Length; EndOfWordPointer++)
            {
                if (char.IsWhiteSpace(InitialValue[EndOfWordPointer]) || char.IsPunctuation(InitialValue[EndOfWordPointer]))
                {
                    //ReversedWords.Append(Reverse(InitialValue.Substring(StartOfWordPointer, EndOfWordPointer - StartOfWordPointer)));

                    //for (int i = EndOfWordPointer - 1; i >= StartOfWordPointer; i--)
                    //{
                    //    ReversedWords.Append(InitialValue[i]);
                    //}
                    ReverseMagid(ref ReversedWords, InitialValue, StartOfWordPointer, EndOfWordPointer);
                    ReversedWords.Append(InitialValue[EndOfWordPointer]);
                    StartOfWordPointer = EndOfWordPointer + 1;
                }
            }
            if (StartOfWordPointer < InitialValue.Length)
            {
                //for (int i = InitialValue.Length - 1; i >= StartOfWordPointer; i--)
                //{
                //    ReversedWords.Append(InitialValue[i]);
                //}
                ReverseMagid(ref ReversedWords, InitialValue, StartOfWordPointer, InitialValue.Length);
            }
            return ReversedWords.ToString();
        }

        private static void ReverseMagid(ref StringBuilder ReversedWords, string InitialValue, int startPointer, int endPointer)
        {
            for (int i = endPointer - 1; i >= startPointer; i--)
            {
                ReversedWords.Append(InitialValue[i]);
            }
        }

        /// <summary>
        /// Credit: Almost completely lifted/coppied from https://codereview.stackexchange.com/a/247650/57486
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separater"></param>
        /// <returns></returns>
        public static string ReverseOnlyWords_Suggested(string value, char separater = ' ')
        {
            if (string.IsNullOrEmpty(value)) { return value; } // just return the value, leave the handling to the caller.

            var words = value.Split(separater); // split it to words by spaces

            // initiate a string builder with a fixed size based on the original string size. 
            // setting the capacity would avoid oversized allocation.
            var resultBuilder = new StringBuilder(value.Length);

            // iterate over words 
            for (int x = 0; x < words.Length; x++)
            {
                // store the tailing punctuation
                char? punctuation = null;
                // iterate over characters in reverse 
                for (int c = words[x].Length - 1; c >= 0; c--)
                {
                    var current = words[x][c];

                    if (char.IsPunctuation(current))
                    {
                        if (c == 0) // for leading punctuation
                        {
                            // get the first poistion of the current word 
                            var index = resultBuilder.ToString().Length - (words[x].Length - 1);

                            // insert the leading punctuation to the first poition (its correct poistion)
                            resultBuilder.Insert(index, current);
                        }
                        else
                        {
                            // store tailing punctuation to insert it afterward
                            punctuation = current;
                        }
                    }
                    else
                    {
                        // everything else, just append
                        resultBuilder.Append(current);
                    }

                }

                if (punctuation != null)
                {
                    // insert tailing punctuation 
                    resultBuilder.Append(punctuation);
                    //                    punctuation = null; //reset 
                }
                resultBuilder.Append(separater);
            }

            return resultBuilder.ToString().Trim();
        }

        /// <summary>
        /// Given a string, remove multiple occurrences of characters in the string
        /// </summary>
        /// <param name="InitialValue">a string</param>
        /// <returns>A string with only unique occurances of chars.</returns>
        public static string RemoveDuplicateChars(string InitialValue)
        {
            if (string.IsNullOrWhiteSpace(InitialValue)) { return InitialValue; }
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
            if (string.IsNullOrWhiteSpace(InitialValue)) { return InitialValue; }
            int InitalValueLength = InitialValue.Length; 
            StringBuilder result = new StringBuilder(InitalValueLength);
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
        /// Given a string, return a corresponding string that is sorted so that all chars present are placed in alphebitical order.
        /// </summary>
        /// <param name="str">String to be sorted</param>
        /// <returns>A string of sorted chars.</returns>
        public static string AlphabetSoup(string InitialValue)
        {
            if (string.IsNullOrWhiteSpace(InitialValue)) { return InitialValue; }
            char[] characters = InitialValue.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }

        /// <summary>
        /// Given a string, retrun the longest word in the string. 
        /// When two words are the same length, the first word occurance is returned.
        /// </summary>
        /// <param name="sen">The string to be searched for the longest word.</param>
        /// <returns>the longest word found in a given string.</returns>
        public static string LongestWord(string sen)
        {
            if (string.IsNullOrWhiteSpace(sen)) { return sen; }

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

        public static IList<string> RestoreIpAddresses(string s)
        {
            bool IsValid = false;
            string[] PotentialIP = new string[4];
            List<string> ValidIPs = new List<string>();
            for (int a = 1; a <= 3; a++)
            {
                if ((s.Length / a < 4) || (s.Length / a > 3))
                {
                    for (int b = 1; b <= 3; b++)
                    {
                        if ((s.Length / b < 4) || (s.Length / b > 3))
                        {
                            for (int c = 1; c <= 3; c++)
                            {
                                if ((s.Length / b < 4) || (s.Length / b > 3))
                                {
                                    if (a + b + c + 1 <= s.Length && s.Length - a -b -c <= 3)
                                    {
                                        PotentialIP[0] = s.Substring(0, a);
                                        PotentialIP[1] = s.Substring(a, b);
                                        PotentialIP[2] = s.Substring(a + b, c);
                                        PotentialIP[3] = s.Substring(a + b + c);
                                        IsValid = IsTheIPValid(PotentialIP);
                                    }
                                }
                                if (IsValid)
                                {
                                    ValidIPs.Add($"{PotentialIP[0]}.{PotentialIP[1]}.{PotentialIP[2]}.{PotentialIP[3]}");
                                    IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
            return ValidIPs.ToArray();
        }
        private static bool IsTheIPValid(string[] IP)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Convert.ToInt32(IP[i]) < 0 )
                {
                    return false;
                }
                if (Convert.ToInt32(IP[i]) > 255 )
                {
                    return false;
                }
                if  (IP[i].Length >= 2 && (IP[i])[0] == '0')
                {
                    return false;
                }
            }
            return true;
        }
    }
}

