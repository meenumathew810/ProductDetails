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
    public partial class ProductInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SUYPC068;Initial Catalog=ProductDb;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("insert into Product(ProductName,ProductDescription,ProductCode) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", con);

            cmd.CommandType = CommandType.Text;

            try

            {

                con.Open();

                cmd.ExecuteNonQuery();

                Label1.Text = "Data inserted successfully";

                Label1.Visible = true;

                con.Close();


            }

            catch (Exception ex)

            {
                Label1.Text = "Not successfull";
                Label1.Visible = true;
            }
            finally
            {
                Response.Redirect("ProductDetails.aspx");
            }
        }
    }
}