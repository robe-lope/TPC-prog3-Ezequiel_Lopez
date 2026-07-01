using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Admin
{
    public partial class Repuestos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Negocio.Seguridad.EsMecanico())
                Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                CargarDropDowns();
                CargarGrilla();
            }
        }

        private void CargarDropDowns()
        {
            var marcaNegocio = new MarcaRepuestoNegocio();
            ddlMarca.DataSource = marcaNegocio.Listar();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione --", "0"));

            ddlFiltroMarca.DataSource = marcaNegocio.Listar();
            ddlFiltroMarca.DataTextField = "Nombre";
            ddlFiltroMarca.DataValueField = "IdMarca";
            ddlFiltroMarca.DataBind();
            ddlFiltroMarca.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Todas las marcas --", "0"));

            var categoriaNegocio = new CategoriaRepuestoNegocio();
            ddlCategoria.DataSource = categoriaNegocio.Listar();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione --", "0"));
        }

        private void CargarGrilla(int idMarca = 0)
        {
            var negocio = new RepuestoNegocio();
            if (idMarca == 0) 
            { 
                gvRepuestos.DataSource = negocio.Listar();
            }
            else 
            {
                gvRepuestos.DataSource = negocio.FiltrarPorMarca(idMarca);
            }
            gvRepuestos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var repuesto = new Repuesto();
                repuesto.IdRepuesto = int.Parse(hfId.Value);
                repuesto.Codigo = txtCodigo.Text.Trim();
                repuesto.Descripcion = txtDescripcion.Text.Trim();
                repuesto.PrecioCompra = decimal.Parse(txtPrecioCompra.Text.Trim());
                repuesto.PrecioVenta = decimal.Parse(txtPrecioVenta.Text.Trim());
                repuesto.StockActual = int.Parse(txtStockActual.Text.Trim());
                repuesto.StockMinimo = int.Parse(txtStockMinimo.Text.Trim());
                repuesto.Marca = new MarcaRepuesto { IdMarca = int.Parse(ddlMarca.SelectedValue) };
                repuesto.Categoria = new Dominio.CategoriaRepuesto { IdCategoria = int.Parse(ddlCategoria.SelectedValue) };

                var negocio = new RepuestoNegocio();
                if (repuesto.IdRepuesto == 0)
                    negocio.Agregar(repuesto);
                else
                    negocio.Modificar(repuesto);

                LimpiarForm();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new RepuestoNegocio();
            var repuesto = negocio.Listar().Find(r => r.IdRepuesto == id);
            if (repuesto != null)
            {
                hfId.Value = repuesto.IdRepuesto.ToString();
                txtCodigo.Text = repuesto.Codigo;
                txtDescripcion.Text = repuesto.Descripcion;
                txtPrecioCompra.Text = repuesto.PrecioCompra.ToString();
                txtPrecioVenta.Text = repuesto.PrecioVenta.ToString();
                txtStockActual.Text = repuesto.StockActual.ToString();
                txtStockMinimo.Text = repuesto.StockMinimo.ToString();
                CargarDropDowns();
                ddlMarca.SelectedValue = repuesto.Marca.IdMarca.ToString();
                ddlCategoria.SelectedValue = repuesto.Categoria.IdCategoria.ToString();
                lblTitulo.Text = "Editar Repuesto";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new RepuestoNegocio();
            negocio.Eliminar(id);
            CargarGrilla();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(int.Parse(ddlFiltroMarca.SelectedValue));
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlFiltroMarca.SelectedIndex = 0;
            CargarGrilla();
        }

        private void LimpiarForm()
        {
            hfId.Value = "0";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStockActual.Text = "";
            txtStockMinimo.Text = "";
            lblTitulo.Text = "Nuevo Repuesto";
            CargarDropDowns();
        }
    }
}