using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace crudapp.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        void LoadTable()
        {
            SqlCommand cmd = new SqlCommand("sp_load", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridvusers.DataSource = dt;
            gridvusers.DataBind();
            conn.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/crud.aspx?op=C");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnQuery = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnQuery.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/crud.aspx?id="+id+"&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnQuery = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnQuery.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/crud.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnQuery = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnQuery.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/crud.aspx?id=" + id + "&op=D");
        }
    }
}