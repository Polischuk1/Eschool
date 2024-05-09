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
                        <asp:TableHeaderCell>Attendance</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-12">
                <asp:Button ID="btnAddStudent" runat="server" Text="Add a Student" CssClass="btn btn-success" OnClick="btnAddStudent_Click" />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>
