using Microsoft.EntityFrameworkCore;
using School.Interfaces;
using School.Models;
using System.Collections.Generic;
using System.Linq;

namespace School.Services
{
    public class ClassesService: IClassesService
    {
        ApplicationContext db;
        public ClassesService(ApplicationContext context)
        {
            db = context;
        }
        public List<Class> GetClasses()
        {
            return db.Classes.Include(u => u.Students).ToList();
        }
        public Class GetClassById(int id)
        {
            var allClasses = GetClasses();
            var classWithAppropriateId = allClasses.Where(u => u.Id == id).FirstOrDefault();
            if (classWithAppropriateId != null)
            {
                return classWithAppropriateId;
            }
            return null;
        }
        public void Update(Class editedClass)
        {
            var classToUpdate = GetClassById(editedClass.Id);
            if (classToUpdate != null)
            {
                classToUpdate.ClassName = editedClass.ClassName;
                classToUpdate.Students.AddRange(editedClass.Students);
                db.SaveChanges();
            } 
        }
        public void Delete(Class classToDelete)
        {
            var classToDeleteFromDb = GetClassById(classToDelete.Id);
            if (classToDeleteFromDb != null)
            {
                db.Classes.Remove(classToDeleteFromDb);
                db.SaveChanges();
            }
        }
        public void CreateNew(Class newClass)
        {
            db.Classes.Add(newClass);
            db.SaveChanges();
        }

       
    }
}
