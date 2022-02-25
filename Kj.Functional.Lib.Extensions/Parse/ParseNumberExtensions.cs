using System.Diagnostics.Contracts;
using System.Globalization;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseNumberExtensions
{
	[Pure]
	public static Either<TValue, ParseErrorInfo> TryParseNumber<TValue>(this string input) where TValue:struct
	{
		return input.AsSpan().TryParseNumber<TValue>(CultureInfo.InvariantCulture);
	}
	
	[Pure]
	public static Either<TValue, ParseErrorInfo> TryParseNumber<TValue>(this string input, CultureInfo cultureInfo) where TValue:struct
	{
		return input.AsSpan().TryParseNumber<TValue>(cultureInfo);
	}

	[Pure]
	public static Either<TValue, ParseErrorInfo> TryParseNumber<TValue>(this ReadOnlySpan<char> input)
		where TValue : struct
	{
		return input.TryParseNumber<TValue>(CultureInfo.InvariantCulture);
	}

	private static readonly ParseErrorInfo _parseError = ParseErrorInfo.FromText("Parse error");
	private static readonly ParseErrorInfo _parseNotDefinedError = ParseErrorInfo.FromText("Parsing not defined");
	
	[Pure]
	private static Either<TValue, ParseErrorInfo> TryParseNumber<TValue>(this ReadOnlySpan<char> input, CultureInfo cultureInfo)
				where TValue:struct
	{
		var convertedType = typeof(TValue);
		
		if (convertedType == typeof(int))
		{
			return input.TryParseInt(cultureInfo).MapToTValue<TValue, int>();
		}
		
		if (convertedType == typeof(decimal))
		{
			return input.TryParseDecimal(cultureInfo).MapToTValue<TValue, decimal>();
		}
		
		if (convertedType == typeof(double))
		{
			return input.TryParseDouble(cultureInfo).MapToTValue<TValue, double>();
		}
		
		if (convertedType == typeof(short))
		{
			return input.TryParseShort(cultureInfo).MapToTValue<TValue, short>();
		}
		
		if (convertedType == typeof(long))
		{
			return input.TryParseLong(cultureInfo).MapToTValue<TValue, long>();
		}
		
		if (convertedType == typeof(byte))
		{
			return input.TryParseByte(cultureInfo).MapToTValue<TValue, byte>();
		}
		
		if (convertedType == typeof(uint))
		{
			return input.TryParseUint(cultureInfo).MapToTValue<TValue, uint>();
		}
		
		if (convertedType == typeof(ushort))
		{
			return input.TryParseUshort(cultureInfo).MapToTValue<TValue, ushort>();
		}
		
		return _parseNotDefinedError;
	}
	
	private static Either<TValue, ParseErrorInfo> MapToTValue<TValue, TParse>(this Either<TParse, ParseErrorInfo> inputEither)
		where TValue: struct
	{
		return inputEither.MapLeft(v=>Convert<TValue>(v!));
	}

	private static TValue Convert<TValue>(this object input) where TValue: struct
	{
		return (TValue)input;
	} 
	
}