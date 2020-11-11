Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop

Public Class GestionProducto

    Private ListaProductos As New List(Of ProductoEN)
    Private ListaProductosTemp As New List(Of ProductoEN)
    Private ListaProductosTempGral As New List(Of ProductoEN)

    Public NroPag As Integer = 0
    Private CantidadPaginas As Integer = 0

    Private UsuAut As Autenticar = Autenticar.Instancia()

    Public PaginaNro As String = My.Resources.ArchivoIdioma.InfoPaginaPag
    Public PaginaDe As String = My.Resources.ArchivoIdioma.InfoPaginaDe
    Public PaginaRegistros As String = My.Resources.ArchivoIdioma.InfoPaginaReg

#Region "Permisos"

    Private AltaProducto As Boolean = False
    Private ModificarProducto As Boolean = False
    Private BajaProducto As Boolean = False
    Private StockProducto As Boolean = False
    Private PrecioProducto As Boolean = False

    Private Sub CargarPermisos()

        AltaProducto = PermisoOK(5)
        Me.AgregarBtn.Enabled = AltaProducto

        ModificarProducto = PermisoOK(6)
        Me.ModificarBtn.Enabled = ModificarProducto

        BajaProducto = PermisoOK(7)
        Me.EliminarBtn.Enabled = BajaProducto

        StockProducto = PermisoOK(8)
        Me.ModificarStockBtn.Enabled = StockProducto

        PrecioProducto = PermisoOK(9)
        Me.ModificarPrecioBtn.Enabled = PrecioProducto

    End Sub

    Private Function PermisoOK(CodPat As Integer) As Boolean
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = CodPat Then
                Return True
            End If
        Next
        Return False
    End Function

#End Region

    Private Sub GestionProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()

        CargarFoco(GestionProductosGB)
        AplicarIdioma()
        CargarTT()
        CargarPermisos()

        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBNombre)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBSector)

        BuscarCmb.SelectedIndex = 0

        If CantidadPaginas = 1 Or ProductosDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        End If

        ListaProductosTempGral.AddRange(ListaProductos)
    End Sub

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        Try
            ListaProductos = ProductoRN.CargarProducto()
        Catch ex As CriticalException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

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
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))

        Parte1Lbl.Text = String.Empty
        Parte2Lbl.Text = String.Empty
        InfoPagLbl.Spring = True

        ProductosDG.AutoGenerateColumns = False
        ProductosDG.DataSource = PaginaSig(NroPag)

        If ProductosDG.Rows.Count = 0 Then
            InfoPagina(0)
        Else
            InfoPagina(1)
        End If

        BarraProgreso.ProgressBar1.Value = 0
        BarraProgreso.Close()
    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click
        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        NroPag = 0

        ListaProductosTemp.Clear()
        ListaProductosTemp.AddRange(ListaProductos)

        ListaProductos.Clear()

        ListaProductos = ProductoRN.BuscarProducto(BuscarCmb.SelectedItem, BusquedaTxt.Text)
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))

        ProductosDG.DataSource = Nothing
        ProductosDG.AutoGenerateColumns = False
        ProductosDG.DataSource = PaginaSig(NroPag)

        If ProductosDG.Rows.Count > 0 Then
            InfoPagina(1)
        Else
            InfoPagina(0)
        End If

        If ProductosDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteProdBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaProductos.Clear()
            ListaProductos.AddRange(ListaProductosTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)

            If ProductosDG.Rows.Count > 0 Then
                InfoPagina(1)
            Else
                InfoPagina(0)
            End If
        End If
    End Sub

    Private Sub AgregarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarBtn.Click
        Dim frm As New AltaProducto
        frm.PuedeModificar = ModificarProducto

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaProductos.Clear()
            ListaProductos = ProductoRN.CargarProducto()

            ListaProductosTempGral.Clear()
            ListaProductosTempGral.AddRange(ListaProductos)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
            InfoPagina(1)
            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

    Private Sub ModificarBtn_Click(sender As System.Object, e As System.EventArgs) Handles ModificarBtn.Click
        If ProductosDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoProductos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ProductosDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarProducto, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim frm As New ModificarProducto
        frm.ProductoSel = ProductosDG.CurrentRow.Cells(1).Value

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaProductos.Clear()
            ListaProductos = ProductoRN.CargarProducto()

            ListaProductosTempGral.Clear()
            ListaProductosTempGral.AddRange(ListaProductos)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
            InfoPagina(1)
            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarBtn.Click

        If ProductosDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoProductos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ProductosDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarProducto, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Producto As New ProductoEN

        Producto.CodProd = ProductosDG.CurrentRow.Cells(0).Value
        Producto.Nombre = ProductosDG.CurrentRow.Cells(1).Value

        Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.EliminarProducto & Producto.Nombre & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxEliminarProducto, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If Resultado = Windows.Forms.DialogResult.OK Then
            Try
                ProductoRN.BajaProducto(Producto)
            Catch ex As InformationException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)

                ListaProductos.Clear()
                ListaProductos = ProductoRN.CargarProducto()

                ListaProductosTempGral.Clear()
                ListaProductosTempGral.AddRange(ListaProductos)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
                ProductosDG.DataSource = Nothing
                ProductosDG.DataSource = PaginaSig(NroPag)

                If ProductosDG.Rows.Count > 0 Then
                    InfoPagina(1)
                Else
                    InfoPagina(0)
                End If

                If CantidadPaginas = 1 Or ProductosDG.Rows.Count = 0 Then
                    DeshabilitarPaginacion()
                Else
                    HabilitarPaginacion()
                End If

            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                ListaProductos.Clear()
                ListaProductos = ProductoRN.CargarProducto()

                ListaProductosTempGral.Clear()
                ListaProductosTempGral.AddRange(ListaProductos)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
                ProductosDG.DataSource = Nothing
                ProductosDG.DataSource = PaginaSig(NroPag)

                If ProductosDG.Rows.Count > 0 Then
                    InfoPagina(1)
                Else
                    InfoPagina(0)
                End If

                If CantidadPaginas = 1 Or ProductosDG.Rows.Count = 0 Then
                    DeshabilitarPaginacion()
                Else
                    HabilitarPaginacion()
                End If
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ModificarStockToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ModificarStockBtn.Click
        If ProductosDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoProductos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ProductosDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarProducto, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim frm As New ModificarStock
        frm.ProductoSel = ProductosDG.CurrentRow.Cells(1).Value

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaProductos.Clear()
            ListaProductos = ProductoRN.CargarProducto()

            ListaProductosTempGral.Clear()
            ListaProductosTempGral.AddRange(ListaProductos)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
            InfoPagina(1)
            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

    Private Sub ModificarPrecioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPrecioBtn.Click
        If ProductosDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoProductos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ProductosDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarProducto, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim frm As New ModificarPrecio
        frm.ProductoSel = ProductosDG.CurrentRow.Cells(1).Value

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaProductos.Clear()
            ListaProductos = ProductoRN.CargarProducto()

            ListaProductosTempGral.Clear()
            ListaProductosTempGral.AddRange(ListaProductos)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
            InfoPagina(1)
            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

#Region "Paginacion"

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

            ListaAux.Add(UnProducto)
        Next

        Return ListaAux
    End Function

    Function PaginaAnt(NroPagActual As Integer) As List(Of ProductoEN)
        NroPag -= 1

        Dim ListaAux As New List(Of ProductoEN)
        For Each item As ProductoEN In ListaProductos.Paginacion(NroPag)
            Dim UnProducto As New ProductoEN

            UnProducto.CodProd = item.CodProd
            UnProducto.Nombre = item.Nombre
            UnProducto.Sector = item.Sector
            UnProducto.Cantidad = item.Cantidad
            UnProducto.Precio = item.Precio

            ListaAux.Add(UnProducto)
        Next

        Return ListaAux
    End Function

    Private Sub SiguienteBtn_Click(sender As System.Object, e As System.EventArgs) Handles SiguienteBtn.Click
        If NroPag > CantidadPaginas - 1 Then
            SiguienteBtn.Enabled = False
            UltimoBtn.Enabled = False
        Else
            PrimeroBtn.Enabled = True
            AnteriorBtn.Enabled = True

            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaSig(NroPag)

            InfoPagina(NroPag)
        End If
    End Sub

    Private Sub AnteriorBtn_Click(sender As System.Object, e As System.EventArgs) Handles AnteriorBtn.Click
        If NroPag = 1 Then
            PrimeroBtn.Enabled = False
            AnteriorBtn.Enabled = False
        Else
            SiguienteBtn.Enabled = True
            UltimoBtn.Enabled = True

            ProductosDG.DataSource = Nothing
            ProductosDG.DataSource = PaginaAnt(NroPag)

            InfoPagina(NroPag)
        End If
    End Sub

    Private Sub PrimeroBtn_Click(sender As System.Object, e As System.EventArgs) Handles PrimeroBtn.Click
        NroPag = 0

        PrimeroBtn.Enabled = False
        AnteriorBtn.Enabled = False

        SiguienteBtn.Enabled = True
        UltimoBtn.Enabled = True

        ProductosDG.DataSource = Nothing
        ProductosDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub UltimoBtn_Click(sender As System.Object, e As System.EventArgs) Handles UltimoBtn.Click
        NroPag = CantidadPaginas - 1

        SiguienteBtn.Enabled = False
        UltimoBtn.Enabled = False

        PrimeroBtn.Enabled = True
        AnteriorBtn.Enabled = True

        ProductosDG.DataSource = Nothing
        ProductosDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        If ProductosDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
            Exit Sub
        End If

        If CantidadPaginas = 1 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        ListaProductos.Clear()
        ListaProductos.AddRange(ListaProductosTempGral)

        NroPag = 0
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProductos.Count / 25))
        InfoPagina(1)
        ProductosDG.DataSource = Nothing
        ProductosDG.DataSource = PaginaSig(NroPag)
    End Sub

    Sub InfoPagina(NroPag As Integer)
        InfoPagLbl.Text = PaginaNro & " " & NroPag & " " & PaginaDe & " " & CantidadPaginas & " " & PaginaRegistros & " " & ListaProductos.Count
        InfoPagLbl.TextAlign = ContentAlignment.MiddleCenter
    End Sub

#End Region

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

    Private Sub BuscarCmb_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles BuscarCmb.SelectedIndexChanged
        BusquedaTxt.Clear()
    End Sub

    Private Sub BusquedaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles BusquedaTxt.TextChanged
        MensajeTT.Hide(BusquedaTxt)
    End Sub

    Private Sub MasBtn_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MasBtn.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            OpcionesCMS.Show(MousePosition)
        End If
    End Sub

    Private Sub GestionProducto_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GestionProductoSMI.Enabled = True
    End Sub

    Private Sub GestionProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "118")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.N And AltaProducto = True Then
            AgregarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.U And ModificarProducto = True Then
            ModificarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.D And BajaProducto = True Then
            EliminarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.S And StockProducto = True Then
            ModificarStockBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.P And PrecioProducto = True Then
            ModificarPrecioBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.E Then
            ExportarAXLSToolStripMenuItem.PerformClick()
        End If
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

    Sub HabilitarPaginacion()
        PrimeroBtn.Enabled = True
        SiguienteBtn.Enabled = True
        UltimoBtn.Enabled = True
        AnteriorBtn.Enabled = True
    End Sub

    Sub DeshabilitarPaginacion()
        PrimeroBtn.Enabled = False
        SiguienteBtn.Enabled = False
        UltimoBtn.Enabled = False
        AnteriorBtn.Enabled = False
    End Sub

#End Region

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.GestionProductosFrm

        GestionProductosGB.Text = My.Resources.ArchivoIdioma.GestionProductosGB
        BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
        IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
        AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarProdBtn
        ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarProdBtn
        EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarProdBtn
        MasBtn.Text = My.Resources.ArchivoIdioma.MasOpcionesBtn
        ModificarStockBtn.Text = My.Resources.ArchivoIdioma.ModificarStockBtn
        ModificarPrecioBtn.Text = My.Resources.ArchivoIdioma.ModificarPrecioBtn

        RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
        CodProdCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        NombreCAB.HeaderText = My.Resources.ArchivoIdioma.CMBNombre
        PrecioUnitarioCAB.HeaderText = My.Resources.ArchivoIdioma.Precio
        CantidadCAB.HeaderText = My.Resources.ArchivoIdioma.Cantidad
        SectorCAB.HeaderText = My.Resources.ArchivoIdioma.CMBSector
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
        ControlesTP.SetToolTip(AgregarBtn, My.Resources.ArchivoIdioma.TTProductoAltaBtn)
        ControlesTP.SetToolTip(ModificarBtn, My.Resources.ArchivoIdioma.TTProductoModificarBtn)
        ControlesTP.SetToolTip(EliminarBtn, My.Resources.ArchivoIdioma.TTProductoEliminarBtn)
        ControlesTP.SetToolTip(MasBtn, My.Resources.ArchivoIdioma.TTMasOpciones)
        ControlesTP.SetToolTip(SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
        ControlesTP.SetToolTip(AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
        ControlesTP.SetToolTip(UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
        ControlesTP.SetToolTip(PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(ProductosDG, My.Resources.ArchivoIdioma.TTListaProducto)
    End Sub

#End Region

End Class