using Microsoft.AspNet.Identity;
using School.Models.SchoolModel;
using School.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoolApp.Controllers
{
    public class SchoolController : Controller
    {
        public SchoolService CreateSchoolService()
        {

            // Guid is a 128-bit integer number used to identify resources
            //GUIDs are used to identify user accounts, documents, software, hardware, software interfaces, sessions, database keys and other items.
            //At some point there is no way to store a value as a Guid,Therefore you should use Guid.Parse(), and User.Identity.GetUserId() return string
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolService(userId);
            return service;
        }
        //Helper methods to bring my List of teachers and classrooms

        public  IEnumerable<SelectListItem> GetTeachers()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var Service = new TeacherService(userId);
            var List =  Service.GetAllTeachers();

            var SelectList = List.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.SchoolId.ToString(),

                                                Text = e.TeacherName
                                            }
                                        ).ToList();

            return SelectList;
        }
        public IEnumerable<SelectListItem> GetAllClassrooms()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var Service = new ClassRoomService(userId);
            var List = Service.GetClassrooms();

            var SelectList = List.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.ClassRoomId.ToString(),

                                                Text = e.ClassRomName
                                            }
                                        ).ToList();

            return SelectList;
        }
        public ActionResult Index()
        {
            var service = CreateSchoolService();
            var model = service.GetAllSchools();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            ViewBag.TeacherId = GetTeachers();
            ViewBag.TeacherId = GetAllClassrooms();
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);

            return View(model);
        }

        public ActionResult Create()
        {



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate model)
        {
            if (!ModelState.IsValid)
            {


                return View(model);

            }
            var svc = CreateSchoolService();

            if (svc.CreateSchool(model))
            {
                TempData["SaveResult"] = "Your School was created.";
                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "School could not be created.");//?

            return View(model);


        }


        public ActionResult Edit(int id)
        {
            var svc = CreateSchoolService();
            var detail = svc.GetSchoolById(id);
            var model =
                new SchoolEdit
                {
                    SchoolId = detail.SchoolId,
                    SchoolName = detail.SchoolName,


                };



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SchoolEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.SchoolId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");


                return View(model);
            }
            var svc = CreateSchoolService();
            if (svc.UpdateSchool(model))
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
            var svc = CreateSchoolService();
            var detail = svc.GetSchoolById(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClass(int id)
        {
            var svc = CreateSchoolService();
            svc.DeleteSchool(id);
            TempData["SaveResult"] = "Your Teacher was successfully deleted.";

            return RedirectToAction("Index");
        }
    }
}