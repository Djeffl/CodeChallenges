//https://edabit.com/challenge/E4eAyJLjgGssf7GFJ

//You are given a list of prime factors arr and a target. When each number in the list is raised to an appropriate power their product will be equal to the target.

//Your role is to return the exponents. All these lists will have a length of three. Basically, it is three numbers whose product is equal to challenge. The only difference is what you are expected to return.

//Examples
//ProductEqualTarget(new int[] { 2, 3, 5 }, 600) ➞ [3, 1, 2]
//// Because 2^3*3^1*5^2 = 600

//ProductEqualTarget(new int[] { 2, 3, 5 }, 720) ➞ [4, 2, 1]
//// Because 2^4*3^2*5^1 = 720
//Notes
//The exponents you will return are expected to replace the base in the list.
//Your returned values must be in the same order as the bases.

var res = ProductEqualTarget(new int[] { 2, 3, 5 }, 600);

Array.ForEach(res, Console.WriteLine);

static int[] ProductEqualTarget(int[] arr, int target)
{
    var val1 = arr.ElementAt(0);
    var val2 = arr.ElementAt(1);
    var val3 = arr.ElementAt(2);

    var pow1 = 1;
    var pow2 = 1;
    var pow3 = 1;

    while (
        IsDividable(target, Math.Pow(val1, pow1 + 1)) &&
        IsValuePossible(target, Math.Pow(val1, pow1 + 1), val2 * val3)
        )
    {
        pow1++;
    }

    while (
            IsDividable(target, Math.Pow(val2, pow2 + 1)) &&
            IsValuePossible(target, Math.Pow(val2, pow2 + 1), val1 * val3)
            )
    {
        pow2++;
    }
    while (
            IsDividable(target, Math.Pow(val3, pow3 + 1)) &&
            IsValuePossible(target, Math.Pow(val3, pow3 + 1), val1 * val2)
            )
    {
        pow3++;
    }

    return new[] { pow1, pow2, pow3 };
}

static bool IsDividable(int totalValue, double divide)
{
    return totalValue % divide == 0;
}

static bool IsValuePossible(int target, double divide, int multiplicationOtherValue)
{
    return (target / divide) % multiplicationOtherValue == 0;
}