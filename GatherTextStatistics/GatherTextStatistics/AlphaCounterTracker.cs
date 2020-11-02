using System;
using System.Collections.Generic;
using System.Text;

namespace GatherTextStatistics
{
    public class AlphaCounterTracker : CounterTracker<char>
    {
        private Dictionary<char, int> AlphaCounter = new Dictionary<char, int>();
        internal const int defaultInitialValue = 0;

        public AlphaCounterTracker()
        {
            string AlphabetInCaps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char c in AlphabetInCaps)
            {
                AlphaCounter.Add(c, defaultInitialValue);
            }
        }

        public int GetValue(char c)
        {
            return AlphaCounter[c];
        }

        public void Increment(char Key)
        {
            char UppercaseKey = Char.ToUpper(Key);
            if (AlphaCounter.ContainsKey(UppercaseKey))
            {

                if (++AlphaCounter[UppercaseKey] > this.HighestOccuranceCount)
                {
                    highestOccuranceCount++;
                    highestOccuringItems.Clear();
                }
                if (AlphaCounter[UppercaseKey] == highestOccuranceCount && !highestOccuringItems.Contains(UppercaseKey))
                {
                    highestOccuringItems.Add(UppercaseKey);
                }
            }
        }
        public string GetItemizedCountResults(string Quantifier = "Count: ")
        {
            StringBuilder CountResults = new StringBuilder(Quantifier + System.Environment.NewLine);
            foreach (char c in AlphaCounter.Keys)
            {
                CountResults.Append($"{c} - {AlphaCounter[c]}" + System.Environment.NewLine);
            }
            return CountResults.ToString();
        }
    }

}
