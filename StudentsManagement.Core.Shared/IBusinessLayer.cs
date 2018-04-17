using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface IBusinessLayer : IInitializer
    {
       
        IStudentServices GetStudentOperationService();
        IAuthentication GetAuthenticationService();
    }
}
