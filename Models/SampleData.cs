using System.Linq;

namespace School.Models
{
    public static class SampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Classes.Any())
            {
                context.Classes.AddRange(
                    new Class 
                    { 
                        ClassName = "test0" 
                    },
                    new Class
                    { 
                        ClassName = "test1" 
                    });
                context.SaveChanges();
            }
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                     new Student
                     {
                         Name = "test0",
                         Surname = "test0",
                         ClassId = context.Classes.ToList().First().Id
                     },
                     new Student
                     {
                         Name = "test1",
                         Surname = "test1",
                         ClassId = context.Classes.ToList().First().Id
                     },
                     new Student
                     {
                         Name = "test2",
                         Surname = "test2",
                         ClassId = context.Classes.ToList().First().Id
                     },
                     new Student
                     {
                         Name = "test3",
                         Surname = "test3",
                         ClassId = context.Classes.ToList().Last().Id
                     });
                context.SaveChanges();
            }

        }
    }
}
