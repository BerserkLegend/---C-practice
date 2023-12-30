using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlnaIcpitWinForm14._12._2023
{
    
    public partial class Form1 : Form
    {
        internal static Control form1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2AddUser form2 = new Form2AddUser();
            if(form2.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add(form2.datagridname[0], form2.datagridname[1], form2.datagridname[2], form2.datagridname[3]);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form1 = this;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2AddUser form2 = new Form2AddUser();
            form2.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            form2.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Male")
            {
                form2.radioButton1.Checked = true;
                form2.radioButton2.Checked = false;
            }
            else {
                form2.radioButton1.Checked = false;
                form2.radioButton2.Checked = true;

            }
            form2.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.CurrentRow.Cells[0].Value = form2.textBox1.Text;
                dataGridView1.CurrentRow.Cells[1].Value = form2.textBox2.Text;
                dataGridView1.CurrentRow.Cells[2].Value = (form2.radioButton1.Checked) ? form2.radioButton1.Text : form2.radioButton2.Text;
                dataGridView1.CurrentRow.Cells[3].Value = form2.textBox3.Text;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using(FileStream f =  new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    using(StreamWriter sw = new StreamWriter(f))
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                sw.Write(dataGridView1.Rows[i].Cells[j].Value + " ");

                            }
                            sw.WriteLine();
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {

                using (FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read)) 
                {
                   using(StreamReader sr = new StreamReader(f))
                    {
                        string buff;
                        string[] buffsplit;
                        
                        
                        while (sr.Peek()!=-1)
                        {
                            buff = sr.ReadLine();
                            buffsplit = buff.Split(' ');
                            dataGridView1.Rows.Add(buffsplit);
                        }

                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3coutcs form3 = new Form3coutcs();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() ==textBox1.Text)
                {
                    // MessageBox.Show($"{i}"," ");

                    form3.listBox1.Items.Add(dataGridView1.Rows[i].Cells[0].Value.ToString() + " " +
                        dataGridView1.Rows[i].Cells[1].Value.ToString() + " " +
                        dataGridView1.Rows[i].Cells[2].Value.ToString() + " " +
                        dataGridView1.Rows[i].Cells[3].Value.ToString());

                }
            }
            form3.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3coutcs form3 = new Form3coutcs();
            form3.label1.Text = $"має ті числа:\n{textBox2.Text}";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(textBox2.Text))
                {
                    // MessageBox.Show($"{i}"," ");

                    form3.listBox1.Items.Add(dataGridView1.Rows[i].Cells[0].Value.ToString()+ " "+
                        dataGridView1.Rows[i].Cells[1].Value.ToString() + " " +
                        dataGridView1.Rows[i].Cells[2].Value.ToString() + " " +
                        dataGridView1.Rows[i].Cells[3].Value.ToString());

                }
            }
            form3.Show();
        }
    }
}
