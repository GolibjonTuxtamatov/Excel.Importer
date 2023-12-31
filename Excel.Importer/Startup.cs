//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Spreadsheets;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Services.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Groups;
using Excel.Importer.Services.Foundations.Spreadsheets;
using Excel.Importer.Services.Orchestrations.Applicants;
using Excel.Importer.Services.Orchestrations.Groups;
using Excel.Importer.Services.Orchestrations.Spreadsheets;
using Excel.Importer.Services.Proccessings.Applicants;
using Excel.Importer.Services.Proccessings.Groups;
using Excel.Importer.Services.Proccessings.Spreadsheets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Excel.Importer
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "Excel.Importer",
                Version = "v1"
            };

            services.AddControllers();

            services.AddDbContext<StorageBroker>();
            AddBrokers(services);
            AddServices(services);


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: apiInfo);
            });
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<ISpreadsheetOrchestrationService, SpreadsheetOrchestrationService>();
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IApplicantProccessingService, ApplicantProccessingService>();
            services.AddTransient<IApplicantOrchestrationService, ApplicantOrchestrationService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IGroupProccessingService, GroupProccessingService>();
            services.AddTransient<IGroupOrchestrationService, GroupOrchestrationService>();
            services.AddTransient<ISpreadsheetService, SpreadsheetService>();
            services.AddTransient<ISpreadsheetProccessingService, SpreadsheetProccessingService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "Excel.Importer v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
