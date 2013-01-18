using System;

namespace Band
{
    public partial class _logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            PanelMessage.Visible = true;
        }
    }
}
