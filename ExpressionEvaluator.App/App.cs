using ExpressionEvaluator.App.Controller;
using ExpressionEvaluator.Core;
using ExpressionEvaluator.Core.Models;

namespace ExpressionEvaluator.App;

public static class App
{
    public static void Run()
    {
        bool repeat;

        do
        {
            string validatedInput = InteractionController.GetValidatedInput();

            Queue<Token> tokenList = Lexer.Parse(validatedInput);

            double result = Evaluator.Evaluate(tokenList);

            InteractionController.AnnounceResult(result);

            repeat = InteractionController.AskForNewExpression();
        }
        while (repeat);
    }
}
