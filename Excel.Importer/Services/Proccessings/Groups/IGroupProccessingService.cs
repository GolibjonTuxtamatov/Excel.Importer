//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;

namespace Excel.Importer.Services.Proccessings.Groups
{
    public interface IGroupProccessingService
    {
        ValueTask<Group> AddGroupAsync(Group group);
        IQueryable<Group> RetrieveAllGroups();
    }
}
