using System.Drawing;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WorldThatIsNotVeryBig
{
    public class Program
    {
        /// <summary>
        /// Input: Accepts a file of points in the format \"ID Lat Lon\", where each point is a single line of the file.
        /// Result: Displays the closest three points to each point on the console.
        /// 
        /// Commandline application loads a datafile using the -f commandline argument:
        ///     WorldThatIsNotVeryBig -f "C:\Path\TextFileName"
        ///     
        /// Consider running the unit tests for the fun of seeing green checkmarks, and to get a sence of the edge cases considered.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string filenamepath = "";
            string ListOfPoints;
            string Help =
                "WorldThatIsNotVeryBig: " + System.Environment.NewLine +
                "  Input: Accepts a file of points in the format \"ID Lat Lon\", where each point is a single line of the file. " + System.Environment.NewLine +
                "  Result: Displays the closest three points to each point on the console." + System.Environment.NewLine +
                "Usage: " + System.Environment.NewLine +
                "  WorldThatIsNotVeryBig [options]" + System.Environment.NewLine +
                "Options: " + System.Environment.NewLine +
                "  (--file|-f) file_path_name        Load the input data from file." + System.Environment.NewLine +
                "  (--help|-h)                       Display Help." + System.Environment.NewLine;
            if (args.Count() >= 2)
            {
                switch (args[0])
                {
                    case "-f":
                        {
                            filenamepath = Environment.ExpandEnvironmentVariables(args[1]);
                            break;
                        }
                    case "--file":
                        {
                            filenamepath = Environment.ExpandEnvironmentVariables(args[1]); 
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(Help);
                            return;
                        }
                }
            }
            else
            {
                Console.WriteLine(Help);
                return;
            }
            if (System.IO.File.Exists(filenamepath))
            {
                ListOfPoints = System.IO.File.ReadAllText(Environment.ExpandEnvironmentVariables(args[1]));
                PointColection pointCollection = new PointColection(ListOfPoints);
                Console.WriteLine(pointCollection.GetClosestPointsForEachPoint());
            }
            else
            {
                Console.WriteLine("File {ListOfPoints} does not exist.");
                Console.WriteLine(Help);
            }
        }
    }
}
