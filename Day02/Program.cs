﻿using Day02;
using Helpers;

string testInput =
	"""
	7 6 4 2 1
	1 2 7 8 9
	9 7 6 2 1
	1 3 2 4 5
	8 6 4 4 1
	1 3 6 7 9
	4 2 6 7 9
	""";

var reports = new List<Report>();

var lines = Input.ReadInputFromFile(@"C:\Dev\AdventOfCode2024\Day02\Reports1.txt", testInput);

foreach (var line in lines)
{
	var input = line.Split(' ').Select(int.Parse).ToArray();
	reports.Add(new Report(input));
}

var safe = reports.FindAll(r => r.IsSafe() == true);

Console.WriteLine($"{safe.Count} reports are safe.");

var damaged = reports.FindAll(r => r.IsSafe() == false);
var dampened = damaged.FindAll(r => r.IsSafeWithProblemDampener() == true);


Console.WriteLine($"{safe.Count + dampened.Count} reports are safe.");

Console.ReadLine();
