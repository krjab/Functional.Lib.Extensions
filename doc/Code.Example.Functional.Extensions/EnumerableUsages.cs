using Kj.Functional.Lib.Core;
using Kj.Functional.Lib.Extensions.Enumerable;

namespace Code.Example.Functional.Extensions;

public static class EnumerableUsages
{
	private static readonly IReadOnlyDictionary<int, string> _dayOfWeekNames = new Dictionary<int, string>()
	{
		{ 1, "Monday" },
		{ 2, "Tuesday" },
		{ 3, "Wednesday" },
		{ 4, "Thursday" },
		{ 5, "Friday" },
		{ 6, "Saturday" },
		{ 7, "Sunday" },
	};
	
	public static void LookupAnEntryInDictionaryAndMap(int dayNumber)
	{
		var dayName = _dayOfWeekNames
			.LookUp(dayNumber)
			.Map(name => $"Day is {name}")
			.Or(() => "Invalid day number");
	}

	public record UserInfo(string Name, int Age);
	
	private static readonly UserInfo[] _userNames = new[]
	{
		new UserInfo("One", 38),
		new UserInfo("Two", 22),
		new UserInfo("Three", 45),
	};

	public static void FindAStringAndMap(string toFind)
	{
		var mapped = _userNames
			.TryFirst(u => u.Name == toFind)
			.Map(u => $"User's age: {u.Age}")
			.Or(() => $"invalid user name");
	}
}