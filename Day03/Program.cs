using Helpers;
using System.Text.RegularExpressions;

var results = 0L;

string testInput =
	"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

var input = Input.GetInputFromFileAsString(@"C:\Dev\AdventOfCode2024\Day03\Program.txt", testInput);

string pattern = @"((mul)\((\d+),(\d+)\))";

var matches = Regex.Matches(input, pattern);

foreach (Match match in matches)
{
	long a = long.Parse(match.Groups[3].Value);
	long b = long.Parse(match.Groups[4].Value);

	results += a * b;
}

Console.WriteLine($"The results of the multiplications are {results}");

// Part 2

results = 0L;

pattern = @"((don't\(\)|do\(\))|(mul)\((\d+),(\d+)\))";

matches = Regex.Matches(input, pattern);

bool enabled = true;

foreach (Match match in matches)
{
	if (match.Value.Equals("don't()"))
	{
		enabled = false;
		continue;
	}
	else if (match.Value.Equals("do()"))
	{
		enabled = true;
		continue;
	}

	if (enabled)
	{
		long a = long.Parse(match.Groups[4].Value);
		long b = long.Parse(match.Groups[5].Value);

		results += a * b;
	}
}

Console.WriteLine($"The results of the multiplications are {results}");

Console.ReadLine();