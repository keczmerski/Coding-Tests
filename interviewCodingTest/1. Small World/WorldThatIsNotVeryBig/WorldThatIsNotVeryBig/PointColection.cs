using System.Drawing;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WorldThatIsNotVeryBig
{
    public class PointColection
    {
        private Dictionary<int, PointF> _Points = new Dictionary<int, PointF>();
        public PointColection( string InputString)
        {
            
            string[] InputLines = InputString.Split(System.Environment.NewLine);

            foreach ( string s in InputLines)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    string sTrimmed = Regex.Replace(Regex.Replace(s, @",", " "), @"\s+", " ");
                    sTrimmed = sTrimmed.Trim();
                    string[] InputLine = sTrimmed.Split(' ');
                    if (InputLine.Length != 3)
                    {
                        Console.WriteLine($"Bad input ignored: \'{s}\'");
                    }
                    else
                    {
                        int ID = Convert.ToInt32(InputLine[0]);
                        PointF thePoint = new PointF(float.Parse(InputLine[1]), float.Parse(InputLine[2]));
                        _Points.Add(ID, thePoint);
                    }
                }
            }
        }

        public string GetClosestPointsForEachPoint()
        {
            Dictionary<int, int[]> ClosestPointsForEachPoint = GetClosestPointsForEachPoint(_Points);
            StringBuilder Result = new StringBuilder();
            foreach(int theKey in ClosestPointsForEachPoint.Keys)
            {
                Result.Append($"{theKey} ");

                for (int i = 0; i < (ClosestPointsForEachPoint[theKey]).Count(); i++)
                {
                    Result.Append((ClosestPointsForEachPoint[theKey])[i]);
                    if (i < (ClosestPointsForEachPoint[theKey]).Count() - 1)
                    {
                        Result.Append(",");
                    }
                }
                Result.AppendLine();
            }
            return Result.ToString();
        }

        public static Dictionary<int, int[]> GetClosestPointsForEachPoint(Dictionary<int, PointF> Points)
        {
            Dictionary<int, int[]> ClosestPointsForEachPoint = new Dictionary<int, int[]>();


            foreach (int point_key_Focused in Points.Keys)
            {
                ClosestPointsForEachPoint.Add(point_key_Focused, GetTheClosest(Points, point_key_Focused));
            }
            return ClosestPointsForEachPoint;
        }

        public static int[] GetTheClosest(Dictionary<int, PointF> Points, int CurrentPointKey)
        {
            int CountOfClosestRequired = 3;
            int CountYouCanAddOneMoretoClosestRequired = CountOfClosestRequired - 1;
            SortedList<double, List<int>> PointKeysSortedByDistance = new SortedList<double, List<int>>();
            List<int> Closest = new List<int>();
            foreach (int keyPoint in Points.Keys)
            {
                if (keyPoint != CurrentPointKey)
                {
                    PointKeysSortedByDistance = RecordPointKeySortedByDistance(Points:Points, PointKeysSortedByDistance: PointKeysSortedByDistance, CurrentPointKey: CurrentPointKey, keyPoint: keyPoint);
                }
            }
            int i = 0;
            while  (Closest.Count < CountOfClosestRequired && i < CountOfClosestRequired)
            {
                int j = 0;
                if (i < PointKeysSortedByDistance.Count && j < PointKeysSortedByDistance.ElementAt(i).Value.Count)
                { 
                    while (Closest.Count  < CountOfClosestRequired && j < PointKeysSortedByDistance.ElementAt(i).Value.Count())
                    {
                        Closest.Add(  PointKeysSortedByDistance.ElementAt(i).Value[j]);
                        j++;
                    }
                }
                i++;
            }
            return Closest.ToArray();
        }
        private static SortedList<double, List<int>> RecordPointKeySortedByDistance(Dictionary<int, PointF> Points, SortedList<double, List<int>> PointKeysSortedByDistance, int CurrentPointKey,  int  keyPoint)
        {
            float CurrentX = Points[CurrentPointKey].X;
            float CurrentY = Points[CurrentPointKey].Y;
            float keyPointX = Points[keyPoint].X;
            float keyPointY = Points[keyPoint].Y;
            double distance = Math.Sqrt((Math.Pow((keyPointX - CurrentX), 2F)) + (Math.Pow((keyPointY - CurrentY), 2F)));
            if (PointKeysSortedByDistance.ContainsKey(distance))
            {
                PointKeysSortedByDistance[distance].Add(keyPoint);
            }
            else
            {
                PointKeysSortedByDistance.Add(distance, new List<int> { keyPoint });
            }
            return PointKeysSortedByDistance;
        }
    }
}
