using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazilimGelistiriciKampi_Gun1
{
    public interface ICourseDal
    {
        List<Course> GetAll();
        void Add(Course course);
    }
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
    public class CourseDal:ICourseDal
    {
        List<Course> courses;
        public CourseDal()
        {
            Course course1 = new Course();
            course1.Id = 1;
            course1.Name = "C#";
            course1.Description = ".NET 8";
            course1.Price = 0;
            Course course2 = new Course();
            course2.Id = 2;
            course2.Name = "Java";
            course2.Description = "Java 17";
            course2.Price = 10;
            Course course3 = new Course();
            course3.Id = 3;
            course3.Name = "Python";
            course3.Description = "Python 3.12";
            course3.Price = 20;

            courses=new List<Course> { course1, course2,course3 };
        }
        public List<Course> GetAll()
        {
            return courses;
        }
        public void Add(Course course)
        {
            courses.Add(course);
        }
    }

    public class CourseManager
    {
        private readonly ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public List<Course> GetAll()
        {
            
            return _courseDal.GetAll();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string message1 = "Krediler";
            int term = 12;
            double amount = 100000;
            bool isAuthenticated = true;
            Console.WriteLine(message1);
            if (isAuthenticated)
            {
                Console.WriteLine("Buton-->Hosgeldin Gorkem");
            }
            else
            {
                Console.WriteLine("Buton-->Sisteme giriş yap");
            }
            string[] loans = { "Kredi 1", "Kredi 2", "Kredi 3", "Kredi 4", "Kredi 5", "Kredi 6" };
            for (int i = 0; i < loans.Length; i++)
            {
                Console.WriteLine(loans[i]);
            }
            CourseManager courseManager = new CourseManager(new CourseDal());
            List<Course> courses2 = courseManager.GetAll();
            for(int i=0;i<courses2.Count; i++)
            {
                Console.WriteLine(courses2[i].Name+ "/" + courses2[i].Price);
            }

            Console.WriteLine("Kod bitti");
            Console.ReadKey();
        }
    }
}
