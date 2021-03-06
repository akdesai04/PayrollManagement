﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace Employee_View_Details
{
    public partial class Employee_Detail : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmpId.Text))
            {
                String source = @"Data Source=DESKTOP-O80U5V5\SQL_AMAN;Initial Catalog=SoftDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conn = new SqlConnection(source);

                conn.Open();
                String queryDisplay = "SELECT * FROM Employee WHERE EMPLOYEE_ID = " + int.Parse(txtEmpId.Text);
                SqlCommand cmd = new SqlCommand(queryDisplay, conn);
                SqlDataReader mdr = cmd.ExecuteReader();

                if (mdr.Read())
                {
                    txtFname.Text = mdr["first_name"].ToString();
                    txtLname.Text = mdr["last_name"].ToString();
                    txtPhone.Text = mdr["phone_no"].ToString();
                    txtEmail.Text = mdr["email"].ToString();
                    lblSSN.Visible = true;
                    lblSSN.Text = mdr["SSN"].ToString();
                    txtAdd1.Text = mdr["address"].ToString();
                }
                conn.Close();

            }
            else
            {
                lblViewWarning.Visible = true;
                lblViewWarning.Text = "You must enter employee ID";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmpId.Text))
            {
                enableControls();
            }
            else
            {
                lblEditWarning.Visible = true;
                lblEditWarning.Text = "Enter employee ID";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmpId.Text))
            {
                String source = @"Data Source=DESKTOP-O80U5V5\SQL_AMAN;Initial Catalog=SoftDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conn = new SqlConnection(source);

                conn.Open();
                String queryDisplay = "SELECT * FROM Employee WHERE EMPLOYEE_ID = " + int.Parse(txtEmpId.Text);
                String queryUpdate = "UPDATE Employee SET phone_no='" + this.txtPhone.Text + "', email='" + this.txtEmail.Text + "', address='" + this.txtAdd1.Text + "' WHERE employee_id = '" + this.txtEmpId.Text + "'";
                SqlCommand cmd = new SqlCommand(queryUpdate, conn);
                SqlCommand cmd1 = new SqlCommand(queryDisplay, conn);
                SqlDataReader mdr = cmd.ExecuteReader();

                if (mdr.Read())
                {
                    txtFname.Text = mdr["first_name"].ToString();
                    txtLname.Text = mdr["last_name"].ToString();
                    txtPhone.Text = mdr["phone_no"].ToString();
                    txtEmail.Text = mdr["email"].ToString();
                    lblSSN.Text = mdr["SSN"].ToString();
                    txtAdd1.Text = mdr["address"].ToString();
                }
                conn.Close();

                disableControls();
            } 
        }
        void enableControls()
        {
            txtFname.Enabled = true;
            txtLname.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAdd1.Enabled = true;
        }

        void disableControls()
        {
            txtFname.Enabled = false;
            txtLname.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtAdd1.Enabled = false;
        }
    }
}