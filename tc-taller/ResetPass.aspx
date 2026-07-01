<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPass.aspx.cs" Inherits="tc_taller.ResetPass" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Restablecer contraseña — Taller Mecánico</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center mt-5">
                <div class="col-md-4">
                    <div class="card shadow p-4">
                        <h3 class="text-center mb-2">🔧 Taller Mecánico</h3>
                        <h5 class="text-center text-muted mb-4">Nueva contraseña</h5>

                        <asp:Label ID="lblMensaje" runat="server" Visible="false" />

                        <div id="panelForm" runat="server">
                            <div class="mb-3">
                                <label class="form-label">Nueva contraseña *</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="La contraseña es requerida." CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Repetir contraseña *</label>
                                <asp:TextBox ID="txtConfirmar" runat="server" CssClass="form-control" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmar"
                                    ErrorMessage="Repetí la contraseña." CssClass="text-danger" Display="Dynamic" />
                                <asp:CompareValidator runat="server" 
                                    ControlToValidate="txtConfirmar" ControlToCompare="txtPassword"
                                    ErrorMessage="Las contraseñas no coinciden." CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar nueva contraseña"
                                CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
                        </div>

                        <div class="text-center mt-3">
                            <a href="Login.aspx" class="text-muted" style="font-size:0.9rem;">← Volver al login</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
