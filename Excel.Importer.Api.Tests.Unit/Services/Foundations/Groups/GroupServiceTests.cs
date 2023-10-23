﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================


using System.Linq.Expressions;
using System.Runtime.Serialization;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Excel.Importer.Api.Tests.Unit.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGroupService groupService;

        public GroupServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.groupService = new GroupService(
                this.storageBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }

        private SqlException GetSqlError()=>
            (SqlException)FormatterServices
            .GetSafeUninitializedObject(typeof(SqlException));

        private Expression<Func<Exception, bool>> SameExceptionAs(Xeption exception) =>
            actualException => actualException.SameExceptionAs(exception);

        private Group CreateRandomGroup() =>
            CreateGroupFiller().Create();

        private Filler<Group> CreateGroupFiller() =>
            new Filler<Group>();
    }
}
