using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CourseWorkSoftwarePolishchukOlha
{
    public partial class TeacherDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAttendanceData();
            }
        }

        private void LoadAttendanceData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "SELECT student_id, full_name FROM Students";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int studentId = reader.GetInt32(0);
                        string fullName = reader.GetString(1);

                        TableRow row = new TableRow();

                        TableCell cellId = new TableCell();
                        cellId.Text = studentId.ToString();
                        row.Cells.Add(cellId);

                        TableCell cellName = new TableCell();
                        cellName.Text = fullName;
                        row.Cells.Add(cellName);

                        TableCell cellAttendance = new TableCell();
                        cellAttendance.Controls.Add(new CheckBox { ID = "chkAttendance_" + studentId });
                        row.Cells.Add(cellAttendance);

                        // Append the row to the table
                        AttendanceTable.Rows.Add(row);
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            foreach (TableRow row in AttendanceTable.Rows)
            {
                if (row is TableHeaderRow)
                {
                    continue; // Skip the header row
                }

                int studentId = int.Parse(row.Cells[0].Text);
                bool isPresent = ((CheckBox)row.Cells[2].Controls[0]).Checked;

                // Update attendance status in the database
                UpdateAttendance(connectionString, studentId, isPresent);
            }

            // Show success message
            lblMessage.Text = "Attendance saved successfully.";
            lblMessage.Visible = true;
        }

        private void UpdateAttendance(string connectionString, int studentId, bool isPresent)
        {
            string query = "UPDATE Attendance SET [status] = @Status WHERE student_id = @StudentId AND CONVERT(DATE, [date]) = @Date";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@Status", isPresent ? "Present" : "Absent");
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.Date); // Use only date part

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log the error, display a message to the user)
                        lblMessage.Text = "Error updating attendance: " + ex.Message;
                        lblMessage.Visible = true;
                    }
                }
            }
        }


        protected void btnAddStudent_Click(object sender, EventArgs e)
        {

        }
    }
}
