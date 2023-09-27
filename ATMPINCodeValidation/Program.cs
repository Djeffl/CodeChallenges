//https://edabit.com/challenge/gBYEFXeD9G2JMZ9dD

//ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits. Your task is to create a function that takes a string and returns true if the PIN is valid and false if it's not.

//Examples
//ValidatePIN("1234") ➞ true
ValidatePIN("1234");

//ValidatePIN("12345") ➞ false

//ValidatePIN("a234") ➞ false

//ValidatePIN("") ➞ false
//Notes
//Some test cases contain special characters.
//Empty strings must return false.

static bool ValidatePIN(string pin)
{
    return (pin.Count() == 4 || pin.Count() == 6) && !pin.Where(c => !char.IsDigit(c)).Any();
}

