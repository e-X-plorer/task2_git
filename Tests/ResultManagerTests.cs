using Xunit;

namespace Calc
{
    public class ResultManagerTests
    {
        [Theory]
        [InlineData("3 + 3 * 3 + 3 * 3", 21)]
        [InlineData("5+5-5", 5)]
        [InlineData("5 * 5 /     5", 5)]
        [InlineData("    5 / 5 * 5    ", 5)]
        [InlineData("3+ 3 *      3^3 + 3    ^3*3^ 3", 813)]
        [InlineData("123.45 + 123.45 * 123.45 / 123.45 - 123.45", 123.45)]
        [InlineData(".1 + 1. + .1", 1.2)]
        [InlineData("123.456", 123.456)]
        public void ShowResult_TestsLegitInput(string input, double expected)
        {
            Assert.True(expected - double.Parse(ResultManager.ShowResult(input)) < ConstValues.ZERO_EPSILON);
        }

        [Theory]
        [InlineData("", "Invalid expression format.")]
        [InlineData("*123+123", "Invalid expression format.")]
        [InlineData("123/123/", "Invalid expression format.")]
        [InlineData("123 ++ 123", "Invalid expression format.")]
        [InlineData("12 $ 23 + 1", "Invalid expression format.")]
        [InlineData("123 + 123 / 0 + 123", "Cannot divide by zero.")]
        public void ShowResult_TestInvalidInput(string input, string expected)
        {
            Assert.Equal(expected, ResultManager.ShowResult(input));
        }
    } 
}