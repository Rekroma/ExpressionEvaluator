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
            Console.Clear();

            Write("Enter your expression:");

            input = ReadLower();

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
        Write($"Your expression evaluates to: {Math.Round(result, 2)}");
        WriteEmptyLine();
    }

    public static void ThrowException(string exceptionMessage)
    {
        Write(exceptionMessage);
        WriteEmptyLine();
    }

    public static bool AskForNewExpression()
    {
        bool repeat;

        Write("Do you want to enter a new expression? [y/OTHER KEY]");
        repeat = ReadLower() == "y";
        if (!repeat)
        {
            Write("Program exited.");
        }
        return repeat;
    }

    private static void Write(string? s)
    {
        Console.WriteLine(s);
    }

    private static void WriteEmptyLine()
    {
        Console.WriteLine();
    }

    private static string? ReadLower()
    {
        return Console.ReadLine().ToLower();
    }
}
