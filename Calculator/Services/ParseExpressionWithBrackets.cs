using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class ParseExpressionWithBrackets
    {
        public void Parse(MathExpression expression)
        {

            (expression.Value, _, expression.Valid) = Parsing(expression.Expression);
           
        }

        private (decimal, int, bool) Parsing(string expression)
        {
            char[] separators = new char[] { '+', '-', '*', '/', '(', ')' };
            string simpleString=string.Empty;
            int i = 0;
            int posBegin = 0, posEnd = 0;
            decimal tempValue;
            MathExpression tempExpression;

            while (i < expression.Length)
            {
                if (expression[i] != '(')
                {
                    if (expression[i] == ')')
                    {
                        tempExpression = new MathExpression(simpleString);
                        _ = new SimpleCalculator().Calculate(tempExpression);
                        return (tempExpression.Value, i, tempExpression.Valid);
                    }
                    else
                    {
                        simpleString += expression[i];
                    }
                }
                else
                {
                    posBegin = i;
                    (tempValue, posEnd, _) = Parsing(expression.Substring(i + 1, expression.Length - (i + 1)));
                    i = posBegin + posEnd + 1;
                    simpleString += tempValue.ToString();
                }
                i++;
            }
            tempExpression = new MathExpression(simpleString);
            _ = new SimpleCalculator().Calculate(tempExpression);
            return (tempExpression.Value, i, tempExpression.Valid);
        }
    }
}
