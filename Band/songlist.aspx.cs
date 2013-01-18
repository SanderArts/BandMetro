using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Band
{
    public partial class _songlist : System.Web.UI.Page
    {
        private bool show;
        
        protected void Page_Preload(object sender, EventArgs e)
        {
            // TESTING
            //Session["fullname"] = "Sander Arts";
            // TESTING

            General.checkloggedin(Response, Session, "songlist");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var counter = 0;
            SqlConnection conn = new SqlConnection
                                     {
                                         ConnectionString = General.connstr 
                                     };
            SqlCommand comm = new SqlCommand {Connection = conn};
            comm.Connection.Open();
            const string query = "select vid.id, vid.artist, vid.title, vid.added, vid.youtubeurl, usr.fullname from videos vid left join users usr on vid.addedby=usr.id";
            comm.CommandText = query;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int vid = reader.GetInt32(0);
                var artist = reader.GetString(1).Trim();
                var title = reader.GetString(2).Trim();
                DateTime dateadded = reader.GetDateTime(3);
                var url = reader.GetString(4).Trim();
                var by = reader.GetString(5).Trim();

                TableRow nrow = new TableRow();
                TableCell ncellleft = new TableCell();

                var yid = url.Replace("https://www.youtube.com/watch?v=", "");
                yid = yid.Replace("http://www.youtube.com/watch?v=", "");

                ncellleft.Text = string.Format("<object width='427' height='258'>" +
                                               "<param name='movie' value='http://www.youtube.com/v/{0}'></param>  " +
                                               "<param name='allowFullScreen' value='true'></param>" +
                                               "<param name='allowscriptaccess' value='always'></param>" +
                                               "<param name='wmode' value='opaque'></param>" +
                                               "<embed src='http://www.youtube.com/v/{0}?' " +
                                               "type='application/x-shockwave-flash' width='427' " +
                                               "height='258' allowscriptaccess='always' allowfullscreen='true' " +
                                               "wmode='opaque'></embed></object>", yid);
                
                nrow.Cells.Add(ncellleft);

                TableCell ncelright = new TableCell
                                          {
                                              Text = string.Format(@"<p class=""prev-indent-bot2"">&nbsp;Artist: {0}<br/><br/>&nbsp;Title: {1}<br/><br/>&nbsp;Added by: {2}<br/><br/>" +
                                                "&nbsp;Added on: {3}<br/><br/></p>", artist, title, by, dateadded.ToShortDateString()) + showpoints(vid)
                                          };
                ncelright.Font.Size = 12;
                nrow.Cells.Add(ncelright);

                if (show)
                {
                    counter += 1;
                    vtable.Rows.Add(nrow);

                    TableRow nrowhr = new TableRow();
                    TableCell ncelhr = new TableCell { ColumnSpan = 2, Text = "<hr>" };
                    nrowhr.Cells.Add(ncelhr);
                    vtable.Rows.Add(nrowhr);
                }
            }
            conn.Close();
            if (counter == 0)
            {
                TableRow nrowe = new TableRow();
                TableCell ncele = new TableCell { ColumnSpan = 2, Text = "<b>No data found.</b>" };
                nrowe.Cells.Add(ncele);
                vtable.Rows.Add(nrowe);
            }
        }


        protected string showpoints(int vid)
        {
            show = false;
            var htmltable = "<table><tr><td>&nbsp;<b>Name</b>&nbsp;</td><td>&nbsp;<b>Points</b>&nbsp;</td></tr>";
            var totalpoints = 0;
            
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = General.connstr
            };
            SqlCommand comm = new SqlCommand { Connection = conn };
            comm.Connection.Open();
            var query = string.Format(@"SELECT usr.id, usr.fullname, (SELECT vts.points FROM votes vts WHERE vts.votedby=usr.ID AND vts.videoid={0}) AS points FROM users usr where usr.admin=0", vid);

            comm.CommandText = query;
            var strresult = "FAILED";
            var strstyle = " style='color:red'";
            var pointsstr = "";

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string by = reader.GetString(1).Trim();
                Int32 points;
                if (!reader.IsDBNull(2))
                {
                    points = reader.GetInt32(2);
                    pointsstr = points.ToString();
                }
                else
                {
                    points = -1;
                }
                if (points == -1)
                {
                    points = 0;
                    pointsstr = "Not voted";
                    strresult = "PENDING";
                    strstyle = " style='color:orange'";
                }
                totalpoints += points;

                htmltable += string.Format("<tr><td>&nbsp;{0}&nbsp;</td><td>&nbsp;{1}&nbsp;</td></tr>", by, pointsstr);
            }
            htmltable += string.Format("<tr><td>&nbsp;<b>Total</b>&nbsp;</td><td>&nbsp;<b>{0}</b>&nbsp;</td></tr>", totalpoints);
            if (totalpoints > General.minpoints)
            {
                strresult = "PASSED";
                strstyle = " style='color:green'";
            }
            htmltable += string.Format("<tr><td>&nbsp;Status&nbsp;</td><td>&nbsp;<b{0}>{1}</b>&nbsp;</td></tr>", strstyle , strresult);
            htmltable += "</table>";
            conn.Close();
            
            switch (strresult)
            {
                case "PENDING":
                    if (ListBoxShow.SelectedIndex == 3) show = true;
                    break;
                case "FAILED":
                    if (ListBoxShow.SelectedIndex == 2) show = true;
                    break;
                case "PASSED":
                    if (ListBoxShow.SelectedIndex == 1) show = true;
                    break;
            }
            if (ListBoxShow.SelectedIndex == 0) show = true;
            return htmltable;
        }
    }
}
