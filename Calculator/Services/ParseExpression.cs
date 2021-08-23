using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Services
{
    public class ParseExpression
    {
        public static IEnumerable<Token> Parse(MathExpression expression)
        {
            List<Token> tokenList = new List<Token>();
            char[] separators = new char[] { '+', '-', '*', '/' };

            string[] values = expression.Expression.Split(separators, StringSplitOptions.TrimEntries);
            
            int separatorPositionInExpression = 0;
            int itemValuesCounter = 0;
            Token token;
            Operation operation = Operation.End;
            
            while ((separatorPositionInExpression = expression.Expression.IndexOfAny(separators, separatorPositionInExpression)) != -1)
            {
                switch (expression.Expression[separatorPositionInExpression])
                {
                    case '+':
                        operation = Operation.Add;
                        break;
                    case '-':
                        operation = Operation.Subtract;
                        break;
                    case '*':
                        operation = Operation.Multiply;
                        break;
                    case '/':
                        operation = Operation.Divide;
                        break;
                }
                token = new Token(decimal.Parse(values[itemValuesCounter++]), operation);
                tokenList.Add(token);
                separatorPositionInExpression++;
            }
            token = new Token(decimal.Parse(values[itemValuesCounter]), Operation.End);
            tokenList.Add(token);
            return tokenList;
        }
    }
}
