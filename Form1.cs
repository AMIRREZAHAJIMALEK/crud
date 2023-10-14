using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud1_human
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool c = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            human human = new human();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = human.reedall();
        }
        public db db1 = new db();
        private void button1_Click(object sender, EventArgs e)
        {
            if (c == false)
            {
                human human = new human() { name = textBox1.Text, family = textBox2.Text, age = Convert.ToByte(textBox3.Text) };
                human.registeer(human);
                bool b = human.registeer(human);
                if (b == true)
                {
                    MessageBox.Show("succes register");
                }
                else
                {
                    MessageBox.Show("faild register");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.reedall();
            }
            else
            {
                human human = new human() { name = textBox1.Text, family = textBox2.Text, age = Convert.ToByte(textBox3.Text) };
                human.update(id, human);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.reedall();
                button1.Text = "register";
                c = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            human human = new human();
            if (textBox4.Text=="")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.reedall();
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.reedbyname(textBox4.Text);
            }
        }
        public int id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            human human = new human();
            id =(int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            human=human.reedbyid(id);
            textBox1.Text = human.name;
            textBox2.Text = human.family;
            textBox3.Text = human.age.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            human human = new human();
            DialogResult = MessageBox.Show("are you sure?", "warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                human.delete(id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.reedall();
            }
            
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "update";
            c = true;
        }
    }
}
