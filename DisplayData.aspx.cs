using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Product1
{
    public partial class DisplayData : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            getCats();
            getProducts();

        }

        public void getCats()
        {
            string s = "select * from Category";
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(s, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            cn.Close();
        }
        public void getProducts()
        {
            string s = "select * from product1";
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(s, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            cn.Close();
        }
    }
}