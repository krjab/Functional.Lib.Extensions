using System.Diagnostics.Contracts;
using System.Globalization;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseHelperExtensions
{

	/// <summary>
	/// Tries to parse a string to integer (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional int</returns>
	[Pure]
	internal static Either<int, ParseErrorInfo> TryParseInt(this string input)
	{
		return input.AsSpan().TryParseInt(CultureInfo.InvariantCulture);
	}
	
	[Pure]
	internal static Either<int, ParseErrorInfo> TryParseInt(this string input, CultureInfo cultureInfo)
	{
		return input.AsSpan().TryParseInt(cultureInfo);
	}
	
	/// <summary>
	/// Tries to parse a character span to integer (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional int</returns>
	[Pure]
	internal static Either<int, ParseErrorInfo> TryParseInt(this ReadOnlySpan<char> input)
	{
		return input.TryParseInt(CultureInfo.InvariantCulture);
	}
	
	private static readonly ParseErrorInfo _parseError = ParseErrorInfo.FromText("Parse error");
	
	[Pure]
	internal static Either<int, ParseErrorInfo> TryParseInt(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (Int32.TryParse(input, NumberStyles.Any, cultureInfo, out int res))
		{
			return res;
		}

		return _parseError;
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
	internal static Either<decimal, ParseErrorInfo> TryParseDecimal(this string input)
	{
		return input.AsSpan().TryParseDecimal();
	}

	/// <summary>
	/// Tries to parse a character span to decimal (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional decimal</returns>
	[Pure]
	internal static Either<decimal, ParseErrorInfo> TryParseDecimal(this ReadOnlySpan<char> input)
	{
		return input.TryParseDecimal(CultureInfo.InvariantCulture);
	}
	
	[Pure]
	internal static Either<decimal, ParseErrorInfo> TryParseDecimal(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (Decimal.TryParse(input, NumberStyles.Any, cultureInfo, out decimal res))
		{
			return res;
		}

		return _parseError;
	}

	/// <summary>
	/// Tries to parse a string to double (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional double</returns>
	[Pure]
	internal static Either<double, ParseErrorInfo> TryParseDouble(this string input)
	{
		return input.AsSpan().TryParseDouble();
	}
	
	/// <summary>
	/// Tries to parse a character span to double (any style, invariant culture)
	/// </summary>
	/// <param name="input">input string</param>
	/// <returns>optional double</returns>
	[Pure]
	internal static Either<double, ParseErrorInfo> TryParseDouble(this ReadOnlySpan<char> input)
	{
		return input.TryParseDouble(CultureInfo.InvariantCulture);
	}
	
	[Pure]
	internal static Either<double, ParseErrorInfo> TryParseDouble(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (Double.TryParse(input, NumberStyles.Any, cultureInfo, out double res))
		{
			return res;
		}

		return _parseError;
	}
	
	[Pure]
	internal static Either<short, ParseErrorInfo> TryParseShort(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (Int16.TryParse(input, NumberStyles.Any, cultureInfo, out short res))
		{
			return res;
		}

		return _parseError;
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