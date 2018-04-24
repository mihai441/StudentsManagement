using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Core.Shared;
using Microsoft.AspNetCore.Builder;
using StudentsManagement.Persistence;
using System.Security.Claims;

namespace StudentsManagement.Core
{
    class StudentServices : IStudentServices
    {
        IPersistenceContext _persistenceContext;


        public StudentServices(IPersistenceContext persistenceContext)
        {
            PersistenceContext = persistenceContext;
        }

        public IPersistenceContext PersistenceContext { get => _persistenceContext; set => _persistenceContext = value; }

        public void Configure(IApplicationBuilder builder)
        {

        }


        public void Initialize(IServiceCollection collection)
        {

        }

    }
}
