using ExVal.App.Validator;

namespace ExVal.App.Services;

public static class InputService
{
    public static string GetValidatedInput()
    {
        string? input;

        do
        {
            input = Console.ReadLine();
        }
        while (!InputValidator.IsValid(input));

        return input;
    }
}
