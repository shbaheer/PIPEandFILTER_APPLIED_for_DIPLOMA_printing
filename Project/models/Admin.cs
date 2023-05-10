using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dip2.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public int DRID { get; set; }
        public bool Fee { get; set; }
        public bool DeanApproval { get; set; }
        public virtual Diploma_Request Diploma_Request { get; set; }
    }
}