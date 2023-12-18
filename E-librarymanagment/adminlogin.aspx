<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="E_librarymanagment.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
    <div class="container my-5">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="text-center">
                            <div class="row">
                              <div class="col">
                                <img src="images/admin.png" alt="loading.." width="120px">
                                <h3>Admin Login</h3>
                              </div>
                            </div>
                         </div>
                          

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class=" mb-3">
                                        <label class="form-label">User name</label>
                                        <asp:TextBox ID="Admin_Name" runat="server" CssClass="form-control" placeholder="user name"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                        <label class="form-label">Password</label>
                                        <asp:TextBox ID="Admin_Pass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-6 d-grid mx-auto my-3">
                                    <asp:Button CssClass="btn btn-login btn-lg" ID="Admin_Login" runat="server" Text="Login" OnClick="Admin_Login_Click" />
                                </div>
                                
                            </div>
                        </div>

                    </div>
                </div>
                
                <a href="Home.aspx"> >>Back to home</a>
            </div>
        </div>
    </div>
</section>
</asp:Content>
