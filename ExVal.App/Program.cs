using ExVal.App.Services;
using System.Security.Cryptography.X509Certificates;
namespace ExVal.App.Models;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter your expression and confirm with [ENTER]:");

        string validatedInput = InputService.GetValidatedInput();

        Lexer l = new Lexer();

        Queue<Token> tokenList = l.Parse(validatedInput);

        foreach (Token t in tokenList)
        {
            Console.WriteLine(t.Value);
        }
    }
}
