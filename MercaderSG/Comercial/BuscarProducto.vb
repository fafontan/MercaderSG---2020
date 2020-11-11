Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.IO

Public Class BuscarProducto

    Dim ListaProductos As New List(Of ProductoEN)
    Dim ListaProductosTemp As New List(Of ProductoEN)
    Dim ListaProductosTempGral As New List(Of ProductoEN)

    Dim NroPag As Integer = 0

    Private _productosel As ProductoEN
    Public Property ProductoSel() As ProductoEN
        Get
            Return _productosel
        End Get
        Set(ByVal value As ProductoEN)
            _productosel = value
        End Set
    End Property


    Private Sub BuscarProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()

        CargarTT()
        AplicarIdioma()
        CargarFoco(ProductoGB)

        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBNombre)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBSector)

        BuscarCmb.SelectedIndex = 0

        ListaProductosTempGral.AddRange(ListaProductos)
    End Sub

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        ListaProductos = ProductoRN.CargarProducto()
        For i As Integer = 0 To ListaProductos.Count - 1
            If BGW.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                BGW.ReportProgress(100 * i / ListaProductos.Count)
            End If
        Next
    End Sub

    Private Sub BGW_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW.ProgressChanged
        BarraProgreso.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        ProductosDG.AutoGenerateColumns = False
        ProductosDG.DataSource = PaginaSig(NroPag)

        BarraProgreso.ProgressBar1.Value = 0
        BarraProgreso.Close()
    End Sub

    Function PaginaSig(NroPagActual As Integer) As List(Of ProductoEN)
        NroPag += 1

        Dim ListaAux As New List(Of ProductoEN)
        For Each item As ProductoEN In ListaProductos.Paginacion(NroPag)
            Dim UnProducto As New ProductoEN

            UnProducto.CodProd = item.CodProd
            UnProducto.Nombre = item.Nombre
            UnProducto.Sector = item.Sector
            UnProducto.Cantidad = item.Cantidad
            UnProducto.Precio = item.Precio
            UnProducto.Descripcion = item.Descripcion

            ListaAux.Add(UnProducto)
        Next

        Return ListaAux
    End Function

    Private Sub ProductosDG_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosDG.CellDoubleClick
        _productosel = DirectCast(ProductosDG.CurrentRow.DataBoundItem, ProductoEN)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        NroPag = 0

        ListaProductosTemp.Clear()
        ListaProductosTemp.AddRange(ListaProductos)

        ListaProductos.Clear()

        Try
            ListaProductos = ProductoRN.BuscarProducto(BuscarCmb.SelectedItem, BusquedaTxt.Text)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaProductos.Clear()
            ListaProductos.AddRange(ListaProductosTempGral)

            NroPag = 0

            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)
        End Try

        ProductosDG.DataSource = Nothing
        ProductosDG.AutoGenerateColumns = False
        ProductosDG.DataSource = PaginaSig(NroPag)

        If ProductosDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteProdBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaProductos.Clear()
            ListaProductos.AddRange(ListaProductosTempGral)

            NroPag = 0

            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)
        End If
    End Sub

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        ListaProductos.Clear()
        ListaProductos.AddRange(ListaProductosTempGral)

        NroPag = 0
        ProductosDG.DataSource = Nothing
        ProductosDG.DataSource = PaginaSig(NroPag)
    End Sub

    Private Sub BuscarProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            _productosel = DirectCast(ProductosDG.CurrentRow.DataBoundItem, ProductoEN)
            DialogResult = Windows.Forms.DialogResult.OK
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(BusquedaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.BusquedaVacia, BusquedaTxt)
            BusquedaTxt.Clear()
            BusquedaTxt.Focus()
            Resultado = False
        End If

        Select Case BuscarCmb.SelectedItem
            Case My.Resources.ArchivoIdioma.CMBNombre

                If BusquedaTxt.Text.Length > 20 Then

                    MensajeTT.Show(My.Resources.ArchivoIdioma.Contener20Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False

                End If

            Case My.Resources.ArchivoIdioma.CMBSector

                If BusquedaTxt.Text.Length > 50 Then

                    MensajeTT.Show(My.Resources.ArchivoIdioma.Contener50Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False

                End If

        End Select

        Return Resultado
    End Function

#End Region

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.BuscarProductoFrm

        ProductoGB.Text = My.Resources.ArchivoIdioma.SeleccionarProd
        BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
        IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        CodProdCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        NombreCAB.HeaderText = My.Resources.ArchivoIdioma.CMBNombre
        PrecioUnitarioCAB.HeaderText = My.Resources.ArchivoIdioma.Precio
        CantidadCAB.HeaderText = My.Resources.ArchivoIdioma.Cantidad
        SectorCAB.HeaderText = My.Resources.ArchivoIdioma.CMBSector
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BusquedaTxt, My.Resources.ArchivoIdioma.IngresarProdBuscar)
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarProd)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(ProductosDG, My.Resources.ArchivoIdioma.TTListaProducto)
    End Sub

#End Region

#Region "Mejoras"
    Private Sub TieneFoco(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MiTextBox As TextBox = DirectCast(sender, TextBox)
        MiTextBox.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub PierdeFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim MiTextBox As TextBox = DirectCast(sender, TextBox)
        MiTextBox.BackColor = Color.White
    End Sub

    Public Sub CargarFoco(Grupo As Windows.Forms.GroupBox)
        Dim Ctrl As Control
        For Each Ctrl In Grupo.Controls
            If (TypeOf (Ctrl) Is System.Windows.Forms.TextBox) Then
                Dim MiTextBox As TextBox = DirectCast(Ctrl, TextBox)
                If MiTextBox.ReadOnly = False Then
                    AddHandler MiTextBox.GotFocus, AddressOf TieneFoco
                    AddHandler MiTextBox.LostFocus, AddressOf PierdeFoco
                End If
            End If
        Next
    End Sub
#End Region

End Class