using ExVal.App.Services;

namespace ExVal.App.Models;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter your expression and confirm with [ENTER]:");

        string validatedInput = InputService.GetValidatedInput();

        Lexer l = new Lexer();

        Queue<Token> tokenList = l.Parse(validatedInput);

        Console.WriteLine(Evaluator.ResolveAST(tokenList));
    }
}
