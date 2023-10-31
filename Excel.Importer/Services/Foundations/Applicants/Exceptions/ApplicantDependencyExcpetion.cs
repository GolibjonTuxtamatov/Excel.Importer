//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Applicants.Exceptions
{
    public class ApplicantDependencyExcpetion : Xeption
    {
        public ApplicantDependencyExcpetion(Exception innerException)
            : base(message: "Guest dependency error occured, contact support",
                  innerException)
        {}
    }
}
