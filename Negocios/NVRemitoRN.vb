Imports Entidades
Imports Datos
Imports Servicios
Imports Excepciones

Public Class NVRemitoRN

    Public Shared Sub CargarRemitoNV(DS As DataSet, NroNota As String)
        If NVRemitoAD.VerificarRemitoNV(NroNota) > 0 Then

            NVRemitoAD.CargarRemitoNV(DS, NroNota)

            For Each row As DataRow In DS.Tables("Cliente").Rows
                row("Cuit") = Seguridad.Desencriptar(CStr(row("Cuit")))
            Next

            For Each row As DataRow In DS.Tables("Producto").Rows
                row("Nombre") = Seguridad.Desencriptar(CStr(row("Nombre")))
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.RemitoNoExiste)
        End If
    End Sub

    Public Shared Sub GenerarRemito(NroNota As String)
        Dim CodigoNota As Integer = NotaVentaAD.ObtenerIDNotaVenta(NroNota)
        Dim RENV As New NVRemitoEN

        If NVRemitoAD.ValidarRemitoNV(CodigoNota) > 0 Then
            Throw New WarningException(My.Resources.ArchivoIdioma.RemitoNVExiste)
        Else
            NVRemitoAD.GenerarRemito(CodigoNota, RENV)
        End If

        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Alta de Remito | Cod: " & RENV.CodRemito)
        Bitacora.Criticidad = 3
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

        Throw New InformationException(My.Resources.ArchivoIdioma.RemitoNVGenerado)
    End Sub
End Class
