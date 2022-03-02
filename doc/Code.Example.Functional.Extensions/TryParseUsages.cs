using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;
using Kj.Functional.Lib.Extensions.Parse;

namespace Code.Example.Functional.Extensions;

public static class TryParseUsages
{
	public static void ParseAndValidateNumberString(string inputString)
	{
		var result = inputString.TryParseNumber<int>() // try parse value
				.AsOption()
				.Filter(v => v > 0) // filter if value > 0
				.Map(v => v * 2) // multiply valid value by 2
			;
	}
	
	public static void ParseDateValidateAndMap(string inputString)
	{
		var result = inputString.TryParseDateTime() // try parse value
			.AsOption()
			.Filter(d => d.Year > 1999) // validate if year > 1999
			.Map(d => $"valid input date of {d}") // map valid date to output string
			.Or(() => $"Invalid date") // map to another string if anything went wrong
			;
	}

	public record UserInfo(string UserName, int YearOfBirth, double NumberOfPoints);

	private static Either<string, ParseErrorInfo> TryParseName(this string input)
	{
		if (input.Length > 5)
		{
			return input;
		}

		return ParseErrorInfo.FromText("Name to short");
	}
	
	public static Option<UserInfo> TryParseUserFromStrings(string inputName, string birthYear, string numberPoints)
	{
		return _createUserFunc(
			inputName.TryParseName(), 
			birthYear.TryParseNumber<int>(), 
			numberPoints.TryParseNumber<double>()
			);
	}
	
	// Optional values are "passed further" in the chained call to finally create an object from all "extracted values" (if present)
	// Any value being empty breaks the chain, leading to a None value being returned instead of the parsed object
	private static readonly
		Func<Either<string, ParseErrorInfo>, Either<int, ParseErrorInfo>, Either<double, ParseErrorInfo>,
			Option<UserInfo>> _createUserFunc =
			(optUserName, optYearOfBirth, optUserPoints) =>
				optUserName.BindResult(name => optYearOfBirth.BindResult(year => optUserPoints.MapResult(
						p => new UserInfo(name, year, p)
					)
				)).AsOption();

}