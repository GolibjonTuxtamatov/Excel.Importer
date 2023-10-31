//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Applicants;

namespace Excel.Importer.Services.Proccessings.Applicants
{
    public partial class ApplicantProccessingService : IApplicantProccessingService
    {
        private readonly IApplicantService applicantService;
        private readonly ILoggingBroker loggingBroker;
        public ApplicantProccessingService(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant) =>
            TryCatch(async () =>
        {
            return await this.applicantService.AddApplicantAsync(applicant);
        });
    }
}
