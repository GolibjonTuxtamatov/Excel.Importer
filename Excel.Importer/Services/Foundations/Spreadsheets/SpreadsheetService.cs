using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Spreadsheets;
using Excel.Importer.Models.Foundations.ExternalApplicants;
using Excel.Importer.Services.Foundations.Spreadsheets.Exceptions;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public partial class SpreadsheetService : ISpreadsheetService
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;
        private readonly ILoggingBroker loggingBroker;

        public SpreadsheetService(ISpreadsheetBroker spreadsheetBroker, ILoggingBroker loggingBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<ExternalApplicant>> ImportExternalApplicantAsync(MemoryStream spreasheet) =>
            TryCatch(async () =>
            {
                return await this.spreadsheetBroker.ReadSpreadsheetAsync(spreasheet);
            });
        
    }
}
