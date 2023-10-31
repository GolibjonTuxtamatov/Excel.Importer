//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Models.Foundations.Groups;

namespace Excel.Importer.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Applicant> InsertApplicantAsync(Applicant applicant);
        IQueryable<Group> SelectAllGroups();
    }
}
