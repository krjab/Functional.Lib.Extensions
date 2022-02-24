using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Models.Validation;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseNumberExtensions
{

	[Pure]
	public static Either<TValue, ParseErrorInfo> TryParseNumber<TValue>(this string input) where TValue:struct
	{
		return input.AsSpan().TryParseNumber<TValue>();
	}

	// private static readonly IReadOnlyDictionary<Type, Func<string, Option<ValueType>>> _parseMethodMap =
	// 	new Dictionary<Type, Func<string, Option<ValueType>>>
	// 	{
	// 		{ typeof(int), s => s.TryParseInt() },
	// 		{ typeof(decimal), s => s.TryParseDecimal() },
	// 	};
	//
	private static readonly ParseErrorInfo _parseError = ParseErrorInfo.FromText("Parse error");
	private static readonly ParseErrorInfo _parseNotDefinedError = ParseErrorInfo.FromText("Parsing not defined");
	
	[Pure]
	public static Either<TValue, ParseErrorInfo> TryParseNumber<TValue>(this ReadOnlySpan<char> input)
	 where TValue:struct
	{
		Option<ValueType> optionalVal;
		var convertedType = typeof(TValue);
		if (convertedType == typeof(int))
		{
			return ParseInteger<TValue>(input);
		}else if (convertedType == typeof(decimal))
		{
			optionalVal = input.TryParseDecimal();
		}
		else
		{
			return _parseNotDefinedError;
		}
		
		//
		// var parseFunc = _parseMethodMap.LookUp(convertedType);
		//
		// return parseFunc
		// 	.Map(f=>Convert<TValue>(f(input)))
		// 	.ToEither(() => _parseError);
		return optionalVal
			.Map(Convert<TValue>)
			.ToEither(() => _parseError);
	}

	private static Either<TValue, ParseErrorInfo> ParseInteger<TValue>(ReadOnlySpan<char> input) where TValue:struct
	{
		return input.TryParseInt()
			.ToEither(() => _parseError)
			.MapLeft(v=>Convert<TValue>(v));
	}

	private static TValue Convert<TValue>(this object input) where TValue: struct
	{
		return (TValue)input;
	} 
	
}