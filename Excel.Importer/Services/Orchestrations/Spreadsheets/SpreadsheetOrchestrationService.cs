//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Models.Foundations.ExternalApplicants;
using Excel.Importer.Services.Proccessings.Applicants;
using Excel.Importer.Services.Proccessings.Groups;
using Excel.Importer.Services.Proccessings.Spreadsheets;

namespace Excel.Importer.Services.Orchestrations.Spreadsheets
{
    public class SpreadsheetOrchestrationService : ISpreadsheetOrchestrationService
    {
        private readonly ISpreadsheetProccessingService spreadsheetProccessingService;
        private readonly IApplicantProccessingService applicantProccessingService;
        private readonly IGroupProccessingService groupProccessingService;

        public SpreadsheetOrchestrationService(
            ISpreadsheetProccessingService spreadsheetProccessingService,
            IApplicantProccessingService applicantProccessingService,
            IGroupProccessingService groupProccessingService)
        {
            this.spreadsheetProccessingService = spreadsheetProccessingService;
            this.applicantProccessingService = applicantProccessingService;
            this.groupProccessingService = groupProccessingService;
        }

        public async ValueTask<ICollection<Applicant>> ImportExternalApplicants(MemoryStream spreadsheet)
        {
            ICollection<Applicant> persistedApplicants = new Collection<Applicant>();

            List<ExternalApplicant> importApplicants =
                await this.spreadsheetProccessingService.GetExternalApplicantsAsync(spreadsheet);

            foreach (ExternalApplicant external in importApplicants)
            {
                Guid groupGuid =await this.groupProccessingService.EnsureExistGroupAsync(external.GroupName);

                Applicant applicant = MapToInternalApplicant(external, groupGuid);

                persistedApplicants.Add(
                    await this.applicantProccessingService.AddApplicantAsync(applicant));
            }

                return persistedApplicants;
        }

        private Applicant MapToInternalApplicant(ExternalApplicant external, Guid groupGuid)
        {
            return new Applicant
            {
                Id = Guid.NewGuid(),
                FirstName = external.FirstName,
                LastName = external.LastName,
                Email = external.Email,
                PhoneNumber = external.PhoneNumber,
                GroupId = groupGuid,
                GroupName = external.GroupName
            };
        }
    }
}
