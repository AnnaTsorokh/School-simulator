using School.Models;
using System.Collections.Generic;

namespace School.Interfaces
{
    public interface IStudentsService
    {
        List<Student> GetStudents();
        void CreateNew(Student student);
        void Update(Student student);
        void Delete(Student student);
        Student GetStudentById(int id);
        List<Student> GetStudentsOutOfClasses();
    }
}
