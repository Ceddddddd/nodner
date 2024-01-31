using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;

            if (name == "admin" && pass == "admin")
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
            else if (name != "admin" && pass == "admin")
            {
                MessageBox.Show("Wrong Username!");
            }
            else if (name == "admin" && pass != "admin")
            {
                MessageBox.Show("Wrong Password!");
            }
            else {
                MessageBox.Show("Invalid Credentials!");
            }

        }
    }
}
