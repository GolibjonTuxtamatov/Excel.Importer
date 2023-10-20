using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;

namespace Excel.Importer.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Group> InsertGroupAsync(Group group);
    }
}
