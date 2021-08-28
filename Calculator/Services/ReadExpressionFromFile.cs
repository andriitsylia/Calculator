using Calculator.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator.Services
{
    public class ReadExpressionFromFile : IExpressionReader
    {
        private readonly string _fileName;

        public ReadExpressionFromFile(string fileName)
        {
            _fileName = fileName
                        ?? throw new ArgumentNullException(nameof(fileName), "Received a null argument");
        }
        public IEnumerable<SourceExpression> Read()
        {
            List<SourceExpression> sourceExpressions = new();
            if (File.Exists(_fileName))
            {
                using StreamReader file = new(_fileName);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    sourceExpressions.Add(new SourceExpression(line));
                }
            }
            else
            {
                throw new FileNotFoundException($"File {_fileName} doesn't exists.");
            }
            return sourceExpressions;
        }
    }
}
