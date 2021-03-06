using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Kj.Functional.Lib.Extensions.Parse;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test.Parse;

[TestFixture]
public class ParseDateTimeTests
{
	[TestCase("2012-01-01")]
	[TestCase("2022-02-21 13:57")]
	[TestCase("2022-03-13Z11:22")]
	public void Parse_Date_Success(string input)
	{
		input.TryParseDateTime().HasSuccessValue().Should().BeTrue();
	}
	
	[TestCase("")]
	[TestCase("  ")]
	[TestCase("some other string")]
	[TestCase("2012-01-32")]
	[TestCase("2022-02-29 13:57")]
	[TestCase("2022-13-13Z")]
	public void Parse_Date_Fails(string input)
	{
		input.TryParseDateTime().HasSuccessValue().Should().BeFalse();
	}

	private static readonly IEnumerable<object[]> _dateTimeParseWithValues = new[]
	{
		new object[] { "2012-01-02", new DateTime(2012, 1, 2) },
		new object[] { "2022-12-08Z11:12:13", new DateTime(2022, 12, 08, 11,12,13, DateTimeKind.Utc)},
		new object[] { "2022-11-24 10:11:12", new DateTime(2022, 11, 24, 10,11,12, DateTimeKind.Unspecified)}
	};
	
	[TestCaseSource(nameof(_dateTimeParseWithValues))]
	public void Parse_Date_Value(string input, DateTime expected)
	{
		var date = input.TryParseDateTime().Match(i => i, err =>
		{
			Assert.Fail(err.ErrorText);
			throw new Exception("unreachable");
		});

		if (date.Kind == DateTimeKind.Unspecified)
		{
			date.Should().Be(expected);
		}
		else
		{
			date.ToUniversalTime().Should().Be(expected);	
		}
	}

	private static readonly CultureInfo _cultureEnUs = new("en-us");
	private static readonly CultureInfo _cultureDeDe = new("de-de");
	private static readonly IEnumerable<object[]> _dateTimeParseForCultureWithValues = new[]
	{
		new object[] { "2012-01-02", _cultureEnUs, new DateTime(2012, 1, 2) },
		new object[] { "2012/11/02", _cultureEnUs, new DateTime(2012, 11, 02) },
		new object[] { "11/02/2014", _cultureEnUs, new DateTime(2014, 11, 02) },
		new object[] { "2012-11-08", _cultureDeDe, new DateTime(2012, 11, 08) },
		new object[] { "11/08/2016", _cultureDeDe, new DateTime(2016, 08, 11) },
	};
	
	[TestCaseSource(nameof(_dateTimeParseForCultureWithValues))]
	public void Parse_Date_Value_WithCulture(string input, CultureInfo cultureInfo, DateTime expected)
	{
		var date = input.TryParseDateTime(cultureInfo).Match(i => i, err =>
		{
			Assert.Fail(err.ErrorText);
			throw new Exception("unreachable");
		});

		if (date.Kind == DateTimeKind.Unspecified)
		{
			date.Should().Be(expected);
		}
		else
		{
			date.ToUniversalTime().Should().Be(expected);	
		}
	}
}