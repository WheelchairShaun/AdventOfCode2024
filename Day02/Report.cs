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

		public bool isSafe()
		{
			return changes.All(x => (x > 0) || changes.All(x => x < 0))
				&& changes.All(x => int.Abs(x) >= 1 && int.Abs(x) <= 3);
		}
	}
}
