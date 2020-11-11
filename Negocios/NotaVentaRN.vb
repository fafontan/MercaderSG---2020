Imports Entidades
Imports Datos
Imports Excepciones
Imports Servicios
Public Class NotaVentaRN


	''' 
	''' <param name="NotaVenta"></param>
    Public Shared Sub BajaNotaVenta(ByVal NotaVenta As NotaVentaEN)
        NotaVentaAD.BajaNotaVenta(NotaVenta)

        Dim CodNot As Integer = NotaVentaAD.ObtenerIDNotaVenta(NotaVenta.NroNota)
        Dim ListaDetalle As New List(Of DetalleEN)
        ListaDetalle = NotaVentaAD.ObtenerDetalleNV(CodNot)

        For Each item As DetalleEN In ListaDetalle
            Dim Detalle As New DetalleEN
            Detalle.CodProd = item.CodProd
            Detalle.Cantidad = item.Cantidad
            NotaVentaAD.ActualizarCantidadProducto(Detalle)

            Dim DVHDatos As New DVHEN
            DVHDatos.Tabla = "Producto"
            DVHDatos.CodReg = item.CodProd

            Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
            Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

            Dim DVVDatos As New DVVEN
            DVVDatos.Tabla = "Producto"
            DVVDatos.ValorDVH = DVH
            DVVDatos.TipoAccion = "Baja Modificar"
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
            Integridad.GrabarDVV(DVVDatos)
        Next

        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Baja de la Nota de Venta con Nro: " & NotaVenta.NroNota)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.BajaNotaVenta)
    End Sub

    Public Shared Function CargarNotaVenta() As List(Of NotaVentaEN)
        Return NotaVentaAD.CargarNotaVenta()
    End Function

    Public Shared Function BuscarNotaVenta(NroNota As String) As List(Of NotaVentaEN)
        Return NotaVentaAD.BuscarNotaVenta(NroNota)
    End Function

	''' 
	''' <param name="NroNota"></param>
    Public Shared Sub CargarNotaVenta(DS As DataSet, NroNota As String)
        If NotaVentaAD.ValidarNotaVenta(NroNota) > 0 Then

            NotaVentaAD.CargarNotaVenta(DS, NroNota)

            For Each row As DataRow In DS.Tables("Cliente").Rows
                row("Cuit") = Seguridad.Desencriptar(CStr(row("Cuit")))
            Next

            For Each row As DataRow In DS.Tables("Producto").Rows
                row("Nombre") = Seguridad.Desencriptar(CStr(row("Nombre")))
            Next

            For Each row As DataRow In DS.Tables("Detalle_NotaVenta").Rows
                row("Precio") = Seguridad.Desencriptar(CStr(row("Precio")))
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.NotaVentaNoExiste)
        End If
    End Sub

    Public Shared Sub CargarUltimaNotaVenta(ByVal DS As DataSet)
        NotaVentaAD.CargarUltimaNotaVenta(DS)

        For Each row As DataRow In DS.Tables("Cliente").Rows
            row("Cuit") = Seguridad.Desencriptar(CStr(row("Cuit")))
        Next

        For Each row As DataRow In DS.Tables("Producto").Rows
            row("Nombre") = Seguridad.Desencriptar(CStr(row("Nombre")))
        Next

        For Each row As DataRow In DS.Tables("Detalle_NotaVenta").Rows
            row("Precio") = Seguridad.Desencriptar(CStr(row("Precio")))
        Next
    End Sub

	''' 
	''' <param name="NotaVenta"></param>
    Public Shared Sub CrearNotaVenta(ByVal NotaVenta As NotaVentaEN)
        Dim ListaDetalle As New List(Of DetalleEN)

        For Each item As DetalleEN In NotaVenta.Detalle
            Dim Linea As New DetalleEN
            Linea.CodProd = item.CodProd
            Linea.NombreProducto = item.NombreProducto
            Linea.Precio = Seguridad.Encriptar(item.Precio)
            Linea.Cantidad = item.Cantidad

            ListaDetalle.Add(Linea)
        Next

        NotaVenta.Detalle = ListaDetalle

        NotaVentaAD.CrearNotaVenta(NotaVenta)

        For Each item As DetalleEN In NotaVenta.Detalle
            Dim DVHDatos As New DVHEN
            DVHDatos.Tabla = "Producto"
            DVHDatos.CodReg = item.CodProd

            Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
            Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

            Dim DVVDatos As New DVVEN
            DVVDatos.Tabla = "Producto"
            DVVDatos.ValorDVH = DVH
            DVVDatos.TipoAccion = "Baja Modificar"
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
            Integridad.GrabarDVV(DVVDatos)
        Next

        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Alta de Nota de Venta | Cod: " & NotaVenta.CodNot)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.AltaNotaVenta)
    End Sub

End Class ' NotaVentaRN