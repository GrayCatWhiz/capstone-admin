using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class UserChecker : Form
    {
        public UserChecker()
        {
            InitializeComponent();
        }

        private void VerifyBtn_Click(object sender, EventArgs e)
        {
            // if valid
            //var Panel = new AdminPanel();
            //Panel.Show();
            //Hide();
            if (SqlUtils.VerifyAccount("admin",PasswordVerify.Text.Trim()))
            {
                new AdminPanel().Show();
                Hide();
            }
            else MessageBox.Show("Wrong Credential!");
        }
    }
}
