using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;
using Calculator.Interfaces;

namespace Calculator.Services
{
    public class ReadExpressionFromConsole : IExpressionReader
    {
        public IEnumerable<MathExpression> Read()
        {
            Console.Write("Enter the expression: ");
            MathExpression expression = new MathExpression(Console.ReadLine());
            List<MathExpression> expressions = new List<MathExpression>();
            expressions.Add(expression);
            return expressions;
        }
    }
}
