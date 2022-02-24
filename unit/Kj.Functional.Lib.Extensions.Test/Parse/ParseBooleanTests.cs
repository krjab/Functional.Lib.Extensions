using System;
using FluentAssertions;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test.Parse;

[TestFixture]
public class ParseBooleanTests
{
	[TestCase("true")]
	[TestCase("TRUE")]
	[TestCase("false")]
	public void Parse_Bool_Success(string input)
	{
		input.TryParseBool().HasValue.Should().BeTrue();
	}
	
	[TestCase("")]
	[TestCase("  ")]
	[TestCase("0")]
	[TestCase("TR")]
	[TestCase("FA")]
	public void Parse_Bool_Fails(string input)
	{
		input.TryParseBool().HasValue.Should().BeFalse();
	}	
	
	[TestCase("true", ExpectedResult = true)]
	[TestCase("false", ExpectedResult = false)]
	[TestCase("TRUE", ExpectedResult = true)]
	public bool Parse_Bool_Value(string input)
	{
		return input.TryParseBool().Match(b => b, () =>
		{
			Assert.Fail("Parse failed");
			throw new Exception("unreachable");
		});
	}
}