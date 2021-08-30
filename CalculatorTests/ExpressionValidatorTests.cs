using Calculator.Models;
using Calculator.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{

    public class ExpressionValidatorTests
    {
        static readonly SourceExpression actualWithoutBracketsInvalidOperands1 = new("1+x+5");
        static readonly SourceExpression actualWithoutBracketsInvalidOperands2 = new("1+25+123456789123456789123456789123456789123456789123456789123456789+0");
        static readonly SourceExpression actualWithoutBracketsDivideByZero1 = new("1+12/0+23");
        static readonly SourceExpression actualWithoutBracketsValid1 = new("1+2-3*4/5");

        static readonly SourceExpression actualWithBracketsInvalidOperands1 = new("1+(x+5)");
        static readonly SourceExpression actualWithBracketsInvalidOperands2 = new("1+(25+123456789123456789123456789123456789123456789123456789123456789)+0");
        static readonly SourceExpression actualWithBracketsInvalidBrackets1 = new("1+((23-18)*12+6+(25/5)+4");
        static readonly SourceExpression actualWithBracketsInvalidBrackets2 = new("1+(23-18)*12+6)+(25/5)+4");
        static readonly SourceExpression actualWithBracketsValid2 = new("(1)*(1)/(1)+(1)-(1)");
        static readonly SourceExpression actualWithBracketsValid3 = new("((((((((100))))))))+((((((((100))))))))");

        static (bool, string) expectedInvalidOperands = (false, "invalid expression (operands)");
        static (bool, string) expectedDivideByZero = (false, "divide by zero");
        static (bool, string) expectedInvalidBrackets = (false, "invalid expression (brackets)");
        static (bool, string) expectedValid = (true, "valid expression");

        private static IEnumerable<TestCaseData> WithoutBracketsInvalidExpressionSet()
        {
            yield return new TestCaseData(actualWithoutBracketsInvalidOperands1, expectedInvalidOperands);
            yield return new TestCaseData(actualWithoutBracketsInvalidOperands2, expectedInvalidOperands);
            
            yield return new TestCaseData(actualWithoutBracketsDivideByZero1, expectedDivideByZero);
        }
        private static IEnumerable<TestCaseData> WithBracketsInvalidExpressionSet()
        {
            yield return new TestCaseData(actualWithBracketsInvalidOperands1, expectedInvalidOperands);
            yield return new TestCaseData(actualWithBracketsInvalidOperands2, expectedInvalidOperands);

            yield return new TestCaseData(actualWithBracketsInvalidBrackets1, expectedInvalidBrackets);
            yield return new TestCaseData(actualWithBracketsInvalidBrackets2, expectedInvalidBrackets);
        }

        private static IEnumerable<TestCaseData> WithoutBracketsValidExpressionSet()
        {
            yield return new TestCaseData(actualWithoutBracketsValid1, expectedValid);

        }
        private static IEnumerable<TestCaseData> WithBracketsValidExpressionSet()
        {
            yield return new TestCaseData(actualWithBracketsValid2, expectedValid);
            yield return new TestCaseData(actualWithBracketsValid3, expectedValid);
        }

        [Test, TestCaseSource("WithoutBracketsInvalidExpressionSet")]
        public void ValidateWithoutBracketsInvalidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().ValidateWithoutBrackets(actual));
        }

        [Test, TestCaseSource("WithoutBracketsValidExpressionSet")]
        public void ValidateWithoutBracketsValidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().ValidateWithoutBrackets(actual));
        }

        [Test, TestCaseSource("WithBracketsInvalidExpressionSet")]
        public void ValidateWithBracketsInvalidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().ValidateWithBrackets(actual));
        }

        [Test, TestCaseSource("WithBracketsValidExpressionSet")]
        public void ValidateWithBracketsValidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().ValidateWithBrackets(actual));
        }
    }
}
