using Calculator.Models;
using Calculator.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{

    public class ExpressionValidatorTests
    {
        static readonly SourceExpression actualMode1InvalidOperands1 = new("1+x+5");
        static readonly SourceExpression actualMode1InvalidOperands2 = new("1+25+123456789123456789123456789123456789123456789123456789123456789+0");
        static readonly SourceExpression actualMode2InvalidOperands1 = new("1+(x+5)");
        static readonly SourceExpression actualMode2InvalidOperands2 = new("1+(25+123456789123456789123456789123456789123456789123456789123456789)+0");

        static readonly SourceExpression actualMode1DivideByZero1 = new("1+12/0+23");

        static readonly SourceExpression actualMode2InvalidBrackets1 = new("1+((23-18)*12+6+(25/5)+4");
        static readonly SourceExpression actualMode2InvalidBrackets2 = new("1+(23-18)*12+6)+(25/5)+4");

        static readonly SourceExpression actualMode1Valid1 = new("1+2-3*4/5");
        static readonly SourceExpression actualMode2Valid2 = new("(1)*(1)/(1)+(1)-(1)");
        static readonly SourceExpression actualMode2Valid3 = new("((((((((100))))))))+((((((((100))))))))");

        static (bool, string) expectedInvalidOperands = (false, "invalid expression (operands)");
        static (bool, string) expectedDivideByZero = (false, "divide by zero");
        static (bool, string) expectedInvalidBrackets = (false, "invalid expression (brackets)");
        static (bool, string) expectedValid = (true, "");

        private static IEnumerable<TestCaseData> Mode1InvalidExpressionSet()
        {
            yield return new TestCaseData(actualMode1InvalidOperands1, expectedInvalidOperands);
            yield return new TestCaseData(actualMode1InvalidOperands2, expectedInvalidOperands);
            
            yield return new TestCaseData(actualMode1DivideByZero1, expectedDivideByZero);
        }
        private static IEnumerable<TestCaseData> Mode2InvalidExpressionSet()
        {
            yield return new TestCaseData(actualMode2InvalidOperands1, expectedInvalidOperands);
            yield return new TestCaseData(actualMode2InvalidOperands2, expectedInvalidOperands);

            yield return new TestCaseData(actualMode2InvalidBrackets1, expectedInvalidBrackets);
            yield return new TestCaseData(actualMode2InvalidBrackets2, expectedInvalidBrackets);
        }

        private static IEnumerable<TestCaseData> Mode1ValidExpressionSet()
        {
            yield return new TestCaseData(actualMode1Valid1, expectedValid);

        }
        private static IEnumerable<TestCaseData> Mode2ValidExpressionSet()
        {
            yield return new TestCaseData(actualMode2Valid2, expectedValid);
            yield return new TestCaseData(actualMode2Valid3, expectedValid);
        }

        [Test, TestCaseSource("Mode1InvalidExpressionSet")]
        public void ValidateMode1InvalidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().Mode1Validate(actual));
        }

        [Test, TestCaseSource("Mode1ValidExpressionSet")]
        public void ValidateMode1ValidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().Mode1Validate(actual));
        }

        [Test, TestCaseSource("Mode2InvalidExpressionSet")]
        public void ValidateMode2InvalidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().Mode2Validate(actual));
        }

        [Test, TestCaseSource("Mode2ValidExpressionSet")]
        public void ValidateMode2ValidExpressionTests(SourceExpression actual, (bool, string) expected)
        {
            Assert.AreEqual(expected, new ExpressionValidator().Mode2Validate(actual));
        }
    }
}
