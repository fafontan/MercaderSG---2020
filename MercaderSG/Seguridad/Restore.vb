Imports Servicios
Imports Excepciones
Imports Ionic.Zip
Imports System.IO

Public Class Restore
    '    Private ListaArchivos As New List(Of String)
    '    Private DirectorioBak As DirectoryInfo
    '    Private Directorio As String = "C:\Extract"

    '    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click
    '        ErrorP.SetError(BuscarBtn, "")

    '        If Not ConsistenciaDatos() Then
    '            Exit Sub
    '        End If

    '        If ContraseñaZipTxt.Text <> ReContraseñaZipTxt.Text Then
    '            MessageBox.Show(My.Resources.ArchivoIdioma.ContraseñaNoCoinciden, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            ContraseñaZipTxt.Clear()
    '            ReContraseñaZipTxt.Clear()
    '            ContraseñaZipTxt.Focus()
    '            Exit Sub
    '        End If

    '        If GuardarFD.ShowDialog() = Windows.Forms.DialogResult.OK Then

    '            If Directory.Exists(Directorio) Then
    '                Dim DirectorioC As DirectoryInfo = New DirectoryInfo(Directorio)
    '                For Each ArchivoBorrar As FileInfo In DirectorioC.GetFiles()
    '                    ArchivoBorrar.Delete()
    '                Next
    '                Directory.Delete(Directorio)
    '                Directory.CreateDirectory(Directorio)
    '            Else
    '                Directory.CreateDirectory(Directorio)
    '            End If

    '            DirectorioBak = New DirectoryInfo(Directorio)

    '            For Each item As String In GuardarFD.FileNames
    '                Dim ArchivoZip As ZipFile = ZipFile.Read(item)
    '                ArchivoZip.Password = ContraseñaZipTxt.Text

    '                Dim ExistePass As Boolean = ZipFile.CheckZipPassword(item, ContraseñaZipTxt.Text)

    '                If ExistePass Then
    '                    ContraseñaZipTxt.ReadOnly = True
    '                    ReContraseñaZipTxt.ReadOnly = True
    '                    BuscarBtn.Enabled = False
    '                    NuevoBtn.Enabled = True

    '                    Dim EntradaZip As New ZipEntry
    '                    For Each EntradaZip In ArchivoZip
    '                        EntradaZip.Extract(Directorio, ExtractExistingFileAction.OverwriteSilently)
    '                        ListaArchivos.Add(Directorio & "\" & EntradaZip.FileName)
    '                    Next
    '                Else
    '                    MessageBox.Show(My.Resources.ArchivoIdioma.ContraseñaIncorrecta, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    ContraseñaZipTxt.Clear()
    '                    ReContraseñaZipTxt.Clear()
    '                    ContraseñaZipTxt.Focus()
    '                    Exit Sub
    '                End If
    '            Next

    '            ArchivosLB.DataSource = ListaArchivos
    '            AceptarBtn.Enabled = True
    '        Else
    '            ErrorP.SetError(BuscarBtn, My.Resources.ArchivoIdioma.NoAgregoBAK)
    '            Exit Sub
    '        End If
    '    End Sub

    '    Private Sub GenerarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
    '        Try
    '            If Servicios.Restore.EjecutarRestore(ListaArchivos) Then
    '                MessageBox.Show(My.Resources.ArchivoIdioma.RestoreGenerado, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                For Each ArchivoBak As FileInfo In DirectorioBak.GetFiles()
    '                    ArchivoBak.Delete()
    '                Next
    '                Directory.Delete(Directorio)
    '                Me.Close()
    '            Else
    '                ListaArchivos.Clear()
    '                ArchivosLB.DataSource = Nothing
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            If ArchivosLB.Items.Count > 0 Then
    '                For Each ArchivoBak As FileInfo In DirectorioBak.GetFiles()
    '                    ArchivoBak.Delete()
    '                Next
    '                Directory.Delete(Directorio)
    '            End If

    '            NuevoBtn.PerformClick()
    '        End Try

    '    End Sub

    '    Private Sub Restore_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '        GuardarFD.Filter = My.Resources.ArchivoIdioma.ArchivoBack
    '        GuardarFD.Title = My.Resources.ArchivoIdioma.SelBackup
    '        GuardarFD.FileName = ""
    '        GuardarFD.Multiselect = True


    '        AceptarBtn.Enabled = False
    '        NuevoBtn.Enabled = False
    '        CargarTT()
    '        AplicarIdioma()
    '    End Sub

    '    Private Sub Restore_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '        Principal.RestoreSMI.Enabled = True
    '    End Sub

    '    Private Sub Restore_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '        If e.KeyCode = Keys.F1 Then
    '            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
    '            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "133")
    '        End If

    '        If e.KeyCode = Keys.Escape Then
    '            Me.Close()
    '        End If
    '    End Sub

    '    Private Function ConsistenciaDatos() As Boolean
    '        Dim Resultado As Boolean = True

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

    '        Return Resultado
    '    End Function

    '    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
    '        Me.Close()
    '    End Sub

    '#Region "Idioma y TT"

    '    Public Sub AplicarIdioma()
    '        Me.Text = My.Resources.ArchivoIdioma.RestoreFrm

    '        RestaurarGB.Text = My.Resources.ArchivoIdioma.RestoreGB

    '        DestinoLbl.Text = My.Resources.ArchivoIdioma.DestinoRestoreLbl
    '        ContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ContraseñaZip
    '        ReContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ReContraseñaZip
    '        NuevoBtn.Text = My.Resources.ArchivoIdioma.NuevoGral

    '        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
    '        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    '    End Sub

    '    Private Sub CargarTT()
    '        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBAK)
    '        ControlesTP.SetToolTip(ArchivosLB, My.Resources.ArchivoIdioma.TTArchivosBAKR)
    '        ControlesTP.SetToolTip(ContraseñaZipTxt, My.Resources.ArchivoIdioma.TTContraseñaZip)
    '        ControlesTP.SetToolTip(ReContraseñaZipTxt, My.Resources.ArchivoIdioma.TTReContraseñaZip)
    '        ControlesTP.SetToolTip(NuevoBtn, My.Resources.ArchivoIdioma.NuevoRestoreLimpiar)
    '        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTGenerarRestore)
    '        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    '    End Sub

    '#End Region

    '    Private Sub NuevoBtn_Click(sender As System.Object, e As System.EventArgs) Handles NuevoBtn.Click
    '        ListaArchivos.Clear()
    '        ArchivosLB.DataSource = Nothing
    '        ContraseñaZipTxt.ReadOnly = False
    '        ReContraseñaZipTxt.ReadOnly = False
    '        ContraseñaZipTxt.Clear()
    '        ReContraseñaZipTxt.Clear()
    '        BuscarBtn.Enabled = True
    '        ContraseñaZipTxt.Focus()
    '    End Sub

    '    Private Sub ContraseñaZipTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ContraseñaZipTxt.TextChanged
    '        ErrorP.SetError(ContraseñaZipTxt, "")
    '    End Sub

    '    Private Sub ReContraseñaZipTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ReContraseñaZipTxt.TextChanged
    '        ErrorP.SetError(ReContraseñaZipTxt, "")
    '    End Sub
End Class