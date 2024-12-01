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
long score = 0L;

List<int> left = new List<int>();
List<int> right = new List<int>();
Dictionary<int, int> simularity = new Dictionary<int, int>();

var lines = Input.ReadInputFromFile(projectPath + "Locations.txt", testInput);

foreach (string line in lines)
{
	var locations = line.Split("  ");
	var l = int.Parse(locations[0]);
	var r = int.Parse(locations[1]);

	left.Add(l);
	right.Add(r);

	if (!simularity.ContainsKey(l))
	{
		simularity.Add(l, 0);
	}
}

left.Sort();
right.Sort();

for (int i = 0; i < left.Count; i++)
{
	distances += long.Abs(left[i] - right[i]);
}

Console.WriteLine($"The total distance between the left list and the right list is {distances}");

// Part 2

right.ForEach(x =>
{
	if (simularity.ContainsKey(x))
	{
		simularity[x]++;
	}
});

foreach (var loc in left)
{
	score += loc * simularity[loc];
}

Console.WriteLine($"Their similarity score is {score}");


Console.ReadLine();