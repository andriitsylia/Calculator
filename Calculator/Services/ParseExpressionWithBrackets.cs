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

            Parsing(expression.Expression);
           
        }

        private (decimal, int) Parsing(string expression)
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
                        return (tempExpression.Value, i);
                    }
                    else
                    {
                        simpleString += expression[i];
                    }
                }
                else
                {
                    posBegin = i;
                    (tempValue, posEnd) = Parsing(expression.Substring(i + 1, expression.Length - (i + 1)));
                    i = posBegin + posEnd + 1;
                    simpleString += tempValue.ToString();
                }
                i++;
            }
            Console.WriteLine(simpleString);
            return (0, 0);
        }
    }
}
