Imports Entidades
Imports Datos
Imports Servicios
Imports Excepciones

Public Class ProveedorRN


	''' 
	''' <param name="Proveedor"></param>
    Public Shared Sub AltaProveedor(ByVal Proveedor As ProveedorEN)
        Dim CuitDesencriptado As String = Proveedor.Cuit

        Proveedor.Cuit = Seguridad.Encriptar(Proveedor.Cuit)

        If ProveedorAD.ValidarProveedor(Proveedor.Cuit) > 0 Then
            Throw New WarningException(My.Resources.ArchivoIdioma.ProveedorExistente)
            Exit Sub
        Else
            Dim ListaTelEncriptada As New List(Of TelefonoEN)

            For Each item As TelefonoEN In Proveedor.Telefono
                Dim UnTelefono As New TelefonoEN

                UnTelefono.Numero = Seguridad.Encriptar(item.Numero)

                ListaTelEncriptada.Add(UnTelefono)
            Next

            Proveedor.Telefono = ListaTelEncriptada

            ProveedorAD.AltaProveedor(Proveedor)

            Dim Bitacora As New BitacoraEN
            Dim UsuAut As Autenticar = Autenticar.Instancia()

            Bitacora.Descripcion = Seguridad.Encriptar("Alta de Proveedor: " & CuitDesencriptado)
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

            Throw New InformationException(My.Resources.ArchivoIdioma.AltaProveedor)
        End If
    End Sub

	''' 
	''' <param name="Proveedor"></param>
    Public Shared Sub BajaProveedor(ByVal Proveedor As ProveedorEN)
        ProveedorAD.BajaProveedor(Proveedor)

        Dim Bitacora As New BitacoraEN
        Dim UsuLog As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Baja de proveedor: " & Proveedor.RazonSocial)
        Bitacora.Criticidad = 2
        Bitacora.Usuario = UsuLog.UsuarioLogueado

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

        Throw New InformationException(My.Resources.ArchivoIdioma.BajaProveedor)
    End Sub

	''' 
	''' <param name="campo"></param>
	''' <param name="valor"></param>
    Public Shared Function BuscarProveedor(ByVal campo As String, ByVal valor As String) As List(Of ProveedorEN)
        Dim ListaProveedor As New List(Of ProveedorEN)
        Dim ListaProvProcesada As New List(Of ProveedorEN)

        If campo = My.Resources.ArchivoIdioma.CMBCuit Then
            valor = Seguridad.Encriptar(valor)
        End If

        ListaProveedor = ProveedorAD.BuscarProveedor(campo, valor)

        For Each item As ProveedorEN In ListaProveedor
            Dim UnProveedor As New ProveedorEN

            UnProveedor.CodProv = item.CodProv
            UnProveedor.RazonSocial = item.RazonSocial
            UnProveedor.Cuit = Seguridad.Desencriptar(item.Cuit)
            UnProveedor.Direccion = item.Direccion
            UnProveedor.Activo = item.Activo

            ListaProvProcesada.Add(UnProveedor)
        Next

        Return ListaProvProcesada
    End Function

    Public Shared Function CargarProveedor() As List(Of ProveedorEN)
        Dim ListaProveedor As New List(Of ProveedorEN)
        Dim ListaProvProcesada As New List(Of ProveedorEN)

        ListaProveedor = ProveedorAD.CargarProveedor()

        For Each item As ProveedorEN In ListaProveedor
            Dim UnProveedor As New ProveedorEN

            UnProveedor.CodProv = item.CodProv
            UnProveedor.RazonSocial = item.RazonSocial
            UnProveedor.Cuit = Seguridad.Desencriptar(item.Cuit)
            UnProveedor.CorreoElectronico = item.CorreoElectronico
            UnProveedor.Direccion = item.Direccion
            UnProveedor.Activo = item.Activo

            ListaProvProcesada.Add(UnProveedor)
        Next

        Return ListaProvProcesada
    End Function


    Public Shared Sub EliminarTelefonoProveedor(ByVal UnTelefono As TelefonoEN)
        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()
        ProveedorAD.EliminarTelefonoProveedor(UnTelefono)

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
	''' <param name="Proveedor"></param>
    Public Shared Sub ModificarProveedor(ByVal Proveedor As ProveedorEN)
        Dim ListaTelefonoEncriptada As New List(Of TelefonoEN)
        Dim CuitDesencriptado As String = Proveedor.Cuit

        Proveedor.Cuit = Seguridad.Encriptar(Proveedor.Cuit)

        For Each item As TelefonoEN In Proveedor.Telefono
            Dim UnTelefono As New TelefonoEN
            UnTelefono.CodTel = item.CodTel
            UnTelefono.CodEn = item.CodEn
            UnTelefono.Numero = Seguridad.Encriptar(item.Numero)

            ListaTelefonoEncriptada.Add(UnTelefono)
        Next
        Proveedor.Telefono = ListaTelefonoEncriptada

        ProveedorAD.ModificarProveedor(Proveedor)

        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos del proveedor: " & CuitDesencriptado)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.ModificarProveedor)
    End Sub

	''' 
	''' <param name="Cuit"></param>
    Public Shared Function ObtenerProveedor(ByVal Cuit As String) As ProveedorEN
        Dim ProvProcesado As New ProveedorEN

        Dim CodPRov As Integer = ProveedorAD.ObtenerIDProveedor(Cuit)

        ProvProcesado = ProveedorAD.ObtenerProveedor(CodPRov)
        ProvProcesado.Cuit = Seguridad.Desencriptar(ProvProcesado.Cuit)

        Return ProvProcesado
    End Function


    Public Shared Function ObtenerTelefonoProveedor(ByVal CodProv As Integer) As List(Of TelefonoEN)
        Dim ListaTelProcesada As New List(Of TelefonoEN)
        Dim ListaTelefonos As New List(Of TelefonoEN)

        ListaTelefonos = ProveedorAD.ObtenerTelefonoProveedor(CodProv)

        For Each item As TelefonoEN In ListaTelefonos
            Dim UnTelefono As New TelefonoEN
            UnTelefono.CodTel = item.CodTel
            UnTelefono.CodEn = item.CodEn
            UnTelefono.Numero = Seguridad.Desencriptar(item.Numero)

            ListaTelProcesada.Add(UnTelefono)
        Next

        Return ListaTelProcesada
    End Function


End Class ' ProveedorRN