Imports Entidades
Imports Datos
Imports Excepciones
Imports Servicios
Public Class LocalidadRN
    Public Shared Sub AltaLocalidad(Localidad As LocalidadEN)

        If LocalidadAD.ValidarLocalidad(Localidad.Descripcion) > 0 Then
            Throw New WarningException(My.Resources.ArchivoIdioma.LocalidadExistente)
            Exit Sub
        Else
            Dim Bitacora As New BitacoraEN
            Dim UsuLog As Autenticar = Autenticar.Instancia()

            Bitacora.Descripcion = Seguridad.Encriptar("Alta de localidad: " & Localidad.Descripcion)
            Bitacora.Criticidad = 3
            Bitacora.Usuario = UsuLog.UsuarioLogueado

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

            LocalidadAD.AltaLocalidad(Localidad)

            Throw New InformationException(My.Resources.ArchivoIdioma.AltaLocalidad)
        End If
    End Sub

    Public Shared Function CargarProvincia() As List(Of ProvinciaEN)
        Return LocalidadAD.CargarProvincia()
    End Function

    Public Shared Function CargarLocalidad() As List(Of LocalidadEN)
        Return LocalidadAD.CargarLocalidad()
    End Function

End Class
