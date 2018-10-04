using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR.Personnel
{
    public partial class uViewPersonnel : UserControl
    {
        public uViewPersonnel()
        {
            InitializeComponent();
        }
        private static uViewPersonnel _instance = null;

        public static uViewPersonnel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new uViewPersonnel();
                }

                return _instance;
            }
        }

        public void InitializeView()
        {
            TablePersonnel.Rows.Clear();
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select eventid,userid,given_name,last_name,username,passwd from personnel",false);
            while (rd.Read())
            {
                TablePersonnel.Rows.Add();
                TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[0].Value = rd.GetValue(0).ToString();
                TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[1].Value = rd.GetValue(1).ToString();
                TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[2].Value = rd.GetValue(2).ToString();
                TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[3].Value = rd.GetValue(3).ToString();
                TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[4].Value = rd.GetValue(4).ToString();
                TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[5].Value = rd.GetValue(5).ToString();
            }
        }
    }
}
