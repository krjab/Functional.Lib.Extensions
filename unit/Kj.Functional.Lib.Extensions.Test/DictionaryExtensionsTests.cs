using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test;

[TestFixture]
public class DictionaryExtensionsTests
{
	[Test]
	public void Lookup_ExistingValue()
	{
		const string tested = "tested";
		var dict = new Dictionary<int, string>()
		{
			{ 1, tested }
		};

		dict.LookUp(1).HasValue.Should().BeTrue();
	}
	
	[Test]
	public void Lookup_NonExistingValue()
	{
		const string tested = "tested";
		const string existingKey = "key1";
		var dict = new Dictionary<string, string>()
		{
			{ existingKey, tested }
		};

		dict.LookUp("another key").HasValue.Should().BeFalse();
	}
}