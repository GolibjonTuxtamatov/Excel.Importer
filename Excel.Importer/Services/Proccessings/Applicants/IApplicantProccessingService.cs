//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;

namespace Excel.Importer.Services.Proccessings.Applicants
{
    public interface IApplicantProccessingService
    {
        ValueTask<Applicant> AddApplicantAsync(Applicant applicant);
    }
}
