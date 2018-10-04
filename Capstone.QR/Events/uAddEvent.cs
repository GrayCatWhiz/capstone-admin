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
    public partial class uAddEvent : UserControl
    {
        private static uAddEvent _instance;
        public static uAddEvent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uAddEvent();
                return _instance;
            }
        }

        public uAddEvent()
        {
            InitializeComponent();
        }

        private void freeSwitch_OnValueChange(object sender, EventArgs e)
        {
            var lblAmount = Amount;

            if (freeSwitch.Value == false)
            {
                txtAmount.Visible = true;
                lblAmount.Visible = true;
            }
            else
            {
                txtAmount.Visible = false;
                lblAmount.Visible = false;
            }
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string eventAmount = freeSwitch.Value == false ? txtAmount.Text.Trim() : "0";
                string eventName = txtEventName.Text.Trim().Length > 8 && txtEventName.Text.Trim().Length < 25 ? txtEventName.Text.Trim() : null;
                string eventLoc = txtEventLocation.Text.Trim().Length > 10 && txtEventLocation.Text.Trim().Length < 25 ? txtEventLocation.Text.Trim() : null;
                string eventTime = txtEventTime.Text.Trim().Length >= 1 ? txtEventTime.Text.Trim() : null;
                string ceventDate = eventDate.Value.ToString() != "" ? eventDate.Value.ToString() : null;
                string eventOpen = "-1";

                string caption = "Attention";
                if (eventName == null)
                {
                    MessageBox.Show("Event Name must be consist of 8 characters and less than 25", caption);
                }
                else if (eventLoc == null)
                {
                    MessageBox.Show("Event Location must be atleast 10 characters and less than 25", caption);
                }
                else if (eventTime == null)
                {
                    MessageBox.Show("Kindly enter a valid time for event's Time", caption);
                }
                else if (eventDate.Value.CompareTo(DateTime.Now) == -1)
                {
                    MessageBox.Show("Kindly enter for event's Date", caption);
                }
                else
                {
                    string query = "insert into custom_event(event_name,event_location,event_stime,event_date,event_cost,event_open,event_registered,event_attended) values(@name,@loc,@time,@date,@cost,@open,@registered,@attended)";
                    SqlUtils.ExecuteInsert(query, new string[] { "@name", "@loc", "@time", "@date", "@cost", "@open", "registered", "@attended" }, new string[] { eventName, eventLoc, eventTime, ceventDate, eventAmount, eventOpen, "0", "0" });
                    MessageBox.Show("New Event Added Successfully");


                    freeSwitch.Value = true;
                    freeSwitch_OnValueChange(bunifuFlatButton1, EventArgs.Empty);
                    txtAmount.Text = "";
                    txtEventLocation.Text = "";
                    txtEventName.Text = "";
                    txtEventTime.Text = "";

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
