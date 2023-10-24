//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Applicants.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Applicant> AddApplicantAsync(Applicant applicant)
        {
            try
            {
                if (applicant == null)
                    throw new NullApplicantException();

                return await this.storageBroker.InsertApplicantAsync(applicant);
            }
            catch (NullApplicantException nullApplicantException)
            {
                var applicantValidaionException = new ApplicantValidationException(nullApplicantException);
                this.loggingBroker.LogError(applicantValidaionException);

                throw applicantValidaionException;
            }
        }
    }
}
