//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Excel.Importer.Services.Foundations.Spreadsheets.Exceptions
{
    public class ExcelFileValidationException : Xeption
    {
        public ExcelFileValidationException(Xeption innerException)
            : base("Excel file validation error occured, fix the error and try again",
                 innerException)
        { }
    }
}
