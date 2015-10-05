using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcDemo.Controllers
{
    public class DefaultController : Controller
    {
        MyContext dbCtx = new MyContext();
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

        [Authorize]
        public ActionResult Create()
        {
            Student student = new Student();
            student.RollNo = dbCtx.Students.Max(m => m.RollNo) + 1;
            return View(student);
        }

        public ActionResult ShowAll()
        {
            var std = dbCtx.Students.ToList();
            return View(std);
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dbCtx.Students.Add(student);
                    dbCtx.SaveChanges();
                    ViewBag.Result = "Student Created successfully!";
                    ModelState.Clear();
                    //return RedirectToAction("ShowAll");
                }
                catch (Exception ex)
                {
                    ViewBag.Result = ex.ToString();
                }

                student = new Student();
                student.ID = dbCtx.Students.Max(m => m.ID) + 1;
                return View(student);
            }
            else
            {
                student = new Student();
                student.ID = dbCtx.Students.Max(m => m.ID) + 1;
                return View(student);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(dbCtx.Students.Where(w => w.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Student _student = dbCtx.Students.Where(w => w.ID == student.ID).FirstOrDefault();
                    _student.FName = student.FName;
                    _student.LName = student.LName;
                    _student.EmailID = student.EmailID;
                    _student.Pswd = student.Pswd;
                    dbCtx.SaveChanges();
                    TempData["msg"] = "Student details updated successfully!";
                    return RedirectToAction("ShowAll");
                }
                catch (Exception ex)
                {
                    ViewBag.Result = ex.ToString();
                }
                return View(student);
            }
            else
            {
                //return RedirectToAction("ShowAll");
                return View(student);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Student stu)
        {
                var query = (from name in dbCtx.Students
                             where name.EmailID == stu.EmailID && name.Pswd == stu.Pswd
                             select name).FirstOrDefault();
                dbCtx.SaveChanges();
                if (query != null)
                {
                    FormsAuthentication.SetAuthCookie(stu.EmailID, true);
                    return RedirectToAction("Create");
                }
                else
                {
                    ViewBag.notfound = "Username or password is not valid";
                    return View();
                }   
        }
    }
}
