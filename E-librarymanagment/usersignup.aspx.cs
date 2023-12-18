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
    public partial class usersignup : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //when sign up button click
        protected void Sign_Up_Click(object sender, EventArgs e)
        {
            if (CheckUserExist())
            {
                Response.Write("<script>alert('User exist.Try another unique User name');</script>");
            }
            else
            {
                signupNewUser();
            }
            
        }

        // user defined function

        private bool CheckUserExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * " +
                    "FROM member_master_tbl WHERE user_name='" + User_Name.Text.Trim()+ "'; ", con);
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

        void signupNewUser()
        {
            //Response.Write("<script>alert('Try another User Id')</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl (First_name,Last_name,Date_of_birth,Gender,Contact_No,City,Pin_code,Email,Address,user_name,Password,account_status) values (@First_name,@Last_name,@Date_of_birth,@Gender,@Contact_No,@City,@Pin_code,@Email,@Address,@user_name,@Password,@account_status)", con);


                cmd.Parameters.AddWithValue("@First_name", F_Name.Text.Trim());
                cmd.Parameters.AddWithValue("@Last_name", L_Name.Text.Trim());
                cmd.Parameters.AddWithValue("@Date_of_birth", Dob.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Value.Trim());
                cmd.Parameters.AddWithValue("@Contact_No", Contact_No.Text.Trim());
                cmd.Parameters.AddWithValue("@City", City.SelectedItem.Value.Trim());
                cmd.Parameters.AddWithValue("@Pin_code", Pin.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", Email.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", Address.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", User_Name.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", Pass.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status","pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('SignUp Successful. Go to User Login');</script>");
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        
    }
}