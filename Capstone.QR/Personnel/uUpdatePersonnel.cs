using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class uUpdatePersonnel : UserControl
    {
        private static uUpdatePersonnel _instance;

        public static uUpdatePersonnel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uUpdatePersonnel();
                return _instance;
            }
        }

        public uUpdatePersonnel()
        {
            InitializeComponent();
        }

        bool allowUpdate = false;

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (personnelid.selectedIndex != 0 && allowUpdate)
            {
                try
                {
                    if (given.Text.Trim().Length < 3 || assignid.Text.Trim().Length < 1 || lname.Text.Trim().Length < 3||
                        username.Text.Trim().Length < 8 || pass.Text.Trim().Length < 8)
                    {
                        MessageBox.Show("Please fill some fields.", "Error");
                    }
                    else if (confirmpass.Text != pass.Text)
                    {
                        MessageBox.Show("Mis-match password,Please try again!", "Error");
                    }
                    else
                    {
                        bool found = false;
                        SqlDataReader rd = SqlUtils.ExecuteQueryReader("select eventid from custom_event where eventid like " + assignid.Text ,false);
                        if (rd.HasRows)
                        {
                            found = true;
                        }

                        if (!found)
                            MessageBox.Show("There is no such event with id " + assignid.Text);
                        else
                        {
                            SqlUtils.ExecuteInsert("update personnel set eventid=@id,given_name=@given,last_name=@lname,username=@user,passwd=@pass where userid=@uid",new string[ ] {"@id","@given","@lname","@user","@pass","@uid"}, new string[] {assignid.Text,given.Text,lname.Text,username.Text,pass.Text,personnelid.selectedValue} );
                            MessageBox.Show("Information Updated Successfully!", "Success");
                            ResetAllFields();
                        }
                        
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (personnelid.selectedIndex == 0)
            {
                MessageBox.Show("Please Select a Personnel to proceed.", "Attention");
            }
            else
            {
                MessageBox.Show("Please Enable Editing Mode", "Attention");
            }
        }

        public void ResetAllFields()
        {
            assignid.Text = "";
            username.Text = "";
            pass.Text = "";
            given.Text = "";
            lname.Text = "";
            assignid.Text = "";
            confirmpass.Text = "";
            allowUpdate = false;
            linkLabel2.Text = "Enable Editing".ToUpper();
        }

        public void Initializer()
        {
            personnelid.Clear();
            personnelid.AddItem("Please select userid");
            personnelid.selectedIndex = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select userid from personnel", false);
            while (rd.Read())
            {
                personnelid.AddItem(rd.GetValue(0).ToString());
            }
        }

        private void personnelid_onItemSelected(object sender, EventArgs e)
        {
            if (personnelid.selectedIndex != 0)
            {
                SqlDataReader rd = SqlUtils.ExecuteQueryReader("select eventid,given_name,last_name,username,passwd from personnel where userid="+personnelid.selectedValue,false);
                while (rd.Read())
                {
                    assignid.Text = rd.GetValue(0).ToString();
                    given.Text = rd.GetValue(1).ToString();
                    lname.Text = rd.GetValue(2).ToString();
                    username.Text = rd.GetValue(3).ToString();
                    pass.Text = rd.GetValue(4).ToString();
                    confirmpass.Text = pass.Text;
                }
            }
        }

        private void passwordClicker_Click(object sender, EventArgs e)
        {
            if (pass.isPassword)
            {
                pass.isPassword = false;
                passwordClicker.Image = Properties.Resources.Invisible_32px;
            }
            else
            {
                pass.isPassword = true;
                passwordClicker.Image = Properties.Resources.Eye_32px;
            }
        }

        private void confirmClicker_Click(object sender, EventArgs e)
        {
            if (confirmpass.isPassword)
            {
                confirmpass.isPassword = false;
                confirmClicker.Image = Properties.Resources.Invisible_32px;
            }
            else
            {
                confirmpass.isPassword = true;
                confirmClicker.Image = Properties.Resources.Eye_32px;
            }
        }
        // edit mode
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var xsender = (LinkLabel) sender;
            if (xsender.Text.Equals("Enable Editing".ToUpper()))
            {
                xsender.Text = "Disable Editing".ToUpper();
                allowUpdate = true;
            }
            else
            {
                xsender.Text = "Enable Editing".ToUpper();
                allowUpdate = false;
            }

            assignid.Enabled = allowUpdate;
            given.Enabled = allowUpdate;
            lname.Enabled = allowUpdate;
            username.Enabled = allowUpdate;
            pass.Enabled = allowUpdate;
            confirmpass.Enabled = allowUpdate;
        }
    }
}
       

