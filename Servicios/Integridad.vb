Imports Datos
Imports Entidades
Imports System.Data.SqlClient
Imports Excepciones

Public Class Integridad

    Public Shared Function CalcularDVH(ByVal DVH As DVHEN) As Integer
        Dim Cadena As String

        Cadena = ServicioAD.CalcularDVH(DVH)

        Dim Sumatoria As Integer = 0
        Dim e As Integer = 1

        Cadena = StrReverse(Cadena)

        For i As Integer = 0 To Cadena.Length - 1
            e += 1
            If e = 8 Then
                e = 2
            End If

            If IsNumeric(Cadena(i)) Then
                Sumatoria += (CInt(Val(Cadena(i))) * e)
            Else
                Sumatoria += (Asc(Cadena(i)) * e)
            End If
        Next

        Dim M11 As Double
        M11 = Sumatoria / 11
        Dim M11Entero As Integer = Int(M11)

        Dim ResultadoM11 As Integer

        ResultadoM11 = M11Entero * 11

        Dim Resto As Integer = Sumatoria - ResultadoM11

        Return Resto
    End Function

    Public Shared Function GrabarDVH(ByVal DVH As DVHEN, ByVal ValorDVH As Integer) As Integer
        Return ServicioAD.GrabarDVH(DVH, ValorDVH)
    End Function

    Public Shared Function VerificarIntegridad(DatosDVHParam As DVHEN) As ErrorIntegridadEN
        Try
            Dim ListaCod As New List(Of DVHEN)
            Dim ErrorInt As New ErrorIntegridadEN

            Dim DVHGral As New DVHEN
            DVHGral.Tabla = DatosDVHParam.Tabla
            ListaCod = ServicioAD.ObtenerRegistros(DatosDVHParam)

            For Each item As DVHEN In ListaCod
                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = DatosDVHParam.Tabla
                DVHDatos.CodReg = item.CodReg
                DVHDatos.Columna = DatosDVHParam.Columna

                If DatosDVHParam.Tabla = "Fam_Pat" Or DatosDVHParam.Tabla = "Usu_Pat" Or DatosDVHParam.Tabla = "Usu_Fam" Then
                    DVHDatos.CodAux = item.CodAux
                End If

                Dim DVHComparar As Integer = Integridad.CalcularDVH(DVHDatos)
                Dim DVHActual As Integer = ServicioAD.ObtenerDVHRegistro(DVHDatos)

                If DVHActual <> DVHComparar Then
                    If Not ErrorInt.Tabla = DVHDatos.Tabla Then
                        ErrorInt.CodEn = DVHDatos.CodReg
                        ErrorInt.Tabla = DVHDatos.Tabla
                        ErrorInt.Tipo = "DVH"
                        ErrorInt.EstadoMensaje = True
                    End If

                    'DataTable
                    DatosDVHParam.DtIntegridad.Rows.Add(DatosDVHParam.Tabla, DVHDatos.CodReg, DVHDatos.CodAux, DVHComparar)
                    DatosDVHParam.DtIntegridadDVV.Rows.Add(DatosDVHParam.Tabla)

                    Dim CadenaFamPat As String = ""
                    Dim CadenaUsuFam As String = ""
                    Dim CadenaUsuPat As String = ""
                    Dim CadenaEntidad As String = ""

                    Select Case DatosDVHParam.Tabla
                        Case "Fam_Pat"
                            CadenaFamPat = Seguridad.Encriptar("Error de integridad DVH. Tabla: Fam_Pat || CodFam: " & DVHDatos.CodReg & " - CodPat: " & DVHDatos.CodAux)
                            If ServicioAD.ExisteRegistroIntegridad(CadenaFamPat) Then
                                Continue For
                            End If

                        Case "Usu_Fam"
                            CadenaUsuFam = Seguridad.Encriptar("Error de integridad DVH. Tabla: Usu_Fam || CodUsu: " & DVHDatos.CodReg & " - CodFam: " & DVHDatos.CodAux)
                            If ServicioAD.ExisteRegistroIntegridad(CadenaUsuFam) Then
                                Continue For
                            End If

                        Case "Usu_Pat"
                            CadenaUsuPat = Seguridad.Encriptar("Error de integridad DVH. Tabla: Usu_Pat || CodUsu: " & DVHDatos.CodReg & " - CodPat: " & DVHDatos.CodAux)
                            If ServicioAD.ExisteRegistroIntegridad(CadenaUsuPat) Then
                                Continue For
                            End If

                        Case Else
                            CadenaEntidad = Seguridad.Encriptar("Error de integridad DVH. Tabla: " & DVHDatos.Tabla & " en el registro nro: " & DVHDatos.CodReg & " de la columna " & DVHDatos.Columna)
                            If ServicioAD.ExisteRegistroIntegridad(CadenaEntidad) Then
                                Continue For
                            End If
                    End Select

                    Dim Bitacora As New BitacoraEN
                    Select Case DatosDVHParam.Tabla
                        Case "Fam_Pat"
                            Bitacora.Descripcion = CadenaFamPat
                        Case "Usu_Fam"
                            Bitacora.Descripcion = CadenaUsuFam
                        Case "Usu_Pat"
                            Bitacora.Descripcion = CadenaUsuPat
                        Case Else
                            Bitacora.Descripcion = CadenaEntidad
                    End Select

                    Bitacora.Criticidad = 1
                    Bitacora.Usuario = "Sistema"

                    BitacoraAD.GrabarBitacora(Bitacora)

                    Dim DVHDatosBitacora As New DVHEN
                    DVHDatosBitacora.Tabla = "Bitacora"
                    DVHDatosBitacora.CodReg = Bitacora.CodBit

                    Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
                    Dim ValorDVHAntiguoBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

                    Dim DVVDatosBitacora As New DVVEN
                    DVVDatosBitacora.Tabla = "Bitacora"
                    DVVDatosBitacora.ValorDVH = DVHBitacora
                    DVVDatosBitacora.TipoAccion = "Alta"
                    Integridad.GrabarDVV(DVVDatosBitacora)
                End If
            Next

            'DVV
            Dim DVVComparar As Integer = ServicioAD.CalcularDVV(DVHGral)
            Dim DVVActual As Integer = ServicioAD.ObtenerDVVTabla(DVHGral)

            If DVVActual <> DVVComparar Then

                ErrorInt.Tabla = DVHGral.Tabla
                If ErrorInt.EstadoMensaje = False Then
                    ErrorInt.Tipo = "DVV"
                Else
                    Dim CadenaDVV As String = " & DVV"
                    ErrorInt.Tipo = ErrorInt.Tipo & CadenaDVV
                End If

                Dim ExisteTablaDT As Boolean = False

                For Each row As DataRow In DatosDVHParam.DtIntegridadDVV.Rows
                    If row("Tabla") = DVHGral.Tabla Then
                        ExisteTablaDT = True
                        Exit For
                    End If
                Next

                If ExisteTablaDT = False Then
                    DatosDVHParam.DtIntegridadDVV.Rows.Add(DVHGral.Tabla)
                End If

                Dim CadenaEntidad As String = Seguridad.Encriptar("Error de integridad DVV. Tabla: " & DVHGral.Tabla)

                If Not ServicioAD.ExisteRegistroIntegridad(CadenaEntidad) Then
                    Dim Bitacora As New BitacoraEN
                    Bitacora.Descripcion = CadenaEntidad
                    Bitacora.Criticidad = 1
                    Bitacora.Usuario = "Sistema"

                    BitacoraAD.GrabarBitacora(Bitacora)

                    Dim DVHDatosBitacora As New DVHEN
                    DVHDatosBitacora.Tabla = "Bitacora"
                    DVHDatosBitacora.CodReg = Bitacora.CodBit

                    Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
                    Dim ValorDVHAntiguoBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

                    Dim DVVDatosBitacora As New DVVEN
                    DVVDatosBitacora.Tabla = "Bitacora"
                    DVVDatosBitacora.ValorDVH = DVHBitacora
                    DVVDatosBitacora.TipoAccion = "Alta"
                    Integridad.GrabarDVV(DVVDatosBitacora)
                End If
            End If

            Return ErrorInt
        Catch ex As SqlException
            Throw New CriticalException(ex.Message)
        End Try

    End Function

    Public Shared Sub GrabarDVV(DVVDatosBitacora As DVVEN)
        ServicioAD.GrabarDVV(DVVDatosBitacora)
    End Sub

    Shared Sub RecalcularDVH(DtErrorIntegridad As DataTable)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        For Each row As DataRow In DtErrorIntegridad.Rows
            ServicioAD.RecalcularDVH(row("Tabla"), row("CodReg"), row("CodAux"), row("ValorDVH"))

            Dim CadenaEntidad As String = ""
            Select Case row("Tabla")
                Case "Fam_Pat"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodFam: " & row("CodReg") & " | CodPat: " & row("CodAux"))
                Case "Usu_Fam"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodUsu: " & row("CodReg") & " | CodFam: " & row("CodAux"))
                Case "Usu_Pat"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodUsu: " & row("CodReg") & " | CodPat: " & row("CodAux"))
                Case "Cliente"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodCli: " & row("CodReg"))
                Case "Bitacora"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodBit: " & row("CodReg"))
                Case "Producto"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodProd: " & row("CodReg"))
                Case "Historico_Precio"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodHist: " & row("CodReg"))
                Case "Usuario"
                    CadenaEntidad = Seguridad.Encriptar("Recalculó DVH. Tabla: " & row("Tabla") & " | CodUsu: " & row("CodReg"))
            End Select

            If ServicioAD.ExisteRegistroIntegridad(CadenaEntidad) Then
                Continue For
            End If

            Dim Bitacora As New BitacoraEN
            Bitacora.Descripcion = CadenaEntidad
            Bitacora.Criticidad = 1
            Bitacora.Usuario = UsuAut.UsuarioLogueado

            BitacoraAD.GrabarBitacora(Bitacora)

            Dim DVHDatosBitacora As New DVHEN
            DVHDatosBitacora.Tabla = "Bitacora"
            DVHDatosBitacora.CodReg = Bitacora.CodBit

            Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
            Dim ValorDVHAntiguoBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

            Dim DVVDatosBitacora As New DVVEN
            DVVDatosBitacora.Tabla = "Bitacora"
            DVVDatosBitacora.ValorDVH = DVHBitacora
            DVVDatosBitacora.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatosBitacora)
        Next
    End Sub

    Shared Sub RecalcularDVV(DtErrorIntegridadDVV As DataTable)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        For Each row As DataRow In DtErrorIntegridadDVV.Rows

            ServicioAD.RecalcularDVV(row("Tabla"))

            Dim CadenaEntidad As String
            CadenaEntidad = Seguridad.Encriptar("Recalculó DVV. Tabla: " & row("Tabla"))
            If ServicioAD.ExisteRegistroIntegridad(CadenaEntidad) Then
                Continue For
            End If

            Dim Bitacora As New BitacoraEN
            Bitacora.Descripcion = CadenaEntidad
            Bitacora.Criticidad = 1
            Bitacora.Usuario = UsuAut.UsuarioLogueado

            BitacoraAD.GrabarBitacora(Bitacora)

            Dim DVHDatosBitacora As New DVHEN
            DVHDatosBitacora.Tabla = "Bitacora"
            DVHDatosBitacora.CodReg = Bitacora.CodBit

            Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
            Dim ValorDVHAntiguoBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

            Dim DVVDatosBitacora As New DVVEN
            DVVDatosBitacora.Tabla = "Bitacora"
            DVVDatosBitacora.ValorDVH = DVHBitacora
            DVVDatosBitacora.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatosBitacora)
        Next
    End Sub

    Public Shared Function ObtenerDVHRegistro(DVH As DVHEN) As Integer
        Return ServicioAD.ObtenerDVHRegistro(DVH)
    End Function

End Class ' Integridad