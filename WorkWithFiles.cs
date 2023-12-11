using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal class WorkWithFiles
    {
        private string filePath = @"D:\TEST";

        public void GenerateFileWithRandomData(int countOfLines, Random rnd, int i)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, $"file_{i}.txt")))
            {
                for (int j = 0; j < countOfLines; j++)
                {
                    GenerateData gn = new GenerateData(rnd);
                    string line = $"{gn.Date}||{gn.LatinSymbols}||{gn.RussianSymbols}||{gn.RandomIntNumber}||{gn.RandomDoubleNumber:F8}||";
                    writer.WriteLine(line);
                }
                ConsoleInput.GeneratedSuccessfully(i);
            }
        }
        public void MergeFiles(string outputFilePath, string patternToRemoves)
        {
            string[] files = Directory.GetFiles(filePath, "file_*.txt");
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string file in files)
                {
                    string[] lines = File.ReadAllLines(file);
                    lines = lines.Where(line => !line.Contains(patternToRemoves)).ToArray();
                    writer.WriteLine(string.Join(Environment.NewLine, lines));
                }
            }
        }
    }
}
