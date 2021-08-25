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
        private decimal _value;
        private bool _isValid;
        private string _info;

        public string Expression
        {
            get
            {
                return _expression;
            }
        }

        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public bool Valid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
            }
        }

        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
            }
        }
        public MathExpression(string expression)
        {
            _expression = expression 
                          ?? throw new ArgumentNullException(nameof(expression), "Received a null argument");
            _value = decimal.Zero;
            _isValid = true;
            _info = string.Empty;
        }


    }
}
