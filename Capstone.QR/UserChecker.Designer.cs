namespace Capstone.QR
{
    partial class UserChecker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PasswordVerify = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.VerifyBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordVerify
            // 
            this.PasswordVerify.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.PasswordVerify.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordVerify.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.PasswordVerify.BorderThickness = 3;
            this.PasswordVerify.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.PasswordVerify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordVerify.isPassword = true;
            this.PasswordVerify.Location = new System.Drawing.Point(13, 32);
            this.PasswordVerify.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordVerify.Name = "PasswordVerify";
            this.PasswordVerify.Size = new System.Drawing.Size(259, 39);
            this.PasswordVerify.TabIndex = 0;
            this.PasswordVerify.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VerifyBtn
            // 
            this.VerifyBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.VerifyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.VerifyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VerifyBtn.BorderRadius = 0;
            this.VerifyBtn.ButtonText = "CONTINUE";
            this.VerifyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VerifyBtn.DisabledColor = System.Drawing.Color.Gray;
            this.VerifyBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.VerifyBtn.Iconimage = null;
            this.VerifyBtn.Iconimage_right = null;
            this.VerifyBtn.Iconimage_right_Selected = null;
            this.VerifyBtn.Iconimage_Selected = null;
            this.VerifyBtn.IconMarginLeft = 0;
            this.VerifyBtn.IconMarginRight = 0;
            this.VerifyBtn.IconRightVisible = true;
            this.VerifyBtn.IconRightZoom = 0D;
            this.VerifyBtn.IconVisible = true;
            this.VerifyBtn.IconZoom = 90D;
            this.VerifyBtn.IsTab = false;
            this.VerifyBtn.Location = new System.Drawing.Point(279, 35);
            this.VerifyBtn.Name = "VerifyBtn";
            this.VerifyBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.VerifyBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.VerifyBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.VerifyBtn.selected = false;
            this.VerifyBtn.Size = new System.Drawing.Size(127, 36);
            this.VerifyBtn.TabIndex = 1;
            this.VerifyBtn.Text = "CONTINUE";
            this.VerifyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VerifyBtn.Textcolor = System.Drawing.Color.White;
            this.VerifyBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyBtn.Click += new System.EventHandler(this.VerifyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(48, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter your recently entered administrative password";
            // 
            // UserChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 77);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VerifyBtn);
            this.Controls.Add(this.PasswordVerify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserChecker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check User Validity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMetroTextbox PasswordVerify;
        private Bunifu.Framework.UI.BunifuFlatButton VerifyBtn;
        private System.Windows.Forms.Label label1;
    }
}