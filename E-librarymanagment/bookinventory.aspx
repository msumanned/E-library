<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookinventory.aspx.cs" Inherits="E_librarymanagment.bookinventory" %>
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
                               <img src="images/book.png" alt="loading.." />
                               <h3>Book Details</h3>
                             </div>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                               <hr>
                           </div>
                       </div>

                       <div class="row mb-3">
                           <div class="col">
                               <label class="form-label">Book Image</label>
                               <asp:FileUpload CssClass="form-control" ID="FileUpload" runat="server" />
                           </div>
                       </div>
                         
                       <div class="row mb-3">
                           <div class="col-md-4">
                                <label class="form-label">Book ID</label>
                                <div class="input-group">
                                  <asp:TextBox ID="Book_id" runat="server" CssClass="form-control"></asp:TextBox>
                                  <asp:Button CssClass="btn btn-primary" ID="Go" runat="server" Text="Go" OnClick="Go_Click" />
                                </div>
                           </div>
                           <div class="col-md-8">
                                <label class="form-label">Book name</label>
                                  <asp:TextBox ID="Book_name" runat="server" CssClass="form-control" ></asp:TextBox>
                           </div>
                           
                       </div>

                    
                       <div class="row mb-3">
                                          
                            <div class="col-md-6">
                                 <label class="form-label">Author name</label>
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                     <asp:ListItem Text="Author 1" Value="Author 1" />
                                     <asp:ListItem Text="Author 2" Value="Author 2" />
                                </asp:DropDownList>

                            </div>
                            <div class="col-md-6">
                                 <label class="form-label">Publisher name</label>
                                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                                     <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                     <asp:ListItem Text="Publisher 2" Value="Publisher 2" />

                                </asp:DropDownList>
                            </div>


                       </div>

                      <div class="row mb-3">
                           <div class="col-md-6">
                                 <label class="form-label">Edition</label>
                                 <asp:TextBox ID="Edition" runat="server" CssClass="form-control" TextMode="SingleLine" ></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <label class="form-label">Pages</label>
                                 <asp:TextBox ID="Pages" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                       </div>

                       <div class="row mb-3">
                           <div class="col-md-4">
                                 <label class="form-label">Actual Stock</label>
                                 <asp:TextBox ID="Stock" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                 <label class="form-label">Current Stock</label>
                                 <asp:TextBox ID="C_Stock" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                 <label class="form-label">Issued Stock</label>
                                 <asp:TextBox ID="I_Stock" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="True"></asp:TextBox>
                            </div>

                       </div>
                       <div class="row mb-3">
                           <div class="col">
                                <label class="form-label">Book Description</label>
                                 <asp:TextBox ID="BookDetail" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
         
                   <div class="card">
                       <div class="card-body text-center">
                           <div class="row">
                               <div class="col">                                                            
                                    <h3>Book Lists</h3>
                               </div>

                          </div>
                           <div class="row">
                               <div class="col">
                                   <hr />
                               </div>
                           </div>

                          <div class="row">                                   
                              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:e-librarydbConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>

                            <div class="col">
                               
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" Width="100%" >
                                        <Columns>
                                            <asp:BoundField DataField="book_id" HeaderText="Book Id" ReadOnly="True" SortExpression="book_id" />

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="container-fluid">
                                                        <div class="row" style="text-align:left">
                                                            <div class="col-sm-10">
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                       <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        Author-
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                        &nbsp; |&nbsp; Publiser-
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-12">Edition-
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("edition") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                        &nbsp; |&nbsp; Pages-&nbsp;
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("pages") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-12">Actual Stock-
                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("actual_stock") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                        &nbsp; |&nbsp; Avalaible&nbsp; Stock-&nbsp;
                                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("current_stock") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col--12">Description-
                                                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("book_description") %>' Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="col-sm-2">
                                                                <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img") %>' />
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
