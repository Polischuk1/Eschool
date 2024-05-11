<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TeacherDashboard.aspx.cs" Inherits="CourseWorkSoftwarePolishchukOlha.TeacherDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Teacher Attendance</title>
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>

    <div class="container mt-5">
        <h2 class="text-center">Student Attendance</h2>
        <div class="row">
            <div class="col-md-12">
                <asp:Table ID="AttendanceTable" runat="server" CssClass="table table-striped table-bordered">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Student ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Student Name</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
        <div class="col-md-6">
            <!-- Add Student Section -->
            <div class="form-group">
                <label for="txtStudentId">Student ID</label>
                <asp:TextBox ID="txtStudentId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtStudentName">Full Name</label>
                <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" CssClass="btn btn-success" OnClick="btnAddStudent_Click" />
            <asp:Label ID="lblStatus" runat="server" CssClass="text-success" Visible="false"></asp:Label>

        </div>

        <div class="row mt-3">
            <div class="col-md-12">
                <!-- GridView to display students -->
                <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
