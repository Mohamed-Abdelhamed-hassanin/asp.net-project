using aspDotNetApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspDotNetApp.Application.ManageStudents
{
    public interface IStudentInterface
    {
        List<Students> GetStudentsOfOneUniveristy(int id);
        List<Students> GetAllStudents();
        Students GetSingleStudent(int id);
        void AddingStudentToUni(int id, Students stud);
        List<Students> GetSearchedStudents(int id, string value);
        void DeleteStudent(int id);
        void EditStudent(int id, Students stud);
    }
}
