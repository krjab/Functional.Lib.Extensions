using System.Diagnostics.Contracts;
using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions.Parse;

public static class ParseHelperExtensions
{
	[Pure]
	public static Option<int> TryParseInt(this string input)
	{
		if (Int32.TryParse(input, out int res))
		{
			return res;
		}

		return Of.None;
	}

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