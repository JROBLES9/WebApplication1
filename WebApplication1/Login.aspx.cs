using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string usuario = Login1.UserName;
            string password = Login1.Password;


            //En el proyecto final,  para esta comparación, deberá ir a buscar si el usuario y password están almacenados en un archivo JSON de usuarios.  
            if ((usuario == "ABC") && (password == "123"))//permite que ingrese el usuario
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now,
                DateTime.Now.AddMinutes(30), Login1.RememberMeSet, "2");//cambiar el valor del nivel " ACA ADENTRO"
                cookiestr = FormsAuthentication.Encrypt(tkt);//encripta la cookie
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr); //guarda la cookie
                if (Login1.RememberMeSet)
                    ck.Expires = tkt.Expiration;//hace que el recuerde al usuario
                ck.Path = FormsAuthentication.FormsCookiePath; //indica la dirección de la cookie
                Response.Cookies.Add(ck);//se guarda la cookie

                string strRedirect;//redireccióna a una pagina
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null )
                    strRedirect = "Default.aspx";
                Response.Redirect(strRedirect, true);
            }
        }
    }
}