using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Core.Shared;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using StudentsManagement.Domain;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentsManagement.Core
{
    class StudentServices : IStudentServices
    {

        public StudentServices()
        {


        }

        public void Configure(IApplicationBuilder builder)
        {

        }

        public void Initialize(IServiceCollection collection)
        {

        }
    }
}
