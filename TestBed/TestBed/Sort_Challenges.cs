using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    public class Sort_Challenges
    {
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
                while (i < j && value[j] == 1)
                {
                    j--;
                }
                if (j > i && value[i] > value[j])
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
            for (int i = values.Length - 1; i >= 0; i--)
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

        public static int[] SortOnesZerosMicrosoft(int[] values)
        {
            Array.Sort(values);
            return values;
        }
    }
}
