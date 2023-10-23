//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;

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
                var groupValidationException =
                    new GroupValidationException(nullGroupException);

                this.loggingBroker.LogError(groupValidationException);

                throw groupValidationException;
            }
        }
    }
}
