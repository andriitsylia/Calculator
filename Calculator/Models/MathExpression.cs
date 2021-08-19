using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class MathExpression
    {
        private readonly string _expression;

        public string Expression
        {
            get
            {
                return _expression;
            }
        }

        public MathExpression(string expression)
        {
            _expression = expression 
                          ?? throw new ArgumentNullException(nameof(expression), "Received a null argument");
        }


    }
}
