using ExVal.App.Validator;

namespace ExVal.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void InputValidatorTest()
    {
        bool expected = false;
        bool actual = InputValidator.IsValid("");
        Assert.That(expected, Is.EqualTo(actual)); 
    }
}
