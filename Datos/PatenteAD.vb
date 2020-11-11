Imports Entidades
Imports System.Configuration
Imports System.Data.SqlClient

Public Class PatenteAD
    Public Shared Function CargarPatente() As List(Of PatenteEN)
        Dim ListaPatentes As New List(Of PatenteEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaPatentes As String = "SELECT CodPat,Descripcion FROM Patente"
            Dim Cmd As New SqlCommand(ConsultaPatentes, Cnn)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = Lector(0)
                UnaPatente.Descripcion = Lector(1)

                ListaPatentes.Add(UnaPatente)
            End While
        End Using

        Return ListaPatentes
    End Function

    Public Shared Function CargarPatente(ByVal CodUsu As Integer) As List(Of PatenteEN)
        Dim ListaPatente As New List(Of PatenteEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaCarga As String = "SELECT CodPat, Descripcion " & _
                                            "FROM Patente " & _
                                            "WHERE CodPat NOT IN (SELECT Patente_CodPat FROM Usu_Pat WHERE Usuario_CodUsu=@Param1) " & _
                                            "AND CodPat NOT IN (SELECT Patente_CodPat FROM Fam_Pat FP INNER JOIN Usu_Fam UF ON FP.Familia_CodFam=UF.Familia_CodFam AND UF.Usuario_CodUsu=@Param1)"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodUsu)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = Lector(0)
                UnaPatente.Descripcion = Lector(1)

                ListaPatente.Add(UnaPatente)
            End While
        End Using

        Return ListaPatente
    End Function

    Public Shared Function ObtenerPatenteUsuario(ByVal CodUsu As Integer) As DataTable
        Dim dtPatUsu As New DataTable
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaPatenteUsuario As String = "WITH Patentes AS ( " & _
                                                    "	SELECT P.CodPat, P.Descripcion, UP.Activo " & _
                                                    "	FROM Patente P, Usuario U, Usu_Pat UP " & _
                                                    "	WHERE P.CodPat=UP.Patente_CodPat AND U.CodUsu=UP.Usuario_CodUsu " & _
                                                    "	AND U.CodUsu=@Param1 " & _
                                                    ") " & _
                                                    "SELECT P.CodPat, P.Descripcion, 1 AS Activo " & _
                                                    "FROM Usuario U, Usu_Fam UF, Familia F, Fam_Pat FP, Patente P " & _
                                                    "WHERE FP.Familia_CodFam=F.CodFam AND FP.Patente_CodPat=P.CodPat " & _
                                                    "	AND UF.Usuario_CodUsu=U.CodUsu AND UF.Familia_CodFam=F.CodFam " & _
                                                    "	AND U.CodUsu=@Param1 AND P.CodPat NOT IN (SELECT CodPat FROM Patentes) " & _
                                                    "UNION " & _
                                                    "SELECT * FROM Patentes WHERE Activo <> 0 ORDER BY CodPat ASC"
            Dim Cmd As New SqlCommand(ConsultaPatenteUsuario, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodUsu)
            Dim da As New SqlDataAdapter(Cmd)
            da.Fill(dtPatUsu)
            Return dtPatUsu
        End Using
    End Function

    Public Shared Function CargarPatenteUsuario(CodUsu As Integer) As List(Of PatenteEN)
        Dim ListaPatente As New List(Of PatenteEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaCarga As String = "WITH Patentes AS ( " & _
                                            "	SELECT P.CodPat, P.Descripcion, UP.Activo " & _
                                            "	FROM Patente P, Usuario U, Usu_Pat UP " & _
                                            "	WHERE P.CodPat=UP.Patente_CodPat AND U.CodUsu=UP.Usuario_CodUsu " & _
                                            "	AND U.CodUsu=@Param1 " & _
                                            ") " & _
                                            "SELECT P.CodPat, P.Descripcion, 1 AS Activo " & _
                                            "FROM Usuario U, Usu_Fam UF, Familia F, Fam_Pat FP, Patente P " & _
                                            "WHERE FP.Familia_CodFam=F.CodFam AND FP.Patente_CodPat=P.CodPat " & _
                                            "	AND UF.Usuario_CodUsu=U.CodUsu AND UF.Familia_CodFam=F.CodFam " & _
                                            "	AND U.CodUsu=@Param1 AND P.CodPat NOT IN (SELECT CodPat FROM Patentes) " & _
                                            "UNION " & _
                                            "SELECT * FROM Patentes WHERE Activo <> 0"

            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodUsu)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = Lector(0)
                UnaPatente.Descripcion = Lector(1)

                ListaPatente.Add(UnaPatente)
            End While
        End Using

        Return ListaPatente
    End Function

    Public Shared Function CargarPatentesFamilia(CodFam As Integer) As List(Of PatenteEN)
        Dim ListaPatente As New List(Of PatenteEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaCarga As String = "SELECT P.CodPat,P.Descripcion FROM Patente P INNER JOIN Fam_Pat FP ON P.CodPat=FP.Patente_CodPat WHERE FP.Familia_CodFam=@Param1"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodFam)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = Lector(0)
                UnaPatente.Descripcion = Lector(1)

                ListaPatente.Add(UnaPatente)
            End While
        End Using

        Return ListaPatente
    End Function

    Public Shared Function CargarNoPatentesFamilia(CodFam As Integer) As List(Of PatenteEN)
        Dim ListaPatente As New List(Of PatenteEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaCarga As String = "SELECT CodPat, Descripcion FROM Patente WHERE CodPat NOT IN (SELECT Patente_CodPat FROM Fam_Pat WHERE Familia_CodFam=@Param1)"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodFam)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = Lector(0)
                UnaPatente.Descripcion = Lector(1)

                ListaPatente.Add(UnaPatente)
            End While
        End Using

        Return ListaPatente
    End Function

    Public Shared Function CargarPatenteDenegadasUsuario(CodUsu As Integer) As List(Of PatenteEN)
        Dim ListaPatente As New List(Of PatenteEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaCarga As String = "SELECT CodPat, Descripcion FROM Patente WHERE CodPat IN (SELECT Patente_CodPat FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Activo=0)"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodUsu)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = Lector(0)
                UnaPatente.Descripcion = Lector(1)

                ListaPatente.Add(UnaPatente)
            End While
        End Using

        Return ListaPatente
    End Function

    Shared Function ObtenerPatentesFamilia(CodFam As Integer) As Boolean
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaPat As String = "SELECT COUNT(*) FROM Fam_Pat WHERE Familia_CodFam=@Param1"
            Dim Cmd As New SqlCommand(ConsultaPat, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodFam)

            Dim Resultado As Integer = Cmd.ExecuteScalar()

            If Resultado > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function


End Class ' PatenteAD