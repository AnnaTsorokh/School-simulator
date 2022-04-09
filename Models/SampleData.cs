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
                        ClassName = "FirstClass" 
                    },
                    new Class
                    { 
                        ClassName = "SecondClass" 
                    });
                context.SaveChanges();
            }
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                     new Student
                     {
                         Name = "Student1",
                         Surname = "Surname1",
                         ClassId = context.Classes.ToList().First().Id
                     },
                     new Student
                     {
                         Name = "Student2",
                         Surname = "Surname2",
                         ClassId = context.Classes.ToList().First().Id
                     },
                     new Student
                     {
                         Name = "Student3",
                         Surname = "Surname3",
                         ClassId = context.Classes.ToList().First().Id
                     },
                     new Student
                     {
                         Name = "Student4",
                         Surname = "Surname4",
                         ClassId = context.Classes.ToList().Last().Id
                     });
                context.SaveChanges();
            }

        }
    }
}
