//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Groups;

namespace Excel.Importer.Services.Foundations.Groups
{
    public class GroupService : IGroupService
    {
        private readonly IStorageBroker storageBroker;

        public GroupService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public ValueTask<Group> AddGroupAsync(Group group)
        {
            return this.storageBroker.InsertGroupAsync(group);
        }

        public IQueryable<Group> RetrieveAllGroups()
        {
            return this.storageBroker.SelectAllGroup();
        }
    }
}
