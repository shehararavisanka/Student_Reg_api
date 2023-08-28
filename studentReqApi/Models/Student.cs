using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studentReqApi.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public int regNo { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string nic { get; set; }

        public string mobile { get; set; }

        public int typ { get; set; }
    }
}