using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GatherTextStatistics
{
    public class CounterTracker<T>
    {
        protected int highestOccuranceCount = 0;
        public int HighestOccuranceCount => highestOccuranceCount;
        protected List<T> highestOccuringItems = new List<T>();

        /// <remarks>Serves Unit tests</remarks>
        public virtual bool HighestIncludes(T Key)
        {
            return highestOccuringItems.Contains(Key);
        }
    }
}
