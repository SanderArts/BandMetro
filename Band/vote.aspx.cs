using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Band
{
    public partial class _vote : System.Web.UI.Page
    {

        protected void Page_Preload(object sender, EventArgs e)
        {
            // TESTING
            //Session["fullname"] = "Sander Arts";
            //Session["uid"] = 1;
            // TESTING

            General.checkloggedin(Response, Session, "vote");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((bool)Session["admin"])
            {
                LabelMsg1.Text = "Sorry, administrators cannot vote.";
                PanelForm.Visible = false;
                PanelMessage.Visible = true;
                HyperLinkVotes.Visible = true;
                HyperLinkVotes.NavigateUrl = "voteslist.aspx";
            } else {
                SqlConnection conn = new SqlConnection
                                         {
                                             ConnectionString = General.connstr 
                                         };
                SqlCommand comm = new SqlCommand {Connection = conn};
                comm.Connection.Open();
                string query = string.Format("select vid.id, vid.artist, vid.title, vid.added, vid.youtubeurl, usr.fullname, " +
                               "(SELECT vts.points FROM votes vts WHERE vts.votedby={0} AND vts.videoid=vid.id) as points " +
                               "from videos vid left join users usr on vid.addedby=usr.id", Session["uid"] );

                comm.CommandText = query;
                SqlDataReader reader = comm.ExecuteReader();
                var counter = 0;
                while (reader.Read())
                {
                    var vid = reader.GetInt32(0);
                    var artist = reader.GetString(1).Trim();
                    var title = reader.GetString(2).Trim();
                    DateTime dateadded = reader.GetDateTime(3);
                    var url = reader.GetString(4).Trim();
                    var by = reader.GetString(5).Trim();

                    if (reader.IsDBNull(6))
                    {
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
                        TableCell ncelright = new TableCell();

                        counter += 1;
                        var htmlvote = string.Format("<input runat='Server' type='hidden' name='videoid{0}' Value='{1}' />", counter, vid);
                        htmlvote += string.Format("<input style='text-align:right;width:50px' runat='Server' size='3' type='text' name='points{0}' value='' />", counter);
                        ncelright.Text = string.Format(@"<p class=""prev-indent-bot2"">&nbsp;Artist: {0}<br/><br/>&nbsp;Title: {1}<br/><br/>&nbsp;Added by: {2}<br/><br/>" +
                              "&nbsp;Added on: {3}<br/><br/>&nbsp;Vote now:&nbsp;{4}&nbsp;points (0-20)<br/><br/></p>", artist, title, by, dateadded.ToShortDateString(), htmlvote);
                        ncelright.Font.Size = 12;
                        nrow.Cells.Add(ncelright);
                        vtable.Rows.Add(nrow);

                        TableRow nrowhr = new TableRow();
                        TableCell ncelhr = new TableCell { ColumnSpan = 2, Text = "<br/><hr><br/>" };
                        nrowhr.Cells.Add(ncelhr);
                        vtable.Rows.Add(nrowhr);
                    }
                }
                conn.Close();

                TableRow nrowx = new TableRow();
                var htmlcounter = string.Format(@"<input runat='Server' type='hidden' name='totallines' value='{0}' />", counter);
                TableCell ncelx = new TableCell { ColumnSpan = 2, Text = htmlcounter };
                nrowx.Cells.Add(ncelx);
                vtable.Rows.Add(nrowx);

                if (counter==0)
                {
                    LabelMsg1.Text = "No songs here for you to vote.";
                    PanelForm.Visible = false;
                    PanelMessage.Visible = true;
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var t = Request.Form["totallines"];
            if (t != "")
            {
                var totallines = Convert.ToInt32(t);
                for (var cnt = 1; cnt <= totallines; cnt += 1)
                {
                    //LabelVote.Text = cnt + "|" + t;
                    var videoid = "videoid" + cnt;
                    var pointsid = "points" + cnt;
                    var vid = Request.Form[videoid].Trim();
                    var p = Request.Form[pointsid].Trim();
                    if (p == "") p = "-1";

                    var ip = Convert.ToInt32(p);

                    if (vid != "" & ip >= 0 & ip <= 20)
                    {
                        SqlConnection conn = new SqlConnection
                        {
                            ConnectionString = General.connstr
                        };
                        SqlCommand comm = new SqlCommand { Connection = conn };
                        comm.Connection.Open();

                        var query =
                            string.Format("INSERT INTO [votes] ([votedby],[videoid],[points]) VALUES ('{0}', {1}, {2})", Session["uid"], vid, p);
                        comm.CommandText = query;
                        comm.ExecuteScalar();
                        conn.Close();
                    }
                }
                Response.Redirect("vote.aspx", true);
            }
        }


    }
}
