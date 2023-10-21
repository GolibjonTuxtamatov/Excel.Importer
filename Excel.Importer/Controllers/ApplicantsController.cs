//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Orchestrations.Applicants;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantsController : RESTFulController
    {
        private IApplicantOrchestrationService applicantOrchestrationService;

        public ApplicantsController(IApplicantOrchestrationService applicantOrchestrationService)
        {
            this.applicantOrchestrationService = applicantOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<Applicant> PostGroupAsync(Applicant applicant)
        {
            return await this.applicantOrchestrationService.AddApplicantAsync(applicant);
        }
    }
}
