namespace Day02
{
	public class Report
	{
		public int[] levels;
		private int[] changes;

		public Report(int[] levels)
		{
			this.levels = levels;
			changes = new int[levels.Length - 1];

			for (int i = 1; i < levels.Length; i++)
			{
				changes[i - 1] = levels[i - 1] - levels[i];
			}
		}

		public bool IsSafe()
		{
			return (changes.All(x => (x > 0)) || changes.All(x => x < 0))
				&& changes.All(x => int.Abs(x) >= 1 && int.Abs(x) <= 3);
		}

		public bool IsSafeWithProblemDampener()
		{
			int problems = 0;

			for (int skip = 0; skip < levels.Length; skip++)
			{
				var s = skip + 1;
				var test = levels[0..skip].Concat(levels[s..^0]).ToArray();
				var c = new int[test.Length - 1];

				for (int i = 1; i < test.Length; i++)
				{
					c[i - 1] = test[i - 1] - test[i];
				}

				if (((c.All(x => (x > 0)) || c.All(x => x < 0)
				&& c.All(x => int.Abs(x) >= 1 && int.Abs(x) <= 3))) == false)
				{
					problems++;
				}

			}

			if (problems > 1)
			{
				return false;
			}

			return true;
		}
	}
}
