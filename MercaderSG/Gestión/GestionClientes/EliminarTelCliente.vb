Imports Entidades
Imports Servicios
Imports Negocios
Imports Excepciones
Imports System.IO

Public Class EliminarTelCliente

    Public CodCli As Integer

    Private Sub EliminarTelCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AplicarIdioma()
        CargarTT()
        TelefonosDG.AutoGenerateColumns = False

        Try
            TelefonosDG.DataSource = ClienteRN.ObtenerTelefonoCliente(CodCli)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Dispose()
        End Try
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        Dim Validacion As Boolean = True

        If TelefonosDG.Rows.Count = 0 Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.NoTelefonoDG, AceptarBtn)
            Validacion = False
        ElseIf TelefonosDG.SelectedRows Is Nothing Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.NoTelSeleccionado, AceptarBtn)
            Validacion = False
        End If

        If Validacion = True Then

            Dim UnTelefono As New TelefonoEN
            UnTelefono.CodTel = TelefonosDG.CurrentRow.Cells(0).Value
            UnTelefono.CodEn = TelefonosDG.CurrentRow.Cells(1).Value
            UnTelefono.Numero = TelefonosDG.CurrentRow.Cells(2).Value

            Dim resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.EliminarNumeroTel & TelefonosDG.CurrentRow.Cells(2).Value & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgEliminarNumeroTel, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If resultado = Windows.Forms.DialogResult.OK And TelefonosDG.Rows.Count > 3 Then
                Try
                    ClienteRN.EliminarTelefonoCliente(UnTelefono)
                Catch ex As InformationException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As WarningException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Try
                        TelefonosDG.DataSource = ClienteRN.ObtenerTelefonoCliente(CodCli)
                    Catch exce As WarningException
                        MessageBox.Show(exce.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Close()
                    End Try

                End Try

            ElseIf resultado = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                MessageBox.Show(My.Resources.ArchivoIdioma.EliminarMenosTresTelCli, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Try
                TelefonosDG.DataSource = ClienteRN.ObtenerTelefonoCliente(CodCli)
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End Try

        End If
    End Sub

    Private Sub EliminarTelCliente_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "110")
        End If
    End Sub

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.EliminarTelFrm

        TelefonosGB.Text = My.Resources.ArchivoIdioma.TelefonosGB
        CodTelCAB.HeaderText = My.Resources.ArchivoIdioma.CodTelefono
        CodCliCAB.HeaderText = My.Resources.ArchivoIdioma.CodCliTel
        NumeroCAB.HeaderText = My.Resources.ArchivoIdioma.NumeroTelLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(TelefonosDG, My.Resources.ArchivoIdioma.TTListaTel)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarEliTel)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

    Private Sub TelefonosDG_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TelefonosDG.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Validacion As Boolean = True

            If TelefonosDG.Rows.Count = 0 Then
                MensajeTT.Show(My.Resources.ArchivoIdioma.NoTelefonoDG, AceptarBtn)
                Validacion = False
            ElseIf TelefonosDG.SelectedRows Is Nothing Then
                MensajeTT.Show(My.Resources.ArchivoIdioma.NoTelSeleccionado, AceptarBtn)
                Validacion = False
            End If

            If Validacion = True Then
                Try
                    Dim UnTelefono As New TelefonoEN
                    UnTelefono.CodTel = TelefonosDG.CurrentRow.Cells(0).Value
                    UnTelefono.CodEn = TelefonosDG.CurrentRow.Cells(1).Value
                    UnTelefono.Numero = TelefonosDG.CurrentRow.Cells(2).Value

                    Dim resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.EliminarNumeroTel & TelefonosDG.CurrentRow.Cells(2).Value & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgEliminarNumeroTel, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    If resultado = Windows.Forms.DialogResult.OK And TelefonosDG.Rows.Count > 3 Then
                        ClienteRN.EliminarTelefonoCliente(UnTelefono)
                    ElseIf resultado = Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    Else
                        MessageBox.Show(My.Resources.ArchivoIdioma.EliminarMenosTresTelCli, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Catch ex As InformationException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As WarningException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Try
                        TelefonosDG.DataSource = ClienteRN.ObtenerTelefonoCliente(CodCli)
                    Catch exce As WarningException
                        MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Close()
                    End Try
                End Try

                Try
                    TelefonosDG.DataSource = ClienteRN.ObtenerTelefonoCliente(CodCli)
                Catch ex As WarningException
                    MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                End Try
            End If
        End If
    End Sub
End Class