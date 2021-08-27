using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class ExpressionValidator
    {
        public bool Validate(MathExpression expression)
        {
            if (!OperandsCheck(expression))
            {
                expression.Valid = false;
                expression.Info = "invalid expression (operands)";
                return expression.Valid;
            }

            if (!BracketsCheck(expression))
            {
                expression.Valid = false;
                expression.Info = "invalid expression (brackets)";
                return expression.Valid;
            }

            expression.Valid = true;
            return expression.Valid;
        }

        private bool OperandsCheck(MathExpression expression)
        {
            char[] operations = new char[] { '+', '-', '*', '/', '(', ')' };

            string[] values = expression.Expression.Split(operations, StringSplitOptions.TrimEntries);
            decimal tempValue;

            foreach (string value in values)
            {
                if (!(string.IsNullOrWhiteSpace(value) || decimal.TryParse(value, out tempValue)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool BracketsCheck(MathExpression expression)
        {
            int bracketsCounter = 0;
            int i = 0;
            
            while (i < expression.Expression.Length)
            {
                switch (expression.Expression[i])
                {
                    case '(':
                        bracketsCounter++;
                        break;
                    case ')':
                        bracketsCounter--;
                        break;
                }
                if (bracketsCounter < 0)
                {
                    return false;
                }
                i++;
            }
            return bracketsCounter == 0 ? true: false;
        }
    }
}
