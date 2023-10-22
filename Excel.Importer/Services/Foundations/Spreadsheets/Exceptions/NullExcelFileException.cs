//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Spreadsheets.Exceptions
{
    public class NullExcelFileException : Xeption
    {
        public NullExcelFileException(Exception innerException)
            :base("Excel file some properties are null",
                 innerException)
        { }
    }
}
