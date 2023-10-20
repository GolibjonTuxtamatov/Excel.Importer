//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Microsoft.EntityFrameworkCore;

namespace Excel.Importer.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Group> Groups { get; set; }

        public ValueTask<Group> InsertGroupAsync(Group group) =>
            InsertAsync(group);
    }
}
