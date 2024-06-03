using Dominio;
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
    public partial class DetallesArticulo : Form
    {
        Articulo articulo = null;

        public DetallesArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void DetallesArticulo_Load(object sender, EventArgs e)
        {
            cargarImagen();
            lblTextoCod.Text = articulo.Codigo;
            lblTextoNombre.Text = articulo.Nombre;
            lblTextoDesc.Text = articulo.Descripcion;
            lblTextoMarca.Text = articulo.Marca.ToString();
            lblTextoCateg.Text = articulo.Categoria.ToString();
            lblTextoPrecio.Text = articulo.Precio.ToString();
        }

        private void cargarImagen()
        {

            try
            {
                pbxImgArticulo.Load(articulo.UrlImagen);
            }
            catch (Exception)
            {
                pbxImgArticulo.Load("https://media.istockphoto.com/id/1472933890/vector/no-image-vector-symbol-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg?s=612x612&w=0&k=20&c=Rdn-lecwAj8ciQEccm0Ep2RX50FCuUJOaEM8qQjiLL0=");
            }
        }
    }
}
