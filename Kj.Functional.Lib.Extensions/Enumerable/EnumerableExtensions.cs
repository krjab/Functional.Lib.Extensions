using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions.Enumerable;

public static class EnumerableExtensions
{
	/// <summary>
	/// Tries to get first element of the collection.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns>Some with value or none</returns>
	[Pure]
	public static Option<T> TryFirst<T>(this IEnumerable<T> enumerable)
	{
		var firstOrNull = enumerable.FirstOrDefault();
		return firstOrNull==null? Of.None:firstOrNull;
	}

	/// <summary>
	/// Tries to get first element of the collection satisfying the specified predicate.
	/// </summary>
	/// <param name="enumerable"></param>
	/// <param name="predicate"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns>Some with value or none</returns>
	[Pure]
	public static Option<T> TryFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
	{
		var filtered = enumerable.FirstOrDefault(predicate);
		return filtered == null ? Of.None: filtered;
	}
	
}