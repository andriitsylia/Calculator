using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Token
    {
        private readonly decimal _value;
        private readonly Operation _operation;

        public decimal Value
        {
            get
            {
                return _value;
            }
        }

        public Operation Operation
        {
            get
            {
                return _operation;
            }
        }

        public Token(decimal value, Operation operation)
        {
            _value = value;
            _operation = operation;
        }
    }
}
