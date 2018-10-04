using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR.Personnel
{
    public partial class uRemovePerson : UserControl
    {
        private static uRemovePerson _instance;

        public static uRemovePerson Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uRemovePerson();
                return _instance;
            }
        }
        public uRemovePerson()
        {
            InitializeComponent();
        }

        private void personnelid_onItemSelected(object sender, EventArgs e)
        {
            if (personnelid.selectedIndex != 0)
            {
                SqlDataReader rd = SqlUtils.ExecuteQueryReader("select eventid,given_name,last_name,username,passwd from personnel where userid=" + personnelid.selectedValue, false);
                while (rd.Read())
                {
                    assignid.Text = rd.GetValue(0).ToString();
                    given.Text = rd.GetValue(1).ToString();
                    lname.Text = rd.GetValue(2).ToString();
                    username.Text = rd.GetValue(3).ToString();
                    pass.Text = rd.GetValue(4).ToString();
                }
            }
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (personnelid.selectedIndex == 0)
                MessageBox.Show("Please select a valid personnel id");
            else
            {
                DialogResult yesno = MessageBox.Show("Are you sure you want remove this personnel?", "Alert",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (yesno.Equals(DialogResult.Yes))
                {
                    SqlUtils.ExecuteQuery("delete from personnel where userid=" + personnelid.selectedValue, false);
                    personnelid.RemoveAt(personnelid.selectedIndex);
                    MessageBox.Show("Remove Success", "Success");
                }
                
            }
        }
    }
}
