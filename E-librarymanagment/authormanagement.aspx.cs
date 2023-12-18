using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_librarymanagment
{
    public partial class authormanagement : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // go button click
        protected void Go_Click(object sender, EventArgs e)
        {
               getAuthorById();
        }

      
        //add button click
        protected void Add_Click(object sender, EventArgs e)
        {
            if (checkAuthorExist())
            {
                Response.Write("<script>alert('This author exist you are not allowed to add author with the same id. Try another author Id'); </script>");
            }
            else
            {
                addAuthor();
            }
        }

        //update button click
        protected void Update_Click(object sender, EventArgs e)
        {
            if (checkAuthorExist())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author doesn't exist.');</script>");
            }
        }

        //delete button click
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (checkAuthorExist())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author doesn't exist.');</script>");
            }
        }

        //user define function
        private bool checkAuthorExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_Id='"+ Author_Id.Text.Trim() +"'; ", con);
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
            catch(Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }

        //add author
        void addAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_Id, author_name) values (@author_Id, @author_name)", con);

                cmd.Parameters.AddWithValue("@author_Id", Author_Id.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", Author_Name.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        //update author
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name= @author_name where author_Id ='"+ Author_Id.Text.Trim() +"'; ", con);
                cmd.Parameters.AddWithValue("@author_name", Author_Name.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author updated successfully'); </script>");
                clearForm();
                GridView1.DataBind();
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            
            }
        }

        //delete author
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                  con.Open();
                }
                 SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_Id='"+ Author_Id.Text.Trim() +"'; ", con);

                 cmd.ExecuteNonQuery();
                 con.Close();
                Response.Write("<script>alert('Author Deleted successfully'); </script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");

            }
        }

        void clearForm()
        {
            Author_Id.Text = "";
            Author_Name.Text = "";
        }

        //get author by Id
        void getAuthorById()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_Id='" + Author_Id.Text.Trim() + "'; ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    Author_Name.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

    }
}