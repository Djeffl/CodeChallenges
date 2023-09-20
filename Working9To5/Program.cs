// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

Console.WriteLine("Hello, World!");

//Write a function that calculates overtime and pay associated with overtime.

//Working 9 to 5: regular hours
//After 5pm is overtime
//Your function gets an array with 4 values:

//Start of working day, in decimal format, (24 - hour day notation)
//End of working day. (Same format)
//Hourly rate
//Overtime multiplier
//Your function should spit out:

//$ +earned that day(rounded to the nearest hundreth)
//Examples
//OverTime([9, 17, 30, 1.5]) ➞ "$240.00"

//OverTime([16, 18, 30, 1.8]) ➞ "$84.00"

//OverTime([13.25, 15, 30, 1.5]) ➞ "$52.50"

//2nd example explained:

//From 16 to 17 is regular, so 1 * 30 = 30
//From 17 to 18 is overtime, so 1 * 30 * 1.8 = 54
//30 + 54 = $84.00

Console.WriteLine("Result: " + OverTime(new double[] { 9, 17, 30, 1.5 }));
Console.WriteLine("Expected: 240");

Console.WriteLine("Result: " + OverTime(new double[] { 16, 18, 30, 1.8 }));
Console.WriteLine("Expected: 84");

Console.WriteLine("Result: " + OverTime(new double[] { 13.25, 15, 30, 1.5 }));
Console.WriteLine("Expected: 52.50");

Console.WriteLine("Result: " + OverTime(new[] { 13, 21, 38.6, 1.8 }));
Console.WriteLine("Expected: 432.32");

Console.WriteLine(OverTime(new[] { 18, 20, 32.5, 2 }));
Console.WriteLine("Expected: 130.00");

//https://edabit.com/challenge/rkzH6YsPNgoJjn75i

static string OverTime(double[] arr)
{
    var startRegularHour = 9;
    var endRegularHour = 17;

    var startHour = arr[0];
    var endHour = arr[1];

    var hourlyRate = arr[2];
    var overTimeFactor = arr[3];

    var regularHoursStart = startHour < startRegularHour ? startRegularHour : startHour > endRegularHour ? 0 : startHour;
    var regularHoursEnd = regularHoursStart == 0 ? 0 : endHour > endRegularHour ? endRegularHour : endHour;

    var totalRegularHoursWorked = regularHoursEnd - regularHoursStart;

    var overTimeStart = startHour < startRegularHour ? startRegularHour - startHour : startHour > endRegularHour ? endRegularHour - startHour : 0;
    var overTimeEnd = endHour > endRegularHour ? endHour - endRegularHour : 0;
    var totalOverTimeHours = overTimeStart + overTimeEnd;

    var totalPayedRegularHours = hourlyRate * totalRegularHoursWorked;

    var totalPayedOverTimeHours = hourlyRate * overTimeFactor * totalOverTimeHours;

    var totalPay = totalPayedOverTimeHours + totalPayedRegularHours;

    return "$" + totalPay.ToString("0.00");

}