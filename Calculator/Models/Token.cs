namespace Calculator.Models
{
    public class Token
    {
        public decimal Value { get; }

        public Operation Operation { get; }

        public Token(decimal value, Operation operation)
        {
            Value = value;
            Operation = operation;
        }
    }
}
