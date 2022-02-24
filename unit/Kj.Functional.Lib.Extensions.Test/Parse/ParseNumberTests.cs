using System;
using FluentAssertions;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test.Parse;

[TestFixture]
public class ParseNumberTests
{
	[Test]
	public void ParseNumberOfType()
	{
		const string simpleNumberString = "1";
		simpleNumberString.TryParseNumber<int>().HasSuccessValue().Should().BeTrue();
		simpleNumberString.TryParseNumber<decimal>().HasSuccessValue().Should().BeTrue();
		simpleNumberString.TryParseNumber<double>().HasSuccessValue().Should().BeTrue();
		simpleNumberString.TryParseNumber<short>().HasSuccessValue().Should().BeTrue();
		simpleNumberString.TryParseNumber<ushort>().HasSuccessValue().Should().BeTrue();
		simpleNumberString.TryParseNumber<byte>().HasSuccessValue().Should().BeTrue();
		simpleNumberString.TryParseNumber<uint>().HasSuccessValue().Should().BeTrue();
	}
}