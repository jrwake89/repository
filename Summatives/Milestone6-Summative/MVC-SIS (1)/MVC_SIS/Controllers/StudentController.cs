using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (string.IsNullOrEmpty(studentVM.Student.FirstName))
            {
                ModelState.AddModelError("Student.FirstName", "Please enter your first name.");
            }

            if (string.IsNullOrEmpty(studentVM.Student.LastName))
            {
                ModelState.AddModelError("Student.LastName", "Please enter your last name.");
            }

            if (studentVM.Student.GPA == 0)
            {
                ModelState.AddModelError("Student.GPA", "Please enter your GPA.");
            }

            if (studentVM.Student.Major.MajorId == 0)
            {
                ModelState.AddModelError("Student.Major", "Please select your major.");
            }

            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }

            else
            {
                //Send back to entry form

                studentVM.SetCourseItems(CourseRepository.GetAll());

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                return View("Add", studentVM);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.Student.Courses = GetCoursesGet(viewModel);
         
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            var student = StudentRepository.Get(studentVM.Student.StudentId); 
                student.Courses = GetCoursesPost(studentVM);                
                student.GPA = studentVM.Student.GPA;
                student.Major = GetMajorId(studentVM, student);
  
            if (studentVM.Student.Address != null)
            {
                StudentRepository.SaveAddress(student.StudentId, studentVM.Student.Address);
            }

            StudentRepository.Edit(student);

            return RedirectToAction("List");
        }

        private Major GetMajorId(StudentVM studentVM, Student student)
        {
            //instantiating over studentVM
            StudentVM viewModel = new StudentVM();
            viewModel.Student.Major = new Major();

            if (studentVM.Student.Major != null)
            {
                student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                return (student.Major);
            }
            else
            {
                studentVM.Student.Major = MajorRepository.Get(student.Major.MajorId);
                return (studentVM.Student.Major);

            }
           
        }

        private List<Course> GetCoursesGet(StudentVM studentVM)
        {
            foreach (var course in studentVM.Student.Courses)
                studentVM.SelectedCourseIds.Add(course.CourseId);

            return (studentVM.Student.Courses);
        }

        private List<Course> GetCoursesPost(StudentVM studentVM)
        {
            StudentVM viewModel = new StudentVM();
            viewModel.Student.Courses = new List<Course>();
           
            foreach (var id in studentVM.SelectedCourseIds)
                viewModel.Student.Courses.Add(CourseRepository.Get(id));

            return (viewModel.Student.Courses);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentVM studentVM)
        {

            StudentRepository.Delete(studentVM.Student.StudentId);

            return RedirectToAction("List");
        }
    }
}