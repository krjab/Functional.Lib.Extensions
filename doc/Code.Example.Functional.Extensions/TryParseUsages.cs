using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Parse;
using Option;

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

	public record UserInfo(string UserName, int YearOfBirth, double NumberOfPoints);

	private static Option<string> TryParseName(this string input)
	{
		if (input.Length > 5)
		{
			return input;
		}

		return Of.None;
	}
	
	public static Option<UserInfo> TryParseUserFromStrings(string inputName, string birthYear, string numberPoints)
	{
		return _createUserFunc(
			inputName.TryParseName(), 
			birthYear.TryParseInt(), 
			numberPoints.TryParseDouble()
			);
	}
	
	// Optional values are "passed further" in the chained call to finally create an object from all "extracted values" (if present)
	// Any value being empty breaks the chain, leading to a None value being returned instead of the parsed object
	private static readonly Func<Option<string>, Option<int>, Option<double>, Option<UserInfo>> _createUserFunc =
		(optUserName, optYearOfBirth, optUserPoints) =>
			optUserName.Bind(name => optYearOfBirth.Bind(year => optUserPoints.Map(
						p => new UserInfo(name, year, p)
					)
			));

}