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
    public partial class PersonnelWinLoader : UserControl
    {
        public PersonnelWinLoader()
        {
            InitializeComponent();
        }

        private static PersonnelWinLoader _instance = null;

        public static PersonnelWinLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersonnelWinLoader();
                }

                return _instance;
            }
            set { _instance = value; }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            int eventCount = 0;
            var reader = SqlUtils.ExecuteQueryReader("select count(*) as open_event from custom_event where event_open=1", false);
            while (reader.Read())
            {
                eventCount = (int) reader["open_event"];
            }
            if(eventCount <= 0)
                MessageBox.Show("Sorry, you must open at least 1 event to start adding personel");
            else
            {
                Controls.Add(uAddPersonnel.Instance);
                uAddPersonnel.Instance.Dock = DockStyle.Fill;
                uAddPersonnel.Instance.InitEvent();
                uAddPersonnel.Instance.BringToFront();
            }
            
            
            
        }
        //view
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select count(*) from personnel",false);
            while (rd.Read())
            {
                count = (Int32)rd.GetValue(0);
            }

            if (count <= 0)
            {
                MessageBox.Show("To proceed, please add a personnel.");
            }
            else
            {
                // Display Panel
                Controls.Add(uViewPersonnel.Instance);
                uViewPersonnel.Instance.Dock = DockStyle.Fill;
                uViewPersonnel.Instance.InitializeView();
                uViewPersonnel.Instance.BringToFront();
            }
        }
        //update
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select count(*) from personnel", false);
            while (rd.Read())
            {
                count = (Int32)rd.GetValue(0);
            }

            if (count <= 0)
            {
                MessageBox.Show("To proceed, please add a personnel.");
            }
            else
            {
                Controls.Add(uUpdatePersonnel.Instance);
                uUpdatePersonnel.Instance.Dock = DockStyle.Fill;
                uUpdatePersonnel.Instance.Initializer();
                uUpdatePersonnel.Instance.BringToFront();
            }
        }
        // remove
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select count(*) from personnel", false);
            while (rd.Read())
            {
                count = (Int32)rd.GetValue(0);
            }

            if (count <= 0)
            {
                MessageBox.Show("To proceed, please add a personnel.");
            }
            else
            {
                Controls.Add(uRemovePerson.Instance);
                uRemovePerson.Instance.Dock = DockStyle.Fill;
                uRemovePerson.Instance.Initializer();
                uRemovePerson.Instance.BringToFront();
            }
        }
    }
}
