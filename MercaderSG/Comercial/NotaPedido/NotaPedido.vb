Imports Excepciones
Imports Entidades
Imports Negocios
Imports System.IO

Public Class NotaPedido
    Dim ListaDetalle As New List(Of DetalleEN)

    Private Sub BuscarProdBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarProdBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodProvTxt)

        LimpiarDatosProducto()

        Dim frm As New BuscarProducto
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            CodProdTxt.Text = frm.ProductoSel.CodProd
            NombreProdTxt.Text = frm.ProductoSel.Nombre
            DescProdTxt.Text = frm.ProductoSel.Descripcion
            PrecioTxt.Text = frm.ProductoSel.Precio
            AgregarBtn.Enabled = True
            CantidadTxt.Focus()
        Else
            AgregarBtn.Enabled = False
        End If
    End Sub

    Sub LimpiarDatosProducto()
        CodProdTxt.Clear()
        NombreProdTxt.Clear()
        DescProdTxt.Clear()
        PrecioTxt.Clear()
        CantidadTxt.Clear()
    End Sub

    Private Sub NotaPedido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()

        AgregarBtn.Enabled = False
        EliminarBtn.Enabled = False
        NuevoBtn.Enabled = False
        GenerarBtn.Enabled = False

        DetalleDG.AutoGenerateColumns = False
        TotalTxt.Text = "$0"
    End Sub

    Private Sub AgregarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodProvTxt)

        If String.IsNullOrEmpty(CantidadTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.IngresarCantidad, CantidadTxt)
            Exit Sub
        End If

        For i As Integer = 0 To DetalleDG.Rows.Count - 1
            If CodProdTxt.Text = DetalleDG.Rows(i).Cells(0).Value Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoIngresarMismoProducto, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LimpiarDatosProducto()
                Exit Sub
            End If
        Next

        Dim DetalleNV As New DetalleEN
        DetalleNV.CodProd = CInt(CodProdTxt.Text)
        DetalleNV.NombreProducto = CStr(NombreProdTxt.Text)
        DetalleNV.Precio = CStr(PrecioTxt.Text)
        DetalleNV.Cantidad = CInt(CantidadTxt.Text)

        ListaDetalle.Add(DetalleNV)

        DetalleDG.DataSource = Nothing
        DetalleDG.DataSource = ListaDetalle

        AgregarBtn.Enabled = False
        EliminarBtn.Enabled = True
        NuevoBtn.Enabled = True
        GenerarBtn.Enabled = True

        CalcularTotal()
        LimpiarDatosProducto()

        BuscarProdBtn.Focus()
    End Sub

    Sub CalcularTotal()
        Dim Total As Double = 0

        For Each item As DetalleEN In ListaDetalle
            Total += item.Cantidad * item.Precio
        Next

        TotalTxt.Text = "$" & CStr(Total)
    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodProvTxt)

        ListaDetalle.RemoveAt(DetalleDG.CurrentRow.Index)
        DetalleDG.DataSource = Nothing
        DetalleDG.DataSource = ListaDetalle

        If DetalleDG.Rows.Count = 0 Then
            EliminarBtn.Enabled = False
            NuevoBtn.Enabled = False
            GenerarBtn.Enabled = False
        End If

        CalcularTotal()
        LimpiarDatosProducto()
    End Sub

    Private Sub NuevoBtn_Click(sender As System.Object, e As System.EventArgs) Handles NuevoBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodProvTxt)

        DetalleDG.DataSource = Nothing
        ListaDetalle.Clear()

        AgregarBtn.Enabled = False
        EliminarBtn.Enabled = False
        NuevoBtn.Enabled = False
        GenerarBtn.Enabled = False

        CalcularTotal()
        LimpiarDatosProducto()
    End Sub

    Private Sub GenerarBtn_Click(sender As System.Object, e As System.EventArgs) Handles GenerarBtn.Click

        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodProvTxt)

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim NuevaNP As New NotaPedidoEN
        NuevaNP.CodProv = CInt(CodProvTxt.Text)
        NuevaNP.Detalle = ListaDetalle

        Try
            NotaPedidoRN.CrearNotaPedido(NuevaNP)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim Mensaje As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.ImprimirNotaPedido & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If Mensaje = Windows.Forms.DialogResult.OK Then
                Dim frm As New UltimaNPRepor
                frm.Show()
                Me.Close()
            Else
                Me.Close()
            End If
        End Try

    End Sub

    Private Sub BuscarCliBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarCliBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodProvTxt)

        Dim frm As New BuscarProveedor
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            CodProvTxt.Text = frm.ProvSel.CodProv
            RazonSocialTxt.Text = frm.ProvSel.RazonSocial
            CuitTxt.Text = frm.ProvSel.Cuit
            DireccionTxt.Text = frm.ProvSel.Direccion
            EstadoCB.Checked = frm.ProvSel.Activo
        End If
    End Sub

    Private Sub NotaPedido_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GenerarNPSMI.Enabled = True
    End Sub

    Private Sub NotaPedido_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "128")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.AltaNotaPedidoFrm

        ProveedorGB.Text = My.Resources.ArchivoIdioma.DatosProveedorGB
        CodProvLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
        CuitLbl.Text = My.Resources.ArchivoIdioma.CuitGral
        DireccionLbl.Text = My.Resources.ArchivoIdioma.DireccionCAB
        RazonSocialLbl.Text = My.Resources.ArchivoIdioma.RazonSocialGral
        ActivoLbl.Text = My.Resources.ArchivoIdioma.ActivoLbl
        FechaEmiLbl.Text = My.Resources.ArchivoIdioma.FechaEmiForm

        ProductoGB.Text = My.Resources.ArchivoIdioma.DatosProductoGB
        CodProdLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
        NombreProdLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
        DescProdLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl
        PrecioLbl.Text = My.Resources.ArchivoIdioma.Precio
        CantidadLbl.Text = My.Resources.ArchivoIdioma.Cantidad

        NotaVentaGB.Text = My.Resources.ArchivoIdioma.DetalleNotaVenta
        CodProdCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        NombreCAB.HeaderText = My.Resources.ArchivoIdioma.CMBNombre
        PrecioCAB.HeaderText = My.Resources.ArchivoIdioma.Precio
        CantidadCAB.HeaderText = My.Resources.ArchivoIdioma.Cantidad

        AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarGral
        EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarGral
        NuevoBtn.Text = My.Resources.ArchivoIdioma.NuevoGral
        TotalLbl.Text = My.Resources.ArchivoIdioma.TotalLbl
        GenerarBtn.Text = My.Resources.ArchivoIdioma.GenerarNotasPFrm
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(CodProvTxt, My.Resources.ArchivoIdioma.TTCodProv)
        ControlesTP.SetToolTip(BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarProvNotas)
        ControlesTP.SetToolTip(CuitTxt, My.Resources.ArchivoIdioma.TTCuit)
        ControlesTP.SetToolTip(DireccionTxt, My.Resources.ArchivoIdioma.TTDireccionProv)
        ControlesTP.SetToolTip(RazonSocialTxt, My.Resources.ArchivoIdioma.TTRazonSocial)
        ControlesTP.SetToolTip(FechaDTP, My.Resources.ArchivoIdioma.TTFechaEmisionNP)

        ControlesTP.SetToolTip(CodProdTxt, My.Resources.ArchivoIdioma.TTCodProd)
        ControlesTP.SetToolTip(BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarProdNota)
        ControlesTP.SetToolTip(NombreProdTxt, My.Resources.ArchivoIdioma.TTNombreProd)
        ControlesTP.SetToolTip(DescProdTxt, My.Resources.ArchivoIdioma.TTDescrProd)
        ControlesTP.SetToolTip(PrecioTxt, My.Resources.ArchivoIdioma.TTPrecioProd)
        ControlesTP.SetToolTip(CantidadTxt, My.Resources.ArchivoIdioma.TTIngreseCantidad)

        ControlesTP.SetToolTip(DetalleDG, My.Resources.ArchivoIdioma.TTListaProductoNP)

        ControlesTP.SetToolTip(AgregarBtn, My.Resources.ArchivoIdioma.TTAgregarDetalle)
        ControlesTP.SetToolTip(EliminarBtn, My.Resources.ArchivoIdioma.TTEliminarDetalle)
        ControlesTP.SetToolTip(NuevoBtn, My.Resources.ArchivoIdioma.TTNuevoDetalle)
        ControlesTP.SetToolTip(GenerarBtn, My.Resources.ArchivoIdioma.TTGenerarNotaPedido)
    End Sub

#End Region

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(CodProvTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.AgregarProvNV, CodProvTxt)
            Resultado = False
            Return Resultado
        End If

        Return Resultado
    End Function

End Class