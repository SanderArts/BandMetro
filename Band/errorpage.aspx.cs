using System;

namespace Band
{
    public partial class errorpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var errorlabel = "A general error occurred.";
            var errortext = "No additional information available. Please try again later or contact your administrator and explain what happened.";
            if (Request["lbl"] != null)
            {
                if (Request["lbl"] != "")
                {
                    errorlabel = Request["lbl"];
                }
            }
            if (Request["txt"] != null)
            {
                if (Request["txt"] != "")
                {
                    errortext = Request["txt"];
                }
            }
            LabelErrorMsg.Text = errorlabel;
            LabelErrorText.Text = errortext;        
        }    
    }
}