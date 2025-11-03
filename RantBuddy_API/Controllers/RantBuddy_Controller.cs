using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using RantBuddy_Common;
using RantBuddy_BusinessDataLogic;

namespace RantBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RantController : ControllerBase
    {
        private readonly string connectionString = "Data Source=VERSOZA\\SQLEXPRESS;Initial Catalog=Rant_Buddy;Integrated Security=True";
        private readonly EmailService _emailService;

        public RantController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult GetRants()
        {
            List<Rant> rants = new List<Rant>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Content FROM Rants";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rants.Add(new Rant
                    {
                        Username = reader["Username"].ToString(),
                        Content = reader["Content"].ToString()
                    });
                }
            }

            return Ok(rants);
        }

        [HttpPost]
        public IActionResult AddRant([FromBody] Rant rant)
        {
            if (rant == null || string.IsNullOrWhiteSpace(rant.Username) || string.IsNullOrWhiteSpace(rant.Content))
                return BadRequest("Username and content are required.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Rants (Username, Content) VALUES (@Username, @Content)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", rant.Username);
                cmd.Parameters.AddWithValue("@Content", rant.Content);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // ✅ Send email notification
            try
            {
                _emailService.SendEmail(rant.Username, rant.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Email sending failed: {ex.Message}");
            }

            return Ok("Rant added successfully and email notification sent!");
        }



        [HttpPut]
        public IActionResult UpdateRant([FromBody] Rant rant)
        {
            if (rant == null || string.IsNullOrWhiteSpace(rant.Username) || string.IsNullOrWhiteSpace(rant.Content))
                return BadRequest("Username and content are required.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Rants SET Content = @Content WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", rant.Username);
                cmd.Parameters.AddWithValue("@Content", rant.Content);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                    return NotFound("Rant not found.");
            }

            try
            {
                _emailService.SendEmail(rant.Username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
            }

            return Ok("Rant updated and email notification sent.");
        }

        [HttpDelete]
        public IActionResult DeleteRant([FromBody] Rant rant)
        {
            if (rant == null || string.IsNullOrWhiteSpace(rant.Username) || string.IsNullOrWhiteSpace(rant.Content))
                return BadRequest("Username and content are required.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Rants WHERE Username = @Username AND Content = @Content";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", rant.Username);
                cmd.Parameters.AddWithValue("@Content", rant.Content);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                    return NotFound("Rant not found.");
            }

            return Ok("Rant deleted.");
        }
    }
}

