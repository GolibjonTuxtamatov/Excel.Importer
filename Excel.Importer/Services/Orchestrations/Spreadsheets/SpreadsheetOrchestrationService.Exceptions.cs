﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Orchestrations.Spreadsheets.Exceptions;
using Excel.Importer.Services.Proccessings.Spreadsheets.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Orchestrations.Spreadsheets
{
    public partial class SpreadsheetOrchestrationService
    {
        private delegate ValueTask<ICollection<Applicant>> ReturningExternalApplicantFunction();

        private async ValueTask<ICollection<Applicant>> TryCatch(ReturningExternalApplicantFunction returningExternalApplicantFunction)
        {
            try
            {
                return await returningExternalApplicantFunction();
            }
            catch (ExcelFileProccessingValidationException excelFileProccessingValidationException)
            {
                throw CreateAndLogOrchestrationValidationException(excelFileProccessingValidationException);
            }
        }

        private ExcelFileOrchestrationValidationException CreateAndLogOrchestrationValidationException(Xeption exception)
        {
            var excelFileOrchestrationValidationException =
                new ExcelFileOrchestrationValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(excelFileOrchestrationValidationException);

            return excelFileOrchestrationValidationException;
        }
    }
}
