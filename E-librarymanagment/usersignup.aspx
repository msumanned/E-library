<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="E_librarymanagment.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <section>
    <div class="container my-5">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="text-center">
                            <div class="row">
                              <div class="col">
                                <img src="images/user.png" alt="loading.." width="120px">
                                <h3>User Registration</h3>
                              </div>
                            </div>
                         </div>
                          

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-sm-6">
                                 <label class="form-label">First name</label>
                                 <asp:TextBox ID="F_Name" runat="server" CssClass="form-control" placeholder="Jhon"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                 <label class="form-label">Last name</label>
                                 <asp:TextBox ID="L_Name" runat="server" CssClass="form-control" placeholder="Smith"></asp:TextBox>
                            </div>
                        </div>

                         <div class="row mb-3">
                            <div class="col-sm-4">
                                 <label class="form-label">Date of Birth</label>
                                 <asp:TextBox ID="Dob" runat="server" CssClass="form-control" placeholder="Jhon" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                 <label class="form-label">Gender</label>
                                <asp:DropDownList CssClass="form-control" ID="Gender" runat="server">
                                    <asp:ListItem Text="Select" Value="select" />
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                </asp:DropDownList>
                                 
                            </div>
                            <div class="col-sm-4">
                                 <label class="form-label">Contact No</label>
                                 <asp:TextBox ID="Contact_No" runat="server" CssClass="form-control" placeholder="002398745615" TextMode="Phone"></asp:TextBox>
                                 
                            </div>
                        </div>
                         <div class="row mb-3">
                            <div class="col-sm-4">
                                 <label class="form-label">City</label>
                                <asp:DropDownList CssClass="form-control" ID="City" runat="server">
                                    <asp:ListItem Text="Select" Value="Select" />
                                    <asp:ListItem Text="Karachi" Value="Karachi" />
                                    <asp:ListItem Text="Lahore" Value="Lahore" />
                                    <asp:ListItem Text="Islamabad" Value="Islamabad" />
                                    <asp:ListItem Text="Faislabad" Value="Faislabad" />
                                    <asp:ListItem Text="Rawalpindi" Value="Rawalpindi" />
                                    <asp:ListItem Text="Multan" Value="Multan" />
                                    <asp:ListItem Text="Hyderabad" Value="Hyderabad" />
                                    <asp:ListItem Text="Quetta" Value="Quetta" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                 <label class="form-label">Pin Code</label>
                                 <asp:TextBox ID="Pin" runat="server" CssClass="form-control" TextMode="Number">
                                 </asp:TextBox>
                                 
                            </div>
                            <div class="col-sm-4">
                                 <label class="form-label">Emial</label>
                                 <asp:TextBox ID="Email" runat="server" CssClass="form-control" placeholder="Jhon@gmail.com" TextMode="Email"></asp:TextBox>
                                 
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col">
                                 <label class="form-label">Address</label>
                                 <asp:TextBox ID="Address" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                           
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="my-2 login-credential">
                                   <span>Login Credentialas</span>

                                </div>
                                    
                                
                                
                                <div class="row mb-3">
                                    <div class="col-sm-6">
                                        <label class="form-label">User name</label>
                                        <asp:TextBox ID="User_Name" runat="server" CssClass="form-control" placeholder="User name"></asp:TextBox>

                                    </div>
                                    <div class="col-sm-6">
                                        <label class="form-label">Password</label>
                                        <asp:TextBox ID="Pass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                                    </div>
                

                                </div>
                                <div class="col-6 d-grid mx-auto">
                                    <asp:Button CssClass="btn btn-login btn-lg" ID="Sign_Up" runat="server" Text="Sign Up" OnClick="Sign_Up_Click" />
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
