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
    public partial class publishermanagement : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.DataBind();
        }

        protected void Go_Click(object sender, EventArgs e)
        {
            GetPublisherById();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (checkPublisherExist())
            {
                Response.Write("<script>alert('This Publisher exist you are not allowed to add publisher with the same id. Try another author Id'); </script>");
            }
            else
            {
                AddPublisher();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (checkPublisherExist())
            {
                UpdatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher not exist.');</script>");
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (checkPublisherExist())
            {
                DeletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher not exist.');</script>");
            }
        }

        //user defined function

        private bool checkPublisherExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl where publisher_Id='" + Publisher_Id.Text.Trim() + "'; ", con);
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

        //add publisher
        void AddPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_Id, publisher_name) values (@publisher_Id, @publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_Id", Publisher_Id.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", Publisher_Name.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher added successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        //update publisher
        void UpdatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name= @publisher_name where publisher_Id ='" + Publisher_Id.Text.Trim() + "'; ", con);
                cmd.Parameters.AddWithValue("@publisher_name", Publisher_Name.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher updated successfully'); </script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");

            }
        }

        //delete publisher
        void DeletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_Id='"+ Publisher_Id.Text.Trim() +"'; ", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted successfully'); </script>");
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
            Publisher_Id.Text = "";
            Publisher_Name.Text = "";
        }

        //get publisher by Id
        void GetPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_Id='" + Publisher_Id.Text.Trim() + "'; ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    Publisher_Name.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}