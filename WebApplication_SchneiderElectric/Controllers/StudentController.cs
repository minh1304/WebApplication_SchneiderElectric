using Microsoft.AspNetCore.Mvc;
using WebApplication_SchneiderElectric.Models;

namespace WebApplication_SchneiderElectric.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer studentDataAccessLayer = null;
        public StudentController()
        {
            studentDataAccessLayer = new StudentDataAccessLayer();
        }
        // GET: Student  
        public ActionResult Index()
        {
            IEnumerable<Student> students = studentDataAccessLayer.GetAllStudent();
            return View(students);
        }


        // GET: Student/Create  
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here  
                studentDataAccessLayer.AddStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


    }
}
