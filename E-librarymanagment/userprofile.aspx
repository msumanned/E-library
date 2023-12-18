<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="E_librarymanagment.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
   <div class="container my-5">
       <div class="row">
           <div class="col-md-6">
               <div class="card">
                   <div class="card-body">
                       <div class="text-center">
                           <div class="row">
                             <div class="col">
                               <img src="images/user.png" alt="loading.." width="120px">
                               <h3>Your Profile</h3>
                                 <span>Account Status</span>
                                 <asp:Label CssClass="badge rounded-pill text-bg-success" ID="Label1" runat="server" Text="your status"></asp:Label>

                             </div>
                           </div>
                        </div>
                         

                       <div class="row">
                           <div class="col">
                               <hr>
                           </div>
                       </div>

                       <div class="row">
                           <div class="col-sm-6">
                                <label class="form-label">First name</label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Jhon"></asp:TextBox>
                           </div>
                           <div class="col-sm-6">
                                <label class="form-label">Last name</label>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Smith"></asp:TextBox>
                           </div>
                       </div>

                        <div class="row">
                           <div class="col-sm-4">
                                <label class="form-label">Date of Birth</label>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Jhon" TextMode="Date"></asp:TextBox>
                           </div>
                           <div class="col-sm-4">
                                <label class="form-label">Gender</label>
                               <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                   <asp:ListItem Text="Select" Value="select" />
                                   <asp:ListItem Text="Male" Value="Male" />
                                   <asp:ListItem Text="Female" Value="Female" />
                               </asp:DropDownList>
                                
                           </div>
                           <div class="col-sm-4">
                                <label class="form-label">Phone Number</label>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="002398745615" TextMode="Phone"></asp:TextBox>
                                
                           </div>
                       </div>
                        <div class="row">
                           <div class="col-sm-4">
                                <label class="form-label">City</label>
                               <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
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
                                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="Number">
                                </asp:TextBox>
                                
                           </div>
                           <div class="col-sm-4">
                                <label class="form-label">Emial</label>
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" placeholder="Jhon@gmail.com" TextMode="Email"></asp:TextBox>
                                
                           </div>
                       </div>
                       <div class="row">
                           <div class="col">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                           </div>
                          
                       </div>

                       <div class="row">
                           <div class="col">
                               <div class="my-4 login-credential">
                                  <span>Change Password</span>

                               </div>
                                   
                               
                               
                               <div class="row">
                                   <div class="col-sm-4">
                                       <label class="form-label">User ID</label>
                                       <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" placeholder="User Id"></asp:TextBox>

                                   </div>
                                   <div class="col-sm-4">
                                       <label class="form-label">Old Password</label>
                                       <asp:TextBox ID="TextBox20" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                                   </div>
                                   <div class="col-sm-4">
                                       <label class="form-label">New Password</label>
                                       <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                                   </div>
               

                               </div>
                               <div class="my-3 d-grid justify-content-center ">
                                   <asp:Button CssClass="btn btn-login btn-lg" ID="Button1" runat="server" Text="Update" />
                               </div>
                         </div>
                     </div>
               
                   </div>
             </div>
               
               <a href="Home.aspx"> >>Back to home</a>
           </div>

           <div class="col-md-6">
               <div>
                   <div class="card">
                       <div class="card-body text-center">
                           <div class="row">
                               <div class="col">                              
                                   <img src="images/book.png" width="50px" />
                                    <h3>Your Issued Books</h3>
                                   <asp:Label CssClass="badge rounded-pill text-bg-info" ID="Label2" runat="server" Text="Info about book due date"></asp:Label>

                               </div>

                          </div>
                           <div class="row">
                               <div class="col">
                                   <hr />
                               </div>
                           </div>

                          <div class="row">
                            <div class="col">
                               <div>
                                 <asp:GridView class="table table-striped" ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
                               </div>
                            </div>
                          </div>
                       </div>
                   </div>
               </div>


           </div>
       </div>
   </div>
</section>
</asp:Content>
