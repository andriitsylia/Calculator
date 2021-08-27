using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class SimpleCalculator
    {

        public bool Calculate(MathExpression  expression)
        {
            List<Token> tl = (List<Token>)ParseSimpleExpression.Parse(expression);
            List<Token> tokenList = new List<Token>();
            Token token;
            int i = 0;
            Operation op;
            decimal value;

            while (i < tl.Count)
            {
                value = tl[i].Value;
                op = tl[i].Operation;
                while (op == Operation.Multiply || op == Operation.Divide)
                {
                    if (op == Operation.Multiply)
                    {
                        value *= tl[i + 1].Value;
                    }
                    if (op == Operation.Divide)
                    {
                        if (tl[i + 1].Value != 0)
                        {
                            value /= tl[i + 1].Value;
                        }
                        else
                        {
                            expression.Valid = false;
                            expression.Info = "divide by zero";
                            return expression.Valid;
                        }
                        
                    }
                    op = tl[i + 1].Operation;
                    i++;
                }
                token = new Token(value, op);
                tokenList.Add(token);
                i++;
            }

            i = 0;
            value = tokenList[i].Value;
            while (i < tokenList.Count)
            {
                if (tokenList[i].Operation == Operation.Add)
                {
                    value += tokenList[i + 1].Value;
                }
                if (tokenList[i].Operation == Operation.Subtract)
                {
                    value -= tokenList[i + 1].Value;
                }
                i++;
            }
            expression.Value = value;
            return expression.Valid;
        }
    }
}
