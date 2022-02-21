using System;
using FluentAssertions;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test;

[TestFixture]
public class ParseIntTests
{
	[TestCase("1")]
	[TestCase("223342")]
	[TestCase("-1")]
	public void Parse_Int_Success(string input)
	{
		input.TryParseInt().HasValue.Should().BeTrue();
	}
	
	[TestCase("1")]
	[TestCase("223342")]
	[TestCase("-1")]
	public void Parse_Int_Span_Success(string input)
	{
		input.AsSpan().TryParseInt().HasValue.Should().BeTrue();
	}
	
	[TestCase("")]
	[TestCase("  ")]
	[TestCase("some other string")]
	[TestCase("x1231")]
	public void Parse_Int_Fails(string input)
	{
		input.TryParseInt().HasValue.Should().BeFalse();
	}

	[TestCase("1", ExpectedResult = 1)]
	[TestCase("    1", ExpectedResult = 1)]
	[TestCase("123456", ExpectedResult = 123456)]
	[TestCase("-123", ExpectedResult = -123)]
	public int Parse_Int_Value(string input)
	{
		return input.TryParseInt().Match(i => i, () =>
		{
			Assert.Fail("Parse failed");
			throw new Exception("unreachable");
		});
	}
}