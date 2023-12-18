<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="E_librarymanagment.userlogin" %>
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
                                   <img src="images/user.png" alt="loading.." width="120px">
                                   <h3>User Login</h3>
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
                                   <div class="mb-3">
                                           <label class="form-label">User name</label>
                                           <asp:TextBox ID="LoginUser_Id" runat="server" CssClass="form-control" placeholder="User name"></asp:TextBox>
                                   </div>
                                   <div class="mb-3">
                                           <label class="form-label">Password</label>
                                           <asp:TextBox ID="Login_Pass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                   </div>
                                   <div class="col-6 d-grid mx-auto gap-2">
                                       <asp:Button CssClass="btn btn-login btn-lg" ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
                               
                                       <a href="usersignup.aspx" class="d-grid" style="text-decoration:none;"><input class="btn btn-signup btn-lg" id="Button2" type="button" value="Sign Up"/></a> 
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
