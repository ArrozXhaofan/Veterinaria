using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;

namespace capaPresentacion
{
    public partial class Doctor : Form
    {
        DataClasses1DataContext linq = new DataClasses1DataContext();

        public Doctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvBuscar.DataSource = linq.sp_buscarCita(int.Parse(txtId.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
             linq.sp_repotarCita(int.Parse(txtId.Text), txtTratamiento.Text);
            MessageBox.Show("Cita rellenada");
             dgvBuscar.DataSource = linq.sp_buscarCita(int.Parse(txtId.Text));
        }

        private void Doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
