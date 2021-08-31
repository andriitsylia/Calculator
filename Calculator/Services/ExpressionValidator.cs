using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Services
{
    public class ExpressionValidator
    {
        public (bool, string) ValidateWithoutBrackets(SourceExpression sourceExpression)
        {
            if (!OperandCheck(sourceExpression))
            {
                return (false, "invalid expression (operands)");
            }

            if (!OperationCheck(sourceExpression))
            {
                return (false, "invalid expression (operations)");
            }

            if (DivideByZeroCheck(sourceExpression))
            {
                return (false, "divide by zero");
            }

            return (true, "valid expression");
        }

        public (bool, string) ValidateWithBrackets(SourceExpression sourceExpression)
        {
            if (!OperandCheck(sourceExpression))
            {
                return (false, "invalid expression (operands)");
            }

            if (!BracketsCheck(sourceExpression))
            {
                return (false, "invalid expression (brackets)");
            }

            return (true, "valid expression");
        }

        private bool OperandCheck(SourceExpression sourceExpression)
        {
            char[] operations = new char[] { '+', '-', '*', '/', '(', ')' };
            string[] operands = sourceExpression.Expression.Split(operations, StringSplitOptions.TrimEntries);

            if (!operands.Where(value=>value != string.Empty).Any())
            {
                return (false);
            }

            if (operands.Where(value => value != string.Empty && !decimal.TryParse(value, out _)).Any())
            {
                return false;
            }

            return true;
        }

        private bool OperationCheck(SourceExpression sourceExpression)
        {
            char[] operations = new char[] { '+', '-', '*', '/' };
            string[] operands = sourceExpression.Expression.Split(operations, StringSplitOptions.TrimEntries);

            IEnumerable<char> operationArray = sourceExpression.Expression.ToCharArray()
                                                .Where(operation => operation is '+' or '-' or '*' or '/')
                                                .Select(operation => operation);

            if ((operationArray.Count() != 0) && (operationArray.ElementAt(0) is '*' or '/') && (operands[0] == string.Empty))
            {
                return false;
            }

            if (operands[operands.Length - 1] == string.Empty)
            {
                return false;
            }

            int firstOperationPosition = 0;
            int valuesCounter = 0;
            firstOperationPosition = sourceExpression.Expression.IndexOfAny(operations, firstOperationPosition);
            int secondOperationPosition;
            while ((secondOperationPosition = sourceExpression.Expression.IndexOfAny(operations, firstOperationPosition + 1)) != -1)
            {
                if (string.IsNullOrWhiteSpace(operands[valuesCounter])
                    && string.IsNullOrWhiteSpace(operands[valuesCounter + 1]))
                {
                    return false;
                }

                switch (sourceExpression.Expression[firstOperationPosition])
                {
                    case '+':
                        if ((sourceExpression.Expression[secondOperationPosition] == '*'
                             || sourceExpression.Expression[secondOperationPosition] == '/')
                             && string.IsNullOrWhiteSpace(operands[valuesCounter + 1]))
                        {
                            return false;
                        }
                        break;
                    case '-':
                        if ((sourceExpression.Expression[secondOperationPosition] == '*'
                             || sourceExpression.Expression[secondOperationPosition] == '/')
                             && string.IsNullOrWhiteSpace(operands[valuesCounter + 1]))
                        {
                            return false;
                        }
                        break;
                    case '*':
                        if ((sourceExpression.Expression[secondOperationPosition] == '*'
                             || sourceExpression.Expression[secondOperationPosition] == '/')
                             && string.IsNullOrWhiteSpace(operands[valuesCounter + 1]))
                        {
                            return false;
                        }
                        break;
                    case '/':
                        if ((sourceExpression.Expression[secondOperationPosition] == '*'
                             || sourceExpression.Expression[secondOperationPosition] == '/')
                             && string.IsNullOrWhiteSpace(operands[valuesCounter + 1]))
                        {
                            return false;
                        }
                        break;
                }
                firstOperationPosition = secondOperationPosition;
                valuesCounter++;
            }

            return true;
        }

        private bool DivideByZeroCheck(SourceExpression sourceExpression)
        {
            char[] operations = new char[] { '+', '-', '*', '/' };
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
