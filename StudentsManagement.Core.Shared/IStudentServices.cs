﻿using StudentsManagement.Persistence;

namespace StudentsManagement.Core.Shared
{
    public interface IStudentServices
    {
        IPersistenceContext PersistenceContext { get; set; }
    }
}
