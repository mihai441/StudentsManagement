using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using StudentsManagement.Domain;
using StudentManagement.Authentication;

namespace StudentsManagement.Core.Shared
{
    public class BusinessLogic : IBusinessLayer
    {
        List<IInitializer> initList;
        private IAuthentication auth;
        private IStudentServices studentServices;
        private IPersistence persistence;

        public BusinessLogic(IPersistence persist, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {            
            studentServices = new StudentServices();
            auth = new AuthenticationServices(persist, userManager, signInManager);
            initList = new List<IInitializer> { auth, studentServices };



        }

        public void Configure(IApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }

        public IAuthentication GetAuthenticationService()
        {
            return auth;
        }

        public IStudentServices GetStudentOperationService()
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
