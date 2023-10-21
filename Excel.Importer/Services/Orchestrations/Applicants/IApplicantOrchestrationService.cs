//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;

namespace Excel.Importer.Services.Orchestrations.Applicants
{
    public interface IApplicantOrchestrationService
    {
        ValueTask<Applicant> AddApplicantAsync(Applicant applicant);
    }
}
