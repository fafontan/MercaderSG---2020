Imports Excepciones
Imports Entidades
Imports Negocios
Imports System.IO

Public Class NotaVenta
    Dim ListaDetalle As New List(Of DetalleEN)

    Private Sub NotaVenta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()

        AgregarBtn.Enabled = False
        EliminarBtn.Enabled = False
        NuevoBtn.Enabled = False
        GenerarBtn.Enabled = False

        DetalleDG.AutoGenerateColumns = False
        TotalTxt.Text = "$0"
    End Sub

    Private Sub BuscarCliBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarCliBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodCliTxt)

        Dim frm As New BuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            CodCliTxt.Text = frm.ClienteSel.CodCli
            RazonSocialTxt.Text = frm.ClienteSel.RazonSocial
            CuitTxt.Text = frm.ClienteSel.Cuit
            DireccionTxt.Text = frm.ClienteSel.Direccion
            EstadoCB.Checked = frm.ClienteSel.Activo
        End If
    End Sub

    Private Sub BuscarProdBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarProdBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodCliTxt)

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

    Private Sub AgregarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodCliTxt)

        If String.IsNullOrEmpty(CantidadTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.IngresarCantidad, CantidadTxt)
            Exit Sub
        End If

        Dim Cantidad As Integer = CType(CantidadTxt.Text, Integer)
        Dim CodProd As Integer = CType(CodProdTxt.Text, Integer)

        If Cantidad <= ProductoRN.StockIDProd(CodProd) Then

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
        Else
            MessageBox.Show(My.Resources.ArchivoIdioma.NoStock, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CantidadTxt.Clear()
        End If
    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarBtn.Click
        MensajeTT.Hide(CantidadTxt)
        MensajeTT.Hide(CodCliTxt)

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
        MensajeTT.Hide(CodCliTxt)

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
        MensajeTT.Hide(CodCliTxt)

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim NuevaNV As New NotaVentaEN
        NuevaNV.CodCli = CInt(CodCliTxt.Text)
        NuevaNV.Detalle = ListaDetalle

        Try
            NotaVentaRN.CrearNotaVenta(NuevaNV)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)

            For Each item As DetalleEN In ListaDetalle
                ProductoRN.ActualizarStock(item.CodProd, item.Cantidad)
            Next

            Dim Mensaje As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.ImprimirNotaVenta & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If Mensaje = Windows.Forms.DialogResult.OK Then
                Dim frm As New Reporte
                frm.Show()
                Me.Close()
            Else
                Me.Close()
            End If
        End Try
    End Sub

    Sub LimpiarDatosProducto()
        CodProdTxt.Clear()
        NombreProdTxt.Clear()
        DescProdTxt.Clear()
        PrecioTxt.Clear()
        CantidadTxt.Clear()
    End Sub

    Sub CalcularTotal()
        Dim Total As Double = 0

        For Each item As DetalleEN In ListaDetalle
            Total += item.Cantidad * item.Precio
        Next

        TotalTxt.Text = "$" & CStr(Total)
    End Sub

    Private Sub CantidadTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadTxt.KeyPress
        Dim CaracteresPermitidos As String = "1234567890" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar

        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NotaVenta_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GenerarNVSMI.Enabled = True
    End Sub

    Private Sub NotaVenta_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "129")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.AltaNotaVentaFrm

        ClienteGB.Text = My.Resources.ArchivoIdioma.DatosClienteGB
        CodCliLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
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
        ControlesTP.SetToolTip(CodCliTxt, My.Resources.ArchivoIdioma.TTCodCli)
        ControlesTP.SetToolTip(BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarCliNotas)
        ControlesTP.SetToolTip(CuitTxt, My.Resources.ArchivoIdioma.TTCuit)
        ControlesTP.SetToolTip(DireccionTxt, My.Resources.ArchivoIdioma.TTDireccionCli)
        ControlesTP.SetToolTip(RazonSocialTxt, My.Resources.ArchivoIdioma.TTRazonSocial)
        ControlesTP.SetToolTip(FechaDTP, My.Resources.ArchivoIdioma.TTFechaEmisionNota)

        ControlesTP.SetToolTip(CodProdTxt, My.Resources.ArchivoIdioma.TTCodProd)
        ControlesTP.SetToolTip(BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarProdNota)
        ControlesTP.SetToolTip(NombreProdTxt, My.Resources.ArchivoIdioma.TTNombreProd)
        ControlesTP.SetToolTip(DescProdTxt, My.Resources.ArchivoIdioma.TTDescrProd)
        ControlesTP.SetToolTip(PrecioTxt, My.Resources.ArchivoIdioma.TTPrecioProd)
        ControlesTP.SetToolTip(CantidadTxt, My.Resources.ArchivoIdioma.TTIngreseCantidad)

        ControlesTP.SetToolTip(DetalleDG, My.Resources.ArchivoIdioma.TTListaProductoNV)

        ControlesTP.SetToolTip(AgregarBtn, My.Resources.ArchivoIdioma.TTAgregarDetalle)
        ControlesTP.SetToolTip(EliminarBtn, My.Resources.ArchivoIdioma.TTEliminarDetalle)
        ControlesTP.SetToolTip(NuevoBtn, My.Resources.ArchivoIdioma.TTNuevoDetalle)
        ControlesTP.SetToolTip(GenerarBtn, My.Resources.ArchivoIdioma.TTGenerarNotaVenta)
    End Sub

#End Region

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(CodCliTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.AgregarCliNV, CodCliTxt)
            Resultado = False
            Return Resultado
        End If

        Return Resultado
    End Function

    Private Sub CantidadTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CantidadTxt.TextChanged
        MensajeTT.Hide(CantidadTxt)
    End Sub

End Class