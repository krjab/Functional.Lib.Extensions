using Kj.Functional.Lib.Core;

namespace Kj.Functional.Lib.Extensions.Test;

internal static class TestHelpers
{
	public static bool HasSuccessValue<T, E>(this Either<T, E> either)
	{
		return either
			.Match(_ => true,
				_ => false);
	}
}