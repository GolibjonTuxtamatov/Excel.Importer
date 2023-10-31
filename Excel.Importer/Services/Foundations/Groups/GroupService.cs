﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using Microsoft.Data.SqlClient;

namespace Excel.Importer.Services.Foundations.Groups
{
    public partial class GroupService : IGroupService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GroupService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Group> AddGroupAsync(Group group) =>
            TryCatch(async () =>
            {
                ValidateGroupOnAdd(group);

                return await this.storageBroker.InsertGroupAsync(group);
            });

        public IQueryable<Group> RetrieveAllGroups()
        {
            try
            {
                return this.storageBroker.SelectAllGroup();
            }
            catch (SqlException sqlException)
            {
                var faildStorageGroupException =
                    new FaildStorageGroupException(sqlException);

                throw CreatAndLogCriticalDependencyException(faildStorageGroupException);
            }
        }
    }
}
