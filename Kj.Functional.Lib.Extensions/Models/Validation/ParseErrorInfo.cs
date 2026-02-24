using System.Diagnostics.CodeAnalysis;

namespace Kj.Functional.Lib.Extensions.Models.Validation;

[SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types")]
public struct ParseErrorInfo
{
	public ParseErrorInfo(string errorText)
	{
		ErrorText = errorText;
	}

	public string ErrorText { get; }

	public static ParseErrorInfo FromText(string input)
	{
		return new ParseErrorInfo(input);
	}
}