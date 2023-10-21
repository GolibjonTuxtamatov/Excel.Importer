//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;

namespace Excel.Importer.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}
