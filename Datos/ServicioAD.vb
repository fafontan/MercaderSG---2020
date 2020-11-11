Imports Entidades
Imports System.Configuration
Imports System.Data.SqlClient
Imports Excepciones

Public Class ServicioAD

    Public Shared Function CalcularDVH(ByVal DVH As DVHEN) As String
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim Cmd As New SqlCommand
            Dim Cadena As String

            Dim ListaCodigos As New List(Of Integer)

            Select Case DVH.Tabla
                Case "Usuario"
                    Dim CadenaUsuarioDV As String = "SELECT Usuario+Contraseña+CAST(CII AS VARCHAR(1))+CAST(Bloqueado AS VARCHAR(1))+CAST(Activo AS VARCHAR(1)) " & _
                                                    "FROM Usuario " & _
                                                    "WHERE CodUsu=@Param1"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaUsuarioDV
                Case "Usu_Fam"
                    Cadena = CStr(DVH.CodReg) + CStr(DVH.CodAux)
                    Return Cadena
                Case "Fam_Pat"
                    Cadena = CStr(DVH.CodReg) + CStr(DVH.CodAux)
                    Return Cadena
                Case "Usu_Pat"
                    Dim ConsultaPat As String = "SELECT CAST(Activo AS VARCHAR(1)) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaPat
                    Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux)

                    Dim Resultado As String = Cmd.ExecuteScalar()

                    Cadena = CStr(DVH.CodReg) + CStr(DVH.CodAux) + Resultado

                    Return Cadena

                Case "Bitacora"
                    Dim CadenaBitacoraDV As String = "SELECT CAST(Fecha AS VARCHAR(100))+Descripcion+Criticidad+Usuario FROM Bitacora WHERE CodBit=@Param1"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaBitacoraDV
                Case "Cliente"
                    Dim CadenaClienteDV As String = "SELECT Cuit+Calle+Numero+CAST(Activo AS VARCHAR(10)) FROM Cliente WHERE CodCli=@Param1"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaClienteDV
                Case "Producto"
                    Dim CadenaProductoDV As String = "SELECT Nombre+CAST(Cantidad AS VARCHAR(100))+CAST(Activo AS VARCHAR(10)) " & _
                                                     "FROM Producto " & _
                                                     "WHERE CodProd=@Param1"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaProductoDV
                Case "Historico_Precio"
                    Dim CadenaHist_PrecioDV As String = "SELECT CAST(Producto_CodProd AS VARCHAR(100))+CAST(Precio AS VARCHAR(100))+CAST(FechaDesde AS VARCHAR(100)) " & _
                                                        "FROM Historico_Precio " & _
                                                        "WHERE CodHist=@Param1"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaHist_PrecioDV

            End Select

            Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg)
            Cadena = Cmd.ExecuteScalar()

            Return Cadena
        End Using
    End Function


    Public Shared Function CalcularDVV(ByVal DVH As DVHEN) As Integer
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaCantReg As String = "SELECT COUNT(*) FROM " & DVH.Tabla
            Dim CmdCant As New SqlCommand(ConsultaCantReg, cnn)
            Dim Cantidad As Integer = CInt(CmdCant.ExecuteScalar())

            If Cantidad > 0 Then
                Dim ConsultaGralDVH As String = "SELECT SUM(DVH) FROM " & DVH.Tabla
                Dim CmdDVH As New SqlCommand(ConsultaGralDVH, cnn)
                Dim SumaDVH As Integer = CmdDVH.ExecuteScalar()

                Return SumaDVH
            Else
                Return 0
            End If
        End Using
    End Function


    Public Shared Function DetectarIdioma(ByVal IDUsuario As Integer) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaIdiomaUsu As String = "SELECT Idioma_CodIdioma FROM Usuario U " & _
                                                "WHERE U.CodUsu=@Param1"
            Dim Cmd As New SqlCommand(ConsultaIdiomaUsu, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", IDUsuario)
            Dim CodIdioma As Integer = Cmd.ExecuteScalar()

            Return CodIdioma
        End Using
    End Function


    Public Shared Function EjecutarBackup(ByVal Destino As String, ByVal volumen As Integer) As List(Of String)
        Dim Resultado As Integer
        Dim ListaArchivos As New List(Of String)
        Dim CadenaArchivos As String

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("BDMaster").ToString())
            Cnn.Open()

            Dim FechaActual As Date = Today.Date
            Dim FechaStr As String
            FechaStr = "Fecha" & FechaActual.ToString("dd-MM-yyyy")

            Dim ConsultaBack As String

            If volumen = 1 Then
                ConsultaBack = "BACKUP DATABASE Mercader TO DISK = '" & Destino & "\Mercader" & FechaStr & ".bak'"
                CadenaArchivos = Destino & "\Mercader" & FechaStr & ".bak"
                ListaArchivos.Add(CadenaArchivos)
            Else
                ConsultaBack = "BACKUP DATABASE Mercader TO DISK = '" & Destino & "\MercaderParte01" & FechaStr & ".bak'"
                CadenaArchivos = Destino & "\MercaderParte01" & FechaStr & ".bak"
                ListaArchivos.Add(CadenaArchivos)
                For i As Integer = 1 To volumen - 1
                    Dim Parte As String = "Parte" & (i + 1).ToString("00")
                    ConsultaBack += String.Concat(", DISK = '" & Destino & "\Mercader" & Parte & "." & FechaStr & ".bak'")
                    CadenaArchivos = Destino & "\Mercader" & Parte & "." & FechaStr & ".bak"
                    ListaArchivos.Add(CadenaArchivos)
                Next
            End If

            Dim Cmd As New SqlCommand(ConsultaBack, Cnn)

            Resultado = Cmd.ExecuteNonQuery()
            If Resultado < 0 Then
                Return ListaArchivos
            Else
                Return ListaArchivos
            End If
        End Using

    End Function


    Public Shared Function EjecutarRestore(ByVal Origen As List(Of String)) As Boolean
        Dim Resultado As Integer
        SqlConnection.ClearAllPools()

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("BDMaster").ToString())
            Cnn.Open()

            Dim ConsultaRestore As String

            If Origen.Count = 1 Then
                ConsultaRestore = "IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Mercader') " & _
                                    "CREATE DATABASE [Mercader] " & _
                                        "USE master " & _
                                            "ALTER DATABASE Mercader SET SINGLE_USER WITH ROLLBACK IMMEDIATE " & _
                                                "RESTORE DATABASE Mercader FROM DISK='" & Origen.Item(0) & "' WITH REPLACE " & _
                                                    "ALTER DATABASE Mercader SET MULTI_USER"
            Else
                ConsultaRestore = "IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Mercader') " & _
                                    "CREATE DATABASE [Mercader] " & _
                                        "USE master " & _
                                            "ALTER DATABASE Mercader SET SINGLE_USER WITH ROLLBACK IMMEDIATE " & _
                                                "RESTORE DATABASE Mercader FROM DISK='" & Origen.Item(0) & "'"

                For Each ruta As String In Origen
                    If Not ruta = Origen.Item(0) Then
                        ConsultaRestore += String.Concat(", DISK = '" & ruta & "'")
                    End If
                Next
                ConsultaRestore += String.Concat(" WITH REPLACE " & _
                                                    "ALTER DATABASE Mercader SET MULTI_USER")
            End If

            Dim Cmd As New SqlCommand(ConsultaRestore, Cnn)

            Resultado = Cmd.ExecuteNonQuery()

            If Resultado < 0 Then
                Return True
            Else
                Return False
            End If
        End Using

    End Function


    Public Shared Function GrabarDVH(ByVal DVH As DVHEN, ByVal ValorDVH As Integer) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim Cmd As New SqlCommand
            Dim ListaCodigos As New List(Of Integer)
            Dim DVHAntiguo As Integer = 0

            Select Case DVH.Tabla
                Case "Usuario"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Usuario WHERE CodUsu=@Param1"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim CadenaUsuarioDV As String = "UPDATE Usuario SET DVH=@Param1 WHERE CodUsu=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaUsuarioDV

                Case "Usu_Fam"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param2", DVH.CodAux)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim ConsultaUpdate As String = "UPDATE Usu_Fam SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Familia_CodFam=@Param3"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaUpdate
                    Cmd.Parameters.AddWithValue("@Param3", DVH.CodAux)

                Case "Fam_Pat"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param2", DVH.CodAux)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim ConsultaUpdate As String = "UPDATE Fam_Pat SET DVH=@Param1 WHERE Familia_CodFam=@Param2 AND Patente_CodPat=@Param3"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaUpdate
                    Cmd.Parameters.AddWithValue("@Param3", DVH.CodAux)

                Case "Usu_Pat"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param2", DVH.CodAux)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim ConsultaUpdate As String = "UPDATE Usu_Pat SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Patente_CodPat=@Param3"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaUpdate
                    Cmd.Parameters.AddWithValue("@Param3", DVH.CodAux)

                Case "Bitacora"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Bitacora WHERE CodBit=@Param1"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim CadenaBitacoraDV As String = "UPDATE Bitacora SET DVH=@Param1 WHERE CodBit=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaBitacoraDV

                Case "Cliente"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Cliente WHERE CodCli=@Param1"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim CadenaClienteDV As String = "UPDATE Cliente SET DVH=@Param1 WHERE CodCli=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaClienteDV

                Case "Producto"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Producto WHERE CodProd=@Param1"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim CadenaProductoDV As String = "UPDATE Producto SET DVH=@Param1 WHERE CodProd=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaProductoDV

                Case "Historico_Precio"
                    Dim ConsultaDVHAnterior As String = "SELECT DVH FROM Historico_Precio WHERE Producto_CodProd=@Param1"
                    Dim CmdDVHAnterior As New SqlCommand(ConsultaDVHAnterior, Cnn)
                    CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    DVHAntiguo = CInt(CmdDVHAnterior.ExecuteScalar())

                    Dim CadenaHist_PrecioDV As String = "UPDATE Historico_Precio SET DVH=@Param1 WHERE CodHist=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = CadenaHist_PrecioDV

            End Select

            Cmd.Parameters.AddWithValue("@Param1", ValorDVH)
            Cmd.Parameters.AddWithValue("@Param2", DVH.CodReg)
            Cmd.ExecuteNonQuery()

            Return DVHAntiguo
        End Using
    End Function

    Public Shared Function ListarIdiomas() As List(Of IdiomaEN)
        Dim ListaIdiomas As New List(Of IdiomaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaIdioma As String = "SELECT * FROM Idioma"
            Dim Cmd As New SqlCommand(ConsultaIdioma, Cnn)
            Dim Lector As SqlDataReader
            Lector = Cmd.ExecuteReader

            While Lector.Read
                Dim UnIdioma As New IdiomaEN
                UnIdioma.CodIdioma = Lector(0)
                UnIdioma.Descripcion = Lector(1)

                ListaIdiomas.Add(UnIdioma)
            End While
        End Using

        Return ListaIdiomas

    End Function


    Public Shared Function ObtenerRegistros(DVV As DVHEN) As List(Of DVHEN)
        Dim ListaRegTablas As New List(Of DVHEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Select Case DVV.Tabla
                Case "Usu_Fam"
                    Dim ConsultaRegUsuFam As String = "SELECT Usuario_CodUsu,Familia_CodFam FROM Usu_fam"
                    Dim CmdUsuFam As New SqlCommand(ConsultaRegUsuFam, Cnn)
                    Dim LectorUsuFam As SqlDataReader = CmdUsuFam.ExecuteReader()

                    While LectorUsuFam.Read()
                        Dim FilaUsuFam As New DVHEN
                        FilaUsuFam.CodReg = LectorUsuFam(0)
                        FilaUsuFam.CodAux = LectorUsuFam(1)

                        ListaRegTablas.Add(FilaUsuFam)
                    End While

                    Return ListaRegTablas

                Case "Fam_Pat"
                    Dim ConsultaRegFam_Pat As String = "SELECT Familia_CodFam,Patente_CodPat FROM Fam_Pat"
                    Dim CmdFamPat As New SqlCommand(ConsultaRegFam_Pat, Cnn)
                    Dim LectorFamPat As SqlDataReader = CmdFamPat.ExecuteReader()

                    While LectorFamPat.Read()
                        Dim FilaFamPat As New DVHEN
                        FilaFamPat.CodReg = LectorFamPat(0)
                        FilaFamPat.CodAux = LectorFamPat(1)

                        ListaRegTablas.Add(FilaFamPat)
                    End While

                    Return ListaRegTablas

                Case "Usu_Pat"
                    Dim ConsultaRegUsuPat As String = "SELECT Usuario_CodUsu,Patente_CodPat,CAST(Activo AS VARCHAR(1)) FROM Usu_Pat"
                    Dim CmdUsuPat As New SqlCommand(ConsultaRegUsuPat, Cnn)
                    Dim LectorUsuPat As SqlDataReader = CmdUsuPat.ExecuteReader()

                    While LectorUsuPat.Read()
                        Dim FilaUsuPat As New DVHEN
                        FilaUsuPat.CodReg = LectorUsuPat(0)
                        FilaUsuPat.CodAux = LectorUsuPat(1)

                        ListaRegTablas.Add(FilaUsuPat)
                    End While

                    Return ListaRegTablas
            End Select

            Dim ConsultaRegistros As String = "SELECT " & DVV.Columna & " FROM " & DVV.Tabla
            Dim Cmd As New SqlCommand(ConsultaRegistros, Cnn)
            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim CodReg As New DVHEN
                CodReg.CodReg = Lector(0)

                ListaRegTablas.Add(CodReg)
            End While
        End Using

        Return ListaRegTablas
    End Function

    Public Shared Function ObtenerDVHRegistro(DVH As DVHEN) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaDVH As String
            Dim Cmd As New SqlCommand
            Dim ValorDVH As Integer

            Select Case DVH.Tabla
                Case "Usu_Fam"
                    ConsultaDVH = "SELECT DVH FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaDVH
                    Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux)

                    ValorDVH = CInt(Cmd.ExecuteScalar())

                    Return ValorDVH
                Case "Fam_Pat"
                    ConsultaDVH = "SELECT DVH FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaDVH
                    Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux)

                    ValorDVH = CInt(Cmd.ExecuteScalar())

                    Return ValorDVH
                Case "Usu_Pat"
                    ConsultaDVH = "SELECT DVH FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaDVH
                    Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg)
                    Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux)

                    ValorDVH = CInt(Cmd.ExecuteScalar())

                    Return ValorDVH
            End Select

            ConsultaDVH = "SELECT DVH FROM " & DVH.Tabla & " WHERE " & DVH.Columna & " = " & DVH.CodReg
            Cmd.Connection = Cnn
            Cmd.CommandText = ConsultaDVH
            ValorDVH = CInt(Cmd.ExecuteScalar())

            Return ValorDVH
        End Using
    End Function

    Public Shared Function ExisteRegistroIntegridad(Cadena As String) As Boolean
        Dim Resultado As Integer

        Dim FechaActual As Date = Date.Now
        Dim FechaStr As String
        FechaStr = FechaActual.ToString("dd/MM/yyyy")

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Consulta As String = "SELECT COUNT(*) FROM Bitacora WHERE Descripcion=@Param1 AND CONVERT(VARCHAR(10),Fecha,103) LIKE @Param2"
            Dim Cmd As New SqlCommand(Consulta, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Cadena)
            Cmd.Parameters.AddWithValue("@Param2", FechaStr)

            Resultado = CInt(Cmd.ExecuteScalar())

        End Using

        If Resultado > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Sub GrabarDVV(DVVDatosBitacora As DVVEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Select Case DVVDatosBitacora.TipoAccion
                Case "Alta"
                    Dim ConsultaDVV As String = "UPDATE DVV SET DVV+=@Param1 WHERE Tabla=@Param2"
                    Dim CmdDVV As New SqlCommand(ConsultaDVV, cnn)
                    CmdDVV.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVH)
                    CmdDVV.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla)
                    CmdDVV.ExecuteNonQuery()

                Case "Baja Modificar"
                    'Restarle DVV
                    Dim ConsultaDVVMenos As String = "UPDATE DVV SET DVV-=@Param1 WHERE Tabla=@Param2"
                    Dim CmdDVVMenos As New SqlCommand(ConsultaDVVMenos, cnn)
                    CmdDVVMenos.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVHAntiguo)
                    CmdDVVMenos.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla)
                    CmdDVVMenos.ExecuteNonQuery()

                    'NuevoDVV
                    Dim ConsultaDVV As String = "UPDATE DVV SET DVV+=@Param1 WHERE Tabla=@Param2"
                    Dim CmdDVV As New SqlCommand(ConsultaDVV, cnn)
                    CmdDVV.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVH)
                    CmdDVV.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla)
                    CmdDVV.ExecuteNonQuery()

                Case "Eliminar"
                    Dim ConsultaDVV As String = "UPDATE DVV SET DVV-=@Param1 WHERE Tabla=@Param2"
                    Dim CmdDVV As New SqlCommand(ConsultaDVV, cnn)
                    CmdDVV.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVH)
                    CmdDVV.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla)
                    CmdDVV.ExecuteNonQuery()

            End Select
            
        End Using
    End Sub

    Public Shared Function ObtenerDVVTabla(DVHDatos As DVHEN) As Integer
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaDVV As String = "SELECT DVV FROM DVV WHERE Tabla=@Param1"
            Dim CmdDVV As New SqlCommand(ConsultaDVV, cnn)
            CmdDVV.Parameters.AddWithValue("@Param1", DVHDatos.Tabla)
            Dim Resultado As Integer = CmdDVV.ExecuteScalar()
            Return Resultado
        End Using
    End Function

    Public Shared Sub RecalcularDVV(Tabla As String)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaCantReg As String = "SELECT COUNT(*) FROM " & Tabla
            Dim CmdCant As New SqlCommand(ConsultaCantReg, cnn)
            Dim Cantidad As Integer = CInt(CmdCant.ExecuteScalar())

            If Cantidad > 0 Then
                Dim ConsultaSum As String = "SELECT SUM(DVH) FROM " & Tabla
                Dim CmdSum As New SqlCommand(ConsultaSum, cnn)
                Dim ValorSum As Integer = CInt(CmdSum.ExecuteScalar())

                Dim ConsultaDVV As String = "UPDATE DVV SET DVV=@Param1 WHERE Tabla=@Param2"
                Dim CmdDVV As New SqlCommand(ConsultaDVV, cnn)
                CmdDVV.Parameters.AddWithValue("@Param1", ValorSum)
                CmdDVV.Parameters.AddWithValue("@Param2", Tabla)

                CmdDVV.ExecuteNonQuery()

            Else

                Dim ConsultaDVV As String = "UPDATE DVV SET DVV=0 WHERE Tabla=@Param1"
                Dim CmdDVV As New SqlCommand(ConsultaDVV, cnn)
                CmdDVV.Parameters.AddWithValue("@Param1", Tabla)

                CmdDVV.ExecuteNonQuery()
            End If
            
        End Using
    End Sub

    Public Shared Sub RecalcularDVH(Tabla As String, CodReg As Integer, CodAux As Integer, DVH As Integer)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim Cmd As New SqlCommand

            Select Case Tabla
                Case "Usuario"
                    Dim CadenaUsuarioDV As String = "UPDATE Usuario SET DVH=@Param1 WHERE CodUsu=@Param2"
                    Cmd.Connection = cnn
                    Cmd.CommandText = CadenaUsuarioDV

                Case "Usu_Fam"

                    Dim ConsultaUpdate As String = "UPDATE Usu_Fam SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Familia_CodFam=@Param3"
                    Cmd.Connection = cnn
                    Cmd.CommandText = ConsultaUpdate
                    Cmd.Parameters.AddWithValue("@Param3", CodAux)

                Case "Fam_Pat"

                    Dim ConsultaUpdate As String = "UPDATE Fam_Pat SET DVH=@Param1 WHERE Familia_CodFam=@Param2 AND Patente_CodPat=@Param3"
                    Cmd.Connection = cnn
                    Cmd.CommandText = ConsultaUpdate
                    Cmd.Parameters.AddWithValue("@Param3", CodAux)

                Case "Usu_Pat"

                    Dim ConsultaUpdate As String = "UPDATE Usu_Pat SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Patente_CodPat=@Param3"
                    Cmd.Connection = cnn
                    Cmd.CommandText = ConsultaUpdate
                    Cmd.Parameters.AddWithValue("@Param3", CodAux)

                Case "Bitacora"
                    Dim CadenaBitacoraDV As String = "UPDATE Bitacora SET DVH=@Param1 WHERE CodBit=@Param2"
                    Cmd.Connection = cnn
                    Cmd.CommandText = CadenaBitacoraDV

                Case "Cliente"
                    Dim CadenaClienteDV As String = "UPDATE Cliente SET DVH=@Param1 WHERE CodCli=@Param2"
                    Cmd.Connection = cnn
                    Cmd.CommandText = CadenaClienteDV

                Case "Producto"
                    Dim CadenaProductoDV As String = "UPDATE Producto SET DVH=@Param1 WHERE CodProd=@Param2"
                    Cmd.Connection = cnn
                    Cmd.CommandText = CadenaProductoDV

                Case "Historico_Precio"
                    Dim CadenaHist_PrecioDV As String = "UPDATE Historico_Precio SET DVH=@Param1 WHERE CodHist=@Param2"
                    Cmd.Connection = cnn
                    Cmd.CommandText = CadenaHist_PrecioDV

            End Select

            Cmd.Parameters.AddWithValue("@Param1", DVH)
            Cmd.Parameters.AddWithValue("@Param2", CodReg)
            Cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Function ExisteBD() As Boolean
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("BDMaster").ToString())
            cnn.Open()

            Dim ConsultaBD As String = "SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = N'Mercader'"
            Dim Cmd As New SqlCommand(ConsultaBD, cnn)
            Dim Resultado As Integer = CInt(Cmd.ExecuteScalar())
            If Resultado > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

End Class