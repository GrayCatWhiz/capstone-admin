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
    public partial class uUpdateEvent : UserControl
    {
        private static uUpdateEvent _instance;
        public static uUpdateEvent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uUpdateEvent();
                return _instance;
            }
        }



        // QR.Capstone Changelogs:
        // Bugs :
        // July 19, 2018 8:42 PM
        // Please fix time date from sql server to native vsStudio proper data type :D
        //
        // July 14, 2018 - Capstone Update Logs Created
        // July 15, 2018 - Custom Encrypter/Decrypter ✓
        // Fix username duplication in Personnel ✓
        // Finished: Add Event/Personnel ✓
        // July 17 2018,
        // - Fixed Add, Update, Delete Issues ✓

        // Pending : 
        // Admin Approval for Registratration
        // Restore / Backup Database
        // Viewable records via Dashboard (uDashboard Control)
        // JSON Configuration file export
        private static Bunifu.Framework.UI.BunifuDropdown eventid;
            

        public uUpdateEvent()
        {

            Init_Selector();
            InitializeComponent();
        }

        public static void Init(List<int> x)
        {
            // This shit is reset :D
            eventid.Clear();
            eventid.AddItem("Select Event ID");
            eventid.selectedIndex = 0;
            foreach (int y in x)
            {
                eventid.AddItem(y.ToString());
            }
        }

        private void eventid_onItemSelected(object sender, EventArgs e)
        {
            if (eventid.selectedIndex != 0)
            {
                string id = eventid.selectedValue;
                SqlDataReader rd = SqlUtils.ExecuteQueryReader("select event_name,event_location,event_cost,event_date,event_stime from custom_event where eventid="+id,false);
                while (rd.Read())
                {
                    txtEventName.Text = rd.GetValue(0).ToString();
                    txtEventLocation.Text = rd.GetValue(1).ToString();
                    var y = rd.GetValue(2);
                    int x= Convert.ToInt32(y);
                    
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

                    string time = "";
                    eventDate.Value = (DateTime)rd.GetValue(3);
                    TimeSpan j = (TimeSpan) rd.GetValue(4);
                    if (j.Hours > 12)
                    {
                        int z = j.Hours - 12;
                        time= z + "PM";
                    }
                    else
                    {
                        time = j.Hours + "AM";
                    }

                    txtEventTime.Text = time;
                }


            }
        }

        private void Init_Selector()
        {
            eventid = new Bunifu.Framework.UI.BunifuDropdown();
            eventid.BackColor = System.Drawing.Color.Transparent;
            eventid.BorderRadius = 3;
            eventid.DisabledColor = System.Drawing.Color.Gray;
            eventid.ForeColor = System.Drawing.Color.White;
            eventid.Items = new string[] {
                "Select Event ID"};
            eventid.Location = new System.Drawing.Point(182, 110);
            eventid.Name = "eventid";
            eventid.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(27)))), ((int)(((byte)(154)))));
            eventid.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(27)))), ((int)(((byte)(154)))));
            eventid.selectedIndex = 0;
            eventid.Size = new System.Drawing.Size(508, 41);
            eventid.TabIndex = 31;
            eventid.onItemSelected += new System.EventHandler(this.eventid_onItemSelected);
            Controls.Add(eventid);
        }
        bool flag;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (linkLabel1.Text == "Enable Editing".ToUpper())
            {
                linkLabel1.Text = "Disable Editing".ToUpper();
                flag = true;
            }
            else
            {
                linkLabel1.Text = "Enable Editing".ToUpper();
                flag = false;
            }
            freeSwitch.Enabled = flag;
            txtAmount.Enabled = flag;
            txtEventLocation.Enabled = flag;
            txtEventTime.Enabled = flag;
            txtEventName.Enabled = flag;
            eventDate.Enabled = flag;
        }
        // Update Personnel Information
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (eventid.selectedIndex == 0)
                MessageBox.Show("Please select a valid Event");
            else
            {
                if (txtAmount.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a valid event cost.");
                }
                else if (txtEventName.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Please enter a valid event name.");
                }
                else if (txtEventLocation.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Please enter a valid event location.");
                }
                else if (txtEventTime.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Please enter a valid event time.");
                }
                else if (eventDate.Value.CompareTo(DateTime.Now) == -1)
                {
                    MessageBox.Show("Please enter a valid event date.");
                }
                else
                {
                    string query = "UPDATE custom_event set event_name=@name,event_location=@location,event_date=@date,event_stime=@time,event_cost=@cost where eventid=@id";
                    SqlUtils.ExecuteInsert(query, new string[] { "@name", "@location", "@date", "@time", "@cost", "@id" }, new string[] { txtEventName.Text.Trim(), txtEventLocation.Text.Trim(), eventDate.Value.ToString().Trim(), txtEventTime.Text.Trim(), txtAmount.Text.Trim(), eventid.selectedValue.Trim() });
                    MessageBox.Show("Information Update Successfully.", "Success");
                }
            }
        }
    }
}
