using School.Models;
using System.Collections.Generic;

namespace School.ViewModels
{
    public class ClassesIndexViewModel
    {
        public List<Class> Classes { get; set; }
        public List<Student> StudentsOutOfClass { get; set; }
    }
}
