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

            try
            {
                switch (calculatorMode)
                {
                    case 1:
                        expressionReader = new ReadExpressionFromConsole();
                        sourceExpressions = (List<SourceExpression>)expressionReader.Read();

                        expressionPrinter = new PrintReportToConsole();

                        foreach (SourceExpression sourceExpression in sourceExpressions)
                        {
                            serviceExpressions.Add(new CalculatorWithoutBrackets().Calculate(sourceExpression));
                        }
                        reportExpressions = (List<ReportExpression>)new PrepareReportExpression().Prepare(serviceExpressions);
                        expressionPrinter.Print(reportExpressions);
                        break;
                    case 2:
                        Console.Write("Enter source file name: ");
                        string sourceFileName = Console.ReadLine();
                        Console.Write("Enter destination file name: ");
                        string destinationFileName = Console.ReadLine();
                        bool appendDestinationFile = false;
                        while (File.Exists(destinationFileName))
                        {
                            Console.Write("Such file exists. (A)ppend/(O)verwrite/Create new file?: ");
                            string answer = Console.ReadLine();
                            if (answer.ToUpper() == "A")
                            {
                                appendDestinationFile = true;
                                Console.WriteLine($"File {destinationFileName} will be appended.");
                                break;
                            }
                            if (answer.ToUpper() == "O")
                            {
                                appendDestinationFile = false;
                                Console.WriteLine($"File {destinationFileName} will be overwritten.");
                                break;
                            }
                            Console.Write("Enter another destination file name: ");
                            destinationFileName = Console.ReadLine();
                        }
                        IExpressionReader readFromConsole = new ReadExpressionFromFile(sourceFileName);
                        sourceExpressions = (List<SourceExpression>)readFromConsole.Read();

                        expressionPrinter = new PrintReportToFile(destinationFileName, appendDestinationFile);

                        foreach (SourceExpression sourceExpression in sourceExpressions)
                        {
                            serviceExpressions.Add(new CalculatorWithBrackets().Calculate(sourceExpression));
                        }
                        reportExpressions = (List<ReportExpression>)new PrepareReportExpression().Prepare(serviceExpressions);
                        expressionPrinter.Print(reportExpressions);
                        Console.WriteLine($"File {destinationFileName} was created.");
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                Console.WriteLine($"StackTrace information: {e.StackTrace}");
            }
        }
    }
}
