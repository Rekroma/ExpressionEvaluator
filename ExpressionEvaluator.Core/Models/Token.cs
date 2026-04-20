namespace ExpressionEvaluator.Core.Models;

public class Token
{
    public TokenType Type { get; set; }
    public object Value { get; set; }

    public Token(TokenType type, object value)
    {
        Type = type;
        Value = value;
    }
}