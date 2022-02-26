using System;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test.Parse;

[TestFixture]
public class ParseNumberTests
{
	private const string _SIMPLE_NUMBER_STRING = "1";
	
	[Test]
	public void ParseNumberInt()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<int>().HasSuccessValue().Should().BeTrue();
	}
	
	[Test]
	public void ParseNumberUint()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<uint>().HasSuccessValue().Should().BeTrue();
	}
	
	[Test]
	public void ParseNumberLong()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<long>().HasSuccessValue().Should().BeTrue();
	}

	[Test]
	public void ParseNumberDecimal()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<decimal>().HasSuccessValue().Should().BeTrue();
	}
	
	[Test]
	public void ParseNumberDouble()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<double>().HasSuccessValue().Should().BeTrue();
	}
	
	[Test]
	public void ParseNumberShort()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<short>().HasSuccessValue().Should().BeTrue();
	}
	
	[Test]
	public void ParseNumberUshort()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<ushort>().HasSuccessValue().Should().BeTrue();
	}
	
	[Test]
	public void ParseNumberByte()
	{
		_SIMPLE_NUMBER_STRING.TryParseNumber<byte>().HasSuccessValue().Should().BeTrue();
	}


	[TestCase("123", "en-us", ExpectedResult = 123)]
	[TestCase("-234", "en-us", ExpectedResult = -234)]
	[TestCase("123,456", "en-us", ExpectedResult = 123456)]
	[TestCase("123.456", "de-de", ExpectedResult = 123456)]
	public int ParseInt_WithCulture(string toParse, string cultureCode)
	{
		return toParse.TryParseNumber<int>(new CultureInfo(cultureCode))
			.Match(v => v, err =>
			{
				Assert.Fail(err.ErrorText);
				throw new Exception("Should not happen");
			});
	}
	
	[TestCase("123", "en-us", ExpectedResult = 123)]
	[TestCase("-234", "en-us", ExpectedResult = -234)]
	[TestCase("123,456", "en-us", ExpectedResult = 123456)]
	[TestCase("123.456", "de-de", ExpectedResult = 123456)]
	[TestCase("12,34", "de-de", ExpectedResult = 12.34)]
	[TestCase("11.23", "en-us", ExpectedResult = 11.23)]
	public decimal ParseDecimal_WithCulture(string toParse, string cultureCode)
	{
		return toParse.TryParseNumber<decimal>(new CultureInfo(cultureCode))
			.Match(v => v, err =>
			{
				Assert.Fail(err.ErrorText);
				throw new Exception("Should not happen");
			});
	}
}