using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Calculator.Models;

namespace Calculator.Services
{
    public class ReadExpressionFromFile : IExpressionReader
    {
        private readonly string _fileName;

        public ReadExpressionFromFile(string fileName)
        {
            _fileName = fileName;
        }
        public IEnumerable<MathExpression> Read()
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                throw new ArgumentNullException("Received a null or empty file name.");
            }

            List<MathExpression> expressions = new List<MathExpression>();
            if (File.Exists(_fileName))
            {
                using (StreamReader file = new StreamReader(_fileName))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        expressions.Add(new MathExpression(line));
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"File doesn't exists {_fileName}.");
            }

            return expressions;
        }
    }
}
