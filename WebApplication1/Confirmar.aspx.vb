
Imports AccesoDatosSQL.accesodatosSQL

Public Class ConfirmAccount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtMail.Text = Request.QueryString("mbr")
        txtCod.Text = Request.QueryString("numConf")
    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim res As String

        res = confirmarUsuario(txtMail.Text, txtCod.Text)

        If res = "OK" Then

            Label1.Text = "Cuenta confirmada con exito"

        End If

        If res = "Error" Then

            Label1.Text = "Ha habido un error"

        End If

        If res = "0" Then

            Label1.Text = "No hay coincidencias"

        Else

            Label1.Text = res

        End If


    End Sub

End Class