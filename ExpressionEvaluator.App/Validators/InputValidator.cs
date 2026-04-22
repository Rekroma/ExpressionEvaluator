namespace ExpressionEvaluator.Core.Validators;

public class InputValidator
{
    static readonly HashSet<char> ValidCharacters = new()
    {
        ' ',
        '+', '-', '*', '/', '%',
        '(', ')',
        '0','1','2','3','4','5','6','7','8','9'
    };

    public static (bool, string?) Validate(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return (false, "You entered no expression.");
        }

        if (input.Any(c => !ValidCharacters.Contains(c)))
        {
            return (false, $"Your expression is invalid. \n" +
                           $"Accepted characters are {string.Join(", ", ValidCharacters).TrimStart(" , ")} and whitespaces.");
        }

        return (true, null);
    }
}
