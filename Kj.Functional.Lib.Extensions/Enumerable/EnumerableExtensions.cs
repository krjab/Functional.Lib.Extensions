using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions.Enumerable;

public static class EnumerableExtensions
{
	[Pure]
	public static Option<T> TryFirst<T>(this IEnumerable<T> enumerable)
	{
		var firstOrNull = enumerable.FirstOrDefault();
		return firstOrNull==null? Of.None:firstOrNull;
	}

	[Pure]
	public static Option<T> TryFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
	{
		var filtered = enumerable.FirstOrDefault(predicate);
		return filtered == null ? Of.None: filtered;
	}
	
}