using System;
using System.Data.SqlClient;

namespace Band
{
    public partial class _settings : System.Web.UI.Page
    {

        protected void Page_Preload(object sender, EventArgs e)
        {
            // TESTING
            //Session["fullname"] = "Sander Arts";
            //Session["uid"] = 1;
            // TESTING

            General.checkloggedin(Response, Session, "settings");

            PanelMessage.Visible = false;
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    SqlConnection conn = new SqlConnection
                    {
                        ConnectionString = General.connstr
                    };
                    SqlCommand comm = new SqlCommand { Connection = conn };
                    comm.Connection.Open();
                    var query = string.Format("select id, username, fullname, password, email, notifications from users where id='{0}'", Session["uid"]);

                    comm.CommandText = query;
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var username = reader.GetString(1).Trim();
                        var fullname = reader.GetString(2).Trim();
                        //var pw = reader.GetString(3).Trim();
                        var email = "";
                        if (!reader.IsDBNull(4)) email = reader.GetString(4).Trim();

                        var notifications = 0;
                        var bnotif = false;
                        if (!reader.IsDBNull(5)) notifications = reader.GetInt16(5);
                        if (notifications == 1) bnotif = true; 

                        TextBoxUserID.Text = id.ToString();
                        TextBoxUsername.Text = username;
                        TextBoxFullname.Text = fullname;
                        TextBoxMailAddress.Text = email;
                        CheckBoxReceiveMails.Checked = bnotif;

                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "An error occurred getting your settings (ID: " +
                                    Session["uid"] + ").", ex.Message ), true);
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var uid = TextBoxUserID.Text;
                //var user = TextBoxUsername.Text;
                //var fullname = TextBoxFullname.Text;
                var emailaddress = TextBoxMailAddress.Text;
                var pw1 = TextBoxPassword.Text;
                var pw2 = TextBoxPassword2.Text;
                var not = 0;
                if ( CheckBoxReceiveMails.Checked) not = 1;


                //Error checking
                LabelError.Visible = false;
                var msg = "";
                if ((emailaddress == "") & (pw1 == "" & pw2 == "")) msg = "E-mailaddress and passwords cannot be empty.";
                if (pw1 != "" )
                {
                    if (pw1 != pw2) msg = "Passwords do not match.";
                    if (msg == "" & pw1.Length < 6) msg = "Password is too short (min. 6 chrs).";
                }

                if (msg != "")
                {
                    LabelError.Text = msg;
                    LabelError.Visible = true;
                } else
                {
                    var sqlquery = "";
                    if (emailaddress != "")
                    {
                        sqlquery = string.Format("update users set email = '{0}', notifications = {2} where id='{1}'", emailaddress, uid, not);
                    }
                    if (pw1 != "")
                    {
                        sqlquery = string.Format("update users set password = '{0}', notifications = {2}  where id='{1}'", pw1, uid, not );
                    }
                    if (emailaddress != "" & pw1 != "")
                    {
                        sqlquery = string.Format("update users set email = '{0}', password = '{1}', notifications = {3}  where id='{2}'", emailaddress, pw1, uid, not );
                    }

                    SqlConnection conn = new SqlConnection
                    {
                        ConnectionString = General.connstr
                    };
                    SqlCommand comm = new SqlCommand { Connection = conn };
                    comm.Connection.Open();
                    comm.CommandText = sqlquery;
                    comm.ExecuteScalar();
                    PanelMessage.Visible = true;
                    PanelForm.Visible = false;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "An error occurred saving your settings (ID: " +
                                TextBoxUserID.Text + ").", ex.Message ), true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", true);
        }
    }
}
