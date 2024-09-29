using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Unommer.Models
{
    public class Demo
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string NameofSchool { get; set; }

        public string dateofdemo { get; set; }

        public string timeofdemo { get; set; }
    }
}