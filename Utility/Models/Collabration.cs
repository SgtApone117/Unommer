using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unommer.Models
{
    public class CollabStudDetails
    {
        public string parent_email{ get; set; }

        public string Class {get; set;}
    }


    public class CollabTeacherDetails
    {
        public string Teacher_Subject { get; set; }

        //public string Teacher_name { get; set; }
        public string Section { get; set; }
        public string Class { get; set; }

        
    }

    public class CollabParentData
    {
        public string parent_mail { get; set; }
    }

    public class TeacherInfo
    {
        public string teacher_email { get; set; }
    }

    public class StudentInfo
    { 
           public string class_name{get; set;}

           public string section { get; set; }
    }

    public class CollabTeacherFetch
    {
        public string Teacher_mail { get; set; }

    }

    public class CollabTeachDelete
    {
        public int req_id { get; set; }

        public decimal start_time { get; set; }

        public decimal end_time { get; set; }

        public string req_date { get; set; }

        public string teacher_mail { get; set; }

        public string choice { get; set; }
    }

    public class ParentCollabDetails
    {
        public string parent_mail { get; set; }
    }

    public class CollabParentDelete
    {
        public int req_id { get; set; }

        public decimal start_time { get; set; }

        public decimal end_time { get; set; }

        public string req_date { get; set; }

        public string choice { get; set; }

        public string teachername { get; set; }

        public string parent_mail { get; set; }

        public string reason { get; set; }

    }

    public class roster_info_fetch
    {

        public string teacher_email{get; set;}

        public string month { get; set; }

        public string year { get; set; }
    }
  
    public class roster_modify
    {
        public string teacher_email { get; set; }

        public string date { get; set; }

        public string nstring { get; set; }
    }
}