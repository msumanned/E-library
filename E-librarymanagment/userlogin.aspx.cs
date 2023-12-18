using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_librarymanagment
{
    public partial class userlogin : System.Web.UI.Page
    {
        
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con= new SqlConnection (strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl " +
                    "WHERE user_name ='" + LoginUser_Id.Text.Trim() + "' AND Password= '"+ Login_Pass.Text.Trim() +"' ; ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Response.Write("<script>alert('"+reader.GetValue(9).ToString()  +"'); </script>");
                        Session["user_name"] = reader.GetValue(9).ToString();
                        Session["First_name"] = reader.GetValue(0).ToString();
                        Session["Last_name"] = reader.GetValue(1).ToString();
                        Session["role"] = "User";
                        //Session["Status"] = reader.GetValue(11).ToString();
                    }
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid login credentials'); </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"'); </script>");
            }
        }

       

        //user define function


    }
}