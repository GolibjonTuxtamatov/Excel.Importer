//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Proccessings.Groups;

namespace Excel.Importer.Services.Orchestrations.Groups
{
    public class GroupOrchestrationService : IGroupOrchestrationService
    {
        private readonly IGroupProccessingService groupProccessingService;

        public GroupOrchestrationService(IGroupProccessingService groupProccessingService)
        {
            this.groupProccessingService = groupProccessingService;
        }

        public async ValueTask<Group> AddGroupAsync(Group group)
        {
            return await this.groupProccessingService.AddGroupAsync(group);
        }

        public IQueryable<Group> RetrieveAllGroups()
        {
            return this.groupProccessingService.RetrieveAllGroups();
        }
    }
}
