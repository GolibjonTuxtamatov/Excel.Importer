//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Excel.Importer.Services.Proccessings.Groups.Exceptions
{
    public class ApplicantProccessingDepedencyException : Xeption
    {
        public ApplicantProccessingDepedencyException(Xeption innerException)
            : base("Group proccessing dependency error occured, fix the error try again",
                 innerException)
        { }
    }
}
