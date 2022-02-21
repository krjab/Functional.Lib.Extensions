using System.Diagnostics.Contracts;
using System.Globalization;
using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseHelperExtensions
{
	/// <summary>
	/// Tries to parse a string to integer (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional int</returns>
	[Pure]
	public static Option<int> TryParseInt(this string input)
	{
		return input.AsSpan().TryParseInt();
	}
	
	/// <summary>
	/// Tries to parse a character span to integer (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional int</returns>
	[Pure]
	public static Option<int> TryParseInt(this ReadOnlySpan<char> input)
	{
		if (Int32.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out int res))
		{
			return res;
		}

		return Of.None;
	}
	
	
	/// <summary>
	/// Tries to parse a string to boolean (invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional boolean</returns>
	[Pure]
	public static Option<bool> TryParseBool(this string input)
	{
		return input.AsSpan().TryParseBool();
	}
	
	/// <summary>
	/// Tries to parse a character span to boolean (invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional boolean</returns>
	[Pure]
	public static Option<bool> TryParseBool(this ReadOnlySpan<char> input)
	{
		if (Boolean.TryParse(input, out bool res))
		{
			return res;
		}
		
		return Of.None;
	}

	/// <summary>
	/// Tries to parse a string to decimal (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional decimal</returns>
	[Pure]
	public static Option<decimal> TryParseDecimal(this string input)
	{
		return input.AsSpan().TryParseDecimal();
	}
	
	/// <summary>
	/// Tries to parse a character span to decimal (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional decimal</returns>
	[Pure]
	public static Option<decimal> TryParseDecimal(this ReadOnlySpan<char> input)
	{
		if (Decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal res))
		{
			return res;
		}

		return Of.None;
	}

	/// <summary>
	/// Tries to parse a string to double (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional double</returns>
	[Pure]
	public static Option<double> TryParseDouble(this string input)
	{
		return input.AsSpan().TryParseDouble();
	}
	
	/// <summary>
	/// Tries to parse a character span to double (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional double</returns>
	[Pure]
	public static Option<double> TryParseDouble(this ReadOnlySpan<char> input)
	{
		if (Double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double res))
		{
			return res;
		}

		return Of.None;
	}
	
	/// <summary>
	/// Tries to parse a string to specified enum.
	/// </summary>
	/// <param name="input">input string</param>
	/// <param name="ignoreCase">case sensitivity</param>
	/// <returns>optional enum</returns>
	[Pure]
	public static Option<T> TryParseEnum<T>(this string input, bool ignoreCase) where T:struct
	{
		if (Enum.TryParse(input, ignoreCase, out T val))
		{
			return val;
		}

		return Of.None;
	}
}