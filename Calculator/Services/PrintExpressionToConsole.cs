using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Calculator.Models;

namespace Calculator.Services
{
    public class PrintExpressionToConsole : IExpressionPrinter
    {
        public void Print(MathExpression expression)
        {
            if (expression.Valid)
            {
                Console.WriteLine($"{expression.Expression} = {expression.Value}");
            }
            else
            {
                Console.WriteLine($"{expression.Expression} = {expression.Info}");
            }
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
