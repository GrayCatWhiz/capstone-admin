using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class uAddPersonnel : UserControl
    {
        private static uAddPersonnel _instance;
        public static uAddPersonnel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uAddPersonnel();
                return _instance;
            }
        }

        public uAddPersonnel()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string givenn, lname, username, pass, confirmpass;
            givenn = givennametb.Text.Trim();
            lname = lnametb.Text.Trim();
            username = unametb.Text.Trim();
            pass = passtb.Text.Trim();
            confirmpass = confirmtb.Text.Trim();

            if (String.IsNullOrEmpty(givenn) || String.IsNullOrEmpty(lname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(pass) || String.IsNullOrEmpty(confirmpass))
            {
                MessageBox.Show("Fields are empty!");
            }
            else if (givenn.Length < 2 || lname.Length < 2 || username.Length < 8 || pass.Length < 8 || confirmpass.Length < 8)
            {
                const string caption = "Attention";
                if (givenn.Length < 2)
                {
                    MessageBox.Show("Given name must be atleast 2 characters",caption);
                }
                else if (lname.Length < 2)
                {
                    MessageBox.Show("Last name must be atleast 2 characters", caption);
                }
                else if (username.Length < 8)
                {
                    MessageBox.Show("Username must be atleast 8 characters", caption);
                }
                else if (pass.Length < 8 || confirmpass.Length < 8)
                {
                    MessageBox.Show("Password/Confirm Password must be atleast 8 characters", caption);
                }

            }
            else
            {
                if (pass != confirmpass)
                {
                    MessageBox.Show("Password do not match!");
                }
                else
                {
                    try
                    {
                        if (eventid.selectedIndex == 0)
                        {
                            MessageBox.Show("Please select a valid event id","Attention");
                        }
                        else
                        {
                            SqlUtils.ExecuteInsert("insert into personnel (eventid,given_name,last_name,username,passwd) values(@id,@gname,@lname,@user,@pass)",new string[] {"@id","@gname","@lname","@user","@pass"},new string [] {eventid.selectedValue,givenn,lname,username,pass} );

                            MessageBox.Show("New Personnel Added!", "Success");

                            givennametb.Text = "";
                            lnametb.Text = "";
                            unametb.Text = "";
                            passtb.Text = "";
                            confirmtb.Text = "";
                            givennametb.Focus();
                        }
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Username is Already Exists!","Error");
                    }
                    


                }
            }         
        }

        private void eventid_onItemSelected(object sender, EventArgs e)
        {
            if (eventid.selectedIndex != 0)
            {
                SqlDataReader rd = SqlUtils.ExecuteQueryReader("select event_name from custom_event where eventid="+ eventid.selectedValue,false);
                while (rd.Read())
                {
                    eventName.Text = rd.GetValue(0).ToString();
                }
            }
        }

        public void InitEvent()
        {
            eventid.Clear();
            eventid.AddItem("Please select an Event");
            eventid.selectedIndex = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select eventid from custom_event where event_open=1",false);
            while (rd.Read())
            {
                eventid.AddItem(rd.GetValue(0).ToString());
            }
            
        }
    }
}