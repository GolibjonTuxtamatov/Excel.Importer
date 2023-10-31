//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Models.Foundations.Applicants.Exceptions;
using Excel.Importer.Services.Proccessings.Groups.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Proccessings.Applicants
{
    public partial class ApplicantProccessingService
    {
        private delegate ValueTask<Applicant> ReturningApplicantFunction();

        private async ValueTask<Applicant> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch(ApplicantValidationException applicantValidationException)
            {
                throw CreateAndLogProccessingValidationException(applicantValidationException);
            }
        }

        private ApplicantProccessingValidationException CreateAndLogProccessingValidationException(Xeption exception)
        {
            var applicantProccessingValidationException =
                new ApplicantProccessingValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantProccessingValidationException);

            return applicantProccessingValidationException;
        }
    }
}
