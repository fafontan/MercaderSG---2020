Imports Entidades
Imports Servicios
Imports Negocios
Imports Excepciones
Imports System.IO

Public Class DesbloquearUsuario

    Private Sub DesbloquearUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()

        Dim ListaUsuario As New List(Of UsuarioEN)

        For Each item As UsuarioEN In UsuarioRN.CargarUsuario()
            Dim UnUsuario As New UsuarioEN
            If item.Bloqueado = True Then
                UnUsuario.CodUsu = item.CodUsu
                UnUsuario.Usuario = item.Usuario

                ListaUsuario.Add(UnUsuario)
            End If
        Next

        UsuarioCMB.DataSource = ListaUsuario
        UsuarioCMB.DisplayMember = "Usuario"
        UsuarioCMB.ValueMember = "CodUsu"
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        Try
            UsuarioRN.DesbloquearUsuario((UsuarioCMB.SelectedItem).Usuario)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End Try
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub DesbloquearUsuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.DesbloquearUsuarioSMI.Enabled = True
    End Sub

    Private Sub DesbloquearUsuario_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "107")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.DesbloquearUsuarioFrm

        UsuarioGB.Text = My.Resources.ArchivoIdioma.SeleccionarUsuarioGB
        UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(UsuarioCMB, My.Resources.ArchivoIdioma.TTListaUsuBloqueados)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarDesbloquearUsu)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region


End Class