Imports Negocios
Imports Entidades
Imports Servicios
Imports Excepciones
Imports System.Threading
Imports System.Text
Imports System.IO

Public Class LogIn

    Public ListaErrorInt As New List(Of ErrorIntegridadEN)
    Public DtErrorIntegridad As DataTable
    Public DtErrorIntegridadDVV As DataTable
    Private EstadoLog As Boolean = False

    Private Sub LogIn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Resources.ArchivoIdioma.IniciarSesionForm
        UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
        ContraseñaLbl.Text = My.Resources.ArchivoIdioma.ContrasenaLbl
        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

        CargarFoco()
        CargarTT()

        UsuarioTxt.Focus()
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Try
            Dim ListaUsuariosPatentes As New List(Of String)

            Dim Usuario As New UsuarioEN
            Usuario.Usuario = UsuarioTxt.Text
            Usuario.Contraseña = ContraseñaTxt.Text

            If UsuarioRN.Logueo(Usuario) = True Then
                Dim IdiomaUsuario As Integer = Idioma.DetectarIdioma(Usuario.CodUsu)
                Dim DescripcionIdioma As String

                If IdiomaUsuario = 1 Then
                    DescripcionIdioma = "es-AR"
                    Principal.EspanolSMI.Enabled = False
                    Principal.InglesSMI.Enabled = True
                Else
                    DescripcionIdioma = "en-US"
                    Principal.EspanolSMI.Enabled = True
                    Principal.InglesSMI.Enabled = False
                End If

                Idioma.AplicarIdioma(DescripcionIdioma)

                Dim UsuAut As Autenticar = Autenticar.Instancia()
                UsuAut.dtPatUsu = PatenteRN.ObtenerPatenteUsuario(Usuario.CodUsu)

                Principal.ListaErrorInt = ListaErrorInt
                Principal.DtErrorIntegridad = DtErrorIntegridad
                Principal.DtErrorIntegridadDVV = DtErrorIntegridadDVV

                Principal.Show()
                EstadoLog = True
                Me.Close()
            Else
                MessageBox.Show(My.Resources.ArchivoIdioma.ContraseñaIncorrecta, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ContraseñaTxt.Clear()
                ContraseñaTxt.Focus()
            End If

        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As CriticalException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            UsuarioTxt.Clear()
            ContraseñaTxt.Clear()
            UsuarioTxt.Focus()
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            If ex.Message = My.Resources.ArchivoIdioma.UsuarioRevision Then
                Dim Usuario As New UsuarioEN
                Usuario.Usuario = UsuarioTxt.Text

                Dim Sfd As New SaveFileDialog()
                Sfd.Filter = My.Resources.ArchivoIdioma.SDFArchivoTexto
                Sfd.FileName = My.Resources.ArchivoIdioma.FileNameTxtUsu & UsuarioTxt.Text

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

                    SW.WriteLine(My.Resources.ArchivoIdioma.TxtUsuario & UsuarioTxt.Text)
                    SW.WriteLine(My.Resources.ArchivoIdioma.TxtContraseña & SB.ToString())
                    SW.Close()
                    FS.Close()

                    Usuario.Contraseña = SB.ToString()
                    Usuario.TipoAccion = True
                Else
                    MessageBox.Show(My.Resources.ArchivoIdioma.DebeGernerarContraseña, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Try
                    UsuarioRN.ResetearContraseña(Usuario)
                Catch ex1 As InformationException
                    MessageBox.Show(ex1.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex1 As WarningException
                    MessageBox.Show(ex1.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If

            ContraseñaTxt.Clear()
            ContraseñaTxt.Focus()
        End Try
    End Sub

#Region "Validacion"

    Private Sub UsuarioTxt_Validated(sender As System.Object, e As System.EventArgs) Handles UsuarioTxt.Validated
        UsuarioTxt.Text = UCase(Mid(UsuarioTxt.Text, 1, 1)) & LCase(Mid(UsuarioTxt.Text, 2))
    End Sub

    Public Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(UsuarioTxt.Text) And String.IsNullOrEmpty(ContraseñaTxt.Text) Then
            MessageBox.Show(My.Resources.ArchivoIdioma.UsuConObligatorios, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UsuarioTxt.Focus()
            Resultado = False

            Return Resultado
        End If

        If String.IsNullOrEmpty(UsuarioTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.CampoObligatorio, UsuarioTxt)
            UsuarioTxt.Focus()
            Resultado = False

            Return Resultado
        End If

        Select Case UsuarioTxt.Text.Length
            Case 1 To 5
                MensajeTT.Show(My.Resources.ArchivoIdioma.ContenerMenos6Carac, UsuarioTxt)
                UsuarioTxt.Focus()
                Resultado = False

                Return Resultado

            Case 6 To 20
                MensajeTT.Hide(UsuarioTxt)

            Case Is > 20
                MensajeTT.Show(My.Resources.ArchivoIdioma.Contener20Carac, UsuarioTxt)
                UsuarioTxt.Focus()
                Resultado = False

                Return Resultado
        End Select

        If String.IsNullOrEmpty(ContraseñaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.CampoObligatorio, ContraseñaTxt)
            ContraseñaTxt.Focus()
            Resultado = False

            Return Resultado
        End If

        Select Case ContraseñaTxt.Text.Length
            Case 1 To 7
                MensajeTT.Show(My.Resources.ArchivoIdioma.ContenerMenos8Carac, ContraseñaTxt)
                ContraseñaTxt.Focus()
                Resultado = False

                Return Resultado

            Case 8 To 12
                MensajeTT.Hide(ContraseñaTxt)

            Case Is > 12
                MensajeTT.Show(My.Resources.ArchivoIdioma.Contener12Carac, ContraseñaTxt)
                ContraseñaTxt.Focus()
                Resultado = False

                Return Resultado
        End Select

        Return Resultado
    End Function

    Private Sub UsuarioTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles UsuarioTxt.TextChanged
        MensajeTT.Hide(UsuarioTxt)
    End Sub

    Private Sub UsuarioTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles UsuarioTxt.KeyPress
        Dim CaracterPermitido As String = "1234567890qwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM_-." & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ContraseñaTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ContraseñaTxt.KeyPress
        Dim CaracteresPermitidos As String = "qwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM1234567890~!@#$%^&*()_-+={}[]\|:;<>,.?/" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ContraseñaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ContraseñaTxt.TextChanged
        MensajeTT.Hide(ContraseñaTxt)
    End Sub
#End Region


#Region "Diseño"

    Private Sub CargarTT()
        ControlesTP.SetToolTip(UsuarioTxt, My.Resources.ArchivoIdioma.TTUsuarioLoginTxt)
        ControlesTP.SetToolTip(ContraseñaTxt, My.Resources.ArchivoIdioma.TTContrasenaLoginTxt)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarLogin)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

    Private Sub TieneFoco(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MiTextBox As TextBox = DirectCast(sender, TextBox)
        MiTextBox.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub PierdeFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim MiTextBox As TextBox = DirectCast(sender, TextBox)
        MiTextBox.BackColor = Color.White
    End Sub

    Public Sub CargarFoco()
        Dim Ctrl As Control
        For Each Ctrl In Me.Controls
            If TypeOf Ctrl Is System.Windows.Forms.TextBox Then
                Dim MiTextBox As TextBox = DirectCast(Ctrl, TextBox)
                If MiTextBox.ReadOnly = False Then
                    AddHandler MiTextBox.GotFocus, AddressOf TieneFoco
                    AddHandler MiTextBox.LostFocus, AddressOf PierdeFoco
                End If
            End If
        Next
    End Sub

#End Region
    Private Sub LogIn_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub LogIn_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If EstadoLog = False Then
            Application.Exit()
        End If
    End Sub
End Class