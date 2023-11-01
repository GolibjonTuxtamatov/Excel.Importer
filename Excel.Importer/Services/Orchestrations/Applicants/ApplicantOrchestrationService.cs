//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Proccessings.Applicants;

namespace Excel.Importer.Services.Orchestrations.Applicants
{
    public partial class ApplicantOrchestrationService : IApplicantOrchestrationService
    {
        private readonly IApplicantProccessingService applicantProccessingService;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantOrchestrationService(IApplicantProccessingService applicantProccessingService, ILoggingBroker loggingBroker)
        {
            this.applicantProccessingService = applicantProccessingService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant) =>
        TryCatch(async () =>
        {
            return await this.applicantProccessingService.AddApplicantAsync(applicant);
        });
    }
}
