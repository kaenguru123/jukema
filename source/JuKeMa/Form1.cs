using JuKeMa.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuKeMa
{
    public partial class Form1 : Form
    {
        private DbConnector data { get; set; }
        public Form1()
        {
            InitializeComponent();
            data = new DbConnector();
            var employees = data.getDataForCheckList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var employeeJSON = data.getAllEmployee();
            Console.WriteLine(employeeJSON);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
