using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Enumerable;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseNumberExtensions
{
	//private static IReadOnlyDictionary<Type, Func<ReadOnlySpan<char>,Option<>>

	[Pure]
	public static Option<T> TryParseNumber<T>(this string input) where T:struct
	{
		return input.TryParseNumber<T>();
	}

	private static readonly IReadOnlyDictionary<Type, Func<string, Option<ValueType>>> _parseMethodMap =
		new Dictionary<Type, Func<string, Option<ValueType>>>
		{
			{ typeof(int), s => s.TryParseInt() },
			{ typeof(decimal), s => s.TryParseDecimal() },
		};
	
	[Pure]
	public static Either<TValue, string> TryParseNumber<TValue>(this ReadOnlySpan<char> input)
	 where TValue:struct
	{

		var parseFunc = _parseMethodMap.LookUp(typeof(TValue));

		return parseFunc
			.Map(Convert<TValue>)
			.ToEither(() => "Parse error");
	}

	private static TValue Convert<TValue>(this object input) where TValue: struct
	{
		return (TValue)input;
	} 
	
}