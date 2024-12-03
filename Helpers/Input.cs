﻿namespace Helpers
{
	public static class Input
	{
		public static string[] ReadInputFromFile(string path, string testInput)
		{
			if (File.Exists(path))
			{
				return File.ReadAllLines(path);
			}

			var lines = testInput.Split(System.Environment.NewLine);
			return lines;
		}

		public static string GetInputFromFileAsString(string path, string testInput)
		{
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
			}

			return testInput;
		}
	}
}
