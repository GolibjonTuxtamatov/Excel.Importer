﻿//===========================
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
            catch (ApplicantProccessingDependencyException applicantProccessingDependencyException)
            {
                throw CreateAndLogOrchetrationDependencyException(applicantProccessingDependencyException);
            }
            catch (ApplicantProccessingDependencyValidationException applicantProccessingDependencyValidationException)
            {
                throw CreateAndLogOrchetrationDependencyValidationException(
                    applicantProccessingDependencyValidationException);
            }
            catch (ApplicantProccessingServiceException applicantProccessingServiceException)
            {
                throw CreateAndLogOrchetrationServiceException(applicantProccessingServiceException);
            }
        }

        private ApplicantOrchestrationValidationException CreateAndLogOrchetrationValidationException(Xeption exception)
        {
            var applicantOrchestrationValidationException =
                new ApplicantOrchestrationValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantOrchestrationValidationException);

            return applicantOrchestrationValidationException;
        }

        private ApplicantOrchestrationDependencyException CreateAndLogOrchetrationDependencyException(Xeption exception)
        {
            var applicantOrchestrationDependencyException =
                new ApplicantOrchestrationDependencyException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantOrchestrationDependencyException);

            return applicantOrchestrationDependencyException;
        }

        private ApplicantOrchetrationDependencyValidationException CreateAndLogOrchetrationDependencyValidationException(Xeption exception)
        {
            var applicantOrchetrationDependencyValidationException =
                new ApplicantOrchetrationDependencyValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantOrchetrationDependencyValidationException);

            return applicantOrchetrationDependencyValidationException;
        }

        private ApplicantOrchestrationServiceException CreateAndLogOrchetrationServiceException(Xeption exception)
        {
            var applicantOrchestrationServiceException =
                new ApplicantOrchestrationServiceException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(applicantOrchestrationServiceException);

            return applicantOrchestrationServiceException;
        }
    }
}
