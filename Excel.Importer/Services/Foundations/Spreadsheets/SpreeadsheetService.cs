//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Spreadsheets;
using Excel.Importer.Models.Foundations.ExternalApplicants;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public class SpreeadsheetService : ISpreeadsheetService
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;

        public SpreeadsheetService(ISpreadsheetBroker spreadsheetBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
        }

        public ValueTask<List<ExternalApplicant>> ImportExternalApplicantAsync(MemoryStream spreadsheet)
        {
            return this.spreadsheetBroker.ReadSpreadsheetAsync(spreadsheet);   
        }
    }
}
