//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Applicants.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;

namespace Excel.Importer.Api.Tests.Unit.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfNullAndLogItAsync()
        {
            //given
            Applicant nullApplicant = null;
            var nullApplicantException = new NullApplicantException();
            var expectedApplicantValidationException =
                new ApplicantValidationException(nullApplicantException);

            //when
            ValueTask<Applicant> addApplicantTask = this.applicantService.AddApplicantAsync(nullApplicant);

            ApplicantValidationException actualApplicantValidation = 
                await Assert.ThrowsAsync<ApplicantValidationException>(addApplicantTask.AsTask);

            //then
            actualApplicantValidation.Should().BeEquivalentTo(expectedApplicantValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedApplicantValidationException))), Times.Once);


            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantAsync(It.IsAny<Applicant>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
