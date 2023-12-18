using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_librarymanagment
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals("")) 
                { 
                    LinkButton2.Visible = true; //login
                    LinkButton3.Visible = true; //signup
                    LinkButton4.Visible = false; //logout
                    LinkButton5.Visible = false; //hello user

                    LinkButton6.Visible = true;
                    LinkButton7.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible=false;
                }
                else if (Session["role"].Equals("User"))
                {
                    LinkButton2.Visible = false; //login
                    LinkButton3.Visible = false; //signup
                    LinkButton4.Visible = true; //logout
                    LinkButton5.Visible = true; //hello user
                    LinkButton5.Text = "Hello" + "&nbsp" + Session["First_name"].ToString() + "&nbsp"+ Session["Last_name"].ToString();

                    LinkButton6.Visible = true;
                    LinkButton7.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible = false;
                }
                else if (Session["role"].Equals("Admin"))
                {
                    LinkButton2.Visible = false; //login
                    LinkButton3.Visible = false; //signup
                    LinkButton4.Visible = true; //logout
                    LinkButton5.Visible = true; //hello user
                    LinkButton5.Text = "Hello" + Session["Full_name"].ToString();

                    LinkButton6.Visible = false;
                    LinkButton7.Visible = true;
                    LinkButton8.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;
                    LinkButton11.Visible = true;
                }

            }
            catch
            {

            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }
        
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
        //logout Button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            
            Session["user_name"] = "";
            Session["role"] = "";
            Session["admin_Id"] = "";

            LinkButton2.Visible = true; //login
            LinkButton3.Visible = true; //signup
            LinkButton4.Visible = false; //logout
            LinkButton5.Visible = false; //hello user

            LinkButton6.Visible = true;
            LinkButton7.Visible = false;
            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;
            LinkButton11.Visible = false;
            Response.Redirect("Home.aspx");

        }
        //profile name
        protected void LinkButton5_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("publishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("authormanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookissue.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookinventory.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }


    }

  
    }