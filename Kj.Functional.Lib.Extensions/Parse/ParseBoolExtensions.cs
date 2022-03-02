using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseBoolExtensions
{
	/// <summary>
	/// Tries to parse a string to boolean (invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional boolean</returns>
	[Pure]
	public static Either<bool, ParseErrorInfo> TryParseBool(this string input)
	{
		return input.AsSpan().TryParseBool();
	}

	private static readonly ParseErrorInfo _parseError = ParseErrorInfo.FromText("Parse error");
	/// <summary>
	/// Tries to parse a character span to boolean (invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional boolean</returns>
	[Pure]
	public static Either<bool, ParseErrorInfo> TryParseBool(this ReadOnlySpan<char> input)
	{
		if (Boolean.TryParse(input, out bool res))
		{
			return res;
		}
		
		return _parseError;
	}
}