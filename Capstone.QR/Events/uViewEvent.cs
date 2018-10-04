using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;
using System.Data.SqlClient;

namespace Capstone.QR.Events
{
    public partial class uViewEvent : UserControl
    {
        public uViewEvent()
        {
            InitializeComponent();
        }
        private static uViewEvent _instance = null;
        public static uViewEvent Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new uViewEvent();
                    return _instance;
                }

                return _instance;
            }
        }
        private int ViewCode = 99;
        public void Ctrl_Added(int Code)
        {
            ViewCode = Code;
            EventData.Rows.Clear();
            EventData.Refresh();
            string status = "";
            string query = "";
            if (Code.Equals(99))
                query = "select eventid, event_name,event_location,event_cost,event_stime,event_date,event_open from custom_event";
            else
                query = "select eventid, event_name,event_location,event_cost,event_stime,event_date,event_open from custom_event where event_open=" + Code; 
            SqlDataReader rd = SqlUtils.ExecuteQueryReader( query, false);
            while (rd.Read())
            {
                var open = rd.GetValue(6);
                int Ropen = (Int32)open;

                if (Ropen == -1)
                {
                    status = "Pending";
                }
                else if (Ropen == 1)
                {
                    status = "Open";
                }
                else
                {
                    status = "Closed";
                }
                EventData.Rows.Add();
                EventData.Rows[EventData.Rows.Count - 1].Cells[0].Value = rd.GetValue(0);
                EventData.Rows[EventData.Rows.Count - 1].Cells[1].Value = rd.GetValue(1);
                EventData.Rows[EventData.Rows.Count - 1].Cells[2].Value = rd.GetValue(2);
                EventData.Rows[EventData.Rows.Count - 1].Cells[3].Value = rd.GetValue(5);
                EventData.Rows[EventData.Rows.Count - 1].Cells[4].Value = rd.GetValue(4);
                EventData.Rows[EventData.Rows.Count - 1].Cells[5].Value = rd.GetValue(3);
                EventData.Rows[EventData.Rows.Count - 1].Cells[6].Value = status;
            }
            rd.Close();
        }

        private void EventData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var obj = (DataGridView)sender;
                string query = "";
                if (obj.Rows.Count > 0 && obj.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (obj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Pending"))
                    {
                        var result = MessageBox.Show("Do you want to open this event for registration?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (result.Equals(DialogResult.Yes))
                        {
                            int x = (Int32)obj.Rows[e.RowIndex].Cells[e.ColumnIndex - 6].Value;
                            query = "UPDATE custom_event SET event_open=1 where eventid=@id";
                            SqlUtils.ExecuteInsert(query, new string[] { "@id" }, new string[] { x.ToString() });
                            MessageBox.Show("Updated Successfully!", "Attention");
                        }
                    }
                    else if (obj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Open"))
                    {
                        var result = MessageBox.Show("Do you want to close this event for registration?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (result.Equals(DialogResult.Yes))
                        {
                            int x = (Int32)obj.Rows[e.RowIndex].Cells[e.ColumnIndex - 6].Value;
                            query = "UPDATE custom_event SET event_open=0 where eventid=@id";
                            SqlUtils.ExecuteInsert(query, new string[] { "@id" }, new string[] { x.ToString() });
                            MessageBox.Show("Updated Successfully!", "Attention");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Event is close", "Sorry");
                    }
                    EventData.Rows.Clear();
                    Ctrl_Added(ViewCode);
                }
            }
            catch (Exception exception)
            {
                
            }
            

        }
    }
}
