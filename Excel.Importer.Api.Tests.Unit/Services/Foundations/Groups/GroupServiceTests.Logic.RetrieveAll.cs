//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Foundations.Groups;
using FluentAssertions;
using Moq;
using Xunit;

namespace Excel.Importer.Api.Tests.Unit.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public void ShouldGetGroups()
        {
            //given
            IQueryable<Group> storedGroups = CreateRandomGroups();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllGroup())
                .Returns(storedGroups);

            //when
            IQueryable<Group> takenGroup = this.groupService.RetrieveAllGroups();

            //then
            takenGroup.Should().BeEquivalentTo(storedGroups);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllGroup(),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
