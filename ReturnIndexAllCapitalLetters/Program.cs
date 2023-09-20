//https://edabit.com/challenge/6qFnpAhd3kdmYcNG2

//Create a function that takes a single string as argument and returns an ordered array containing the indices of all capital letters in the string.

//Examples
//IndexOfCapitals("eDaBiT") ➞ [1, 3, 5]

//IndexOfCapitals("eQuINoX") ➞ [1, 3, 4, 6]

//IndexOfCapitals("determine") ➞ []

//IndexOfCapitals("STRIKE") ➞ [0, 1, 2, 3, 4, 5]

//IndexOfCapitals("sUn") ➞ [1]
//Notes
//Return an empty array if no uppercase letters are found in the string.
//Special characters ($#@%) and numbers will be included in some test cases.
//Assume all words do not have duplicate letters.

Array.ForEach(IndexOfCapitals("eDaBiT"), Console.Write);

Console.WriteLine(); //➞ [1, 3, 5]

Array.ForEach(IndexOfCapitals("eQuINoX"), Console.Write);

Console.WriteLine(); // ➞ [1, 3, 4, 6]

Array.ForEach(IndexOfCapitals("determine"), Console.Write);

Console.WriteLine(); //➞ []

Array.ForEach(IndexOfCapitals("STRIKE"), Console.Write);

Console.WriteLine(); // ➞ [0, 1, 2, 3, 4, 5]

Array.ForEach(IndexOfCapitals("sUn"), Console.Write);

Console.WriteLine();  // ➞ [1]

Array.ForEach(IndexOfCapitals("Fo?.arg~{86tUx=|OqZ!"), Console.Write);

Console.WriteLine();  // ➞ [0, 12, 16, 18]

static int[] IndexOfCapitals(string str)
{
	var result = new List<int>();

    var a = str.ToArray();

	for (int i = 0; i < a.Length; i++)
	{
		var c = a[i];

		if (Char.IsAsciiLetterUpper(c))
		{
			result.Add(i);
		}
	}

	return result.ToArray();
}