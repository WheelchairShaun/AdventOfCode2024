using Helpers;

string testInput =
	"""
	47|53
	97|13
	97|61
	97|47
	75|29
	61|13
	75|53
	29|13
	97|29
	53|29
	61|53
	97|53
	61|29
	47|13
	75|47
	97|75
	47|61
	75|61
	47|29
	75|13
	53|13

	75,47,61,53,29
	97,61,53,29,13
	75,29,13
	75,97,47,61,53
	61,13,29
	97,13,75,29,47
	""";

var rules = new Dictionary<int, List<int>>();
var pages = new List<int[]>();

var input = Input.GetInputFromFileAsString(@"C:\Dev\AdventOfCode2024\Day05\Pages.txt", testInput);

var sections = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

var section = sections[0].Split(Environment.NewLine);

foreach (string line in section)
{
	var r = line.Split('|').Select(x => int.Parse(x)).ToArray();

	if (rules.ContainsKey(r[0]))
	{
		rules[r[0]].Add(r[1]);
	}
	else
	{
		rules.Add(r[0], new List<int>());
		rules[r[0]].Add(r[1]);
	}
}

section = sections[1].Split(Environment.NewLine);

foreach (string line in section)
{
	pages.Add(line.Split(',').Select(p => int.Parse(p)).ToArray());
}

var updates = new List<int[]>();

foreach (var p in pages)
{
	if (IsRightOrder(p))
	{
		updates.Add(p);
	}
}

var middle = 0L;
updates.ForEach(u =>
{
	var m = u.Length / 2;
	middle += u[m];
});

Console.WriteLine($"The sum of the middle page number from those correctly-ordered updates is {middle}");

Console.ReadLine();

bool IsRightOrder(int[] pages)
{
	for (int i = 0; i < pages.Length; i++)
	{
		// If this page does not have a rule, go to next page
		if (rules.ContainsKey(pages[i]) == false)
		{
			continue;
		}

		// Get the rules for this page
		var r = rules[pages[i]];

		foreach (var p in r)
		{
			var loc = Array.FindIndex(pages, x => x == p);

			// Page not in update, next rule
			if (loc == -1)
			{
				continue;
			}

			// If rule is before current page, not in order
			if (loc < i)
			{
				return false;
			}


		}
	}
	return true;
}
