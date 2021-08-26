using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Services
{
    public class ParseSimpleExpression
    {
        public static IEnumerable<Token> Parse(MathExpression expression)
        {
            List<Token> tokenList = new List<Token>();
            char[] operations = new char[] { '+', '-', '*', '/' };

            string[] values = expression.Expression.Split(operations, StringSplitOptions.TrimEntries);

            int operationPosition = 0;
            int valuesCounter = 0;
            bool isUnarySign = false;
            int multiplicant = 1;
            Token token;
            Operation operation = Operation.End;
            
            while ((operationPosition = expression.Expression.IndexOfAny(operations, operationPosition)) != -1)
            {
                    switch (expression.Expression[operationPosition])
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
                }
                if (!isUnarySign)
                {
                    token = new Token(decimal.Parse(values[valuesCounter++])*multiplicant, operation);
                    tokenList.Add(token);
                    multiplicant = 1;
                }
                operationPosition++;
                isUnarySign = false;
            }
            token = new Token(decimal.Parse(values[valuesCounter])*multiplicant, Operation.End);
            tokenList.Add(token);
            return tokenList;
        }
    }
}
