using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFiveP.Models;

namespace ProjectFiveP.Controllers
{
    public class UsersController : Controller
    {
        private DataProjectFivePEntities db = new DataProjectFivePEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: Users/Details/5
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            String strUserEmail = f["user_email"].ToString();
            String strUserPass = f["user_pass"].ToString();
            User user = db.Users.Where(n=>n.user_active == true && n.user_bin == false && n.Role.role_id == 1).SingleOrDefault(n => n.user_email == strUserEmail && n.user_pass == strUserPass);
            if(user != null)
            {
                user.user_datelogin = DateTime.Now;
                db.SaveChanges();
                HttpCookie cookie = new HttpCookie("user_id",user.user_id.ToString());
                cookie.Expires.AddDays(10);
                Response.Cookies.Set(cookie);
                return Redirect("/HomeCenter/Index");
            }
            else
            {
                ViewBag.Login = "Email hoặc mật khẩu sai! Vui lòng nhập lại!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("user_id");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return Redirect("/Users/Login");
        }
        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_pass,user_email,user_token,user_code,role_id,user_active,user_option,user_datecreate,user_datelogin,user_bin,user_dateedit")] User user)
        {
            User checkEmail = db.Users.SingleOrDefault(n => n.user_email == user.user_email);
            if(checkEmail != null)
            {
                ViewBag.CheckEmail = "Email đã tồn tại! Vui lòng chọn email khác!";
            }
            else
            {
                user.user_token = Guid.NewGuid().ToString();
                user.role_id = 1;
                user.user_active = true;
                user.user_option = 1;
                user.user_datecreate = DateTime.Now;
                user.user_datelogin = DateTime.Now;
                user.user_bin = false;
                user.user_dateedit = DateTime.Now;
                user.user_img = "images.png";
                db.Users.Add(user);
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
            HttpCookie cookie = new HttpCookie("user_id", id.ToString());
            cookie.Expires.AddDays(10);
            Response.Cookies.Set(cookie);
            return Redirect("/HomeCenter/Index");
        }

        // GET: Users/Edit/5
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

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_pass,user_email,user_token,user_code,role_id,user_active,user_option,user_datecreate,user_datelogin,user_bin,user_dateedit")] User user)
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

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Users/Delete/5
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
