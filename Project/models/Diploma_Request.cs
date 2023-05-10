using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dip2.Models
{
    public class Diploma_Request
    {
        public int ID { get; set; }
        public string   Name { get; set; }
        public string IDCardID { get; set; }

        public String  Graduate { get; set; }
        public virtual List<DepartmentApproval> DepartmentApprovals { get; set; }
        public virtual List<faclty> faculty { get; set; }
        public virtual List<Admin> Admin { get; set; }
        public virtual List<Printing> Printing { get; set; }

    }
}