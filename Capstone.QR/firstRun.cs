using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class firstRun : Form
    {
        
        List<Color> colors = new List<Color>();
        int currentColor = 0;
        int a = 0;
        public firstRun()
        {
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(112, 191, 83));
            colors.Add(Color.FromArgb(126, 155, 40));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(235, 83, 104));
            colors.Add(Color.FromArgb(223, 128, 255));
            colors.Add(Color.FromArgb(112, 48, 160));
            colors.Add(Color.FromArgb(107, 122, 187));
            colors.Add(Color.FromArgb(95, 136, 176));
            colors.Add(Color.FromArgb(70, 175, 227));
            colors.Add(Color.FromArgb(0, 158, 71));
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (currentColor < colors.Count - 1)
            {
                this.BackColor = Bunifu.Framework.UI.BunifuColorTransition.getColorScale(a, colors[currentColor], colors[currentColor + 1]);
                if (currentColor == 2)
                {
                    notifier.Text = "Checking Machine Compatibility...";
                    if (Windows.IsServerInstalled() == false)
                    {
                        MessageBox.Show("Microsoft SQL Server Management Studio must be installed!", "Exiting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                    }
                    
                }
                else if (currentColor == 5)
                {
                    Windows.ConfigureDirectory();
                    notifier.Text = "Creating Local Directory...";
                }
                else if (currentColor == 8)
                {
                    if (SqlUtils.IsDatabaseExist() == false)
                        SqlUtils.CreateDatabase();
                    
                    //MessageBox.Show(SqlUtils.IsTableExist("auth").ToString());
                    if (SqlUtils.IsTableExist("auth") == false)
                    {
                        String query = "CREATE TABLE auth (uname varchar(25), passwd nvarchar(4000))"; // For admin login table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table custom_event (eventid int primary key not null identity,event_name varchar(400),event_location varchar(500),event_stime time,event_date date,event_cost money,event_open int,event_registered int,event_attended int)"; // For Event table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "CREATE TABLE personnel (userid int primary key not null identity,eventid int,given_name varchar(100),last_name varchar(100),username varchar(80) unique,passwd nvarchar(4000),constraint fk_personnelEvent foreign key (eventid) references custom_event(eventid))"; // For personel table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table college (college_code varchar(100) primary key,college_desc varchar(400))"; // College Table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table attendee (attendee_id int identity,attendee_fullname varchar(250),attendee_yrsec varchar(200),college_code varchar(100),eventid int,attendee_present int,primary key(attendee_id),constraint fk_attendeeCollege foreign key (college_code) references college(college_code),constraint fk_attendanceEvent foreign key (eventid)references custom_event(eventid))"; // Attendee Table
                        SqlUtils.ExecuteQuery(query, false);

                        SqlUtils.CreateAdminAccount();
                    }
                    notifier.Text = "Creating Databases...";

                }
                else if (currentColor == 9)
                    notifier.Text = "Finishing...";

                if (a < 100)
                    a++;
                else
                {
                    a = 0;
                    currentColor++;
                }
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                login adminLogin = new login();
                this.Hide();
                adminLogin.Show();
            }
        }

        private void firstRun_Activated(object sender, EventArgs e)
        {
            if (SqlUtils.IsDatabaseExist())
            {
                timer1.Enabled = false;
                this.Hide();
                login adminLogin = new login();
                adminLogin.Show();
            }
        }
    }
}
