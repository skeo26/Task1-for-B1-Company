using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal class WorkWithDB
    {
        const int batchSize = 100000;

        public void ImportFileToDatabase(string filePath, string connectionString)
        {
            int importedRowCount = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.DestinationTableName = "RandomData";

                        using (var reader = new StreamReader(filePath))
                        {
                            var dataTable = new DataTable();
                            dataTable.Columns.Add("DateColumn", typeof(DateTime));
                            dataTable.Columns.Add("LatinColumn", typeof(string));
                            dataTable.Columns.Add("RussianColumn", typeof(string));
                            dataTable.Columns.Add("IntegerColumn", typeof(int));
                            dataTable.Columns.Add("FloatColumn", typeof(double));

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var fields = line.Split("||");

                                dataTable.Rows.Add(
                                    DateTime.Parse(fields[0]),
                                    fields[1],
                                    fields[2],
                                    int.Parse(fields[3]),
                                    double.Parse(fields[4], CultureInfo.InvariantCulture)
                                );

                                importedRowCount++;

                                if (importedRowCount % batchSize == 0)
                                {
                                    bulkCopy.WriteToServer(dataTable);
                                    dataTable.Rows.Clear();
                                    ConsoleInput.CountOfImportedRows(importedRowCount, filePath);
                                }
                            }

                            if (dataTable.Rows.Count > 0)
                            {
                                bulkCopy.WriteToServer(dataTable);
                            }
                        }
                    }

                    transaction.Commit();
                }
            }

            ConsoleInput.TotalCountOfImportedRows(importedRowCount, filePath);
        }

        public void ExecuteGetSumAndMedianProcedure(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {

                    command.CommandTimeout = 300; // 300 секунд (5 минут), увеличьте при необходимости

                    command.CommandText = "CalculateSumAndMedian";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Обработка данных, как и раньше
                            decimal sum = reader.GetDecimal(0);
                            decimal median = reader.GetDecimal(1);

                            ConsoleInput.SumAndMedian(sum, median);
                        }
                    }
                }
            }
        }
    }
}
