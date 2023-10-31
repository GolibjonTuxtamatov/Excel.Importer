//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Applicants.Exceptions
{
    public class ApplicantDependencyValidationExcpetion : Xeption
    {
        public ApplicantDependencyValidationExcpetion(Exception innerException)
            : base(message: "Applicant dependency validation error occured, fix the errors and try again", innerException)
        {}
    }
}
