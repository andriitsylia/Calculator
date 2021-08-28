using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Services
{
    public class PrepareReportExpression
    {
        public IEnumerable<ReportExpression> Prepare(IEnumerable<ServiceExpression> serviceExpressions)
        {
            List<ReportExpression> reportExpressions = new();
            foreach (ServiceExpression serviceExpression in serviceExpressions)
            {
                if (serviceExpression.Valid)
                {
                    reportExpressions.Add(new ReportExpression($"{serviceExpression.Expression} = {serviceExpression.Value}"));
                }
                else
                {
                    reportExpressions.Add(new ReportExpression($"{serviceExpression.Expression} = {serviceExpression.Info}"));
                }
            }
            return reportExpressions;
        }
    }
}
