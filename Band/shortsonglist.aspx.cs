using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Band
{
    public partial class _shortsonglist : System.Web.UI.Page
    {

        private bool show;
        
        protected void Page_Preload(object sender, EventArgs e)
        {
            // TESTING
            //Session["fullname"] = "Sander Arts";
            // TESTING

            General.checkloggedin(Response, Session, "shortsonglist");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var counter = 0;

            TableRow hrow = new TableRow();
            hrow.Font.Size = 12;
            hrow.Font.Italic = true;
            TableCell hcell1 = new TableCell { Text = "Artist" };
            hrow.Cells.Add(hcell1);
            TableCell hcell2 = new TableCell { Text = "Title" };
            hrow.Cells.Add(hcell2);
            TableCell hcell3 = new TableCell { Text = "Points" };
            hrow.Cells.Add(hcell3);
            TableCell hcell4 = new TableCell { Text = "Status" };
            hrow.Cells.Add(hcell4);
            vtable.Rows.Add(hrow);

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
                var vid = reader.GetInt32(0);
                var artist = reader.GetString(1).Trim();
                var title = reader.GetString(2).Trim();
                var totalpoints = gettotalpoints(vid);
                var status = "failed/pending";
                if (totalpoints > General.minpoints)
                {
                    status = "passed";
                }

                TableRow nrow = new TableRow();
                nrow.Font.Size = 12;
                TableCell ncell1 = new TableCell { Text = artist };
                nrow.Cells.Add(ncell1);
                TableCell ncell2 = new TableCell { Text = title };
                nrow.Cells.Add(ncell2);
                TableCell ncell3 = new TableCell { Text = totalpoints.ToString() };
                nrow.Cells.Add(ncell3);
                TableCell ncell4 = new TableCell { Text = status };
                nrow.Cells.Add(ncell4);

                if (show)
                {
                    counter += 1;
                    vtable.Rows.Add(nrow);
                }
            }
            conn.Close();
            if (counter == 0)
            {
                TableRow nrowe = new TableRow();
                TableCell ncele = new TableCell { ColumnSpan = 4, Text = "<b>No data found.</b>" };
                nrowe.Cells.Add(ncele);
                vtable.Rows.Add(nrowe);
            }
        }


        protected int gettotalpoints(long id)
        {
            var points = 0;
            
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = General.connstr
            };
            SqlCommand comm = new SqlCommand { Connection = conn };
            comm.Connection.Open();
            var query = string.Format(@"SELECT SUM(vts.points) as total FROM votes vts WHERE vts.videoid={0}", id);
            comm.CommandText = query;

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    points = reader.GetInt32(0);
                }
            }
            conn.Close();

            show = false;
            switch (ListBoxShow.SelectedIndex)
            {
                case 0:
                    show = true;
                    break;
                case 1:
                    if (points > General.minpoints) show = true;
                    break;
                case 2:
                    if (points <= General.minpoints) show = true;
                    break;
            }
 
            if (ListBoxShow.SelectedIndex == 0) show = true;
            
            return points;
        }
    }
}
