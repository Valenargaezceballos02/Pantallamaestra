using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallamaestra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BaseDeDatos DB_Registros = new BaseDeDatos();

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvRegistro.DataSource = DB_Registros.SelectDataTable("select * from personas");
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            string agregar = "insert into datos values (" + txtcodigo.Text + ",'" + txtnombres.Text + "','" + txtapellidos.Text + ",'" + txttelefono.Text + "')";
        
            if (DB_Registros.executecommand(agregar))
            {
                MessageBox.Show("Registro agregado recientemente");
                dgvRegistro.DataSource = DB_Registros.SelectDataTable("select * from datos");
            }

            else
            {
                MessageBox.Show("Error al agregar");
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "delete datos where codigo = " + txtcodigo.Text;

            if (DB_Registros.executecommand(eliminar))
            {
                MessageBox.Show("Registro eliminado correctamente");
                dgvRegistro.DataSource = DB_Registros.SelectDataTable("select * from datos");
            }

            else
            {
                MessageBox.Show("Error al eliminar");
            }

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            string actualizar = "update datos set nombre =" + txtnombres.Text + "where codigo =" + txtcodigo.Text;

            if (DB_Registros.executecommand(actualizar))
            {
                MessageBox.Show("Registro modificado correctamente");
                dgvRegistro.DataSource = DB_Registros.SelectDataTable("select * from datos");
            }

            else
            {
                MessageBox.Show("Error al modificar");
            }

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            dgvRegistro.DataSource = DB_Registros.SelectDatatable("select * from datos where codigo = " + txtbuscar.Text);
        }

        private void dgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dgvRegistro.Rows[e.RowIndex];
            txtcodigo.Text = dgv.Cells[0].Value.ToString();
            txtnombres.Text = dgv.Cells[1].Value.ToString();
            txtapellidos.Text = dgv.Cells[2].Value.ToString();
            txttelefono.Text = dgv.Cells[3].Value.ToString();
        }

    }
}
