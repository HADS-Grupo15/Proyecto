Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class accesodatosSQL

    Private Shared conexion As New SqlConnection

    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String

        Try

            conexion.ConnectionString = "Server=tcp:hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;User ID=opalomo001;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

            conexion.Open()

        Catch ex As Exception

            Return "ERROR DE CONEXIÓN: " + ex.Message

        End Try

        Return "CONEXION OK"

    End Function

    Public Shared Function myrandomize() As Integer

        Randomize()
        Dim NumConf As Integer = CLng(Rnd() * 9000000) + 1000000

        Return NumConf

    End Function

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellido1 As String,
                                    ByVal apellido2 As String, ByVal numconfir As Integer,
                                    ByVal tipo As String, ByVal pass As String) As String


        Dim st = "insert into Usuarios (email,nombre,apellido1,apellido2,numconfir,confirmado,tipo,pass) values (
        
        '" & email & "',
        '" & nombre & "',
        '" & apellido1 & "',
        '" & apellido2 & "',
        '" & numconfir & "',
        '0',
        '" & tipo & "',
        '" & pass & "'
        )"

        Dim numregs As Integer

        comando = New SqlCommand(st, conexion)

        Try

            numregs = comando.ExecuteNonQuery()

        Catch ex As Exception

            Return ex.Message

        End Try

        Return (numregs & "registro(s) insertado(s) en la BD")

    End Function

    Public Shared Function comprobarUsuario(ByVal email As String, ByVal password As String) As String

        cerrarconexion()

        conectar()

        Dim st = "select * from Usuarios where email='" & email & "'"

        comando = New SqlCommand(st, conexion)

        If comando.ExecuteNonQuery() = 0 Then

            Return "No registrado"

        End If

        st = "select count(*) from Usuarios where email='" & email & "' AND pass='" & password & "'AND confirmado='" & True & "' "

        comando = New SqlCommand(st, conexion)

        If comando.ExecuteScalar > 0 Then

            Return "1"

        Else

            Return "0"

        End If

    End Function

    Public Shared Function getCodigoConfirUsuario(ByVal email As String) As Integer
        cerrarconexion()

        If (conectar() IsNot "CONEXION OK") Then

            Return "Error"

        End If

        Dim st As String

        'Como conseguir el codigo confirmacion del unico usuario que deberia devolver la consulta
        st = "SELECT * FROM USUARIOS WHERE email='" & email & "'"

    End Function

    Public Shared Function confirmarUsuario(ByVal email As String, ByVal numconf As String) As String

        Try
            Dim st As String

            Dim numregs As Integer

            cerrarconexion()

            If (conectar() IsNot "CONEXION OK") Then

                Return "Error"

            End If

            st = "UPDATE Usuarios SET confirmado=1 WHERE email='" & email & "' AND numconfir='" & numconf & "' AND confirmado=0 "

            comando = New SqlCommand(st, conexion)

            numregs = comando.ExecuteNonQuery()

            cerrarconexion()

            If numregs = 0 Then

                Return "0"

            Else

                Return "OK"

            End If

        Catch ex As Exception

            Return ex.Message

        End Try

    End Function

    Public Shared Function enviarEmail(ByVal email_to As String, ByVal numconf As Integer, ByVal subject As String, ByVal nombre_pagina As String) As Boolean
        Try
            'Direccion de origen
            Dim email_from As String = "opalomo001@ikasle.ehu.eus"
            Dim from_name As String = "HADS15_OscarAxel"
            Dim from_address As New MailAddress(email_from, from_name)
            'Direccion de destino
            Dim to_address As New MailAddress(email_to)
            'Password de la cuenta
            Dim from_pass As String = "Freetanga69"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ehu.es"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = subject
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "http://localhost:60975/" & nombre_pagina & ".aspx?mbr=" & email_to & "&numconf=" & numconf & "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function

    Public Shared Function cambiarPass(ByVal numconfir As String, email As String, ByVal newpass As String) As String

        conectar()

        Try
            Dim st As String

            st = "SELECT * FROM USUARIOS WHERE email='" & email & "' and numconfir='" & numconfir & "'"

            comando = New SqlCommand(st, conexion)

            If comando.ExecuteNonQuery = 0 Then

                Return "0 coincidencias"

            End If

            Dim numregs As Integer

            st = "UPDATE Usuarios SET pass='" & newpass & "' WHERE email='" & email & "' AND numconfir='" & numconfir & "'"

            comando = New SqlCommand(st, conexion)

            If comando.ExecuteNonQuery() = 0 Then

                Return "No se ha podido cambiar el pass"

            Else

                Return "OK"

            End If

        Catch ex As Exception

            Return False

        End Try

    End Function

    Public Shared Sub cerrarconexion()

        conexion.Close()

    End Sub

End Class
