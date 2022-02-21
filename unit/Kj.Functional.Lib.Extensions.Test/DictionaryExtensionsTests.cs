using System.Collections.Generic;
using System.Collections.Specialized;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace Kj.Functional.Lib.Extensions.Test;

[TestFixture]
public class DictionaryExtensionsTests
{
	private AutoFixture.Fixture _fixture = null!;

	[SetUp]
	public void Setup()
	{
		_fixture = new Fixture();
	}
	
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

	[Test]
	public void NameValueCollection_Lookup_ExistingValue()
	{
		var value = "tested" + _fixture.Create<string>() ;
		var key = "key" + _fixture.Create<string>() ;
		
		var nameValueCollection = new NameValueCollection
		{
			[key] = value
		};

		nameValueCollection.LookUp(key).HasValue.Should().BeTrue();
	}

	[Test]
	public void NameValueCollection_Lookup_NonExistingValue()
	{
		var value = "tested" + _fixture.Create<string>() ;
		const string key = "some key";
		
		var nameValueCollection = new NameValueCollection
		{
			[key] = value
		};

		nameValueCollection.LookUp("not-existing-key").HasValue.Should().BeFalse();
	}
}