using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unommer.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        //public string LastName { get; set; }

        public string Email { get; set; }

        public string Subjects { get; set; }

        public string Designation { get; set; }

        public string Class { get; set; }

        public string Section { get; set; }

        public string Status { get; set; }

        public int Result { get; set; }

        public string Pass { get; set; }

        public string Guid { get; set; }

        public List<Teachers> Teacher_Records_List = new List<Teachers>();
    }

   
}