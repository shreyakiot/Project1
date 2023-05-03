using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace Product1
{
    public partial class categoryMaster : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetData();

            }
        }

                 public void GetData()
                  {
                SqlConnection cn = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand("select * from Category", cn);
                cn.Open();
                Gridview.DataSource = cmd.ExecuteReader();
                Gridview.DataBind();
                cn.Close();
            }                   

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            string s = "insert into Category values('" + TextBox1.Text + "')";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            lblmsg.Text = "Recorder Insertedd...";
            TextBox1.Text = "";
            Response.Redirect("ProductMaster.aspx");
        }
    
         protected void Gridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Gridview.DataKeys[e.RowIndex].Value);
            SqlConnection cn = new SqlConnection(con);
            string s = "delete from Category where Cat_Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(s ,cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            GetData();
        }
        protected void Gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridview.EditIndex = e.NewEditIndex;
            GetData();
        }
        protected void Gridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           Gridview.EditIndex = -1;
            GetData();
        }

        protected void Gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            SqlConnection cn = new SqlConnection(con);

            Label id = Gridview.Rows[e.RowIndex].FindControl("Cat_Id") as Label;
            TextBox name = Gridview.Rows[e.RowIndex].FindControl("Cat_name") as TextBox;
            String s = "update Category set Cat_name='" +name.Text+ "' where Cat_Id='" + id.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.ExecuteNonQuery();
            cn.Close();

            Gridview.EditIndex = -1;
            GetData();
        }
    }
    }

  
 