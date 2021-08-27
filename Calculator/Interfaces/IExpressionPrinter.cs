using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Interfaces
{
    public interface IExpressionPrinter
    {
        public void Print(MathExpression expression);
        public void Print(IEnumerable<MathExpression> expressions);
        public void Print(string message);
    }
}
