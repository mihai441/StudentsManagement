using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using StudentsManagement.Domain;
using StudentManagement.Authentication;
using StudentsManagement.Persistence;

namespace StudentsManagement.Core.Shared
{
    public class BusinessLogic : IBusinessLayer
    {
        //List<IInitializer> initList;
        private IAuthentication auth;
        private IStudentServices studentServices;

        public BusinessLogic(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IPersistenceContext persistenceContext)
        {            
            studentServices = new StudentServices(persistenceContext);
            auth = new AuthenticationServices(userManager, signInManager);

        }

        public IAuthentication GetAuthenticationService()
        {
            return auth;
        }

        public IStudentServices GetStudentOperationService()
        {
            return studentServices;
        }
    }
}
