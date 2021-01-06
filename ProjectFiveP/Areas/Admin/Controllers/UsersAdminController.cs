using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFiveP.Models;
using ProjectFiveP.Models.Json;

namespace ProjectFiveP.Areas.Admin.Controllers
{
    public class UsersAdminController : Controller
    {
        private DataProjectFivePEntities db = new DataProjectFivePEntities();

        // GET: Admin/UsersAdmin
        public ActionResult Index()
        {
            var users = db.Users.Where(n => n.role_id == 1 && n.user_active == true && n.user_bin == false).ToList();
            return View(users);
        }
        public JsonResult IndexListUsers()
        {
            List<User> users = db.Users.Where(n=>n.user_bin == false).ToList();
            List<ListUsers> listUsers = users.Select(n => new ListUsers
            {
                user_id = n.user_id,
                user_name = n.user_name,
                user_pass = n.user_pass,
                user_email = n.user_email,
                user_token = n.user_token,
                user_code = n.user_code,
                role_id = n.role_id,
                user_active = n.user_active,
                user_option = n.user_option,
                user_datecreate = n.user_datecreate.ToString(),
                user_datelogin = n.user_datelogin.ToString(),
                user_bin = n.user_bin,
                user_dateedit = n.user_dateedit.ToString(),
                user_img = n.user_img,
                Role = n.Role.role_name
            }).ToList();
            return Json(listUsers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckAction(int? id)
        {
            User user = db.Users.Find(id);
            user.user_active = !user.user_active;
            db.SaveChanges();
            return Json(user,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int? id)
        {
            User user = db.Users.Find(id);
            user.user_bin = true;
            db.SaveChanges();
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/UsersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/UsersAdmin/Create
        public ActionResult Create()
        {
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name");
            return View();
        }

        // POST: Admin/UsersAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_pass,user_email,user_token,user_code,role_id,user_active,user_option,user_datecreate,user_datelogin,user_bin,user_dateedit,user_img")] User user, HttpPostedFileBase fileImg)
        {
            User user1 = db.Users.SingleOrDefault(n => n.user_email == user.user_email);
            Random random = new Random();
            ViewBag.random = random.Next(0, 1000);

            if (user1 != null)
            {
                TempData["EmailExist"] = "Email đã tồn tại!";
                
            }
            else
            {

                db.Users.Add(user);
                if (fileImg == null)
                {
                    user.user_img = "images.png";

                }
                else
                {
                    var varFileImg = Path.GetFileName(fileImg.FileName);
                    //Lưu file
                    var pa = Path.Combine(Server.MapPath("~/Image/Users"), ViewBag.random + varFileImg);

                    fileImg.SaveAs(pa);
                    user.user_img = ViewBag.random + fileImg.FileName;
                }
                user.user_token = Guid.NewGuid().ToString();
                user.user_datecreate = DateTime.Now;
                user.user_datelogin = DateTime.Now;
                user.user_dateedit = DateTime.Now;
                user.user_bin = false;
                db.SaveChanges();
                User code = db.Users.SingleOrDefault(n => n.user_email == user.user_email);
                return RedirectToAction("CreateCode", new { id = code.user_id });
            }
            return View(user);
        }
        public RedirectResult CreateCode(int? id)
        {
            User user = db.Users.Find(id);
            user.user_code = "#user-" + id;
            db.SaveChanges();
            HttpCookie cookie = new HttpCookie("user_id", user.user_id.ToString());
            cookie.Expires.AddDays(10);
            Response.Cookies.Set(cookie);
            return Redirect("/Admin/HomeAdmin/Index");
        }

        // GET: Admin/UsersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name", user.role_id);
            return View(user);
        }

        // POST: Admin/UsersAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_pass,user_email,user_token,user_code,role_id,user_active,user_option,user_datecreate,user_datelogin,user_bin,user_dateedit,user_img")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name", user.role_id);
            return View(user);
        }

        // GET: Admin/UsersAdmin/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: Admin/UsersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
