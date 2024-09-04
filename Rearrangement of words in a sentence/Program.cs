using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Rearrangement_of_words_in_a_sentence
{
    internal class Program
    {

        static string[] SplitText(string text)
        {
            string[] words = text.Split(' ');
            return words;
        }

        static string ReversWords(string inputPhrase)
        {
            string[] words = SplitText(inputPhrase);
            
            Array.Reverse(words);

            string reversedPhrase = string.Join(" ", words);
            return reversedPhrase;

        }
        static void Main(string[] args)
        {
            WriteLine("Enter the long sentence");
            string input = Console.ReadLine();

            string reversedPhrase = ReversWords(input);

            WriteLine("Sentence with Revers");
            WriteLine($"{reversedPhrase}"); 

            ReadKey();
        }
    }
}
