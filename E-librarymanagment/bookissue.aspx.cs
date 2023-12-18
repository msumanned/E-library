using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_librarymanagment
{
    public partial class adminbookissue : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void Go_Click(object sender, EventArgs e)
        {
            GetName();
        }
        protected void Issue_Click(object sender, EventArgs e)
        {
            if (CheckIfUserExists() && CheckIfBookExists())
            {
               if (CheckIfIssueEntryExist())
                {
                    Response.Write("<script>alert('This User already taken this book');</script>");
                }
                else
                {
                    issueBook();
                }
            }
            else
            {
                Response.Write("<script>alert('');</script>");
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            if (CheckIfUserExists() && CheckIfBookExists())
            {
                if (CheckIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                Response.Write("<script>alert('NO entry');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('');</script>");
            }
        }

        //user define function

        bool CheckIfUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE user_name='" + User_name.Text.Trim() + "'", con);
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

        bool CheckIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + Book_Id.Text.Trim() + "' AND current_stock >0 ", con);
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

        //check if issue entry exist
        bool CheckIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM bookissue_master_tbl WHERE user_Id='" + User_name.Text.Trim() + "' AND  book_id='"+ Book_Id.Text.Trim() +"' ", con);
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
                return false;

            }
        }

        //go button get names
        void GetName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT First_name, Last_name FROM member_master_tbl WHERE user_name='" + User_name.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    Full_name.Text = dt.Rows[0]["First_name"].ToString();
                   // Full_name.Text = dt.Rows[0]["Last_name"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Wrong user name');</script>");
                }

                cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id='" + Book_Id.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    Book_name.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong User ID');</script>");
                }
               

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");

            }
        }

        
       

        //issue book
        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO bookissue_master_tbl(user_Id, user_name, book_id, book_name, issue_date, receive_date)" +
                    " VALUES (@user_Id, @user_name, @book_id, @book_name, @issue_date, @receive_date) ", con);
                cmd.Parameters.AddWithValue("@user_Id", User_name.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", Full_name.Text.Trim());
                cmd.Parameters.AddWithValue("@book_Id", Book_Id.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", Book_name.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", Issue_date.Text.Trim());
                cmd.Parameters.AddWithValue("@receive_date", Receive_date.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update book_master_tbl set current_stock = current_stock-1 WHERE book_id='" + Book_Id.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Issued successfully');</script>");
                clearForm();
                GridView1.DataBind();
                

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        //return Book
        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM bookissue_master_tbl WHERE user_id='"+ User_name.Text.Trim() +"' AND book_id='"+ Book_Id.Text.Trim() +"'  ", con);
                
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    cmd = new SqlCommand("update book_master_tbl set current_stock = current_stock+1 " +
                        "Where book_id='"+Book_Id.Text.Trim() +"' ", con);
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Return successfully');</script>");
                    GridView1.DataBind();
                    con.Close();

                }
               
                else 
                {
                    Response.Write("<script>alert('Invalid details');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        //clear form
        void clearForm()
        {
            User_name.Text = "";
            Book_Id.Text = "";
            Full_name.Text = "";
            Book_name.Text = "";
            Issue_date.Text = "";
            Receive_date.Text = "";
        }
    }
}