using JuKeMa.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuKeMa
{
    public partial class MainFrame : Form
    {
        private DbConnector data { get; set; }
        public MainFrame()
        {
            data = new DbConnector();
            InitializeComponent();
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

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
