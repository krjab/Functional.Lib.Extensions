using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Parse;

namespace Code.Example.Functional.Extensions;

public static class TryParseUsages
{
	public static void ParseAndValidateNumberString(string inputString)
	{
		var result = inputString.TryParseInt() // try parse value
				.Filter(v => v > 0) // filter if value > 0
				.Map(v => v * 2) // multiply valid value by 2
			;
	}
	
	public static void ParseDateValidateAndMap(string inputString)
	{
		var result = inputString.TryParseDateTime() // try parse value
			.Filter(d => d.Year > 1999) // validate if year > 1999
			.Map(d => $"valid input date of {d}") // map valid date to output string
			.Or(() => $"Invalid date") // map to another string if anything went wrong
			;
	}
}