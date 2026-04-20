using ExpressionEvaluator.Core.Models;

namespace ExpressionEvaluator.Core;

public class Lexer
{
    public static Queue<Token> Parse(string expression)
    {
        List<string> parsedExpression = expression.Split(" ").ToList();

        Queue<Token> output = new Queue<Token>();
        Stack<Token> operators = new Stack<Token>();

        Dictionary<TokenType, int> precedence = new Dictionary<TokenType, int>()
        {
            { TokenType.PlusToken, 1 },
            { TokenType.MinusToken, 1 },
            { TokenType.MultiplierToken, 2 },
            { TokenType.DivisionToken, 2 },
            { TokenType.ModuloToken, 2 },
        };

        Dictionary<string, TokenType> tokenMap = new Dictionary<string, TokenType>
        {
            { "+", TokenType.PlusToken },
            { "-", TokenType.MinusToken },
            { "*", TokenType.MultiplierToken },
            { "/", TokenType.DivisionToken },
            { "%", TokenType.ModuloToken },
            { "(", TokenType.OpeningParanthesisToken },
            { ")", TokenType.ClosingParanthesisToken }
        };

        foreach (string s in parsedExpression)
        {
            if (tokenMap.ContainsKey(s))
            {
                Token newToken = new Token(tokenMap[s], s);

                if (newToken.Type == TokenType.OpeningParanthesisToken)
                {
                    operators.Push(newToken);
                }

                else if (newToken.Type == TokenType.ClosingParanthesisToken)
                {
                    while (operators.Count > 0 && operators.Peek().Type != TokenType.OpeningParanthesisToken)
                    {
                        output.Enqueue(operators.Pop());
                    }

                    if (operators.Count > 0)
                    {
                        operators.Pop();
                    }
                }

                else
                {
                    while (operators.Count > 0)
                    {
                        Token lastToken = operators.Peek();

                        if (lastToken.Type == TokenType.OpeningParanthesisToken)
                        {
                            break;
                        }
                        if (precedence[lastToken.Type] >= precedence[newToken.Type])
                        {
                            output.Enqueue(operators.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    operators.Push(newToken);
                }
            }
            else
            {
                output.Enqueue(new Token(TokenType.OperandToken, double.Parse(s)));
            }
        }

        while (operators.Count > 0)
        {
            Token lastToken = operators.Peek();
            output.Enqueue(lastToken);
            operators.Pop();
        }

        return output;
    }
}
