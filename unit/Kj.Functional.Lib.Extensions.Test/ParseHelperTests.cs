using System;
using System.Linq;
using FluentAssertions;
using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;


namespace Kj.Functional.Lib.Extensions.Test;

[TestFixture]
public class ParseHelperTests
{
	[TestCase("1")]
	[TestCase("223342")]
	[TestCase("-1")]
	public void Parse_Int_Success(string input)
	{
		input.TryParseInt().Match(r => true, () => false).Should().Be(true);
	}
	
	[TestCase("")]
	[TestCase("  ")]
	[TestCase("some other string")]
	[TestCase("x1231")]
	public void Parse_Int_Fails(string input)
	{
		input.TryParseInt().Match(r => true, () => false).Should().Be(false);
	}

	public enum TestEnum
	{
		One=1,
		Two,
		Three
	}
	
	[TestCase("One", ExpectedResult = TestEnum.One)]
	[TestCase("two", ExpectedResult = TestEnum.Two)]
	[TestCase("tHREE", ExpectedResult = TestEnum.Three)]
	public TestEnum ParseEnum_Success(string input)
	{
		var parsed = input.TryParseEnum<TestEnum>(true);
		return parsed
				.Do(v => { }, Assert.Fail)
				.Match(v => v,
					() => (TestEnum)0)
			;
	}
}