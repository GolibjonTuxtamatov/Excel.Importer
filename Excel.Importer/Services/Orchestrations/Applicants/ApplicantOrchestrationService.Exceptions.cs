//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Models.Foundations.Applicants.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Orchestrations.Applicants
{
    public partial class ApplicantOrchestrationService
    {
        private delegate ValueTask<Applicant> ReturningApplicantFunction();

        private async ValueTask<Applicant> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (ApplicantProccessingValidationException applicantProccessingValidationException)
            {
                throw CreateAndLogOrchetrationValidationException(applicantProccessingValidationException);
            }
        }

        private ApplicantOrchestrationValidationException CreateAndLogOrchetrationValidationException(Xeption exception)
        {
            var applicantOrchestrationValidationException =
                new ApplicantOrchestrationValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantOrchestrationValidationException);

            return applicantOrchestrationValidationException;
        }
    }
}
