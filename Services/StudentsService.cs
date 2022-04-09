using Microsoft.EntityFrameworkCore;
using School.Interfaces;
using School.Models;
using System.Collections.Generic;
using System.Linq;

namespace School.Services
{
    public class StudentsService: IStudentsService
    {
        ApplicationContext db;
        public StudentsService(ApplicationContext context)
        {
            db = context;
        }
        public List<Student> GetStudents()
        {
            return db.Students.Include(u => u.Class).ToList();
        }
        public void CreateNew(Student student)
        {
            db.Add(student);
            db.SaveChanges();
        }
        public void Update(Student editedStudent)
        {
            var student = GetStudentById(editedStudent.Id);
            student.Name = editedStudent.Name;
            student.Surname = editedStudent.Surname;
            student.ClassId = editedStudent.ClassId;
            db.SaveChanges();
        }
        public void Delete(Student studentToDelete)
        {
            var student = GetStudentById(studentToDelete.Id);
            if (student != null)
            {
                db.Remove(student);
                db.SaveChanges();
            }
        }
        public Student GetStudentById(int id)
        {
            var allStudents = GetStudents();
            var studentWithAppropriateId = allStudents.Where(u => u.Id == id).FirstOrDefault();
            return studentWithAppropriateId;
        } 
        public List<Student> GetStudentsOutOfClasses()
        {
            List<Student> studentsOutOfClass = new List<Student>();
            var students = GetStudents();
            studentsOutOfClass.AddRange(students.Where(u => u.Class == null));
            return studentsOutOfClass;
        }
    }
}
