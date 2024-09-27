using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unommer.Models
{


    public class SchoolRegistration
    {
        public string Pass { get; set; }

        public string SchoolName { get; set; }
        public string Address { get; set; }
        public string SchoolBoard { get; set; }
        public string City { get; set; }
        public string TelphoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string AffiliationNumber { get; set; }
        public string AdministratorName { get; set; }
        public string AdministratorEmail { get; set; }
        public string AdministratorContactNum { get; set; }
        public string RegistrationDate { get; set; }
        public string Guid { get; set; }
        public int Result { get; set; }


    }

    public class TeacherRegistration
    {
        public string Pass { get; set; }

        public string Teacher_Name { get; set; }

        public string Teacher_Mail { get; set; }

        public string Teacher_Reg_Date { get; set; }

        public string Guid { get; set; }

        public int Result { get; set; }

    }

    public class ParentRegistration
    {
        public string Pass { get; set; }

        public string Parent_Name { get; set; }

        public string Parent_mail { get; set; }

        public string Parent_Reg_Date { get; set; }

        public string Parent_type { get; set; }

        public string Guid { get; set; }

        public int Result { get; set; }

        public string NewPass { get; set; }

        public List<StudentDetails> StudentList = new List<StudentDetails>();

    }

    public class Admin_Update 
    {
        public string NewPass { get; set; }

       // public string Currentpass { get; set; }

        public string AdminEmail { get; set; }
    }


    public class StudentDetails
    {
        public string Student_FirstName { get; set; }

        public string Student_LastName { get; set; }

        public string Class { get; set; }

        public string Section { get; set; }

        public int RollNo { get; set; }

        public string FatherMail { get; set; }

        public string MotherMail { get; set; }

        public string GuardianMail { get; set; }

        public string Status { get; set; }

        public int result { get; set; }

    }

    public class SchoolDetails
    {
        public string School_Address { get; set; }

        public string School_TelephoneNo { get; set; }

        public string School_MobileNo { get; set; }

        public string School_admin { get; set; }

        public string School_Name { get; set; }

        public List<SchoolDetails> SchoolList = new List<SchoolDetails>();
    }

    public class RosterDetails
    {
        public int Teacher_id { get; set; }

        public string Teacher_email { get; set; }

        public int result { get; set; }

        public string month { get; set; }

        public string year { get; set; }

        public string topic { get; set; }

       // public List<RosterDetails> ;
    
    }


    public class avail_temp
    {

        public string Template_Name { get; set; }

        public string Template_Status { get; set; }

        public string Day { get; set; }

        public string StartTimeMonMorng { get; set; }

        public string EndTimeMonMorng { get; set; }

        public string StartTimeMonAfter { get; set; }

        public string EndTimeMonAfter { get; set; }

        
    }

    public class collab_request {
        public string collab_type { get; set; }

        public int student_id { get; set; }

        public string requestor { get; set; }

        public string requestor_type { get; set; }

        public string class_no {get;  set;}

        public string subject { get; set; }

        public string section { get; set; }

        public int teacher_id { get; set; }

        public string parent_id { get; set; }

        public decimal start_time { get; set; }

        public decimal end_time { get; set; }

        public string date { get; set; }

        public string teacher_mail { get; set; }
    }




    public class Teachers_Data_Roster {

        public int Teacher_id { get; set; }
        public string Pass { get; set; }

        public string Teacher_Name { get; set; }

        public string Teacher_Mail { get; set; }

        public string Teacher_Reg_Date { get; set; }

        public string Guid { get; set; }

        public int Result { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public string Month { get; set; }

        public string Year { get; set; }

        public string TemplateName { get; set; } 

    }

    public class Teacher_fetch_Roster
    {
        public int teacher_id { get; set; }

        public string date { get; set; }

        public string parent_id { get; set; }

        public decimal start_time { get; set; }

        public decimal end_time { get; set; }

        public int student_id { get; set; }

        public string collab_type { get; set; }

        public string class_no { get; set; }

        public string subject { get; set; }

        public string section { get; set; }

        public string requestor { get; set; }

        public string teacher_mail { get; set; }


        public string topic { get; set; }
        
    }
}