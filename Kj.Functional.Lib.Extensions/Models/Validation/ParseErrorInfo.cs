namespace Kj.Functional.Lib.Extensions.Models.Validation;

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