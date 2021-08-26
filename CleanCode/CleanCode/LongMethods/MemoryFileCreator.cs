using System;
using System.Data;
using System.IO;

namespace CleanCode.LongMethods
{
    public class DataTableToCsvMapper
    {
        public MemoryStream Map(DataTable dataTable)
        {
            var returnStream = new MemoryStream();
            var streamWriter = new StreamWriter(returnStream);
            WriteColumnNames(dataTable, streamWriter);
            WriteDataRows(dataTable, streamWriter);

            return returnStream;
        }

        private static void WriteDataRows(DataTable dataTable, StreamWriter streamWriter)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                WriteRow(dataTable, dr, streamWriter);
                streamWriter.WriteLine();
            }

            streamWriter.Flush();
            streamWriter.Close();
        }

        private static void WriteRow(DataTable dataTable, DataRow dataRow, StreamWriter streamWriter)
        {
            for (var index = 0; index < dataTable.Columns.Count; index++)
            {
                WriteCell(dataRow, index, streamWriter);
                WriteSeparator(dataTable, index, streamWriter);
            }
        }

        private static void WriteSeparator(DataTable data, int index, StreamWriter streamWriter)
        {
            if (index < data.Columns.Count - 1)
            {
                streamWriter.Write(",");
            }
        }

        private static void WriteCell(DataRow dataRow, int index, StreamWriter streamWriter)
        {
            if (!Convert.IsDBNull(dataRow[index]))
            {
                var str = $"\"{dataRow[index].ToString():c}\"".Replace("\r\n", " ");
                streamWriter.Write(str);
            }
            else
            {
                streamWriter.Write("");
            }
        }

        private static void WriteColumnNames(DataTable dataTable, StreamWriter streamWriter)
        {
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                streamWriter.Write(dataTable.Columns[i]);
                if (i < dataTable.Columns.Count - 1)
                {
                    streamWriter.Write(",");
                }
            }

            streamWriter.WriteLine();
        }

    }
}