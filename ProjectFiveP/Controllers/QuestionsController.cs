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
    public class QuestionsController : Controller
    {
        private DataProjectFivePEntities db = new DataProjectFivePEntities();

        public ActionResult Question()
        {
            var questions = db.Questions.Include(q => q.User);
            return View(questions.ToList());
        }
        // GET: Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.User);
            return View(questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "question_id,question_content,question_dateCreate,question_dateEdit,user_id,question_activate,question_title,question_totalAnswer,question_totalComment,question_view,question_totalRate,question_medalCalculator,question_recycleBin,question_userStatus,question_popular,question_admin_recycleBin")] Question question)
        {
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            db.Questions.Add(question);


            question.question_dateCreate = DateTime.Now;
            question.question_dateEdit = DateTime.Now;
            question.user_id = user_id;
            question.question_activate = true;
            question.question_totalAnswer = 0;
            question.question_totalComment = 0;
            question.question_view = 0;
            question.question_totalRate = 0;
            question.question_medalCalculator = 0;
            question.question_recycleBin = false;
            question.question_admin_recycleBin = false;
            question.question_userStatus = true;
            question.question_popular = 0;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", question.user_id);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "question_id,question_content,question_dateCreate,question_dateEdit,user_id,question_activate,question_title,question_totalAnswer,question_totalComment,question_view,question_totalRate,question_medalCalculator,question_recycleBin,question_userStatus,question_popular,question_admin_recycleBin")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", question.user_id);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
