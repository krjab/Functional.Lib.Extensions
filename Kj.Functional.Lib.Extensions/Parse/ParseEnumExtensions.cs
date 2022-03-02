using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseEnumExtensions
{
	/// <summary>
	/// Tries to parse a string to specified enum.
	/// </summary>
	/// <param name="input">input string</param>
	/// <param name="ignoreCase">case sensitivity</param>
	/// <returns>optional enum</returns>
	[Pure]
	public static Either<T, ParseErrorInfo> TryParseEnum<T>(this string input, bool ignoreCase) where T:struct
	{
		if (Enum.TryParse(input, ignoreCase, out T val))
		{
			return val;
		}

		return _parseError;
	}		
	
	private static readonly ParseErrorInfo _parseError = ParseErrorInfo.FromText("Parse error");
}