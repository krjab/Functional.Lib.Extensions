using System;
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
}