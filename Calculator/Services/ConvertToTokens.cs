using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Services
{
    public class ConvertToTokens
    {
        public static IEnumerable<Token<float>> Convert(MathExpression expression)
        {
            List<Token<float>> tokenList = new List<Token<float>>();
            char[] separators = new char[] { '+', '-', '*', '/' };

            string[] values = expression.Expression.Split(separators, StringSplitOptions.TrimEntries);
            int pos = 0, i = 0;
            Token<float> token;
            Operation op = Operation.Add;
            while ((pos = expression.Expression.IndexOfAny(separators, pos)) != -1)
            {
                switch (expression.Expression[pos])
                {
                    case '+':
                        op = Operation.Add;
                        break;
                    case '-':
                        op = Operation.Subtract;
                        break;
                    case '*':
                        op = Operation.Multiply;
                        break;
                    case '/':
                        op = Operation.Divide;
                        break;
                }
                token = new Token<float>(float.Parse(values[i++]), op);
                tokenList.Add(token);
                pos++;
            }
            token = new Token<float>(float.Parse(values[i]), Operation.End);
            tokenList.Add(token);
            return tokenList;
        }

        //private string RemoveWhiteSpaces(string line)
        //{
        //    string tempLine = string.Empty;
        //    for (int i = 0; i < line.Length; i++)
        //    {
        //        if (line[i] != ' ')
        //        {
        //            tempLine += (string)line[i];
        //        }
        //    }
        //    return tempLine;
        //}
    }
}
