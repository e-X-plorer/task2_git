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
        /// <summary>
        /// Does this block represent a primary operation?
        /// </summary>
        /// <value></value>
        public bool isPrimary { get; }
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
            value = inputNumber;
            isNumber = true;
        }

        /// <summary>
        /// Constructor for block containing an operation.
        /// </summary>
        /// <param name="inputOperation">a type of operation to put into a block</param>
        /// <param name="primary">whether this operation is primary or not</param>
        public ExpressionBlock(Operation inputOperation, bool primary)
        {
            operation = inputOperation;
            isNumber = false;
            isPrimary = primary;
        }
    }
}