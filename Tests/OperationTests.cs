using Xunit;
using System;

namespace Calc
{
    public class OperationTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(-1, 0, -1)]
        [InlineData(123.45, 123.45, 246.9)]
        [InlineData(-123456.78, 123456.78, 0)]
        public void Add_Tests(double lhs, double rhs, double expected)
        {
            var add = new Add();
            add.Init(lhs, rhs);
            Assert.True(expected - add.Execute() < ConstValues.ZERO_EPSILON);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(-1, 0, -1)]
        [InlineData(123.45, 123.45, 0)]
        [InlineData(-123456, -123456, 0)]
        [InlineData(123, 23.1, 99.9)]
        public void Sub_Tests(double lhs, double rhs, double expected)
        {
            var sub = new Subtract();
            sub.Init(lhs, rhs);
            Assert.True(expected - sub.Execute() < ConstValues.ZERO_EPSILON);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-1076425.8, 0, 0)]
        [InlineData(-1, 1, -1)]
        [InlineData(-123.45, -123.45, 15239.9025)]
        [InlineData(0.5, 6, 3)]
        public void Mult_Tests(double lhs, double rhs, double expected)
        {
            var mult = new Multiply();
            mult.Init(lhs, rhs);
            Assert.True(expected - mult.Execute() < ConstValues.ZERO_EPSILON);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, -1, -1)]
        [InlineData(2.5, 0.5, 5)]
        [InlineData(0.5, 2.5, 0.2)]
        public void Div_TestsLegitInput(double lhs, double rhs, double expected)
        {
            var div = new Divide();
            div.Init(lhs, rhs);
            Assert.True(expected - div.Execute() < ConstValues.ZERO_EPSILON);
        }

        [Theory]
        [InlineData(121, 0)]
        [InlineData(-123.456, 0)]
        [InlineData(0, 0)]
        public void Div_TestsDivByZero(double lhs, double rhs)
        {
            var div = new Divide();
            div.Init(lhs, rhs);
            Assert.Throws<DivideByZeroException>(() => div.Execute());
        }
    } 
}