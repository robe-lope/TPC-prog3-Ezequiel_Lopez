using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller
{
    public partial class ResetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string token = Request.QueryString["token"];
                if (string.IsNullOrEmpty(token))
                {
                    MostrarError("Link inválido.");
                    return;
                }

                var negocio = new UsuarioNegocio();
                var usuario = negocio.GetByToken(token);
                if (usuario == null)
                {
                    MostrarError("El link expiró o es inválido. Solicitá uno nuevo.");
                    return;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string token = Request.QueryString["token"];
            var negocio = new UsuarioNegocio();
            var usuario = negocio.GetByToken(token);

            if (usuario == null)
            {
                MostrarError("El link expiró. Solicitá uno nuevo.");
                return;
            }

            negocio.ActualizarPassword(usuario.IdUsuario, txtPassword.Text.Trim());

            panelForm.Visible = false;
            lblMensaje.CssClass = "alert alert-success d-block";
            lblMensaje.Text = "✅ Contraseña actualizada correctamente. Ya podés <a href='Login.aspx'>iniciar sesión</a>.";
            lblMensaje.Visible = true;
        }

        private void MostrarError(string mensaje)
        {
            panelForm.Visible = false;
            lblMensaje.CssClass = "alert alert-danger d-block";
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;
        }
    }
}