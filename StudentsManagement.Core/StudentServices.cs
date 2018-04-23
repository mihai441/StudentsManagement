using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Core.Shared;
using Microsoft.AspNetCore.Builder;
using StudentsManagement.Persistence;

namespace StudentsManagement.Core
{
    class StudentServices : IStudentServices
    {
        IPersistenceContext _persistenceContext;

        public StudentServices(IPersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext
        }

        public void Configure(IApplicationBuilder builder)
        {

        }


        public void Initialize(IServiceCollection collection)
        {

        }
    }
}
