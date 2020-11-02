using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GatherTextStatistics
{
    public class PrefixCounterTracker : CounterTracker<string>
    {

        private Dictionary<string, List<string>> StringTracker = new Dictionary<string, List<string>>();
        private void Add(string Key, string AssociatedWord)
        {
            if (!StringTracker.ContainsKey(Key))
            {
                StringTracker.Add(Key, new List<string>());
            }
            StringTracker[Key].Add(AssociatedWord);
        }
        public void Increment(string Prefix, string AssociatedWord)
        {
            this.Add(Prefix, AssociatedWord);
            if (StringTracker[Prefix].Count > highestOccuranceCount)
            {
                highestOccuranceCount++;
                highestOccuringItems.Clear();
            }
            if (StringTracker[Prefix].Count == highestOccuranceCount && !highestOccuringItems.Contains(Prefix))
            {
                highestOccuringItems.Add(Prefix);
            }
        }
        public string GetGeneralCountResults(string ItemDescriptor = "Counted Prefixes: ")
        {
            // filter
            StringBuilder highestItemStatisticsFormatted = new StringBuilder($"{ItemDescriptor}{System.Environment.NewLine}");
            string[] filteredHighestItems = this.GetFilteredListWithOnlyLargestStrings();

            for (int i = 0; i < filteredHighestItems.Length; i++)
            {
                highestItemStatisticsFormatted.Append($"Prefix: {filteredHighestItems[i]}{System.Environment.NewLine}");
                highestItemStatisticsFormatted.Append($"Associated Words: ");
                for (int j = 0; j < StringTracker[filteredHighestItems[i]].Count; j++)
                {
                    highestItemStatisticsFormatted.Append((StringTracker[filteredHighestItems[i]])[j]);
                    if (j != StringTracker[filteredHighestItems[i]].Count - 1)
                    {
                        highestItemStatisticsFormatted.Append(", ");
                    }
                }
                highestItemStatisticsFormatted.Append(System.Environment.NewLine);
            }
            highestItemStatisticsFormatted.Append($"Count: { this.HighestOccuranceCount }");
            return highestItemStatisticsFormatted.ToString();
        }
        /// <remarks>This takes advantage of the known order used to add items on the list, 
        /// It would be safer to sort the items by size first, but that would be slightly less efficient. </remarks>
        private string[] GetFilteredListWithOnlyLargestStrings()
        {
            List<string> AllStrings = new List<string>();
            foreach (string item in highestOccuringItems)
            {
                AllStrings.Add(item.ToString());
            }
            List<string> LargestStrings = new List<string>(AllStrings.ToArray());

            foreach (string s in AllStrings)
            {
                if (s.Length > 2 && LargestStrings.Contains(s.Substring(0, s.Length - 1)))
                {
                    LargestStrings.Remove(s.Substring(0, s.Length - 1));
                }
            }
            return LargestStrings.ToArray();
        }
        public override bool HighestIncludes(string Key)
        {
            return this.GetFilteredListWithOnlyLargestStrings().Contains(Key);
        }
        public bool AssociatedIncludes(string Key, string word)
        {
            return StringTracker[Key].Contains(word);
        }
    }

}
