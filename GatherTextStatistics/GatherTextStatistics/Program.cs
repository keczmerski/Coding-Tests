using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;

namespace GatherTextStatistics
{
    public class Program
    {
        private static void Main()
        {
            string textFromFile = GetTextFromFile(GetFileDataFromCommandLine());
            Console.WriteLine(GetStatistics(textFromFile));
            Console.WriteLine(System.Environment.NewLine + "Application Complete.");
        }
        internal enum FileType{ local, WebClient};
        internal struct FileData
        {
            internal FileType fileType;
            internal string fileNamePath;
        }

        private static FileData GetFileDataFromCommandLine()
        {
            FileData fileData = new FileData();
            try
            {
                
                string[] arguments = Environment.GetCommandLineArgs();

                switch (arguments[0].ToLower())
                {
                    case "-w":
                        {
                            fileData.fileType = FileType.WebClient;
                            fileData.fileNamePath = Environment.ExpandEnvironmentVariables(arguments[1]);
                            break;
                        }
                    case "-l":
                        {
                            fileData.fileType = FileType.local;
                            fileData.fileNamePath = Environment.ExpandEnvironmentVariables(arguments[1]);
                            break;
                        }
                    default:
                        {
                            fileData.fileType = FileType.local;
                            fileData.fileNamePath = Environment.ExpandEnvironmentVariables(arguments[0]);
                            break;
                        }
                }
                
                if (!System.IO.File.Exists(fileData.fileNamePath)){
                    throw new System.IO.FileNotFoundException(fileData.fileNamePath);
                }
            }
            catch (Exception e)
            {
                ExceptionCaughtAccessingFile(e);
            }
            return fileData;
        }

        private static void ExceptionCaughtAccessingFile(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine();
            Console.WriteLine("Usage: ");
            Console.WriteLine("[-w] file_path: Access file on web domain.");
            Console.WriteLine("[-l] file_path: Access local file path");
            Console.WriteLine("file_path: Access local file path");
        }
        /// <remarks>Hard coded Text File Address should probably be set in a configuration file.</remarks>
        private static string GetTextFromFile(FileData fileData)
        {
            string TextFileAddress = fileData.fileNamePath;
            string textFromFile = "";

            Console.Write("Collecting File Data...");
            try
            {
                switch (fileData.fileType)
                {
                    case FileType.WebClient:
                        {
                            WebClient client = new WebClient();
                            textFromFile = client.DownloadString(TextFileAddress);
                            break;
                        }
                    case FileType.local:
                    default:
                        {
                            textFromFile = System.IO.File.ReadAllText(TextFileAddress);
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                ExceptionCaughtAccessingFile(e);
            }

            Console.WriteLine("Complete.");
            return textFromFile;
        }
        private static string GetStatistics(string AnalizeText)
        {
            StringBuilder staticticsCollected = new StringBuilder();

            Console.Write("Collecting Statistics... ");
            CheckEachChar(AnalizeText, out AlphaCounterTracker LetterCount,
                out WordCounterTracker WordCount, 
                out int CapitalizationCount,
                out PrefixCounterTracker AnyPrefixCount);
            Console.WriteLine("Complete."); 

            Console.Write("Formatting Data... ");
            staticticsCollected.Append(LetterCount.GetItemizedCountResults("Letter Count (case insensitive):"));
            staticticsCollected.Append(System.Environment.NewLine);
            staticticsCollected.Append($"Count of Capatalized Letters: {CapitalizationCount}");
            staticticsCollected.Append(System.Environment.NewLine);
            staticticsCollected.Append(System.Environment.NewLine);
            staticticsCollected.Append(WordCount.GetGeneralCountResults( "Most Occurring Word(s): "));
            staticticsCollected.Append(System.Environment.NewLine);
            staticticsCollected.Append(System.Environment.NewLine);
            staticticsCollected.Append(AnyPrefixCount.GetGeneralCountResults("Most Occurring prefix(s) of two or more characters: "));
            Console.WriteLine("Complete.");
            Console.WriteLine();

            return staticticsCollected.ToString();
        }

        public static void CheckEachChar(string TargetText, out AlphaCounterTracker Letter_OccuranceCounts, 
            out WordCounterTracker WordCount, out int CapitalizationCount, 
            out PrefixCounterTracker AnyPrefixCount)
        {
            Letter_OccuranceCounts = new AlphaCounterTracker();

            CapitalizationCount = 0;

            StringBuilder CurrentWord = new StringBuilder();
            WordCount = new WordCounterTracker();
            AnyPrefixCount = new PrefixCounterTracker();
            
            foreach (char c in TargetText)
            {
                Letter_OccuranceCounts.Increment(c);

                if (Char.IsUpper(c))
                {
                    CapitalizationCount++;

                    if (CurrentWord.Length > 0)
                    {
                        WordCount.Increment(CurrentWord.ToString());
                        CheckEachWordForPrefixes(CurrentWord.ToString(), ref AnyPrefixCount);
                        CurrentWord.Clear();
                    }
                }
                CurrentWord.Append(c);
            }

            if (CurrentWord.Length > 0)
            {
                WordCount.Increment(CurrentWord.ToString());
                CheckEachWordForPrefixes(CurrentWord.ToString(), ref AnyPrefixCount);
                CurrentWord.Clear();
            }
        }


        private static void CheckEachWordForPrefixes(string word, ref PrefixCounterTracker AnyPrefixCount)
        {
            int minimumPostfixLength = 1;

            for (int i = 1; i < word.Length - minimumPostfixLength; i++)
            {
                AnyPrefixCount.Increment(word.Substring(0, i + 1), word);
            }
        }
    }
}
