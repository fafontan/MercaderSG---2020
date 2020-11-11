Imports Servicios
Imports Negocios
Imports Entidades
Imports Excepciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class ModificarUsuario
    Private CodigoUsuario As Integer
    Public UsuarioSel As String

    Private Sub ModificarUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
        CargarFoco(UsuarioGB)
        CargarFoco(DatosPersonalesGB)

        FechaNacDTP.MaxDate = DateTime.Today
        UsuarioSel = Seguridad.Encriptar(UsuarioSel)

        IdiomaCMB.DataSource = Idioma.ListarIdiomas()
        IdiomaCMB.DisplayMember = "Descripcion"
        IdiomaCMB.ValueMember = "CodIdioma"

        Try
            Dim Usuario As UsuarioEN = UsuarioRN.ObtenerUsuario(UsuarioSel)
            UsuarioTxt.Text = Usuario.Usuario
            ApellidoTxt.Text = Usuario.Apellido
            NombreTxt.Text = Usuario.Nombre
            IdiomaCMB.SelectedValue = Usuario.CodIdioma
            CorreoElectronicoTxt.Text = Usuario.CorreoElectronico
            FechaNacDTP.Value = Usuario.FechaNacimiento

            CodigoUsuario = Usuario.CodUsu

            TelefonosDG.AutoGenerateColumns = False
            TelefonosDG.DataSource = UsuarioRN.ObtenerTelefonoUsuario(CodigoUsuario)

            TelefonosDG.Columns(0).ReadOnly = True
            TelefonosDG.Columns(1).ReadOnly = True
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Dispose()
        End Try

    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim ListaTelefono As New List(Of TelefonoEN)

        For Each fila As DataGridViewRow In TelefonosDG.Rows
            Dim UnTelefono As New TelefonoEN
            UnTelefono.CodTel = fila.Cells(0).Value
            UnTelefono.CodEn = fila.Cells(1).Value
            UnTelefono.Numero = fila.Cells(2).Value

            ListaTelefono.Add(UnTelefono)
        Next

        Dim UsuarioModificar As String = UsuarioTxt.Text

        Dim UnUsuario As New UsuarioEN
        UnUsuario.CodUsu = CodigoUsuario
        UnUsuario.Usuario = UsuarioModificar
        UnUsuario.Apellido = ApellidoTxt.Text
        UnUsuario.Nombre = NombreTxt.Text
        UnUsuario.CodIdioma = IdiomaCMB.SelectedValue
        UnUsuario.FechaNacimiento = FechaNacDTP.Value
        UnUsuario.Telefono = ListaTelefono
        Try
            UsuarioRN.ModificarUsuario(UnUsuario)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End Try
    End Sub

#Region "Validaciones e Idioma"

    Public Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If TelefonosDG.Rows.Count < 3 Then
            ErrorP.SetError(TelefonosDG, My.Resources.ArchivoIdioma.AgregarMin3Tel)
            Resultado = False
        Else
            ErrorP.SetError(TelefonosDG, "")
        End If

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

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub


    Private Sub ApellidoTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ApellidoTxt.TextChanged
        ErrorP.SetError(ApellidoTxt, "")
    End Sub

    Private Sub NombreTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles NombreTxt.TextChanged
        ErrorP.SetError(NombreTxt, "")
    End Sub

    Private Sub ApellidoyNombreTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ApellidoTxt.KeyPress, NombreTxt.KeyPress
        Dim CaracterPermitido As String = "QWERTYUIOPASDFGHJKLÑZXCVBNMÁÉÍÚÓáéíóúqwertyuiopasdfghjklñzxcvbnm " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ApellidoTxt_Validated(sender As System.Object, e As System.EventArgs) Handles ApellidoTxt.Validated
        ApellidoTxt.Text = UCase(Mid(ApellidoTxt.Text, 1, 1)) & LCase(Mid(ApellidoTxt.Text, 2))
    End Sub

    Private Sub NombreTxt_Validated(sender As System.Object, e As System.EventArgs) Handles NombreTxt.Validated
        NombreTxt.Text = UCase(Mid(NombreTxt.Text, 1, 1)) & LCase(Mid(NombreTxt.Text, 2))
    End Sub

    Private Sub ModificarUsuario_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "127")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TelefonosDG_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles TelefonosDG.EditingControlShowing
        Dim Celda As TextBox = CType(e.Control, TextBox)
        AddHandler Celda.KeyPress, AddressOf Celda_Keypress
    End Sub

    Private Sub Celda_Keypress(sender As Object, e As KeyPressEventArgs)
        Dim CaracterPermitido As String = "1234567890()- " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

#End Region

#Region "Idioma y Mejoras"


    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.ModificarUsuarioForm

        UsuarioGB.Text = My.Resources.ArchivoIdioma.UsuarioLbl
        UsuarioLbl.Text = My.Resources.ArchivoIdioma.NombreUsuarioLbl
        CorreoElectronicoLbl.Text = My.Resources.ArchivoIdioma.CorreoElectronicoGral
        IdiomaLbl.Text = My.Resources.ArchivoIdioma.IdiomaPfrm

        DatosPersonalesGB.Text = My.Resources.ArchivoIdioma.DatosPersonales
        ApellidoLbl.Text = My.Resources.ArchivoIdioma.CMBApellido
        NombreLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
        FechaNacLbl.Text = My.Resources.ArchivoIdioma.FechaNacimientoLbl

        TelefonosGB.Text = My.Resources.ArchivoIdioma.TelefonosGB
        TelefonoCAB.HeaderText = My.Resources.ArchivoIdioma.DGModificarUsuarioTelCAB
        NumeroCAB.HeaderText = My.Resources.ArchivoIdioma.DGModificarUsuarioNumeroCAB

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
        ControlesTP.SetToolTip(TelefonosDG, My.Resources.ArchivoIdioma.TTListaTel)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTModificarUsuBtn)
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