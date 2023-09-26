//Create a function that returns the simplified version of a fraction.

//Examples
//Simplify("4/6") ➞ "2/3"

//Simplify("10/11") ➞ "10/11"

//Simplify("100/400") ➞ "1/4"

//Simplify("8/4") ➞ "2"
//Notes
//A fraction is simplified if there are no common factors (except 1) between the numerator and the denominator. For example, 4/6 is not simplified, since 4 and 6 both share 2 as a factor.
//If improper fractions can be transformed into integers, do so in your code (see example #4).

//https://edabit.com/challenge/3wT3QcDdfvMR3amjc

static string Simplify(string str)
{
    var numerator = int.Parse(str.Split('/')[0]);
    var denominator = int.Parse(str.Split('/')[1]);

    if (numerator == 0) return "0";

    if (denominator == 0) throw new ArgumentException();

    if (numerator == denominator) return "1";

    if (numerator % denominator == 0) return (numerator / denominator).ToString();

    var simplifyingNumbers = Enumerable.Range(1, numerator).ToArray();

    Array.ForEach(simplifyingNumbers, x =>
    {
        if (numerator % x == 0 && denominator % x == 0)
        {
            numerator /= x;
            denominator /= x;
        }
    });

    return $"{numerator}/{denominator}";
}