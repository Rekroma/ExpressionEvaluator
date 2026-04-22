using ExpressionEvaluator.App.Models;
using ExpressionEvaluator.Core;
using ExpressionEvaluator.Core.Models;
using ExpressionEvaluator.Core.Validators;

namespace ExpressionEvaluator.App;

class Program
{
    public static void Main(string[] args)
    {
        bool repeat = false; 

        do
        {
            string? input;

            Console.WriteLine("Please enter your expression and confirm with [ENTER]:");

            do
            {
                input = Console.ReadLine();
            }
            while (!InputValidator.IsValid(input));

            Queue<Token> tokenList = Lexer.Parse(input);

            double result = Evaluator.Evaluate(tokenList);

            Console.WriteLine($"Your expression evaluates to: {result} \n");

            Console.WriteLine("Do you want to enter another expression? [y/n]");

            repeat = Console.ReadLine().ToLower().Equals("y");
        }
        while (repeat);
    }
}
