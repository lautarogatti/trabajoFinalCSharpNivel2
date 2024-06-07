using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    static public class Ayudante
    {
        static public void cargarImagen(string url, PictureBox contenedor)
        {
            try
            {
                contenedor.Load(url);
            }
            catch (Exception)
            {
                contenedor.Load("https://media.istockphoto.com/id/1472933890/vector/no-image-vector-symbol-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg?s=612x612&w=0&k=20&c=Rdn-lecwAj8ciQEccm0Ep2RX50FCuUJOaEM8qQjiLL0=");
            }
        }
    }
}
