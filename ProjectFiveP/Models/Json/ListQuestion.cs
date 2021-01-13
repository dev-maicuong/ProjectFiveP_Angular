using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFiveP.Models.Json
{
    public class ListQuestion
    {
        public int question_id { get; set; }
        public string question_content { get; set; }
        public string question_dateCreate { get; set; }
        public string question_dateEdit { get; set; }
        public int user_id { get; set; }
        public Nullable<bool> question_activate { get; set; }
        public string question_title { get; set; }
        public Nullable<int> question_totalAnswer { get; set; }
        public Nullable<int> question_totalComment { get; set; }
        public Nullable<int> question_view { get; set; }
        public Nullable<int> question_totalRate { get; set; }
        public Nullable<int> question_medalCalculator { get; set; }
        public Nullable<bool> question_recycleBin { get; set; }
        public Nullable<bool> question_userStatus { get; set; }
        public Nullable<int> question_popular { get; set; }
        public Nullable<bool> question_admin_recycleBin { get; set; }
        public string user_name { get; set; }

    }
}