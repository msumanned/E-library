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
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Admin_Login_Click(object sender, EventArgs e)
        {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("select * from admin_login_tbl where admin_Id='" + Admin_Name.Text.Trim() + "' AND password='" + Admin_Pass.Text.Trim() + "'", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Response.Write("<script>alert('Successful login');</script>");
                            Session["Full_name"] = reader.GetValue(0).ToString();
                            Session["admin_Id"] = reader.GetValue(1).ToString();
                            Session["role"] = "Admin";
                            
                        }
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid credentials');</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
           
        }
    }
}