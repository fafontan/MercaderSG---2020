Imports Datos
Imports Entidades
Imports Excepciones

Public Class Restore


    ''' 
    ''' <param name="Origen"></param>
    Public Shared Function EjecutarRestore(ByVal Origen As List(Of String)) As Boolean
        If ServicioAD.EjecutarRestore(Origen) Then
            Dim Bitacora As New BitacoraEN
            Dim UsuAut As Autenticar = Autenticar.Instancia()

            Bitacora.Descripcion = Seguridad.Encriptar("Restauro la base de datos")
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

            Return True
        Else
            Return False
        End If
    End Function

End Class ' Restore