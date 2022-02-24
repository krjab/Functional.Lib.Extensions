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
				.Do(v => { }, Assert.Fail)
				.Match(v => v,
					() => (TestEnum)0)
			;
	}
}