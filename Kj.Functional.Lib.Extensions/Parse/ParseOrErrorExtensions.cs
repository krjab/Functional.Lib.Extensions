using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseOrErrorExtensions
{
	[Pure]
	public static Either<TValue, TError> TryParseOrError<TValue, TError>(this string input,
		Func<TError> errorFunc)
	{
		// if (typeof(TValue) == typeof(int))
		// {
		// 	return input.TryParseInt()
		// 		
		// 		.Match(v => v, ()=>errorFunc());
		// }
		
		

		throw new NotImplementedException();
	}
}