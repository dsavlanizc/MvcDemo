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
                GetResult();
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

                    //return RedirectToAction("ShowAll");
                }
                catch (Exception ex)
                {
                    ViewBag.Result = ex.ToString();
                }
                return View(student);
            }
            else
            {
                return View(student);
            }
            
        }
        
        public void GetResult()
        {
            if (Request["num1"] != null)
            {
                int a, b;
                int.TryParse(Request["num1"], out a);
                int.TryParse(Request["num2"], out b);
                ViewBag.myData = "Addition is: " + (a + b);
            }
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
