using Helpers;

string projectPath = @"C:\Dev\AdventOfCode2024\Day01\";

string testInput =
	"""
	3   4
	4   3
	2   5
	1   3
	3   9
	3   3
	""";

long distances = 0L;

List<int> left = new List<int>();
List<int> right = new List<int>();

var lines = Input.ReadInputFromFile(projectPath + "Locations.txt", testInput);

foreach (string line in lines)
{
	var locations = line.Split("  ");
	left.Add(int.Parse(locations[0]));
	right.Add(int.Parse(locations[1]));
}

left.Sort();
right.Sort();

for (int i = 0; i < left.Count; i++)
{
	distances += long.Abs(left[i] - right[i]);
}

Console.WriteLine($"The total distance between the left list and the right list is {distances}");

Console.ReadLine();