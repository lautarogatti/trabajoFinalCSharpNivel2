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

        public AltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Editar Articulo";
            lblTitulo.Text = "Editar Articulo";
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcas = new MarcaNegocio();
            CategoriaNegocio categorias = new CategoriaNegocio();
            try
            {
                cbxMarca.DataSource = marcas.listar();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion"; 
                cbxCategoria.DataSource = categorias.listar();
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txbCodigo.Text = articulo.Codigo.ToString();
                    txbNombre.Text = articulo.Nombre;
                    txbDescripcion.Text = articulo.Descripcion;
                    cbxMarca.SelectedValue = articulo.Marca.Id;
                    cbxCategoria.SelectedValue = articulo.Categoria.Id;
                    txbUrlImagen.Text = articulo.UrlImagen;
                    txbPrecio.Text = articulo.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                articulo.Codigo = txbCodigo.Text;
                articulo.Nombre = txbNombre.Text;
                articulo.Descripcion = txbDescripcion.Text;
                articulo.Marca = (Marca)cbxMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                articulo.UrlImagen = txbUrlImagen.Text;
                articulo.Precio = decimal.Parse(txbPrecio.Text);

                if(articulo.Id == 0)
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Articulo agregado con exito");
                }
                else
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Articulo modificado con exito");
                }

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
