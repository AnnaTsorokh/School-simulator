using School.Models;
using System.Collections.Generic;

namespace School.Interfaces
{
    public interface IClassesService
    {
        List<Class> GetClasses();
        public Class GetClassById(int id);
        void Update(Class classToUpdate);
        void Delete(Class classToDelete);
        void CreateNew(Class newClass);
    }
}
