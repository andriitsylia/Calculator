using Calculator.Models;

namespace Calculator.Services
{
    public class CalculatorMode2
    {
        public ServiceExpression Calculate(SourceExpression sourceExpression)
        {
            ServiceExpression serviceExpression;
            ServiceExpression tempServiceExpression;
            ExpressionValidator validator = new();

            (bool isValidSourceExpression, string info) = validator.Mode2Validate(sourceExpression);

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
                        serviceExpression = new CalculatorMode1().Calculate(sourceExpression);
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
                }
                i++;
            }
            sourceExpression = new SourceExpression(simpleString);
            serviceExpression = new CalculatorMode1().Calculate(sourceExpression);
            return (serviceExpression, i);
        }
    }
}
