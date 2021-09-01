using Calculator.Models;

namespace Calculator.Services
{
    public class CalculatorWithBrackets
    {
        public ServiceExpression Calculate(SourceExpression sourceExpression)
        {
            ServiceExpression serviceExpression;
            ServiceExpression tempServiceExpression;
            ExpressionValidator validator = new();

            (bool isValidSourceExpression, string info) = validator.ValidateWithBrackets(sourceExpression);

            if (isValidSourceExpression)
            {
                (tempServiceExpression, _) = Parse(sourceExpression.Expression);
                serviceExpression = new ServiceExpression(sourceExpression.Expression, 
                                                          tempServiceExpression.Value, 
                                                          tempServiceExpression.Valid, 
                                                          tempServiceExpression.Info);
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

        private (ServiceExpression, int) Parse(string expression)
        {
            string simpleString = string.Empty;
            int i = 0;
            int posBegin, posEnd;
            SourceExpression sourceExpression;
            ServiceExpression serviceExpression;

            while (i < expression.Length)
            {
                if (expression[i] != '(')
                {
                    if (expression[i] == ')')
                    {
                        sourceExpression = new SourceExpression(simpleString);
                        serviceExpression = new CalculatorWithoutBrackets().Calculate(sourceExpression);
                        return (serviceExpression, i);
                    }
                    else
                    {
                        simpleString += expression[i];
                    }
                }
                else
                {
                    posBegin = i;
                    (serviceExpression, posEnd) = Parse(expression[(i + 1)..]);
                    i = posBegin + posEnd + 1;
                    simpleString += serviceExpression.Value.ToString();
                    if (!serviceExpression.Valid)
                    {
                        return (serviceExpression, posEnd);
                    }
                }
                i++;
            }
            sourceExpression = new SourceExpression(simpleString);
            serviceExpression = new CalculatorWithoutBrackets().Calculate(sourceExpression);
            return (serviceExpression, i);
        }
    }
}
