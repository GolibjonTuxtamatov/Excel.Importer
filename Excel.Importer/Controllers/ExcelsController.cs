//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Orchestrations.Spreadsheets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcelsController : RESTFulController
    {
        private readonly ISpreadsheetOrchestrationService spreadsheetOrchestrationService;

        public ExcelsController(ISpreadsheetOrchestrationService spreadsheetOrchestrationService)
        {
            this.spreadsheetOrchestrationService = spreadsheetOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ICollection<Applicant>>> ImportExternalApplicant(IFormFile formFile)
        {
            if (formFile == null)
                return BadRequest("File is null");
            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);

            ICollection<Applicant> posetdApplicants =
                await this.spreadsheetOrchestrationService.ImportExternalApplicants(memoryStream);

            return Created(posetdApplicants);
        }
    }
}
