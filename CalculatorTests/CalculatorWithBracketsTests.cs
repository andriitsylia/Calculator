using Calculator.Models;
using Calculator.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    public class CalculatorWithBracketsTests
    {
        static readonly SourceExpression actualInvalidOperands1 = new("1+x+5");
        static readonly SourceExpression actualInvalidOperands2 = new("1+25+123456789123456789123456789123456789123456789123456789123456789+0");
        static readonly SourceExpression actualInvalidBrackets1 = new("1+((23-18)*12+6+(25/5)+4");
        static readonly SourceExpression actualInvalidBrackets2 = new("1+(23-18)*12+6)+(25/5)+4");

        static readonly SourceExpression actualValid1 = new("1+2-3*4+100/5");
        static readonly SourceExpression actualValid2 = new("(1)*(1)/(1)+(1)-(1)");
        static readonly SourceExpression actualValid3 = new("((((((((100))))))))+((((((((100))))))))");

        static readonly ServiceExpression expectedInvalidOperands1 = new("1+x+5", 0, false, "invalid expression (operands)");
        static readonly ServiceExpression expectedInvalidOperands2 = new("1+25+123456789123456789123456789123456789123456789123456789123456789+0", 0, false, "invalid expression (operands)");
        static readonly ServiceExpression expectedInvalidBrackets1 = new("1+((23-18)*12+6+(25/5)+4", 0, false, "invalid expression (brackets)");
        static readonly ServiceExpression expectedInvalidBrackets2 = new("1+(23-18)*12+6)+(25/5)+4", 0, false, "invalid expression (brackets)");

        static readonly ServiceExpression expectedValid1 = new("1+2-3*4+100/5", 11, true, "valid expression");
        static readonly ServiceExpression expectedValid2 = new("(1)*(1)/(1)+(1)-(1)", 1, true, "valid expression");
        static readonly ServiceExpression expectedValid3 = new("((((((((100))))))))+((((((((100))))))))", 200, true, "valid expression");


        public static IEnumerable<TestCaseData> CalculatorSet()
        {
            yield return new TestCaseData(actualInvalidOperands1, expectedInvalidOperands1);
            yield return new TestCaseData(actualInvalidOperands2, expectedInvalidOperands2);
            yield return new TestCaseData(actualInvalidBrackets1, expectedInvalidBrackets1);
            yield return new TestCaseData(actualInvalidBrackets2, expectedInvalidBrackets2);
            yield return new TestCaseData(actualValid1, expectedValid1);
            yield return new TestCaseData(actualValid2, expectedValid2);
            yield return new TestCaseData(actualValid3, expectedValid3);
        }

        [Test, TestCaseSource("CalculatorSet")]
        public void PrepareTest(SourceExpression actual, ServiceExpression expected)
        {
            ServiceExpression expression = new CalculatorWithBrackets().Calculate(actual);
            Assert.AreEqual(expected.Expression, expression.Expression);
            Assert.AreEqual(expected.Value, expression.Value);
            Assert.AreEqual(expected.Valid, expression.Valid);
            Assert.AreEqual(expected.Info, expression.Info);
        }
    }
}
