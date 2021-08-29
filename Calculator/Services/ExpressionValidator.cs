using Calculator.Models;
using System;

namespace Calculator.Services
{
    public class ExpressionValidator
    {
        public (bool, string) Mode1Validate(SourceExpression sourceExpression)
        {
            if (!OperandsCheck(sourceExpression))
            {
                return (false, "invalid expression (operands)");
            }

            if (DivideByZeroCheck(sourceExpression))
            {
                return (false, "divide by zero");
            }

            return (true, "");
        }

        public (bool, string) Mode2Validate(SourceExpression sourceExpression)
        {
            if (!OperandsCheck(sourceExpression))
            {
                return (false, "invalid expression (operands)");
            }

            if (!BracketsCheck(sourceExpression))
            {
                return (false, "invalid expression (brackets)");
            }

            return (true, "");
        }

        private bool OperandsCheck(SourceExpression sourceExpression)
        {
            char[] operations = new char[] { '+', '-', '*', '/', '(', ')' };
            string[] values = sourceExpression.Expression.Split(operations, StringSplitOptions.TrimEntries);

            foreach (string value in values)
            {
                if (!(string.IsNullOrWhiteSpace(value) || decimal.TryParse(value, out _)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool DivideByZeroCheck(SourceExpression sourceExpression)
        {
            char[] operations = new char[] { '+', '-', '*', '/', '(', ')' };
            int dividePosition = 0;
            string value;
            while ((dividePosition = sourceExpression.Expression.IndexOf('/', dividePosition)) != -1)
            {
                int signPosition = sourceExpression.Expression.IndexOfAny(operations, dividePosition + 1);
                if (signPosition != -1)
                {
                    value = sourceExpression.Expression.Substring(dividePosition + 1, signPosition - dividePosition - 1); 
                }
                else
                {
                    value = sourceExpression.Expression.Substring(dividePosition + 1);
                }
                if (!string.IsNullOrWhiteSpace(value) && decimal.Parse(value) == 0)
                {
                    return true;
                }
                dividePosition++;
            }
            return false;
        }

        private bool BracketsCheck(SourceExpression sourceExpression)
        {
            int bracketsCounter = 0;
            int i = 0;
            
            while (i < sourceExpression.Expression.Length)
            {
                switch (sourceExpression.Expression[i])
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
            return bracketsCounter == 0;
        }
    }
}
