using Xeptions;

namespace Excel.Importer.Services.Foundations.Groups.Exceptions
{
    public class GroupDependencyException : Xeption
    {
        public GroupDependencyException(Xeption innerException)
            :base("Group dependency error occured, fix the error try again",
                 innerException)
        { }

    }
}
