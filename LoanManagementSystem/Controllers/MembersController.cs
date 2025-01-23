using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private string connectionString = @"Server=(LocalDb)\MSSQLLocalDB;Database=LoanManagementDB;Trusted_Connection=True;";

        // GET: Members
        public ActionResult Index()
        {
            var members = GetMembers();
            return View(members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                InsertMember(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // Helper method to get members from the database
        private List<Member> GetMembers()
        {
            var members = new List<Member>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Member", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    members.Add(new Member
                    {
                        MemberId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Contact = reader.GetString(2),
                        Email = reader.GetString(3),
                        Address = reader.GetString(4),
                        CreatedDate = reader.GetDateTime(5)
                    });
                }
            }
            return members;
        }

        // Helper method to insert a new member into the database
        private void InsertMember(Member member)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Member (Name, Contact, Email, Address) VALUES (@Name, @Contact, @Email, @Address)", connection);
                command.Parameters.AddWithValue("@Name", member.Name);
                command.Parameters.AddWithValue("@Contact", member.Contact);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Address", member.Address);
                command.ExecuteNonQuery();
            }
        }

    }
}
