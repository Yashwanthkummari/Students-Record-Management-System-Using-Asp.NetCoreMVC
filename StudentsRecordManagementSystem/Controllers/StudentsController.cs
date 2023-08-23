using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsRecordManagementSystem.Models;
using System.Collections.Generic;

namespace StudentsRecordManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        StudentsDataAccessLayer studentsDataAccessLayer = null;
        public StudentsController()
        {
            studentsDataAccessLayer = new StudentsDataAccessLayer();
        }
        // GET: StudentsController
        public ActionResult Index()
        {
            IEnumerable<Students> students = studentsDataAccessLayer.GetAllStudent();
            return View(students);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            Students students = studentsDataAccessLayer.GetStudentData(id);
            return View(students);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students students)
        {
            try
            {
                studentsDataAccessLayer.AddStudent(students);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            Students students = studentsDataAccessLayer.GetStudentData(id);
            return View(students);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Students students)
        {
            try
            {
                studentsDataAccessLayer.UpdateStudent(students);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            Students students = studentsDataAccessLayer.GetStudentData(id);
            return View(students);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Students students)
        {
            try
            {
                studentsDataAccessLayer.DeleteStudent(students.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
