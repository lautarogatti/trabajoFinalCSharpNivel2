using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Helpers;

namespace GestorDeCatalogos
{
    public partial class AltaArticulo : Form
    {
        Articulo articulo = null;
        public AltaArticulo()
        {
            InitializeComponent();
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcas = new MarcaNegocio();
            CategoriaNegocio categorias = new CategoriaNegocio();
            cbxMarca.DataSource = marcas.listar();
            cbxCategoria.DataSource = categorias.listar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            articulo = new Articulo();

            try
            {
                articulo.Codigo = txbCodigo.Text;
                articulo.Nombre = txbNombre.Text;
                articulo.Descripcion = txbDescripcion.Text;
                articulo.Marca = (Marca)cbxMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                articulo.UrlImagen = txbUrlImagen.Text;
                articulo.Precio = decimal.Parse(txbPrecio.Text);
                negocio.agregar(articulo);
                MessageBox.Show("Articulo agregado con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbUrlImagen_TextChanged(object sender, EventArgs e)
        {
            Ayudante.cargarImagen(txbUrlImagen.Text, pbxImagen);
        }
    }
}
