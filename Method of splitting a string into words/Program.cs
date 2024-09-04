using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Method_of_splitting_a_string_into_words
{
    internal class Program
    {

        static string[] SplitText(string text)
        {
            string[] words = text.Split(' ');
            return words;
        }

        static void PrintWords(string[] words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void Main(string[] args)
        {
            WriteLine("Enter the long sentence");
            string input = Console.ReadLine();

            string[] words = SplitText(input);

            WriteLine();

            PrintWords(words);
            
            ReadKey();
        }
    }
}
