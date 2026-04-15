namespace ExVal.Validator;

public class InputValidator
{
    public static bool IsValid(string input)
    {
        var validCharacters = new List<char>
        {
            ' ', '+', '-', '*', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("You entered no expression. Try again:");
            return false;
        }

        if (input.Any(c => !validCharacters.Contains(c)))
        {
            Console.WriteLine("Your expression is invalid. Accepted characters are digits 0-9, +, -, *, /, and whitespaces. Try again:");
            return false;
        }

        return true;
    }
}
