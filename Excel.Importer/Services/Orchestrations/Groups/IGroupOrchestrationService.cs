//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;

namespace Excel.Importer.Services.Orchestrations.Groups
{
    public interface IGroupOrchestrationService
    {
        ValueTask<Group> AddGroupAsync(Group group);
    }
}
