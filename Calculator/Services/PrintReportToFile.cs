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
        private readonly bool _append;

        public PrintReportToFile(string fileName, bool append)
        {
            _fileName = fileName
                        ?? throw new ArgumentNullException(nameof(fileName), "Received a null argument");
            _append = append;
        }

        public void Print(IEnumerable<ReportExpression> reportExpressions)
        {
            using StreamWriter file = new(_fileName, _append);
            foreach (ReportExpression reportExpression in reportExpressions)
            {
                file.WriteLine(reportExpression.Expression);
            }
        }
    }
}
