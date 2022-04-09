using School.Models;
using System.Collections.Generic;

namespace School.ViewModels
{
    public class ClassCreateViewModel
    {
        public Class NewClass { get; set; }
        public List<Student> StudentsOutOfClasses { get; set; }
        public List<int> StudentsIds { get; set; }
    }
}
