using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Interfaces
{
    public interface IExpressionPrinter
    {
        public void Print(IEnumerable<ReportExpression> reportExpressions);
    }
}
