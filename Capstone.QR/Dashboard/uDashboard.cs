using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Security.Principal;
using Capstone.QR.Tools;
using Capstone.QR.Events;

namespace Capstone.QR
{
    public partial class uDashboard : UserControl
    {
        private static uDashboard _instance;

        public static uDashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uDashboard();
                return _instance;
            }
            set { _instance = value; }
        }

        public uDashboard()
        {
            InitializeComponent();
        }        

        // Refresh Pending

        public void Initializer()
        {
            string query2 = "SELECT count(*) from custom_event where event_open=-1";
            SqlDataReader rd2 = SqlUtils.ExecuteQueryReader(query2, false);
            while (rd2.Read())
            {
                pendingEvents.Text = rd2.GetInt32(0).ToString();
            }
            string query1 = "SELECT count(*) from custom_event where event_open=0";
            SqlDataReader rd1 = SqlUtils.ExecuteQueryReader(query1, false);
            while (rd1.Read())
            {
                closeEvents.Text = rd1.GetInt32(0).ToString();
            }
            string query = "SELECT count(*) from custom_event where event_open=1";
            SqlDataReader rd = SqlUtils.ExecuteQueryReader(query, false);
            while (rd.Read())
            {
                openEvents.Text = rd.GetInt32(0).ToString();
            }
            int c = 0;
            var reader = SqlUtils.ExecuteQueryReader("select top 5 event_name,event_cost from custom_event where event_open=1 and event_cost != 0 order by event_cost desc", false);
            while (reader.Read())
            {
                c += 1;
                TopProfitedPie.Series["Profit"].Points.AddXY(reader["event_name"],reader["event_cost"]);
            }
            TopProfitedPie.Titles[0].Text = "Top " + c + " Most Profited Events";
            reader = SqlUtils.ExecuteQueryReader("select top 5 event_name,event_attended from custom_event where event_open=1 order by event_attended desc ", false);
            while (reader.Read())
            {
                AttendeeEventChart.Series["Attendees"].Points.AddXY(reader["event_name"],reader["event_attended"]);
            }
            reader.Close();
         
        }
        //open
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            viewEventsSummary(1);
        }
       
        public void viewEventsSummary(int code ) // Status Code for Status
        {
            displayPanel.Controls.Add(uViewEvent.Instance);
            uViewEvent.Instance.Dock = DockStyle.Fill;
            uViewEvent.Instance.Ctrl_Added(code);
            uViewEvent.Instance.BringToFront();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            viewEventsSummary(0);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            viewEventsSummary(-1);
        }
    }
}
