//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.ExternalApplicants;
using Excel.Importer.Services.Foundations.Spreadsheets;

namespace Excel.Importer.Services.Proccessings.Spreadsheets
{
    public class SpreadsheetProccessingService : ISpreadsheetProccessingService
    {
        private readonly ISpreadsheetService spreadsheetService;

        public SpreadsheetProccessingService(ISpreadsheetService spreadsheetService)
        {
            this.spreadsheetService = spreadsheetService;
        }

        public ValueTask<List<ExternalApplicant>> GetExternalApplicantsAsync(MemoryStream spreadsheet)
        {
            return this.spreadsheetService.ImportExternalApplicantAsync(spreadsheet);
        }
    }
}
