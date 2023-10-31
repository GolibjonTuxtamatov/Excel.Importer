//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Models.Foundations.Applicants.Exceptions
{
    public class ApplicantServiceException : Xeption
    {
        public ApplicantServiceException(Xeption innerException)
            : base(message: "Applicant service error occured, contact support", innerException)
        { }
    }
}
