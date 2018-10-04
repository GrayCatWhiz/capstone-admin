namespace Capstone.QR.Attendee
{
    partial class AttendViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ADataGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.AttendeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollegeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Present = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.Filter = new System.Windows.Forms.ComboBox();
            this.Keyword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ADataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ADataGrid
            // 
            this.ADataGrid.AllowUserToAddRows = false;
            this.ADataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ADataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ADataGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.ADataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ADataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ADataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttendeeId,
            this.Fullname,
            this.YearSection,
            this.CollegeCode,
            this.EventName,
            this.Present});
            this.ADataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ADataGrid.DoubleBuffered = true;
            this.ADataGrid.EnableHeadersVisualStyles = false;
            this.ADataGrid.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.ADataGrid.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ADataGrid.Location = new System.Drawing.Point(0, 46);
            this.ADataGrid.Name = "ADataGrid";
            this.ADataGrid.ReadOnly = true;
            this.ADataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ADataGrid.Size = new System.Drawing.Size(748, 450);
            this.ADataGrid.TabIndex = 0;
            // 
            // AttendeeId
            // 
            this.AttendeeId.HeaderText = "#";
            this.AttendeeId.Name = "AttendeeId";
            this.AttendeeId.ReadOnly = true;
            // 
            // Fullname
            // 
            this.Fullname.HeaderText = "Fullname";
            this.Fullname.Name = "Fullname";
            this.Fullname.ReadOnly = true;
            // 
            // YearSection
            // 
            this.YearSection.HeaderText = "Year & Section";
            this.YearSection.Name = "YearSection";
            this.YearSection.ReadOnly = true;
            // 
            // CollegeCode
            // 
            this.CollegeCode.HeaderText = "College";
            this.CollegeCode.Name = "CollegeCode";
            this.CollegeCode.ReadOnly = true;
            // 
            // EventName
            // 
            this.EventName.HeaderText = "Event Name";
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            // 
            // Present
            // 
            this.Present.HeaderText = "Present";
            this.Present.Name = "Present";
            this.Present.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search For";
            // 
            // Filter
            // 
            this.Filter.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter.FormattingEnabled = true;
            this.Filter.Location = new System.Drawing.Point(242, 13);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(121, 22);
            this.Filter.TabIndex = 2;
            // 
            // Keyword
            // 
            this.Keyword.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyword.Location = new System.Drawing.Point(369, 13);
            this.Keyword.Name = "Keyword";
            this.Keyword.Size = new System.Drawing.Size(236, 22);
            this.Keyword.TabIndex = 3;
            this.Keyword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keyword_KeyUp);
            // 
            // AttendViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Keyword);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ADataGrid);
            this.Name = "AttendViewer";
            this.Size = new System.Drawing.Size(748, 496);
            ((System.ComponentModel.ISupportInitialize)(this.ADataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid ADataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollegeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Present;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Filter;
        private System.Windows.Forms.TextBox Keyword;
    }
}
