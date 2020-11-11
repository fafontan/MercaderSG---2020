Imports Entidades
Imports Servicios
Imports Excepciones
Imports Negocios
Imports System.IO

Public Class GestionNV

#Region "Permisos"

    Dim UsuAut As Autenticar = Autenticar.Instancia()
    Public ConsultarNota As Boolean = False
    Public BajaNV As Boolean = False
    Public ConsultaRemitoNV As Boolean = False
    Public GenerarRemitoNV As Boolean = False

    Private Sub CargarPermisos()
        ConsultarNota = PermisoOK(14)
        BajaNV = PermisoOK(17)
        ConsultaRemitoNV = PermisoOK(15)
        GenerarRemitoNV = PermisoOK(16)
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

    Private Sub GestionNV_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
        CargarPermisos()

        If ConsultarNota = True Then
            AccionCMB.Items.Add(My.Resources.ArchivoIdioma.ConsultarNV)
        End If

        If ConsultaRemitoNV = True Then
            AccionCMB.Items.Add(My.Resources.ArchivoIdioma.ConsultarRemNV)
        End If

        If GenerarRemitoNV = True Then
            AccionCMB.Items.Add(My.Resources.ArchivoIdioma.GenerarRemito)
        End If

        If BajaNV = True Then
            AccionCMB.Items.Add(My.Resources.ArchivoIdioma.BajaNotaVenta)
        End If

        AccionCMB.SelectedIndex = 0

        NotaVentaDG.AutoGenerateColumns = False
        NotaVentaDG.DataSource = NotaVentaRN.CargarNotaVenta()
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        If NotaVentaDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoNotasVentas, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = NotaVentaDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarNV, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Select Case AccionCMB.SelectedItem
            Case My.Resources.ArchivoIdioma.ConsultarNV
                Dim frm As New ConsultarNV
                frm.NroNota = NotaVentaDG.CurrentRow.Cells(0).Value
                frm.Show()
                NroNotaTxt.Clear()
            Case My.Resources.ArchivoIdioma.GenerarRemito
                Try
                    NVRemitoRN.GenerarRemito(NotaVentaDG.CurrentRow.Cells(0).Value)
                Catch ex As InformationException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    NroNotaTxt.Clear()
                Catch ex As WarningException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    NroNotaTxt.Clear()
                End Try

            Case My.Resources.ArchivoIdioma.ConsultarRemNV
                Dim frm As New ConsultarRemito
                frm.NroNota = NotaVentaDG.CurrentRow.Cells(0).Value
                frm.Show()

                NroNotaTxt.Clear()
            Case My.Resources.ArchivoIdioma.BajaNotaVenta
                Try
                    Dim NV As New NotaVentaEN
                    NV.NroNota = NotaVentaDG.CurrentRow.Cells(0).Value
                    NotaVentaRN.BajaNotaVenta(NV)
                Catch ex As InformationException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    NotaVentaDG.DataSource = NotaVentaRN.CargarNotaVenta()
                    NroNotaTxt.Clear()
                Catch ex As WarningException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    NroNotaTxt.Clear()
                End Try
        End Select

    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Try
            NotaVentaDG.DataSource = NotaVentaRN.BuscarNotaVenta(NroNotaTxt.Text)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NroNotaTxt.Clear()

            NotaVentaDG.DataSource = NotaVentaRN.CargarNotaVenta()
        End Try

        If NotaVentaDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteNVBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NroNotaTxt.Clear()

            NotaVentaDG.DataSource = NotaVentaRN.CargarNotaVenta()
        End If
    End Sub

    Private Sub GestionNV_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GestionNVSMI.Enabled = True
    End Sub

    Private Sub GestionNV_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "117")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.GestionNVFrm
        AccionLbl.Text = My.Resources.ArchivoIdioma.AccionLbl

        NroNotaLbl.Text = My.Resources.ArchivoIdioma.NumeroNota
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        NotaGB.Text = My.Resources.ArchivoIdioma.NotaVentaGB
        NroNotaCAB.HeaderText = My.Resources.ArchivoIdioma.NroNotaCAB
        FechaCAB.HeaderText = My.Resources.ArchivoIdioma.FechaLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(AccionCMB, My.Resources.ArchivoIdioma.TTListaAcciones)
        ControlesTP.SetToolTip(NroNotaTxt, My.Resources.ArchivoIdioma.TTNroNotaVenta)
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarNotaVenta)
        ControlesTP.SetToolTip(NotaVentaDG, My.Resources.ArchivoIdioma.TTListaNotaVenta)
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
End Class