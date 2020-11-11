Imports Entidades
Imports Datos
Imports Servicios

Public Class LogOut


    Public Shared Sub CerrarSesion(Usuario As String)
        Dim Bitacora As New BitacoraEN

        Bitacora.Descripcion = Seguridad.Encriptar("Cerró Sesión")
        Bitacora.Criticidad = 3
        Bitacora.Usuario = Usuario

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
    End Sub


End Class ' LogOut