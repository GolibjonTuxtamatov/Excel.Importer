using System;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Spreadsheets.Exceptions
{
    public class InvalidExcelFileException : Xeption
    {
        public InvalidExcelFileException(Exception innerException)
            :base("Excel file is invalid",
                 innerException)
        { }
    }
}
