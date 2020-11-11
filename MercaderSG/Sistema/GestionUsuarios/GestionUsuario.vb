Imports Negocios
Imports Entidades
Imports Excepciones
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports Servicios

Public Class GestionUsuario
    Private ListaUsuarios As New List(Of UsuarioEN)
    Private ListaUsuariosTemp As New List(Of UsuarioEN)
    Private ListaUsuariosTempGral As New List(Of UsuarioEN)

    Public NroPag As Integer = 0
    Private CantidadPaginas As Integer = 0

    Public PaginaNro As String = My.Resources.ArchivoIdioma.InfoPaginaPag
    Public PaginaDe As String = My.Resources.ArchivoIdioma.InfoPaginaDe
    Public PaginaRegistros As String = My.Resources.ArchivoIdioma.InfoPaginaReg

#Region "Permisos"

    Private AltaUsuario As Boolean = False
    Private BajaUsuario As Boolean = False
    Private ModificarUsuario As Boolean = False
    Private EliminarTel As Boolean = False

    Dim UsuAut As Autenticar = Autenticar.Instancia()

    Private Sub CargarPermisos()
        AltaUsuario = PermisoOK(22)
        AgregarBtn.Enabled = AltaUsuario

        ModificarUsuario = PermisoOK(23)
        ModificarBtn.Enabled = ModificarUsuario

        BajaUsuario = PermisoOK(24)
        EliminarBtn.Enabled = BajaUsuario

        EliminarTel = PermisoOK(25)
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

    Private Sub GestionUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()

        BusquedaTxt.Focus()

        AplicarIdioma()
        CargaTT()
        CargarPermisos()
        CargarFoco(GestionUsuariosGB)

        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBUsuario)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBApellido)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBNombre)

        BuscarCmb.SelectedIndex = 0

        If CantidadPaginas = 1 Or UsuarioDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        End If

        ListaUsuariosTempGral.AddRange(ListaUsuarios)
    End Sub

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        ListaUsuarios = UsuarioRN.CargarUsuario()
        For i As Integer = 0 To ListaUsuarios.Count - 1
            If BGW.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                BGW.ReportProgress(100 * i / ListaUsuarios.Count)
            End If
        Next
    End Sub

    Private Sub BGW_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW.ProgressChanged
        BarraProgreso.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))

        Parte1Lbl.Text = String.Empty
        Parte2Lbl.Text = String.Empty
        InfoPagLbl.Spring = True

        UsuarioDG.AutoGenerateColumns = False
        UsuarioDG.DataSource = PaginaSig(NroPag)

        If UsuarioDG.Rows.Count = 0 Then
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

        ListaUsuariosTemp.Clear()
        ListaUsuariosTemp.AddRange(ListaUsuarios)

        ListaUsuarios.Clear()
        ListaUsuarios = UsuarioRN.BuscarUsuario(BuscarCmb.SelectedItem, BusquedaTxt.Text)
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))

        UsuarioDG.DataSource = Nothing
        UsuarioDG.AutoGenerateColumns = False
        UsuarioDG.DataSource = PaginaSig(NroPag)

        If UsuarioDG.Rows.Count > 0 Then
            InfoPagina(1)
        Else
            InfoPagina(0)
        End If

        If UsuarioDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteUsuBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaUsuarios.Clear()
            ListaUsuarios.AddRange(ListaUsuariosTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))
            UsuarioDG.DataSource = Nothing
            UsuarioDG.DataSource = PaginaSig(NroPag)

            If UsuarioDG.Rows.Count > 0 Then
                InfoPagina(1)
            Else
                InfoPagina(0)
            End If
        End If
    End Sub

#Region "Acciones"

    Private Sub AgregarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarBtn.Click
        Dim frm As New AltaUsuario
        frm.PuedeModificar = ModificarUsuario

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaUsuarios.Clear()
            ListaUsuarios = UsuarioRN.CargarUsuario()

            ListaUsuariosTempGral.Clear()
            ListaUsuariosTempGral.AddRange(ListaUsuarios)
            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))
            InfoPagina(1)
            UsuarioDG.DataSource = Nothing
            UsuarioDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

    Private Sub ModificarBtn_Click(sender As System.Object, e As System.EventArgs) Handles ModificarBtn.Click
        If UsuarioDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoUsuarios, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = UsuarioDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarUsuario, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If UsuAut.UsuarioLogueado = UsuarioDG.CurrentRow.Cells(1).Value And ModificarUsuario = True Then
            MessageBox.Show(My.Resources.ArchivoIdioma.ModificarVosMismo, My.Resources.ArchivoIdioma.ModificarUsuBtn, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim frm As New ModificarUsuario
            frm.UsuarioSel = UsuarioDG.CurrentRow.Cells(1).Value

            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ListaUsuarios.Clear()
                ListaUsuarios = UsuarioRN.CargarUsuario()

                ListaUsuariosTempGral.Clear()
                ListaUsuariosTempGral.AddRange(ListaUsuarios)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))
                InfoPagina(1)
                UsuarioDG.DataSource = Nothing
                UsuarioDG.DataSource = PaginaSig(NroPag)

                If CantidadPaginas = 1 Then
                    DeshabilitarPaginacion()
                Else
                    HabilitarPaginacion()
                End If
            End If
        End If
    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarBtn.Click
        If UsuarioDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoUsuarios, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = UsuarioDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarUsuario, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim Usuario As New UsuarioEN

        Usuario.CodUsu = UsuarioDG.CurrentRow.Cells(0).Value
        Usuario.Usuario = UsuarioDG.CurrentRow.Cells(1).Value

        If UsuAut.UsuarioLogueado = Usuario.Usuario And BajaUsuario = True Then
            MessageBox.Show(My.Resources.ArchivoIdioma.EliminarVosMismo, My.Resources.ArchivoIdioma.EliminarUsuBtn, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.EliminarUsuario & UsuarioDG.CurrentRow.Cells(1).Value & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxEliminarUsuario, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If Resultado = Windows.Forms.DialogResult.OK Then

                Try
                    UsuarioRN.BajaUsuario(Usuario)
                Catch ex As InformationException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ListaUsuarios.Clear()
                    ListaUsuarios = UsuarioRN.CargarUsuario()

                    ListaUsuariosTempGral.Clear()
                    ListaUsuariosTempGral.AddRange(ListaUsuarios)

                    NroPag = 0
                    CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))
                    UsuarioDG.DataSource = Nothing
                    UsuarioDG.DataSource = PaginaSig(NroPag)

                    If UsuarioDG.Rows.Count > 0 Then
                        InfoPagina(1)
                    Else
                        InfoPagina(0)
                    End If

                    If CantidadPaginas = 1 Or UsuarioDG.Rows.Count = 0 Then
                        DeshabilitarPaginacion()
                    Else
                        HabilitarPaginacion()
                    End If

                Catch ex As WarningException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ListaUsuarios.Clear()
                    ListaUsuarios = UsuarioRN.CargarUsuario()

                    ListaUsuariosTempGral.Clear()
                    ListaUsuariosTempGral.AddRange(ListaUsuarios)

                    NroPag = 0
                    CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))
                    UsuarioDG.DataSource = Nothing
                    UsuarioDG.DataSource = PaginaSig(NroPag)

                    If UsuarioDG.Rows.Count > 0 Then
                        InfoPagina(1)
                    Else
                        InfoPagina(0)
                    End If

                    If CantidadPaginas = 1 Or UsuarioDG.Rows.Count = 0 Then
                        DeshabilitarPaginacion()
                    Else
                        HabilitarPaginacion()
                    End If
                End Try
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub EliminarTelBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarTelBtn.Click
        If UsuarioDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoUsuarios, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = UsuarioDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarUsuario, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim frm As New EliminarTelUsuario
        frm.CodUsu = UsuarioDG.CurrentRow.Cells(0).Value
        frm.ShowDialog()
    End Sub

#End Region

#Region "Paginacion"
    Function PaginaSig(NroPagActual As Integer) As List(Of UsuarioEN)
        NroPag += 1

        Dim ListaAux As New List(Of UsuarioEN)
        For Each item As UsuarioEN In ListaUsuarios.Paginacion(NroPag)
            Dim UnUsuario As New UsuarioEN
            UnUsuario.CodUsu = item.CodUsu
            UnUsuario.Usuario = item.Usuario
            UnUsuario.Apellido = item.Apellido
            UnUsuario.Nombre = item.Nombre
            UnUsuario.CorreoElectronico = item.CorreoElectronico
            UnUsuario.Edad = item.Edad

            ListaAux.Add(UnUsuario)
        Next

        Return ListaAux
    End Function

    Function PaginaAnt(NroPagActual As Integer) As List(Of UsuarioEN)
        NroPag -= 1

        Dim ListaAux As New List(Of UsuarioEN)
        For Each item As UsuarioEN In ListaUsuarios.Paginacion(NroPag)
            Dim UnUsuario As New UsuarioEN
            UnUsuario.CodUsu = item.CodUsu
            UnUsuario.Usuario = item.Usuario
            UnUsuario.Apellido = item.Apellido
            UnUsuario.Nombre = item.Nombre
            UnUsuario.CorreoElectronico = item.CorreoElectronico
            UnUsuario.Edad = item.Edad

            ListaAux.Add(UnUsuario)
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

            UsuarioDG.DataSource = Nothing
            UsuarioDG.DataSource = PaginaSig(NroPag)

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

            UsuarioDG.DataSource = Nothing
            UsuarioDG.DataSource = PaginaAnt(NroPag)

            InfoPagina(NroPag)
        End If
    End Sub

    Private Sub PrimeroBtn_Click(sender As System.Object, e As System.EventArgs) Handles PrimeroBtn.Click
        NroPag = 0

        PrimeroBtn.Enabled = False
        AnteriorBtn.Enabled = False

        SiguienteBtn.Enabled = True
        UltimoBtn.Enabled = True

        UsuarioDG.DataSource = Nothing
        UsuarioDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub UltimoBtn_Click(sender As System.Object, e As System.EventArgs) Handles UltimoBtn.Click
        NroPag = CantidadPaginas - 1

        SiguienteBtn.Enabled = False
        UltimoBtn.Enabled = False

        PrimeroBtn.Enabled = True
        AnteriorBtn.Enabled = True

        UsuarioDG.DataSource = Nothing
        UsuarioDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        If CantidadPaginas = 1 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        ListaUsuarios.Clear()
        ListaUsuarios.AddRange(ListaUsuariosTempGral)

        NroPag = 0
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaUsuarios.Count / 25))
        InfoPagina(1)
        UsuarioDG.DataSource = Nothing
        UsuarioDG.DataSource = PaginaSig(NroPag)
    End Sub

    Sub InfoPagina(NroPag As Integer)
        InfoPagLbl.Text = PaginaNro & " " & NroPag & " " & PaginaDe & " " & CantidadPaginas & " " & PaginaRegistros & " " & ListaUsuarios.Count
        InfoPagLbl.TextAlign = ContentAlignment.MiddleCenter
    End Sub
#End Region

#Region "Exportar Datos"

    Private Sub ExportarAXLSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarAXLSToolStripMenuItem.Click
        If UsuarioDG.RowCount > 0 Then

            Dim Sfd As New SaveFileDialog()
            Sfd.Filter = "Excel (*.xls)|*.xls"
            Sfd.FileName = My.Resources.ArchivoIdioma.FileNameUsuarioPdfXls

            If Sfd.ShowDialog() = DialogResult.OK Then

                Dim App As New Excel.Application
                Dim WB As Excel.Workbook
                Dim WS As New Excel.Worksheet

                WB = App.Workbooks.Add()

                WS = WB.ActiveSheet

                For i As Integer = 1 To UsuarioDG.Columns.Count
                    WS.Cells(1, i) = UsuarioDG.Columns(i - 1).HeaderText
                Next

                For i As Integer = 0 To UsuarioDG.Rows.Count - 1
                    For j As Integer = 0 To UsuarioDG.Columns.Count - 1
                        WS.Cells(i + 2, j + 1) = UsuarioDG.Rows(i).Cells(j).Value.ToString()
                        WS.Cells(i + 2, 1).Font.Color = Color.Blue
                    Next
                Next

                With WS
                    With .Range(.Cells(1, 1), .Cells(1, UsuarioDG.ColumnCount)).Font
                        .Color = Color.White
                        .Bold = 1
                        .Size = 12
                    End With
                    .Range(.Cells(1, 1), .Cells(1, UsuarioDG.ColumnCount)).Interior.Color = Color.Black
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

#Region "Validacion y Diseño"

    Public Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(BusquedaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.BusquedaVacia, BusquedaTxt)
            Resultado = False
            Return Resultado
        End If

        Select Case BuscarCmb.SelectedItem
            Case My.Resources.ArchivoIdioma.CMBApellido
                If BusquedaTxt.Text.Length > 50 Then
                    MensajeTT.Show(My.Resources.ArchivoIdioma.Contener50Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False
                End If

                For i As Integer = 0 To BusquedaTxt.Text.Length - 1
                    If IsNumeric(BusquedaTxt.Text(i)) Then
                        MensajeTT.Show(My.Resources.ArchivoIdioma.BusquedaNumero, BusquedaTxt)
                        Resultado = False
                        Exit For
                    End If
                Next
            Case My.Resources.ArchivoIdioma.CMBNombre
                If BusquedaTxt.Text.Length > 50 Then
                    MensajeTT.Show(My.Resources.ArchivoIdioma.Contener50Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False
                End If

                For i As Integer = 0 To BusquedaTxt.Text.Length - 1
                    If IsNumeric(BusquedaTxt.Text(i)) Then
                        MensajeTT.Show(My.Resources.ArchivoIdioma.BusquedaNumero, BusquedaTxt)
                        Resultado = False
                        Exit For
                    End If
                Next
            Case My.Resources.ArchivoIdioma.CMBUsuario
                If BusquedaTxt.Text.Length < 6 Then
                    MensajeTT.Show(My.Resources.ArchivoIdioma.ContenerMenos6Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False
                End If

                If BusquedaTxt.Text.Length > 20 Then
                    MensajeTT.Show(My.Resources.ArchivoIdioma.Contener20Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False
                End If
        End Select

        Return Resultado
    End Function

    Private Sub BusquedaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles BusquedaTxt.TextChanged
        MensajeTT.Hide(BusquedaTxt)
    End Sub

    Private Sub CargaTT()
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
        ControlesTP.SetToolTip(AgregarBtn, My.Resources.ArchivoIdioma.TTUsuarioAltaBtn)
        ControlesTP.SetToolTip(ModificarBtn, My.Resources.ArchivoIdioma.TTUsuarioModificarBtn)
        ControlesTP.SetToolTip(EliminarBtn, My.Resources.ArchivoIdioma.TTUsuarioEliminarBtn)
        ControlesTP.SetToolTip(EliminarTelBtn, My.Resources.ArchivoIdioma.TTEliminarTelBtn)
        ControlesTP.SetToolTip(SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
        ControlesTP.SetToolTip(AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
        ControlesTP.SetToolTip(UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
        ControlesTP.SetToolTip(PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(UsuarioDG, My.Resources.ArchivoIdioma.TTListaUsuarios)
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

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.GestionUsuarioForm

        GestionUsuariosGB.Text = My.Resources.ArchivoIdioma.GestionUsuariosGB
        BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
        IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
        AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarUsuBtn
        ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarUsuBtn
        EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarUsuBtn
        EliminarTelBtn.Text = My.Resources.ArchivoIdioma.EliminarTelBtn

        RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
        CodUsuCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioCodigoCAB
        UsuarioCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioUsuarioCAB
        ApellidoCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioApellidoCAB
        NombreCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioNombreCAB
        CorreoCAB.HeaderText = My.Resources.ArchivoIdioma.CorreoElectronicoGral
        EdadCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioEdadCAB
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

    Private Sub GestionUsuario_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "120")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.N And AltaUsuario = True Then
            AgregarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.U And ModificarUsuario = True Then
            ModificarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.D And BajaUsuario = True Then
            EliminarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.T And EliminarTel = True Then
            EliminarTelBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.E Then
            ExportarAXLSToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub BusquedaTxt_Validated(sender As System.Object, e As System.EventArgs)
        BusquedaTxt.Text = UCase(Mid(BusquedaTxt.Text, 1, 1)) & LCase(Mid(BusquedaTxt.Text, 2))
    End Sub

    Private Sub GestionUsuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GestionUsuarioSMI.Enabled = True
    End Sub
#End Region

End Class