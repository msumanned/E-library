<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="E_librarymanagment.WebForm3" %>
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
                <div class="col-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                           <div class="text-center">
                             <div class="row">
                               <div class="col">
                                 <img src="images/book.png" alt="loading.." />
                                  <h3>Book Details</h3>
                               </div>
                             </div>
                           </div>

                           <div class="row">
                               <div class="col-12">
                                   <asp:SqlDataSource ID="SqlDataSouce1" runat="server" ConnectionString="<%$ ConnectionStrings:e-librarydbConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                   <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSouce1" width="100%">
                                       <Columns>
                                           <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />

                                           <asp:TemplateField>
                                               <ItemTemplate>
                                                   <div class="container-fluid">
                                                       <div class="row">
                                                           <div class="col-10">
                                                               <div class="row">
                                                                   <div class="col-12">
                                                                       <asp:Label ID="label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Larger"></asp:Label>
                                                                   </div>
                                                               </div>

                                                              <div class="row">
                                                                   <div class="col-12">
                                                                       Author name-
                                                                       <asp:Label ID="label3" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                       &nbsp; |&nbsp; Publisher name:
                                                                       <asp:Label ID="label4" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="True" Font-Size="Small"></asp:Label> 

                                                                   </div>
                                                               </div>

                                                              <div class="row">
                                                                   <div class="col-12">
                                                                       Edition-
                                                                       <asp:Label ID="label5" runat="server" Text='<%# Eval("edition") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                       &nbsp; |&nbsp; Pages-
                                                                       <asp:Label ID="label6" runat="server" Text='<%# Eval("pages") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                   </div>
                                                               </div>

                                                               <div class="row">
                                                                   <div class="col-12">
                                                                       Actual Stock-
                                                                       <asp:Label ID="labe7" runat="server" Text='<%# Eval("actual_stock") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                       &nbsp; |&nbsp; Current Stock-
                                                                       <asp:Label ID="label8" runat="server" Text='<%# Eval("current_stock") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                   </div>
                                                               </div>

                                                               <div class="row">
                                                                   <div class="col-12">
                                                                       Book description-
                                                                       <asp:Label ID="label9" runat="server" Text='<%# Eval("book_description") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                   </div>
                                                               </div>

                                                           </div>

                                                           <div class="col-2">
                                                               <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("book_img") %>' />

                                                           </div>
                                                       </div>
                                                   </div>

                                               </ItemTemplate>
                                           </asp:TemplateField>

                                       </Columns>
                                      

                                      
                                   </asp:GridView>
                               </div>
                           </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
