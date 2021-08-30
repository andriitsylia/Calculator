using Calculator.Models;
using Calculator.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    public class PrepareReportExpressionTests
    {

        static readonly ServiceExpression serviceExpressionValid = new("1+2-3*4+100/5", 11, true, "valid expression");
        static readonly ServiceExpression serviceExpressionInValid1 = new("1+x+5", 0, false, "invalid expression (operands)");
        static readonly ServiceExpression serviceExpressionInValid2 = new("1+12/0+23", 0, false, "divide by zero");
        static readonly ServiceExpression serviceExpressionInValid3 = new("1+((23-18)*12+6+(25/5)+4", 0, false, "invalid expression (brackets)");

        static readonly ReportExpression reportExpressionValid = new("1+2-3*4+100/5 = 11");
        static readonly ReportExpression reportExpressionInValid1 = new("1+x+5 = invalid expression (operands)");
        static readonly ReportExpression reportExpressionInValid2 = new("1+12/0+23 = divide by zero");
        static readonly ReportExpression reportExpressionInValid3 = new("1+((23-18)*12+6+(25/5)+4 = invalid expression (brackets)");

        static readonly List<ServiceExpression> serviceExpressions = new() { serviceExpressionValid ,
                                                                    serviceExpressionInValid1,
                                                                    serviceExpressionInValid2,
                                                                    serviceExpressionInValid3 };
        
        static readonly List<ReportExpression> reportExpressions = new() { reportExpressionValid ,
                                                                  reportExpressionInValid1,
                                                                  reportExpressionInValid2,
                                                                  reportExpressionInValid3 };

        public static IEnumerable<TestCaseData> ReportSet()
        { 
            yield return new TestCaseData(serviceExpressions, reportExpressions);
        }

        [Test, TestCaseSource("ReportSet")]
        public void PrepareTests(List<ServiceExpression> actual, List<ReportExpression> expected)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                List<ReportExpression> expressions =  (List<ReportExpression>)new PrepareReportExpression().Prepare(actual);
                Assert.AreEqual(expected[i].Expression, expressions[i].Expression);
            }
        }
    }
}
