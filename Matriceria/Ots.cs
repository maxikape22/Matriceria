using Matriceria.Entidades;
using Matriceria.Negocios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Matriceria
{
    public partial class Ots : Form
    {
        public Orden objEntOrden = new Orden();
        public OrdenNegocio objNegocioOrden = new OrdenNegocio();
        public Ots()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ots_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Areas ar = new Areas();
            ar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Piezas piezas = new Piezas();
            piezas.Show();
        }


        private void btGuardar_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposOrden();
            try
            {
                if (validar)
                {
                    // Crear el objeto de la orden y asignar valores


                    // Insertar la orden usando la capa de negocio
                    TxtBox_a_ObjOrden();
                    int nGrabados = objNegocioOrden.InsertarOrden("Alta", objEntOrden);

                    if (nGrabados == -1)
                    {
                        MessageBox.Show("No se logró agregar la orden al sistema");
                    }
                    else
                    {
                        MessageBox.Show("Se logró agregar la orden con éxito");
                        // Opcional: Limpiar formulario, recargar datos, etc.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
           
        }

        private void TxtBox_a_ObjOrden()
        {
           
            objEntOrden.Codigo = txtCodigo.Text;
            objEntOrden.Prioridad = cmbPrioridad.Text;
            objEntOrden.Descripcion = txtDescripcion.Text;
            objEntOrden.Estado = cmbEstado.Text;
            dateTimeFechaInicio.Text = (DateTime.Now).ToShortDateString();
            dateTimeFechaPrometido.Text = (DateTime.Now).ToShortDateString();
        }


        private bool ValidacionCamposOrden()
        {
            // Validación del Código
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese un Código de Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtCodigo.Text.Length > 50 || txtCodigo.Text.Length < 2)
            {
                MessageBox.Show("El código debe tener entre 2 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de Prioridad
            if (cmbPrioridad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la prioridad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de Descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDescripcion.Text.Length > 255)
            {
                MessageBox.Show("La descripción no puede superar los 255 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de Estado
            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de Fecha de Inicio
            DateTime fechaInicio = dateTimeFechaInicio.Value;
            if (fechaInicio == default(DateTime))
            {
                MessageBox.Show("Ingrese una fecha de inicio válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de Fecha Prometido
            DateTime fechaPrometido = dateTimeFechaPrometido.Value;
            if (fechaPrometido == default(DateTime))
            {
                MessageBox.Show("Ingrese una fecha de prometido válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validación de Fecha Prometido no anterior a Fecha de Inicio
            if (fechaPrometido < fechaInicio)
            {
                MessageBox.Show("La fecha de prometido no puede ser anterior a la fecha de inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public enum Prioridad
        {
            Alta,
            Media,
            Baja
        }

        public enum Estado
        {
            Abierto,
            Cerrado,
            Cancelado
        }

        private readonly Dictionary<Prioridad, string> PrioridadMapeo = new Dictionary<Prioridad, string>()
        {
            {
                Prioridad.Alta, "Alta" 
            },
            { 
                Prioridad.Media, "Media" 
            },
            { 
                Prioridad.Baja, "Baja"
            }
        };

        private readonly Dictionary<Estado, string> EstadoMapeo = new Dictionary<Estado, string>()
        {
            {   
                Estado.Abierto, "Abierto" 
            },
            {   
                Estado.Cerrado, "Cerrado" 
            },
            {
                Estado.Cancelado, "Cancelado" 
            }
        };

        private void CargarComboBox()
        {
            // Cargar ComboBox de Prioridades
            cmbPrioridad.DataSource = new BindingSource(PrioridadMapeo, null);
            cmbPrioridad.DisplayMember = "Value";
            cmbPrioridad.ValueMember = "Key";

            // Cargar ComboBox de Estados
            cmbEstado.DataSource = new BindingSource(EstadoMapeo, null);
            cmbEstado.DisplayMember = "Value";
            cmbEstado.ValueMember = "Key";
        }
    }
}
