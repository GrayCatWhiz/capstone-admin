using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone.QR
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClosePrompt();
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (sidePanel.Width == 55)
            {
                sidePanel.Visible = false;
                sidePanel.Width = 255;
                panelAnimator.ShowSync(sidePanel);
                logoAnimator.ShowSync(logo);
            }
            else
            {
                logoAnimator.Hide(logo);
                sidePanel.Visible = false;
                sidePanel.Width = 55;
                panelAnimator.ShowSync(sidePanel);
            }
        }


        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            

                if (personnelPanel.Height == 140)
                {
                    
                    personnelPanel.Visible = false;
                    personnelPanel.Height = 46;
                    PersonnelAnimator.ShowSync(personnelPanel);
                }
                else
                {
                   
                    personnelPanel.Hide();
                    personnelPanel.Height = 140;
                    PersonnelAnimator.ShowSync(personnelPanel);
                }
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (eventPanel.Height == 140)
            {
                eventPanel.Visible = false;
                eventPanel.Height = 46;
                eventAnimator.ShowSync(eventPanel);
            }
            else
            {
             
                eventPanel.Hide();
                eventPanel.Height = 140;
                eventAnimator.Show(eventPanel);
            }
            
        }

       

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            dashSelected();
        }

        private void dashSelected()
        {
            if (!displayPanel.Controls.Contains(uDashboard.Instance))
            {
                int close = 0;
                int open = 0;
                int pending = 0;

                utils SqlUtils = new utils();
                SqlConnection conn = SqlUtils.connectSQL();
                conn.Open();
                string query = "SELECT event_open FROM custom_event";
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == -1)
                    {
                        pending += 1;
                    }
                    else if (reader.GetInt32(0) == 1)
                    {
                        open += 1;
                    }
                    else
                    {
                        close += 1;
                    }
                }
                displayPanel.Controls.Add(uDashboard.Instance);
               
                uDashboard.Instance.Dock = DockStyle.Fill;
                uDashboard.Instance.BringToFront();
            }
            else
            {
                uDashboard.Instance.BringToFront();
            }
        }

        


        public void ClosePrompt()
        {
            var quit = MessageBox.Show("Are you sure you want to quit? This will logged out current session.", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (DialogResult.OK == quit)
            {
                utils netcookie = new utils();
                netcookie.DeleteSession();
                Application.Exit();
                this.Dispose();
            }
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            if (bunifuFlatButton1.selected)
            {
                dashSelected();
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (!displayPanel.Controls.Contains(uAddEvent.Instance))
            {
                displayPanel.Controls.Add(uAddEvent.Instance);
                uAddEvent.Instance.Dock = DockStyle.Fill;
                uAddEvent.Instance.BringToFront();
            }
            else
            {
                uAddEvent.Instance.BringToFront();
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            utils sqlUtils = new utils();
            SqlConnection conn = sqlUtils.connectSQL();
            conn.Open();
            string query = "select eventid,event_name from custom_event";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if (!rd.HasRows)
            {
                MessageBox.Show("Nothing to update please add event first", "Attention");
            }
            else
            {
                if (!displayPanel.Controls.Contains(uUpdateEvent.Instance))
                {
                    displayPanel.Controls.Add(uUpdateEvent.Instance);
                    uUpdateEvent.Instance.Dock = DockStyle.Fill;
                    uUpdateEvent.Instance.BringToFront();
                }
                else
                {
                    uUpdateEvent.Instance.BringToFront();
                }
            }
            conn.Close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            utils sqlUtils = new utils();
            SqlConnection conn = sqlUtils.connectSQL();
            conn.Open();
            string query = "select eventid,event_name from custom_event";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if (!rd.HasRows)
            {
                MessageBox.Show("Please add an event first before adding personnel", "Attention");
            }
            else
            {
                if (!displayPanel.Controls.Contains(uAddPersonnel.Instance))
                {
                    displayPanel.Controls.Add(uAddPersonnel.Instance);
                    uAddPersonnel.Instance.Dock = DockStyle.Fill;
                    uAddPersonnel.Instance.BringToFront();
                }
                else
                {
                    uAddPersonnel.Instance.BringToFront();
                }
            }
            conn.Close();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            utils sqlUtils = new utils();
            SqlConnection conn = sqlUtils.connectSQL();
            conn.Open();
            string query = "select userid from personnel";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if (!rd.HasRows)
            {
                MessageBox.Show("Please add a personnel first before updating infos.", "Attention");
            }
            else
            {
                if (!displayPanel.Controls.Contains(uUpdatePersonnel.Instance))
                {
                    displayPanel.Controls.Add(uUpdatePersonnel.Instance);
                    uUpdatePersonnel.Instance.Dock = DockStyle.Fill;
                    uUpdatePersonnel.Instance.BringToFront();
                }
                else
                {
                    uUpdatePersonnel.Instance.BringToFront();
                }
            }
            conn.Close();
        }
        
    }
}
