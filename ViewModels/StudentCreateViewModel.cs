using School.Models;
using System.Collections.Generic;

namespace School.ViewModels
{
    public class StudentCreateViewModel
    {
        public Student Student { get; set; }
        public List<Class> Classes { get; set; }
        public string StudentCreateBackUrl { get; set; }
    }
}
