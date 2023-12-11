using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Testovoe;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        WorkWithFiles workWithFiles = new WorkWithFiles();
        WorkWithDB workWithDB = new WorkWithDB();
        string filePath = @"D:\TEST";
        Random rnd = new Random();
        int fileCount = 100;
        int countOfLines = 100000;
        string connectionString = "Data Source=LAPTOP-9UFILKK7\\SQLEXPRESS;Initial Catalog=RandomData;Integrated Security=True;";

        for (int i = 0; i < fileCount; i++)
        {
            try
            {
                workWithFiles.GenerateFileWithRandomData(countOfLines, rnd, i);
            }
            catch (Exception Ex)
            {
                ConsoleInput.Exception(Ex);
            }
        }
        while(true)
        {
            ConsoleInput.ChoosingBetweenCombiningImportingAndArithmetic();
            string temp = Console.ReadLine();
            if (temp == "1")
            {
                workWithFiles.MergeFiles(@"D:\TEST\MergeFile.txt", "abc");
                ConsoleInput.MergeningIsOver();
            }
            else if (temp == "2")
            {
                foreach (var file in Directory.GetFiles(filePath, "file_*.txt"))
                {
                    workWithDB.ImportFileToDatabase(file, connectionString);
                }
            }
            else if (temp == "3")
            {
                ConsoleInput.CompleteProcess();
                workWithDB.ExecuteGetSumAndMedianProcedure(connectionString);
            }
            else if (temp == "0") 
            {
                ConsoleInput.ExitChoice();
                break;
            }
            else
            {
                ConsoleInput.ExitChoice();
                break;
            }
        }
    }
}