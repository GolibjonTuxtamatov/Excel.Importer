//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Azure.Messaging;
using Xeptions;

namespace Excel.Importer.Models.Foundations.Applicants.Exceptions
{
    public class FailedApplicantStorageException : Xeption
    {
        public FailedApplicantStorageException(Exception innerException)
            : base(message: "Failed applicant storage error occured, contact support",
                  innerException)
        { }
    }
}
