Imports Entidades
Imports Datos
Imports Servicios
Imports Excepciones
Imports System.Text.RegularExpressions
Public Class ClienteRN

    Public Shared Sub AltaCliente(ByVal Cliente As ClienteEN)
        Dim CuitDesencriptado As String = Cliente.Cuit

        Cliente.Cuit = Seguridad.Encriptar(Cliente.Cuit)

        If ClienteAD.ValidarCliente(Cliente.Cuit) > 0 Then
            Throw New WarningException(My.Resources.ArchivoIdioma.ClienteExistente)
            Exit Sub
        Else
            Dim ListaTelefonoEncriptada As New List(Of TelefonoEN)

            For Each item As TelefonoEN In Cliente.Telefono
                Dim UnTelefono As New TelefonoEN
                UnTelefono.Numero = Seguridad.Encriptar(item.Numero)

                ListaTelefonoEncriptada.Add(UnTelefono)
            Next

            Cliente.Telefono = ListaTelefonoEncriptada

            ClienteAD.AltaCliente(Cliente)

            Dim DVHDatos As New DVHEN
            DVHDatos.Tabla = "Cliente"
            DVHDatos.CodReg = Cliente.CodCli

            Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
            Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

            Dim DVVDatosCliente As New DVVEN
            DVVDatosCliente.Tabla = "Cliente"
            DVVDatosCliente.TipoAccion = "Alta"
            DVVDatosCliente.ValorDVH = DVH
            Integridad.GrabarDVV(DVVDatosCliente)

            Dim Bitacora As New BitacoraEN
            Dim UsuAut As Autenticar = Autenticar.Instancia()

            Bitacora.Descripcion = Seguridad.Encriptar("Alta de cliente con CUIT: " & CuitDesencriptado)
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

            Throw New InformationException(My.Resources.ArchivoIdioma.AltaCliente)
        End If
    End Sub

	''' 
	''' <param name="Cliente"></param>
    Public Shared Sub BajaCliente(ByVal Cliente As ClienteEN)

        ClienteAD.BajaCliente(Cliente)

        Dim UsuLog As Autenticar = Autenticar.Instancia()

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Cliente"
        DVHDatos.CodReg = Cliente.CodCli

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatosCliente As New DVVEN
        DVVDatosCliente.Tabla = "Cliente"
        DVVDatosCliente.ValorDVHAntiguo = ValorDVHAntiguo
        DVVDatosCliente.TipoAccion = "Baja Modificar"
        DVVDatosCliente.ValorDVH = DVH
        Integridad.GrabarDVV(DVVDatosCliente)

        Dim Bitacora As New BitacoraEN
        Bitacora.Descripcion = Seguridad.Encriptar("Baja de cliente con CUIT: " & Cliente.Cuit)
        Bitacora.Criticidad = 2
        Bitacora.Usuario = UsuLog.UsuarioLogueado

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

        Throw New InformationException(My.Resources.ArchivoIdioma.BajaCliente)

    End Sub

    Public Shared Function BuscarCliente(ByVal campo As String, ByVal valor As String) As List(Of ClienteEN)
        Dim ListaCliente As New List(Of ClienteEN)
        Dim ListaCliProcesada As New List(Of ClienteEN)

        If campo = My.Resources.ArchivoIdioma.CMBCuit Then
            valor = seguridad.Encriptar(valor)
        End If

        ListaCliente = ClienteAD.BuscarCliente(campo, valor)

        For Each item As ClienteEN In ListaCliente
            Dim UnCliente As New ClienteEN
            UnCliente.CodCli = item.CodCli
            UnCliente.RazonSocial = item.RazonSocial
            UnCliente.Cuit = seguridad.Desencriptar(item.Cuit)
            UnCliente.Direccion = item.Direccion
            UnCliente.Activo = item.Activo
            UnCliente.Localidad = item.Localidad

            ListaCliProcesada.Add(UnCliente)
        Next

        Return ListaCliProcesada
    End Function

    Public Shared Function CargarCliente() As List(Of ClienteEN)
        Dim ListaCliente As New List(Of ClienteEN)
        Dim ListaCliProcesada As New List(Of ClienteEN)

        ListaCliente = ClienteAD.CargarCliente()

        For Each item As ClienteEN In ListaCliente
            Dim UnCliente As New ClienteEN
            UnCliente.CodCli = item.CodCli
            UnCliente.RazonSocial = item.RazonSocial
            UnCliente.Cuit = Seguridad.Desencriptar(item.Cuit)
            UnCliente.Direccion = item.Direccion
            UnCliente.Activo = item.Activo
            UnCliente.Localidad = item.Localidad

            ListaCliProcesada.Add(UnCliente)
        Next

        Return ListaCliProcesada
    End Function

    Public Shared Sub EliminarTelefonoCliente(ByVal UnTelefono As TelefonoEN)
        Dim Bitacora As New BitacoraEN
        ClienteAD.EliminarTelefonoCliente(UnTelefono)
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

	''' 
	''' <param name="Cliente"></param>
    Public Shared Sub ModificarCliente(ByVal Cliente As ClienteEN)
        Dim ListaTelEncriptada As New List(Of TelefonoEN)

        For Each item As TelefonoEN In Cliente.Telefono
            Dim UnTelefono As New TelefonoEN

            UnTelefono.CodTel = item.CodTel
            UnTelefono.CodEn = item.CodEn
            UnTelefono.Numero = Seguridad.Encriptar(item.Numero)

            ListaTelEncriptada.Add(UnTelefono)
        Next

        Cliente.Telefono = ListaTelEncriptada

        ClienteAD.ModificarCliente(Cliente)

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Cliente"
        DVHDatos.CodReg = Cliente.CodCli

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatosCliente As New DVVEN
        DVVDatosCliente.Tabla = "Cliente"
        DVVDatosCliente.TipoAccion = "Baja Modificar"
        DVVDatosCliente.ValorDVHAntiguo = ValorDVHAntiguo
        DVVDatosCliente.ValorDVH = DVH
        Integridad.GrabarDVV(DVVDatosCliente)

        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos del cliente: " & Cliente.RazonSocial)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.ModificarCliente)
    End Sub

    Public Shared Function ObtenerCliente(ByVal CUIT As String) As ClienteEN
        Dim ClienteProcesado As ClienteEN

        Dim CodigoCliente As Integer = ClienteAD.ObtenerIDCliente(CUIT)

        ClienteProcesado = ClienteAD.ObtenerCliente(CodigoCliente)
        ClienteProcesado.Cuit = Seguridad.Desencriptar(ClienteProcesado.Cuit)

        Return ClienteProcesado
    End Function


    Public Shared Function ObtenerTelefonoCliente(ByVal CodCli As Integer) As List(Of TelefonoEN)
        Dim ListaTelProcesada As New List(Of TelefonoEN)
        Dim Listatel As New List(Of TelefonoEN)

        Listatel = ClienteAD.ObtenerTelefonoCliente(CodCli)

        For Each item As TelefonoEN In Listatel

            Dim UnTelefono As New TelefonoEN
            UnTelefono.CodTel = item.CodTel
            UnTelefono.CodEn = item.CodEn
            UnTelefono.Numero = Seguridad.Desencriptar(item.Numero)

            ListaTelProcesada.Add(UnTelefono)

        Next

        Return ListaTelProcesada

    End Function


End Class ' ClienteRN