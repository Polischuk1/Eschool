using System;
using System.Web.UI;

namespace CourseWorkSoftwarePolishchukOlha
{
    public partial class TeacherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Add your authentication logic here
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Example authentication logic (replace with your actual authentication logic)
            if (username == "teacher" && password == "password")
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
