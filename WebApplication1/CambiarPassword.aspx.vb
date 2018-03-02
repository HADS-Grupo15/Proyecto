Imports AccesoDatosSQL.accesodatosSQL
Public Class PassChange
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        Dim numConf As Integer
        numConf = myrandomize()
        enviarEmail(txtMail.Text, numConf, "Enlace para cambio de contraseña", "CambiarPassword2")
    End Sub
End Class