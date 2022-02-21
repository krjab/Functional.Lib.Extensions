using System;
using FluentAssertions;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test;

[TestFixture]
public class ParseDecimalTests
{
	[TestCase("1")]
	[TestCase("223342")]
	[TestCase("-1")]
	[TestCase("1.2345")]
	[TestCase("  0.345566")]
	[TestCase("0.123")]
	[TestCase("-0.123")]
	[TestCase("-6.783")]
	public void Parse_Dec_Success(string input)
	{
		input.TryParseDecimal().HasValue.Should().BeTrue();
	}
	
	[TestCase("")]
	[TestCase("  ")]
	[TestCase("some other string")]
	[TestCase("x1231")]
	public void Parse_Dec_Fails(string input)
	{
		input.TryParseDecimal().HasValue.Should().BeFalse();
	}

	[TestCase("1", ExpectedResult = 1)]
	[TestCase("   4.12", ExpectedResult = 4.12)]
	[TestCase("123456", ExpectedResult = 123456)]
	[TestCase("-123", ExpectedResult = -123)]
	[TestCase("0.1234", ExpectedResult = 0.1234)]
	public decimal Parse_Dec_Value(string input)
	{
		return input.TryParseDecimal().Match(i => i, () =>
		{
			Assert.Fail("Parse failed");
			throw new Exception("unreachable");
		});
	}
	
}