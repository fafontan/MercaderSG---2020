Imports Datos
Imports Entidades
Imports Excepciones

Public Class Backup


    ''' 
    ''' <param name="Destino"></param>
    ''' <param name="volumen"></param>
    Public Shared Function EjecutarBackup(ByVal Destino As String, ByVal Volumen As Integer) As List(Of String)
        If ServicioAD.ExisteBD() Then
            Dim ListaArchivos As New List(Of String)
            ListaArchivos = ServicioAD.EjecutarBackup(Destino, Volumen)

            If ListaArchivos.Count > 0 Then
                Dim Bitacora As New BitacoraEN
                Dim UsuAut As Autenticar = Autenticar.Instancia()

                Bitacora.Descripcion = Seguridad.Encriptar("Realizó una copia de seguridad en " & Volumen & " parte/s")
                Bitacora.Criticidad = 2
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

                Return ListaArchivos
            Else
                Return ListaArchivos
            End If
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.BDNoExiste)
        End If
    End Function
End Class ' Backup