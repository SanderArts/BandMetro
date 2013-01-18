using System;

namespace Band
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            General.setdefaults();

            if (Session["fullname"] == null)
            {
                LabelLoggedIn.Text = "Not logged in";
                //HyperLinkLogInOut.Text = "Log in";
                HyperLinkLogInOut.NavigateUrl = "login.aspx";
                HyperLinkLogInOut.ToolTip = "Click to login.";
            }
            else
            {
                LabelLoggedIn.Text = "Welcome";
                LabelLoggedInName.Text = Session["fullname"].ToString();
                //HyperLinkLogInOut.Text = "Log Out";
                HyperLinkLogInOut.NavigateUrl = "logout.aspx";
                HyperLinkLogInOut.ToolTip = "Click to logout.";
            }
        }


    }
}
