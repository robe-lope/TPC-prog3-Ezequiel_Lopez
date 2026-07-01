using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller
{
    public partial class OlvideMiPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            var negocio = new UsuarioNegocio();
            var usuario = negocio.GetByEmail(txtEmail.Text.Trim());

            
            lblMensaje.CssClass = "alert alert-success d-block mb-3";
            lblMensaje.Text = "Si el email existe, te va a llegar un link para restablecer tu contraseña.";
            lblMensaje.Visible = true;
            btnEnviar.Visible = false;
            txtEmail.Visible = false;

            if (usuario != null)
            {
                string token = Guid.NewGuid().ToString();
                DateTime expiracion = DateTime.Now.AddHours(1);

                negocio.GuardarToken(usuario.IdUsuario, token, expiracion);

                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority;
                var mail = new MailNegocio();
                mail.EnviarMailRecuperacion(usuario.Email, usuario.Nombre, token, baseUrl);
            }
        }
    }
}
