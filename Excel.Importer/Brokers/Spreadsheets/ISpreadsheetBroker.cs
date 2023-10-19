//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.ExternalApplicants;

namespace Excel.Importer.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        ValueTask<List<ExternalApplicant>> ReadSpreadsheetAsync(MemoryStream spreadsheet);
    }
}
