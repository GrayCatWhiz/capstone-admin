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
using Capstone.QR;
using Capstone.QR.Tools;
using Capstone.QR.Events;

namespace Capstone.QR
{
    public partial class EventWinLoader : UserControl
    {

        public EventWinLoader()
        {
            InitializeComponent();
        }

        public static EventWinLoader _instance;

        public static EventWinLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventWinLoader();
                }
                return _instance;
            }
        }
        // Add Event
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(uAddEvent.Instance))
            {
                this.Controls.Add(uAddEvent.Instance);
                uAddEvent.Instance.Dock = DockStyle.Fill;
                uAddEvent.Instance.BringToFront();
            }
            else
            {
                uAddEvent.Instance.BringToFront();
            }
        }
        // Update Event
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(uUpdateEvent.Instance))
            {
                int EventCount = 0;
                SqlDataReader reader = SqlUtils.ExecuteQueryReader("select count(*) from custom_event", false);
                while (reader.Read())
                {
                    EventCount = reader.GetInt32(0);
                }
                if (EventCount <= 0)
                {
                    MessageBox.Show("To continue, Please add an event","Alert");
                }
                else
                {
                    List<int> arr = new List<int>();
                    SqlDataReader rd = SqlUtils.ExecuteQueryReader("select eventid from custom_event",false);
                    while (rd.Read())
                    {
                        arr.Add(rd.GetInt32(0));
                    }
                    uUpdateEvent.Init(arr);
                    this.Controls.Add(uUpdateEvent.Instance);
                    uUpdateEvent.Instance.Dock = DockStyle.Fill;
                    uUpdateEvent.Instance.BringToFront();
                }
                
            }
            else
            {
                uUpdateEvent.Instance.BringToFront();
            }
        }
        // Delete Event
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(uDeleteEvent.Instance))
            {
                int EventCount = 0;
                SqlDataReader reader = SqlUtils.ExecuteQueryReader("select count(*) from custom_event", false);
                while (reader.Read())
                {
                    EventCount = reader.GetInt32(0);
                }
                if (EventCount <= 0)
                {
                    MessageBox.Show("To continue, Please add an event", "Alert");
                }
                else
                {
                    List<int> arr = new List<int>();
                    SqlDataReader rd = SqlUtils.ExecuteQueryReader("select eventid from custom_event", false);
                    while (rd.Read())
                    {
                        arr.Add(rd.GetInt32(0));
                    }
                    uDeleteEvent.setID(arr);
                    this.Controls.Add(uDeleteEvent.Instance);
                    uDeleteEvent.Instance.Dock = DockStyle.Fill;
                    uDeleteEvent.Instance.BringToFront();
                }
            }
            else
            {
                uDeleteEvent.Instance.BringToFront();
            }
        }
        // View All Events
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(uViewEvent.Instance))
            {
                int EventCount = 0;
                SqlDataReader reader = SqlUtils.ExecuteQueryReader("select count(*) from custom_event", false);
                while (reader.Read())
                {
                    EventCount = reader.GetInt32(0);
                }
                if (EventCount <= 0)
                {
                    MessageBox.Show("To continue, Please add an event", "Alert");
                }
                else
                {
                    this.Controls.Add(uViewEvent.Instance);
                    uViewEvent.Instance.Dock = DockStyle.Fill;
                    uViewEvent.Instance.Ctrl_Added(99);
                    uViewEvent.Instance.BringToFront();
                }
            }
            else
            {
                uViewEvent.Instance.BringToFront();
            }
        }
    }
}
