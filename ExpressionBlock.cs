using System;

namespace Calc
{
    /// <summary>
    /// Helper class for Expression Block data structure.
    /// </summary>
    public class ExpressionBlock
    {
        /// <summary>
        /// Does this block represent a number?
        /// </summary>
        /// <value></value>
        public bool isNumber { get; }
        public int tier { get; }
        /// <summary>
        /// Operation this block represents.
        /// </summary>
        /// <value></value>
        public Operation operation { get; }
        /// <summary>
        /// Numerical value of this block if exists.
        /// </summary>
        /// <value></value>
        public double value { get; }

        /// <summary>
        /// Constructor for block containing a number.
        /// </summary>
        /// <param name="inputNumber">number to put into a block</param>
        public ExpressionBlock(double inputNumber)
        {
            this.value = inputNumber;
            this.isNumber = true;
        }

        public ExpressionBlock(Operation operation, int operationTier)
        {
            this.operation = operation;
            this.isNumber = false;
            this.tier = operationTier;
        }
    }
}