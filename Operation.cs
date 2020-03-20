using System;

namespace Calc
{
    /// <summary>
    /// Base class for all operations.
    /// </summary>
    public abstract class Operation
    {
        /// <summary>
        /// Whether operation is binary or unary.
        /// </summary>
        /// <value></value>
        public bool isBinary { get; protected set; }

        /// <summary>
        /// Executes the operation's logic.
        /// </summary>
        /// <returns>result of operation</returns>
        public abstract double Execute();
    }
}