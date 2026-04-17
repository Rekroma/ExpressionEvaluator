namespace ExVal.App.Models;

public class Evaluator
{
    public static double ResolveAST(Queue<Token> ast) // unfinished
    {
        Stack<double> s = new Stack<double>();
        double sum = 0;
        bool first = true;

        foreach (Token t in ast)
        {
            if (t.Type == TokenType.OperandToken)
            {
                s.Push(Convert.ToDouble(t.Value));
            }
            else
            {
                double b = s.Pop();
                
                if (first)
                {
                    sum = s.Pop();
                    first = false;
                }                    
                
                sum = Calculate(sum, b, t);
            }
        }

        return sum;
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
        }

        return 0;
    }
}
