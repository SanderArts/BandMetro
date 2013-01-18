using System;
using System.Data.SqlClient;
using Band;

namespace Band
{
    
    public partial class _login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UserName.Focus();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                SqlConnection conn = new SqlConnection {ConnectionString = General.connstr};
                SqlCommand comm = new SqlCommand { Connection = conn };
                comm.Connection.Open();
                var query = string.Format("SELECT id, fullname, username, password, admin, email FROM [users] WHERE username='{0}' ", UserName.Text);
                comm.CommandText = query;
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    var uid = reader.GetInt32(0);
                    var fullname = reader.GetString(1).Trim();
                    var user = reader.GetString(2).Trim();
                    var pw = reader.GetString(3).Trim();
                    var isadmin = reader.GetBoolean(4);
                    var useremail = reader.GetString(5).Trim();

                    if (user == UserName.Text.Trim() & pw == Password.Text.Trim())
                    {
                        Session["fullname"] = fullname;     //Fullname
                        Session["uid"] = uid;               //INT
                        Session["admin"] = isadmin;         //Bool: true/false
                        //Session["email"] = useremail;       //E-mailaddress user
                    }
                }
                conn.Close();
                if (Session["fullname"] == null)
                {
                    PanelError.Visible = true;
                }
                else
                {
                    if (Request["page"] != null)
                    {
                        if (Request["page"] != "")
                        {
                            var topage = Request["page"];
                            Response.Redirect(topage + ".aspx", false);
                        }
                    } else
                    {
                        Response.Redirect("default.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "An error occurred logging in.", ex.Message ), true);
            }
        }
    }
}
