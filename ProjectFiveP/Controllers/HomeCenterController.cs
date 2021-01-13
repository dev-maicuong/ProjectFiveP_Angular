using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFiveP.Models;
using ProjectFiveP.Models.Json;


namespace ProjectFiveP.Controllers
{
    public class HomeCenterController : Controller
    {
        private DataProjectFivePEntities db = new DataProjectFivePEntities();
        // GET: HomeCenter
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult ListQuestions()
        {
            
            List<Question> question = db.Questions.ToList();
            List<ListQuestion> listQuestions = question.Select(n => new ListQuestion
            {
                question_id = n.question_id,
                question_content = n.question_content,
                question_dateCreate = n.question_dateCreate.ToString(),
                question_dateEdit = n.question_dateEdit.ToString(),
                question_activate = n.question_activate,
                question_title = n.question_title,
                question_totalAnswer = n.question_totalAnswer,
                question_totalComment = n.question_totalComment,
                question_view = n.question_view,
                question_totalRate = n.question_totalRate,
                question_medalCalculator = n.question_medalCalculator,
                question_recycleBin = n.question_recycleBin,
                question_userStatus = n.question_userStatus,
                question_popular = n.question_popular,
                question_admin_recycleBin = n.question_admin_recycleBin,
                user_name = n.User.user_name,
                user_id = (int)n.user_id
            }).ToList();
            return Json(listQuestions, JsonRequestBehavior.AllowGet);
        }
    }
}