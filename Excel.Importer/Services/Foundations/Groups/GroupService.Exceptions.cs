//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Groups
{
    public partial class GroupService
    {
        private delegate ValueTask<Group> ReturningGroupFunctuion();

        private async ValueTask<Group> TryCatch(ReturningGroupFunctuion returningGroupFunctuion)
        {
            try
            {
                return await returningGroupFunctuion();
            }
            catch (NullGroupException nullGroupException)
            {
                throw CreateAndLogValidationException(nullGroupException);
            }
            catch (InvalidGroupException invalidGroupException)
            {
                throw CreateAndLogValidationException(invalidGroupException);
            }
        }

        private GroupValidationException CreateAndLogValidationException(Xeption exception)
        {
            var groupValidationException =
                    new GroupValidationException(exception);

            this.loggingBroker.LogError(groupValidationException);

            return groupValidationException;
        }
    }
}
