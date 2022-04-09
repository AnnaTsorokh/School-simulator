using Microsoft.AspNetCore.Mvc;
using School.Interfaces;
using School.Models;
using School.ViewModels;
using System;
using System.Linq;

namespace School.Controllers
{
    public class StudentsController : Controller
    {
        public static string studentBackUrl = "";

        private readonly IStudentsService _studentsService;
        private readonly IClassesService _classesService;
        public StudentsController(IStudentsService studentsService,
            IClassesService classesService)
        {
            _studentsService = studentsService;
            _classesService = classesService;
        }
        public IActionResult Index()
        {
            studentBackUrl = "/students/index";
            var students = _studentsService.GetStudents();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create(int? classId)
        {
            StudentCreateViewModel viewModel = new StudentCreateViewModel();
            viewModel.Student = new Student();
            viewModel.Classes = _classesService.GetClasses();
            if (classId != null)
            {
                viewModel.Student.ClassId = (int)classId;
            }
            viewModel.StudentCreateBackUrl = studentBackUrl;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel viewModel)
        {
            _studentsService.CreateNew(viewModel.Student);
            return Redirect(studentBackUrl);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentEditViewModel viewModel = new StudentEditViewModel();
            viewModel.Student = _studentsService.GetStudentById(id);
            viewModel.Classes = _classesService.GetClasses();
            viewModel.StudentEditBackUrl = studentBackUrl;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel viewModel)
        {
            _studentsService.Update(viewModel.Student);
            return Redirect(studentBackUrl);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            StudentDeleteViewModel viewModel = new StudentDeleteViewModel();
            viewModel.Student = _studentsService.GetStudentById(id);
            viewModel.StudentDeleteBackUrl = studentBackUrl; 
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(StudentDeleteViewModel viewModel)
        {
            _studentsService.Delete(viewModel.Student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            StudentDetailsViewModel viewModel = new StudentDetailsViewModel();
            viewModel.Student= _studentsService.GetStudentById(id);
            viewModel.StudentDetailsBackUrl = studentBackUrl;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Details(StudentDetailsViewModel viewModel)
        {
            return View(viewModel.Student);
        }
        [HttpGet]
        public IActionResult DeleteFromClass(int id)
        {
            var student = _studentsService.GetStudentById(id);
            if (student != null)
            {
                return View(student);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromClass(Student student)
        {
            var editedStudent = _studentsService.GetStudentById(student.Id);
            var c = editedStudent.Class;
            editedStudent.ClassId = null;
            _studentsService.Update(editedStudent);
            return RedirectToAction("Edit", "Classes", c);
        }
    }
}
