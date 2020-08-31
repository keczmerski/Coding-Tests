using System;
using TestBed;
using System.Reflection;
using System.Linq;

namespace SelectAChallenge
{
    class Program
    {
        /// <summary>
        /// On ocassion I want to go through the coding chalenges I have recorded so far and analize them to see if they could be improved uppon. 
        /// In order to do this in a non bias way, I want to select a method at random. The public methods are the challenges and the private methods only assist the challenges.
        /// Other chalenges in other projects and languages will be hard coded in for now. 
        /// Perhaps some time I will find away to automatically include them as well. 
        /// I suppose, this may depend on how long those other lists grow.
        /// </summary>
        /// <param name="args"></param>
        static void Main() { 
        
            MethodInfo[] methodInfoChallenges = typeof(Challenges).GetMethods();
            //MethodInfo[] methodInfoSort_Challengess = typeof(Sort_Challenges).GetMethods();// I think this one is fully investigated so I am not including it anymore
            System.Collections.Generic.List<string> CSharpMethodNames = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> JavaScriptMethodNames = new System.Collections.Generic.List<string>();
            foreach (MethodInfo MethodInfo in methodInfoChallenges)
            {
                string[] filterMethodsThatArePlayedOut = new string[] { "SumOfDigits" };
                if (MethodInfo.IsPublic && !filterMethodsThatArePlayedOut.Contains(MethodInfo.Name))
                {
                    CSharpMethodNames.Add(MethodInfo.Name);
                }
            }
            //foreach (MethodInfo MethodInfo in methodInfoSort_Challengess) // I think this one is fully investigated
            //{
            //    if (MethodInfo.IsPublic)
            //    {
            //        CSharpMethodNames.Add(MethodInfo.Name);
            //    }
            //}
            CSharpMethodNames.Add("SmallWorld");
            CSharpMethodNames.Add("SelectAChalenge");
            JavaScriptMethodNames.Add("FindCharsVowelsFirst");
            JavaScriptMethodNames.Add("Reverser");
            JavaScriptMethodNames.Add("DataMunging");
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Console.WriteLine("Study Selector? (Y/N) (If not then you are simply randomly selecting some code to review.)");
            ConsoleKeyInfo StudySelectorAnswerKey = Console.ReadKey();
            char StudySelectorAnswer = StudySelectorAnswerKey.KeyChar;

            bool IsSelectCodeForReview = true;
            string simpleBoarder = "******************************************************************" + System.Environment.NewLine;
            string TextBoarder = System.Environment.NewLine + System.Environment.NewLine + simpleBoarder + simpleBoarder + simpleBoarder + System.Environment.NewLine;

            if (StudySelectorAnswer == 'Y' || StudySelectorAnswer == 'y')
            {
                string selectACodeReview = "Select a code review and have it reviewed on Stack overflow/ code reviews.";
                string[] Choices = new string[] {
                    "Read your text book (Or research on line) and study algorythms.",
                    "Read your text book (Or research on line) and study datastructures.",
                    "Create a DataStructure in your coding chalenge section.",
                    "Create a sorting algorythm in your coding chalenge section.",
                    "Do a Hacker Rank coding challenge.",
                    "Do a LeetCode coding challenge.",
                    "Do a Hacker Rank coding challenge.",
                    "Do a LeetCode coding challenge.",
                    "Do a Hacker Rank coding challenge.",
                    "Do a LeetCode coding challenge.",
                    "Okay, okay, study Unity. Sigh.",
                    selectACodeReview,
                    selectACodeReview
                };
                int StudySelectorSelection = rand.Next(0, Choices.Count());
                Console.WriteLine(TextBoarder + $"{Choices[StudySelectorSelection]}" + TextBoarder);
                if (!String.Equals(selectACodeReview, Choices[StudySelectorSelection]))
                {
                    IsSelectCodeForReview = false;
                }
                
            }


            if (IsSelectCodeForReview)
            {
                Console.WriteLine();
                Console.WriteLine("C#, JavaScript, or All?");
                Console.WriteLine();
                ConsoleKeyInfo answerKey = Console.ReadKey();
                char answer = answerKey.KeyChar;

                if (answer == 'c' || answer == 'C')
                {
                    int CSharpSelection = rand.Next(0, CSharpMethodNames.Count - 1);
                    Console.WriteLine($"C# answer: {CSharpMethodNames[CSharpSelection]}");
                }
                else if (answer == 'j' || answer == 'J')
                {
                    int JSSelection = rand.Next(0, JavaScriptMethodNames.Count - 1);
                    Console.WriteLine($"JS answer: {JavaScriptMethodNames[JSSelection]}");
                }
                else
                {
                    System.Collections.Generic.List<string> AllMethodNames = new System.Collections.Generic.List<string>();
                    AllMethodNames.AddRange(CSharpMethodNames);
                    AllMethodNames.AddRange(JavaScriptMethodNames);
                    int AllSelection = rand.Next(0, AllMethodNames.Count - 1);
                    Console.WriteLine($"All answer: {AllMethodNames[AllSelection]}");
                }
                Console.WriteLine(TextBoarder);
            }
            Console.WriteLine("Select any key to close.");
            Console.ReadLine();
            Console.WriteLine($"Application complete.");
        }
    }
}
