using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Services
{
    public class CalculatorWithoutBrackets
    {
        public ServiceExpression Calculate(SourceExpression sourceExpression)
        {
            ServiceExpression serviceExpression;
            ExpressionValidator validator = new();
            
            (bool isValidSourceExpression, string info) = validator.ValidateWithoutBrackets(sourceExpression);
            
            if (isValidSourceExpression)
            {
                ParsedExpression parsedExpression = new ParseExpression().Parse(sourceExpression);

                List<Token> tokens = new();
                int i = 0;
                Operation op;
                decimal value;

                while (i < parsedExpression.Tokens.Count)
                {
                    value = parsedExpression.Tokens[i].Value;
                    op = parsedExpression.Tokens[i].Operation;

                    while (op == Operation.Multiply || op == Operation.Divide)
                    {
                        if (op == Operation.Multiply)
                        {
                            value *= parsedExpression.Tokens[i + 1].Value;
                        }
                        if (op == Operation.Divide)
                        {
                            value /= parsedExpression.Tokens[i + 1].Value;
                        }
                        op = parsedExpression.Tokens[i + 1].Operation;
                        i++;
                    }
                    tokens.Add(new Token(value, op));
                    i++;
                }

                i = 0;
                value = tokens[i].Value;
                while (i < tokens.Count)
                {
                    if (tokens[i].Operation == Operation.Add)
                    {
                        value += tokens[i + 1].Value;
                    }
                    if (tokens[i].Operation == Operation.Subtract)
                    {
                        value -= tokens[i + 1].Value;
                    }
                    i++;
                }
                serviceExpression = new ServiceExpression(parsedExpression.Expression,
                                                          value,
                                                          true,
                                                          info);
            }
            else
            {
                serviceExpression = new ServiceExpression(sourceExpression.Expression,
                                                          decimal.Zero,
                                                          false,
                                                          info);
            }
            return serviceExpression;
        }
    }
}
