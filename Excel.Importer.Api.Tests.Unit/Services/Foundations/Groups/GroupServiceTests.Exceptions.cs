//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Runtime.Serialization;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace Excel.Importer.Api.Tests.Unit.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccuresAndLogitAsync()
        {
            //given
            Group someGroup = CreateRandomGroup();
            SqlException sqlException = GetSqlError();
            var faildStorageGroupException = new FaildStorageGroupException(sqlException);

            var expectedGroupDependencyException =
                new GroupDependencyException(faildStorageGroupException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGroupAsync(someGroup))
                .ThrowsAsync(sqlException);

            //when
            ValueTask<Group> actualGroupTask =
                this.groupService.AddGroupAsync(someGroup);

            //then
            await Assert.ThrowsAsync<GroupDependencyException>(() =>
                actualGroupTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGroupAsync(someGroup),
                Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedGroupDependencyException))),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
