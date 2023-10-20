//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;

namespace Excel.Importer.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<T> InsertAsync<T>(T @object);
    }
}
