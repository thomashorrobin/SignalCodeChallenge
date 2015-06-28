using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SentenceSpliter;
using SentenceSpliter.Exceptions;
using System.IO;

namespace SignalCodeChallengeCLI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Program p = new Program();
            p.PrintOptions();
        }

        void DisplayResults(Text text)
        {
            Console.WriteLine("Number of sentences: " + text.SentenceCount);
            Console.WriteLine("Number of words: " + text.WordCount);
            string longestSentences = "Sentence(s) with the most words: ";
            List<Sentence> longestSentencesList = text.FindSentenceWithMostWords(0);
            if (longestSentencesList.Count > 0)
            {
                longestSentences += longestSentencesList[0].SentenceSnippet;
                for (int i = 1; i < longestSentencesList.Count; i++)
                {
                    longestSentences += ", " + longestSentencesList[0].SentenceSnippet;
                }
            }
            Console.WriteLine(longestSentences);
            string mostFrequentWord = "Most frequently used word(s): ";
            List<string> mostFrequentWords = text.FindMostCommonWord(0);
            if (mostFrequentWords.Count > 0)
            {
                mostFrequentWord += mostFrequentWords[0];
                for (int i = 1; i < mostFrequentWords.Count; i++)
                {
                    mostFrequentWord += ", " + mostFrequentWords[i];
                }
            }
            Console.WriteLine(mostFrequentWord);
            string longestWords = "3rd longest word(s): ";
            List<string> longestWords2 = text.FindLongestWord(2);
            if (longestWords2.Count > 0)
            {
                longestWords += longestWords2[0];
                for (int i = 1; i < longestWords2.Count; i++)
                {
                    longestWords += ", " + longestWords2[i];
                }
            }
            Console.WriteLine(longestWords);
            AskUserForCmd();
        }

        void TypeText()
        {
            Console.Write("text: ");
            string text = Console.ReadLine();
            try
            {
                DisplayResults(new Text(text));
            }
            catch (InvalidWordException ex)
            {
                Console.WriteLine(ex.WordText + " is not a valid word");
            }
            catch (InvalidSentenceException ex)
            {
                Console.WriteLine("\"" + ex.SentenceText + "\" is not a valid sentence");
            }
        }

        void UploadFile()
        {
            OpenFileDialog fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string text;
                Stream s = fbd.OpenFile();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(s))
                {
                    text = reader.ReadToEnd();
                }
                s.Close();
                try
                {
                    Text t = new Text(text);
                    DisplayResults(t);
                }
                catch (InvalidWordException ex)
                {
                    Console.WriteLine(ex.WordText + " is not a valid word");
                }
                catch (InvalidSentenceException ex)
                {
                    Console.WriteLine("\"" + ex.SentenceText + "\" is not a valid sentence");
                }
            }
            else
            {
                Console.WriteLine("File didn't work");
                AskUserForCmd();
            }
        }

        void AskUserForCmd()
        {
            Console.Write("cmd: ");
            string cmd = Console.ReadLine();
            switch (cmd)
            {
                case("help"):
                    PrintOptions();
                    break;
                case("typetext"):
                    TypeText();
                    break;
                case ("uploadfile"):
                    UploadFile();
                    break;
                case("exit"):
                    break;
                default:
                    PrintOptions();
                    break;
            }
        }

        void PrintOptions()
        {
            Console.WriteLine("This is the command line interface for the code challenge");
            Console.WriteLine("commands:");
            Console.WriteLine("help : displays this message");
            Console.WriteLine("typetext : allows the uses to text directly into the console");
            Console.WriteLine("uploadfile : allows the user to upload a text file");
            AskUserForCmd();
        }
    }
}
