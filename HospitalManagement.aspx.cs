using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HospitalManagement
{
    public partial class HospitalManagement : System.Web.UI.Page

    {
        string connStr = "Data Source=DESKTOP-5QNS0TK;Initial Catalog=HotelManagement;Integrated Security=True";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            { 
                LoadGrid(); 
            }
        }

        void LoadGrid()
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Appointments", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvAppointments.DataSource = dt;
            gvAppointments.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            string query = "INSERT INTO Appointments (PatientName, DoctorName, AppDate) VALUES (@name, @doc, @date)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@doc", ddlDoctor.SelectedValue);
            DateTime bookingDateTime = Convert.ToDateTime(txtDate.Text).Add(DateTime.Now.TimeOfDay);
            cmd.Parameters.AddWithValue("@date", bookingDateTime);
            //cmd.Parameters.AddWithValue("@date", DateTime.Now);
           // cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(txtDate.Text));
            // Current Time ke saath date bhejne ke liye
            //DateTime bookingDateTime = DateTime.Parse(txtDate.Text).Add(DateTime.Now.TimeOfDay);
            //cmd.Parameters.AddWithValue("@date", bookingDateTime);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadGrid(); // Grid refresh karega

            Response.Redirect(Request.RawUrl);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            

            if (hfAppID.Value == "")
            {
                return; // koi row select nahi hui
            }

            int appId = Convert.ToInt32(hfAppID.Value);

            SqlConnection conn = new SqlConnection(connStr);
            string query = "UPDATE Appointments SET Status = @status WHERE AppID = @id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@status", "Confirmed");
            cmd.Parameters.AddWithValue("@id", appId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadGrid();

         
         ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
        "alert('Appointment Confirmed Successfully!');", true);

         txtName.Text = "";
         ddlDoctor.SelectedIndex = 0;
         txtDate.Text = "";
         hfAppID.Value = "";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (hfAppID.Value != "")
            {
                SqlConnection conn = new SqlConnection(connStr);

                string query = "DELETE FROM Appointments WHERE AppID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", hfAppID.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadGrid();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "alert('Appointment Deleted Successfully!');", true);

                // Clear fields after delete
                txtName.Text = "";
                ddlDoctor.SelectedIndex = 0;
                txtDate.Text = "";
                hfAppID.Value = "";
            }


        }


        protected void gvAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {           


            int appId = Convert.ToInt32(gvAppointments.SelectedDataKey.Value);
            hfAppID.Value = appId.ToString();

            SqlConnection conn = new SqlConnection(connStr);
            string query = "SELECT * FROM Appointments WHERE AppID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", appId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtName.Text = dr["PatientName"].ToString();
                ddlDoctor.SelectedValue = dr["DoctorName"].ToString();

                DateTime dt = Convert.ToDateTime(dr["AppDate"]);
                txtDate.Text = dt.ToString("yyyy-MM-dd");
            }

            conn.Close();

        }


        











    }
}