using Microsoft.AspNet.Identity;
using School.Models.TeacherModel;
using School.Service;
using ShoolApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoolApp.Controllers
{
    public class TeacherController : Controller
    {

        ApplicationDbContext _db = new ApplicationDbContext();
        public TeacherService CreateTeacherService()
        {

            // Guid is a 128-bit integer number used to identify resources
            //GUIDs are used to identify user accounts, documents, software, hardware, software interfaces, sessions, database keys and other items.
            //At some point there is no way to store a value as a Guid,Therefore you should use Guid.Parse(), and User.Identity.GetUserId() return string
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeacherService(userId);
            return service;
        }


        public ActionResult Index()
        {
            var service = CreateTeacherService();
            var model = service.GetAllTeachers();
            return View(model);
        }

        public ActionResult Details(int id)
        {

            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }

        public ActionResult Create()
        {


            ViewData["Schools"] = _db.Schools.Select(e => new SelectListItem
            {
                Text = e.SchoolName,
                Value = e.SchoolId.ToString()
            }); ;



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherCreate model)
        {
            if (!ModelState.IsValid)
            {


                return View(model);

            }
            var svc = CreateTeacherService();

            if (svc.CreateTeacher(model))
            {
                TempData["SaveResult"] = "Your Teacher was created.";
                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "Teacher could not be created.");//?

            return View(model);


        }


        public ActionResult Edit(int id)
        {
            var svc = CreateTeacherService();
            var detail = svc.GetTeacherById(id);

            if(detail == null)
            {
                return HttpNotFound();
            }
            var model =
                new TeacherEdit
                {
                    TeacherId = detail.TeacherId,
                    TeacherName = detail.TeacherName,

                };
            ViewData["Schools"] = _db.Schools.Select(e => new SelectListItem
            {
                Text = e.SchoolName,
                Value = e.SchoolId.ToString()
            }); 

            


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeacherEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.TeacherId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");


                return View(model);
            }
            var svc = CreateTeacherService();
            if (svc.UpdateTeacher(model))
            {
                TempData["SaveResult"] = "Teacher was successfully updated.";
                return RedirectToAction("Index");
            }


            ModelState.AddModelError("", "Menu could not be updated.");
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeacherService();
            var detail = svc.GetTeacherById(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClass(int id)
        {
            var svc = CreateTeacherService();
            svc.DeleteTeacher(id);
            TempData["SaveResult"] = "Your Teacher was successfully deleted.";

            return RedirectToAction("Index");
        }
    }
}