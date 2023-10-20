//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups;

namespace Excel.Importer.Services.Proccessings.Groups
{
    public class GroupProccessingService : IGroupProccessingService
    {
        private readonly IGroupService groupService;

        public GroupProccessingService(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public ValueTask<Group> AddGroupAsync(Group group)
        {
            return this.groupService.AddGroupAsync(group);
        }

        public IQueryable<Group> RetrieveAllGroups()
        {
            return this.groupService.RetrieveAllGroups();
        }
    }
}
