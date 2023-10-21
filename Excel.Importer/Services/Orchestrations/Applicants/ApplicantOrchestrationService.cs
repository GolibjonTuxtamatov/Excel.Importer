//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Proccessings.Applicants;

namespace Excel.Importer.Services.Orchestrations.Applicants
{
    public class ApplicantOrchestrationService : IApplicantOrchestrationService
    {
        private readonly IApplicantProccessingService applicantProccessingService;

        public ApplicantOrchestrationService(IApplicantProccessingService applicantProccessingService)
        {
            this.applicantProccessingService = applicantProccessingService;
        }

        public async ValueTask<Applicant> AddApplicantAsync(Applicant applicant)
        {
            return await this.applicantProccessingService.AddApplicantAsync(applicant);
        }
    }
}
