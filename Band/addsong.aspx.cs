using System;
using System.Data.SqlClient;

namespace Band
{
    public partial class _addsong : System.Web.UI.Page
    {

        protected void Page_Preload(object sender, EventArgs e)
        {
            General.checkloggedin(Response, Session, "addsong" );
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PanelMessage.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            SqlConnection conn = new SqlConnection
                                     {
                                         ConnectionString = General.connstr
                                     };
            SqlCommand comm = new SqlCommand { Connection = conn };
            comm.Connection.Open();
            var suid = Session["uid"];
            var artist = TextBoxArtist.Text.Replace("'", "");
            artist = artist.Replace("&", "");
            var title = TextBoxTitle.Text.Replace("'", "");
            title = title.Replace("&", "");

            var query = string.Format("INSERT INTO [videos] ([artist],[title],[addedby],[youtubeurl]) VALUES " +
                "('{0}' ,'{1}' ,{2} ,'{3}')", artist , title , suid, TextBoxURL.Text);
            comm.CommandText = query;
            comm.ExecuteScalar();
            PanelForm.Visible = false;
            PanelMessage.Visible = true;
            conn.Close();
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "An error occurred saving your new song.", ex.Message ), true);
            }
        }
    }
}
