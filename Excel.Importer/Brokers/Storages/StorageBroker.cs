//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using EFxceptions;
using Excel.Importer.Models.Foundations.Applicants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Excel.Importer.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public async ValueTask<T> InsertAsync<T>(T @object)
        {
            using var broker = new StorageBroker(this.configuration);
            broker.Entry(@object).State = EntityState.Added;
            await broker.SaveChangesAsync();

            return @object;
        }

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
