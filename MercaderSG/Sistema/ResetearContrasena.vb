Imports Entidades
Imports Servicios
Imports Negocios
Imports Excepciones
Imports System.IO
Imports System.Text

Public Class ResetearContrasena

    Private Sub ResetearContrasena_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()

        UsuarioCMB.DataSource = UsuarioRN.CargarUsuario()
        UsuarioCMB.DisplayMember = "Usuario"
        UsuarioCMB.ValueMember = "CodUsu"
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        Dim Usuario As New UsuarioEN
        Usuario.Usuario = (UsuarioCMB.SelectedItem).Usuario
        Usuario.CodUsu = UsuarioCMB.SelectedValue

        Dim Sfd As New SaveFileDialog()
        Sfd.Filter = My.Resources.ArchivoIdioma.SDFArchivoTexto
        Sfd.FileName = My.Resources.ArchivoIdioma.FileNameTxtUsu & (UsuarioCMB.SelectedItem).Usuario

        If Sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim FS As New FileStream(Sfd.FileName, FileMode.Create)
            Dim SW As New StreamWriter(FS)

            Dim Caracteres As String = "1234567890qwertyuiopaslñzxcvbnmQWERTYPÑLKJHGFDSXCVBNM_-.[]{};_:^¨*\|!·$%&/()=?¿@#~€"
            Dim Rnd As New Random
            Dim SB As New StringBuilder
            Dim CH As Char

            For i As Integer = 1 To 10
                CH = Caracteres(Rnd.Next(0, Caracteres.Length))
                SB.Append(CH)
            Next

            SW.WriteLine(My.Resources.ArchivoIdioma.TxtUsuario & (UsuarioCMB.SelectedItem).Usuario)
            SW.WriteLine(My.Resources.ArchivoIdioma.TxtContraseña & SB.ToString())
            SW.Close()
            FS.Close()

            Usuario.Contraseña = SB.ToString()
            Usuario.TipoAccion = False
        Else
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeGernerarContraseña, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            UsuarioRN.ResetearContraseña(Usuario)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ResetearContrasena_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.ResetearContrasenaSMI.Enabled = True
    End Sub

    Private Sub ResetearContrasena_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "132")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.ResetearContraseñaFrm

        UsuarioGB.Text = My.Resources.ArchivoIdioma.SeleccionarUsuarioGB
        UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(UsuarioCMB, My.Resources.ArchivoIdioma.TTListaUsuarios)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarResetearContraseña)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub
End Class