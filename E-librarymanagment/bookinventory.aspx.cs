using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_librarymanagment
{
    public partial class bookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actualstock, global_currentstock, global_issuedbook;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  fillByAuthorAndPublisher();

            }
            GridView1.DataBind();
           
        }

        protected void Go_Click(object sender, EventArgs e)
        {
                getBookById();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            addBook();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            deleteBook();
        }

        //user define function

        //check if book id exist

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + Book_id.Text.Trim() + "' OR book_name='" + Book_name.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        //get book by Id
        void getBookById()
        {

              try
              {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_Id='"+Book_id.Text.Trim() +"' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1 )
                {
                    Book_name.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    Edition.Text = dt.Rows[0]["edition"].ToString();
                    Pages.Text = dt.Rows[0]["pages"].ToString();
                    Stock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    C_Stock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    I_Stock.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim()) );
                    BookDetail.Text = dt.Rows[0]["book_description"].ToString();

                        global_actualstock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                        global_currentstock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                        global_issuedbook = global_actualstock - global_currentstock;
                        global_filepath = dt.Rows[0]["book_img"].ToString();
                    }
                }
              catch(Exception ex)
              {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
              }


        }

        //authorname and publisher name
        void fillByAuthorAndPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "author_name";
                DropDownList1.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //add book
        void addBook()
        {
            try
            {
                string filepath = "~/bookinvertory/";
                string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                FileUpload.SaveAs(Server.MapPath("bookinventory/" + filename));
                filepath = "~/bookinventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id, book_name, author_name, publisher_name, edition, pages, actual_stock, current_stock, book_img, book_description) " +
                    "values(@book_id, @book_name, @author_name, @publisher_name, @edition, @pages, @actual_stock, @current_stock, @book_img, @book_description) ", con);

                cmd.Parameters.AddWithValue("@book_id", Book_id.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", Book_name.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", DropDownList1.SelectedItem.Value); 
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", Edition.Text.Trim());
                cmd.Parameters.AddWithValue("@pages", Pages.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", Stock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", Stock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img", filepath);
                cmd.Parameters.AddWithValue("@book_description", BookDetail.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully') </script>");
                clearForm();
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        //update book info
        /*
        void UpdateBook()
        {

            if (checkIfBookExists())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(Stock.Text.Trim());
                    int current_stock = Convert.ToInt32(C_Stock.Text.Trim());

                    if (global_actualstock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issuedbook)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issuedbook;
                            C_Stock.Text = "" + current_stock;
                        }
                    }

                    string filepath = "~/book_inventory/books1";
                    string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, author_name=@author_name, publisher_name=@publisher_name, edition=@edition, pages=@pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock WHERE book_id='" + Book_id.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", Book_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", Edition.Text.Trim());
                    cmd.Parameters.AddWithValue("@pages", Pages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", BookDetail.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", Stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", C_Stock.ToString());
                 //   cmd.Parameters.AddWithValue("@book_img", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }*/

        //delete book
        void deleteBook()
        {
          if (checkIfBookExists())
          {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='"+ Book_id.Text.Trim() +"'  ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
          }
            else
            {
                Response.Write("<script>alert('Invalid Book Id');</script>");
            }

        }

        //claear form
        void clearForm()
        {
            Book_id.Text = "";
            Book_name.Text = "";
            Edition.Text = "";
            Pages.Text = "";
            Stock.Text = "";
            C_Stock.Text = "";
            BookDetail.Text = "";
        }

    }
}