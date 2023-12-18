<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookissue.aspx.cs" Inherits="E_librarymanagment.adminbookissue" %>
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
   <div class="container-fluid my-3">
       <div class="row">
           <div class="col-md-5">
               <div class="card">
                   <div class="card-body">
                       <div class="text-center">
                           <div class="row">
                             <div class="col">
                               <img class="publisher" src="images/pic3.jpg" alt="loading..">
                               <h3>Book Issuing</h3>
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
                                <label class="form-label">User name</label>
                                  <asp:TextBox ID="User_name" runat="server" CssClass="form-control"></asp:TextBox>
                           </div>
                           <div class="col-sm-6">
                                <label class="form-label">Book ID</label>
                                 <div class="input-group">
                                  <asp:TextBox ID="Book_Id" runat="server" CssClass="form-control"></asp:TextBox>
                                  <asp:Button CssClass="btn btn-secondary" ID="Go" runat="server" Text="Go" OnClick="Go_Click"  />
                                </div>
                           </div>
                           
                       </div>

                        <div class="row mb-3">
                                                      
                            <div class="col-sm-6">
                                 <label class="form-label">Full name</label>
                                 <asp:TextBox ID="Full_name" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                 <label class="form-label">Book name</label>
                                 <asp:TextBox ID="Book_name" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>


                        </div>

                       <div class="row mb-3">
                                          
                            <div class="col-sm-6">
                                 <label class="form-label">Issue Date</label>
                                 <asp:TextBox ID="Issue_date" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                 <label class="form-label">Received Date</label>
                                 <asp:TextBox ID="Receive_date" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>

                         

                       </div>

                       <div class="row">
                           <div class="col d-grid">
                               <asp:Button CssClass="btn btn-success" ID="Issue" runat="server" Text="Issue" OnClick="Issue_Click" />
                           </div>
                           <div class="col d-grid">
                               <asp:Button CssClass="btn btn-primary" ID="Return" runat="server" Text="Receive" OnClick="Return_Click" />
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
                                   <img src="images/book.png" width="50px" />
                                    <h3>Book Issued List</h3>
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
                                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:e-librarydbConnectionString %>" SelectCommand="SELECT * FROM [bookissue_master_tbl]"></asp:SqlDataSource>
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="user_Id" HeaderText="User name" SortExpression="user_Id" />
                                            <asp:BoundField DataField="user_name" HeaderText="First name" SortExpression="user_name" />
                                            <asp:BoundField DataField="book_id" HeaderText="Book id" SortExpression="book_id" />
                                            <asp:BoundField DataField="book_name" HeaderText="Book name" SortExpression="book_name" />
                                            <asp:BoundField DataField="issue_date" HeaderText="Issue date" SortExpression="issue_date" />
                                            <asp:BoundField DataField="receive_date" HeaderText="Return_date" SortExpression="receive_date" />
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
