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
    public partial class Form2 : Form
    {
        public EnlaceDB conexion;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((textBoxNombre.Text != "" && textBoxCedula.Text != "" && textBoxEsp.Text != "" && (textBoxFecha.Text != "" && validarFecha(textBoxFecha.Text)) && textBoxSueldo.Text != "") && (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true))
            {

                string nombre = textBoxNombre.Text;
                int cedula = int.Parse(textBoxCedula.Text);
                //validarNumeros(cedula, Click);
                string especialidad = textBoxEsp.Text;
                double sueldo = double.Parse(textBoxSueldo.Text);
                int edad = int.Parse(textBoxEdad.Text);
                /*DateTime*/
                string fecha = /*Date.Parse(fecha.ToString("yyyy-MM-dd"));*/ textBoxFecha.Text;
                string[] dias = new string[7];
                int cont = 0, i = 0;
                if (checkBox1.Checked)
                {
                    dias[cont] = "Lunes";
                    cont++;
                }
                if (checkBox2.Checked)
                {
                    dias[cont] = "Martes";
                    cont++;
                }
                if (checkBox3.Checked)
                {
                    dias[cont] = "Miercoles";
                    cont++;
                }
                if (checkBox4.Checked)
                {
                    dias[cont] = "Jueves";
                    cont++;
                }
                if (checkBox5.Checked)
                {
                    dias[cont] = "Viernes";
                    cont++;
                }
                if (checkBox6.Checked)
                {
                    dias[cont] = "Sabado";
                    cont++;
                }
                if (checkBox7.Checked)
                    dias[cont] = "Domingo";

                var dispo = "";
                if (dias[i] != null)
                {
                    dispo += dias[i];
                    i++;
                    while (dias[i] != null)
                    {
                        dispo += ", " + dias[i];
                        i++;
                    }
                }
               

                    MessageBox.Show("Nombre: " + nombre + "\nCédula: " + cedula + "\nEspecialidad: " + especialidad + "\nSueldo: " + sueldo + "\nFecha de Ingreso: " + fecha + "\nDías Laborales: " + dispo);
                    var conn = new EnlaceCassandra();
                    conn.InsertaDatos(cedula, nombre, especialidad, fecha, sueldo, dias, edad);
                    MessageBox.Show("Médico Agregado Exitosamente");
                    textBoxNombre.Text = "";
                    textBoxCedula.Text = "";
                    textBoxEsp.Text = "";
                    textBoxSueldo.Text = "";
                    textBoxFecha.Text = "";
                    textBoxEdad.Text = "";
                    //checkBox1.CheckState = unchecked()
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                
            }
            else
                MessageBox.Show("Favor de llenar todos los datos correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {


            var conn = new EnlaceCassandra();
            int cedula = int.Parse(textBoxBusCedula.Text);
            conn.GetOne(cedula, textBoxCedula, textBoxNombre, textBoxEsp, textBoxSueldo, textBoxFecha, textBoxEdad, checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7);
            textBoxCedula.Enabled = false;

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

            btnAgregar.Enabled = false;
            textBoxCedula.Enabled = false;
            int cedula = int.Parse(textBoxBusCedula.Text);
            if ((textBoxNombre.Text != "" && textBoxEsp.Text != "" && (textBoxFecha.Text != "" && validarFecha(textBoxFecha.Text)) && textBoxSueldo.Text != "") && (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true))
            {

                string nombre = textBoxNombre.Text;
                //validarNumeros(cedula, Click);
                string especialidad = textBoxEsp.Text;
                double sueldo = double.Parse(textBoxSueldo.Text);
                int edad = int.Parse(textBoxEdad.Text);
                /*DateTime*/
                string fecha = /*Date.Parse(fecha.ToString("yyyy-MM-dd"));*/ textBoxFecha.Text;
                string[] dias = new string[7];
                int cont = 0, i = 0;
                if (checkBox1.Checked)
                {
                    dias[cont] = "Lunes";
                    cont++;
                }
                if (checkBox2.Checked)
                {
                    dias[cont] = "Martes";
                    cont++;
                }
                if (checkBox3.Checked)
                {
                    dias[cont] = "Miercoles";
                    cont++;
                }
                if (checkBox4.Checked)
                {
                    dias[cont] = "Jueves";
                    cont++;
                }
                if (checkBox5.Checked)
                {
                    dias[cont] = "Viernes";
                    cont++;
                }
                if (checkBox6.Checked)
                {
                    dias[cont] = "Sabado";
                    cont++;
                }
                if (checkBox7.Checked)
                    dias[cont] = "Domingo";

                var dispo = "";
                if (dias[i] != null)
                {
                    dispo += dias[i];
                    i++;
                    while (dias[i] != null)
                    {
                        dispo += ", " + dias[i];
                        i++;
                    }
                }


                MessageBox.Show("Nombre: " + nombre + "\nCédula: " + cedula + "\nEspecialidad: " + especialidad + "\nSueldo: " + sueldo + "\nFecha de Ingreso: " + fecha + "\nDías Laborales: " + dispo);
                var conn = new EnlaceCassandra();
                conn.InsertaDatos(cedula, nombre, especialidad, fecha, sueldo, dias, edad);
                MessageBox.Show("Datos Modificados Exitosamente");
                textBoxNombre.Text = "";
                textBoxCedula.Text = "";
                textBoxEsp.Text = "";
                textBoxSueldo.Text = "";
                textBoxFecha.Text = "";
                textBoxEdad.Text = "";
                textBoxBusCedula.Text = "";
                //checkBox1.CheckState = unchecked()
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;

            }
            else
                MessageBox.Show("Favor de llenar todos los datos correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            textBoxCedula.Enabled = false;
            btnAgregar.Enabled = false;
            var conn = new EnlaceCassandra();
            int cedula = int.Parse(textBoxBusCedula.Text);
            var res=  MessageBox.Show("¿Estás seguro de eliminar este médico?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                conn.EliminarDatos(cedula);

        }
        public  void validarNumeros(object sender, KeyPressEventArgs num)
        {
            if (char.IsDigit(num.KeyChar))
                num.Handled = false;
            else if (char.IsControl(num.KeyChar))
                num.Handled = false;
            else
                num.Handled = true;
        }

        public  void validarLetras(object sender, KeyPressEventArgs let)
        {
            if (char.IsLetter(let.KeyChar))
                let.Handled = false;
            else if (char.IsControl(let.KeyChar))
                let.Handled = false;
            else
                let.Handled = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool validarFecha(string fecha_)
        {
            DateTime fecha;
            if(DateTime.TryParse(fecha_, out fecha))
            {
                return true;
            }
            return false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            var x = new EnlaceCassandra();
            List<Ejemplo> lst1 = new List<Ejemplo>();
            lst1 = x.Get_All();

            dataGridView1.DataSource = lst1;
            conexion = null;    
        }


        private void unoPorUnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conexion = new EnlaceDB();
            DataTable data = new DataTable();

            data = conexion.get_Users();

            foreach (DataRow renglon in data.Rows)
            {
                MessageBox.Show(renglon["Nombre"].ToString(), "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conexion = null;
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGet_Click(sender, e);
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form3();
            form.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
