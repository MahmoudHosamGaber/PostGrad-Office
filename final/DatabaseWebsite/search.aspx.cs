﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseWebsite
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabaseWebsite"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            String Thesis = thesis.Text;

            SqlCommand loginProc = new SqlCommand("searchThesis", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

            loginProc.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar)).Value = Thesis;


            conn.Open();
            
            loginProc.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(loginProc);
            DataTable da = new DataTable();
            adapter.Fill(da);
            GridView1.DataSource = da;
            GridView1.DataBind();
            conn.Close();
            if (GridView1.Rows.Count ==0)
            {
                Label label = new Label();
                label.Text = "No Thesis with the Given Name";
                label.CssClass = "fail";
                form1.Controls.Add(label);
            }
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("examiner.aspx");
        }
    }
}