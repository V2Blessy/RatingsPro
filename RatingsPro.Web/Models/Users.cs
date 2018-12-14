using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingsPro.Web.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
    }
}