Imports Entidades
Imports System.Configuration
Imports System.Data.SqlClient
Imports Excepciones
Imports System.Transactions

Public Class UsuarioAD

    Public Shared Function AltaPatenteUsuario(ByVal CodUsu As Integer, ByVal PatUsu As PatUsuEN) As Boolean
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidarActivo As String = "SELECT COUNT(*) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1" & _
                                                    " AND Patente_CodPat=@Param2 AND Activo=0"
            Dim CmdValidar As New SqlCommand(ConsultaValidarActivo, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", CodUsu)
            CmdValidar.Parameters.AddWithValue("@Param2", PatUsu.CodPat)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()


            If Resultado > 0 Then
                Dim ConsultaModificar As String = "UPDATE Usu_Pat SET Activo=1 WHERE Usuario_CodUsu=@Param1" & _
                                                    " AND Patente_CodPat=@Param2"
                Dim CmdModificar As New SqlCommand(ConsultaModificar, Cnn)
                CmdModificar.Parameters.AddWithValue("@Param1", CodUsu)
                CmdModificar.Parameters.AddWithValue("@Param2", PatUsu.CodPat)

                CmdModificar.ExecuteNonQuery()
                Return False
            Else
                Dim ConsultaAlta As String = "INSERT INTO Usu_Pat(Usuario_CodUsu,Patente_CodPat,Activo,DVH)" & _
                                            "VALUES(@CodUsu,@CodPat,1,0)"
                Dim Cmd As New SqlCommand(ConsultaAlta, Cnn)
                Cmd.Parameters.AddWithValue("@CodUsu", CodUsu)
                Cmd.Parameters.AddWithValue("@CodPat", PatUsu.CodPat)

                Cmd.ExecuteNonQuery()
                Return True
            End If
        End Using
    End Function


    Public Shared Sub AltaUsuario(ByVal Usuario As UsuarioEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaUsuario As String = "INSERT INTO Usuario(Idioma_CodIdioma," & _
                                                "Usuario,Contraseña,Apellido,Nombre,CorreoElectronico," & _
                                                    "FechaNacimiento,CII,Activo,Bloqueado,DVH)" & _
                                            "VALUES(@Idioma_CodIdioma,@Usuario,@Contraseña" & _
                                                        ",@Apellido,@Nombre,@CorreoElectronico,@FechaNacimiento" & _
                                                            ",0,1,0,0) " & _
                                            "SELECT SCOPE_IDENTITY()"

            Dim Cmd As New SqlCommand(ConsultaUsuario, Cnn)

            Cmd.Parameters.AddWithValue("@Idioma_CodIdioma", Usuario.CodIdioma)
            Cmd.Parameters.AddWithValue("@Usuario", Usuario.Usuario)
            Cmd.Parameters.AddWithValue("@Contraseña", Usuario.Contraseña)
            Cmd.Parameters.AddWithValue("@Apellido", Usuario.Apellido)
            Cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre)
            Cmd.Parameters.AddWithValue("@CorreoElectronico", Usuario.CorreoElectronico)
            Cmd.Parameters.AddWithValue("@FechaNacimiento", Usuario.FechaNacimiento)

            Dim CodigoUsuarioNuevo As Integer = Cmd.ExecuteScalar()

            Usuario.CodUsu = CodigoUsuarioNuevo

            For Each Telefono As TelefonoEN In Usuario.Telefono
                NegocioAD.AltaTelefono(CodigoUsuarioNuevo, Telefono, "Tel_Usu")
            Next
        End Using
    End Sub


    Public Shared Function AltaUsuarioFamilia(ByVal Codigo As Integer, ByVal UsuarioFamilia As UsuFamEN) As Boolean
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExistePat As String = "SELECT COUNT(*) FROM Fam_Pat WHERE Familia_CodFam=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExistePat, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", UsuarioFamilia.CodFam)
            Dim Existe As Integer = CmdExiste.ExecuteScalar()

            If Existe > 0 Then
                Dim ConsultaAlta As String = "INSERT INTO Usu_Fam(Usuario_CodUsu,Familia_CodFam,DVH)" & _
                                            "VALUES(@Param1,@Param2,0)"
                Dim Cmd As New SqlCommand(ConsultaAlta, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Codigo)
                Cmd.Parameters.AddWithValue("@Param2", UsuarioFamilia.CodFam)

                Cmd.ExecuteNonQuery()
                Return True
            Else
                Return False
            End If

        End Using
    End Function

    Public Shared Function AltaPatUsuDesdeFam(CodUsu As Integer, CodPat As Integer) As Boolean
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2"
            Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodUsu)
            Cmd.Parameters.AddWithValue("@Param2", CodPat)
            Dim Resultado As Integer = Cmd.ExecuteScalar()

            If Resultado > 0 Then
                Return False
            Else
                Dim ConsultaAltaPer As String = "INSERT INTO Usu_Pat(Usuario_CodUsu,Patente_CodPat,Activo,DVH)" & _
                                                "VALUES(@Param1,@Param2,1,0)"
                Dim CmdAltaPer As New SqlCommand(ConsultaAltaPer, Cnn)
                CmdAltaPer.Parameters.AddWithValue("@Param1", CodUsu)
                CmdAltaPer.Parameters.AddWithValue("@Param2", CodPat)

                CmdAltaPer.ExecuteNonQuery()
                Return True
            End If
        End Using
    End Function


    Public Shared Sub BajaUsuario(ByVal Usuario As UsuarioEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            'Consultar SI Existe
            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Activo=1 AND CodUsu=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Usuario.CodUsu)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                'Baja de Usuario
                Dim ConsultaBaja As String = "UPDATE Usuario SET Activo=0 WHERE CodUsu=@Param1"
                Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Usuario.CodUsu)

                Cmd.ExecuteNonQuery()
            End If
        End Using
    End Sub


    Public Shared Sub BloquearUsuario(ByVal Usuario As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaUsuario As String = "UPDATE Usuario SET Bloqueado=1 WHERE Usuario=@Param1"
            Dim Cmd As New SqlCommand(ConsultaUsuario, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario)

            Cmd.ExecuteNonQuery()
        End Using
    End Sub


    Public Shared Function BuscarUsuario(ByVal campo As String, ByVal texto As String) As List(Of UsuarioEN)
        Dim ListaUsuarios As New List(Of UsuarioEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cnn
            Select Case campo
                Case My.Resources.ArchivoIdioma.CMBUsuario
                    Cmd.CommandText = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT) " & _
                                    "FROM Usuario WHERE Usuario=@Param1 AND Activo=1"
                Case My.Resources.ArchivoIdioma.CMBApellido
                    Cmd.CommandText = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT) " & _
                                        "FROM Usuario WHERE Apellido LIKE '%' + @Param1 + '%' AND Activo=1"
                Case My.Resources.ArchivoIdioma.CMBNombre
                    Cmd.CommandText = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT) " & _
                                        "FROM Usuario WHERE Nombre LIKE '%' + @Param1 + '%' AND Activo=1"
            End Select

            Cmd.Parameters.AddWithValue("@Param1", texto)

            Dim Lector As SqlDataReader
            Lector = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnUsuario As New UsuarioEN

                UnUsuario.CodUsu = Lector(0)
                UnUsuario.Usuario = Lector(1)
                UnUsuario.Apellido = Lector(2)
                UnUsuario.Nombre = Lector(3)
                UnUsuario.CorreoElectronico = Lector(4)
                UnUsuario.Edad = Lector(5)

                ListaUsuarios.Add(UnUsuario)
            End While
        End Using

        Return ListaUsuarios
    End Function

    Public Shared Sub CambiarContraseña(ByVal Usuario As String, ByVal NuevaContraseña As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Usuario)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                Dim ConsultaContraseña As String = "UPDATE Usuario SET Contraseña=@Param1 WHERE Usuario=@Param2"
                Dim Cmd As New SqlCommand(ConsultaContraseña, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", NuevaContraseña)
                Cmd.Parameters.AddWithValue("@Param2", Usuario)
                Cmd.ExecuteNonQuery()
            End If
        End Using
    End Sub

    Public Shared Function CargarUsuario() As List(Of UsuarioEN)
        Dim ListaUsuarios As New List(Of UsuarioEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaUsuarios As String = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT),Bloqueado" & _
                                            " FROM Usuario WHERE Activo=1"
            Dim Cmd As New SqlCommand(ConsultaUsuarios, Cnn)

            Dim Lector As SqlDataReader
            Lector = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnUsuario As New UsuarioEN
                UnUsuario.CodUsu = Lector(0)
                UnUsuario.Usuario = Lector(1)
                UnUsuario.Apellido = Lector(2)
                UnUsuario.Nombre = Lector(3)
                UnUsuario.CorreoElectronico = Lector(4)
                UnUsuario.Edad = Lector(5)
                UnUsuario.Bloqueado = Lector(6)

                ListaUsuarios.Add(UnUsuario)
            End While

        End Using

        Return ListaUsuarios
    End Function


    Public Shared Sub DenegarPatenteUsuario(ByVal Codigo As Integer, ByVal PatUsu As PatUsuEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2"
            Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", Codigo)
            CmdValidar.Parameters.AddWithValue("@Param2", PatUsu.CodPat)
            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado > 0 Then
                Dim ConsultaBaja As String = "UPDATE Usu_Pat SET Activo=0 WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2"
                Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Codigo)
                Cmd.Parameters.AddWithValue("@Param2", PatUsu.CodPat)
                Cmd.ExecuteNonQuery()
            Else
                Dim ConsultaAlta As String = "INSERT INTO Usu_Pat(Usuario_CodUsu,Patente_CodPat,Activo,DVH)" & _
                                            "VALUES(@CodUsu,@CodPat,0,0)"
                Dim Cmd As New SqlCommand(ConsultaAlta, Cnn)
                Cmd.Parameters.AddWithValue("@CodUsu", Codigo)
                Cmd.Parameters.AddWithValue("@CodPat", PatUsu.CodPat)

                Cmd.ExecuteNonQuery()
            End If

        End Using
    End Sub


    Public Shared Sub DesbloquearUsuario(ByVal Usuario As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Usuario)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                Dim ConsultaValidarActivo As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Bloqueado=1"
                Dim CmdValidar As New SqlCommand(ConsultaValidarActivo, Cnn)
                CmdValidar.Parameters.AddWithValue("@Param1", Usuario)
                Dim ResultadoValidar As Integer = CmdValidar.ExecuteScalar()

                If ResultadoValidar > 0 Then
                    Dim ConsultaDesbloquear As String = "UPDATE Usuario SET Bloqueado=0,CII=0 WHERE Usuario=@Param1"
                    Dim Cmd As New SqlCommand(ConsultaDesbloquear, Cnn)
                    Cmd.Parameters.AddWithValue("@Param1", Usuario)

                    Cmd.ExecuteNonQuery()
                Else
                    Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioNoBloqueado)
                End If
            End If
        End Using
    End Sub


    Public Shared Sub EliminarTelefonoUsuario(ByVal UnTelefono As TelefonoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidarTel As String = "SELECT COUNT(*) FROM Tel_Usu WHERE CodTel=@Param1 AND Usuario_CodUsu=@Param2"
            Dim CmdValidar As New SqlCommand(ConsultaValidarTel, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", UnTelefono.CodTel)
            CmdValidar.Parameters.AddWithValue("@Param2", UnTelefono.CodEn)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado > 0 Then
                Dim ConsultaEliminarTel As String = "DELETE FROM Tel_Usu WHERE CodTel=@Param1 AND Usuario_CodUsu=@Param2"
                Dim Cmd As New SqlCommand(ConsultaEliminarTel, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", UnTelefono.CodTel)
                Cmd.Parameters.AddWithValue("@Param2", UnTelefono.CodEn)
                Cmd.ExecuteNonQuery()
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.NumeroTelefonoNoExiste)
            End If
        End Using
    End Sub


    Public Shared Function Logueo(ByVal Usuario As UsuarioEN) As Boolean
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaLogueo As String = "SELECT COUNT(*) FROM Usuario " & _
                                            "WHERE Usuario=@Param1 AND Contraseña=@Param2"
            Dim Cmd As New SqlCommand(ConsultaLogueo, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario.Usuario)
            Cmd.Parameters.AddWithValue("@Param2", Usuario.Contraseña)

            Dim Resultado As Integer = Cmd.ExecuteScalar()

            If Resultado > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function


    Public Shared Sub ModificarCIIUsuario(ByVal Usuario As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaCII As String = "UPDATE Usuario SET CII +=1 WHERE Usuario=@Param1"
            Dim Cmd As New SqlCommand(ConsultaCII, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario)

            Cmd.ExecuteNonQuery()
        End Using
    End Sub


    Public Shared Sub ModificarUsuario(ByVal Usuario As UsuarioEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Usuario)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                Dim ConsultaIDUsuario As String = "SELECT CodUsu FROM Usuario WHERE Usuario=@Usuario"
                Dim CmdIDUsuario As New SqlCommand(ConsultaIDUsuario, Cnn)
                CmdIDUsuario.Parameters.AddWithValue("@Usuario", Usuario.Usuario)

                Dim CodigoUsuario As Integer = CmdIDUsuario.ExecuteScalar()

                Dim ConsultaModificar As String = "UPDATE Usuario SET Idioma_CodIdioma=@Param1,Apellido=@Param2," & _
                                                    "Nombre=@Param3, FechaNacimiento=@Param6 WHERE Usuario=@Param4 AND CodUsu=@Param5"

                Dim Cmd As New SqlCommand(ConsultaModificar, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Usuario.CodIdioma)
                Cmd.Parameters.AddWithValue("@Param2", Usuario.Apellido)
                Cmd.Parameters.AddWithValue("@Param3", Usuario.Nombre)
                Cmd.Parameters.AddWithValue("@Param4", Usuario.Usuario)
                Cmd.Parameters.AddWithValue("@Param5", CodigoUsuario)
                Cmd.Parameters.AddWithValue("@Param6", Usuario.FechaNacimiento)
                Cmd.ExecuteNonQuery()

                For Each Telefono As TelefonoEN In Usuario.Telefono
                    NegocioAD.ModificarTelefono(CodigoUsuario, Telefono, "Tel_Usu")
                Next
            End If
        End Using
    End Sub


    Public Shared Function ObtenerCIIUsuario(ByVal Usuario As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExisUsuariosBD As String = "SELECT COUNT(*) FROM Usuario"
            Dim CmdExisteUsuariosBD As New SqlCommand(ConsultaExisUsuariosBD, Cnn)
            Dim ResultadoBD As Integer = CmdExisteUsuariosBD.ExecuteScalar()

            If ResultadoBD > 0 Then
                Dim ConsultaExisteUsuario As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1"
                Dim Cmd As New SqlCommand(ConsultaExisteUsuario, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Usuario)
                Dim Resultado As Integer = Cmd.ExecuteScalar()

                If Resultado > 0 Then
                    Dim ConsultaBloqueadoUsuario As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param2 AND Bloqueado=1"
                    Dim CmdBloqueado As New SqlCommand(ConsultaBloqueadoUsuario, Cnn)
                    CmdBloqueado.Parameters.AddWithValue("@Param2", Usuario)
                    Dim ResultadoBloqueado As Integer = CmdBloqueado.ExecuteScalar()

                    If ResultadoBloqueado > 0 Then
                        Throw New CriticalException(My.Resources.ArchivoIdioma.UsuarioBloqueado)
                    Else
                        Dim ConsultaCII As String = "SELECT CII FROM Usuario WHERE Usuario=@Param3"
                        Dim CmdCii As New SqlCommand(ConsultaCII, Cnn)
                        CmdCii.Parameters.AddWithValue("@Param3", Usuario)
                        Dim CII As Integer = CmdCii.ExecuteScalar()
                        Return CII
                    End If
                Else
                    Throw New CriticalException(My.Resources.ArchivoIdioma.UsuarioNoExiste)
                End If
            Else
                Throw New CriticalException(My.Resources.ArchivoIdioma.NoExistenUsuariosBD)
            End If
        End Using
    End Function


    Public Shared Function ObtenerIDUsuario(ByVal Usuario As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Usuario)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                Dim ConsultaUsuario As String = "SELECT CodUsu FROM Usuario WHERE Usuario=@Param1 AND Activo=1"
                Dim Cmd As New SqlCommand(ConsultaUsuario, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Usuario)

                Dim Codigo As Integer = Cmd.ExecuteScalar()

                Return Codigo
            End If
        End Using
    End Function


    Public Shared Function ObtenerTelefonoUsuario(ByVal Codigo As Integer) As List(Of TelefonoEN)
        Dim ListaTelefonos As New List(Of TelefonoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Activo=1 AND CodUsu=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Codigo)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                Dim ConsultaTelUsuario As String = "SELECT CodTel,Usuario_CodUsu,Numero " & _
                                    "FROM Tel_Usu WHERE Usuario_CodUsu = @Param1"
                Dim Cmd As New SqlCommand(ConsultaTelUsuario, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Codigo)
                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnTelefono As New TelefonoEN
                    UnTelefono.CodTel = Lector(0)
                    UnTelefono.CodEn = Lector(1)
                    UnTelefono.Numero = Lector(2)

                    ListaTelefonos.Add(UnTelefono)
                End While

                Return ListaTelefonos
            End If
        End Using
    End Function


    Public Shared Function ObtenerUsuario(ByVal Codigo As Integer) As UsuarioEN
        Dim Usuario As New UsuarioEN
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Activo=1 AND CodUsu=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Codigo)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                Dim ConsultaUsuario As String = "SELECT CodUsu,Idioma_CodIdioma,Usuario,Apellido,Nombre,CorreoElectronico,FechaNacimiento,Activo " & _
                                            "FROM Usuario WHERE CodUsu=@Param1"

                Dim Cmd As New SqlCommand(ConsultaUsuario, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Codigo)

                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Usuario.CodUsu = Lector(0)
                    Usuario.CodIdioma = Lector(1)
                    Usuario.Usuario = Lector(2)
                    Usuario.Apellido = Lector(3)
                    Usuario.Nombre = Lector(4)
                    Usuario.CorreoElectronico = Lector(5)
                    Usuario.FechaNacimiento = Lector(6)
                    Usuario.Activo = Lector(7)
                End While

                Return Usuario
            End If
        End Using
    End Function

    Public Shared Sub ResetearCII(ByVal Usuario As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaCII As String = "UPDATE Usuario SET CII = 0 WHERE Usuario=@Param1"
            Dim Cmd As New SqlCommand(ConsultaCII, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario)
            Cmd.ExecuteNonQuery()
        End Using
    End Sub


    Public Shared Function ValidarContraseña(ByVal Usuario As String, ByVal ContraseñaAnterior As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Contraseña=@Param2"
            Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario)
            Cmd.Parameters.AddWithValue("@Param2", ContraseñaAnterior)

            Dim Resultado As Integer = Cmd.ExecuteScalar()

            Return Resultado
        End Using
    End Function


    Public Shared Function ValidarUsuario(ByVal Usuario As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaExisteUsuario As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1"
            Dim Cmd As New SqlCommand(ConsultaExisteUsuario, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario)

            Dim Resultado As Integer = Cmd.ExecuteScalar()

            Return Resultado
        End Using
    End Function


    Public Shared Function ValidarUsuFam(ByVal Codigo As Integer, ByVal UsuFam As UsuFamEN) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2"
            Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Codigo)
            Cmd.Parameters.AddWithValue("@Param2", UsuFam.CodFam)
            Dim Resultado As Integer = Cmd.ExecuteScalar()

            Return Resultado
        End Using
    End Function

    Public Shared Sub ResetearContraseña(Usuario As UsuarioEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=0"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Usuario.Usuario)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado > 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            Else
                Dim Consulta As String = "UPDATE Usuario SET Contraseña=@Param1 WHERE Usuario=@Param2"
                Dim Cmd As New SqlCommand(Consulta, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Usuario.Contraseña)
                Cmd.Parameters.AddWithValue("@Param2", Usuario.Usuario)

                Cmd.ExecuteNonQuery()
            End If
        End Using
    End Sub

    Public Shared Function VerificarPatentesUsuario(CodPat As Integer) As Boolean
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Consulta As String = "SELECT COUNT(*) AS CNT " & _
                                        "FROM ( " & _
                                        " " & _
                                        "SELECT U.CodUsu " & _
                                        "FROM Usuario AS U INNER JOIN Usu_Pat AS UP ON U.CodUsu = UP.Usuario_CodUsu " & _
                                        "WHERE UP.Patente_CodPat = @Param1 and UP.Activo = 1 " & _
                                        " " & _
                                        "UNION " & _
                                        " " & _
                                        "SELECT UF.Usuario_CodUsu AS CodUsu " & _
                                        "FROM Usu_Fam AS UF inner join Familia AS F ON UF.Familia_CodFam = F.CodFam " & _
                                        "INNER JOIN Fam_Pat AS FP ON FP.Familia_CodFam = f.CodFam " & _
                                        "WHERE FP.Patente_CodPat = @Param1 " & _
                                        " " & _
                                        ") AS T "
                                        
            Dim Cmd As New SqlCommand(Consulta, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodPat)
            Dim CantidadUsuarios As Integer = CInt(Cmd.ExecuteScalar())

            If CantidadUsuarios > 1 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Public Shared Function ObtenerUsuariosErrorIntegridad() As List(Of String)
        Dim ListaUsuarios As New List(Of String)
        Dim Usuario As String
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Consulta As String = "SELECT DISTINCT U.Usuario " & _
                                     "FROM Usuario U " & _
                                     "INNER JOIN Usu_Pat UP ON U.CodUsu = UP.Usuario_CodUsu " & _
                                     "WHERE U.Usuario IN (SELECT U1.Usuario From Usuario U1 INNER JOIN Usu_Pat UP1 ON U1.CodUsu = UP1.Usuario_CodUsu WHERE UP1.Activo=1 AND (UP1.Patente_CodPat = 32 OR UP1.Patente_CodPat = 39))"
            Dim Cmd As New SqlCommand(Consulta, Cnn)
            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Usuario = Lector(0)
                ListaUsuarios.Add(Usuario)
            End While

        End Using

        Return ListaUsuarios
    End Function

    Shared Function ObtenerPatentesUsuario(CodUsu As Integer) As List(Of PatUsuEN)
        Dim ListaPatUsu As New List(Of PatUsuEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaUsuFam As String = "SELECT Patente_CodPat FROM Usu_Pat WHERE Usuario_CodUsu=@Param1"
            Dim CmdUsuFam As New SqlCommand(ConsultaUsuFam, cnn)
            CmdUsuFam.Parameters.AddWithValue("@Param1", CodUsu)

            Dim Lector As SqlDataReader = CmdUsuFam.ExecuteReader()

            While Lector.Read()
                Dim UnaPatUsu As New PatUsuEN
                UnaPatUsu.CodUsu = CodUsu
                UnaPatUsu.CodPat = Lector(0)

                ListaPatUsu.Add(UnaPatUsu)
            End While

            Return ListaPatUsu
        End Using
    End Function

    Shared Sub EliminarPatentesUsuario(UnaPatUsu As PatUsuEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaPatUsu As String = "DELETE FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2"
            Dim CmdUsuPat As New SqlCommand(ConsultaPatUsu, cnn)
            CmdUsuPat.Parameters.AddWithValue("@Param1", UnaPatUsu.CodUsu)
            CmdUsuPat.Parameters.AddWithValue("@Param2", UnaPatUsu.CodPat)
            CmdUsuPat.ExecuteNonQuery()
        End Using
    End Sub

End Class ' UsuarioAD