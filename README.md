### Welcome to the Functional.Lib.Extensions wiki!

# Description
A simple library extending core .net libraries to support functional paradigm using Kj.Functional.Lib.
Simplifies usage of most popular methods/routines, like parsing, accessing collections, accessing dictionaries etc.


# Code examples

## Parsing and validating a number value:
```
		var result = inputString.TryParseInt() // try parse value
				.Filter(v => v > 0) // filter if value > 0
				.Map(v => v * 2) // multiply valid value by 2
			;
```

## Parsing and validating a date value:
```
		var result = inputString.TryParseDateTime() // try parse value
			.Filter(d => d.Year > 1999) // validate if year > 1999
			.Map(d => $"valid input date of {d}") // map valid date to output string
			.Or(() => $"Invalid date") // map to another string if anything went wrong
			;
```

## Looking up and validating a dictionary value:
```
		var dayName = _dayOfWeekNames
			.LookUp(dayNumber)
			.Map(name => $"Day is {name}")
			.Or(() => "Invalid day number");
```

## Trying to find an element in a collection:
```
		var mapped = _userNames
			.TryFirst(u => u.Name == toFind)
			.Map(u => $"User's age: {u.Age}")
			.Or(() => $"invalid user name");
```

## Using a chain of optional values to create an object:
```
	public static Option<UserInfo> TryParseUserFromStrings(string inputName, string birthYear, string numberPoints)
	{
		return _createUserFunc(
			inputName.TryParseName(), 
			birthYear.TryParseNumber<int>(), 
			numberPoints.TryParseNumber<double>()
			);
	}
	
	// Optional values are "passed further" in the chained call to finally create an object from all "extracted values" (if present)
	// Any value being empty breaks the chain, leading to a None value being returned instead of the parsed object
	private static readonly
		Func<Either<string, ParseErrorInfo>, Either<int, ParseErrorInfo>, Either<double, ParseErrorInfo>,
			Option<UserInfo>> _createUserFunc =
			(optUserName, optYearOfBirth, optUserPoints) =>
				optUserName.BindResult(name => optYearOfBirth.BindResult(year => optUserPoints.MapResult(
						p => new UserInfo(name, year, p)
					)
				)).AsOption();
```



