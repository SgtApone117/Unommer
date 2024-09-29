using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unommer.Models
{
    public class Debrief
    {
        public string teacher_email { get; set; }

        public string password { get; set; }

        public int result { get; set; }
    }
    

    public class DebriefInsert
    {

        public int request_id { get; set; }

        public string debrief_subject { get; set; }

        public string filename { get; set; }

        public string sentfilename { get; set; }

        public string parentmail { get; set; }

        public string teachermail { get; set; }
    }

    public class Debrief_Parent
    {
        public string parent_mail { get; set; }
        public string password { get; set; }

        public int result { get; set; }
    }

    
}