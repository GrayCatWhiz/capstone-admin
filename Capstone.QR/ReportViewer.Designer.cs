namespace Capstone.QR
{
    partial class ReportViewer
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
            this.ReportView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.GetRpt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReportView
            // 
            this.ReportView.ActiveViewIndex = -1;
            this.ReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportView.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ReportView.Location = new System.Drawing.Point(0, 35);
            this.ReportView.Name = "ReportView";
            this.ReportView.Size = new System.Drawing.Size(926, 470);
            this.ReportView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export as PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetRpt
            // 
            this.GetRpt.Location = new System.Drawing.Point(12, 6);
            this.GetRpt.Name = "GetRpt";
            this.GetRpt.Size = new System.Drawing.Size(121, 23);
            this.GetRpt.TabIndex = 2;
            this.GetRpt.Text = "Load Report File";
            this.GetRpt.UseVisualStyleBackColor = true;
            this.GetRpt.Click += new System.EventHandler(this.GetRpt_Click);
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 505);
            this.Controls.Add(this.GetRpt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ReportView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReportViewer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button GetRpt;
    }
}