using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test.Parse;

[TestFixture]
public class ParseEnumTests
{
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
				.Do(v => { }, err=> Assert.Fail(err.ErrorText))
				.Match(v => v,
					_ => (TestEnum)0)
			;
	}
	
	[TestCase("xx1")]
	[TestCase("ABC")]
	[TestCase("")]
	[TestCase(null)]
	public void ParseEnum_Error(string input)
	{
		var parsed = input.TryParseEnum<TestEnum>(true);
		parsed
				.Do(v =>
				{
					Assert.Fail();
				}, _=>Assert.Pass())
			;
	}
}