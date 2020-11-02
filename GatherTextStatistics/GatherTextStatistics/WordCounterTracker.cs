using System;
using System.Collections.Generic;
using System.Text;

namespace GatherTextStatistics
{
    public class WordCounterTracker : CounterTracker<string>
    {
        private Dictionary<string, int> WordCounter = new Dictionary<string, int>();
        internal const int defaultInitialValue = 0;

        private void Add(string Key)
        {
            if (!WordCounter.ContainsKey(Key))
            {
                WordCounter.Add(Key, defaultInitialValue);
            }
        }

        public void Increment(string Key)
        {
            this.Add(Key);
            if (++WordCounter[Key] > this.HighestOccuranceCount)
            {
                highestOccuranceCount++;
                highestOccuringItems.Clear();
            }
            if (WordCounter[Key] == highestOccuranceCount && !highestOccuringItems.Contains(Key))
            {
                highestOccuringItems.Add(Key);
            }
        }
        public string GetGeneralCountResults(string ItemDescriptor = "Counted Words: ")
        {
            // filter
            StringBuilder highestItemStatisticsFormatted = new StringBuilder($"{ItemDescriptor}{System.Environment.NewLine}");

            for (int i = 0; i < highestOccuringItems.Count; i++)
            {
                highestItemStatisticsFormatted.Append($"{highestOccuringItems[i]}");
                if (i != highestOccuringItems.Count - 1)
                {
                    highestItemStatisticsFormatted.Append(", ");
                }
            }
            highestItemStatisticsFormatted.Append($"{System.Environment.NewLine}Count: { this.HighestOccuranceCount }");
            return highestItemStatisticsFormatted.ToString();
        }
    }

}
