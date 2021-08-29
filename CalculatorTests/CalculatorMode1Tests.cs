using Calculator.Models;
using Calculator.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    public class CalculatorMode1Tests
    {
        static readonly SourceExpression actualInvalidOperands1 = new("1+x+5");
        static readonly SourceExpression actualInvalidOperands2 = new("1+25+123456789123456789123456789123456789123456789123456789123456789+0");
        static readonly SourceExpression actualDivideByZero1 = new("1+12/0+23");
        static readonly SourceExpression actualValid1 = new("1+2-3*4+100/5");

        static readonly ServiceExpression expectedInvalidOperands1 = new("1+x+5", 0, false, "invalid expression (operands)");
        static readonly ServiceExpression expectedInvalidOperands2 = new("1+25+123456789123456789123456789123456789123456789123456789123456789+0", 0, false, "invalid expression (operands)");
        static readonly ServiceExpression expectedDivideByZero1 = new("1+12/0+23", 0, false, "divide by zero");
        static readonly ServiceExpression expectedValid1 = new("1+2-3*4+100/5", 11, true, "");

        public static IEnumerable<TestCaseData> CalculatorSet()
        {
            yield return new TestCaseData(actualInvalidOperands1, expectedInvalidOperands1);
            yield return new TestCaseData(actualInvalidOperands2, expectedInvalidOperands2);
            yield return new TestCaseData(actualDivideByZero1, expectedDivideByZero1);
            yield return new TestCaseData(actualValid1, expectedValid1);
        }

        [Test, TestCaseSource("CalculatorSet")]
        public void PrepareTest(SourceExpression actual, ServiceExpression expected)
        {
            ServiceExpression expression = new CalculatorMode1().Calculate(actual);
            Assert.AreEqual(expected.Expression, expression.Expression);
            Assert.AreEqual(expected.Value, expression.Value);
            Assert.AreEqual(expected.Valid, expression.Valid);
            Assert.AreEqual(expected.Info, expression.Info);
        }
    }
}
