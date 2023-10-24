//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Orchestrations.Groups.Exceptions;
using Excel.Importer.Services.Proccessings.Groups.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Orchestrations.Groups
{
    public partial class GroupOrchestrationService
    {
        private delegate ValueTask<Group> ReturningGroupFunction();

        private async ValueTask<Group> TryCatch(ReturningGroupFunction returningGroupFunction)
        {
            try
            {
                return await returningGroupFunction();
            }
            catch (GroupProccessingValidationException groupProccessingValidationException)
            {
                throw CreateAndLogOrchetrationValidationException(groupProccessingValidationException);
            }
        }

        private GroupOrchestrationValidationException CreateAndLogOrchetrationValidationException(Xeption exception)
        {
            var groupOrchestrationValidationException =
                new GroupOrchestrationValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(groupOrchestrationValidationException);

            return groupOrchestrationValidationException;
        }
    }
}
