Imports Entidades
Imports System.Data.SqlClient
Imports System.Configuration
Imports Excepciones
Public Class FamiliaAD

    Public Shared Sub AltaFamilia(ByVal Familia As FamiliaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaAlta As String = "INSERT INTO Familia(Descripcion)VALUES(@Descripcion)"
                Dim Cmd As New SqlCommand(ConsultaAlta, Cnn)
                Cmd.Parameters.AddWithValue("@Descripcion", Familia.Descripcion)

                Cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' 
    ''' <param name="FamiliaPatente"></param>
    Public Shared Sub AltaFamiliaPatente(ByVal FamiliaPatente As FamPatEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1"
                Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
                CmdValidar.Parameters.AddWithValue("@Param1", FamiliaPatente.CodFam)
                Dim Resultado As Integer = CmdValidar.ExecuteScalar()
            If Resultado > 0 Then
                Dim ConsultaAlta As String = "INSERT INTO Fam_Pat(Familia_CodFam,Patente_CodPat,DVH)" & _
                                            "VALUES(@Param1,@Param2,0)"
                Dim Cmd As New SqlCommand(ConsultaAlta, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", FamiliaPatente.CodFam)
                Cmd.Parameters.AddWithValue("@Param2", FamiliaPatente.CodPat)
                Cmd.ExecuteNonQuery()
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja)
            End If
        End Using
    End Sub

    ''' 
    ''' <param name="Familia"></param>
    Public Shared Sub BajaFamilia(ByVal Familia As FamiliaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param1", Familia.CodFam)
            Dim Resultado As Integer = CmdExiste.ExecuteScalar()

            If Resultado > 0 Then
                Dim ConsultaBaja As String = "DELETE FROM Familia WHERE CodFam=@Param1"
                Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Familia.CodFam)
                Cmd.ExecuteNonQuery()
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja)
            End If

        End Using
    End Sub

    Public Shared Function CargarFamilia() As List(Of FamiliaEN)
        Dim ListaFamilia As New List(Of FamiliaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCarga As String = "SELECT CodFam,Descripcion FROM Familia"
                Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
                Dim Lector As SqlDataReader = Cmd.ExecuteReader()
            While Lector.Read
                Dim UnaFamilia As New FamiliaEN
                UnaFamilia.CodFam = Lector(0)
                UnaFamilia.Descripcion = Lector(1)

                ListaFamilia.Add(UnaFamilia)
            End While
        End Using

        Return ListaFamilia
    End Function

    Public Shared Function CargarFamiliaConPatentes() As List(Of FamiliaEN)
        Dim ListaFamilia As New List(Of FamiliaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCarga As String = "SELECT DISTINCT CodFam,Descripcion " & _
                                                    "FROM Familia " & _
                                                    "INNER JOIN Fam_Pat ON Familia.CodFam = Fam_Pat.Familia_CodFam"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Dim Lector As SqlDataReader = Cmd.ExecuteReader()
            While Lector.Read
                Dim UnaFamilia As New FamiliaEN
                UnaFamilia.CodFam = Lector(0)
                UnaFamilia.Descripcion = Lector(1)

                ListaFamilia.Add(UnaFamilia)
            End While

        End Using

        Return ListaFamilia

    End Function


    Public Shared Sub ModificarFamilia(ByVal Familia As FamiliaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1"
                Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
                CmdExiste.Parameters.AddWithValue("@Param1", Familia.CodFam)
                Dim Resultado As Integer = CmdExiste.ExecuteScalar()

                If Resultado > 0 Then
                    Dim ConsultaModificar As String = "UPDATE Familia SET Descripcion=@Param1 WHERE CodFam=@Param2"
                    Dim Cmd As New SqlCommand(ConsultaModificar, Cnn)
                    Cmd.Parameters.AddWithValue("@Param1", Familia.Descripcion)
                    Cmd.Parameters.AddWithValue("@Param2", Familia.CodFam)

                    Cmd.ExecuteNonQuery()
                Else
                    Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja)
                End If

        End Using
    End Sub

    Public Shared Function ObtenerFamilia(ByVal Descripcion As String) As FamiliaEN
        Dim Familia As New FamiliaEN
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())

            Cnn.Open()

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Familia WHERE Descripcion=@Param1"
                Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
                CmdExiste.Parameters.AddWithValue("@Param1", Descripcion)
                Dim Resultado As Integer = CmdExiste.ExecuteScalar()

                If Resultado > 0 Then
                    Dim ConsultaIDFam As String = "SELECT CodFam FROM Familia WHERE Descripcion=@Param1"
                    Dim Cmd As New SqlCommand(ConsultaIDFam, Cnn)
                    Cmd.Parameters.AddWithValue("@Param1", Descripcion)
                    Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                    While Lector.Read
                        Familia.CodFam = Lector(0)
                    End While
                    Familia.Descripcion = Descripcion
                Else
                    Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja)
                End If

        End Using

        Return Familia
    End Function

    Public Shared Function ValidarPatente(ByVal FamPat As FamPatEN) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2"
                Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", FamPat.CodFam)
                Cmd.Parameters.AddWithValue("@Param2", FamPat.CodPat)

                Dim Resultado As Integer = Cmd.ExecuteScalar()

                Return Resultado
        End Using
    End Function

    ''' 
    ''' <param name="Descripcion"></param>
    Public Shared Function ValidarFamilia(ByVal Descripcion As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Familia WHERE Descripcion=@Param1"
                Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Descripcion)

                Dim Resultado As Integer = Cmd.ExecuteScalar()

                Return Resultado

        End Using
    End Function

    Public Shared Function ObtenerIDFamilia(Fam As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaFamilia As String = "SELECT CodFam FROM Familia WHERE Descripcion=@Param1"
                Dim Cmd As New SqlCommand(ConsultaFamilia, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Fam)

                Dim Resultado As Integer = CInt(Cmd.ExecuteScalar())

                Return Resultado

        End Using
    End Function

    Public Shared Sub BajaFamiliaPatente(CodFam As Integer, UnaFamPat As FamPatEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1"
                Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
                CmdValidar.Parameters.AddWithValue("@Param1", CodFam)
                Dim Resultado As Integer = CmdValidar.ExecuteScalar()

                If Resultado > 0 Then
                Dim ConsultaBaja As String = "DELETE FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2"
                        Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                        Cmd.Parameters.AddWithValue("@Param1", CodFam)
                        Cmd.Parameters.AddWithValue("@Param2", UnaFamPat.CodPat)
                        Cmd.ExecuteNonQuery()
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja)
                End If
            
        End Using
    End Sub

    Public Shared Function VerificarPatentesFamilia(CodFam As Integer, CodPat As Integer) As Integer
        Dim Resultado As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaPatFam As String = "WITH Patentes AS ( " & _
                                            "	SELECT P.CodPat, UP.Activo " & _
                                            "	FROM Patente P, Usuario U, Usu_Pat UP " & _
                                            "	WHERE P.CodPat=UP.Patente_CodPat AND P.CodPat=@Param1 " & _
                                            "	AND UP.Usuario_CodUsu=U.CodUsu " & _
                                            ") " & _
                                            "SELECT " & _
                                            "(SELECT COUNT(*) " & _
                                            "FROM Usuario U, Usu_Fam UF, Familia F, Fam_Pat FP, Patente P " & _
                                            "WHERE FP.Familia_CodFam=F.CodFam AND FP.Patente_CodPat=P.CodPat " & _
                                            "	AND UF.Familia_CodFam=F.CodFam AND UF.Usuario_CodUsu = U.CodUsu " & _
                                            "	AND P.CodPat NOT IN (SELECT CodPat FROM Patentes WHERE Activo = 0) " & _
                                            "	AND P.CodPat=@Param1  AND F.CodFam <>  @Param2 " & _
                                            ") " & _
                                            "+ " & _
                                            "(SELECT COUNT(*) FROM Patentes WHERE Activo <> 0) " & _
                                            "AS Total"
            Dim Cmd As New SqlCommand(ConsultaPatFam, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodPat)
            Cmd.Parameters.AddWithValue("@Param2", CodFam)
            Resultado = CInt(Cmd.ExecuteScalar())

        End Using

        Return Resultado
    End Function

    Public Shared Function ObtenerFamiliaPatente(CodFam As Integer) As List(Of FamPatEN)
        Dim ListaFamPat As New List(Of FamPatEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaFamPat As String = "SELECT Patente_CodPat FROM Fam_Pat WHERE Familia_CodFam=@Param1"
            Dim CmdFamPat As New SqlCommand(ConsultaFamPat, cnn)
            CmdFamPat.Parameters.AddWithValue("@Param1", CodFam)

            Dim Lector As SqlDataReader = CmdFamPat.ExecuteReader()

            While Lector.Read()
                Dim UnaFamPat As New FamPatEN
                UnaFamPat.CodFam = CodFam
                UnaFamPat.CodPat = Lector(0)

                ListaFamPat.Add(UnaFamPat)
            End While

            Return ListaFamPat
        End Using
    End Function

    Public Shared Sub EliminarFamiliaPatente(UnaFamPat As FamPatEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaFam_Pat As String = "DELETE FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2"
            Dim CmdFamPat As New SqlCommand(ConsultaFam_Pat, cnn)
            CmdFamPat.Parameters.AddWithValue("@Param1", UnaFamPat.CodFam)
            CmdFamPat.Parameters.AddWithValue("@Param2", UnaFamPat.CodPat)
            CmdFamPat.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Function ObtenerUsuarioFamilia(CodFam As Integer) As List(Of UsuFamEN)
        Dim ListaUsuFam As New List(Of UsuFamEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaUsuFam As String = "SELECT Usuario_CodUsu FROM Usu_Fam WHERE Familia_CodFam=@Param1"
            Dim CmdUsuFam As New SqlCommand(ConsultaUsuFam, cnn)
            CmdUsuFam.Parameters.AddWithValue("@Param1", CodFam)

            Dim Lector As SqlDataReader = CmdUsuFam.ExecuteReader()

            While Lector.Read()
                Dim UnaUsuFam As New UsuFamEN
                UnaUsuFam.CodUsu = Lector(0)
                UnaUsuFam.CodFam = CodFam

                ListaUsuFam.Add(UnaUsuFam)
            End While

            Return ListaUsuFam
        End Using
    End Function

    Public Shared Sub EliminarUsuarioFamilia(UnaUsuFam As UsuFamEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaUsu_Fam As String = "DELETE FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2"
            Dim CmdUsuFam As New SqlCommand(ConsultaUsu_Fam, cnn)
            CmdUsuFam.Parameters.AddWithValue("@Param1", UnaUsuFam.CodUsu)
            CmdUsuFam.Parameters.AddWithValue("@Param2", UnaUsuFam.CodFam)
            CmdUsuFam.ExecuteNonQuery()
        End Using
    End Sub

    Shared Function ObtenerFamiliaUsuario(CodUsu As Integer) As List(Of UsuFamEN)
        Dim ListaUsuFam As New List(Of UsuFamEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaUsuFam As String = "SELECT Familia_CodFam FROM Usu_Fam WHERE Usuario_CodUsu=@Param1"
            Dim CmdUsuFam As New SqlCommand(ConsultaUsuFam, cnn)
            CmdUsuFam.Parameters.AddWithValue("@Param1", CodUsu)

            Dim Lector As SqlDataReader = CmdUsuFam.ExecuteReader()

            While Lector.Read()
                Dim UnaUsuFam As New UsuFamEN
                UnaUsuFam.CodUsu = CodUsu
                UnaUsuFam.CodFam = Lector(0)

                ListaUsuFam.Add(UnaUsuFam)
            End While

            Return ListaUsuFam
        End Using
    End Function


End Class ' FamiliaAD