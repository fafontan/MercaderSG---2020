Imports Entidades
Imports System.Configuration
Imports System.Data.SqlClient
Imports Excepciones
Imports System.Transactions
Public Class ClienteAD

    ''' 
    ''' <param name="Cliente"></param>
    Public Shared Sub AltaCliente(ByVal Cliente As ClienteEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCli As String = "INSERT INTO Cliente(Localidad_CodLoc,Cuit," & _
                                            "RazonSocial,Calle,Numero,Piso,Departamento,Activo,DVH)VALUES(" & _
                                                "@Localidad_CodLoc,@Cuit,@RazonSocial,@Calle,@Numero,@Piso," & _
                                                    "@Departamento,1,0) " & _
                                                    "SELECT SCOPE_IDENTITY()"
                Dim Cmd As New SqlCommand(ConsultaCli, Cnn)
                Cmd.Parameters.AddWithValue("@Localidad_CodLoc", Cliente.CodLoc)
                Cmd.Parameters.AddWithValue("@Cuit", Cliente.Cuit)
                Cmd.Parameters.AddWithValue("@RazonSocial", Cliente.RazonSocial)
                Cmd.Parameters.AddWithValue("@Calle", Cliente.Calle)
                Cmd.Parameters.AddWithValue("@Numero", Cliente.Numero)
                Cmd.Parameters.AddWithValue("@Piso", Cliente.Piso)
                Cmd.Parameters.AddWithValue("@Departamento", Cliente.Departamento)

                Dim CodigoCli As Integer = Cmd.ExecuteScalar()

                Cliente.CodCli = CodigoCli

                For Each Telefono As TelefonoEN In Cliente.Telefono
                    NegocioAD.AltaTelefono(CodigoCli, Telefono, "Tel_Cli")
                Next

        End Using
    End Sub

    ''' 
    ''' <param name="Cliente"></param>
    Public Shared Sub BajaCliente(ByVal Cliente As ClienteEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Cliente.CodCli)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ClienteEstaEliminado)
            Else
                Dim ConsultaBaja As String = "UPDATE Cliente SET Activo=0 WHERE CodCli=@Param1"
                Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Cliente.CodCli)

                Cmd.ExecuteNonQuery()
            End If

        End Using
    End Sub

    ''' 
    ''' <param name="campo"></param>
    ''' <param name="valor"></param>
    Public Shared Function BuscarCliente(ByVal campo As String, ByVal valor As String) As List(Of ClienteEN)
        Dim ListaCliente As New List(Of ClienteEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Cmd As New SqlCommand
                Cmd.Connection = Cnn

                Select Case campo
                    Case My.Resources.ArchivoIdioma.CMBCuit
                    Cmd.CommandText = "SELECT C.CodCli,C.RazonSocial,C.Cuit,(C.Calle + ' ' + C.Numero) AS Direccion,C.Activo,L.Descripcion " & _
                                        "FROM Cliente C, Localidad L " & _
                                        "WHERE C.Localidad_CodLoc= L.CodLoc AND C.Cuit=@Param1 AND C.Activo=1"
                Case My.Resources.ArchivoIdioma.CMBRazonSocial
                    Cmd.CommandText = "SELECT C.CodCli,C.RazonSocial,C.Cuit,(C.Calle + ' ' + C.Numero) AS Direccion,C.Activo,L.Descripcion " & _
                                        "FROM Cliente C, Localidad L " & _
                                        "WHERE C.Localidad_CodLoc= L.CodLoc AND C.RazonSocial LIKE '%' + @Param1 + '%' AND C.Activo=1"
            End Select
                Cmd.Parameters.AddWithValue("@Param1", valor)

                Dim Lector As SqlDataReader
                Lector = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnCliente As New ClienteEN
                    UnCliente.CodCli = Lector(0)
                    UnCliente.RazonSocial = Lector(1)
                    UnCliente.Cuit = Lector(2)
                    UnCliente.Direccion = Lector(3)
                UnCliente.Activo = Lector(4)
                UnCliente.Localidad = Lector(5)

                    ListaCliente.Add(UnCliente)
                End While

                Return ListaCliente
        End Using
    End Function

    Public Shared Function CargarCliente() As List(Of ClienteEN)
        Dim ListaClientes As New List(Of ClienteEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCarga As String = "SELECT C.CodCli,C.RazonSocial,C.Cuit,(C.Calle + ' ' + C.Numero) AS Direccion,C.Activo,L.Descripcion " & _
                                            "FROM Cliente C, Localidad L " & _
                                            "WHERE C.Localidad_CodLoc= L.CodLoc AND C.Activo=1"
                Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
                Dim Lector As SqlDataReader
                Lector = Cmd.ExecuteReader()

                While Lector.Read()

                    Dim UnCliente As New ClienteEN
                    UnCliente.CodCli = Lector(0)
                    UnCliente.RazonSocial = Lector(1)
                    UnCliente.Cuit = Lector(2)
                    UnCliente.Direccion = Lector(3)
                UnCliente.Activo = Lector(4)
                UnCliente.Localidad = Lector(5)

                    ListaClientes.Add(UnCliente)
                End While

                Return ListaClientes
        End Using
    End Function

    Public Shared Sub EliminarTelefonoCliente(ByVal UnTelefono As TelefonoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidarTel As String = "SELECT COUNT(*) FROM Tel_Cli WHERE CodTel=@Param1 AND Cliente_CodCli=@Param2"
                Dim CmdValidar As New SqlCommand(ConsultaValidarTel, Cnn)
                CmdValidar.Parameters.AddWithValue("@Param1", UnTelefono.CodTel)
                CmdValidar.Parameters.AddWithValue("@Param2", UnTelefono.CodEn)

                Dim Resultado As Integer = CmdValidar.ExecuteScalar()

                If Resultado > 0 Then
                    Dim ConsultaEliminarTel As String = "DELETE FROM Tel_Cli WHERE CodTel=@Param1 AND Cliente_CodCli=@Param2"
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
    ''' <param name="Cliente"></param>
    Public Shared Sub ModificarCliente(ByVal Cliente As ClienteEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim CodigoCliente As Integer = Cliente.CodCli

                Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1"
                Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
                CmdExiste.Parameters.AddWithValue("@Param1", CodigoCliente)

                Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja)
            Else
                Dim ConsultaModificar As String = "UPDATE Cliente SET Localidad_CodLoc=@CodLoc,Cuit=@Cuit,RazonSocial=@RazonSocial," & _
                                              "Calle=@Calle,Numero=@Numero,Piso=@Piso,Departamento=@Dpto FROM Cliente WHERE CodCli=@CodCli"
                Dim Cmd As New SqlCommand(ConsultaModificar, Cnn)

                Cmd.Parameters.AddWithValue("@CodLoc", Cliente.CodLoc)
                Cmd.Parameters.AddWithValue("@Cuit", Cliente.Cuit)
                Cmd.Parameters.AddWithValue("@RazonSocial", Cliente.RazonSocial)
                Cmd.Parameters.AddWithValue("@Calle", Cliente.Calle)
                Cmd.Parameters.AddWithValue("@Numero", Cliente.Numero)
                Cmd.Parameters.AddWithValue("@Piso", Cliente.Piso)
                Cmd.Parameters.AddWithValue("@Dpto", Cliente.Departamento)

                Cliente.CodCli = CodigoCliente
                Cmd.Parameters.AddWithValue("@CodCli", Cliente.CodCli)

                Cmd.ExecuteNonQuery()

                For Each Telefono As TelefonoEN In Cliente.Telefono
                    NegocioAD.ModificarTelefono(CodigoCliente, Telefono, "Tel_Cli")
                Next
            End If
        End Using
    End Sub

    ''' 
    ''' <param name="Codigo"></param>
    Public Shared Function ObtenerCliente(ByVal Codigo As Integer) As ClienteEN
        Dim Cliente As New ClienteEN

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1"
                Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
                CmdExiste.Parameters.AddWithValue("@Param1", Codigo)

                Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja)
            Else
                Dim ConsultaCliente As String = "SELECT CodCli,Localidad_CodLoc,RazonSocial,Cuit,Calle,Numero,Piso,Departamento" & _
                                                        " FROM Cliente WHERE CodCli=@Param1"
                Dim Cmd As New SqlCommand(ConsultaCliente, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Codigo)

                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read
                    Cliente.CodCli = Lector(0)
                    Cliente.CodLoc = Lector(1)
                    Cliente.RazonSocial = Lector(2)
                    Cliente.Cuit = Lector(3)

                    Cliente.Calle = Lector(4)
                    Cliente.Numero = Lector(5)
                    Cliente.Piso = Lector(6)
                    Cliente.Departamento = Lector(7)
                End While

                Return Cliente
            End If
        End Using
    End Function


    Public Shared Function ObtenerIDCliente(ByVal Cuit As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND Cuit=@Param1"
                Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
                CmdExiste.Parameters.AddWithValue("@Param1", Cuit)

                Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja)
            Else
                Dim ConsultaId As String = "SELECT CodCli FROM Cliente WHERE Cuit=@Param1 AND Activo=1"
                Dim Cmd As New SqlCommand(ConsultaId, Cnn)

                Cmd.Parameters.AddWithValue("@Param1", Cuit)

                Dim CodigoCliente As Integer = Cmd.ExecuteScalar()

                Return CodigoCliente
            End If

        End Using
    End Function


    Public Shared Function ObtenerTelefonoCliente(ByVal CodCli As Integer) As List(Of TelefonoEN)
        Dim ListaTel As New List(Of TelefonoEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", CodCli)

            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja)
            Else
                Dim ConsultaTel As String = "SELECT CodTel,Cliente_CodCli,Numero FROM Tel_Cli WHERE Cliente_CodCli=@Param1"
                Dim Cmd As New SqlCommand(ConsultaTel, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", CodCli)
                Dim Lector As SqlDataReader = Cmd.ExecuteReader()
                While Lector.Read
                    Dim UnTelefono As New TelefonoEN
                    UnTelefono.CodTel = Lector(0)
                    UnTelefono.CodEn = Lector(1)
                    UnTelefono.Numero = Lector(2)
                    ListaTel.Add(UnTelefono)
                End While
                Return ListaTel
            End If
        End Using
    End Function

    Public Shared Function ValidarCliente(ByVal Cuit As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCli As String = "SELECT COUNT(*) FROM Cliente WHERE Cuit=@Param1 AND Activo=1"
            Dim Cmd As New SqlCommand(ConsultaCli, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Cuit)
            Dim Resultado As Integer = Cmd.ExecuteScalar()
            Return Resultado
        End Using
    End Function


End Class ' ClienteAD