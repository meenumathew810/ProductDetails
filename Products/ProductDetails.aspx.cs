using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Products
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=SUYPC068;Initial Catalog=ProductDb;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        protected void FillGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Product", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductInsert.aspx");
        }

        
        
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try

            {
                int Eid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                SqlCommand cmd = new SqlCommand("delete Product where ProductID=" + Eid, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex){  
            }
            finally
            {
                Response.Redirect("ProductDetails.aspx");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        { 
            GridView1.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string ProductID = GridView1.DataKeys[e.RowIndex].Values["ProductID"].ToString();
                string ProductName = e.NewValues[0].ToString();
                string ProductDescription = e.NewValues[1].ToString();
                string ProductCode = e.NewValues[2].ToString();
                con.Open();
                string sql = "update Product set ProductName='" + ProductName + "', ProductDescription = '" + ProductDescription + "', ProductCode = '" + ProductCode + "' where ProductID='" + ProductID + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                FillGrid();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                Response.Redirect("ProductDetails.aspx");
            }
        }

    }
}