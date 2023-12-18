﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="authormanagement.aspx.cs" Inherits="E_librarymanagment.authormanagement" %>
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
   <div class="container my-5">
       <div class="row">
           <div class="col-md-5">
               <div class="card">
                   <div class="card-body">
                       <div class="text-center">
                           <div class="row">
                             <div class="col">
                               <img class="publisher" src="images/gallery6.jpg" alt="loading..">
                               <h3>Author Details</h3>
                             </div>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                               <hr>
                           </div>
                       </div>
                         
                       <div class="row mb-3">
                           <div class="col-sm-5">
                                <label class="form-label">Author Id</label>
                                 <div class="input-group">
                                  <asp:TextBox ID="Author_Id" runat="server" CssClass="form-control"></asp:TextBox>
                                  <asp:Button CssClass="btn btn-primary" ID="Go" runat="server" Text="Go" OnClick="Go_Click" />
                                </div>
                           </div>
                           <div class="col-sm-7">
                                <label class="form-label">Author name</label>
                                <asp:TextBox ID="Author_Name" runat="server" CssClass="form-control" placeholder="Smith"></asp:TextBox>
                           </div>
                       </div>

                       <div class="row">
                           <div class="col-4 d-grid">
                               <asp:Button CssClass="btn btn-success" ID="Add" runat="server" Text="Add" OnClick="Add_Click" />
                           </div>
                           <div class="col-4 d-grid">
                               <asp:Button CssClass="btn btn-primary" ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
                           </div>
                           <div class="col-4 d-grid">
                               <asp:Button CssClass="btn btn-danger" ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" />
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
                                 
                                    <h3>Author List</h3>
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
                                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:e-librarydbConnectionString %>" ProviderName="<%$ ConnectionStrings:e-librarydbConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_Id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="author_Id" HeaderText="Author Id" ReadOnly="True" SortExpression="author_Id" />
                                            <asp:BoundField DataField="author_name" HeaderText="Author Name" SortExpression="author_name" />
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
