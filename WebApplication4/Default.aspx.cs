﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonId_Click(Object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                // Writing insert query  
                //string query = "insert into student(name,email,contact)values(" + UsernameId.Text + ","+ EmailId.Text + "," + ContactId.Text + "')";  
                string query = "insert into student(name,email,contact)values('" + UsernameId.Text + "', '" 
                 + EmailId.Text + "','" + ContactId.Text + "')";  
                SqlCommand sc = new SqlCommand(query, con);
                // Opening connection  
                con.Open();
                // Executing query  
                int status = sc.ExecuteNonQuery();
                Label1.Text = "Your record has been saved with the following details!";
                // ----------------------- Retrieving Data ------------------ //  
                SqlCommand cm = new SqlCommand("select top 1 * from student order by id desc", con);
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                Label2.Text = "User Name"; Label5.Text = sdr["name"].ToString();
                Label3.Text = "Email ID"; Label6.Text = sdr["email"].ToString();
                Label4.Text = "Contact"; Label7.Text = sdr["contact"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}