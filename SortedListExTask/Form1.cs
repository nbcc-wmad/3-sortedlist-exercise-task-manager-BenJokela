using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SortedList<DateTime, string> taskList = new SortedList<DateTime, string>();



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if(txtTask.Text == string.Empty)
            {
                MessageBox.Show("You must enter a task.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime taskDate = dtpTaskDate.Value;
                string taskName = txtTask.Text.Trim();

                taskList.Add(taskDate, taskName);
                lstTasks.Items.Add(taskDate.ToShortDateString() + " " + taskName);

            }
        }
    }
}
