using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Xml.Linq;

namespace E_librarymanagment
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Go_Click(object sender, EventArgs e)
        {
            getUserById();
        }
        protected void Active_Click(object sender, EventArgs e)
        {
            updateAccountStatus("Active");
        }

        protected void Pending_Click(object sender, EventArgs e)
        {
            updateAccountStatus("Pending");
        }

        protected void Deactive_Click(object sender, EventArgs e)
        {
           updateAccountStatus("Deactive");
        }

        //delere parmanentely
        protected void Delete_Click(object sender, EventArgs e)
        {
            deleteUser();
        }

        //user define function
        bool CheckUserExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE user_name='" + User_Id.Text.Trim() +"'; ", con);
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

        //get user by id
        void getUserById()
        {
            if (CheckUserExist())
            {
              try
              {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE user_name='"+ User_Id.Text.Trim() +"'; ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User_Id.Text = reader.GetValue(9).ToString();
                        Account_Status.Text = reader.GetValue(11).ToString();
                        F_name.Text = reader.GetValue(0).ToString();
                        L_name.Text = reader.GetValue(1).ToString();
                        Dob.Text = reader.GetValue(2).ToString();
                        Gender.Text = reader.GetValue(3).ToString();
                        Contact_Num.Text = reader.GetValue(4).ToString();
                        City.Text = reader.GetValue(5).ToString();
                        Pin_Code.Text = reader.GetValue(6).ToString();
                        Email_Id.Text = reader.GetValue(7).ToString();
                        Address.Text = reader.GetValue(8).ToString();

                    }
                }
                else
                {
                    Response.Write("<script>alert('Member doesn't exist');</script>");
                }

              }
              catch (Exception ex)
              {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
              }
            }
            else
            {
                Response.Write("<script>alert('Invalid user name');</script>");
            }

        }
        
        //account status update
        void updateAccountStatus(string status)
        {
            if (CheckUserExist())
            {

              try
              {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='"+ status + "' WHERE user_name='" + User_Id.Text.Trim() + "'; ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();

                Response.Write("<script>alert('User status update');</script>");
                
              }
              catch(Exception ex)
              {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
              }
            }
            else
            {
                Response.Write("<script>alert('Invalid user name');</script>");

            }
        }
        
        //deleter user parmanentlly
        void deleteUser()
        {
            if (CheckUserExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE user_name='" + User_Id.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('User Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch(Exception ex)
                {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid user name');</script>");

            }
        }

        //celar form field
        void clearForm()
        {
            User_Id.Text = "";
            Account_Status.Text = "";
            F_name.Text = "";
            L_name.Text = "";
            Dob.Text = "";
            Gender.Text = "";
            Contact_Num.Text = "";
            City.Text = "";
            Pin_Code.Text = "";
            Email_Id.Text = "";
            Address.Text = "";
        }

    }
}