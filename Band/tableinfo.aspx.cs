using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Band
{
    public partial class _tableinfo : System.Web.UI.Page
    {

        
        protected void Page_Preload(object sender, EventArgs e)
        {
            // TESTING
            //Session["fullname"] = "Sander Arts";
            //Session["uid"] = "1";
            //Session["admin"] = false;
            // TESTING

            General.checkloggedin(Response, Session, "tableinfo" );

            if (!General.isadminuser( Response, Session ))
            {
                Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "Access denied.", "Only administrators can access this page."), true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxTable.SelectedIndex >= 0)
                {
                    var counter = 0;
                    LabelTableName.Text = ListBoxTable.SelectedValue;

                    SqlConnection conn = new SqlConnection
                                             {
                                                 ConnectionString = General.connstr 
                                             };
                    SqlCommand comm = new SqlCommand {Connection = conn};
                    comm.Connection.Open();
                    var query = string.Format("SELECT * FROM {0} ORDER BY id", ListBoxTable.SelectedValue );
                    comm.CommandText = query;
                    var reader = comm.ExecuteReader();

                    TableRow hrow = new TableRow();
                    hrow.Font.Size = 12;
                    hrow.Font.Italic = true;
                    var cols = reader.FieldCount;
                    for (var x = 0; x < cols;x += 1)
                    {
                        TableCell hcell = new TableCell { Text = reader.GetName(x) };
                        hrow.Cells.Add(hcell);
                    }
                    vtable.Rows.Add(hrow);

                    while (reader.Read())
                    {
                        counter += 1;

                        TableRow nrow = new TableRow();
                        nrow.Font.Size = 12;
                        for (var y = 0; y < cols; y += 1)
                        {
                            TableCell ncell = new TableCell { Text = reader.GetValue(y).ToString() };
                            nrow.Cells.Add(ncell);
                        }
                        vtable.Rows.Add(nrow);
                    }
                    conn.Close();

                    if (counter == 0)
                    {
                        TableRow nrowe = new TableRow();
                        TableCell ncele = new TableCell { ColumnSpan = cols, Text = "<b>No data found.</b>" };
                        nrowe.Cells.Add(ncele);
                        vtable.Rows.Add(nrowe);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("./errorpage.aspx?lbl={0}&txt={1}", "An error occurred showing the table information.", ex.Message ), true);
            }
        }
    }
}
