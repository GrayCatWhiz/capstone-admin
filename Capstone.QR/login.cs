using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
   
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = Uname.Text.Trim();
            string pass = Passwd.Text.Trim();
            try
            {
                if (user == "" || pass == "")
                {
                    MessageBox.Show("Please fill-up the following fields.", "Attention");
                }
                else if (SqlUtils.VerifyAccount(user,pass))
                {
                    var Panel = new AdminPanel();
                    Panel.Show();
                    Hide();
                    if (rememberBtn.Checked)
                    {
                        Windows.CreateSession(user, Cipher.Encrypt(pass, Cipher.secret));
                    }
                }
                else loginStatus.Text = "Invalid username or password!";
                
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void login_Activated(object sender, EventArgs e)
        {
            
            if (Windows.RememberUser())
            {
                new UserChecker().Show();
                Hide();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (rememberBtn.Checked == false)
            {
                rememberBtn.Checked = true;
            }
            else
            {
                rememberBtn.Checked = false;
            }
        }

        private void Passwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(btnLogin, EventArgs.Empty);
            }
        }
    }
}
