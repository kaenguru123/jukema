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
        private bool[] checkedBoxes { get; set; }
        private List<Employee> employees { get; set; }
        private bool allSelected { get; set; }

        public MainFrame()
        {
            data = new DbConnector();
            InitializeComponent();
            checkedBoxes = new bool[this.employees.Count];
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

        private void ListBox_SelectedIndexChanged(object sender, ItemCheckEventArgs e)
        {
            this.JsonView.Clear();
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    this.allSelected = true;
                    for (int index = 0; index < this.checkedBoxes.Length; ++index)
                    {
                        this.checkedBoxes[index] = true;
                        ListBox.SetItemChecked(index+1, true);
                    }
                } else
                {
                    this.allSelected = false;
                    for (int index = 0; index < this.checkedBoxes.Length; ++index)
                    {
                        this.checkedBoxes[index] = true;
                        ListBox.SetItemChecked(index+1, false);
                    }
                }

            } else if (this.checkedBoxes.All(x => true) && e.NewValue == CheckState.Unchecked)
            {
                this.allSelected = false;
                ListBox.SetItemChecked(0, false);
            } else 
            { 
                for (int cnt = 0; cnt < this.checkedBoxes.Length; ++cnt)
                {
                    if (ListBox.GetItemChecked(cnt))
                    {
                        this.checkedBoxes[cnt] = true;
                    }
                    else
                    {
                        this.checkedBoxes[cnt] = false;
                    }
                }
                if (e.NewValue == CheckState.Checked)
                {
                    this.checkedBoxes[e.Index] = true;
                }
            }

            for (int index = 1; index < this.checkedBoxes.Length; ++index)
            {
                if (this.checkedBoxes[index])
                {
                    var ntuser = "";
                    var checkedItem = ListBox.Items[index].ToString();
                    for (int i = 0; checkedItem[i] != '\t'; ++i)
                    {
                        ntuser += checkedItem[i];
                    }
                    var employee = this.employees.FirstOrDefault(x => x.NTUser.Equals(ntuser));
                    if (employee.NTUser != "")
                    {
                        this.JsonView.Text += data.getEmployeeById(employee.NTUser);
                    }
                }
            }
        }
    }
}
