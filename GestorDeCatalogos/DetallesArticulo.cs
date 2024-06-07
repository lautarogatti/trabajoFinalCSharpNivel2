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
using Helpers;

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
            Ayudante.cargarImagen(articulo.UrlImagen, pbxImgArticulo);
            lblTextoCod.Text = articulo.Codigo;
            lblTextoNombre.Text = articulo.Nombre;
            lblTextoDesc.Text = articulo.Descripcion;
            lblTextoMarca.Text = articulo.Marca.ToString();
            lblTextoCateg.Text = articulo.Categoria.ToString();
            lblTextoPrecio.Text = articulo.Precio.ToString();
        }
    }
}
