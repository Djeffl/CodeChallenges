
//https://edabit.com/challenge/uhsik73PY7Y2XftzG

//Pig latin has two very simple rules:

//If a word starts with a consonant move the first letter(s) of the word, till you reach a vowel, to the end of the word and add "ay" to the end.
//have ➞ avehay
//cram ➞ amcray
//take ➞ aketay
//cat ➞ atcay
//shrimp ➞ impshray
//trebuchet ➞ ebuchettray
//If a word starts with a vowel add "yay" to the end of the word.
//ate ➞ ateyay
//apple ➞ appleyay
//oaken ➞ oakenyay
//eagle ➞ eagleyay
//Write two functions to make an English to pig latin translator. The first function TranslateWord(word) takes a single word and returns that word translated into pig latin. The second function TranslateSentence(sentence) takes an English sentence and returns that sentence translated into pig latin.

//Examples
Console.WriteLine(TranslateWord("I"));

//TranslateWord("flag") ➞ "agflay"
Console.WriteLine(TranslateWord("flag"));

//TranslateWord("Apple") ➞ "Appleyay"
Console.WriteLine(TranslateWord("Apple"));

//TranslateWord("button") ➞ "uttonbay"
Console.WriteLine(TranslateWord("button"));

//TranslateWord("") ➞ ""
Console.WriteLine(TranslateWord(""));
//TranslateSentence("I like to eat honey waffles.") ➞ "Iyay ikelay otay eatyay oneyhay afflesway."
Console.WriteLine(TranslateSentence("I like to eat honey waffles."));
//TranslateSentence("Do you think it is going to rain today?") ➞ "Oday ouyay inkthay ityay isyay oinggay otay ainray odaytay?"
//Notes
//Regular expressions will help you not mess up the punctuation in the sentence.
//If the original word or sentence starts with a capital letter, the translation should preserve its case (see examples #2, #5 and #6).

static string TranslateWord(string word)
{
    if (word == "") return "";

    var chars = new Queue<char>(word.ToArray());

    var wordArray = word.ToArray();

    var end = "ay";
    var isCapitalized = char.IsUpper(wordArray[0]);

    for (var i = 0; i < wordArray.Length; i++)
    {
        var c = char.ToLower(wordArray[i]);
        if (new[] { 'a', 'o', 'i', 'e', 'u' }.Contains(c))
        {
            if (i == 0) end = "yay";
            break;
        }

        chars.Enqueue(char.ToLower(chars.Dequeue()));
    }

    return chars.Select((x, i) => i == 0 && isCapitalized ? char.ToUpper(x) : x).Aggregate("", (a, b) => a + b) + end;
}

static string TranslateSentence(string sentence)
{
    return sentence
        .Split(' ')
        .Select(word =>
        {
            return $"{word.ToCharArray().TakeWhile(Char.IsPunctuation).Aggregate("", (a,b) => a+b)}{TranslateWord(word.Where(c => !char.IsPunctuation(c)).Aggregate("", (a,b) => a+b))}{word.ToCharArray().Reverse().TakeWhile(Char.IsPunctuation).Reverse().Aggregate("", (a, b) => a + b)}";
        })
        .Aggregate((a, b) => $"{a} {b}");
}