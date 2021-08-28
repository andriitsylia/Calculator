using System;

namespace Calculator.Models
{
    public class ServiceExpression
    {
        public string Expression { get; }

        public decimal Value { get; }

        public bool Valid { get; }

        public string Info { get; }

        public ServiceExpression(string expression, decimal value, bool isValid, string info)
        {
            Expression = expression
                          ?? throw new ArgumentNullException(nameof(expression), "Received a null argument");
            Value = value;
            Valid = isValid;
            Info = info;
        }
    }
}
