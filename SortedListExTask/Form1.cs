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
                if (taskList.ContainsKey(taskDate))
                {
                    MessageBox.Show("Only one task per date is allowed.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpTaskDate.Focus();
                }
                else
                {
                    string taskName = txtTask.Text.Trim();

                    taskList.Add(taskDate, taskName);
                    lstTasks.Items.Add(taskDate);
                    txtTask.Text = string.Empty;
                    txtTask.Focus();
                }

            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                DateTime taskDate = (DateTime)lstTasks.SelectedItem;
                var currentTask = taskList.Where(x => x.Key == taskDate).FirstOrDefault();
                lblTaskDetails.Text = currentTask.Value.ToString();
                //foreach (var x in taskList)
                //{
                //    if(x.Key == taskDate)
                //    {
                //        lblTaskDetails.Text = x.Value;
                //    }
                //}

            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            foreach(var x in taskList)
            {
                message += $"{x.Key} {x.Value}\n";
            }
            MessageBox.Show(message);
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a task to remove.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DateTime taskDate = (DateTime)lstTasks.SelectedItem;
                var currentTask = taskList.Where(x => x.Key == taskDate).FirstOrDefault();
                taskList.Remove(currentTask.Key);
                lstTasks.Items.Remove(lstTasks.SelectedItem);
                lblTaskDetails.Text = string.Empty;
            }
        }
    }
}
