using ExpressionEvaluator.App.Models;
using ExpressionEvaluator.Core;

namespace ExpressionEvaluator.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void TestAll()
    {
        var testCases = new Dictionary<string, double>
        {
            ["1 + 2 - 3"] = 0,
            ["1 * ( 2 + 3 ) - 4"] = 1,
            ["( 1 + 2 ) * 3 / 4"] = 2.25,
            ["5 + 6 - ( 3 * 5 + ( 6 - 8 ) ) / 2"] = 4.5,
            ["10 % 3 + 2"] = 3,
            ["( 10 + 5 ) % 4 * 3"] = 9,
            ["-5 + 3 * 2"] = 1,
            ["( -10 + 2 ) * 3"] = -24,
            ["8 / 2 + 3 * ( 2 - 5 )"] = -5,
            ["( 7 + 3 ) * ( 2 % 3 )"] = 20,
            ["-8 % 3 + 6"] = 4,
            ["( 12 / 3 ) + ( 5 * -2 )"] = -6,
            ["( 9 - 4 ) * ( 6 % 4 )"] = 10,
            ["-3 * ( 4 + 2 ) / 3"] = -6
        };

        foreach (var testCase in testCases)
        {
            Assert.That(Evaluator.Evaluate(Lexer.Parse(testCase.Key)), Is.EqualTo(testCase.Value));
        }
    }
}