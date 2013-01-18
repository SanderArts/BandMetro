using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Band
{
    public partial class _songlistajax : System.Web.UI.Page
    {
        
        protected void Page_Preload(object sender, EventArgs e)
        {
            // TESTING
            //Session["fullname"] = "Sander Arts";
            //Session["uid"] = "1";
            //Session["admin"] = false;
            // TESTING

            General.checkloggedin(Response, Session, "songlistajax" );

            ddl.Visible = false;
            LabelVote.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("vid", HiddenFieldvid.Value); var requestedid = "";

            if (!Page.IsPostBack)
            {
                if (Request["vid"] != null)
                {
                    requestedid = Request["vid"];
                }
            }

            try
            {
                var counter = 0;
                SqlConnection conn = new SqlConnection
                                         {
                                             ConnectionString = General.connstr 
                                         };
                SqlCommand comm = new SqlCommand {Connection = conn};
                comm.Connection.Open();
                const string query = "select vid.id, vid.artist, vid.title, vid.added, usr.fullname, " + 
                                    "usr.email from videos vid left join users usr on vid.addedby=usr.id";
                comm.CommandText = query;
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    var show = false;
                    var vid = reader.GetInt32(0);
                    var artist = reader.GetString(1).Trim();
                    var title = reader.GetString(2).Trim();
                    DateTime dateadded = reader.GetDateTime(3);
                    var by = reader.GetString(4).Trim();
                    var totalpoints = getpoints(vid);

                    switch (ListBoxShow.SelectedValue)
                    {
                        case "0":
                            show = true;
                            break;
                        case "1":
                            if (totalpoints > General.minpoints) show = true;
                            break;
                        case "2":
                            if (totalpoints <= General.minpoints & totalpoints != -1) show = true;
                            break;
                        case "3":
                            if (totalpoints == -1) show = true;
                            break;
                    }

                    if (show)
                    {
                        TableRow nrow = new TableRow();
                        TableCell ncellleft = new TableCell
                                                  {
                                                      Text =
                                                          string.Format(
                                                              "<a href='./songlistajax.aspx?vid={4}'>{0} - {1}</a><br/>Added by {2} on {3}<br/>",
                                                              artist, title, by, dateadded, vid)
                                                  };
                        counter += 1;
                        nrow.Cells.Add(ncellleft);
                        vtable.Rows.Add(nrow);
                    }
                }
                reader.Close();
                TableDetails.Visible = false;       //Hide details table by default

                if (counter == 0)
                {
                    TableRow nrowe = new TableRow();
                    TableCell ncele = new TableCell { ColumnSpan = 2, Text = "<b>No data found.</b>" };
                    nrowe.Cells.Add(ncele);
                    vtable.Rows.Add(nrowe);
                }


                if (requestedid != "")
                {
                    var queryurl = string.Format("SELECT vid.youtubeurl, vid.artist, vid.title, usr.fullname, usr.email from videos vid " +
                                                "left join users usr on vid.addedby=usr.id WHERE vid.ID = {0}", requestedid);
                    comm.CommandText = queryurl;
                    SqlDataReader readerurl = comm.ExecuteReader();
                    var vurl = "";
                    var vartist = "";
                    var vtitle = "";
                    var vfullname = "";
                    var vemail = "";
                    if (readerurl.HasRows)
                    {
                        vurl = readerurl.GetString(0).Trim();
                        vartist = readerurl.GetString(1).Trim();
                        vtitle = readerurl.GetString(2).Trim();
                        vfullname = readerurl.GetString(3).Trim();
                        vemail = readerurl.GetString(4).Trim();
                    }
                    readerurl.Close();
                    if (vurl != "")
                    {
                        TableRow drow = new TableRow();
                        TableCell dcell = new TableCell();
                        var yid = vurl.Replace("https://www.youtube.com/watch?v=", "");
                        yid = yid.Replace("http://www.youtube.com/watch?v=", "");

                        dcell.Text = string.Format("<object width='427' height='258'>" +
                                                    "<param name='movie' value='http://www.youtube.com/v/{0}'></param>  " +
                                                    "<param name='allowFullScreen' value='true'></param>" +
                                                    "<param name='allowscriptaccess' value='always'></param>" +
                                                    "<param name='wmode' value='opaque'></param>" +
                                                    "<embed src='http://www.youtube.com/v/{0}?' " +
                                                    "type='application/x-shockwave-flash' width='427' " +
                                                    "height='258' allowscriptaccess='always' allowfullscreen='true' " +
                                                    "wmode='opaque'></embed></object>" , yid);
                        //Add some javascript to prevent __flash__removeCallback errors when clicking something if a video is playing...
                        dcell.Text +=
                            "<script type='text/javascript'>(function(){var s=function(){__flash__removeCallback=function(i,n)" +
                            "{if(i)i[n]=null;};window.setTimeout(s,10);};s();})();</script>";

                        drow.Cells.Add(dcell);
                        TableDetails.Rows.Add(drow);
                        TableDetails.Visible = true;

                        showvotes(requestedid, vartist, vtitle, vfullname, vemail );
                    }
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "An error occurred showing the page.", ex.Message ), true);
            }
        }


        protected int getpoints(int vid)
        {
            var totalpoints = 0;
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = General.connstr
            };
            SqlCommand comm = new SqlCommand { Connection = conn };
            comm.Connection.Open();
            var query = string.Format(@"SELECT usr.id, usr.fullname, (SELECT vts.points FROM votes vts " + 
                "WHERE vts.votedby=usr.ID AND vts.videoid={0}) AS points FROM users usr where usr.admin=0", vid);
            comm.CommandText = query;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(2))
                {
                    totalpoints += reader.GetInt32(2);
                }
                else
                {
                    totalpoints = -1;
                }
            }
            conn.Close();
            return totalpoints;
        }


        protected void showvotes(string vid, string artist, string title, string fullname, string email)
        {
            var notvoted = false;
            Table vTable = new Table {Width = 350};
            TableRow hrow = new TableRow();
            TableCell hcell1 = new TableCell { Text = "<i>Name</i>" };
            hrow.Cells.Add(hcell1);
            TableCell hcell2 = new TableCell { Text = "<i>Points</i>" };
            hrow.Cells.Add(hcell2);
            vTable.Rows.Add(hrow);

            var totalpoints = 0;
            var strresult = "FAILED";
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = General.connstr
            };
            SqlCommand comm = new SqlCommand { Connection = conn };
            var query = string.Format(@"SELECT usr.id, usr.fullname, (SELECT vts.points FROM votes vts " + 
                "WHERE vts.votedby=usr.ID AND vts.videoid={0}) AS points FROM users usr where usr.admin=0", vid);
            comm.CommandText = query;
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                var uid = reader.GetInt32(0);
                var by = reader.GetString(1).Trim();
                Int32 points;
                string pointsstr;
                if (!reader.IsDBNull(2))
                {
                    points = reader.GetInt32(2);
                    pointsstr = points.ToString();
                }
                else
                {
                    points = 0;
                    pointsstr = "Not voted";
                    strresult = "PENDING";
                    if (uid.ToString() == Session["uid"].ToString())
                    {
                        notvoted = true;
                    }
                }
                totalpoints += points;

                TableRow drow = new TableRow();
                TableCell dcell1 = new TableCell { Text = by };
                drow.Cells.Add(dcell1);
                TableCell dcell2 = new TableCell { Text = pointsstr };
                drow.Cells.Add(dcell2);
                vTable.Rows.Add(drow);
            }
            conn.Close();

            if (totalpoints > General.minpoints)
            {
                strresult = "PASSED";
            }

            TableRow erow = new TableRow();
            TableCell ecell1 = new TableCell { Text = " " };
            erow.Cells.Add(ecell1);
            TableCell ecell2 = new TableCell { Text = totalpoints + " (" + strresult + ")" };
            erow.Cells.Add(ecell2);
            vTable.Rows.Add(erow);
            PanelDetails.Controls.Add(vTable);      //Add table to panel

            if (notvoted)
            {
                LabelVote.Visible = true;
                HiddenFieldvid.Value = vid;
                HiddenFieldArtist.Value = artist;
                HiddenFieldTitle.Value = title;
                HiddenFieldFullname.Value = fullname;
                HiddenFieldEmail.Value = email;
                HiddenFieldPoints.Value = totalpoints.ToString();
                ddl.Visible = true;

                for (var x = 1; x<=20; x+=1 )
                {
                    ddl.Items.Add(x.ToString());
                }
            }
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var vidpoints = ddl.SelectedValue;
                var vidid = HiddenFieldvid.Value;
                var artist = HiddenFieldArtist.Value;
                var title = HiddenFieldTitle.Value;
                var fullname = HiddenFieldFullname.Value;
                var email = HiddenFieldEmail.Value;
                var points = HiddenFieldPoints.Value;

                if (vidpoints != "0" & vidid != "")
                {
                    SqlConnection conn = new SqlConnection
                    {
                        ConnectionString = General.connstr
                    };
                    SqlCommand comm = new SqlCommand { Connection = conn };
                    comm.Connection.Open();

                    var query =
                        string.Format("INSERT INTO [votes] ([votedby],[videoid],[points]) VALUES ('{0}', {1}, {2})", Session["uid"], vidid, vidpoints);
                    comm.CommandText = query;
                    comm.ExecuteScalar();
                    conn.Close();
                    int totpoints = Convert.ToInt32(points) + Convert.ToInt32(vidpoints);
                    checklastvote(vidid, totpoints, artist, title, DateTime.Today.ToShortDateString(), email, fullname);
                }
                Response.Redirect(string.Format("./songlistajax.aspx?vid={0}", vidid), true);
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "An error occurred saving your vote for video ID: " +
                                HiddenFieldvid.Value, ex.Message ), true);
            }
        }


        protected void checklastvote(string videoid, int totalpoints, string artist, string title, string dateadded, string emailuser, string fullname)
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = General.connstr
            };
            SqlCommand comm = new SqlCommand { Connection = conn };
            comm.Connection.Open();
            var query = string.Format("SELECT ( SELECT COUNT(ID) FROM users WHERE admin=0 ) AS numberofusers, " +
                    "( SELECT COUNT(ID) FROM votes WHERE videoid={0} ) AS numberofvotes", videoid);

            comm.CommandText = query;
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                var numberofusers = reader.GetInt32(0);
                var numberofvotes = reader.GetInt32(1);
                if (numberofusers == numberofvotes)
                {
                    //You are the last one to vote!
                    var htmlbody = String.Format("On {0} you added a new song: <br/><br/><br/>", dateadded);
                    htmlbody += String.Format("{0} - {1}.", artist, title);
                    htmlbody += "<br/><br/><br/>";

                    if (totalpoints <= General.minpoints)
                    {
                        htmlbody += "We are sorry to inform you that your song did not pass voting and is not accepted.";
                    }
                    else
                    {
                        htmlbody += "We are happy to inform you that your song just passed voting and is accepted!";
                    }
                    htmlbody += "<br/><br/><br/><br/>";
                    General.sendmail(emailuser, fullname, htmlbody);
                }
            }
            conn.Close();
        }
    
    
    }
}
