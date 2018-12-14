using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RatingsPro.Web.Models;
namespace RatingsPro.Web.Controllers
{
    public class JqGridController : Controller
    {
        // GET: JqGrid
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetValues(string sidx, string sord, int page, int rows) //Gets the todo Lists.  
        {
            List<Users> userList = new List<Users>();
            userList.Add(new Users() { Id = 1, Name = "Santosh saini", Phone = 9877, Address = "UNR", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 2, Name = "rohit", Phone = 9877, Address = "xyz", DOB = DateTime.Now.AddMonths(-2) });
            userList.Add(new Users() { Id = 3, Name = "akash", Phone = 9877, Address = "pqr", DOB = DateTime.Now.AddMonths(-1) });
            userList.Add(new Users() { Id = 4, Name = "mahesh", Phone = 9877, Address = "UNR", DOB = DateTime.Now.AddMonths(-4) });
            userList.Add(new Users() { Id = 5, Name = "mohit", Phone = 9877, Address = "xyz", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 6, Name = "kiran", Phone = 9877, Address = "pqr", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 7, Name = "pooja", Phone = 9877, Address = "UNR", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 8, Name = "xyz", Phone = 9877, Address = "xyz", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 9, Name = "PQR", Phone = 9877, Address = "pqr", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 10, Name = "Santosh saini", Phone = 9877, Address = "UNR", DOB = DateTime.Now.AddYears(-1) });
            userList.Add(new Users() { Id = 11, Name = "xyz", Phone = 9877, Address = "xyz", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 12, Name = "PQR", Phone = 9877, Address = "pqr", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 13, Name = "Santosh saini", Phone = 9877, Address = "UNR", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 14, Name = "xyz", Phone = 9877, Address = "xyz", DOB = DateTime.Now.AddYears(-2)});
            userList.Add(new Users() { Id = 15, Name = "PQR", Phone = 9877, Address = "pqr", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 16, Name = "Santosh saini", Phone = 9877, Address = "UNR", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 17, Name = "xyz", Phone = 9877, Address = "xyz", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 18, Name = "PQR", Phone = 9877, Address = "pqr", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 19, Name = "Santosh saini", Phone = 9877, Address = "UNR", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 20, Name = "xyz", Phone = 9877, Address = "xyz", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 21, Name = "PQR", Phone = 9877, Address = "pqr", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 22, Name = "Santosh saini", Phone = 9877, Address = "UNR", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 23, Name = "xyz", Phone = 9877, Address = "xyz", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 24, Name = "PQR", Phone = 9877, Address = "pqr", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 25, Name = "Santosh saini", Phone = 9877, Address = "UNR", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 26, Name = "xyz", Phone = 9877, Address = "xyz", DOB = DateTime.Now });
            userList.Add(new Users() { Id = 27, Name = "PQR", Phone = 9877, Address = "pqr", DOB = DateTime.Now });

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = userList.Select(
                a => new
                {
                    a.Id,
                    a.Name,
                    a.Phone,
                    a.Address,
                    a.DOB,
                });
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // TODO:insert a new row to the grid logic here  
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Users obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    // db.Users.Add(obj);
                    // db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Edit(Users obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(obj).State = EntityState.Modified;
                    //db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Delete(int Id)
        {
            //Users list = db.Users.Find(Id);
            //db.Users.Remove(list);
            //db.SaveChanges();
            return "Deleted successfully";
        }
    }
}