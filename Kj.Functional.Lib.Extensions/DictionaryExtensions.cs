using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions;

public static class DictionaryExtensions
{
	/// <summary>
	/// Tries to lookup entry wih the specified key in the <paramref name="input"/> dictionary.
	/// </summary>
	/// <param name="input">dictionary to use</param>
	/// <param name="key">key to find</param>
	/// <typeparam name="TK">key type</typeparam>
	/// <typeparam name="TV">value type</typeparam>
	/// <returns>optional value (if found)</returns>
	[Pure]
	public static Option<TV> LookUp<TK, TV>(this IDictionary<TK, TV> input, TK key)
	{
		return input.TryGetValue(key, out TV? val) ? val : Of.None;
	}
	
	/// <summary>
	/// Tries to lookup entry wih the specified key in the <paramref name="input"/> name-value collection.
	/// </summary>
	/// <param name="input">name-value collection to use</param>
	/// <param name="key">key to find</param>
	/// <returns>optional value (if found)</returns>
	[Pure]
	public static Option<string> LookUp(this NameValueCollection input, string key)
	{
		var val = input.Get(key);
		return val == null ? Of.None : val;
	}
}