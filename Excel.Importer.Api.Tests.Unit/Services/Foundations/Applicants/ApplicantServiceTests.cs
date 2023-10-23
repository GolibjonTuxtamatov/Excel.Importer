//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Applicants;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace Excel.Importer.Api.Tests.Unit.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IApplicantService applicantService;

        public ApplicantServiceTests()
        {
            this.storageBrokerMock = new  Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.applicantService = new ApplicantService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Applicant CreateRandomApplicant() =>
            CreateApplicantFiller().Create();

        private static Filler<Applicant> CreateApplicantFiller() =>
            new Filler<Applicant>();

    }
}
