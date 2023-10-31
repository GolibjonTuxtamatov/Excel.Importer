//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Models.Foundations.Applicants.Exceptions
{
    public class AlreadyExistApplicantException : Xeption
    {
        public AlreadyExistApplicantException(Exception innerException)
            : base(message: "Applicant already exists",
                  innerException)
        { }
    }
}
