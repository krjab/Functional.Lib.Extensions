using System.Diagnostics.Contracts;
using System.Globalization;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseDateExtensions
{
	/// <summary>
	/// Tries to parse a string to datetime (no style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>result or <see cref="ParseErrorInfo"/></returns>
	[Pure]
	public static Either<DateTime, ParseErrorInfo> TryParseDateTime(this string input)
	{
		return input.AsSpan().TryParseDateTime();
	}

	/// <summary>
	/// Tries to parse a string to datetime (no style) for the specified culture
	/// </summary>
	/// <param name="input">input string</param>
	/// <param name="culture">CultureInfo</param>
	/// <returns>result or <see cref="ParseErrorInfo"/></returns>
	[Pure]
	public static Either<DateTime, ParseErrorInfo> TryParseDateTime(this string input, CultureInfo culture)
	{
		return input.AsSpan().TryParseDateTime(culture);
	}
	
	/// <summary>
	/// Tries to parse a character span to datetime (no style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>result or <see cref="ParseErrorInfo"/></returns>
	[Pure]
	public static Either<DateTime, ParseErrorInfo> TryParseDateTime(this ReadOnlySpan<char> input)
	{
		return input.TryParseDateTime(CultureInfo.InvariantCulture);
	}
	
	private static readonly ParseErrorInfo _parseError = ParseErrorInfo.FromText("Parse error");
	
	/// <summary>
	/// Tries to parse a character span to datetime (no style, specified culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <param name="culture">CultureInfo</param>
	/// <returns>result or <see cref="ParseErrorInfo"/></returns>
	[Pure]
	public static Either<DateTime, ParseErrorInfo> TryParseDateTime(this ReadOnlySpan<char> input, CultureInfo culture)
	{
		if (DateTime.TryParse(input, culture, DateTimeStyles.None, out var res))
		{
			return res;
		}

		return _parseError;
	}
}