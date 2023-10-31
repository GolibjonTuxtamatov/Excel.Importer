using System;
using Xeptions;

namespace Excel.Importer.Models.Foundations.ExternalApplicants.Exceptions
{
    public class InvalidExcelFileException : Xeption
    {
        public InvalidExcelFileException(Exception innerException)
            : base("Excel file is invalid",
                 innerException)
        { }
    }
}
