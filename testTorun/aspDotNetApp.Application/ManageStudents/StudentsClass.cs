using aspDotNetApp.Data;
using aspDotNetApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspDotNetApp.Application.ManageStudents
{
    public class StudentsClass : IStudentInterface
    {
        public readonly UniDbContext db;
        public StudentsClass(UniDbContext db)
        {
            this.db = db;
        }

        public void AddingStudentToUni(int id, Students stud)
        {
            var StudentToBeAdded = db.Universties.Include(uni => uni.students).Where(STUD => STUD.id == id).SingleOrDefault();
            StudentToBeAdded.students.Add(stud);
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var deletedStudent = db.Students.Where(stud => stud.id == id).SingleOrDefault();
            db.Students.Remove(deletedStudent);
            db.SaveChanges();
        }

        public void EditStudent(int id, Students stud)
        {
            var studentToBeEdited = db.Students.Where(student => student.id == id).SingleOrDefault();
            studentToBeEdited.name = stud.name;
            studentToBeEdited.grades = stud.grades;
            db.SaveChanges();
        }

        public List<Students> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public List<Students> GetSearchedStudents(int id, string value)
        {
            var SearchedStudents = db.Universties.Include(stud => stud.students).Where(stud => stud.id == id).SingleOrDefault().students.
                Where(stud => stud.name.StartsWith(value)).ToList();
            return SearchedStudents;
        }

        public Students GetSingleStudent(int id)
        {
            return db.Students.SingleOrDefault(stud => stud.id== id);
        }

        public List<Students> GetStudentsOfOneUniveristy(int id)
        {
            var Students = db.Universties.Include(uni => uni.students)
                .Where(uni => uni.id == id)
                .Select(stud => stud.students).SingleOrDefault();
            
                return Students;
           
            
        }
    }
}
