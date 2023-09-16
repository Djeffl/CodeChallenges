using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Linq;

namespace ReverseAndNot
{
    internal class Program
    {
        //https://edabit.com/challenge/YGhgctqPsKQxQQCFS
        static void Main(string[] args)
        {
            // Write a function that takes an integer i and
            // returns a string with the integer backwards followed by the original integer.

            //Bonus: By using System.Linq this should be completed in one line of code.
            Console.WriteLine(ReverseAndNot(123));


        }

        static string ReverseAndNot(int number)
        {
            // ONE LINER BOII
            return (number.ToString().ToArray().Reverse().Concat(number.ToString().ToArray())).Aggregate<char, string>("", (a, b) => a + b);
        }
    }
}