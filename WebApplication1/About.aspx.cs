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
    public partial class About : Page
    {
        static List<Producto> Productos = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }

        public void cargar()
        {
            //Se crea una lista con la misma estructura que tienen los datos en el archivo


            //El nombre del archivo a utilizar
            string archivo = Server.MapPath("Datos.json");

            //Se abre el archivo
            StreamReader jsonStream = File.OpenText(archivo);

            //Se Lee todo el contenido del archivo y el contenido leído se guarda en una variable cualquiera de tipo string.
            //aquí no se necesitan ciclos pues el método ReadToEnd() lee todo el contenido de una sola vez.
            string json = jsonStream.ReadToEnd();

            //Se cierra el archivo
            jsonStream.Close();

            //Se deserializa (convierte) la cadena json guardada en la variable, en la estructura que tiene la lista a donde se van a cargar los datos
            Productos = JsonConvert.DeserializeObject<List<Producto>>(json);
        }
    }
}