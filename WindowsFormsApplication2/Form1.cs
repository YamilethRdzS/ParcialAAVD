using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            Form form = new Form2();
            form.ShowDialog();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            //Form form = new Form4();
            //form.ShowDialog();
            //DialogResult dialog = new DialogResult();

            //dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            //if (dialog == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
