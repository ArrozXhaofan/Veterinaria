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
    public partial class Recepcion : Form
    {
        DataClasses1DataContext linq = new DataClasses1DataContext();
        Doctor doctor = new Doctor();


        public Recepcion()
        {
            InitializeComponent();
        }

        private void Recepcion_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarDueño_Click(object sender, EventArgs e)
        {
            linq.sp_crearDueño(txtDueñoNombre.Text, txtDueñoTel.Text, txtDueñoCorreo.Text);

            //CREAR EVENTO QUE LEA EL NUEVO DUEÑO
            MessageBox.Show("Nuevo dueño " + txtDueñoNombre.Text + " agregado.");
            dgvLista.DataSource = linq.sp_loadDueño();
        }

        private void btnAgregarAnimal_Click(object sender, EventArgs e)
        {
            linq.sp_crearAnimal(txtAnimalNombre.Text, txtAnimalEdad.Text,  txtColorAnimal.Text,int.Parse(txtAnimalDueño.Text));

            //CREAR EVENTO QUE LEA EL NUEVO ANIMAL
            MessageBox.Show("Nuevo animal " + txtAnimalNombre.Text + " agregado.");
            dgvLista.DataSource = linq.sp_loadAnimal();
        }

        private void btnAgregarFecha_Click(object sender, EventArgs e)
        {
             

            linq.sp_crearCita(Convert.ToDateTime(txtCitaFecha.Text),txtCitaDueño.Text,txtCitaAnimal.Text);

            //CREAR EVENTO QUE LEA EL NUEVO ANIMAL
            MessageBox.Show("Nuevo cita creada.");
            dgvLista.DataSource = linq.sp_loadCitas();
        }

        private void btnListaDueño_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = linq.sp_loadDueño();
        }

        private void btnListaAnimal_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = linq.sp_loadAnimal();
        }

        private void btnListaCitas_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = linq.sp_loadCitas();
        }

        private void btnCitasProx_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = linq.sp_loadCitasFuturas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doctor.Show();
        }
    }
}
