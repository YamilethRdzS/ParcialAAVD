using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using System.Configuration;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class EnlaceCassandra
    {
        static private string _dbServer { set; get; }
        static private string _dbKeySpace { set; get; }
        static private Cluster _cluster;
        static private ISession _session;

        private static void conectar()
        {
            _dbServer = ConfigurationManager.AppSettings["Cluster"].ToString();
            _dbKeySpace = ConfigurationManager.AppSettings["KeySpace"].ToString();

            _cluster = Cluster.Builder()
                .AddContactPoint(_dbServer)
                .Build();

            _session = _cluster.Connect(_dbKeySpace);
        }

        private static void desconectar()
        {
            _cluster.Dispose();
        }

        public void Crear()
        {
            conectar();
            string query = "CREATE TABLE Reg_medicos(cedula_profesional int primary key, nombre text, especialidad text, fecha_ingreso timestamp, sueldo double, edad int);";
            string query2 = "ALTER TABLE Reg_medicos ADD diaslaborales list< text >;";
            _session.Execute(query);
            _session.Execute(query2);
        }
        public void InsertaDatos(int cedula, string nombre, string especialidad, /*DateTime*/ string fecha_ingreso, double sueldo, string []dias, int edad /*int id, string dato*/)
        {
            try
            {
                int i = 0;
                conectar();
                //Crear();
                string qry = "INSERT into Reg_medicos(cedula_profesional, nombre, especialidad, fecha_ingreso, sueldo, edad) values(";
                qry = qry + cedula.ToString();
                qry = qry + ", '";
                qry = qry + nombre;
                qry = qry + "', '";
                qry = qry + especialidad;
                qry = qry + "', '";
                qry = qry + fecha_ingreso;
                qry = qry + "', ";
                qry = qry + sueldo.ToString();
                qry = qry + ", ";
                qry = qry + edad.ToString();
                qry = qry + ");";
                
                string qry2 = "UPDATE Reg_medicos SET diaslaborales = ['";
                if (dias[i] != null)
                {
                    qry2 = qry2 + dias[i];
                    i++;
                    while (dias[i] != null)
                    {
                        qry2 = qry2 + "', '" + dias[i];
                        i++;
                    }
                }
                qry2 = qry2 + "']  WHERE  cedula_profesional = ";
                qry2 = qry2 + cedula.ToString();
                qry2 = qry2 + ";";


                //string query = "insert into medicos(campo1, campo2) values({0}, '{1}');";
                //query = string.Format(query, id, dato);

                _session.Execute(qry);
                _session.Execute(qry2);
            }
            catch(Exception e)
            {
                throw e;   
            }
            finally
            {
                // desconectar o cerrar la conexión
            }
        }

        public void ModificarDatosDatos(int cedula, string nombre, string especialidad, string fecha_ingreso, double sueldo, string []dias, int edad){
            try
            {
                int i = 0;
                conectar();
        string qry = "UPDATE into Reg_medicos(cedula_profesional, nombre, especialidad, fecha_ingreso, sueldo, edad) values(";
        qry = qry + cedula.ToString();
                qry = qry + ", '";
                qry = qry + nombre;
                qry = qry + "', '";
                qry = qry + especialidad;
                qry = qry + "', '";
                qry = qry + fecha_ingreso;
                qry = qry + "', ";
                qry = qry + sueldo.ToString();
                qry = qry + ", ";
                qry = qry + edad.ToString();
                qry = qry + ");";

                string qry2 = "UPDATE medicos SET diaslaborales = ['";
                if (dias[i] != null)
                {
                    qry2 = qry2 + dias[i];
                    i++;
                    while (dias[i] != null)
                    {
                        qry2 = qry2 + "', '" + dias[i];
                        i++;
                    }
                }
                qry2 = qry2 + "']  WHERE  cedula_profesional = ";
                qry2 = qry2 + cedula.ToString();
                qry2 = qry2 + ";";

                

                _session.Execute(qry);
                _session.Execute(qry2);
            }
            catch(Exception e)
            {
                throw e;   
            }
            finally
            {
                // desconectar o cerrar la conexión
            }
        }

        public void EliminarDatos(int cedula)
        {
            try
            {
                int i = 0;
                conectar();
                string qry = "DELETE FROM Reg_medicos WHERE cedula_profesional = ";
                qry = qry + cedula.ToString();
                qry = qry + ";";
                

                _session.Execute(qry);
                MessageBox.Show("Médico Eliminado Exitosamente");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // desconectar o cerrar la conexión
            }
        }
        
        public IEnumerable<Ejemplo> Get_One(int dato)
        {
            string query = "SELECT cedula_profesional, nombre, especialidad, fecha_ingreso, sueldo, edad /*dias_laborales*/ FROM Reg_medicos WHERE cedula_profesioanl = ?;";
            conectar();
            IMapper mapper = new Mapper(_session);
            IEnumerable<Ejemplo> users = mapper.Fetch<Ejemplo>(query, dato);

            desconectar();
            return users.ToList();
        }

        public List<Ejemplo> Get_All()
        {
            string query = "SELECT cedula_profesional, nombre FROM Reg_medicos;";
            conectar();
            
            IMapper mapper = new Mapper(_session);
            IEnumerable<Ejemplo> users = mapper.Fetch<Ejemplo>(query);

            desconectar();
            return users.ToList();
            
        }

        // Ejemplo de leer row x row
        public void GetOne(int cedula_prof, TextBox cedula_, TextBox nombre_, TextBox especialidad_, TextBox sueldo_, TextBox fecha_ingreso_, TextBox edad_, CheckBox cb_, CheckBox cb2_, CheckBox cb3_, CheckBox cb4_, CheckBox cb5_, CheckBox cb6_, CheckBox cb7_)
        {
            conectar();

            string query = "SELECT cedula_profesional, nombre, especialidad, fecha_ingreso, sueldo, edad /*dias_laborales*/ FROM Reg_medicos WHERE cedula_profesional = ";
            query = query + cedula_prof.ToString();
            query = query + ";";

            // Execute a query on a connection synchronously 
            var rs = _session.Execute(query);

            bool found = false;
            // Iterate through the RowSet 
            foreach (var row in rs)
            {
                var cedula = row.GetValue<int>("cedula_profesional");
                cedula_.Text = Convert.ToString(cedula);
                // Do something with the value 
                var nombre = row.GetValue<string>("nombre");
                nombre_.Text = nombre;
                // Do something with the value 
                var sueldo = row.GetValue<double>("sueldo");
                sueldo_.Text = Convert.ToString(sueldo);
                var especialidad = row.GetValue<string>("especialidad");
                especialidad_.Text = especialidad;
                var fecha = row.GetValue<DateTime>("fecha_ingreso");
                fecha_ingreso_.Text = Convert.ToString(fecha);
                var edad = row.GetValue<int>("edad");
                edad_.Text = Convert.ToString(edad);
                //textBoxNombre.Text = nombre;
                //textBoxCedula.Text = cedula;
                //textBoxEsp.Text = "";
                //textBoxSueldo.Text = "";
                //textBoxFecha.Text = "";
                //textBoxEdad.Text = "";
                found = true;
                MessageBox.Show("Nombre: " + nombre + "\nCédula: " + cedula + "\nEspecialidad: " + especialidad + "\nSueldo: " + sueldo + "\nFecha de Ingreso: " + fecha /*+ "\nDías Laborales: " + dispo*/);

                /*
                RowSet rsUsers = session.Execute(qry);

                ////////////////////////////////////////////////
                var users = new List<UserModel>();
                foreach (var userRow in rsUsers)
                {
                    //users.Add(ReflectionTools.GetSingleEntryDynamicFromReader<UserModel>(userRow));
                }

                foreach (UserModel user in users)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", user.Id, user.FirstName, user.LastName, user.Country, user.IsActive);
                }
                */

            }
            if (found == false)
                MessageBox.Show("Cédula no encontrada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

    }
}
