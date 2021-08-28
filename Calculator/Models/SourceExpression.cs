using System;

namespace Calculator.Models
{
    public class SourceExpression
    {
        public string Expression { get; }

        public SourceExpression(string expression)
        {
            Expression = expression 
                         ?? throw new ArgumentNullException(nameof(expression), "Received a null argument");
        }
    }
}
