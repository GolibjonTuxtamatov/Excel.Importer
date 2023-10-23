//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================


using System.Linq.Expressions;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using Moq;
using Xunit;

namespace Excel.Importer.Api.Tests.Unit.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGroupIsNullAndLogItAsync()
        {
            //given
            Group nullGroup = null;
            var nullGroupException = new NullGroupException();

            var expectedGroupValidationException =
                new GroupValidationException(nullGroupException);

            //when
            ValueTask<Group> actualGroupTask =
                this.groupService.AddGroupAsync(nullGroup);

            //then
            await Assert.ThrowsAsync<GroupValidationException>(() =>
                actualGroupTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedGroupValidationException))),
                Times.Once());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGroupAsync(It.IsAny<Group>()),
                Times.Never());

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
