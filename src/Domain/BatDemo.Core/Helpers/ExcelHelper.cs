using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace BatDemo.Domain.Core.Helpers
{
    public static class ExcelHelper
    {
        public static DataTable GetDataTableFromExcel(ImportInputModel input,
            List<string> dataColumnDateTime, List<string> dataColumnNumber,
            bool hasHeader = true)
        {
            try
            {
                DataTable tbl = new DataTable();
                List<int> columnDateTime = new List<int>();
                List<int> columnNumber = new List<int>();
                using (var workBook = new XLWorkbook(input.FilePath))
                {
                    //Get first sheet
                    var workSheet = workBook.Worksheet(1);
                    //Get all columns
                    var cols = workSheet.FirstRowUsed().CellsUsed().ToList();
                    foreach (var col in cols)
                    {
                        string columnName = col.Value.ToString();
                        if (!string.IsNullOrEmpty(columnName))
                        {
                            if (dataColumnDateTime.Contains(columnName))
                            {
                                tbl.Columns.Add(columnName, typeof(DateTime));
                            }
                            else if (dataColumnNumber.Contains(columnName))
                            {
                                tbl.Columns.Add(columnName, typeof(long));
                            }
                            else
                            {
                                tbl.Columns.Add(columnName);
                            }
                        }
                    }
                    //Add columns default
                    tbl.Columns.Add("ID", typeof(long));
                    tbl.Columns.Add("BATCH_ID", typeof(long));
                    tbl.Columns.Add("TRANG_THAI");
                    tbl.Columns.Add("NGUOI_DUNG_ID", typeof(long));
                    tbl.Columns.Add("DON_VI_ID", typeof(long));
                    tbl.Columns.Add("NGAY_IMPORT", typeof(DateTime));
                    tbl.Columns.Add("BATCH_GUID");
                    tbl.Columns.Add("KY_DU_LIEU", typeof(DateTime));
                    tbl.Columns.Add("NAM_KY_DU_LIEU", typeof(long));
                    tbl.Columns.Add("THANG_KY_DU_LIEU", typeof(long));
                    tbl.Columns.Add("NGAY_KY_DU_LIEU", typeof(long));

                    //Read data from excel skip header
                    foreach (var r in workSheet.RowsUsed().Skip(1))
                    {
                        var row = tbl.NewRow();
                        for (var i = 0; i < cols.Count; i++)
                        {
                            var colName = cols[i].GetString();
                            var val = r.Cell(i + 1).GetString();
                            if (dataColumnDateTime.Contains(colName))
                            {
                                row[i] = DateTime.ParseExact(val, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            }
                            else if (dataColumnNumber.Contains(colName))
                            {
                                row[i] = long.Parse(val, CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                row[i] = val;
                            }
                        }
                        //Add default value
                        row[row.Table.Columns["BATCH_ID"].Ordinal] = input.BatchId;
                        row[row.Table.Columns["TRANG_THAI"].Ordinal] = "PENDING";
                        row[row.Table.Columns["NGUOI_DUNG_ID"].Ordinal] = input.NguoiDungId;
                        row[row.Table.Columns["DON_VI_ID"].Ordinal] = input.DonViId;
                        row[row.Table.Columns["NGAY_IMPORT"].Ordinal] = DateTime.Now;
                        row[row.Table.Columns["BATCH_GUID"].Ordinal] = input.BatchGuid;
                        row[row.Table.Columns["KY_DU_LIEU"].Ordinal] = input.KyDuLieu;
                        row[row.Table.Columns["NAM_KY_DU_LIEU"].Ordinal] = input.KyDuLieu.Year;
                        row[row.Table.Columns["THANG_KY_DU_LIEU"].Ordinal] = input.KyDuLieu.Month;
                        row[row.Table.Columns["NGAY_KY_DU_LIEU"].Ordinal] = input.KyDuLieu.Day;

                        tbl.Rows.Add(row);
                    }
                }
                return tbl;
            }
            catch
            {
                throw;
            }
        }

        public static List<string> GetAllColumnFromExel(string filePath)
        {
            try
            {
                List<string> lst = new List<string>();
                using (var workBook = new XLWorkbook(filePath))
                {
                    //Get first sheet
                    var workSheet = workBook.Worksheet(1);
                    //Get all columns
                    var cols = workSheet.FirstRowUsed().CellsUsed().ToList();
                    foreach (var col in cols)
                    {
                        if (!string.IsNullOrEmpty(col.Value.ToString()))
                            lst.Add(col.Value.ToString());
                    }
                    return lst;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}






