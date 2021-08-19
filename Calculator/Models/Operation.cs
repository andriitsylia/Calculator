using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public enum Operation
    {
        Add = 0,
        Subtract= Add,
        Multiply = 1,
        Divide = Multiply,
        LeftBracket = 2,
        RightBracket = LeftBracket,
        End = 3
    }
}
