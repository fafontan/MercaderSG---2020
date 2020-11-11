Imports Entidades
Imports Datos
Imports Servicios
Imports Excepciones
Imports System.Text.RegularExpressions

Public Class UsuarioRN

    Public Shared Sub AltaPatenteUsuario(ByVal UsuEnc As String, ByVal PatUsu As UsuarioEN)
        Dim CodUsu As Integer = UsuarioAD.ObtenerIDUsuario(UsuEnc)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        For Each item As PatUsuEN In PatUsu.UsuPatL

            Dim UnaPatUsu As New PatUsuEN
            UnaPatUsu.CodPat = item.CodPat
            If UsuarioAD.ValidarUsuario(UsuEnc) > 0 Then

                If UsuarioAD.AltaPatenteUsuario(CodUsu, UnaPatUsu) = True Then
                    Dim DVHDatos As New DVHEN
                    DVHDatos.Tabla = "Usu_Pat"
                    DVHDatos.CodReg = CodUsu
                    DVHDatos.CodAux = UnaPatUsu.CodPat

                    Dim DVHUsu_Pat As Integer = Integridad.CalcularDVH(DVHDatos)
                    Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVHUsu_Pat)

                    Dim DVVDatos As New DVVEN
                    DVVDatos.Tabla = "Usu_Pat"
                    DVVDatos.TipoAccion = "Alta"
                    DVVDatos.ValorDVH = DVHUsu_Pat
                    Integridad.GrabarDVV(DVVDatos)

                    Dim BitacoraUsu_Pat As New BitacoraEN
                    BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Alta Patente - Usuario | Cod.Usu: " & CodUsu & " y Cod.Pat: " & UnaPatUsu.CodPat)
                    BitacoraUsu_Pat.Criticidad = 3
                    BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado

                    BitacoraAD.GrabarBitacora(BitacoraUsu_Pat)

                    Dim DVHDatosBitacora As New DVHEN
                    DVHDatosBitacora.Tabla = "Bitacora"
                    DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit

                    Dim DVHBitacoraUsu_Pat As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
                    Dim ValorDVHAntiguoBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacoraUsu_Pat)

                    Dim DVVDatosBitacora As New DVVEN
                    DVVDatosBitacora.Tabla = "Bitacora"
                    DVVDatosBitacora.ValorDVH = DVHBitacoraUsu_Pat
                    DVVDatosBitacora.TipoAccion = "Alta"
                    Integridad.GrabarDVV(DVVDatosBitacora)
                Else
                    Dim DVHDatoFalso As New DVHEN
                    DVHDatoFalso.Tabla = "Usu_Pat"
                    DVHDatoFalso.CodReg = CodUsu
                    DVHDatoFalso.CodAux = UnaPatUsu.CodPat

                    Dim DVHUsu_PatFalso As Integer = Integridad.CalcularDVH(DVHDatoFalso)
                    Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatoFalso, DVHUsu_PatFalso)

                    Dim DVVDatos As New DVVEN
                    DVVDatos.Tabla = "Usu_Pat"
                    DVVDatos.TipoAccion = "Baja Modificar"
                    DVVDatos.ValorDVH = DVHUsu_PatFalso
                    DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
                    Integridad.GrabarDVV(DVVDatos)

                    Dim BitacoraUsu_Pat As New BitacoraEN
                    BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Se asigno la Cod.Pat: " & UnaPatUsu.CodPat & " al Cod.Usu: " & CodUsu)
                    BitacoraUsu_Pat.Criticidad = 3
                    BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado

                    BitacoraAD.GrabarBitacora(BitacoraUsu_Pat)

                    Dim DVHDatosBitacora As New DVHEN
                    DVHDatosBitacora.Tabla = "Bitacora"
                    DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit

                    Dim DVHBitacoraUsu_Pat As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
                    Dim ValorDVHAntiguoBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacoraUsu_Pat)

                    Dim DVVDatosBitacora As New DVVEN
                    DVVDatosBitacora.Tabla = "Bitacora"
                    DVVDatosBitacora.ValorDVH = DVHBitacoraUsu_Pat
                    DVVDatosBitacora.TipoAccion = "Alta"
                    Integridad.GrabarDVV(DVVDatosBitacora)
                End If
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
            End If
        Next

    End Sub

    Public Shared Sub AltaUsuario(ByVal Usuario As UsuarioEN)
        Dim UsuarioDesencriptado As String = Usuario.Usuario

        Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario)
        Usuario.Contraseña = Seguridad.EncriptarMD5(Usuario.Contraseña)

        If UsuarioAD.ValidarUsuario(Usuario.Usuario) > 0 Then
            Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioExistente)
            Exit Sub
        Else
            Dim ListaTelefonoEncriptada As New List(Of TelefonoEN)

            For Each item As TelefonoEN In Usuario.Telefono
                Dim unTelefono As New TelefonoEN
                unTelefono.Numero = Seguridad.Encriptar(item.Numero)

                ListaTelefonoEncriptada.Add(unTelefono)
            Next

            Usuario.Telefono = ListaTelefonoEncriptada

            UsuarioAD.AltaUsuario(Usuario)
            Dim UsuAut As Autenticar = Autenticar.Instancia()

            Dim DVHDatos As New DVHEN
            DVHDatos.Tabla = "Usuario"
            DVHDatos.CodReg = Usuario.CodUsu

            Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
            Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

            Dim DVVDatos As New DVVEN
            DVVDatos.Tabla = "Usuario"
            DVVDatos.ValorDVH = DVH
            DVVDatos.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatos)

            Dim Bitacora As New BitacoraEN

            Bitacora.Descripcion = Seguridad.Encriptar("Alta de usuario: " & UsuarioDesencriptado)
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

            Throw New InformationException(My.Resources.ArchivoIdioma.AltaUsuario)
        End If
    End Sub


    Public Shared Sub AltaUsuarioFamilia(ByVal Usuario As String, ByVal UsuFam As UsuarioEN)
        Dim ListaMensajes As New List(Of UsuFamEN)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        If UsuarioAD.ValidarUsuario(Usuario) > 0 Then
            Dim CodUsu As Integer = UsuarioAD.ObtenerIDUsuario(Usuario)

            For Each item As UsuFamEN In UsuFam.UsuFamL
                Dim UnUsuFam As New UsuFamEN
                UnUsuFam.CodFam = item.CodFam
                UnUsuFam.DescFam = item.DescFam

                If UsuarioAD.ValidarUsuFam(CodUsu, UnUsuFam) > 0 Then
                    ListaMensajes.Add(UnUsuFam)
                Else
                    If UsuarioAD.AltaUsuarioFamilia(CodUsu, UnUsuFam) = True Then
                        Dim DVHDatosFam As New DVHEN
                        DVHDatosFam.Tabla = "Usu_Fam"
                        DVHDatosFam.CodReg = CodUsu
                        DVHDatosFam.CodAux = UnUsuFam.CodFam

                        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatosFam)
                        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatosFam, DVH)

                        Dim DVVDatos As New DVVEN
                        DVVDatos.Tabla = "Usu_Fam"
                        DVVDatos.ValorDVH = DVH
                        DVVDatos.TipoAccion = "Alta"
                        Integridad.GrabarDVV(DVVDatos)

                        Dim Bitacora As New BitacoraEN
                        Bitacora.Descripcion = Seguridad.Encriptar("Alta Usuario - Familia | Cod.Usu: " & CodUsu & " y Cod.Fam: " & UnUsuFam.CodFam)
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
                End If
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
        End If

        If ListaMensajes.Count > 0 Then
            Throw New WarningException(ListaMensajes)
        End If

    End Sub


    Public Shared Sub BajaUsuario(ByVal Usuario As UsuarioEN)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim DTPatentesUsuario As DataTable
        DTPatentesUsuario = PatenteAD.ObtenerPatenteUsuario(Usuario.CodUsu)
        Dim EstadoPat As Boolean = True

        For Each Row As DataRow In DTPatentesUsuario.Rows
            If Row("CodPat") = 22 Then
                If UsuarioAD.VerificarPatentesUsuario(22) Then
                    EstadoPat = True
                    Continue For
                Else
                    EstadoPat = False
                    Exit For
                End If
            End If

            If Row("CodPat") = 29 Then
                If UsuarioAD.VerificarPatentesUsuario(29) Then
                    EstadoPat = True
                    Continue For
                Else
                    EstadoPat = False
                    Exit For
                End If
            End If

            If Row("CodPat") = 37 Then
                If UsuarioAD.VerificarPatentesUsuario(37) Then
                    EstadoPat = True
                    Continue For
                Else
                    EstadoPat = False
                    Exit For
                End If
            End If

            If Row("CodPat") = 39 Then
                If UsuarioAD.VerificarPatentesUsuario(39) Then
                    EstadoPat = True
                    Continue For
                Else
                    EstadoPat = False
                    Exit For
                End If
            End If
        Next

        If EstadoPat Then

            'UsuFam
            Dim ListaUsuFam As New List(Of UsuFamEN)
            ListaUsuFam = FamiliaAD.ObtenerFamiliaUsuario(Usuario.CodUsu)

            For Each item As UsuFamEN In ListaUsuFam
                Dim UnaUsuFam As New UsuFamEN
                UnaUsuFam.CodUsu = item.CodUsu
                UnaUsuFam.CodFam = item.CodFam

                Dim DVHDatosUsuFam As New DVHEN
                DVHDatosUsuFam.Tabla = "Usu_Fam"
                DVHDatosUsuFam.CodReg = UnaUsuFam.CodUsu
                DVHDatosUsuFam.CodAux = UnaUsuFam.CodFam
                Dim DVHUsuFam As Integer = Integridad.ObtenerDVHRegistro(DVHDatosUsuFam)

                FamiliaAD.EliminarUsuarioFamilia(UnaUsuFam)

                Dim DVVDatosUsuFam As New DVVEN
                DVVDatosUsuFam.Tabla = "Usu_Fam"
                DVVDatosUsuFam.ValorDVH = DVHUsuFam
                DVVDatosUsuFam.TipoAccion = "Eliminar"
                Integridad.GrabarDVV(DVVDatosUsuFam)
            Next

            'UsuPat
            Dim ListaPatUsu As New List(Of PatUsuEN)
            ListaPatUsu = UsuarioAD.ObtenerPatentesUsuario(Usuario.CodUsu)

            For Each item As PatUsuEN In ListaPatUsu
                Dim UnaPatUsu As New PatUsuEN
                UnaPatUsu.CodUsu = item.CodUsu
                UnaPatUsu.CodPat = item.CodPat

                Dim DVHDatosPatUsu As New DVHEN
                DVHDatosPatUsu.Tabla = "Usu_Pat"
                DVHDatosPatUsu.CodReg = UnaPatUsu.CodUsu
                DVHDatosPatUsu.CodAux = UnaPatUsu.CodPat
                Dim DVHPatUsu As Integer = Integridad.ObtenerDVHRegistro(DVHDatosPatUsu)

                UsuarioAD.EliminarPatentesUsuario(UnaPatUsu)

                Dim DVVDatosPatUsu As New DVVEN
                DVVDatosPatUsu.Tabla = "Usu_Pat"
                DVVDatosPatUsu.ValorDVH = DVHPatUsu
                DVVDatosPatUsu.TipoAccion = "Eliminar"
                Integridad.GrabarDVV(DVVDatosPatUsu)
            Next

            UsuarioAD.BajaUsuario(Usuario)

            Dim DVHDatos As New DVHEN
            DVHDatos.Tabla = "Usuario"
            DVHDatos.CodReg = Usuario.CodUsu

            Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
            Dim ValorDVHAntiguoUsu As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

            Dim DVVDatos As New DVVEN
            DVVDatos.Tabla = "Usuario"
            DVVDatos.ValorDVH = DVH
            DVVDatos.TipoAccion = "Baja Modificar"
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguoUsu
            Integridad.GrabarDVV(DVVDatos)

            Dim Bitacora As New BitacoraEN

            Bitacora.Descripcion = Seguridad.Encriptar("Baja de usuario: " & Usuario.Usuario)
            Bitacora.Criticidad = 2
            Bitacora.Usuario = UsuAut.UsuarioLogueado

            BitacoraAD.GrabarBitacora(Bitacora)

            Dim DVHDatosBitacora As New DVHEN
            DVHDatosBitacora.Tabla = "Bitacora"
            DVHDatosBitacora.CodReg = Bitacora.CodBit

            Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
            Dim ValorDVHAntiguoBitBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

            Dim DVVDatosBitacora As New DVVEN
            DVVDatosBitacora.Tabla = "Bitacora"
            DVVDatosBitacora.ValorDVH = DVHBitacora
            DVVDatosBitacora.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatosBitacora)

            Throw New InformationException(My.Resources.ArchivoIdioma.BajaUsuario)
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.PrivilegiosUsuario)
            Exit Sub
        End If
    End Sub

    Public Shared Function BuscarUsuario(ByVal campo As String, ByVal texto As String) As List(Of UsuarioEN)
        Dim ListaUsuarios As New List(Of UsuarioEN)
        Dim ListaUsuProcesada As New List(Of UsuarioEN)
        Dim Seguridad As New Seguridad

        If campo = My.Resources.ArchivoIdioma.CMBUsuario Then
            texto = Seguridad.Encriptar(texto)
        End If

        ListaUsuarios = UsuarioAD.BuscarUsuario(campo, texto)

        For Each item As UsuarioEN In ListaUsuarios
            Dim UnUsuario As New UsuarioEN
            UnUsuario.CodUsu = item.CodUsu
            UnUsuario.Usuario = Seguridad.Desencriptar(item.Usuario)
            UnUsuario.Apellido = item.Apellido
            UnUsuario.Nombre = item.Nombre
            UnUsuario.CorreoElectronico = item.CorreoElectronico
            UnUsuario.Edad = item.Edad

            ListaUsuProcesada.Add(UnUsuario)
        Next

        Return ListaUsuProcesada
    End Function


    Public Shared Sub CambiarContraseña(ByVal UsuarioLogueado As String, ByVal ContraseñaAnterior As String, ByVal NuevaContraseña As String)
        Dim UsuEnc As String = Seguridad.Encriptar(UsuarioLogueado)
        Dim ConAntEnc As String = Seguridad.EncriptarMD5(ContraseñaAnterior)
        Dim NuevaCon As String = Seguridad.EncriptarMD5(NuevaContraseña)

        If UsuarioAD.ValidarContraseña(UsuEnc, ConAntEnc) > 0 Then

            UsuarioAD.CambiarContraseña(UsuEnc, NuevaCon)
            Dim UsuAut As Autenticar = Autenticar.Instancia()

            Dim DVHDatos As New DVHEN
            DVHDatos.Tabla = "Usuario"
            DVHDatos.CodReg = UsuAut.CodUsuLogueado

            Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
            Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

            Dim DVVDatos As New DVVEN
            DVVDatos.Tabla = "Usuario"
            DVVDatos.ValorDVH = DVH
            DVVDatos.TipoAccion = "Baja Modificar"
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
            Integridad.GrabarDVV(DVVDatos)

            Dim Bitacora As New BitacoraEN

            Bitacora.Descripcion = Seguridad.Encriptar("Cambio su contraseña")
            Bitacora.Criticidad = 3
            Bitacora.Usuario = UsuarioLogueado

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

            Throw New InformationException(My.Resources.ArchivoIdioma.ContraseñaCambiada)
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.ContraseñaInvalida)
        End If
    End Sub

    Public Shared Function CargarUsuario() As List(Of UsuarioEN)

        Dim ListaUsuarios As New List(Of UsuarioEN)
        Dim ListaUsuProcesada As New List(Of UsuarioEN)

        ListaUsuarios = UsuarioAD.CargarUsuario()

        For Each item As UsuarioEN In ListaUsuarios
            Dim UnUsuario As New UsuarioEN
            UnUsuario.CodUsu = item.CodUsu
            UnUsuario.Usuario = Seguridad.Desencriptar(item.Usuario)
            UnUsuario.Apellido = item.Apellido
            UnUsuario.Nombre = item.Nombre
            UnUsuario.CorreoElectronico = item.CorreoElectronico
            UnUsuario.Edad = item.Edad
            UnUsuario.Bloqueado = item.Bloqueado

            ListaUsuProcesada.Add(UnUsuario)
        Next

        Return ListaUsuProcesada
    End Function


    Public Shared Sub DenegarPatenteUsuario(ByVal UsuEnc As String, ByVal PatUsu As UsuarioEN)
        Dim CodUsu As Integer = UsuarioAD.ObtenerIDUsuario(UsuEnc)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        For Each item As PatUsuEN In PatUsu.UsuPatL

            Dim UnaPatUsu As New PatUsuEN
            UnaPatUsu.CodPat = item.CodPat

            Dim EstadoPat As Boolean = True

            If item.CodPat = 22 Then
                If UsuarioAD.VerificarPatentesUsuario(22) Then
                    EstadoPat = True
                Else
                    EstadoPat = False
                End If
            End If

            If item.CodPat = 29 Then
                If UsuarioAD.VerificarPatentesUsuario(29) Then
                    EstadoPat = True
                Else
                    EstadoPat = False
                End If
            End If

            If item.CodPat = 37 Then
                If UsuarioAD.VerificarPatentesUsuario(37) Then
                    EstadoPat = True
                Else
                    EstadoPat = False
                End If
            End If

            If item.CodPat = 39 Then
                If UsuarioAD.VerificarPatentesUsuario(39) Then
                    EstadoPat = True
                Else
                    EstadoPat = False
                End If
            End If

            If EstadoPat Then
                UsuarioAD.DenegarPatenteUsuario(CodUsu, UnaPatUsu)

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Usu_Pat"
                DVHDatos.CodReg = CodUsu
                DVHDatos.CodAux = UnaPatUsu.CodPat

                Dim DVHUsu_Pat As Integer = Integridad.CalcularDVH(DVHDatos)
                Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVHUsu_Pat)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Usu_Pat"
                DVVDatos.ValorDVH = DVHUsu_Pat
                DVVDatos.TipoAccion = "Baja Modificar"
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
                Integridad.GrabarDVV(DVVDatos)

                Dim BitacoraUsu_Pat As New BitacoraEN
                BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Denego Patente - Usuario | Cod.Pat: " & UnaPatUsu.CodPat & " del Cod.Usu: " & CodUsu)
                BitacoraUsu_Pat.Criticidad = 2
                BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado

                BitacoraAD.GrabarBitacora(BitacoraUsu_Pat)

                Dim DVHDatosBitacora As New DVHEN
                DVHDatosBitacora.Tabla = "Bitacora"
                DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit

                Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
                Dim ValorDVHAntiguoBit As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

                Dim DVVDatosBitacora As New DVVEN
                DVVDatosBitacora.Tabla = "Bitacora"
                DVVDatosBitacora.ValorDVH = DVHBitacora
                DVVDatosBitacora.TipoAccion = "Alta"
                Integridad.GrabarDVV(DVVDatosBitacora)
            Else
                Continue For
            End If
        Next
    End Sub


    Public Shared Sub DesbloquearUsuario(ByVal Usuario As String)
        Dim UsuarioDesencriptado As String = Usuario

        Usuario = Seguridad.Encriptar(Usuario)
        Dim CodUsu As Integer = UsuarioAD.ObtenerIDUsuario(Usuario)
        UsuarioAD.DesbloquearUsuario(Usuario)
        Dim UsuAut As Autenticar = Autenticar.Instancia()
        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Usuario"
        DVHDatos.CodReg = CodUsu

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatos As New DVVEN
        DVVDatos.Tabla = "Usuario"
        DVVDatos.ValorDVH = DVH
        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
        DVVDatos.TipoAccion = "Baja Modificar"
        Integridad.GrabarDVV(DVVDatos)

        Dim Bitacora As New BitacoraEN

        Bitacora.Descripcion = Seguridad.Encriptar("Desbloqueo al usuario: " & UsuarioDesencriptado)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.DesbloquearUsuario)
    End Sub


    Public Shared Sub EliminarTelefonoUsuario(ByVal UnTelefono As TelefonoEN)
        Dim Bitacora As New BitacoraEN
        UsuarioAD.EliminarTelefonoUsuario(UnTelefono)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Eliminó el telefono: " & UnTelefono.Numero)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.EliminarTelefono)
    End Sub

    Public Shared Function Logueo(ByVal Usuario As UsuarioEN) As Boolean
        Dim Bitacora As New BitacoraEN

        Dim UsuarioDesencriptado As String = Usuario.Usuario
        Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario)
        Usuario.Contraseña = Seguridad.EncriptarMD5(Usuario.Contraseña)

        Dim CodUsu As Integer

        If UsuarioAD.ObtenerCIIUsuario(Usuario.Usuario) < 3 Then
            CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario.Usuario)
            Usuario.CodUsu = CodUsu

            If UsuarioAD.Logueo(Usuario) = False Then

                UsuarioAD.ModificarCIIUsuario(Usuario.Usuario)

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Usuario"
                DVHDatos.CodReg = Usuario.CodUsu

                Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
                Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Usuario"
                DVVDatos.TipoAccion = "Baja Modificar"
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
                DVVDatos.ValorDVH = DVH
                Integridad.GrabarDVV(DVVDatos)

                Bitacora.Descripcion = Seguridad.Encriptar("Error al ingresar al sistema")
                Bitacora.Criticidad = 2
                Bitacora.Usuario = UsuarioDesencriptado

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

                Return False
            Else
                UsuarioAD.ResetearCII(Usuario.Usuario)

                Dim UsuAut As Autenticar = Autenticar.Instancia()

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Usuario"
                DVHDatos.CodReg = Usuario.CodUsu

                Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
                Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Usuario"
                DVVDatos.TipoAccion = "Baja Modificar"
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
                DVVDatos.ValorDVH = DVH
                Integridad.GrabarDVV(DVVDatos)

                UsuAut.UsuarioLogueado = Seguridad.Desencriptar(Usuario.Usuario)
                UsuAut.CodUsuLogueado = Usuario.CodUsu

                Bitacora.Descripcion = Seguridad.Encriptar("Ingresó al sistema")
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

                Return True
            End If
        Else
            CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario.Usuario)
            Usuario.CodUsu = CodUsu

            Dim DTPatentesUsuario As DataTable
            DTPatentesUsuario = PatenteAD.ObtenerPatenteUsuario(Usuario.CodUsu)
            Dim EstadoPat As Boolean = True

            For Each Row As DataRow In DTPatentesUsuario.Rows
                If Row("CodPat") = 22 Then
                    If UsuarioAD.VerificarPatentesUsuario(22) Then
                        EstadoPat = True
                        Continue For
                    Else
                        EstadoPat = False
                        Exit For
                    End If
                End If

                If Row("CodPat") = 29 Then
                    If UsuarioAD.VerificarPatentesUsuario(29) Then
                        EstadoPat = True
                        Continue For
                    Else
                        EstadoPat = False
                        Exit For
                    End If
                End If

                If Row("CodPat") = 37 Then
                    If UsuarioAD.VerificarPatentesUsuario(37) Then
                        EstadoPat = True
                        Continue For
                    Else
                        EstadoPat = False
                        Exit For
                    End If
                End If

                If Row("CodPat") = 39 Then
                    If UsuarioAD.VerificarPatentesUsuario(39) Then
                        EstadoPat = True
                        Continue For
                    Else
                        EstadoPat = False
                        Exit For
                    End If
                End If
            Next

            If EstadoPat Then
                UsuarioAD.BloquearUsuario(Usuario.Usuario)

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Usuario"
                DVHDatos.CodReg = Usuario.CodUsu

                Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
                Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Usuario"
                DVVDatos.ValorDVH = DVH
                DVVDatos.TipoAccion = "Baja Modificar"
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
                Integridad.GrabarDVV(DVVDatos)

                Bitacora.Descripcion = Seguridad.Encriptar("Se ha bloqueado al usuario")
                Bitacora.Criticidad = 2
                Bitacora.Usuario = UsuarioDesencriptado

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

                Throw New CriticalException(My.Resources.ArchivoIdioma.UsuarioBloqueado)
            Else
                UsuarioAD.ResetearCII(Usuario.Usuario)

                Dim DVHDatos As New DVHEN
                DVHDatos.Tabla = "Usuario"
                DVHDatos.CodReg = Usuario.CodUsu

                Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
                Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

                Dim DVVDatos As New DVVEN
                DVVDatos.Tabla = "Usuario"
                DVVDatos.ValorDVH = DVH
                DVVDatos.TipoAccion = "Baja Modificar"
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
                Integridad.GrabarDVV(DVVDatos)

                Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioRevision)
            End If
        End If

    End Function


    Public Shared Sub ModificarUsuario(ByVal Usuario As UsuarioEN)

        Dim ListaTelefonoEncriptada As New List(Of TelefonoEN)

        Dim UsuarioDesencriptado As String = Usuario.Usuario
        Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario)

        For Each item As TelefonoEN In Usuario.Telefono
            Dim UnTelefono As New TelefonoEN
            UnTelefono.CodTel = item.CodTel
            UnTelefono.CodEn = item.CodEn
            UnTelefono.Numero = Seguridad.Encriptar(item.Numero)

            ListaTelefonoEncriptada.Add(UnTelefono)
        Next
        Usuario.Telefono = ListaTelefonoEncriptada

        UsuarioAD.ModificarUsuario(Usuario)

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Usuario"
        DVHDatos.CodReg = Usuario.CodUsu

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatos As New DVVEN
        DVVDatos.Tabla = "Usuario"
        DVVDatos.ValorDVH = DVH
        DVVDatos.TipoAccion = "Baja Modificar"
        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
        Integridad.GrabarDVV(DVVDatos)

        Dim UsuAut As Autenticar = Autenticar.Instancia()
        Dim Bitacora As New BitacoraEN

        Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos del usuario: " & UsuarioDesencriptado)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.ModificarUsuario)
    End Sub


    Public Shared Function ObtenerTelefonoUsuario(ByVal CodUsuario As Integer) As List(Of TelefonoEN)
        Dim ListaTelProcesada As New List(Of TelefonoEN)
        Dim ListaTelefonos As New List(Of TelefonoEN)

        ListaTelefonos = UsuarioAD.ObtenerTelefonoUsuario(CodUsuario)

        For Each item As TelefonoEN In ListaTelefonos
            Dim UnTelefono As New TelefonoEN
            UnTelefono.CodTel = item.CodTel
            UnTelefono.CodEn = item.CodEn
            UnTelefono.Numero = Seguridad.Desencriptar(item.Numero)

            ListaTelProcesada.Add(UnTelefono)
        Next

        Return ListaTelProcesada
    End Function


    Public Shared Function ObtenerUsuario(ByVal Usuario As String) As UsuarioEN
        Dim UsuarioProcesado As UsuarioEN
        Dim CodigoUsuario As Integer = UsuarioAD.ObtenerIDUsuario(Usuario)

        UsuarioProcesado = UsuarioAD.ObtenerUsuario(CodigoUsuario)
        UsuarioProcesado.Usuario = Seguridad.Desencriptar(UsuarioProcesado.Usuario)

        Return UsuarioProcesado
    End Function


    Public Shared Sub ResetearContraseña(Usuario As UsuarioEN)
        Dim UsuarioDesencriptado As String = Usuario.Usuario
        Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario)
        Usuario.Contraseña = Seguridad.EncriptarMD5(Usuario.Contraseña)

        UsuarioAD.ResetearContraseña(Usuario)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Usuario"
        DVHDatos.CodReg = Usuario.CodUsu

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatos As New DVVEN
        DVVDatos.Tabla = "Usuario"
        DVVDatos.ValorDVH = DVH
        DVVDatos.TipoAccion = "Baja Modificar"
        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
        Integridad.GrabarDVV(DVVDatos)

        If Usuario.TipoAccion = False Then
            Dim Bitacora As New BitacoraEN

            Bitacora.Descripcion = Seguridad.Encriptar("Cambió la contraseña de: " & UsuarioDesencriptado)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.ResetContrasena)
    End Sub

    Public Shared Function ObtenerUsuariosErrorIntegridad() As List(Of String)
        Dim ListaUsuarios As New List(Of String)
        Dim ListaUsuariosDesencriptada As New List(Of String)

        ListaUsuarios = UsuarioAD.ObtenerUsuariosErrorIntegridad()

        For Each item As String In ListaUsuarios
            Dim UsuDesencriptado As String
            UsuDesencriptado = Seguridad.Desencriptar(item)

            ListaUsuariosDesencriptada.Add(UsuDesencriptado)
        Next

        Return ListaUsuariosDesencriptada
    End Function

End Class