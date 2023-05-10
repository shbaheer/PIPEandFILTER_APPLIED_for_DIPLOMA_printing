using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dip2.Models
{
    public class faclty
    {

        public int ID { get; set; }
        public int DRID { get; set; }
        public bool Approval { get; set; }
        public virtual Diploma_Request Diploma_Request { get; set; }
    }
}