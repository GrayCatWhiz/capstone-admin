using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone.QR
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }
        ReportDocument File;

        private void button1_Click(object sender, EventArgs e) // Export Pdf
        {
            try
            {
                var file = new FolderBrowserDialog();
                var result = file.ShowDialog();
                if (result == DialogResult.OK && file.SelectedPath != null)
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = file.SelectedPath;
                    CrExportOptions = File.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    File.Export();
                    MessageBox.Show("Exported Successfully!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetRpt_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            file.Filter = "Report File|*.rpt";
            var result = file.ShowDialog();

            if(result == DialogResult.OK && file.FileName != null)
            {
                File = new ReportDocument();
                File.Load(file.FileName);
                ReportView.ReportSource = File;
                ReportView.Refresh();
            }

            
        }
    }
}
