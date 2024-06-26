﻿//Problem Description
//The N-Queens problem is a classic puzzle in which you are to place N queens on an N×N chessboard so that no two queens threaten each other. This means that no two queens can share the same row, column, or diagonal.

//Task
//Write a program that finds one valid configuration for placing N queens on an N×N chessboard.

//Requirements
//Input:

//An integer N, representing the size of the chessboard and the number of queens to place (e.g., 8 for an 8x8 board).
//Output:

//A 2D array (or a similar structure) representing the chessboard with queens placed in valid positions. You can use 'Q' for a queen and '.' for an empty space.
//Constraints
//Each queen must be placed such that no two queens can attack each other.
//The solution must handle any size of N (e.g., 4, 8, 10).

// Exercise generated by ChatGPT 

//// Code
//// Variables
//var queens = 3;
//var chessboardDimensions = new bool[3, 3];

//// Constraints
//var hasQueenInSameRow = (int row, int column, bool[,] field) =>
//{
//	var selectedSquare = field[row, column];
//	for (int i = 0; i < field.GetLength(1); i++)
//	{

//		var nextColumn = field[row, i];

//		if (selectedSquare != nextColumn) continue;

//		// IF HAS QUEEN IN NEXT COLUMN
//		if (nextColumn == true) 
//			return true;
//	}

//	return false;
//};

//// Solver

//for (int i = 0; i < chessboardDimensions.GetLength(0); i++)
//{
//	for (int j = 0; j < chessboardDimensions.GetLength(1); j++)
//	{
//		if (!hasQueenInSameRow(i, j, chessboardDimensions))
//		{
//			chessboardDimensions[i, j] = true;
//		}
//	}
//}

//for (int i = 0; i < chessboardDimensions.GetLength(0); i++)
//{
//	for (int j = 0; j < chessboardDimensions.GetLength(1); j++)
//	{
//        Console.Write(chessboardDimensions[i, j] ? 1 : 0);
//    }
//    Console.WriteLine();
//}



// Variables
var queens = 3;
var chessboardDimensions = new bool[3, 3];

// Constraints
var hasQueenInSameRow = (int row, bool[,] field) =>
{
	for (int i = 0; i < field.GetLength(1); i++)
	{
		if (field[row, i]) return true;
	}
	return false;
};

var hasQueenInSameColumn = (int column, bool[,] field) =>
{
	for (int i = 0; i < field.GetLength(0); i++)
	{
		if (field[i, column]) return true;
	}
	return false;
};

var hasQueenInSameDiagonals = (int row, int column, bool[,] field) =>
{
	// Check \ diagonal
	for (int i = 0; i < field.GetLength(0); i++)
	{
		for (int j = 0; j < field.GetLength(1); j++)
		{
			if (i + j == row + column && field[i, j]) return true;
			if (i - j == row - column && field[i, j]) return true;
		}
	}
	return false;
};

// Solver
for (int i = 0; i < chessboardDimensions.GetLength(0); i++)
{
	for (int j = 0; j < chessboardDimensions.GetLength(1); j++)
	{
		if (!hasQueenInSameRow(i, chessboardDimensions) &&
			!hasQueenInSameColumn(j, chessboardDimensions) &&
			!hasQueenInSameDiagonals(i, j, chessboardDimensions) &&
			queens > 0)
		{
			chessboardDimensions[i, j] = true;
			queens--;
		}
	}
}

// Output
for (int i = 0; i < chessboardDimensions.GetLength(0); i++)
{
	for (int j = 0; j < chessboardDimensions.GetLength(1); j++)
	{
		Console.Write(chessboardDimensions[i, j] ? 1 : 0);
	}
	Console.WriteLine();
}