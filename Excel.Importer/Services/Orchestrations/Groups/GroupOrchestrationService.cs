//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Proccessings.Groups;

namespace Excel.Importer.Services.Orchestrations.Groups
{
    public partial class GroupOrchestrationService : IGroupOrchestrationService
    {
        private readonly IGroupProccessingService groupProccessingService;
        private readonly ILoggingBroker loggingBroker;

        public GroupOrchestrationService(
            IGroupProccessingService groupProccessingService,
            ILoggingBroker loggingBroker)
        {
            this.groupProccessingService = groupProccessingService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Group> AddGroupAsync(Group group) =>
        TryCatch(async () =>
        {
            return await this.groupProccessingService.AddGroupAsync(group);
        });

        public IQueryable<Group> RetrieveAllGroups()
        {
            return this.groupProccessingService.RetrieveAllGroups();
        }
    }
}
