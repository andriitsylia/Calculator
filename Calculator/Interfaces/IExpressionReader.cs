using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Interfaces
{
    public interface IExpressionReader
    {
        public IEnumerable<MathExpression> Read();
    }
}
