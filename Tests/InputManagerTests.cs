using Xunit;

namespace Calc
{
    public class InputManagerTests
    {
        [Theory]
        [InlineData("3 + 3 * 3 + 3 * 3", 21)]
        [InlineData("5 + 5 - 5", 5)]
        [InlineData("5 * 5 / 5", 5)]
        [InlineData("5 / 5 * 5", 5)]
        [InlineData("3 + 3 * 3 ^ 3 + 3 ^ 3 * 3 ^ 3", 813)]
        [InlineData("5 % 2", 1)]
        [InlineData("5 ^ 3 + 6.5 % 2.1", 125.2)]
        [InlineData("123.45 + 123.45 * 123.45 / 123.45 - 123.45", 123.45)]
        [InlineData("pi + 100 * e - e", 272.251494)]
        public void ProcessInput_TestsLegitInput(string input, double expected)
        {
            Assert.True(expected - InputManager.ProcessInput(input) < ConstValues.ZERO_EPSILON);
        }
    } 
}