using ExpressionEvaluator.Core.Validators;

namespace ExpressionEvaluator.App.Controller;

public class IOController
{
    public static string GetValidatedInput()
    {
        string? input;
        bool isValid;

        do
        {
            Write("Enter your expression:");

            input = Read();

            WriteEmptyLine();

            (isValid, string? message) = InputValidator.Validate(input);

            if (message != null)
            {
                Write(message);
                WriteEmptyLine();
            }
        }
        while (!isValid);

        return input;
    }

    public static void AnnounceResult(double result)
    {
        Write($"Your expression evaluates to: {result:F2}");
        WriteEmptyLine();
    }

    public static void ThrowException(string exceptionMessage)
    {
        Write(exceptionMessage);
        WriteEmptyLine();
    }

    public static bool AskForNewExpression()
    {
        string input;

        do
        {
            Write("Do you want to enter a new expression? [y/n]");
            input = Read();
            WriteEmptyLine();
        }
        while (string.IsNullOrEmpty(input) && input != "y" && input != "n");

        return input == "y";
    }

    private static void Write(string? s)
    {
        Console.WriteLine(s);
    }

    private static void WriteEmptyLine()
    {
        Console.WriteLine();
    }

    private static string? Read()
    {
        return Console.ReadLine().ToLower();
    }
}
