using System.Diagnostics.Contracts;
using System.Globalization;
using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseDateExtensions
{
	/// <summary>
	/// Tries to parse a string to datetime (no style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional datetime</returns>
	[Pure]
	public static Option<DateTime> TryParseDateTime(this string input)
	{
		return input.AsSpan().TryParseDateTime();
	}

	/// <summary>
	/// Tries to parse a string to datetime (no style) for the specified culture
	/// </summary>
	/// <param name="input">input string</param>
	/// <param name="culture">CultureInfo</param>
	/// <returns>optional datetime</returns>
	[Pure]
	public static Option<DateTime> TryParseDateTime(this string input, CultureInfo culture)
	{
		return input.AsSpan().TryParseDateTime(culture);
	}
	
	/// <summary>
	/// Tries to parse a character span to datetime (no style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional datetime</returns>
	[Pure]
	public static Option<DateTime> TryParseDateTime(this ReadOnlySpan<char> input)
	{
		return input.TryParseDateTime(CultureInfo.InvariantCulture);
	}
	
	[Pure]
	public static Option<DateTime> TryParseDateTime(this ReadOnlySpan<char> input, CultureInfo culture)
	{
		if (DateTime.TryParse(input, culture, DateTimeStyles.None, out var res))
		{
			return res;
		}

		return Of.None;
	}
}