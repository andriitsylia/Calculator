using Calculator.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator.Services
{
    public class PrintReportToFile: IExpressionPrinter
    {
        private readonly string _fileName;

        public PrintReportToFile(string fileName)
        {
            _fileName = fileName
                        ?? throw new ArgumentNullException(nameof(fileName), "Received a null argument");
        }

        public void Print(IEnumerable<ReportExpression> reportExpressions)
        {
            using StreamWriter file = new(_fileName);
            foreach (ReportExpression reportExpression in reportExpressions)
            {
                file.WriteLine(reportExpression.Expression);
            }
        }
    }
}
