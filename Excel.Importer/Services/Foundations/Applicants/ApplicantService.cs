//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Applicants;

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
            throw new System.NotImplementedException();
        }
    }
}
