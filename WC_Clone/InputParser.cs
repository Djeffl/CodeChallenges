namespace WC_Clone;

public class InputParser
{
	public static Dictionary<string, string> ParseArguments(string[] args)
	{
		return args
			.Select((arg, index) => new { Arg = arg, Index = index })
			.Where(x => x.Arg.StartsWith("-"))
			.ToDictionary(
				x => x.Arg,
				x => x.Index + 1 < args.Length && !args[x.Index + 1].StartsWith("-") ? args[x.Index + 1] : string.Empty
			);
	}

	public static string ParseValue(string[] args)
	{
		var val = args
			.Select((arg, index) => new { Arg = arg, Index = index })
			.LastOrDefault();

		if(val.Index == 0) return val.Arg;

		if (args[val.Index - 1].StartsWith("-"))
		{
			throw new InvalidOperationException();
		}

		return val.Arg;
	}
}
