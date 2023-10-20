//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Excel.Importer.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = configuration.GetConnectionString(name: "DefaultConnection");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite( connectionString);
        }
    }
}