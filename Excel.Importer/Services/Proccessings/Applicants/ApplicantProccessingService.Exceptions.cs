//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Models.Foundations.Applicants.Exceptions;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
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
            catch (ApplicantDependencyExcpetion applicantDependencyExcpetion)
            {
                throw CreateAndLogProccessingDependencyException(applicantDependencyExcpetion);
            }
            catch (ApplicantDependencyValidationExcpetion applicantDependencyValidationException)
            {
                throw CreateAndLogProccessingDependencyValidationException(applicantDependencyValidationException);
            }
        }

        private ApplicantProccessingValidationException CreateAndLogProccessingValidationException(Xeption exception)
        {
            var applicantProccessingValidationException =
                new ApplicantProccessingValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantProccessingValidationException);

            return applicantProccessingValidationException;
        }

        private ApplicantProccessingDepedencyException CreateAndLogProccessingDependencyException(Xeption exception)
        {
            var applicantProccessingDepedencyException =
                new ApplicantProccessingDepedencyException(exception.InnerException as Xeption);

            this.loggingBroker.LogCritical(applicantProccessingDepedencyException);

            return applicantProccessingDepedencyException;
        }

        private ApplicantProccessingDependencyValidationException CreateAndLogProccessingDependencyValidationException(Xeption exception)
        {
            var applicantProccessingDependencyValidationException =
                new ApplicantProccessingDependencyValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantProccessingDependencyValidationException);

            return applicantProccessingDependencyValidationException;
        }
    }
}
