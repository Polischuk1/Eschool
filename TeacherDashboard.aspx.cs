using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace CourseWorkSoftwarePolishchukOlha
{
    public partial class TeacherDashboard : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentsData();
            }
        }

        private void LoadStudentsData()
        {
            string query = "SELECT StudentID, FullName FROM Students";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    GridViewStudents.DataSource = reader;
                    GridViewStudents.DataBind();
                }
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddNewStudent();
        }

        private void AddNewStudent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Students (FullName) VALUES (@full_name)", con);
                    cmd.Parameters.AddWithValue("@full_name", txtStudentName.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                lblStatus.Text = "Student added successfully";
                lblStatus.CssClass = "text-success";
                lblStatus.Visible = true;

                // Reload the student data after adding the student
                LoadStudentsData();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
                lblStatus.CssClass = "text-danger";
                lblStatus.Visible = true;
            }
        }

    }
}
