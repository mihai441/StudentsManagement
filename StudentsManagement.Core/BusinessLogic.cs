using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace StudentsManagement.Core.Shared
{
    class BusinessLogic : IBusinessLayer
    {
        List<IInitializer> initList;
        private IInitializer auth;
        private IInitializer studentServices;

        public BusinessLogic( )
        {            
            IInitializer studentServices = new StudentServices();
            initList = new List<IInitializer> { auth, studentServices };


        }

        public void Configure(IApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }

        public IInitializer GetAuthenticationService()
        {
            return auth;
        }

        public IInitializer GetStudentOperationService()
        {
            return studentServices;
        }


        public void Initialize(IServiceCollection collection)
        {
            
            foreach (var item in initList)
            {
                item.Initialize(collection);
            }
        }
    }
}
