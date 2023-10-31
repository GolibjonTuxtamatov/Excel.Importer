//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace Excel.Importer.Api.Tests.Unit.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public void ShouldThrowCriticalDependencyExceptionOnRetrieveAllIfSqlErrorOccursAndLogIt()
        {
            //given
            SqlException sqlException = GetSqlError();

            var faildStorageGroupException = new FaildStorageGroupException(sqlException);

            var expectedGroupDependecyException =
                new GroupDependencyException(faildStorageGroupException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllGroup())
                .Throws(sqlException);

            //when
            Action retrieveAllGroupsAction = () => this.groupService.RetrieveAllGroups();

            GroupDependencyException actualGroupdependencyException =
                Assert.Throws<GroupDependencyException>(retrieveAllGroupsAction);

            //then
            actualGroupdependencyException.Should().BeEquivalentTo(expectedGroupDependecyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllGroup(), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedGroupDependecyException))),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
