<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="CourseWorkSoftwarePolishchukOlha.StudentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<title>Student Login</title

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="text-center">Student Login</h2>
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                        <div class="form-group">
                            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
