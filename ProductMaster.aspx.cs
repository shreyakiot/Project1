using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
          // con.Open();
            if (!IsPostBack)
            {
                GetCategory();
                GetData();
            }
        }
        public void GetCategory()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Category", con);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "Cat_name";
            DropDownList1.DataValueField = "Cat_Id";
            DropDownList1.DataBind();
            con.Close();
        }

        public void GetData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from product1", con);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            Gridview.DataSource = ds;
            Gridview.DataBind();
            con.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "insert into product1 values('"+TextBox1.Text+"','"+DropDownList1.SelectedValue+"','"+DropDownList1.SelectedItem.Text+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
           
            TextBox1.Text = "";
            Response.Redirect("DisplayData.aspx");

        }

        protected void Gridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Gridview.DataKeys[e.RowIndex].Value);
            SqlConnection cn = new SqlConnection("con");
            string s = "delete from product1 where Product_id='" + id + "'";
            SqlCommand cmd = new SqlCommand(s, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

           
        }

        protected void Gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridview.EditIndex = e.NewEditIndex;
          
        }

        protected void Gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            SqlConnection cn = new SqlConnection("con");

            Label id = Gridview.Rows[e.RowIndex].FindControl( "Product_id") as Label;
            TextBox name = Gridview.Rows[e.RowIndex].FindControl("Product_name") as TextBox;
            String s = "update product1 set Product_name='" + name.Text + "' where Product_id='" + id.Text + "'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.ExecuteNonQuery();
            cn.Close();

            Gridview.EditIndex = -1;
           
        }

        protected void Gridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gridview.EditIndex = -1;
            GetData();
        }
    }
}