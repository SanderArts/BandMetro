using System.Net.Mail;
using System.Web;
using System.Web.SessionState;

namespace Band
{
    public class General
    {

        public static string connstr;
        public static int minpoints;

        public static void setdefaults()
        {
            //WEB.CONFIG:
            //connstr = ConfigurationManager.ConnectionStrings["db_artsenco"].ConnectionString;
            //LOCAL:
            //connstr = "Data Source=LION008;Initial Catalog=BAND;Integrated Security=True";
            //LIVE:
            connstr = "Data Source=mssql.artsenco.nl;Initial Catalog=db_artsenco;User Id=dbadmin;Password=1db2use!;";
            minpoints = 80;
            
        }


        public static void checkloggedin(HttpResponse myresponse, HttpSessionState mysession, string to_page)
        {
            var to_url = "login.aspx";
            if (to_page != "") to_url += "?page=" + to_page;
            if (mysession["fullname"] == null)
            {
                myresponse.Redirect(to_url, true);
            } else
            {
                if (mysession["fullname"].ToString().Trim() == "")
                {
                    myresponse.Redirect(to_url, true);
                }
            }
        }


        public static bool isadminuser(HttpResponse myresponse, HttpSessionState mysession)
        {
            var isadmin = false;
            if (mysession["admin"] != null)
            {
                if ((bool)mysession["admin"])
                {
                    isadmin = true;
                }
            }
            return isadmin;
        }


        public static void sendmail(string useremail, string userfullname, string htmlbody )
        {
            var sHTML = addheader( userfullname );

            sHTML += htmlbody;            
            sHTML += addfooter();
        
            MailMessage message = new MailMessage("myband@artsenco.nl", useremail, "You have to vote!", "MyBand notifications");
            message.IsBodyHtml = true;
            message.Body = sHTML;
            SmtpClient myclient = new SmtpClient("artsenco.nl", 25);
            myclient.UseDefaultCredentials = true;
            myclient.Credentials = new System.Net.NetworkCredential("myband@artsenco.nl", "P@ssw0rd!");
            myclient.Send(message);
        }
    

        private static string addheader(string uname)
        {
            var newheader = "<html lang='en'>" +
                            "<head>" +
                            "<title>Message from MyBand</title>" +
                            "<style>" +
                            "body {padding-top: 24px; padding-bottom: 88px; position: relative; font-family: 'Open Sans',Arial,Helvetica,Sans-Serif; " +
                            "font-weight: 300; font-size:11px; color: rgb(255, 255, 255);" +
                            "background-color: rgb(60, 60, 60); background-repeat: repeat;}" +
                            ".container-fluid {padding-left: 70px; padding-right: 70px;}" +
                            "h3, .win-type-large {font-weight: 600; font-size: 20px; line-height: 26px; margin-top: 0; margin-bottom: 0;}" +
                            "body, h5, legend {font-weight: 300; font-size: 13px; line-height: 20px;}" +
                            "body,button, input,textarea, .win-textarea,select, option {letter-spacing: 0.02em;}" +
                            "a {text-decoration: underline;color:#24A0DA }img {border-style: none;}" +
		                    ".footersmall {padding-left: 70px; padding-right: 70px;font-size: 9px;}" +
                            "</style>" +
                            "</head>" +
                            "<body >" +
                            "<div class='container-fluid'>" +
                            "<div class='padding-grid-1'>";

            newheader += string.Format( "<h3>Hi {0}, we have news for you! </h3>", uname );

            newheader += "</div>" +
                        "<div class='wrapper'>" +
                        "<br /><br />" +
                        "<p>";
            return newheader;
        }


        private static string addfooter()
        {
            const string newfooter = 
				"<br/><br/>" +
				"Please visit <a href='http://myband.artsenco.nl/songlistajax.aspx'>MyBand</a> for more information." +
                "<br/><br/><br/>" +
                "Regards,<br/>" +
                "MyBand" +
                "<br/><br/>" +
                "</p>" +
                "</div>" +
                "</div>" +
    		    "<div>" +
			    "<br/><br/><br/>" +
			    "<p class='footersmall'>" +
			    "This is an automatic generated message. Please do not reply to this e-mail." +
			    "</p>" +
    		    "</div>" +
                "</body>" +
                "</html>";
            return newfooter;
        }
    

    }
}