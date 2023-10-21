//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Applicants;

namespace Excel.Importer.Services.Proccessings.Applicants
{
    public class ApplicantProccessingService : IApplicantProccessingService
    {
        private readonly IApplicantService applicantService;

        public ApplicantProccessingService(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant)
        {
            return this.applicantService.AddApplicantAsync(applicant);
        }
    }
}
