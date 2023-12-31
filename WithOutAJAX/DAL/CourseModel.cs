using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class CourseModel
    {
        public string CID { get; set; }
        public string CName { get; set; }
        public int CDuration { get; set; }
        public int CFees { get; set; }
    }
}