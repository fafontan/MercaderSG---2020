Imports Entidades
Imports System.Configuration
Imports System.Data.SqlClient
Imports Excepciones
Imports System.Transactions

Public Class ProveedorAD
    ''' 
    ''' <param name="Proveedor"></param>
    Public Shared Sub AltaProveedor(ByVal Proveedor As ProveedorEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaProveedor As String = "INSERT INTO Proveedor(Localidad_CodLoc,Cuit,RazonSocial," & _
                                                "CorreoElectronico,Calle,Numero,Piso,Departamento,Activo)" & _
                                              "VALUES(@Localidad_CodLoc,@Cuit,@RazonSocial," & _
                                                "@CorreoElectronico,@Calle,@Numero,@Piso,@Departamento,1) " & _
                                              "SELECT SCOPE_IDENTITY()"
            Dim Cmd As New SqlCommand(ConsultaProveedor, Cnn)

            Cmd.Parameters.AddWithValue("@Localidad_CodLoc", Proveedor.CodLoc)
            Cmd.Parameters.AddWithValue("@Cuit", Proveedor.Cuit)
            Cmd.Parameters.AddWithValue("@RazonSocial", Proveedor.RazonSocial)
            Cmd.Parameters.AddWithValue("@CorreoElectronico", Proveedor.CorreoElectronico)
            Cmd.Parameters.AddWithValue("@Calle", Proveedor.Calle)
            Cmd.Parameters.AddWithValue("@Numero", Proveedor.Numero)
            Cmd.Parameters.AddWithValue("@Piso", Proveedor.Piso)
            Cmd.Parameters.AddWithValue("@Departamento", Proveedor.Departamento)

            Dim CodProvNuevo As Integer = Cmd.ExecuteScalar()

            Proveedor.CodProv = CodProvNuevo

            For Each Telefono As TelefonoEN In Proveedor.Telefono
                NegocioAD.AltaTelefono(CodProvNuevo, Telefono, "Tel_Prov")
            Next
        End Using
    End Sub

    ''' 
    ''' <param name="Proveedor"></param>
    Public Shared Sub BajaProveedor(ByVal Proveedor As ProveedorEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Proveedor.CodProv)
            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProveedorEstaEliminado)
            Else
                Dim ConsultaBaja As String = "UPDATE Proveedor SET Activo=0 WHERE CodProv=@Param1"
                Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Proveedor.CodProv)

                Cmd.ExecuteNonQuery()
            End If
        End Using
    End Sub

    ''' 
    ''' <param name="campo"></param>
    ''' <param name="valor"></param>
    Public Shared Function BuscarProveedor(ByVal campo As String, ByVal valor As String) As List(Of ProveedorEN)
        Dim ListaProveedor As New List(Of ProveedorEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Cmd As New SqlCommand
            Cmd.Connection = Cnn

            Select Case campo
                Case My.Resources.ArchivoIdioma.CMBCuit
                    Cmd.CommandText = "SELECT CodProv,RazonSocial,Cuit,(Calle + ' ' + Numero) AS Direccion,Activo  " & _
                                       "FROM Proveedor WHERE Cuit=@Param1 AND Activo=1"
                Case My.Resources.ArchivoIdioma.CMBRazonSocial
                    Cmd.CommandText = "SELECT CodProv,RazonSocial,Cuit,(Calle + ' ' + Numero) AS Direccion,Activo  " & _
                                            "FROM Proveedor WHERE RazonSocial LIKE '%' + @Param1 + '%' AND Activo=1"
            End Select
            Cmd.Parameters.AddWithValue("@Param1", valor)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnProveedor As New ProveedorEN
                UnProveedor.CodProv = Lector(0)
                UnProveedor.RazonSocial = Lector(1)
                UnProveedor.Cuit = Lector(2)
                UnProveedor.Direccion = Lector(3)
                UnProveedor.Activo = Lector(4)

                ListaProveedor.Add(UnProveedor)
            End While

            Return ListaProveedor
        End Using
    End Function

    Public Shared Function CargarProveedor() As List(Of ProveedorEN)
        Dim ListaProveedor As New List(Of ProveedorEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCarga As String = "SELECT CodProv,RazonSocial,Cuit,CorreoElectronico,(Calle + ' ' + Numero) AS Direccion,Activo  " & _
                                            "FROM Proveedor WHERE Activo=1"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Dim Lector As SqlDataReader
            Lector = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnProveedor As New ProveedorEN
                UnProveedor.CodProv = Lector(0)
                UnProveedor.RazonSocial = Lector(1)
                UnProveedor.Cuit = Lector(2)
                UnProveedor.CorreoElectronico = Lector(3)
                UnProveedor.Direccion = Lector(4)
                UnProveedor.Activo = Lector(5)

                ListaProveedor.Add(UnProveedor)
            End While

            Return ListaProveedor
        End Using
    End Function

    Public Shared Sub EliminarTelefonoProveedor(ByVal UnTelefono As TelefonoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidarTel As String = "SELECT COUNT(*) FROM Tel_Prov WHERE CodTel=@Param1 AND Proveedor_CodProv=@Param2"
            Dim CmdValidar As New SqlCommand(ConsultaValidarTel, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", UnTelefono.CodTel)
            CmdValidar.Parameters.AddWithValue("@Param2", UnTelefono.CodEn)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado > 0 Then
                Dim ConsultaEliminarTel As String = "DELETE FROM Tel_Prov WHERE CodTel=@Param1 AND Proveedor_CodProv=@Param2"
                Dim Cmd As New SqlCommand(ConsultaEliminarTel, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", UnTelefono.CodTel)
                Cmd.Parameters.AddWithValue("@Param2", UnTelefono.CodEn)
                Cmd.ExecuteNonQuery()
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.NumeroTelefonoNoExiste)
            End If

            
        End Using
    End Sub

    ''' 
    ''' <param name="Proveedor"></param>
    Public Shared Sub ModificarProveedor(ByVal Proveedor As ProveedorEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim CodProv As Integer = Proveedor.CodProv

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", CodProv)
            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProveedorDadoBaja)
            Else
                Dim ConsultaModificar As String = "UPDATE Proveedor SET Localidad_CodLoc=@CodLoc,RazonSocial=@RazonSocial," & _
                                                "Cuit=@Cuit,CorreoElectronico=@Correo,Calle=@Calle,Numero=@Numero,Piso=@Piso,Departamento=@Dpto " & _
                                                    "WHERE CodProv=@CodProv"
                Dim Cmd As New SqlCommand(ConsultaModificar, Cnn)
                Cmd.Parameters.AddWithValue("@CodLoc", Proveedor.CodLoc)
                Cmd.Parameters.AddWithValue("@RazonSocial", Proveedor.RazonSocial)
                Cmd.Parameters.AddWithValue("@Cuit", Proveedor.Cuit)
                Cmd.Parameters.AddWithValue("@Correo", Proveedor.CorreoElectronico)
                Cmd.Parameters.AddWithValue("@Calle", Proveedor.Calle)
                Cmd.Parameters.AddWithValue("@Numero", Proveedor.Numero)
                Cmd.Parameters.AddWithValue("@Piso", Proveedor.Piso)
                Cmd.Parameters.AddWithValue("@Dpto", Proveedor.Departamento)
                Cmd.Parameters.AddWithValue("@CodProv", CodProv)

                Cmd.ExecuteNonQuery()

                For Each Telefono As TelefonoEN In Proveedor.Telefono
                    NegocioAD.ModificarTelefono(CodProv, Telefono, "Tel_Prov")
                Next

            End If
        End Using
    End Sub

    ''' 
    ''' <param name="CUIT"></param>
    Public Shared Function ObtenerIDProveedor(ByVal CUIT As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND Cuit=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", CUIT)
            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProveedorDadoBaja)
            Else
                Dim ConsultaID As String = "SELECT CodProv FROM Proveedor WHERE Cuit=@Param1 AND Activo=1"
                Dim Cmd As New SqlCommand(ConsultaID, Cnn)
                Cmd.Parameters.AddWithValue("Param1", CUIT)

                Dim CodPRov As Integer = Cmd.ExecuteScalar()

                Return CodPRov
            End If
        End Using
    End Function


    Public Shared Function ObtenerProveedor(ByVal CodProv As Integer) As ProveedorEN
        Dim Proveedor As New ProveedorEN

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", CodProv)
            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProveedorDadoBaja)
            Else
                Dim ConsultaCarga As String = "SELECT CodProv,Localidad_CodLoc,Cuit,RazonSocial,CorreoElectronico," & _
                                            "Calle,Numero,Piso,Departamento FROM Proveedor WHERE CodProv=@Param1"
                Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", CodProv)

                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Proveedor.CodProv = Lector(0)
                    Proveedor.CodLoc = Lector(1)
                    Proveedor.Cuit = Lector(2)
                    Proveedor.RazonSocial = Lector(3)
                    Proveedor.CorreoElectronico = Lector(4)
                    Proveedor.Calle = Lector(5)
                    Proveedor.Numero = Lector(6)
                    Proveedor.Piso = Lector(7)
                    Proveedor.Departamento = Lector(8)
                End While

                Return Proveedor
            End If
        End Using
    End Function


    Public Shared Function ObtenerTelefonoProveedor(ByVal CodProv As Integer) As List(Of TelefonoEN)
        Dim ListaTelefonos As New List(Of TelefonoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", CodProv)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProveedorDadoBaja)
            Else
                Dim ConsultaTelProveeor As String = "SELECT CodTel,Proveedor_CodProv,Numero " & _
                                               "FROM Tel_Prov WHERE Proveedor_CodProv = @Param1"
                Dim Cmd As New SqlCommand(ConsultaTelProveeor, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", CodProv)
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

    ''' 
    ''' <param name="Cuit"></param>
    Public Shared Function ValidarProveedor(ByVal Cuit As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExisteProv As String = "SELECT COUNT(*) FROM Proveedor WHERE Cuit=@Param1 AND Activo=1"
            Dim Cmd As New SqlCommand(ConsultaExisteProv, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Cuit)

            Dim Resultado As Integer = Cmd.ExecuteScalar()

            Return Resultado
        End Using
    End Function


End Class ' ProveedorAD