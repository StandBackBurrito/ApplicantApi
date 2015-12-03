using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantApi.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IpAddress { get; set; }
    }

    public class Application
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}