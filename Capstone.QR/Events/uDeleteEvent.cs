using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR.Events
{
    public partial class uDeleteEvent : UserControl
    {
        private static Bunifu.Framework.UI.BunifuDropdown eventid;
        public uDeleteEvent()
        {
            Init();
            InitializeComponent();
        }
        private static uDeleteEvent _instance;
        public static uDeleteEvent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uDeleteEvent();
                return _instance;
            }
        }

        
        public static void setID(List<int> n)
        {
            eventid.Clear();
            eventid.AddItem("Select Event ID");
            eventid.selectedIndex = 0;
            foreach (int y in n)
            {
                
                eventid.AddItem(y.ToString());
            }
            
        }

        private void Init()
        {
            eventid = new Bunifu.Framework.UI.BunifuDropdown();
            eventid.BackColor = System.Drawing.Color.Transparent;
            eventid.BorderRadius = 3;
            eventid.DisabledColor = System.Drawing.Color.Gray;
            eventid.ForeColor = System.Drawing.Color.White;
            eventid.Items = new string[0];
            eventid.Location = new System.Drawing.Point(170, 92);
            eventid.Name = "eventid";
            eventid.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(27)))), ((int)(((byte)(154)))));
            eventid.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(27)))), ((int)(((byte)(154)))));
            eventid.selectedIndex = -1;
            eventid.Size = new System.Drawing.Size(508, 35);
            eventid.TabIndex = 50;
            eventid.onItemSelected += new System.EventHandler(eventid_onItemSelected);
            Controls.Add(eventid);
        }
        private void eventid_onItemSelected(object sender, EventArgs e)
        {
            if (eventid.selectedIndex != 0)
            {
                string id = eventid.selectedValue;
                
                SqlDataReader rd = SqlUtils.ExecuteQueryReader("select event_name,event_location,event_cost,event_date,event_stime from custom_event where eventid=" + id, false);
                while (rd.Read())
                {
                    txtEventName.Text = rd.GetValue(0).ToString();
                    txtEventLocation.Text = rd.GetValue(1).ToString();
                    var y = rd.GetValue(2);
                    int x = Convert.ToInt32(y);

                    if (x <= 0)
                    {
                        txtAmount.Visible = false;
                        freeSwitch.Value = true;
                    }
                    else
                    {
                        txtAmount.Visible = true;
                        txtAmount.Text = x.ToString();
                        freeSwitch.Value = false;
                    }

                    eventDate.Value = (DateTime)rd.GetValue(3);
                    TimeSpan j = (TimeSpan)rd.GetValue(4);
                    string time;
                    if (j.Hours > 12)
                    {
                        int z = j.Hours - 12;
                        time = z + "AM";
                    }
                    else
                    {
                        time = j.Hours + "PM";
                    }

                    txtEventTime.Text = time;
                }


            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (eventid.selectedIndex != 0)
            {
                var res = MessageBox.Show("Are you sure you want to remove it from events?", "Attention",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (res.Equals(DialogResult.Yes))
                {
                    SqlUtils.ExecuteQuery("delete from custom_event where eventid=" + eventid.selectedValue, false);
                    eventid.RemoveAt(eventid.selectedIndex);
                }
            }

        }
    }
}
