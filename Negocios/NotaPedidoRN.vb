Imports Entidades
Imports Datos
Imports Excepciones
Imports Servicios
Public Class NotaPedidoRN


	''' 
	''' <param name="NotaPedido"></param>
    Public Shared Sub BajaNotaPedido(ByVal NotaPedido As NotaPedidoEN)
        NotaPedidoAD.BajaNotaPedido(NotaPedido)

        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Baja de la Nota de Pedido con Nro: " & NotaPedido.NroNota)
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

    Public Shared Function CargarNotaPedido() As List(Of NotaPedidoEN)
        Return NotaPedidoAD.CargarNotaPedido()
    End Function

    Public Shared Sub CargarNotaPedido(DS As DataSet, NroNota As String)
        If NotaPedidoAD.ValidarNotaPedido(NroNota) > 0 Then

            NotaPedidoAD.CargarNotaPedido(DS, NroNota)

            For Each row As DataRow In DS.Tables("Proveedor").Rows
                row("Cuit") = Seguridad.Desencriptar(CStr(row("Cuit")))
            Next

            For Each row As DataRow In DS.Tables("Producto").Rows
                row("Nombre") = Seguridad.Desencriptar(CStr(row("Nombre")))
            Next

            For Each row As DataRow In DS.Tables("Detalle_NotaPedido").Rows
                row("Precio") = Seguridad.Desencriptar(CStr(row("Precio")))
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.NotaPedidoNoExiste)
        End If
    End Sub

    Public Shared Sub CargarUltimaNotaPedido(ByVal DS As DataSet)

        NotaPedidoAD.CargarUltimaNotaPedido(DS)

        For Each row As DataRow In DS.Tables("Proveedor").Rows
            row("Cuit") = Seguridad.Desencriptar(CStr(row("Cuit")))
        Next

        For Each row As DataRow In DS.Tables("Producto").Rows
            row("Nombre") = Seguridad.Desencriptar(CStr(row("Nombre")))
        Next

        For Each row As DataRow In DS.Tables("Detalle_NotaPedido").Rows
            row("Precio") = Seguridad.Desencriptar(CStr(row("Precio")))
        Next

    End Sub

	''' 
	''' <param name="NotaPedido"></param>
    Public Shared Sub CrearNotaPedido(ByVal NotaPedido As NotaPedidoEN)
        Dim ListaDetalle As New List(Of DetalleEN)

        For Each item As DetalleEN In NotaPedido.Detalle
            Dim Linea As New DetalleEN
            Linea.CodProd = item.CodProd
            Linea.NombreProducto = item.NombreProducto
            Linea.Precio = Seguridad.Encriptar(item.Precio)
            Linea.Cantidad = item.Cantidad

            ListaDetalle.Add(Linea)
        Next

        NotaPedido.Detalle = ListaDetalle

        NotaPedidoAD.CrearNotaPedido(NotaPedido)

        Dim Bitacora As New BitacoraEN
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Bitacora.Descripcion = Seguridad.Encriptar("Alta de Nota de Pedido | Cod: " & NotaPedido.CodNot)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.AltaNotaPedido)
    End Sub

    Public Shared Function BuscarNotaPedido(NroNota As String) As List(Of NotaPedidoEN)
        Return NotaPedidoAD.BuscarNotaPedido(NroNota)
    End Function


End Class ' NotaPedidoRN