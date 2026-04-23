using ExpressionEvaluator.Core.Models;

namespace ExpressionEvaluator.Core;

public class Lexer
{
    public static Queue<Token> Parse(string expression)
    {
        List<string> parsedExpression = new List<string>();
        string temp = "";
        expression = expression.Replace(" ", "");

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '-' && i == 0 ||
               (expression[i] == '-' && (!char.IsDigit(expression[i - 1])) && expression[i - 1] != ')'))
            {
                temp = "-";
            }
            else if ((!char.IsDigit(expression[i])))
            {
                if (temp.Length > 0) parsedExpression.Add(temp);
                parsedExpression.Add(expression[i].ToString());
                temp = "";
            }
            else
            {
                temp += expression[i].ToString();
            }
        }
        if (temp.Length > 0) parsedExpression.Add(temp);

        Queue<Token> output = new Queue<Token>();
        Stack<Token> operators = new Stack<Token>();

        Dictionary<TokenType, int> precedence = new Dictionary<TokenType, int>()
        {
            { TokenType.PlusToken, 1 },
            { TokenType.MinusToken, 1 },
            { TokenType.MultiplierToken, 2 },
            { TokenType.DivisionToken, 2 },
            { TokenType.ModuloToken, 2 },
            { TokenType.ExponentiationToken, 3},
        };

        Dictionary<string, TokenType> tokenMap = new Dictionary<string, TokenType>
        {
            { "+", TokenType.PlusToken },
            { "-", TokenType.MinusToken },
            { "*", TokenType.MultiplierToken },
            { "/", TokenType.DivisionToken },
            { "%", TokenType.ModuloToken },
            { "^", TokenType.ExponentiationToken },
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
                        bool isRightAssociative = newToken.Type == TokenType.ExponentiationToken;
                        if (isRightAssociative
                            ? precedence[lastToken.Type] > precedence[newToken.Type]
                            : precedence[lastToken.Type] >= precedence[newToken.Type])
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
