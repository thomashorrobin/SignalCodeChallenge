using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SentenceSpliter;
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
            AskUserForCmd();
        }

        void TypeText()
        {
            Console.Write("text: ");
            string text = Console.ReadLine();
            DisplayResults(new Text(text));
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
                DisplayResults(new Text(text));
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
