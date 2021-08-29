using Calculator.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator.Services
{
    public class Worker
    {
        public void Run(int calculatorMode)
        {
            IExpressionReader expressionReader;
            IExpressionPrinter expressionPrinter;
            List<SourceExpression> sourceExpressions;
            List<ServiceExpression> serviceExpressions = new();
            List<ReportExpression> reportExpressions;

            switch (calculatorMode)
            {
                case 1:
                    expressionReader = new ReadExpressionFromConsole();
                    sourceExpressions = (List<SourceExpression>)expressionReader.Read();

                    expressionPrinter = new PrintReportToConsole();

                    foreach (SourceExpression sourceExpression in sourceExpressions)
                    {
                        serviceExpressions.Add(new CalculatorMode1().Calculate(sourceExpression));
                    }
                    reportExpressions = (List<ReportExpression>)new PrepareReportExpression().Prepare(serviceExpressions);
                    expressionPrinter.Print(reportExpressions);
                    break;
                case 2:
                    Console.Write("Enter source file name: ");
                    string sourceFileName = Console.ReadLine();
                    Console.Write("Enter destination file name: ");
                    string destinationFileName = Console.ReadLine();
                    while (File.Exists(destinationFileName))
                    {
                        Console.WriteLine("Such file exists.");
                        Console.Write("Enter another destination file name: ");
                        destinationFileName = Console.ReadLine();
                    }
                    IExpressionReader readFromConsole = new ReadExpressionFromFile(sourceFileName);
                    sourceExpressions = (List<SourceExpression>)readFromConsole.Read();

                    expressionPrinter = new PrintReportToFile(destinationFileName);

                    foreach (SourceExpression sourceExpression in sourceExpressions)
                    {
                        serviceExpressions.Add(new CalculatorMode2().Calculate(sourceExpression));
                    }
                    reportExpressions = (List<ReportExpression>)new PrepareReportExpression().Prepare(serviceExpressions);
                    expressionPrinter.Print(reportExpressions);
                    Console.WriteLine($"File {destinationFileName} was created.");
                    break;
                default:
                    break;
            }
        }
    }
}
