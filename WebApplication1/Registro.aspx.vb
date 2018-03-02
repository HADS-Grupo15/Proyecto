Imports AccesoDatosSQL.accesodatosSQL

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        conectar()

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim numConf As Integer

        numConf = myrandomize()

        Dim res = insertar(txtmail.Text, txtNom.Text, txtApe.Text, txtApe2.Text, numConf, rol.Text, txtPass.Text)

        txtConfirmar.Text = res

        cerrarconexion()

        enviarEmail(txtmail.Text, numConf, "Enlace de confirmación para registro", "Confirmar")

        'Se queda bloqueado. Se accederá mediante el link enviado al mail
        'Response.Redirect("Confirmar.aspx")

    End Sub

End Class