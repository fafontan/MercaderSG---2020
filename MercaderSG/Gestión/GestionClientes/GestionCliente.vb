Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Text.RegularExpressions

Public Class GestionCliente

    Private UsuAut As Autenticar = Autenticar.Instancia()
    Private ListaClientes As New List(Of ClienteEN)
    Private ListaClientesTemp As New List(Of ClienteEN)
    Private ListaClientesTempGral As New List(Of ClienteEN)

    Public NroPag As Integer = 0
    Private CantidadPaginas As Integer = 0

    Public PaginaNro As String = My.Resources.ArchivoIdioma.InfoPaginaPag
    Public PaginaDe As String = My.Resources.ArchivoIdioma.InfoPaginaDe
    Public PaginaRegistros As String = My.Resources.ArchivoIdioma.InfoPaginaReg

#Region "Permisos"

    Private AltaCliente As Boolean = False
    Private BajaCliente As Boolean = False
    Private ModificarCliente As Boolean = False
    Private EliminarTel As Boolean = False

    Private Sub CargarPermisos()
        AltaCliente = PermisoOK(1)
        AgregarBtn.Enabled = AltaCliente

        ModificarCliente = PermisoOK(2)
        ModificarBtn.Enabled = ModificarCliente

        BajaCliente = PermisoOK(3)
        EliminarBtn.Enabled = BajaCliente

        EliminarTel = PermisoOK(4)
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

    Private Sub GestionCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()
        CargarFoco(GestionClientesGB)

        AplicarIdioma()
        CargarTT()

        CargarPermisos()

        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBCuit)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBRazonSocial)

        BuscarCmb.SelectedIndex = 0

        If CantidadPaginas = 1 Or ClienteDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        End If

        ListaClientesTempGral.AddRange(ListaClientes)
    End Sub

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        Try
            ListaClientes = ClienteRN.CargarCliente()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        For i As Integer = 0 To ListaClientes.Count - 1
            If BGW.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                BGW.ReportProgress(100 * i / ListaClientes.Count)
            End If
        Next
    End Sub

    Private Sub BGW_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW.ProgressChanged
        BarraProgreso.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))

        Parte1Lbl.Text = String.Empty
        Parte2Lbl.Text = String.Empty
        InfoPagLbl.Spring = True

        ClienteDG.AutoGenerateColumns = False
        ClienteDG.DataSource = PaginaSig(NroPag)

        If ClienteDG.Rows.Count = 0 Then
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

        ListaClientesTemp.Clear()
        ListaClientesTemp.AddRange(ListaClientes)

        ListaClientes.Clear()

        ListaClientes = ClienteRN.BuscarCliente(BuscarCmb.SelectedItem, BusquedaTxt.Text)
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))

        ClienteDG.DataSource = Nothing
        ClienteDG.AutoGenerateColumns = False
        ClienteDG.DataSource = PaginaSig(NroPag)

        If ClienteDG.Rows.Count > 0 Then
            InfoPagina(1)
        Else
            InfoPagina(0)
        End If

        If ClienteDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteCliBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaClientes.Clear()
            ListaClientes.AddRange(ListaClientesTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))
            ClienteDG.DataSource = Nothing
            ClienteDG.DataSource = PaginaSig(NroPag)

            If ClienteDG.Rows.Count > 0 Then
                InfoPagina(1)
            Else
                InfoPagina(0)
            End If
        End If
    End Sub

    Private Sub AgregarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarBtn.Click
        Dim frm As New AltaCliente
        frm.PuedeModificar = ModificarCliente

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaClientes.Clear()
            ListaClientes = ClienteRN.CargarCliente()

            ListaClientesTempGral.Clear()
            ListaClientesTempGral.AddRange(ListaClientes)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))
            InfoPagina(1)
            ClienteDG.DataSource = Nothing
            ClienteDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If

    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarBtn.Click

        If ClienteDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoClientes, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ClienteDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarCliente, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Cliente As New ClienteEN

        Cliente.CodCli = ClienteDG.CurrentRow.Cells(0).Value
        Cliente.RazonSocial = ClienteDG.CurrentRow.Cells(1).Value
        Cliente.Cuit = ClienteDG.CurrentRow.Cells(2).Value

        Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.EliminarCliente & Cliente.RazonSocial & " || " & Cliente.Cuit & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxEliminarCliente, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If Resultado = Windows.Forms.DialogResult.OK Then
            Try
                ClienteRN.BajaCliente(Cliente)
            Catch ex As InformationException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListaClientes.Clear()
                ListaClientes = ClienteRN.CargarCliente()

                ListaClientesTempGral.Clear()
                ListaClientesTempGral.AddRange(ListaClientes)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))
                ClienteDG.DataSource = Nothing
                ClienteDG.DataSource = PaginaSig(NroPag)

                If ClienteDG.Rows.Count > 0 Then
                    InfoPagina(1)
                Else
                    InfoPagina(0)
                End If

                If CantidadPaginas = 1 Or ClienteDG.Rows.Count = 0 Then
                    DeshabilitarPaginacion()
                Else
                    HabilitarPaginacion()
                End If

            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ListaClientes.Clear()
                ListaClientes = ClienteRN.CargarCliente()

                ListaClientesTempGral.Clear()
                ListaClientesTempGral.AddRange(ListaClientes)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))
                ClienteDG.DataSource = Nothing
                ClienteDG.DataSource = PaginaSig(NroPag)

                If ClienteDG.Rows.Count > 0 Then
                    InfoPagina(1)
                Else
                    InfoPagina(0)
                End If

                If CantidadPaginas = 1 Or ClienteDG.Rows.Count = 0 Then
                    DeshabilitarPaginacion()
                Else
                    HabilitarPaginacion()
                End If
            End Try
        Else
            Exit Sub
        End If

    End Sub

    Private Sub ModificarBtn_Click(sender As System.Object, e As System.EventArgs) Handles ModificarBtn.Click
        If ClienteDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoClientes, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ClienteDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarCliente, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim RazonSocial, Cuit As String

        RazonSocial = ClienteDG.CurrentRow.Cells(1).Value
        Cuit = ClienteDG.CurrentRow.Cells(2).Value

        Dim frm As New ModificarCliente
        frm.ClienteSel = ClienteDG.CurrentRow.Cells(2).Value

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListaClientes.Clear()
            ListaClientes = ClienteRN.CargarCliente()
            ListaClientesTempGral.Clear()
            ListaClientesTempGral.AddRange(ListaClientes)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))
            InfoPagina(1)
            ClienteDG.DataSource = Nothing
            ClienteDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If
        End If
    End Sub

    Private Sub EliminarTelBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarTelBtn.Click
        If ClienteDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoClientes, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = ClienteDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarCliente, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim frm As New EliminarTelCliente
        frm.CodCli = ClienteDG.CurrentRow.Cells(0).Value
        frm.ShowDialog()
    End Sub

#Region "Validaciones y Diseño"
    Public Function ConsistenciaDatos() As Boolean
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

    Private Sub BuscarCmb_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles BuscarCmb.SelectedIndexChanged
        BusquedaTxt.Clear()
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

    Private Sub GestionCliente_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GestionClienteSMI.Enabled = True
    End Sub

    Private Sub BusquedaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles BusquedaTxt.TextChanged
        MensajeTT.Hide(BusquedaTxt)
    End Sub

    Private Sub GestionCliente_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.N And AltaCliente = True Then
            AgregarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.U And ModificarCliente = True Then
            ModificarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.D And BajaCliente = True Then
            EliminarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.T And EliminarTel = True Then
            EliminarTelBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.E Then
            ExportarAXLSToolStripMenuItem.PerformClick()
        End If

        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "114")
        End If

    End Sub

#End Region

#Region "Paginacion"

    Function PaginaSig(NroPagActual As Integer) As List(Of ClienteEN)
        NroPag += 1

        Dim ListaAux As New List(Of ClienteEN)
        For Each item As ClienteEN In ListaClientes.Paginacion(NroPag)
            Dim UnCliente As New ClienteEN
            UnCliente.CodCli = item.CodCli
            UnCliente.RazonSocial = item.RazonSocial
            UnCliente.Cuit = item.Cuit
            UnCliente.Direccion = item.Direccion
            UnCliente.Localidad = item.Localidad

            ListaAux.Add(UnCliente)
        Next

        Return ListaAux
    End Function

    Function PaginaAnt(NroPagActual As Integer) As List(Of ClienteEN)
        NroPag -= 1

        Dim ListaAux As New List(Of ClienteEN)
        For Each item As ClienteEN In ListaClientes.Paginacion(NroPag)
            Dim UnCliente As New ClienteEN
            UnCliente.CodCli = item.CodCli
            UnCliente.RazonSocial = item.RazonSocial
            UnCliente.Cuit = item.Cuit
            UnCliente.Direccion = item.Direccion
            UnCliente.Localidad = item.Localidad

            ListaAux.Add(UnCliente)
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

            ClienteDG.DataSource = Nothing
            ClienteDG.DataSource = PaginaSig(NroPag)

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

            ClienteDG.DataSource = Nothing
            ClienteDG.DataSource = PaginaAnt(NroPag)

            InfoPagina(NroPag)
        End If
    End Sub

    Private Sub PrimeroBtn_Click(sender As System.Object, e As System.EventArgs) Handles PrimeroBtn.Click
        NroPag = 0

        PrimeroBtn.Enabled = False
        AnteriorBtn.Enabled = False

        SiguienteBtn.Enabled = True
        UltimoBtn.Enabled = True

        ClienteDG.DataSource = Nothing
        ClienteDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub UltimoBtn_Click(sender As System.Object, e As System.EventArgs) Handles UltimoBtn.Click
        NroPag = CantidadPaginas - 1

        SiguienteBtn.Enabled = False
        UltimoBtn.Enabled = False

        PrimeroBtn.Enabled = True
        AnteriorBtn.Enabled = True

        ClienteDG.DataSource = Nothing
        ClienteDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        If ClienteDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
            Exit Sub
        End If

        If CantidadPaginas = 1 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        ListaClientes.Clear()
        ListaClientes.AddRange(ListaClientesTempGral)

        NroPag = 0
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaClientes.Count / 25))
        InfoPagina(1)
        ClienteDG.DataSource = Nothing
        ClienteDG.DataSource = PaginaSig(NroPag)
    End Sub

    Sub InfoPagina(NroPag As Integer)
        InfoPagLbl.Text = PaginaNro & " " & NroPag & " " & PaginaDe & " " & CantidadPaginas & " " & PaginaRegistros & " " & ListaClientes.Count
        InfoPagLbl.TextAlign = ContentAlignment.MiddleCenter
    End Sub

#End Region

#Region "Exportar Datos"

    Private Sub ExportarAXLSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarAXLSToolStripMenuItem.Click

    End Sub
#End Region

    Private Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.GestionClienteFrm

        GestionClientesGB.Text = My.Resources.ArchivoIdioma.GestionClienteGB
        BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
        IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
        AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarCliBtn
        ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarCliBtn
        EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarCliBtn
        EliminarTelBtn.Text = My.Resources.ArchivoIdioma.EliminarTelBtn

        RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
        CodCliCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        RazonSocialCAB.HeaderText = My.Resources.ArchivoIdioma.RazonSocialGral
        CuitCAB.HeaderText = My.Resources.ArchivoIdioma.CuitGral
        DireccionCAB.HeaderText = My.Resources.ArchivoIdioma.DireccionCAB
        LocalidadCAB.HeaderText = My.Resources.ArchivoIdioma.LocalidadLbl
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
        ControlesTP.SetToolTip(AgregarBtn, My.Resources.ArchivoIdioma.TTClienteAltaBtn)
        ControlesTP.SetToolTip(ModificarBtn, My.Resources.ArchivoIdioma.TTClienteModificarBtn)
        ControlesTP.SetToolTip(EliminarBtn, My.Resources.ArchivoIdioma.TTClienteEliminarBtn)
        ControlesTP.SetToolTip(EliminarTelBtn, My.Resources.ArchivoIdioma.TTEliminarTelBtn)
        ControlesTP.SetToolTip(SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
        ControlesTP.SetToolTip(AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
        ControlesTP.SetToolTip(UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
        ControlesTP.SetToolTip(PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(ClienteDG, My.Resources.ArchivoIdioma.TTListaClientes)
    End Sub

    Private Sub OperacionGB_Enter(sender As System.Object, e As System.EventArgs) Handles OperacionGB.Enter

    End Sub

    Private Sub ClienteDG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ClienteDG.CellContentClick

    End Sub
End Class