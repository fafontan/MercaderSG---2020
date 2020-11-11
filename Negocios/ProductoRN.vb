Imports Entidades
Imports Servicios
Imports Datos
Imports Excepciones
Public Class ProductoRN

    Public Shared Sub ActualizarStock(ByVal CodProd As Integer, ByVal Cantidad As Integer)
        ProductoAD.ActualizarStock(CodProd, Cantidad)

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Producto"
        DVHDatos.CodReg = CodProd

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatos As New DVVEN
        DVVDatos.Tabla = "Producto"
        DVVDatos.ValorDVH = DVH
        DVVDatos.TipoAccion = "Baja Modificar"
        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
        Integridad.GrabarDVV(DVVDatos)
    End Sub

	''' 
	''' <param name="Producto"></param>
    Public Shared Sub AltaProducto(ByVal Producto As ProductoEN)

        Dim ProductoDesencriptado As String = Producto.Nombre
        Dim PrecioDesencriptado As String = Producto.Precio

        Producto.Nombre = Seguridad.Encriptar(Producto.Nombre)
        Producto.Precio = Seguridad.Encriptar(Producto.Precio)

        If ProductoAD.ValidarProducto(Producto.Nombre) > 0 Then
            Throw New WarningException(My.Resources.ArchivoIdioma.ProductoExistente)
            Exit Sub
        Else
            ProductoAD.AltaProducto(Producto)
            Dim UsuAut As Autenticar = Autenticar.Instancia()

            'Producto
            Dim DVHDatos As New DVHEN
            DVHDatos.Tabla = "Producto"
            DVHDatos.CodReg = Producto.CodProd

            Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
            Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

            Dim DVVDatos As New DVVEN
            DVVDatos.Tabla = "Producto"
            DVVDatos.ValorDVH = DVH
            DVVDatos.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatos)

            Dim Bitacora As New BitacoraEN
            Bitacora.Descripcion = Seguridad.Encriptar("Alta de Producto: " & ProductoDesencriptado)
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

            'Historico_Precio
            Dim DVHDatosHP As New DVHEN
            DVHDatosHP.Tabla = "Historico_Precio"
            DVHDatosHP.CodReg = Producto.CodHistorico

            Dim DVHHP As Integer = Integridad.CalcularDVH(DVHDatosHP)
            Dim ValorDVHAntiguoHP As Integer = Integridad.GrabarDVH(DVHDatosHP, DVHHP)

            Dim DVVDatosHP As New DVVEN
            DVVDatosHP.Tabla = "Historico_Precio"
            DVVDatosHP.ValorDVH = DVHHP
            DVVDatosHP.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatosHP)

            Dim BitacoraHP As New BitacoraEN

            BitacoraHP.Descripcion = Seguridad.Encriptar("Alta de Precio: " & PrecioDesencriptado & " del Cod.Prod: " & Producto.CodProd)
            BitacoraHP.Criticidad = 3
            BitacoraHP.Usuario = UsuAut.UsuarioLogueado

            BitacoraAD.GrabarBitacora(BitacoraHP)

            Dim DVHDatosBitacoraHP As New DVHEN
            DVHDatosBitacoraHP.Tabla = "Bitacora"
            DVHDatosBitacoraHP.CodReg = BitacoraHP.CodBit

            Dim DVHBitacoraHP As Integer = Integridad.CalcularDVH(DVHDatosBitacoraHP)
            Dim ValorDVHAntiguoHPBit As Integer = Integridad.GrabarDVH(DVHDatosBitacoraHP, DVHBitacoraHP)

            Dim DVVDatosBitacoraHP As New DVVEN
            DVVDatosBitacoraHP.Tabla = "Bitacora"
            DVVDatosBitacoraHP.ValorDVH = DVHBitacoraHP
            DVVDatosBitacoraHP.TipoAccion = "Alta"
            Integridad.GrabarDVV(DVVDatosBitacoraHP)

            Throw New InformationException(My.Resources.ArchivoIdioma.AltaProducto)
        End If

    End Sub

	''' 
	''' <param name="Producto"></param>
    Public Shared Sub BajaProducto(ByVal Producto As ProductoEN)
        ProductoAD.BajaProducto(Producto)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Producto"
        DVHDatos.CodReg = Producto.CodProd

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatos As New DVVEN
        DVVDatos.Tabla = "Producto"
        DVVDatos.TipoAccion = "Baja Modificar"
        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
        DVVDatos.ValorDVH = DVH
        Integridad.GrabarDVV(DVVDatos)

        Dim Bitacora As New BitacoraEN
        Bitacora.Descripcion = Seguridad.Encriptar("Baja de Producto: " & Producto.Nombre)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.BajaProducto)
    End Sub

	''' 
	''' <param name="campo"></param>
	''' <param name="valor"></param>
    Public Shared Function BuscarProducto(ByVal Campo As String, ByVal Valor As String) As List(Of ProductoEN)
        Dim ListaProductos As New List(Of ProductoEN)
        Dim ListaProductosProc As New List(Of ProductoEN)

        If Campo = My.Resources.ArchivoIdioma.CMBNombre Then
            Valor = Seguridad.Encriptar(Valor)
        End If

        ListaProductos = ProductoAD.BuscarProducto(Campo, Valor)

        For Each item As ProductoEN In ListaProductos
            Dim UnProducto As New ProductoEN

            UnProducto.CodProd = item.CodProd
            UnProducto.Nombre = Seguridad.Desencriptar(item.Nombre)
            UnProducto.Sector = item.Sector
            UnProducto.Cantidad = item.Cantidad
            UnProducto.Precio = Seguridad.Desencriptar(CStr(item.Precio))
            UnProducto.Descripcion = item.Descripcion

            ListaProductosProc.Add(UnProducto)
        Next

        Return ListaProductosProc
    End Function

    Public Shared Function CargarProducto() As List(Of ProductoEN)
        Dim ListaProducto As New List(Of ProductoEN)
        Dim ListaProductoProc As New List(Of ProductoEN)

        ListaProducto = ProductoAD.CargarProducto()

        For Each item As ProductoEN In ListaProducto
            Dim UnProducto As New ProductoEN

            UnProducto.CodProd = item.CodProd
            UnProducto.Nombre = Seguridad.Desencriptar(item.Nombre)
            UnProducto.Sector = item.Sector
            UnProducto.Cantidad = item.Cantidad
            UnProducto.Precio = Seguridad.Desencriptar(CStr(item.Precio))
            UnProducto.Descripcion = item.Descripcion

            ListaProductoProc.Add(UnProducto)
        Next

        Return ListaProductoProc
    End Function


    Public Shared Sub ModificarPrecioProducto(ByVal Producto As ProductoEN)
        Dim PrecioDesencriptado As String = Producto.Precio
        Producto.Precio = Seguridad.Encriptar(Producto.Precio)

        ProductoAD.ModificarPrecioProducto(Producto)

        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim DVHDatosHP As New DVHEN
        DVHDatosHP.Tabla = "Historico_Precio"
        DVHDatosHP.CodReg = Producto.CodHistorico

        Dim DVHHP As Integer = Integridad.CalcularDVH(DVHDatosHP)
        Dim ValorDVHAntiguoHP As Integer = Integridad.GrabarDVH(DVHDatosHP, DVHHP)

        Dim DVVDatosHP As New DVVEN
        DVVDatosHP.Tabla = "Historico_Precio"
        DVVDatosHP.TipoAccion = "Baja Modificar"
        DVVDatosHP.ValorDVHAntiguo = ValorDVHAntiguoHP
        DVVDatosHP.ValorDVH = DVHHP
        Integridad.GrabarDVV(DVVDatosHP)

        Dim BitacoraHP As New BitacoraEN

        BitacoraHP.Descripcion = Seguridad.Encriptar("Alta de Precio: " & PrecioDesencriptado & " del Cod.Prod: " & Producto.CodProd)
        BitacoraHP.Criticidad = 2
        BitacoraHP.Usuario = UsuAut.UsuarioLogueado

        BitacoraAD.GrabarBitacora(BitacoraHP)

        Dim DVHDatosBitacoraHP As New DVHEN
        DVHDatosBitacoraHP.Tabla = "Bitacora"
        DVHDatosBitacoraHP.CodReg = BitacoraHP.CodBit

        Dim DVHBitacoraHP As Integer = Integridad.CalcularDVH(DVHDatosBitacoraHP)
        Dim ValorDVHAntiguoHPBit As Integer = Integridad.GrabarDVH(DVHDatosBitacoraHP, DVHBitacoraHP)

        Dim DVVDatosBitacora As New DVVEN
        DVVDatosBitacora.Tabla = "Bitacora"
        DVVDatosBitacora.ValorDVH = DVHBitacoraHP
        DVVDatosBitacora.TipoAccion = "Alta"
        Integridad.GrabarDVV(DVVDatosBitacora)

        Throw New InformationException(My.Resources.ArchivoIdioma.AltaPrecio)
    End Sub

	''' 
	''' <param name="Producto"></param>
    Public Shared Sub ModificarProducto(ByVal Producto As ProductoEN)
        Producto.Nombre = Seguridad.Encriptar(Producto.Nombre)

        ProductoAD.ModificarProducto(Producto)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Producto"
        DVHDatos.CodReg = Producto.CodProd

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatos As New DVVEN
        DVVDatos.Tabla = "Producto"
        DVVDatos.ValorDVH = DVH
        DVVDatos.TipoAccion = "Baja Modificar"
        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
        Integridad.GrabarDVV(DVVDatos)

        Dim Bitacora As New BitacoraEN

        Bitacora.Descripcion = Seguridad.Encriptar("Se modificó el Producto: " & Producto.Nombre)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.ModificarProducto)
    End Sub


    Public Shared Sub ModificarStockProducto(ByVal Producto As ProductoEN)

        ProductoAD.ModificarStockProducto(Producto)

        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim DVHDatos As New DVHEN
        DVHDatos.Tabla = "Producto"
        DVHDatos.CodReg = Producto.CodProd

        Dim DVH As Integer = Integridad.CalcularDVH(DVHDatos)
        Dim ValorDVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatos, DVH)

        Dim DVVDatos As New DVVEN
        DVVDatos.Tabla = "Producto"
        DVVDatos.ValorDVH = DVH
        DVVDatos.TipoAccion = "Baja Modificar"
        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo
        Integridad.GrabarDVV(DVVDatos)

        Dim Bitacora As New BitacoraEN

        Bitacora.Descripcion = Seguridad.Encriptar("Se agrego " & Producto.Cantidad & " unidades al stock del producto: " & Producto.CodProd & "||" & Producto.Nombre)
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

        Throw New InformationException(My.Resources.ArchivoIdioma.AltaStock)
    End Sub

    ''' 
    ''' <param name="Nombre"></param>
    Public Shared Function ObtenerProducto(ByVal Nombre As String) As ProductoEN
        Dim CodProd As Integer = ProductoAD.ObtenerIDProducto(Nombre)

        Dim UnProducto As New ProductoEN

        UnProducto = ProductoAD.ObtenerProducto(CodProd)

        UnProducto.Nombre = Seguridad.Desencriptar(UnProducto.Nombre)
        UnProducto.Precio = Seguridad.Desencriptar(UnProducto.Precio)

        Return UnProducto

    End Function

    ''' 
    ''' <param name="Codprod"></param>
    Public Shared Function StockIDProd(ByVal CodProd As Integer) As Integer
        Return ProductoAD.StockIDProd(CodProd)
    End Function


End Class ' ProductoRN