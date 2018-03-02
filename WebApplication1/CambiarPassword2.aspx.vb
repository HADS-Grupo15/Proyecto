
Imports AccesoDatosSQL.accesodatosSQL

Public Class PassChange2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCod.Text = Request.QueryString("numConf")
    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        'El email es nulo si no se accede mediante enlace
        cambiarPass(txtCod.Text, Request.QueryString("mbr"), txtPassw.Text)


    End Sub
End Class