using Helpers;
using System.Text.RegularExpressions;

var results = 0L;

string testInput =
	"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

var input = Input.GetInputFromFileAsString(@"C:\Dev\AdventOfCode2024\Day03\Program1.txt", testInput);

string pattern = "((mul)\\((\\d+),(\\d+)\\))";

var matches = Regex.Matches(input, pattern);

foreach (Match match in matches)
{
	long a = long.Parse(match.Groups[3].Value);
	long b = long.Parse(match.Groups[4].Value);

	results += a * b;
}

Console.WriteLine($"The results of the multiplications are {results}");

Console.ReadLine();