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
            string validatedInput = IOController.GetValidatedInput();

            try
            {
                Queue<Token> tokenList = Lexer.Parse(validatedInput);

                double result = Evaluator.Evaluate(tokenList);

                IOController.AnnounceResult(result);
            }
            catch (Exception e)
            {
                IOController.ThrowException(e.Message);
            }
            finally
            {
                repeat = IOController.AskForNewExpression();
            }
        }
        while (repeat);
    }
}
