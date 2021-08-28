using System;
using System.Collections.Generic;

namespace Calculator.Models
{
    public class ParsedExpression
    {
        public string Expression { get; }

        public List<Token> Tokens { get; }

        public ParsedExpression(string expression, List<Token> tokens)
        {
            Expression = expression
                          ?? throw new ArgumentNullException(nameof(expression), "Received a null argument");
            Tokens = tokens
                          ?? throw new ArgumentNullException(nameof(tokens), "Received a null argument");
        }
    }
}
