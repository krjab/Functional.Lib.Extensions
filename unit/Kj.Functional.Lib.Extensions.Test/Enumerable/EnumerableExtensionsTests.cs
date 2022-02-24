using System;
using FluentAssertions;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Enumerable;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test.Enumerable;

[TestFixture]
public class EnumerableExtensionsTests
{
	[Test]
	public void TryFirst_ReturnsNone()
	{
		var empty = Array.Empty<string>();

		empty.TryFirst()
			.Do(x => Assert.Fail(),
				Assert.Pass);
	}

	[Test]
	public void TryFirst_ReturnsSome()
	{
		const string testedString = "abc";
		var array = new[] { testedString };
		array.TryFirst()
			.Do(x => x.Should().Be(testedString),
				Assert.Fail);
	}
	
	[Test]
	public void TryFirst_WithWhere_ReturnsSome()
	{
		const string testedString = "abc";
		var array = new[] { testedString };
		array.TryFirst(x=>x==testedString)
			.Do(x => x.Should().Be(testedString),
				Assert.Fail);
	}
}