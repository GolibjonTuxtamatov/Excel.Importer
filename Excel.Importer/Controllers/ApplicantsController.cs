//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Models.Foundations.Applicants.Exceptions;
using Excel.Importer.Services.Orchestrations.Applicants;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantsController : RESTFulController
    {
        private readonly IApplicantOrchestrationService applicantOrchestrationService;

        public ApplicantsController(IApplicantOrchestrationService applicantOrchestrationService)
        {
            this.applicantOrchestrationService = applicantOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Applicant>> PostApplicantAsync(Applicant applicant)
        {
            try
            {
                Applicant postedApplicant = await this.applicantOrchestrationService.AddApplicantAsync(applicant);

                return Created(postedApplicant);
            }
            catch (ApplicantOrchestrationValidationException applicantOrchestrationValidationException)
            {
                return BadRequest(applicantOrchestrationValidationException.InnerException);
            }
            catch (ApplicantOrchetrationDependencyValidationException applicantOrchetrationDependencyValidationException)
                when (applicantOrchetrationDependencyValidationException.InnerException is AlreadyExistApplicantException)
            {
                return Conflict(applicantOrchetrationDependencyValidationException.InnerException);
            }
            catch (ApplicantOrchetrationDependencyValidationException applicantOrchetrationDependencyValidationException)
            {
                return Conflict(applicantOrchetrationDependencyValidationException.InnerException);
            }
            catch (ApplicantOrchestrationDependencyException applicantOrchestrationDependencyException)
            {
                return InternalServerError(applicantOrchestrationDependencyException.InnerException);
            }
            catch (ApplicantOrchestrationServiceException applicantOrchestrationServiceException)
            {
                return InternalServerError(applicantOrchestrationServiceException.InnerException);
            }
        }
    }
}
