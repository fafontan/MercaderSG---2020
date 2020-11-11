Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Text.RegularExpressions

Public Class GestionProveedor
    Private ListaProveedor As New List(Of ProveedorEN)
    Private ListaProveedorTemp As New List(Of ProveedorEN)
    Private ListaProveedorTempGral As New List(Of ProveedorEN)

    Public NroPag As Integer = 0
    Private CantidadPaginas As Integer = 0

    Private UsuAut As Autenticar = Autenticar.Instancia()

    Public PaginaNro As String = My.Resources.ArchivoIdioma.InfoPaginaPag
    Public PaginaDe As String = My.Resources.ArchivoIdioma.InfoPaginaDe
    Public PaginaRegistros As String = My.Resources.ArchivoIdioma.InfoPaginaReg

#Region "Permisos"

    Private AltaProveedor As Boolean = False
    Private ModificarProveedor As Boolean = False
    Private BajaProveedor As Boolean = False
    Private EliminarTel As Boolean = False

    Private Sub CargarPermisos()
        AltaProveedor = PermisoOK(10)
        AgregarBtn.Enabled = AltaProveedor

        ModificarProveedor = PermisoOK(11)
        ModificarBtn.Enabled = ModificarProveedor

        BajaProveedor = PermisoOK(12)
        EliminarBtn.Enabled = BajaProveedor

        EliminarTel = PermisoOK(13)
        EliminarTelBtn.Enabled = EliminarTel
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

    Private Sub GestionProveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()

        AplicarIdioma()
        CargaTT()
        CargarFoco(GestionProveedoresGB)
        CargarPermisos()

        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBCuit)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBRazonSocial)

        BuscarCmb.SelectedIndex = 0

        If CantidadPaginas = 1 Or ProveedorDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        End If

        ListaProveedorTempGral.AddRange(ListaProveedor)
    End Sub

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        ListaProveedor = ProveedorRN.CargarProveedor()

        For i As Integer = 0 To ListaProveedor.Count - 1
            If BGW.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                BGW.ReportProgress(100 * i / ListaProveedor.Count)
            End If
        Next
    End Sub

    Private Sub BGW_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW.ProgressChanged
        BarraProgreso.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))

        Parte1Lbl.Text = String.Empty
        Parte2Lbl.Text = String.Empty
        InfoPagLbl.Spring = True

        InfoPagina(1)

        ProveedorDG.AutoGenerateColumns = False
        ProveedorDG.DataSource = PaginaSig(NroPag)

        If ProveedorDG.Rows.Count = 0 Then
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

        ListaProveedorTemp.Clear()
        ListaProveedorTemp.AddRange(ListaProveedor)

        ListaProveedor.Clear()

        ListaProveedor = ProveedorRN.BuscarProveedor(BuscarCmb.SelectedItem, BusquedaTxt.Text)
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))

        ProveedorDG.DataSource = Nothing
        ProveedorDG.AutoGenerateColumns = False
        ProveedorDG.DataSource = PaginaSig(NroPag)

        If ProveedorDG.Rows.Count > 0 Then
            InfoPagina(1)
        Else
            InfoPagina(0)
        End If

        If ProveedorDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteProvBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaProveedor.Clear()
            ListaProveedor.AddRange(ListaProveedorTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))
            ProveedorDG.DataSource = Nothing
            ProveedorDG.DataSource = PaginaSig(NroPag)

            If ProveedorDG.Rows.Count > 0 Then
                InfoPagina(1)
            Else
                InfoPagina(0)
            End If
        End If
    End Sub

    Private Sub AgregarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarBtn.Click
        Dim frm As New AltaProveedor
        frm.PuedeModificar = ModificarProveedor

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaProveedor.Clear()
            ListaProveedor = ProveedorRN.CargarProveedor()

            ListaProveedorTempGral.Clear()
            ListaProveedorTempGral.AddRange(ListaProveedor)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))
            InfoPagina(1)
            ProveedorDG.DataSource = Nothing
            ProveedorDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

    Private Sub ModificarBtn_Click(sender As System.Object, e As System.EventArgs) Handles ModificarBtn.Click
        If ProveedorDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoProveedor, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ProveedorDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarProveedor, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim frm As New ModificarProveedor
        frm.CuitSel = ProveedorDG.CurrentRow.Cells(2).Value

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaProveedor.Clear()
            ListaProveedor = ProveedorRN.CargarProveedor()

            ListaProveedorTempGral.Clear()
            ListaProveedorTempGral.AddRange(ListaProveedor)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))
            InfoPagina(1)
            ProveedorDG.DataSource = Nothing
            ProveedorDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarBtn.Click

        If ProveedorDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoProveedor, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ProveedorDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarProveedor, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Proveedor As New ProveedorEN
        Proveedor.CodProv = ProveedorDG.CurrentRow.Cells(0).Value
        Proveedor.RazonSocial = ProveedorDG.CurrentRow.Cells(1).Value
        Proveedor.Cuit = ProveedorDG.CurrentRow.Cells(2).Value

        Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.EliminarProveedor & Proveedor.RazonSocial & " || " & Proveedor.Cuit & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxEliminarProveedor, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Resultado = Windows.Forms.DialogResult.OK Then
            Try
                ProveedorRN.BajaProveedor(Proveedor)
            Catch ex As InformationException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListaProveedor.Clear()
                ListaProveedor = ProveedorRN.CargarProveedor()

                ListaProveedorTempGral.Clear()
                ListaProveedorTempGral.AddRange(ListaProveedor)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))
                ProveedorDG.DataSource = Nothing
                ProveedorDG.DataSource = PaginaSig(NroPag)

                If ProveedorDG.Rows.Count > 0 Then
                    InfoPagina(1)
                Else
                    InfoPagina(0)
                End If

                If CantidadPaginas = 1 Or ProveedorDG.Rows.Count = 0 Then
                    DeshabilitarPaginacion()
                Else
                    HabilitarPaginacion()
                End If

            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ListaProveedor.Clear()
                ListaProveedor = ProveedorRN.CargarProveedor()

                ListaProveedorTempGral.Clear()
                ListaProveedorTempGral.AddRange(ListaProveedor)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))
                ProveedorDG.DataSource = Nothing
                ProveedorDG.DataSource = PaginaSig(NroPag)

                If ProveedorDG.Rows.Count > 0 Then
                    InfoPagina(1)
                Else
                    InfoPagina(0)
                End If

                If CantidadPaginas = 1 Or ProveedorDG.Rows.Count = 0 Then
                    DeshabilitarPaginacion()
                Else
                    HabilitarPaginacion()
                End If
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub EliminarTelBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarTelBtn.Click
        If ProveedorDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoProveedor, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ProveedorDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarProveedor, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim frm As New EliminarTelProveedor
        frm.CodProv = ProveedorDG.CurrentRow.Cells(0).Value
        frm.ShowDialog()
    End Sub

#Region "Paginacion"
    Function PaginaSig(NroPagActual As Integer) As List(Of ProveedorEN)
        NroPag += 1

        Dim ListaAux As New List(Of ProveedorEN)
        For Each item As ProveedorEN In ListaProveedor.Paginacion(NroPag)
            Dim UnProveedor As New ProveedorEN
            UnProveedor.CodProv = item.CodProv
            UnProveedor.RazonSocial = item.RazonSocial
            UnProveedor.Cuit = item.Cuit
            UnProveedor.CorreoElectronico = item.CorreoElectronico
            UnProveedor.Direccion = item.Direccion

            ListaAux.Add(UnProveedor)
        Next

        Return ListaAux
    End Function

    Function PaginaAnt(NroPagActual As Integer) As List(Of ProveedorEN)
        NroPag -= 1

        Dim ListaAux As New List(Of ProveedorEN)
        For Each item As ProveedorEN In ListaProveedor.Paginacion(NroPag)
            Dim UnProveedor As New ProveedorEN
            UnProveedor.CodProv = item.CodProv
            UnProveedor.RazonSocial = item.RazonSocial
            UnProveedor.Cuit = item.Cuit
            UnProveedor.CorreoElectronico = item.CorreoElectronico
            UnProveedor.Direccion = item.Direccion

            ListaAux.Add(UnProveedor)
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

            ProveedorDG.DataSource = Nothing
            ProveedorDG.DataSource = PaginaSig(NroPag)

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

            ProveedorDG.DataSource = Nothing
            ProveedorDG.DataSource = PaginaAnt(NroPag)

            InfoPagina(NroPag)
        End If
    End Sub

    Private Sub PrimeroBtn_Click(sender As System.Object, e As System.EventArgs) Handles PrimeroBtn.Click
        NroPag = 0

        PrimeroBtn.Enabled = False
        AnteriorBtn.Enabled = False

        SiguienteBtn.Enabled = True
        UltimoBtn.Enabled = True

        ProveedorDG.DataSource = Nothing
        ProveedorDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub UltimoBtn_Click(sender As System.Object, e As System.EventArgs) Handles UltimoBtn.Click
        NroPag = CantidadPaginas - 1

        SiguienteBtn.Enabled = False
        UltimoBtn.Enabled = False

        PrimeroBtn.Enabled = True
        AnteriorBtn.Enabled = True

        ProveedorDG.DataSource = Nothing
        ProveedorDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        If ProveedorDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
            Exit Sub
        End If

        If CantidadPaginas = 1 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        ListaProveedor.Clear()
        ListaProveedor.AddRange(ListaProveedorTempGral)

        NroPag = 0
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaProveedor.Count / 25))
        InfoPagina(1)
        ProveedorDG.DataSource = Nothing
        ProveedorDG.DataSource = PaginaSig(NroPag)
    End Sub

    Sub InfoPagina(NroPag As Integer)
        InfoPagLbl.Text = PaginaNro & " " & NroPag & " " & PaginaDe & " " & CantidadPaginas & " " & PaginaRegistros & " " & ListaProveedor.Count
        InfoPagLbl.TextAlign = ContentAlignment.MiddleCenter
    End Sub
#End Region

#Region "Validacion y Diseño"
    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(BusquedaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.BusquedaVacia, BusquedaTxt)
            BusquedaTxt.Clear()
            BusquedaTxt.Focus()
            Resultado = False
        End If

        Select Case BuscarCmb.SelectedItem
            Case My.Resources.ArchivoIdioma.CMBCuit

                Select Case BusquedaTxt.Text.Length
                    Case Is > 13
                        MensajeTT.Show(My.Resources.ArchivoIdioma.Contener13Carac, BusquedaTxt)
                        BusquedaTxt.Focus()
                        Resultado = False
                    Case 1 To 13
                        Dim Cuit As New Regex("([0-9]{2})[-]([0-9]{8})[-]([0-9]{1})")

                        If Not Cuit.IsMatch(BusquedaTxt.Text) Then
                            MensajeTT.Show(My.Resources.ArchivoIdioma.FormatoCUIT, BusquedaTxt)
                            BusquedaTxt.Focus()
                            Resultado = False
                        End If
                    Case Is = 13
                        Dim Cuit As New Regex("([0-9]{2})[-]([0-9]{8})[-]([0-9]{1})")

                        If Not Cuit.IsMatch(BusquedaTxt.Text) Then
                            MensajeTT.Show(My.Resources.ArchivoIdioma.FormatoCUIT, BusquedaTxt)
                            BusquedaTxt.Focus()
                            Resultado = False
                        End If
                End Select

            Case My.Resources.ArchivoIdioma.CMBRazonSocial
                If BusquedaTxt.Text.Length > 50 Then
                    MensajeTT.Show(My.Resources.ArchivoIdioma.Contener50Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False
                End If
        End Select
        Return Resultado
    End Function

    Private Sub GestionProveedor_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GestionProveedorSMI.Enabled = True
    End Sub

    Private Sub GestionProveedor_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "119")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.N And AltaProveedor = True Then
            AgregarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.U And ModificarProveedor = True Then
            ModificarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.D And BajaProveedor = True Then
            EliminarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.T And EliminarTel = True Then
            EliminarTelBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.E Then
            ExportarAXLSToolStripMenuItem.PerformClick()
        End If

    End Sub

    Private Sub BusquedaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles BusquedaTxt.TextChanged
        MensajeTT.Hide(BusquedaTxt)
    End Sub

    Private Sub BuscarCmb_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles BuscarCmb.SelectedIndexChanged
        BusquedaTxt.Clear()
    End Sub

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.GestionProveedorFrm

        GestionProveedoresGB.Text = My.Resources.ArchivoIdioma.GestionProveedorGB
        BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
        IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
        AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarProvBtn
        ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarProvBtn
        EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarProvBtn
        EliminarTelBtn.Text = My.Resources.ArchivoIdioma.EliminarTelBtn

        RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
        CodProvCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        RazonSocialCAB.HeaderText = My.Resources.ArchivoIdioma.RazonSocialGral
        CuitCAB.HeaderText = My.Resources.ArchivoIdioma.CuitGral
        CorreoElectronicoCAB.HeaderText = My.Resources.ArchivoIdioma.CorreoElectronicoGral
        DireccionCAB.HeaderText = My.Resources.ArchivoIdioma.DireccionCAB
    End Sub

    Private Sub CargaTT()
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
        ControlesTP.SetToolTip(AgregarBtn, My.Resources.ArchivoIdioma.TTProveedorAltaBtn)
        ControlesTP.SetToolTip(ModificarBtn, My.Resources.ArchivoIdioma.TTProveedorModificarBtn)
        ControlesTP.SetToolTip(EliminarBtn, My.Resources.ArchivoIdioma.TTProveedorEliminarBtn)
        ControlesTP.SetToolTip(EliminarTelBtn, My.Resources.ArchivoIdioma.TTEliminarTelBtn)
        ControlesTP.SetToolTip(SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
        ControlesTP.SetToolTip(AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
        ControlesTP.SetToolTip(UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
        ControlesTP.SetToolTip(PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(ProveedorDG, My.Resources.ArchivoIdioma.TTListaProveedor)
    End Sub


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

#Region "Exportar XLS"

    Private Sub ExportarAXLSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarAXLSToolStripMenuItem.Click
        If ProveedorDG.RowCount > 0 Then
            Dim Sfd As New SaveFileDialog()
            Sfd.Filter = "Excel (*.xls)|*.xls"
            Sfd.FileName = My.Resources.ArchivoIdioma.FileNameClientePdfXls

            If Sfd.ShowDialog() = DialogResult.OK Then

                Dim App As New Excel.Application
                Dim WB As Excel.Workbook
                Dim WS As New Excel.Worksheet

                WB = App.Workbooks.Add()

                WS = WB.ActiveSheet

                For i As Integer = 1 To ProveedorDG.Columns.Count
                    WS.Cells(1, i) = ProveedorDG.Columns(i - 1).HeaderText
                Next

                For i As Integer = 0 To ProveedorDG.Rows.Count - 1
                    For j As Integer = 0 To ProveedorDG.Columns.Count - 1
                        WS.Cells(i + 2, j + 1) = ProveedorDG.Rows(i).Cells(j).Value.ToString()
                        WS.Cells(i + 2, 1).Font.Color = Color.Blue
                    Next
                Next

                With WS
                    With .Range(.Cells(1, 1), .Cells(1, ProveedorDG.ColumnCount)).Font
                        .Color = Color.White
                        .Bold = 1
                        .Size = 12
                    End With
                    .Range(.Cells(1, 1), .Cells(1, ProveedorDG.ColumnCount)).Interior.Color = Color.Black
                    .Columns.AutoFit()
                    .Columns.HorizontalAlignment = 2
                End With

                WB.SaveAs(Sfd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)

                WB.Close()
                Process.Start(Sfd.FileName)
            End If

        Else
            MessageBox.Show(My.Resources.ArchivoIdioma.NoRegExportar, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

#End Region


End Class