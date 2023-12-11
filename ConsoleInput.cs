using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    public class ConsoleInput
    {
        public ConsoleInput() { }

        public static void GeneratedSuccessfully(int i)
        {
            Console.WriteLine(i + " File generated successfully.");
        }

        public static void Exception(Exception Ex)
        {
            Console.WriteLine(Ex.ToString());
        }

        public static void MergeningIsOver()
        {
            Console.WriteLine("Mergening is over!");
        }

        public static void CompleteProcess() 
        {
            Console.WriteLine("Import process is complete!");
        }

        public static void CountOfImportedRows(int importedRowCount, string filePath)
        {
            Console.WriteLine($"Imported {importedRowCount} rows. Remaining rows: {File.ReadLines(filePath).Count() - importedRowCount}");
        }

        public static void TotalCountOfImportedRows(int importedRowCount, string filePath)
        {
            Console.WriteLine($"Imported data from file {filePath}. Total rows: {importedRowCount}");
        }

        public static void SumAndMedian(decimal sum, decimal median)
        {
            Console.WriteLine($"Sum: {sum}, Median: {median:F8}");
        }
        public static void ChoosingBetweenCombiningImportingAndArithmetic()
        {
            Console.WriteLine("Выберите нужное действие");
            Console.WriteLine($"1 - Объединение файлов в один\n" +
                "2 - Импорт в базу данных\n" +
                "3 - Вычисление суммы и медианы\n" +
                "0 - Выход");
        }
        public static void ExitChoice()
        {
            Console.WriteLine("Bye!");
        }
    }
}
