<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="E_librarymanagment.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
           <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js"></script>
 
    <script>

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <section>
   <div class="container my-3">
       <div class="row">
           <div class="col-md-5">
               <div class="card">
                   <div class="card-body">
                       <div class="text-center">
                           <div class="row">
                             <div class="col">
                               <img class="publisher" src="images/staff1.jpg" alt="loading..">
                               <h3>Member Detail</h3>
                             </div>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                               <hr>
                           </div>
                       </div>
                         
                       <div class="row mb-3">

                           <div class="col-md-4">
                                <label class="form-label">User name</label>
                                <div class="input-group">
                                  <asp:TextBox ID="User_Id" runat="server" CssClass="form-control"></asp:TextBox>
                                  <asp:Button CssClass="btn btn-primary" ID="Go" runat="server" Text="Go" OnClick="Go_Click" />
                                </div>
                           </div>
                        
                          <div class="col-md-8">
                                <label class="form-label">Account Status</label>
                              <div class="btn-group" >
                                  <asp:TextBox ID="Account_Status" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                                 <div class="d-sm-inline-flex">
                                     <asp:LinkButton CssClass="btn btn-primary mx-1" ID="Active" runat="server" OnClick="Active_Click"><i class="fa-solid fa-circle-check" style="color: #ffffff;"></i></asp:LinkButton>
                                     <asp:LinkButton CssClass="btn btn-warning " ID="Pending" runat="server" OnClick="Pending_Click"><i class="fa-regular fa-circle-pause" style="color: #ffffff;"></i></asp:LinkButton>
                                     <asp:LinkButton CssClass="btn btn-danger mx-1" ID="Deactive" runat="server" OnClick="Deactive_Click"><i class="fa-solid fa-trash"></i></asp:LinkButton>
                                </div>

                              </div>

                           </div>
                           
                       </div>

                      <div class="row mb-3">
                                          
                            <div class="col-md-6">
                                 <label class="form-label">First name</label>
                                 <asp:TextBox ID="F_name" runat="server" CssClass="form-control" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <label class="form-label">Last name</label>
                                 <asp:TextBox ID="L_name" runat="server" CssClass="form-control" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                            </div>


                       </div>
                    
                       <div class="row mb-3">
                                          
                            <div class="col-md-6">
                                 <label class="form-label">Date of birth</label>
                                 <asp:TextBox ID="Dob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <label class="form-label">Gender</label>
                                 <asp:TextBox ID="Gender" runat="server" CssClass="form-control" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                            </div>


                       </div>

                      <div class="row mb-3">
                           <div class="col-md-6">
                                 <label class="form-label">Contact No</label>
                                 <asp:TextBox ID="Contact_Num" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <label class="form-label">City</label>
                                 <asp:TextBox ID="City" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>

                       </div>

                       <div class="row mb-3">
                            <div class="col-md-6">
                                 <label class="form-label">Pin code</label>
                                 <asp:TextBox ID="Pin_Code" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                           <div class="col-md-6">
                                 <label class="form-label">Email</label>
                                 <asp:TextBox ID="Email_Id" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>

                       </div>

                        <div class="row mb-3">
                            <div class="col">
                                 <label class="form-label">Address</label>
                                 <asp:TextBox ID="Address" runat="server" CssClass="form-control" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </div>

                       </div>


                       <div class="row">
                           <div class="col-6 mx-auto d-grid">                     
                                   <asp:Button CssClass="btn btn-danger" ID="Delete" runat="server" Text="Delete User Permanently" OnClick="Delete_Click" /> 
                           </div>
                         
                       </div>


               
                   </div>
             </div>
               
               <a href="Home.aspx"> >>Back to home</a>
           </div>

           <div class="col-md-7">
               <div>
                   <div class="card">
                       <div class="card-body text-center">
                           <div class="row">
                               <div class="col">                              
                              
                                    <h3>Memmber List</h3>
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
                                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:e-librarydbConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="user_name" DataSourceID="SqlDataSource1" >
                                        <Columns>
                                            <asp:BoundField DataField="user_name" HeaderText="User name" ReadOnly="True" SortExpression="user_name" />
                                            <asp:BoundField DataField="account_status" HeaderText="Account status" SortExpression="account_status" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                            <asp:BoundField DataField="Contact_No" HeaderText="Contact no" SortExpression="Contact_No" />
                                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                        </Columns>
                                   </asp:GridView>
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
