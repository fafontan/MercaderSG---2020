Imports Entidades
Imports Datos
Imports Servicios
Imports Excepciones
Public Class FamiliaRN

    Public Shared Sub AltaFamilia(ByVal Familia As FamiliaEN)
        Dim FamiliaDesencriptada As String = Familia.Descripcion

        Familia.Descripcion = Seguridad.Encriptar(Familia.Descripcion)

        If FamiliaAD.ValidarFamilia(Familia.Descripcion) > 0 Then
            Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaExistente)
            Exit Sub
        Else
            FamiliaAD.AltaFamilia(Familia)

            Dim UsuAut As Autenticar = Autenticar.Instancia()

            Dim Bitacora As New BitacoraEN
            Bitacora.Descripcion = Seguridad.Encriptar("Alta de Familia: " & FamiliaDesencriptada)
            Bitacora.Criticidad = 3
            Bitacora.Usuario = UsuAut.UsuarioLogueado

            BitacoraAD.GrabarBitacora(Bitacora)

            Dim DVHDatosBitacora As New DVHEN
            DVHDatosBitacora.Tabla = "Bitacora"
            DVHDatosBitacora.CodReg = Bitacora.CodBit

            Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
            Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

            Dim DVVDatosBitacora As New DVVEN
            DVVDatosBitacora.Tabla = "Bitacora"
            DVVDatosBitacora.ValorDVH = DVHBitacora
            DVVDatosBitacora.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatosBitacora)

            Throw New InformationException(My.Resources.ArchivoIdioma.AltaFamilia)
        End If
    End Sub

    ''' 
    ''' <param name="FamiliaPatente"></param>
    Public Shared Sub AltaFamiliaPatente(ByVal FamiliaPatente As FamiliaEN)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        For Each item As FamPatEN In FamiliaPatente.FamPatL
            Dim UnaFamPat As New FamPatEN
            UnaFamPat.CodFam = item.CodFam
            UnaFamPat.CodPat = item.CodPat
            UnaFamPat.DescPat = item.DescPat

            If Not FamiliaAD.ValidarPatente(UnaFamPat) > 0 Then
                FamiliaAD.AltaFamiliaPatente(UnaFamPat)

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Fam_Pat"
                DVHDatos.CodReg = UnaFamPat.CodFam
                DVHDatos.CodAux = UnaFamPat.CodPat

                Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
                Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Fam_Pat"
                DVVDatos.TipoAccion = "Alta"
                DVVDatos.ValorDVH = DVH
                Integridad.GrabarDVV(DVVDatos)

                Dim Bitacora As New BitacoraEN
                Bitacora.Descripcion = Seguridad.Encriptar("Alta de Patente - Familia | Cod.Fam: " & UnaFamPat.CodFam & " y Cod.Pat: " & UnaFamPat.CodPat)
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

            End If
        Next

    End Sub

    ''' 
    ''' <param name="Familia"></param>
    Public Shared Sub BajaFamilia(ByVal Familia As FamiliaEN)

        Dim UsuAut As Autenticar = Autenticar.Instancia()

        If SePuedeEliminarFamilia(Familia.CodFam) = True Then

            'FamPat
            Dim ListaFamPat As New List(Of FamPatEN)
            ListaFamPat = FamiliaAD.ObtenerFamiliaPatente(Familia.CodFam)

            For Each item As FamPatEN In ListaFamPat
                Dim UnaFamPat As New FamPatEN
                UnaFamPat.CodFam = item.CodFam
                UnaFamPat.CodPat = item.CodPat

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Fam_Pat"
                DVHDatos.CodReg = UnaFamPat.CodFam
                DVHDatos.CodAux = UnaFamPat.CodPat
                Dim DVHFamPat As Integer = Integridad.ObtenerDVHRegistro(DVHDatos)

                FamiliaAD.EliminarFamiliaPatente(UnaFamPat)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Fam_Pat"
                DVVDatos.ValorDVH = DVHFamPat
                DVVDatos.TipoAccion = "Eliminar"
                Integridad.GrabarDVV(DVVDatos)
            Next

            'UsuFam
            Dim ListaUsuFam As New List(Of UsuFamEN)
            ListaUsuFam = FamiliaAD.ObtenerUsuarioFamilia(Familia.CodFam)

            For Each item As UsuFamEN In ListaUsuFam
                Dim UnaUsuFam As New UsuFamEN
                UnaUsuFam.CodUsu = item.CodUsu
                UnaUsuFam.CodFam = item.CodFam

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Usu_Fam"
                DVHDatos.CodReg = UnaUsuFam.CodUsu
                DVHDatos.CodAux = UnaUsuFam.CodFam
                Dim DVHFamPat As Integer = Integridad.ObtenerDVHRegistro(DVHDatos)

                FamiliaAD.EliminarUsuarioFamilia(UnaUsuFam)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Usu_Fam"
                DVVDatos.ValorDVH = DVHFamPat
                DVVDatos.TipoAccion = "Eliminar"
                Integridad.GrabarDVV(DVVDatos)
            Next

            FamiliaAD.BajaFamilia(Familia)

            Dim Bitacora As New BitacoraEN
            Bitacora.Descripcion = Seguridad.Encriptar("Baja de familia: " & Familia.Descripcion)
            Bitacora.Criticidad = 2
            Bitacora.Usuario = UsuAut.UsuarioLogueado

            BitacoraAD.GrabarBitacora(Bitacora)

            Dim DVHDatosBitacora As New DVHEN
            DVHDatosBitacora.Tabla = "Bitacora"
            DVHDatosBitacora.CodReg = Bitacora.CodBit

            Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
            Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

            Dim DVVDatosBitacora As New DVVEN
            DVVDatosBitacora.Tabla = "Bitacora"
            DVVDatosBitacora.ValorDVH = DVHBitacora
            DVVDatosBitacora.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatosBitacora)

            Throw New InformationException(My.Resources.ArchivoIdioma.BajaFamilia)
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.PrivilegiosFamilia)
            Exit Sub
        End If
    End Sub

    Shared Function SePuedeEliminarFamilia(CodFam As Integer) As Boolean
        For Each i As Integer In {22, 29, 37, 39}
            If FamiliaAD.VerificarPatentesFamilia(CodFam, i) = 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Function CargarFamilia() As List(Of FamiliaEN)
        Dim ListaFamilia As New List(Of FamiliaEN)
        Dim ListaFamiliaProcesada As New List(Of FamiliaEN)

        ListaFamilia = FamiliaAD.CargarFamilia()

        For Each item As FamiliaEN In ListaFamilia
            Dim UnaFamilia As New FamiliaEN
            UnaFamilia.CodFam = item.CodFam
            UnaFamilia.Descripcion = Seguridad.Desencriptar(item.Descripcion)

            ListaFamiliaProcesada.Add(UnaFamilia)
        Next

        Return ListaFamiliaProcesada
    End Function

    Public Shared Function CargarFamiliaConPatentes() As List(Of FamiliaEN)
        Dim ListaFamilia As New List(Of FamiliaEN)
        Dim ListaFamiliaProcesada As New List(Of FamiliaEN)

        ListaFamilia = FamiliaAD.CargarFamiliaConPatentes()

        For Each item As FamiliaEN In ListaFamilia
            Dim UnaFamilia As New FamiliaEN
            UnaFamilia.CodFam = item.CodFam
            UnaFamilia.Descripcion = Seguridad.Desencriptar(item.Descripcion)

            ListaFamiliaProcesada.Add(UnaFamilia)
        Next

        Return ListaFamiliaProcesada

    End Function


    Public Shared Sub ModificarFamilia(ByVal Familia As FamiliaEN)
        Dim FamiliaDesencriptada As String = Familia.Descripcion
        Familia.Descripcion = Seguridad.Encriptar(Familia.Descripcion)

        FamiliaAD.ModificarFamilia(Familia)

        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim Bitacora As New BitacoraEN
        Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos de la familia: " & FamiliaDesencriptada)
        Bitacora.Criticidad = 3
        Bitacora.Usuario = UsuAut.UsuarioLogueado

        BitacoraAD.GrabarBitacora(Bitacora)

        Dim DVHDatosBitacora As New DVHEN
        DVHDatosBitacora.Tabla = "Bitacora"
        DVHDatosBitacora.CodReg = Bitacora.CodBit

        Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

        Dim DVVDatosBitacora As New DVVEN
        DVVDatosBitacora.Tabla = "Bitacora"
        DVVDatosBitacora.ValorDVH = DVHBitacora
        DVVDatosBitacora.TipoAccion = "Alta"
        Integridad.GrabarDVV(DVVDatosBitacora)

        Throw New InformationException(My.Resources.ArchivoIdioma.ModificarFamilia)
    End Sub


    Public Shared Function ObtenerFamilia(ByVal Descripcion As String) As FamiliaEN
        Dim FamiliaProcesada As New FamiliaEN

        FamiliaProcesada = FamiliaAD.ObtenerFamilia(Descripcion)
        FamiliaProcesada.Descripcion = Seguridad.Desencriptar(FamiliaProcesada.Descripcion)

        Return FamiliaProcesada
    End Function

    Public Shared Sub BajaFamiliaPatente(Fam As String, BajaFamPat As FamiliaEN)
        Dim UsuAut As Autenticar = Autenticar.Instancia()
        Fam = Seguridad.Encriptar(Fam)
        Dim CodFam As Integer = FamiliaAD.ObtenerIDFamilia(Fam)

        For Each item As FamPatEN In BajaFamPat.FamPatL
            Dim UnaFamPat As New FamPatEN
            UnaFamPat.CodPat = item.CodPat

            If SePuedeQuitarPatente(CodFam) Then

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Fam_Pat"
                DVHDatos.CodReg = CodFam
                DVHDatos.CodAux = UnaFamPat.CodPat
                Dim DVHFamPat As Integer = Integridad.ObtenerDVHRegistro(DVHDatos)

                FamiliaAD.BajaFamiliaPatente(CodFam, UnaFamPat)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Fam_Pat"
                DVVDatos.ValorDVH = DVHFamPat
                DVVDatos.TipoAccion = "Eliminar"
                Integridad.GrabarDVV(DVVDatos)

                Dim BitacoraUsu_Pat As New BitacoraEN
                BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Eliminó Patente - Familia | Cod.Fam: " & CodFam & " y Cod.Pat: " & UnaFamPat.CodPat)
                BitacoraUsu_Pat.Criticidad = 2
                BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado

                BitacoraAD.GrabarBitacora(BitacoraUsu_Pat)

                Dim DVHDatosBitacora As New DVHEN
                DVHDatosBitacora.Tabla = "Bitacora"
                DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit

                Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
                Dim DVHBitacoraInt As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

                Dim DVVDatosBitacora As New DVVEN
                DVVDatosBitacora.Tabla = "Bitacora"
                DVVDatosBitacora.ValorDVH = DVHBitacora
                DVVDatosBitacora.TipoAccion = "Alta"
                Integridad.GrabarDVV(DVVDatosBitacora)
            End If
        Next
    End Sub

    Shared Function SePuedeQuitarPatente(CodFam As Integer) As Boolean
        For Each i As Integer In {22, 29, 37, 39}
            If FamiliaAD.VerificarPatentesFamilia(CodFam, i) = 0 Then
                Return False
            End If
        Next
        Return True
    End Function

End Class ' FamiliaRN