Imports Servicios
Imports Entidades
Imports Negocios
Imports Excepciones
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class AltaUsuario
    Private ListaTelefonos As New List(Of TelefonoEN)
    Private UsuAut As Autenticar = Autenticar.Instancia()
    Public PuedeModificar As Boolean = False

    Private Sub AltaUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()
        CargarFoco(DatosGB)
        CargarFoco(TelefonosGB)
        CargarFoco(UsuarioGB)

        FechaNacDTP.MaxDate = DateTime.Today
        FechaNacDTP.Value = DateTime.Today

        UsuarioTxt.Focus()
        IdiomaCMB.DataSource = Idioma.ListarIdiomas()
        IdiomaCMB.DisplayMember = "Descripcion"
        IdiomaCMB.ValueMember = "CodIdioma"
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim UsuarioNuevo As New UsuarioEN

        UsuarioNuevo.Usuario = UsuarioTxt.Text
        UsuarioNuevo.CorreoElectronico = CorreoElectronicoTxt.Text
        UsuarioNuevo.CodIdioma = IdiomaCMB.SelectedValue
        UsuarioNuevo.Apellido = ApellidoTxt.Text
        UsuarioNuevo.Nombre = NombreTxt.Text
        UsuarioNuevo.FechaNacimiento = FechaNacDTP.Value

        UsuarioNuevo.Telefono = ListaTelefonos

        Dim Sfd As New SaveFileDialog()
        Sfd.Filter = My.Resources.ArchivoIdioma.SDFArchivoTexto
        Sfd.FileName = My.Resources.ArchivoIdioma.FileNameTxtUsu & UsuarioTxt.Text

        If Sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim FS As New FileStream(Sfd.FileName, FileMode.Create)
            Dim SW As New StreamWriter(FS)

            Dim Caracteres As String = "qwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM1234567890~!@#$%^&*()_-+={}[]\|:;<>,.?/"
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

            UsuarioNuevo.Contraseña = SB.ToString()
        Else
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeGernerarContraseña, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            UsuarioRN.AltaUsuario(UsuarioNuevo)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            If ex.Message = My.Resources.ArchivoIdioma.UsuarioExistente Then

                If PuedeModificar = True And Not UsuAut.UsuarioLogueado = UsuarioTxt.Text Then
                    Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.ModificarUsuario & UsuarioTxt.Text & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxModificarUsuario, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                    If Resultado = Windows.Forms.DialogResult.OK Then
                        Dim frm As New ModificarUsuario
                        frm.UsuarioSel = UsuarioTxt.Text
                        Me.Dispose()
                        frm.ShowDialog()
                    Else
                        Me.Close()
                    End If
                End If

            End If

        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub AgregarTelBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarTelBtn.Click
        Dim Valor As Boolean = True

        If String.IsNullOrEmpty(TelefonoTxt.Text) Then
            ErrorP.SetError(TelefonoTxt, My.Resources.ArchivoIdioma.IngreseNumero)
            Valor = False
        Else
            ErrorP.SetError(TelefonoTxt, "")
        End If

        Select Case TelefonoTxt.Text.Length
            Case Is > 25
                ErrorP.SetError(TelefonoTxt, My.Resources.ArchivoIdioma.Contener25Num)
                Valor = False
            Case 1 To 25
                ErrorP.SetError(TelefonoTxt, "")
        End Select

        If TelefonosDG.Rows.Count = 5 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.CincoTelMax, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Valor = False
        End If

        If Not Valor Then
            Exit Sub
        Else
            TelefonoTxt.Focus()
        End If

        Dim UnTelefono As New TelefonoEN
        UnTelefono.Numero = TelefonoTxt.Text

        ListaTelefonos.Add(UnTelefono)

        TelefonosDG.DataSource = Nothing
        TelefonosDG.DataSource = ListaTelefonos

        TelefonoTxt.Clear()
        TelefonosDG.Columns(0).Visible = False
        TelefonosDG.Columns(1).Visible = False
        TelefonosDG.Columns(2).Visible = False
    End Sub

    Private Sub QuitarTelBtn_Click(sender As System.Object, e As System.EventArgs) Handles QuitarTelBtn.Click
        If TelefonosDG.Rows.Count = 0 Then
            ErrorP.SetError(TelefonosDG, My.Resources.ArchivoIdioma.NoTelefonoDG)
            Exit Sub
        End If


        If TelefonosDG.CurrentRow Is Nothing Then
            ErrorP.SetError(TelefonosDG, My.Resources.ArchivoIdioma.NoTelSeleccionado)
        Else
            ListaTelefonos.RemoveAt(TelefonosDG.CurrentRow.Index)
            TelefonosDG.DataSource = Nothing
            TelefonosDG.DataSource = ListaTelefonos

            TelefonosDG.Columns(0).Visible = False
            TelefonosDG.Columns(1).Visible = False
            TelefonosDG.Columns(2).Visible = False
        End If

    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

#Region "Validaciones"

    Public Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        ErrorP.SetError(TelefonoTxt, "")

        If TelefonosDG.Rows.Count < 3 Then
            ErrorP.SetError(TelefonosDG, My.Resources.ArchivoIdioma.AgregarMin3Tel)
            Resultado = False
        End If

        'Usuario

        If String.IsNullOrEmpty(UsuarioTxt.Text) Then
            ErrorP.SetError(UsuarioTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            UsuarioTxt.Focus()
            Resultado = False
        End If

        Select Case UsuarioTxt.Text.Length
            Case 1 To 5
                ErrorP.SetError(UsuarioTxt, My.Resources.ArchivoIdioma.ContenerMenos6Carac)
                UsuarioTxt.Focus()
                Resultado = False
            Case 6 To 20
                ErrorP.SetError(UsuarioTxt, "")
            Case Is > 20
                ErrorP.SetError(UsuarioTxt, My.Resources.ArchivoIdioma.Contener20Carac)
                UsuarioTxt.Focus()
                Resultado = False
        End Select

        'Correo
        If String.IsNullOrEmpty(CorreoElectronicoTxt.Text) Then
            ErrorP.SetError(CorreoElectronicoTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        End If

        Select Case CorreoElectronicoTxt.Text.Length
            Case Is > 50
                ErrorP.SetError(CorreoElectronicoTxt, My.Resources.ArchivoIdioma.Contener50Carac)
                Resultado = False
            Case 1 To 50
                Dim Email As New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")

                If Not Email.IsMatch(CorreoElectronicoTxt.Text) Then
                    ErrorP.SetError(CorreoElectronicoTxt, My.Resources.ArchivoIdioma.FormatoCorreo)
                    Resultado = False
                End If
        End Select

        'Apellido
        If String.IsNullOrEmpty(ApellidoTxt.Text) Then
            ErrorP.SetError(ApellidoTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(ApellidoTxt, "")
        End If

        Select Case ApellidoTxt.Text.Length
            Case Is > 50
                ErrorP.SetError(ApellidoTxt, My.Resources.ArchivoIdioma.Contener50Carac)
                Resultado = False
            Case 1 To 50
                ErrorP.SetError(ApellidoTxt, "")
        End Select

        'Nombre
        If String.IsNullOrEmpty(NombreTxt.Text) Then
            ErrorP.SetError(NombreTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(NombreTxt, "")
        End If

        Select Case NombreTxt.Text.Length
            Case Is > 50
                ErrorP.SetError(NombreTxt, My.Resources.ArchivoIdioma.Contener50Carac)
                Resultado = False
            Case 1 To 50
                ErrorP.SetError(NombreTxt, "")
        End Select

        Return Resultado
    End Function

    Private Sub UsuarioTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles UsuarioTxt.KeyPress
        Dim CaracterPermitido As String = "1234567890qwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM_-." & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub UsuarioTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles UsuarioTxt.TextChanged
        ErrorP.SetError(UsuarioTxt, "")
    End Sub

    Private Sub ApellidoTxt_Validated(sender As System.Object, e As System.EventArgs) Handles ApellidoTxt.Validated
        ApellidoTxt.Text = UCase(Mid(ApellidoTxt.Text, 1, 1)) & LCase(Mid(ApellidoTxt.Text, 2))
    End Sub

    Private Sub NombreTxt_Validated(sender As System.Object, e As System.EventArgs) Handles NombreTxt.Validated
        NombreTxt.Text = UCase(Mid(NombreTxt.Text, 1, 1)) & LCase(Mid(NombreTxt.Text, 2))
    End Sub

    Private Sub UsuarioTxt_Validated(sender As System.Object, e As System.EventArgs) Handles UsuarioTxt.Validated
        UsuarioTxt.Text = UCase(Mid(UsuarioTxt.Text, 1, 1)) & LCase(Mid(UsuarioTxt.Text, 2))
    End Sub

    Private Sub TelefonoTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TelefonoTxt.KeyPress
        Dim CaracterPermitido As String = "1234567890()- " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ApellidoYNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ApellidoTxt.KeyPress, NombreTxt.KeyPress
        Dim CaracterPermitido As String = "QWERTYUIOPASDFGHJKLÑZXCVBNMÁÉÍÚÓáéíóúqwertyuiopasdfghjklñzxcvbnm " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ContraseñaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CorreoElectronicoTxt.TextChanged
        ErrorP.SetError(CorreoElectronicoTxt, "")
    End Sub

    Private Sub ApellidoTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ApellidoTxt.TextChanged
        ErrorP.SetError(ApellidoTxt, "")
    End Sub

    Private Sub NombreTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles NombreTxt.TextChanged
        ErrorP.SetError(NombreTxt, "")
    End Sub

    Private Sub TelefonoTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles TelefonoTxt.TextChanged
        ErrorP.SetError(TelefonoTxt, "")
    End Sub

    Private Sub AltaUsuario_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "104")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TelefonosDG_Click(sender As System.Object, e As System.EventArgs) Handles TelefonosDG.Click
        ErrorP.SetError(TelefonosDG, "")
    End Sub

#End Region

#Region "Idioma y Mejoras"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.AltaUsuarioForm

        UsuarioGB.Text = My.Resources.ArchivoIdioma.UsuarioLbl
        UsuarioLbl.Text = My.Resources.ArchivoIdioma.NombreUsuarioLbl
        CorreoElectronicoLbl.Text = My.Resources.ArchivoIdioma.CorreoElectronicoGral
        IdiomaLbl.Text = My.Resources.ArchivoIdioma.IdiomaPfrm

        DatosGB.Text = My.Resources.ArchivoIdioma.DatosPersonales
        ApellidoLbl.Text = My.Resources.ArchivoIdioma.CMBApellido
        NombreLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
        FechaNacLbl.Text = My.Resources.ArchivoIdioma.FechaNacimientoLbl

        TelefonosGB.Text = My.Resources.ArchivoIdioma.TelefonosGB
        NumeroLbl.Text = My.Resources.ArchivoIdioma.NumeroTelLbl
        NumeroCAB.HeaderText = My.Resources.ArchivoIdioma.NumeroTelLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(UsuarioTxt, My.Resources.ArchivoIdioma.TTUsuarioText)
        ControlesTP.SetToolTip(CorreoElectronicoTxt, My.Resources.ArchivoIdioma.TTCorreoElectronicoUsu)
        ControlesTP.SetToolTip(ApellidoTxt, My.Resources.ArchivoIdioma.TTApellidoUsu)
        ControlesTP.SetToolTip(IdiomaCMB, My.Resources.ArchivoIdioma.TTIdiomas)
        ControlesTP.SetToolTip(NombreTxt, My.Resources.ArchivoIdioma.TTNombreUsu)
        ControlesTP.SetToolTip(FechaNacDTP, My.Resources.ArchivoIdioma.TTNacimientoUsu)
        ControlesTP.SetToolTip(TelefonoTxt, My.Resources.ArchivoIdioma.TTTelelonoUsu)
        ControlesTP.SetToolTip(AgregarTelBtn, My.Resources.ArchivoIdioma.TTAgregarTel)
        ControlesTP.SetToolTip(QuitarTelBtn, My.Resources.ArchivoIdioma.TTQuitarTel)
        ControlesTP.SetToolTip(TelefonosDG, My.Resources.ArchivoIdioma.TTListaTel)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarAltaUsu)
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

#End Region

End Class