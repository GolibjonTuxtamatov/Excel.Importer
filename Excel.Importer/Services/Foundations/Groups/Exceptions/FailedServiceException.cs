//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Groups.Exceptions
{
    public class FailedServiceException : Xeption
    {
        public FailedServiceException(Exception innerException)
            : base("Service error occured, contact support",
                 innerException)
        { }
    }
}
