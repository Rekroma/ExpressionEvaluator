using ExVal.App.Models;
using ExVal.App.Services;
using ExVal.App.Validator;

namespace ExVal.Tests;

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
        };

        foreach (var testCase in testCases)
        {
            Assert.That(Evaluator.ResolveAST(new Lexer().Parse(testCase.Key)), Is.EqualTo(testCase.Value));
        }
    }
}