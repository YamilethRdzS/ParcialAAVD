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
    public partial class Form4 : Form
    {
        //public EnlaceCassandra conexion;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var id = Int32.Parse(textBox1.Text);
            var texto = textBox2.Text;

            var conn = new EnlaceCassandra();
            //conn.InsertaDatos(/*cedula, nombre, especialidad, fecha, sueldo, dispo*/ id, texto, "0", "YYYY_MM_DD", "0.0", "0", "0");


            MessageBox.Show("Registro Agregado","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            var conn = new EnlaceCassandra();
            List<Ejemplo> lst1 = new List<Ejemplo>();
            lst1 = conn.Get_All();

            cboEjemplo.Items.Clear();
            cboEjemplo.DisplayMember = "campo2";
            cboEjemplo.ValueMember = "campo1";
            cboEjemplo.DataSource = lst1;            
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            //int id = (int)cboEjemplo.SelectedValue;
            /*
            var id = cboEjemplo.SelectedValue;
            label1.Text = id.ToString();
            */

            var x = new EnlaceCassandra();
            //x.GetOne();

        }
    }
}
