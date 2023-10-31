//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.Foundations.ExternalApplicants;
using Excel.Importer.Services.Foundations.Spreadsheets;

namespace Excel.Importer.Services.Proccessings.Spreadsheets
{
    public partial class SpreadsheetProccessingService : ISpreadsheetProccessingService
    {
        private readonly ISpreadsheetService spreadsheetService;
        private readonly ILoggingBroker loggingBroker;

        public SpreadsheetProccessingService(ISpreadsheetService spreadsheetService, ILoggingBroker loggingBroker)
        {
            this.spreadsheetService = spreadsheetService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<ExternalApplicant>> GetExternalApplicantsAsync(MemoryStream spreadsheet) =>
        TryCatch(async () =>
        {
            return await this.spreadsheetService.ImportExternalApplicantAsync(spreadsheet);
        });
    }
}
