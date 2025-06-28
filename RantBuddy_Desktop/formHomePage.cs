using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RantBuddy_Desktop
{
    public partial class formHomePage : Form
    {
        private string currentUsername;

        public formHomePage(string username)
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void formHomePage_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your rant:", "Add Rant", "");

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Entry cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection("Data Source=VERSOZA\\SQLEXPRESS;Initial Catalog=Rant_Buddy;Integrated Security=True"))
            {
                string query = "INSERT INTO Rants (Username, Content) VALUES (@Username, @Content)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", currentUsername);
                cmd.Parameters.AddWithValue("@Content", input);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Entry added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRead.PerformClick();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=VERSOZA\\SQLEXPRESS;Initial Catalog=Rant_Buddy;Integrated Security=True"))
            {
                string query = "SELECT * FROM Rants WHERE Username = @Username";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Username", currentUsername);

                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvRants.DataSource = table;
            }

            MessageBox.Show("Rants loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            DataGridViewRow row = dgvRants.SelectedRows[0];
            string oldContent = row.Cells["Content"].Value.ToString().Trim();

            string newContent = Microsoft.VisualBasic.Interaction.InputBox("Edit your rant:", "Update Rant", oldContent);

            if (string.IsNullOrWhiteSpace(newContent)) return;

            using (SqlConnection conn = new SqlConnection("Data Source=VERSOZA\\SQLEXPRESS;Initial Catalog=Rant_Buddy;Integrated Security=True"))
            {
                string query = "UPDATE Rants SET Content = @NewContent WHERE Username = @Username AND LTRIM(RTRIM(Content)) = @OldContent";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewContent", newContent);
                cmd.Parameters.AddWithValue("@OldContent", oldContent);
                cmd.Parameters.AddWithValue("@Username", currentUsername);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Entry updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRead.PerformClick();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string content = dgvRants.SelectedRows[0].Cells["Content"].Value.ToString().Trim();

            using (SqlConnection conn = new SqlConnection("Data Source=VERSOZA\\SQLEXPRESS;Initial Catalog=Rant_Buddy;Integrated Security=True"))
            {
                string query = "DELETE FROM Rants WHERE Username = @Username AND LTRIM(RTRIM(Content)) = @Content";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", currentUsername);
                cmd.Parameters.AddWithValue("@Content", content);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Entry deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRead.PerformClick();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Enter keyword to search:", "Search");

            if (string.IsNullOrWhiteSpace(keyword)) return;

            using (SqlConnection conn = new SqlConnection("Data Source=VERSOZA\\SQLEXPRESS;Initial Catalog=Rant_Buddy;Integrated Security=True"))
            {
                string query = "SELECT * FROM Rants WHERE Content LIKE @Keyword AND Username = @Username";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                adapter.SelectCommand.Parameters.AddWithValue("@Username", currentUsername);

                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvRants.DataSource = table;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvRants_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
