namespace ExVal.App.Models;

public class Lexer
{
    public List<Token> Parse(string expression)
    {
        List<string> parsedExpression = expression.Split(" ").ToList();

        foreach(string s in parsedExpression)
        {
            //
        }
    }
}
