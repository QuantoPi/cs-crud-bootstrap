using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace crudapp.Pages
{
    public partial class crud : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Request.QueryString["id"]!=null)
                {
                    sID = Request.QueryString["id"].ToString();
                    LoadData();
                    tbbirthdate.TextMode = TextBoxMode.DateTime;
                }
                if (Request.QueryString["op"]!=null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch(sOpc)
                    {
                        case "C":
                            this.labeltitle.Text = "Insert new User";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.labeltitle.Text = "User Query";
                            break;
                        case "U":
                            this.labeltitle.Text = "Update User";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.labeltitle.Text = "Delete User";
                            this.BtnDelete.Visible = true;
                            break;

                    }
                }
            }
        }

        void LoadData()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", conn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbname.Text = row[1].ToString();
            tbage.Text = row[2].ToString();
            tbemail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            tbbirthdate.Text = d.ToString("dd/MM/yyyy");
            conn.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = tbname.Text;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = tbage.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = tbbirthdate.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = tbname.Text;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = tbage.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = tbbirthdate.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("index.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}