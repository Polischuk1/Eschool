using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace CourseWorkSoftwarePolishchukOlha
{
    public partial class TeacherPage : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Query to check if the provided credentials exist in the Teachers table
            string query = "SELECT COUNT(*) FROM Teachers WHERE username = @Username AND [password] = @Password";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Redirect to the teacher dashboard upon successful login
                        Response.Redirect("TeacherDashboard.aspx");
                    }
                    else
                    {
                        // Display error message for invalid credentials
                        lblMessage.Text = "Invalid username or password.";
                    }
                }
            }
        }
    }
}
