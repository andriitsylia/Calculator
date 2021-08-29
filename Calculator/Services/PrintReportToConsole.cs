using Calculator.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;

namespace Calculator.Services
{
    public class PrintReportToConsole : IExpressionPrinter
    {
        public void Print(IEnumerable<ReportExpression> reportExpressions)
        {
            foreach (ReportExpression reportExpression in reportExpressions)
            {
                Console.WriteLine(reportExpression.Expression);
            }
        }
    }
}
