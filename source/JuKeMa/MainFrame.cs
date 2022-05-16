using JuKeMa.Data;
using JuKeMa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuKeMa
{
    public partial class MainFrame : Form
    {
        private DbConnector data { get; set; }
        private List<string> checkedEmployees { get; set; }
        private List<Employee> employees { get; set; }
        private bool blockLoading { get; set; }

        public MainFrame()
        {
            data = new DbConnector();
            InitializeComponent();
            checkedEmployees = new List<string>();
        }

        private void SaveJson_Click(object sender, EventArgs e)
        {
            var employeeJSON = data.getAllEmployee();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON|*.json | Text|*.txt";
            saveFileDialog.Title = "Choose output directory";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, employeeJSON);
            }
            Console.WriteLine(employeeJSON);
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

        private void ListBox_SelectedIndexChanged(object sender, ItemCheckEventArgs e)
        {
            this.JsonView.Clear();
            var checkedItem = ListBox.Items[e.Index].ToString();

            if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                this.blockLoading = true;
                for (int i = 1; i < ListBox.Items.Count; ++i)
                {
                    ListBox.SetItemChecked(i, true);
                }
                this.blockLoading = false;
            } 
            else if (e.Index == 0 && e.NewValue == CheckState.Unchecked && this.checkedEmployees.Count == this.employees.Count)
            {
                this.blockLoading = true;
                for (int i = 1; i < ListBox.Items.Count; ++i)
                {
                    ListBox.SetItemChecked(i, false);
                }
                this.blockLoading = false;
            } 
            
            if (e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                this.checkedEmployees.Add(extractNtUserFromItem(checkedItem));
            } 
            else if (e.Index != 0 && e.NewValue == CheckState.Unchecked)
            {
                var toRemove = this.checkedEmployees.FirstOrDefault(x => x.Equals(extractNtUserFromItem(checkedItem)));
                this.checkedEmployees.Remove(toRemove);
                ListBox.SetItemChecked(0, false);
            }
            if (!blockLoading)
            {
                this.JsonView.Text = this.checkedEmployees.Count == 0 ? "" : data.getEmployeeByList(this.checkedEmployees);
            }
        }
    }
}
