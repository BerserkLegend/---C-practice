using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlnaIcpitWinForm14._12._2023
{
    public partial class Form2AddUser : Form
    {
        // internal DataGridView dataGrid;
        internal string[] datagridname;
        public Form2AddUser()
        {
            InitializeComponent();
        }

        /*private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                radioButton1.Checked = false;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkFull())
            {
                string[] buff = {
                textBox1.Text,
                textBox2.Text,
                (radioButton1.Checked)?radioButton1.Text:radioButton2.Text,
                textBox3.Text
                };
                datagridname = buff;
                /*dataGrid = new DataGridView();
                dataGrid = (DataGridView)Form1.form1.Controls[1];
                dataGrid.Rows.Add(textBox1.Text, textBox2.Text, (radioButton1.Checked)?radioButton1.Text:radioButton2.Text, textBox3.Text);
                */
            }
            else
              this.DialogResult = DialogResult.Cancel;
        }
        bool checkFull()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)&&!string.IsNullOrWhiteSpace(textBox2.Text)&&!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                return true;
            }
            return false;

        }
    }
}