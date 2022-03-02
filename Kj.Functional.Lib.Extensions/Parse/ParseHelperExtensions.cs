using System.Diagnostics.Contracts;
using System.Globalization;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;

namespace Kj.Functional.Lib.Extensions.Parse;

internal static class ParseHelperExtensions
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
	private static Either<decimal, ParseErrorInfo> TryParseDecimal(this ReadOnlySpan<char> input)
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
	private static Either<double, ParseErrorInfo> TryParseDouble(this ReadOnlySpan<char> input)
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
	
	[Pure]
	internal static Either<long, ParseErrorInfo> TryParseLong(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (Int64.TryParse(input, NumberStyles.Any, cultureInfo, out long res))
		{
			return res;
		}

		return _parseError;
	}

	[Pure]
	internal static Either<byte, ParseErrorInfo> TryParseByte(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (Byte.TryParse(input, NumberStyles.Any, cultureInfo, out byte res))
		{
			return res;
		}

		return _parseError;
	}	
	
	[Pure]
	internal static Either<uint, ParseErrorInfo> TryParseUint(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (UInt32.TryParse(input, NumberStyles.Any, cultureInfo, out uint res))
		{
			return res;
		}

		return _parseError;
	}	
	
	[Pure]
	internal static Either<ushort, ParseErrorInfo> TryParseUshort(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
	{
		if (UInt16.TryParse(input, NumberStyles.Any, cultureInfo, out ushort res))
		{
			return res;
		}

		return _parseError;
	}
}