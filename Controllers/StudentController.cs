using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StudentViewTemplatesDemo.Models;

namespace StudentViewTemplatesDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        static List<Student> students = new List<Student>() {
        new Student() {
        Id = 1,
        Name="Allen",
        Age = 79,
        Address= new Address()
        {
            Id = 101,
            Country = "India",
            State = "Punjab",
            City = "Mohali"
        }
    },
        new Student()
        {
            Id = 2,
            Name = "Mary",
            Age = 99,
            Address = new Address()
            {
                Id = 102,
                Country = "India",
                State = "Punjab",
                City = "Mohali"
            }
        },

        new Student()
        {
            Id = 3,
            Name = "Tom",
            Age = 139,
            Address = new Address()
            {
                Id = 103,
                Country = "India",
                State = "Kerala",
                City = "Thrissur"
            }
        },
        new Student()
        {
            Id = 4,
            Name = "Jerry",
            Age = 69,
            Address = new Address()
            {
                Id = 104,
                Country = "India",
                State = "Tamil Nadu",
                City = "Chennai"
            }
        }
    };
        //displays a list of all students
        public ActionResult Index()
        {
            return View(students);
        }

        //displays details of a specific student based on the ID
        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        //displays the form for creating a new student
        public ActionResult Create()
        {
            return View();
        }

        //handles the form submission for creating a new student
        [HttpPost]
        public ActionResult Create(Student student)
        {
            //remove validation for Address.Id to allow student creation without Address Id
            ModelState.Remove("Address.Id");

            //check if the model state is valid before adding the student
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("Index", student);
            }
            return View(student);
        }

        //displays the form for editing a specific student based on the ID
        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }


        //handles the form submission for editing a specific student
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                }
                return RedirectToAction("Index", student);
            }
            return View(student);
        }

        //deletes a specific student based on the ID
        public ActionResult Delete(int id)
        {
            var item = students.Where(s => s.Id == id).FirstOrDefault();
            students.Remove(item);
            return RedirectToAction("Index");
        }

        //displays the form to add an address to a specific student
        public ActionResult AddAddress(int id)
        {
            var student = students.FirstOrDefault(st => st.Id == id);

            ViewBag.StudentId = id;
            return View(new Address { Id = student.Id });
        }

        //handles the form submission to add an address to a specific student
        [HttpPost]
        public ActionResult AddAddress(int id, Address address)
        {

            if (ModelState.IsValid)
            {
                var student = students.FirstOrDefault(st => st.Id == id);
                student.Address = address;
                return RedirectToAction("Index");
            }
            return View(address);
        }

        //displays the address of a specific student or redirects to AddAddress if no address exists
        public ActionResult GetAddress(int id)
        {
            var item = students.Where(s => s.Id == id).FirstOrDefault();
            if (item.Address == null)
            {
                return RedirectToAction("AddAddress", new { id = item.Id });
            }
            return View(item.Address);
        }

        //displays the form to edit the address of a specific student
        public ActionResult EditAddress(int id)
        {
            var student = students.FirstOrDefault(s => s.Address != null && s.Address.Id == id);
            return View(student.Address);
        }

        //handles the form submission to edit the address of a specific student
        [HttpPost]
        public ActionResult EditAddress(int id, Address address)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(st => st.Address.Id == id);
                if (existingStudent != null)
                {
                    existingStudent.Address.Country = address.Country;
                    existingStudent.Address.State = address.State;
                    existingStudent.Address.City = address.City;

                    return RedirectToAction("Index");
                }

            }
            return View(address);
        }

        //deletes the address of a specific student
        public ActionResult DeleteAddress(int id)
        {
            var student = students.FirstOrDefault(st => st.Address.Id == id);
            student.Address = null;
            return RedirectToAction("Index");
        }
    }
}