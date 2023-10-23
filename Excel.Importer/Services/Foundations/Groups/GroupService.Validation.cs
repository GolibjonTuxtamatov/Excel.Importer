//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;

namespace Excel.Importer.Services.Foundations.Groups
{
    public partial class GroupService
    {
        private void ValidateGroupNotNull(Group group)
        {
            if (group == null)
                throw new NullGroupException();
        }
    }
}
