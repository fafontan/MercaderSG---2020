Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports Ionic.Zip
Imports System.IO

Public Class Backup
    '    Private Sub GenerarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
    '        Try
    '            If Not ConsistenciaDatos() Then
    '                Exit Sub
    '            End If

    '            If ContraseñaZipTxt.Text <> ReContraseñaZipTxt.Text Then
    '                MessageBox.Show(My.Resources.ArchivoIdioma.ContraseñaNoCoinciden, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                ContraseñaZipTxt.Clear()
    '                ReContraseñaZipTxt.Clear()
    '                ContraseñaZipTxt.Focus()
    '                Exit Sub
    '            End If

    '            Dim ListaArchivos As New List(Of String)
    '            ListaArchivos = Servicios.Backup.EjecutarBackup(RutaTxt.Text, VolumenNUD.Value)

    '            Dim contador As Integer = 0
    '            Dim FechaActual As Date = Today.Date
    '            Dim FechaStr As String
    '            FechaStr = "Fecha" & FechaActual.ToString("dd-MM-yyyy")

    '            For Each item As String In ListaArchivos
    '                Dim ZipArchivos As New ZipFile

    '                If Not ListaArchivos.Count = 1 Then
    '                    contador += 1
    '                End If

    '                ZipArchivos.Password = ContraseñaZipTxt.Text
    '                ZipArchivos.AddFile(item, "")

    '                If ListaArchivos.Count = 1 Then
    '                    ZipArchivos.Save(RutaTxt.Text & "\" & NombreZipTxt.Text & "." & FechaStr & ".zip")
    '                Else
    '                    ZipArchivos.Save(RutaTxt.Text & "\" & NombreZipTxt.Text & contador.ToString("00") & "." & FechaStr & ".zip")
    '                End If

    '                File.Delete(item)
    '            Next

    '            MessageBox.Show(My.Resources.ArchivoIdioma.BackupGenerado, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            If ex.Message = My.Resources.ArchivoIdioma.BDNoExiste Then
    '                Me.Close()
    '            End If
    '        End Try
    '    End Sub

    '    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click
    '        MensajeTT.Hide(RutaTxt)

    '        AbrirFD.ShowDialog()
    '        Dim Ruta As String
    '        Ruta = AbrirFD.SelectedPath

    '        RutaTxt.Text = Ruta
    '    End Sub

    '    Private Sub Backup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '        VolumenNUD.Value = 1

    '        CargarTT()
    '        AplicarIdioma()
    '    End Sub

    '    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
    '        Me.Close()
    '    End Sub

    '#Region "Validaciones"

    '    Private Function ConsistenciaDatos() As Boolean
    '        Dim Resultado As Boolean = True

    '        If String.IsNullOrEmpty(RutaTxt.Text) Then
    '            MensajeTT.Show(My.Resources.ArchivoIdioma.SeleccionarRuta, BuscarBtn)
    '            Resultado = False

    '            Return Resultado
    '        End If

    '        'Nombre
    '        If String.IsNullOrEmpty(NombreZipTxt.Text) Then
    '            ErrorP.SetError(NombreZipTxt, My.Resources.ArchivoIdioma.CampoVacio)
    '            Resultado = False
    '        Else
    '            If NombreZipTxt.Text.Length > 12 Then
    '                ErrorP.SetError(NombreZipTxt, My.Resources.ArchivoIdioma.Contener12Carac)
    '                Resultado = False
    '            End If
    '        End If

    '        'ContraseñaTxt
    '        If String.IsNullOrEmpty(ContraseñaZipTxt.Text) Then
    '            ErrorP.SetError(ContraseñaZipTxt, My.Resources.ArchivoIdioma.CampoVacio)
    '            Resultado = False
    '        Else
    '            If ContraseñaZipTxt.Text.Length < 8 Then
    '                ErrorP.SetError(ContraseñaZipTxt, My.Resources.ArchivoIdioma.ContenerMenos8Carac)
    '                Resultado = False
    '            End If

    '            If ContraseñaZipTxt.Text.Length > 12 Then
    '                ErrorP.SetError(ContraseñaZipTxt, My.Resources.ArchivoIdioma.Contener12Carac)
    '                Resultado = False
    '            End If
    '        End If

    '        'Reingresar
    '        If String.IsNullOrEmpty(ReContraseñaZipTxt.Text) Then
    '            ErrorP.SetError(ReContraseñaZipTxt, My.Resources.ArchivoIdioma.CampoVacio)
    '            Resultado = False
    '        Else
    '            If ReContraseñaZipTxt.Text.Length < 8 Then
    '                ErrorP.SetError(ReContraseñaZipTxt, My.Resources.ArchivoIdioma.ContenerMenos8Carac)
    '                Resultado = False
    '            End If

    '            If ReContraseñaZipTxt.Text.Length > 12 Then
    '                ErrorP.SetError(ReContraseñaZipTxt, My.Resources.ArchivoIdioma.Contener12Carac)
    '                Resultado = False
    '            End If
    '        End If

    '        'Volumen
    '        If String.IsNullOrEmpty(DirectCast(VolumenNUD, Control).Text) Then
    '            ErrorP.SetError(VolumenNUD, My.Resources.ArchivoIdioma.IngresarValor)
    '            Resultado = False
    '        End If

    '        Return Resultado
    '    End Function

    '    Private Sub VolumenNUD_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles VolumenNUD.KeyPress
    '        MensajeTT.Hide(VolumenNUD)

    '        Dim CaracteresPermitidos As String = "1234567890" & Convert.ToChar(8)
    '        Dim c As Char = e.KeyChar
    '        If Not CaracteresPermitidos.Contains(c) Then
    '            e.Handled = True
    '        End If
    '    End Sub

    '    Private Sub Backup_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '        Principal.BackupSMI.Enabled = True
    '    End Sub

    '    Private Sub Backup_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '        If e.KeyCode = Keys.F1 Then
    '            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
    '            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "105")
    '        End If

    '        If e.KeyCode = Keys.Escape Then
    '            Me.Close()
    '        End If
    '    End Sub

    '#End Region

    '#Region "Idioma y TT"

    '    Public Sub AplicarIdioma()
    '        Me.Text = My.Resources.ArchivoIdioma.BackupFrm

    '        BackupGB.Text = My.Resources.ArchivoIdioma.Backup
    '        DestinoLbl.Text = My.Resources.ArchivoIdioma.DestinoLbl
    '        VolumenLbl.Text = My.Resources.ArchivoIdioma.VolumenLbl

    '        NombreZipLbl.Text = My.Resources.ArchivoIdioma.NombreZip
    '        ContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ContraseñaZip
    '        ReContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ReContraseñaZip

    '        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
    '        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    '    End Sub

    '    Private Sub CargarTT()
    '        ControlesTP.SetToolTip(RutaTxt, My.Resources.ArchivoIdioma.TTRuta)
    '        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarRutaBK)
    '        ControlesTP.SetToolTip(VolumenNUD, My.Resources.ArchivoIdioma.TTVolumenes)
    '        ControlesTP.SetToolTip(NombreZipTxt, My.Resources.ArchivoIdioma.TTNombreZip)
    '        ControlesTP.SetToolTip(ContraseñaZipTxt, My.Resources.ArchivoIdioma.TTContraseñaZip)
    '        ControlesTP.SetToolTip(ReContraseñaZipTxt, My.Resources.ArchivoIdioma.TTReContraseñaZip)
    '        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTGenerarBackup)
    '        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    '    End Sub

    '#End Region

    '    Private Sub NombreZipTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles NombreZipTxt.TextChanged
    '        ErrorP.SetError(NombreZipTxt, "")
    '    End Sub

    '    Private Sub ContraseñaZipTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ContraseñaZipTxt.TextChanged
    '        ErrorP.SetError(ContraseñaZipTxt, "")
    '    End Sub

    '    Private Sub ReContraseñaZipTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ReContraseñaZipTxt.TextChanged
    '        ErrorP.SetError(ReContraseñaZipTxt, "")
    '    End Sub
End Class