using System;
using System.Reflection;
using FluentAssertions;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test.Parse;

[TestFixture]
public class ParseIntTests
{
	[TestCase("1")]
	[TestCase("223342")]
	[TestCase("-1")]
	public void Parse_Int_Success(string input)
	{
		input.TryParseNumber<int>()
			.HasSuccessValue().Should().BeTrue();
	}
	
	[TestCase("1")]
	[TestCase("223342")]
	[TestCase("-1")]
	public void Parse_Int_Span_Success(string input)
	{
		input.AsSpan().TryParseNumber<int>()
			.HasSuccessValue().Should().BeTrue();
	}
	
	[TestCase("")]
	[TestCase("  ")]
	[TestCase("some other string")]
	[TestCase("x1231")]
	public void Parse_Int_Fails(string input)
	{
		input.TryParseNumber<int>()
			.HasSuccessValue().Should().BeFalse();
	}

	[TestCase("1", ExpectedResult = 1)]
	[TestCase("    1", ExpectedResult = 1)]
	[TestCase("123456", ExpectedResult = 123456)]
	[TestCase("-123", ExpectedResult = -123)]
	public int Parse_Int_Value(string input)
	{
		return input.TryParseNumber<int>().Match(i => i, err =>
		{
			Assert.Fail($"Parse failed: {err.ErrorText}");
			throw new Exception("unreachable");
		});
	}

	// [TestCase("")]
	// [TestCase(null)]
	// [TestCase("abc")]
	// public void Parse_Int_Error(string input)
	// {
	// 	const string errorResult = "invalid" ;
	// 	input.TryParseOrError<int, string>(() => errorResult)
	// 		.Do(i => Assert.Fail(),
	// 			s => s.Should().Be(errorResult));
	// }
}