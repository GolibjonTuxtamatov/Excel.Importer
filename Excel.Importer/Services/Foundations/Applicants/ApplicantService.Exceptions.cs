//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Applicants.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private delegate ValueTask<Applicant> ReturningApplicantFunction();

        private async ValueTask<Applicant> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (NullApplicantException nullApplicantException)
            {
                throw CreateAndLogValidationException(nullApplicantException);
            }
            catch (InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }
            catch (SqlException sqlException)
            {
                var failedApplicantStorageException = 
                    new FailedApplicantStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedApplicantStorageException);
            }
        }

        private ApplicantValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantValidaionException =
                new ApplicantValidationException(exception);

            this.loggingBroker.LogError(applicantValidaionException);

            return applicantValidaionException;
        }

        private ApplicantDependencyExcpetion CreateAndLogCriticalDependencyException(Xeption excpetion)
        {
            var applicantDependencyExcpetion = new ApplicantDependencyExcpetion(excpetion);
            this.loggingBroker.LogCritical(applicantDependencyExcpetion);

            return applicantDependencyExcpetion;
        }
    }
}
