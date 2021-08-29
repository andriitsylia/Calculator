using Calculator.Models;
using Calculator.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    public class ParseExpressionTests
    {
        static readonly SourceExpression sourceExpression1 = new("1+2-3*4+100/5");
        static readonly SourceExpression sourceExpression2 = new("-1+2-3+-2");
        static readonly SourceExpression sourceExpression3 = new("+1-2+3-+2");

        static readonly ParsedExpression parsedExpression1 = new("1+2-3*4+100/5",
                                                     new List<Token>() {new Token(1, Operation.Add),
                                                                        new Token(2, Operation.Subtract),
                                                                        new Token(3, Operation.Multiply),
                                                                        new Token(4, Operation.Add),
                                                                        new Token(100, Operation.Divide),
                                                                        new Token(5, Operation.End) });
        static readonly ParsedExpression parsedExpression2 = new("-1+2-3+-2",
                                                     new List<Token>() {new Token(-1, Operation.Add),
                                                                        new Token(2, Operation.Subtract),
                                                                        new Token(3, Operation.Add),
                                                                        new Token(-2, Operation.End) });
        static readonly ParsedExpression parsedExpression3 = new("+1-2+3-+2",
                                                     new List<Token>() {new Token(1, Operation.Subtract),
                                                                        new Token(2, Operation.Add),
                                                                        new Token(3, Operation.Subtract),
                                                                        new Token(2, Operation.End) });

        private static IEnumerable<TestCaseData> ParseSet()
        {
            yield return new TestCaseData(sourceExpression1, parsedExpression1);
            yield return new TestCaseData(sourceExpression2, parsedExpression2);
            yield return new TestCaseData(sourceExpression3, parsedExpression3);
        }

        [Test, TestCaseSource("ParseSet")]
        public void ParseTests(SourceExpression actual, ParsedExpression expected)
        {
            ParsedExpression expression = new ParseExpression().Parse(actual);

            Assert.AreEqual(expected.Expression, expression.Expression);
            Assert.AreEqual(expected.Tokens.Count, expression.Tokens.Count);
            for (int i = 0; i < expected.Tokens.Count; i++)
            {
                Assert.AreEqual(expected.Tokens[i].Value, expression.Tokens[i].Value);
                Assert.AreEqual(expected.Tokens[i].Operation, expression.Tokens[i].Operation);
            }
        }
    }
}