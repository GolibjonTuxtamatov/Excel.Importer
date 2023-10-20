using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Spreadsheets;
using Excel.Importer.Models.Foundations.ExternalApplicants;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public class SpreadsheetService : ISpreadsheetService
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;
        public ValueTask<List<ExternalApplicant>> ImportExternalApplicantAsync(MemoryStream spreasheet)
        {
            return this.spreadsheetBroker.ReadSpreadsheetAsync(spreasheet);
        }
    }
}
