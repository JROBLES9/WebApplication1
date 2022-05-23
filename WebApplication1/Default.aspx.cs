using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{

    public partial class _Default : Page
    {
        static public List<Producto> Productos = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Codigo = TextBoxCodigo.Text;

            producto.Descripcion = TextBoxDescripcion.Text;

            producto.Marca = TextBoxMarca.Text;

            producto.Existencia = Convert.ToInt32(TextBoxExistencia.Text);

            string archivoOrigen = Path.GetFileName(FileUploadImagen.FileName);

            try

            {

                //esta linea "copia" el archivo original que seleccionamos, a la carpeta imagenes de nuestro proyecto. Esta carpeta ya debe estar hecha

                FileUploadImagen.SaveAs(Server.MapPath("~/imagenes/") + archivoOrigen);

                LabelEstado.Text = "Exitosamente Subido";

            }
            catch (Exception ex)

            {

                LabelEstado.Text = "No se pudo subir, se generó el siguiente error:  " + ex.Message;

            }
            string archivo = "~/imagenes/" + FileUploadImagen.FileName;

            producto.Imagen = archivo;
            Productos.Add(producto);
            guardar();
        }
        public void guardar()
        {

            //Se serializa (convierte) la lista en formato Json y se guarda en una variable de tipo string
            string json = JsonConvert.SerializeObject(Productos);

            //El nombre del archivo
            string archivo = Server.MapPath("Datos.json");

            //Se escribe la variable que contiene el json al archivo en un solo paso
            //con WriteAllText se escribe todo de un solo
            System.IO.File.WriteAllText(archivo, json);
        }
    }
}