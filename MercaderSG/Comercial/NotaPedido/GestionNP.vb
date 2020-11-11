Imports Entidades
Imports Servicios
Imports Excepciones
Imports Negocios
Imports System.IO

Public Class GestionNP

#Region "Permisos"
    Private UsuAut As Autenticar = Autenticar.Instancia()
    Public ConsultarNota As Boolean = False
    Public BajaNP As Boolean = False

    Private Sub CargarPermisos()
        ConsultarNota = PermisoOK(19)
        BajaNP = PermisoOK(20)
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

    Private Sub GestionNP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
        CargarPermisos()

        If ConsultarNota = True Then
            AccionCMB.Items.Add(My.Resources.ArchivoIdioma.ConsultarNP)
        End If

        If BajaNP = True Then
            AccionCMB.Items.Add(My.Resources.ArchivoIdioma.BajaNotaPed)
        End If

        AccionCMB.SelectedIndex = 0
        NotaPedidoDG.AutoGenerateColumns = False
        NotaPedidoDG.DataSource = NotaPedidoRN.CargarNotaPedido()
    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Try
            NotaPedidoDG.DataSource = NotaPedidoRN.BuscarNotaPedido(NroNotaTxt.Text)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NroNotaTxt.Clear()
            NroNotaTxt.Focus()

            NotaPedidoDG.DataSource = NotaPedidoRN.CargarNotaPedido()
        End Try

        If NotaPedidoDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteNPBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NroNotaTxt.Clear()
            NroNotaTxt.Focus()

            NotaPedidoDG.DataSource = NotaPedidoRN.CargarNotaPedido()
        End If

    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        If NotaPedidoDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoNotasPedido, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = NotaPedidoDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarNP, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Select Case AccionCMB.SelectedItem
            Case My.Resources.ArchivoIdioma.ConsultarNP
                Dim frm As New ConsultarNP
                frm.NroNota = NotaPedidoDG.CurrentRow.Cells(0).Value
                frm.Show()
            Case My.Resources.ArchivoIdioma.BajaNotaPed

                Dim NV As New NotaPedidoEN
                NV.NroNota = NotaPedidoDG.CurrentRow.Cells(0).Value
                Try
                    NotaPedidoRN.BajaNotaPedido(NV)
                Catch ex As InformationException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    NotaPedidoDG.DataSource = NotaPedidoRN.CargarNotaPedido()
                Catch ex As WarningException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    NroNotaTxt.Clear()
                End Try
        End Select
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.GestionNPFrm
        AccionLbl.Text = My.Resources.ArchivoIdioma.AccionLbl

        NroNotaLbl.Text = My.Resources.ArchivoIdioma.NumeroNota
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        NotaGB.Text = My.Resources.ArchivoIdioma.NotaPedidoGB
        NroNotaCAB.HeaderText = My.Resources.ArchivoIdioma.NroNotaCAB
        FechaCAB.HeaderText = My.Resources.ArchivoIdioma.FechaLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(AccionCMB, My.Resources.ArchivoIdioma.TTListaAcciones)
        ControlesTP.SetToolTip(NroNotaTxt, My.Resources.ArchivoIdioma.TTNroNotaPedido)
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarNotaPedido)
        ControlesTP.SetToolTip(NotaPedidoDG, My.Resources.ArchivoIdioma.TTListaNotaPedido)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTRealizarAccion)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(NroNotaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.CampoVacio, NroNotaTxt)
            Resultado = False
            Return Resultado
        End If

        Return Resultado
    End Function

    Private Sub NroNotaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles NroNotaTxt.TextChanged
        MensajeTT.Hide(NroNotaTxt)
    End Sub

    Private Sub NroNotaTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles NroNotaTxt.KeyPress
        Dim CaracteresPermitidos As String = "QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890-" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar

        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NroNotaTxt_Validated(sender As System.Object, e As System.EventArgs) Handles NroNotaTxt.Validated
        NroNotaTxt.Text = UCase(NroNotaTxt.Text)
    End Sub

#End Region

    Private Sub GestionNP_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GestionNPSMI.Enabled = True
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub GestionNP_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "116")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class