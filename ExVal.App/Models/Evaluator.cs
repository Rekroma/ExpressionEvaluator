namespace ExVal.App.Models;

public class Evaluator
{
    public static double ResolveAST(Queue<Token> ast)
    {
        Stack<double> s = new Stack<double>();

        foreach (Token t in ast)
        {
            if (t.Type == TokenType.OperandToken)
            {
                s.Push(Convert.ToDouble(t.Value));
            }
            else
            {
                double right = s.Pop();
                double left = s.Pop();

                double result = Calculate(left, right, t);
                s.Push(result);
            }
        }

        return s.Pop();
    }

    public static double Calculate(double a, double b, Token t)
    {
        switch (t.Type)
        {
            case TokenType.PlusToken: return a + b;
            case TokenType.MinusToken: return a - b;
            case TokenType.MultiplierToken: return a * b;
            case TokenType.DivisionToken:
                {
                    if (b == 0)
                    {
                        throw new DivideByZeroException("You can't do that.");
                    }

                    return a / b;
                }
            case TokenType.ModuloToken: return a % b;
        }

        return 0;
    }
}
