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
        [InlineData("123.45 + 123.45 * 123.45 / 123.45 - 123.45", 123.45)]
        public void ProcessInput_TestsLegitInput(string input, double expected)
        {
            Assert.True(expected - InputManager.ProcessInput(input) < ConstValues.ZERO_EPSILON);
        }
    } 
}