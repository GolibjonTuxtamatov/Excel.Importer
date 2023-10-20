//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Applicants;

namespace Excel.Importer.Services.Foundations.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;

        public ApplicantService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant)
        {
            return this.storageBroker.InsertApplicantAsync(applicant);
        }
    }
}
