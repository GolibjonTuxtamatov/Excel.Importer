using Xeptions;

namespace Excel.Importer.Services.Foundations.Groups.Exceptions
{
    public class InvalidGroupException : Xeption
    {
        public InvalidGroupException()
            :base("Group is invalid")
        { }
    }
}
