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
using Excel.Importer.Services.Foundations.Spreadsheets.Exceptions;
using Excel.Importer.Services.Proccessings.Spreadsheets.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Proccessings.Spreadsheets
{
    public class SpreadsheetProccessingService : ISpreadsheetProccessingService
    {
        private readonly ISpreadsheetService spreadsheetService;
        private readonly ILoggingBroker loggingBroker;

        public SpreadsheetProccessingService(ISpreadsheetService spreadsheetService,ILoggingBroker loggingBroker)
        {
            this.spreadsheetService = spreadsheetService;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<List<ExternalApplicant>> GetExternalApplicantsAsync(MemoryStream spreadsheet)
        {
            try
            {
                return await this.spreadsheetService.ImportExternalApplicantAsync(spreadsheet);
            }
            catch (ExcelFileValidationException excelFileValidationException)
            {
                throw CreateAndLogProccessingValidationException(excelFileValidationException);
            }
        }

        private ExcelFileProccessingValidationException CreateAndLogProccessingValidationException(Xeption exception)
        {
            var excelFileProccessingValidationException =
                new ExcelFileProccessingValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(excelFileProccessingValidationException);

            return excelFileProccessingValidationException;
        }
    }
}
