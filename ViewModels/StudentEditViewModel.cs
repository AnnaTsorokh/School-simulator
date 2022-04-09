using Microsoft.AspNetCore.Mvc;
using School.Models;
using System.Collections.Generic;

namespace School.ViewModels
{
    public class StudentEditViewModel
    {
        public Student Student { get; set; }
        public List<Class> Classes { get; set; }
        public string StudentEditBackUrl { get; set; }
    }
}
