// https://edabit.com/challenge/MnPogX5KgggaRpaJo

//Poker Hand Ranking
//In this challenge, you have to establish which kind of Poker combination is present in a deck of five cards. Every card is a string containing the card value (with the upper-case initial for face-cards) and the lower-case initial for suits, as in the examples below:

//"Ah" ➞ Ace of hearts
//"Ks" ➞ King of spades
//"3d" ➞ Three of diamonds
//"Qc" ➞ Queen of clubs
//"10c" ➞ Ten of clubs
//There are 10 different combinations. Here's the list, in decreasing order of importance:

//Name	Description
//Royal Flush	A, K, Q, J, 10, all with the same suit.
//Straight Flush	Five cards in sequence, all with the same suit.
//Four of a Kind	Four cards of the same rank.
//Full House	Three of a Kind with a Pair.
//Flush	Any five cards of the same suit, not in sequence.
//Straight	Five cards in a sequence, but not of the same suit.
//Three of a Kind	Three cards of the same rank.
//Two Pair	Two different Pair.
//Pair	Two cards of the same rank.
//High Card	No other valid combination.
//Given an array hand containing five strings being the cards, implement a function that returns a string with the name of the highest combination obtained, accordingly to the table above.

//Examples
//PokerHandRanking({ "10h", "Jh", "Qh", "Ah", "Kh" }) ➞ "Royal Flush"

//PokerHandRanking({ "3h", "5h", "Qs", "9h", "Ad" }) ➞ "High Card"

//PokerHandRanking({ "10s", "10c", "8d", "10d", "10h" }) ➞ "Four of a Kind"

using System.Threading;

Console.WriteLine(PokerHandRanking(["10h", "Jh", "Qh", "Ah", "Kh"]));
Console.WriteLine(PokerHandRanking(["3h", "5h", "Qs", "9h", "Ad"]));
Console.WriteLine(PokerHandRanking(["10s", "10c", "8d", "10d", "10h"]));
static string PokerHandRanking(string[] hand)
{
	var cardOrder = new string[] { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" }
			.Select((value, index) => new { value, index })
			.ToDictionary(pair => pair.value, pair => pair.index);

	var isFlush = hand
		.SelectMany(card => card.Where(c => char.IsLower(c))) // Get all suits of each card (lowercase characters)
		.GroupBy(suit => suit) // Group them
		.Count().Equals(1);

	var cardPositions = hand.Select(card => card.Where(c => !char.IsLower(c)).Aggregate("", (a, b) => a + b)).Select(cardValue => cardOrder[cardValue]).Order();

	var groups = cardPositions.GroupBy(pos => pos);

	var pairs = 0;
	var triples = 0;
	var quotros = 0;
	foreach (var group in groups)
	{
		if (group.Count() == 2) { pairs++; }
		if (group.Count() == 3) { triples++; }
		if (group.Count() == 4) { quotros++; }
	}

	var isStraight = cardPositions.Zip(cardPositions.Skip(1), (a, b) => b - a).Where(diff => diff != 1).Count().Equals(0);

	//	Royal Flush A, K, Q, J, 10, all with the same suit.
	var highestCardIsAce = cardPositions.Min() == 0;
	if (isStraight && isFlush && highestCardIsAce) return "Royal Flush";

	//Straight Flush  Five cards in sequence, all with the same suit.
	if (isStraight && isFlush) return "Straight Flush";

	//Four of a Kind  Four cards of the same rank.
	if (quotros is 1) return "Four of a Kind";

	//Full House  Three of a Kind with a Pair.
	if (pairs is 1 && triples is 1) return "Full House";

	//Flush Any five cards of the same suit, not in sequence.
	if (isFlush) return "Flush";

	//Straight Five cards in a sequence, but not of the same suit.
	if (isStraight) return "Straight";

	//Three of a Kind Three cards of the same rank.
	if (triples is 1) return "Three of a Kind";

	//Two Pair    Two different Pair.
	if (pairs is 2) return "Two Pair";

	//Pair Two cards of the same rank.
	if (pairs is 1) return "Pair";

	//High Card   No other valid combination.
	return "High Card";
}