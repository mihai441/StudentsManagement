using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace StudentsManagement.Core
{
    class StudentServices : IInitializer
    {
        public StudentServices()
        {
        }

        public void Configure(IApplicationBuilder builder)
        {
        }

        public void Initialize(IServiceCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
