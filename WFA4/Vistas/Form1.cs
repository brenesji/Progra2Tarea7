using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

//
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WFA4
{
    public partial class Form1 : Form
    {
        ControladorEmpleado controladorempleado = new ControladorEmpleado();
        ControladorSalario controladorsalario = new ControladorSalario();
        EntidadEmpleado entidadempleado = new EntidadEmpleado();
        EntidadSalario entidadsalario = new EntidadSalario();        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrid();
            //Comienza a hacer el select para el combobox
            cmbSal.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt1 = new DataTable();
            dt1 = controladorsalario.leer();
            Dictionary<int, string> data = new Dictionary<int, string>();
            string compose = "";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                compose = dt1.Rows[i][1].ToString().ToUpper() + "\\ ₡ " + dt1.Rows[i][2].ToString();
                data.Add(int.Parse(dt1.Rows[i][0].ToString()), compose);
            }

            cmbSal.DataSource = new BindingSource(data, null);
            cmbSal.DisplayMember = "Value";
            cmbSal.ValueMember = "Key";

            cmbSal.SelectedIndex = 0;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                    // Seleccion del rango del combobox
                    if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Equals("5"))
                        cmbSal.SelectedIndex = 0;
                    else if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Equals("10"))
                        cmbSal.SelectedIndex = 1;
                    else
                        cmbSal.SelectedIndex = 2;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(" ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Limpiar
            limpiarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Agregar
            cargarEntidad();
            controladorempleado.insertar(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }       

        private void button3_Click(object sender, EventArgs e)
        {
            //Modifcar
            cargarEntidad();
            controladorempleado.modificar(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Eliminar
            controladorempleado.eliminar(Convert.ToInt32(textBox1.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                //Buscar
                DataTable dt = new DataTable();
                dt = controladorempleado.buscar(Convert.ToInt32(textBox1.Text));
                textBox2.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                //int index = Convert.ToInt16(dt.Rows[0][4].ToString()) + 1;
                //comboBox1.SelectedIndex = index;      

                // Seleccion del rango del combobox
                if (dt.Rows[0][4].ToString().Equals("5"))
                    cmbSal.SelectedIndex = 0;
                else if (dt.Rows[0][4].ToString().Equals("10"))
                    cmbSal.SelectedIndex = 1;
                else
                    cmbSal.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Ingrese una Cedula a buscar");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Refrescar
            cargarGrid();
        }

        private void limpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }       

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorempleado.leer();
        }

        private void cargarCombo()
        {
            /*DataTable dt = new DataTable();
            sql = "select " + "id_salario," + "tipo" + " from " +
                "salario";
            mysqlconn.Open();
            mysqlda = new SqlDataAdapter(sql, mysqlconn);
            mysqlda.Fill(dt);
            mysqlconn.Close();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "tipo";
            comboBox1.ValueMember = "id_salario";
            comboBox1.SelectedIndex = 0;*/
        }

        private void cargarEntidad()
        {
            entidadempleado.Cedula = Convert.ToInt32(textBox1.Text);
            entidadempleado.Nombre = textBox2.Text;
            entidadempleado.Apellido = textBox3.Text;
            entidadempleado.Ubicacion = textBox4.Text;
            ///For debug
            Console.WriteLine("TEST: "+ cmbSal.SelectedValue.ToString());            
            entidadempleado.Id_Salario = Int32.Parse(cmbSal.SelectedValue.ToString());                        
        }

        private void cmbSal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("index: "+cmbSal.SelectedIndex.ToString());
            Console.WriteLine("item entire: "+cmbSal.SelectedItem.ToString());
            Console.WriteLine("selected value: " + cmbSal.SelectedValue.ToString());
            
            Console.WriteLine("------------------------------------");
        }
    }
}
