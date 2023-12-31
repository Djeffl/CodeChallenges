﻿//Create a function to check if a candidate is qualified in an imaginary coding interview of an imaginary tech startup.

//The criteria for a candidate to be qualified in the coding interview is:

//The candidate should have complete all the questions.
//The maximum time given to complete the interview is 120 minutes.
//The maximum time given for very easy questions is 5 minutes each.
//The maximum time given for easy questions is 10 minutes each.
//The maximum time given for medium questions is 15 minutes each.
//The maximum time given for hard questions is 20 minutes each.
//If all the above conditions are satisfied, return "qualified", else return "disqualified".

//You will be given an array of time taken by a candidate to solve a particular question and the total time taken by the candidate to complete the interview.

//Given an array, in a true condition will always be in the format [very easy, very easy, easy, easy, medium, medium, hard, hard].

//The maximum time to complete the interview includes a buffer time of 20 minutes.

//Examples
//Interview(new int[] { 5, 5, 10, 10, 15, 15, 20, 20 }, 120) ➞ "qualified"

//Interview(new int[] { 2, 3, 8, 6, 5, 12, 10, 18 }, 64) ➞  "qualified"

//Interview(new int[] { 5, 5, 10, 10, 25, 15, 20, 20 }, 120) ➞ "disqualified"
//// Exceeded the time limit for a medium question.

//Interview(new int[] { 5, 5, 10, 10, 15, 15, 20 }, 120) ➞ "disqualified"
//// Did not complete all the questions.

//Interview(new int[] { 5, 5, 10, 10, 15, 15, 20, 20 }, 130) ➞ "disqualified"
//// Solved all the questions in their respected time limits but exceeded the total time limit of the interview.
//Notes
//Try to solve the problem using only array methods.

using System.Collections;

Console.WriteLine(Interview(new int[] { 5, 5, 10, 10, 15, 15, 20, 20 }, 120));
Console.WriteLine(Interview(new int[] { 5, 5, 10, 10, 15, 15, 20 }, 120));

static string Interview(int[] arr, int tot)
{
    var isValid = true;

    var questionQueue = new Queue<string>(new string[] { "VE", "VE", "E", "E", "M", "M", "H", "H" });

    if (questionQueue.Count != arr.Length) isValid = false;

    foreach (var interviewQuestionTime in arr)
    {
        var currentQuestion = questionQueue.Dequeue();
        switch (currentQuestion)
        {
            case "VE": isValid &= interviewQuestionTime <= 5; break;
            case "E": isValid &= interviewQuestionTime <= 10; break;
            case "M": isValid &= interviewQuestionTime <= 15; break;
            case "H": isValid &= interviewQuestionTime <= 20; break;
        }
    }
    isValid &= tot <= 120;

    return isValid ? "qualified" : "disqualified";
}