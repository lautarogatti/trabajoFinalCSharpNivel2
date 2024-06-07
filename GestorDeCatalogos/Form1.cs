using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeCatalogos
{
    public partial class Form1 : Form
    {
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            try
            {
                dgvArticulos.DataSource = articuloNegocio.listar();
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["UrlImagen"].Visible = false;
        }

        private void btnVerProducto_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            DetallesArticulo detallesArticulo = new DetallesArticulo(seleccionado);
            detallesArticulo.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaArticulo alta = new AltaArticulo();
            alta.ShowDialog();
            cargarGrilla();
        }
    }
}
