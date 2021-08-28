using Calculator.Models;
using System;
using System.Collections.Generic;

namespace Calculator.Services
{
    public class ParseExpression
    {
        public ParsedExpression Parse(SourceExpression sourceExpression)
        {
            char[] operations = new char[] { '+', '-', '*', '/' };
            string[] values = sourceExpression.Expression.Split(operations, StringSplitOptions.TrimEntries);

            int operationPosition = 0;
            int valuesCounter = 0;
            bool isUnarySign = false;
            int multiplicant = 1;
            Operation operation = Operation.End;
            List<Token> tokens = new();

            while ((operationPosition = sourceExpression.Expression.IndexOfAny(operations, operationPosition)) != -1)
            {
                switch (sourceExpression.Expression[operationPosition])
                {
                    case '+':
                        if (!string.IsNullOrWhiteSpace(values[valuesCounter]))
                        {
                            operation = Operation.Add;
                        }
                        else
                        {
                            isUnarySign = true;
                            multiplicant = 1;
                            valuesCounter++;
                        }
                        break;
                    case '-':
                        if (!string.IsNullOrWhiteSpace(values[valuesCounter]))
                        {
                            operation = Operation.Subtract;
                        }
                        else
                        {
                            isUnarySign = true;
                            multiplicant = -1;
                            valuesCounter++;
                        }
                        break;
                    case '*':
                        operation = Operation.Multiply;
                        break;
                    case '/':
                        operation = Operation.Divide;
                        break;
                    default:
                        break;
                }
                if (!isUnarySign)
                {
                    tokens.Add(new Token(decimal.Parse(values[valuesCounter++]) * multiplicant,
                               operation));
                    multiplicant = 1;
                }
                operationPosition++;
                isUnarySign = false;
            }
            tokens.Add(new Token(decimal.Parse(values[valuesCounter]) * multiplicant, Operation.End));
            
            return new ParsedExpression(sourceExpression.Expression, tokens);
        }
    }
}
