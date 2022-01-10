using Microsoft.AspNet.Identity;
using School.Models.ClassRoomModel;
using School.Service;
using ShoolApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoolApp.Controllers
{
    public class ClassRoomController : Controller
    {

        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: ClassRoom
        public ClassRoomService CreateClassRoomService()
        {

            // Guid is a 128-bit integer number used to identify resources
            //GUIDs are used to identify user accounts, documents, software, hardware, software interfaces, sessions, database keys and other items.
            //At some point there is no way to store a value as a Guid,Therefore you should use Guid.Parse(), and User.Identity.GetUserId() return string
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClassRoomService(userId);
            return service;
        }


        public ActionResult Index()
        {
            var service = CreateClassRoomService();
            var model = service.GetClassrooms();
            return View(model);
        }

        public ActionResult Details(int id)
        {

            var svc = CreateClassRoomService();
            var model = svc.GetClassRoomById(id);

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
        public ActionResult Create(ClassRoomCreate model)
        {
            if (!ModelState.IsValid)
            {


                return View(model);

            }
            var svc = CreateClassRoomService();

            if (svc.CreateClassRoom(model))
            {
                TempData["SaveResult"] = "Your Classroom was created.";
                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "Classroom could not be created.");//?

            return View(model);


        }


        public ActionResult Edit(int id)
        {
            var svc = CreateClassRoomService();
            var detail = svc.GetClassRoomById(id);

            ViewData["Schools"] = _db.Schools.Select(e => new SelectListItem
            {
                Text = e.SchoolName,
                Value = e.SchoolId.ToString()
            }); ;
            var model =
                new ClassRoomEdit
                {
                    ClassRoomId = detail.ClassRoomId,
                    ClassRomName = detail.ClassRomName,


                };



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClassRoomEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ClassRoomId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
               

                return View(model);
            }
            var svc = CreateClassRoomService();
            if ( svc.UpdateClassRoom(model))
            {
                TempData["SaveResult"] = "Classroom was successfully updated.";
                return RedirectToAction("Index");
            }
           

            ModelState.AddModelError("", "Classroom could not be updated.");
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var svc = CreateClassRoomService();
            var detail = svc.GetClassRoomById(id);
            return View(detail);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClass(int id)
        {
            var svc = CreateClassRoomService();
            svc.DeleteClassRoom(id);
            TempData["SaveResult"] = "Your Classroom was successfully deleted.";

            return RedirectToAction("Index");
        }

       

    }
}