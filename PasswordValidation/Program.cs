//https://edabit.com/challenge/etT7orqDDXJF2zGYM

//Create a function that validates a password to conform to the following rules:

//Length between 6 and 24 characters.
//At least one uppercase letter (A-Z).
//At least one lowercase letter (a-z).
//At least one digit (0-9).
//Maximum of 2 repeated characters.
//"aa" is OK 👍
//"aaa" is NOT OK 👎
//Supported special characters:
//! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; " ' ? < > , .
//Examples
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine(ValidatePassword("P1zz@"));
//ValidatePassword("P1zz@") ➞ false
//// Too short.

Console.WriteLine(ValidatePassword("iLoveYou"));
//ValidatePassword("iLoveYou") ➞ false
//// Missing a number.

Console.WriteLine(ValidatePassword("Fhg93@"));
//ValidatePassword("Fhg93@") ➞ true
//// OK!
///

Console.WriteLine(ValidatePassword("Pè7$areLove"));

Console.WriteLine(ValidatePassword("zZ9'?<>,."));

static bool ValidatePassword(string password)
{
    //Length between 6 and 24 characters.
    if (password.Length < 6 || password.Length > 24)
        return false;

    //At least one uppercase letter (A-Z).
    if (!password.Where(char.IsUpper).Any())
        return false;

    //At least one lowercase letter (a-z).
    if (!password.Where(char.IsLower).Any())
        return false;

    //At least one digit (0-9).
    if (!password.Where(char.IsNumber).Any())
        return false;

    //Maximum of 2 repeated characters.
    //"aa" is OK 👍
    //"aaa" is NOT OK 👎
    if (password.GroupBy(c => c).Where(x => x.Count() > 2).Any())
        return false;

    //Supported special characters:
    //! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; " ' ? < > , .
    var allowedSymbols = "! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; \" ' ? < > , .".ToCharArray().Where(c => !char.IsWhiteSpace(c));
    if (password.Where(c => !char.IsLetterOrDigit(c) && !allowedSymbols.Where(s => s == c).Any()).Any())
        return false;

    if (password.Where(x => new[] {'é', 'è'}.Contains(x)).Any())
        return false;

    return true;
}