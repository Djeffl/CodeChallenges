using System.Text;

https://edabit.com/challenge/wunaXvZw3WctYioeC

//Someone has attempted to censor my strings by replacing every vowel with a *, l*k* th*s. Luckily, I've been able to find the vowels that were removed.

//Given a censored string and a string of the censored vowels, return the original uncensored string.

//Example
//uncensor("Wh*r* d*d my v*w*ls g*?", "eeioeo") ➞ "Where did my vowels go?"

//uncensor("abcd", "") ➞ "abcd"

//uncensor("*PP*RC*S*", "UEAE") ➞ "UPPERCASE"
//Notes
//The vowels are given in the correct order.
//The number of vowels will match the number of * characters in the censored string.

Console.WriteLine(Uncensor("Wh*r* d*d my v*w*ls g*?", "eeioeo"));

static string Uncensor(string sentence, string vowels)
{
    var sb = new StringBuilder();

    var vowelIndex = 0;
    Array.ForEach(sentence.ToCharArray(), c => sb.Append(c != '*' ? c : vowels[vowelIndex++]));

    return sb.ToString();
}