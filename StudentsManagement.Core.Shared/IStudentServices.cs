using StudentsManagement.Persistence;

namespace StudentsManagement.Core.Shared
{
    public interface IStudentServices : IInitializer
    {
        IPersistenceContext PersistenceContext { get; set; }
    }
}
