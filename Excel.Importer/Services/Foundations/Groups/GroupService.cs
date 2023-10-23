//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;

namespace Excel.Importer.Services.Foundations.Groups
{
    public class GroupService : IGroupService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GroupService(IStorageBroker storageBroker,ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Group> AddGroupAsync(Group group)
        {
            try
            {
                if (group is null)
                    throw new NullGroupException();

                return await this.storageBroker.InsertGroupAsync(group);
            }
            catch (NullGroupException nullGroupException)
            {
                var groupValidationException =
                    new GroupValidationException(nullGroupException);

                this.loggingBroker.LogError(groupValidationException);

                throw groupValidationException;
            }
        }

        public IQueryable<Group> RetrieveAllGroups()
        {
            return this.storageBroker.SelectAllGroup();
        }
    }
}
