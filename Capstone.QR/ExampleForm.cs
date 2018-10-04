using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Personnel;
using Capstone.QR.Tools;
using Capstone.QR.Attendee;
using Capstone.QR.Dashboard;

namespace Capstone.QR
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            this.Load += Form_Load;
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dashBtn.selected = true;
            Load_Dashboard();
        }

            //passForm = new FormChangePassword();
            //passForm.StartPosition = FormStartPosition.CenterScreen;
            //passForm.Show();
      


            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.OverwritePrompt = true;
            //sfd.FileName = "config";
            //sfd.DefaultExt = "json";
            //sfd.Filter = "Configuration File (*.json) | All Files (*.*)";
            //sfd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "configs");
            //var opt = sfd.ShowDialog();
            //if (opt.Equals(DialogResult.OK))
            //{
            //    using (StreamWriter sw = new StreamWriter(Path.Combine(sfd.InitialDirectory,sfd.FileName),false))
            //    {
            //        sw.WriteLine("{\"ServerName\"}");
            //    }

            //}


        private void dashBtn_Click(object sender, EventArgs e)
        {
           Load_Dashboard();
        }

        private void EventBtn_Click(object sender, EventArgs e)
        {
            navigation.Text = "Events";
            EventWinLoader._instance = null;
            if (!MainPanel.Controls.Contains(EventWinLoader.Instance))
            {
                MainPanel.Controls.Add(EventWinLoader.Instance);
                EventWinLoader.Instance.Dock = DockStyle.Fill;
                EventWinLoader.Instance.BringToFront();
            }
            else
            {
                EventWinLoader.Instance.BringToFront();
            }
        }

        private void PersonnelBtn_Click(object sender, EventArgs e)
        {
            navigation.Text = "Personnel";
            PersonnelWinLoader.Instance = null;
            if (!MainPanel.Controls.Contains(PersonnelWinLoader.Instance))
            {
                MainPanel.Controls.Add(PersonnelWinLoader.Instance);
                PersonnelWinLoader.Instance.Dock = DockStyle.None;
                PersonnelWinLoader.Instance.BringToFront();
            }
            else
            {
                PersonnelWinLoader.Instance.BringToFront();
            }
           
        }

        private void AttendeeBtn_Click(object sender, EventArgs e)
        {
            navigation.Text = "Attendee";
            var attendviewer = new AttendViewer();
            MainPanel.Controls.Add(attendviewer);
            attendviewer.Dock = DockStyle.None;
            attendviewer.InitFilters();
            attendviewer.AttendeeViewController();
            attendviewer.BringToFront();
        }

        private void Load_Dashboard()
        {
            navigation.Text = "Dashboard";
            
            MainPanel.Controls.Add(uDashboard.Instance);
            uDashboard.Instance.Dock = DockStyle.None;
            uDashboard.Instance.Initializer();
            uDashboard.Instance.BringToFront();
            uDashboard.Instance = null;

        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            navigation.Text = "Profile";

            MainPanel.Controls.Add(uAdminProfile.Instance);
            uAdminProfile.Instance.Dock = DockStyle.None;
            uAdminProfile.Instance.BringToFront();
            uAdminProfile.Instance = null;
        }

 

        private void ExitBtn_Click(object sender, EventArgs e)
        {

            var action = MessageBox.Show("Are you sure you want to logout?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (action.Equals(DialogResult.Yes))
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "/session/user.session"))
                {
                    DialogResult response = MessageBox.Show("Do you want to reserved your session?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (response == DialogResult.No)
                    {
                        Windows.RemoveSession();
                        Dispose();
                        Application.Exit();
                    }
                    Dispose();
                    Application.Exit();
                }
                else
                {
                    Dispose();
                    Application.Exit();
                }
            }
        }
    }
}
