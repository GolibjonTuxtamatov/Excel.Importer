//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
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

        public async ValueTask<Guid> EnsureExistGroupAsync(string groupName)
        {
            IQueryable<Group> groups = RetrieveAllGroups();

            if (EnsureExistGroupName(groupName))
            {
                Group foundGroup = groups.FirstOrDefault(group =>
                    group.GroupName == groupName);

                return foundGroup.Id;
            }
            else
            {
                var group = new Group
                {
                    Id = Guid.NewGuid(),
                    GroupName = groupName
                };
                await groupService.AddGroupAsync(group);

                return group.Id;
            }

        }

        private bool EnsureExistGroupName(string groupName)
        {
            IQueryable<Group> groups = RetrieveAllGroups();

            return groups.Contains(groups.FirstOrDefault(group =>
                group.GroupName == groupName));
        }
    }
}
