using System;

namespace Calculator.Models
{
    public class ReportExpression
    {
        public string Expression { get; }

        public ReportExpression(string expression)
        {
            Expression = expression
                          ?? throw new ArgumentNullException(nameof(expression), "Received a null argument"); ;
        }
    }
}
