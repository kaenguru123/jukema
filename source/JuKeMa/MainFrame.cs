using JuKeMa.Data;
using JuKeMa.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JuKeMa
{
    public partial class MainFrame : Form
    {
        private DbConnector Data { get; set; }
        private List<string> CheckedEmployees { get; set; }
        private List<Employee> Employees { get; set; }
        private bool BlockLoading { get; set; }

        public MainFrame()
        {
            Data = new DbConnector();
            InitializeComponent();
            CheckedEmployees = new List<string>();
        }

        private void saveJson_Click(object sender, EventArgs e)
        {
            if (this.CheckedEmployees.Count == 0)
            {
                MessageBox.Show("Please select an employee", "No employees selected!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON|*.json | Text|*.txt";
            saveFileDialog.Title = "Choose output directory";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, this.JsonView.Text);
            }
        }

        private string extractNtUserFromItem(string item)
        {
            var ntuser = "";
            for (int i = 0; i < item.Length && item[i] != '\t'; ++i)
            {
                ntuser += item[i];
            }
            return ntuser;
        }

        private void listBox_SelectedIndexChanged(object sender, ItemCheckEventArgs e)
        {
            this.JsonView.Clear();
            var checkedItem = ListBox.Items[e.Index].ToString();

            if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                this.BlockLoading = true;
                for (int i = 1; i < ListBox.Items.Count; ++i)
                {
                    ListBox.SetItemChecked(i, true);
                }
                this.BlockLoading = false;
            } 
            else if (e.Index == 0 && e.NewValue == CheckState.Unchecked && this.CheckedEmployees.Count == this.Employees.Count)
            {
                this.BlockLoading = true;
                for (int i = 1; i < ListBox.Items.Count; ++i)
                {
                    ListBox.SetItemChecked(i, false);
                }
                this.BlockLoading = false;
            } 
            
            if (e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                this.CheckedEmployees.Add(extractNtUserFromItem(checkedItem));
            } 
            else if (e.Index != 0 && e.NewValue == CheckState.Unchecked)
            {
                var toRemove = this.CheckedEmployees.FirstOrDefault(x => x.Equals(extractNtUserFromItem(checkedItem)));
                this.CheckedEmployees.Remove(toRemove);
                ListBox.SetItemChecked(0, false);
            }
            if (!BlockLoading)
            {
                this.JsonView.Text = this.CheckedEmployees.Count == 0 ? "" : Data.getEmployeeByList(this.CheckedEmployees);
            }
        }
    }
}
