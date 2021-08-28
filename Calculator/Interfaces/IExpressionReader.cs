using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Interfaces
{
    public interface IExpressionReader
    {
        public IEnumerable<SourceExpression> Read();
    }
}
