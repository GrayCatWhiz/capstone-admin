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
using System.Text.RegularExpressions;

namespace Capstone.QR.Attendee
{
    public partial class AttendViewer : UserControl
    {
        public AttendViewer()
        {
            InitializeComponent();
        }

        public static AttendViewer Instance()
        {
            return new AttendViewer();
        }

        internal void InitFilters()
        {
            Filter.Items.Clear();
            Filter.Items.Add("Attendee Name");
            Filter.Items.Add("Event Name");
            Filter.Items.Add("College");
            Filter.Items.Add("Year & Section");
            Filter.SelectedIndex = 0;

        }

        internal void AttendeeViewController()
        {
            ADataGrid.Rows.Clear();
            ADataGrid.Refresh();
            var reader = SqlUtils.ExecuteQueryReader("select attendee_id,attendee_fullname,attendee_yrsec,college_code,eventid,attendee_present from attendee", false);
            while (reader.Read())
            {
                string collegeDesc = "";
                var collegeReader = SqlUtils.ExecuteQueryReader("select college_desc from college where college_code='" + reader["college_code"].ToString() + "'", false);
                while (collegeReader.Read())
                {
                    collegeDesc = (string)collegeReader["college_desc"];
                }

                string eventName = "";
                var eventReader = SqlUtils.ExecuteQueryReader("select event_name from custom_event where eventid=" + Convert.ToInt32(reader["eventid"]), false);
                while (eventReader.Read())
                {
                    eventName = (string)eventReader["event_name"];
                }


                ADataGrid.Rows.Add();
                ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[0].Value = reader["attendee_id"];
                ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[1].Value = reader["attendee_fullname"];
                ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[2].Value = reader["attendee_yrsec"];
                ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[3].Value = collegeDesc;
                ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[4].Value = eventName;
                ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[5].Value = (int)reader["attendee_present"];
            }
            reader.Close();
        }

        private void Keyword_KeyUp(object sender, KeyEventArgs e)
        {
            ADataGrid.Rows.Clear();

            if (Keyword.Text.Trim().Length > 0)
            {
                var pattern = new Regex(Keyword.Text.Trim().ToLower());
                ADataGrid.Rows.Clear();
                var reader = SqlUtils.ExecuteQueryReader("select attendee_id,attendee_fullname,attendee_yrsec,college_code,eventid,attendee_present from attendee", false);
                while (reader.Read())
                {
                    string collegeDesc = "";
                    var collegeReader = SqlUtils.ExecuteQueryReader("select college_desc from college where college_code='" + reader["college_code"].ToString() + "'", false);
                    while (collegeReader.Read())
                    {
                        collegeDesc = (string)collegeReader["college_desc"];
                    }

                    string eventName = "";
                    var eventReader = SqlUtils.ExecuteQueryReader("select event_name from custom_event where eventid=" + Convert.ToInt32(reader["eventid"]), false);
                    while (eventReader.Read())
                    {
                        eventName = (string)eventReader["event_name"];
                    }

                    if (Filter.SelectedIndex == 0 && pattern.IsMatch(reader["attendee_fullname"].ToString().ToLower())){
                        ADataGrid.Rows.Add();
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[0].Value = reader["attendee_id"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[1].Value = reader["attendee_fullname"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[2].Value = reader["attendee_yrsec"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[3].Value = collegeDesc;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[4].Value = eventName;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[5].Value = (int)reader["attendee_present"];
                    }
                    else if (Filter.SelectedIndex == 1 && pattern.IsMatch(eventName.ToLower())){
                        ADataGrid.Rows.Add();
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[0].Value = reader["attendee_id"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[1].Value = reader["attendee_fullname"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[2].Value = reader["attendee_yrsec"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[3].Value = collegeDesc;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[4].Value = eventName;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[5].Value = (int)reader["attendee_present"];
                    }
                    else if (Filter.SelectedIndex == 2 && pattern.IsMatch(collegeDesc.ToLower()))
                    {
                        ADataGrid.Rows.Add();
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[0].Value = reader["attendee_id"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[1].Value = reader["attendee_fullname"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[2].Value = reader["attendee_yrsec"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[3].Value = collegeDesc;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[4].Value = eventName;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[5].Value = (int)reader["attendee_present"];
                    }
                    else if (Filter.SelectedIndex == 3 && pattern.IsMatch(reader["attendee_yrsec"].ToString().ToLower()))
                    {
                        ADataGrid.Rows.Add();
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[0].Value = reader["attendee_id"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[1].Value = reader["attendee_fullname"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[2].Value = reader["attendee_yrsec"];
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[3].Value = collegeDesc;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[4].Value = eventName;
                        ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[5].Value = (int)reader["attendee_present"];
                    }
                }
                reader.Close();
            }
            else
            {
                ADataGrid.Refresh();
                var reader = SqlUtils.ExecuteQueryReader("select attendee_id,attendee_fullname,attendee_yrsec,college_code,eventid,attendee_present from attendee", false);
                while (reader.Read())
                {
                    string collegeDesc = "";
                    var collegeReader = SqlUtils.ExecuteQueryReader("select college_desc from college where college_code='" + reader["college_code"].ToString() + "'", false);
                    while (collegeReader.Read())
                    {
                        collegeDesc = (string)collegeReader["college_desc"];
                    }

                    string eventName = "";
                    var eventReader = SqlUtils.ExecuteQueryReader("select event_name from custom_event where eventid=" + Convert.ToInt32(reader["eventid"]), false);
                    while (eventReader.Read())
                    {
                        eventName = (string)eventReader["event_name"];
                    }


                    ADataGrid.Rows.Add();
                    ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[0].Value = reader["attendee_id"];
                    ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[1].Value = reader["attendee_fullname"];
                    ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[2].Value = reader["attendee_yrsec"];
                    ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[3].Value = collegeDesc;
                    ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[4].Value = eventName;
                    ADataGrid.Rows[ADataGrid.Rows.Count - 1].Cells[5].Value = (int)reader["attendee_present"];
                }
                reader.Close();
            }
        }
    }
}
