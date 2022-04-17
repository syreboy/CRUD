using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using Npgsql;

namespace CRUD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnInsertion_Click(object sender, EventArgs e)
        {
            try
            {
                /* Insertion After Validations*/
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=postgres ;User Id=postgres; Password=12345"))
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into pabrikan(namapabrikan) values(@name)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@name", txtEmpFname.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtEmpFname.Text = "";
                    txtEmpID.Text = "";
                    lblmsg.Text = "Data Has been Saved";
                }
            }
            catch (Exception ex) { }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try /* Select After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=postgres ;User Id=postgres; Password=12345"))
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from pabrikan";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex) { }
        }
        protected void btnUpdation_Click(object sender, EventArgs e)
        {
            try /* Updation After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=postgres ;User Id=postgres; Password=12345"))
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update pabrikan set namapabrikan=@name where idpabrikan=@ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", int.Parse(txtEmpID.Text)));
                    cmd.Parameters.Add(new NpgsqlParameter("@name", txtEmpFname.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtEmpFname.Text = "";
                    txtEmpID.Text = "";
                    lblmsg.Text = "Data Has been Updated";

                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try /* Deletion After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=postgres ;User Id=postgres; Password=12345"))
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Delete from pabrikan where idpabrikan=@ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", int.Parse(txtEmployeeID.Text)));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtEmployeeID.Text = "";
                    lblmessage.Text = "Data Has been Deleted";
                }
            }
            catch (Exception ex) { }
        }
    }
}