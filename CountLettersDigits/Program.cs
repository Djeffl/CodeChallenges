using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace CountLettersDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://edabit.com/challenge/ZSvj2W3J6QRydkyh2

            Console.WriteLine(CountAll("Hello World"));// ➞ "{ LETTERS =  10, DIGITS =  0 }"
            Console.WriteLine(CountAll("H3ll0 Wor1d"));// ➞ "{ LETTERS =  7, DIGITS =  3 }"
            Console.WriteLine(CountAll("149990"));// ➞ "{ LETTERS =  0, DIGITS = 6 }"
        }

        /// <summary>
        /// Write a function that takes a string and calculates the number of letters and digits within it.Return the result as anonymous type in string format.
        /// Examples
        /// count_all("Hello World") ➞ "{ LETTERS =  10, DIGITS =  0 }"
        /// count_all("H3ll0 Wor1d") ➞ "{ LETTERS =  7, DIGITS =  3 }"
        /// count_all("149990") ➞ "{ LETTERS =  0, DIGITS = 6 }"
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string CountAll(string txt)
        {
            var digits = 0;
            var letters = 0;

            var chars = txt.ToArray();

            foreach (var c in chars)
            {
                if (int.TryParse(c.ToString(), out _))
                {
                    digits++;
                } else if(c == ' ')
                {

                }
                else
                {
                    letters++;
                }
            }

            return $"{{ LETTERS = {letters}, DIGITS = {digits} }}";
;        }
    }
}