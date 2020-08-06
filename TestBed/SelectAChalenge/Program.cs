﻿using System;
using TestBed;
using System.Reflection;

namespace SelectAChalenge
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
        static void Main()
        {
            MethodInfo[] methodInfos = typeof(Challenges).GetMethods();
            System.Collections.Generic.List<string> CSharpMethodNames = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> JavaScriptMethodNames = new System.Collections.Generic.List<string>();
            foreach (MethodInfo MethodInfo in methodInfos)
            {
                if (MethodInfo.IsPublic)
                {
                    CSharpMethodNames.Add(MethodInfo.Name);
                }
            }
            CSharpMethodNames.Add("SmallWorld");
            CSharpMethodNames.Add("SelectAChalenge");
            JavaScriptMethodNames.Add("FindCharsVowelsFirst");
            JavaScriptMethodNames.Add("Reverser");
            JavaScriptMethodNames.Add("DataMunging");
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Console.WriteLine("C#, JavaScript, or All?");
            ConsoleKeyInfo answerKey = Console.ReadKey();
            char answer = answerKey.KeyChar;
            Console.WriteLine();
            if (answer == 'c' || answer == 'C')
            {
                int CSharpSelection = rand.Next(0, CSharpMethodNames.Count - 1);
                Console.WriteLine($"C# answer: {CSharpMethodNames[CSharpSelection]}");
            }
            else if (answer == (int)'j' || answer == (int)'J')
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
            Console.WriteLine("Select any key to close.");
            Console.ReadLine();
            Console.WriteLine($"Application complete.");
        }
    }
}
