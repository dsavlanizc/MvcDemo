using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class DefaultController : Controller
    {
        MyContext cnt = new MyContext();
        //
        // GET: /Default/
        public ActionResult Index()
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
                return View();
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Create()
        {
            Student student = new Student();
            student.ID = cnt.Students.Max(m => m.ID) + 1;
            return View(student);
        }

        public ActionResult ShowAll()
        {
            var std = cnt.Students.ToList();
            return View(std);
        }
        
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                MyContext context = new MyContext();
                try
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    ViewBag.Result = "Student Created successfully!";
                    ModelState.Clear();
                    //return RedirectToAction("ShowAll");
                }
                catch (Exception ex)
                {
                    ViewBag.Result = ex.ToString();
                }
                
                student = new Student();
                student.ID = cnt.Students.Max(m => m.ID) + 1;
                return View(student);
            }
            else
            {
                student = new Student();
                student.ID = cnt.Students.Max(m => m.ID) + 1;
                return View(student);
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
