//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using Excel.Importer.Services.Proccessings.Groups.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Proccessings.Groups
{
    public partial class GroupProccessingService
    {
        private delegate ValueTask<Group> ReturningGroupFunction();

        private async ValueTask<Group> TryCatch(ReturningGroupFunction returningGroupFunction)
        {
            try
            {
                return await returningGroupFunction();
            }
            catch (GroupValidationException groupValidationException)
            {
                throw CreateAndLogProccessingValidationException(groupValidationException);
            }
        }

        private GroupProccessingValidationException CreateAndLogProccessingValidationException(Xeption exception)
        {
            var groupProccessingValidationException =
                new GroupProccessingValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(groupProccessingValidationException);

            return groupProccessingValidationException;
        }
    }
}
