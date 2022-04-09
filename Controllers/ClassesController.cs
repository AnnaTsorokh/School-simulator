using Microsoft.AspNetCore.Mvc;
using School.Interfaces;
using School.Models;
using School.Services;
using School.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace School.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassesService _classesService;
        private readonly IStudentsService _studentsService;
        public ClassesController(IClassesService classesService, IStudentsService studentsService)
        {
            _classesService = classesService;
            _studentsService = studentsService;
        }
        public IActionResult Index()
        {
            StudentsController.studentBackUrl = "/classes/index";
            ClassesIndexViewModel viewModel = new ClassesIndexViewModel();
            viewModel.Classes = _classesService.GetClasses();
            viewModel.StudentsOutOfClass = _studentsService.GetStudentsOutOfClasses();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_classesService.GetClassById(id));
        }
        [HttpPost]
        public IActionResult Details(Class chosenClass)
        {
            return View(chosenClass);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentsController.studentBackUrl = $"/classes/edit/{id}";
            return View(_classesService.GetClassById(id));
        }
        [HttpPost]
        public IActionResult Edit(Class classToEdit)
        {
            return View(classToEdit);
        }
        [HttpGet]
        public IActionResult Rename(int id)
        {
            return View(_classesService.GetClassById(id));
        }
        [HttpPost]
        public IActionResult Rename(Class classToRename)
        {
            _classesService.Update(classToRename);
            return RedirectToAction("Edit", classToRename);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_classesService.GetClassById(id));
        }
        [HttpPost]
        public IActionResult Delete(Class classToDelete)
        {
            _classesService.Delete(classToDelete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ClassCreateViewModel viewModel = new ClassCreateViewModel();
            viewModel.StudentsIds = new List<int>();
            viewModel.NewClass = new Class();
            viewModel.StudentsOutOfClasses = _studentsService.GetStudentsOutOfClasses();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(ClassCreateViewModel viewModel)
        {
            var allStudents = _studentsService.GetStudents();
            if (viewModel.StudentsIds != null)
            {
                foreach (var id in viewModel.StudentsIds)
                {
                    viewModel.NewClass.Students.Add(allStudents.Where(x => x.Id == id).First());
                }
            }
            _classesService.CreateNew(viewModel.NewClass);
            return RedirectToAction("Index");
        }
    }
}
