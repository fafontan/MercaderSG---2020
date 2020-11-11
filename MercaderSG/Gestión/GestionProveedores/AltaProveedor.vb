Imports Servicios
Imports Entidades
Imports Negocios
Imports Excepciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class AltaProveedor
    Dim ListaTelefonos As New List(Of TelefonoEN)
    Public PuedeModificar As Boolean = False

    Private Sub AltaProveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()
        CargarFoco(DatosGB)
        CargarFoco(TelefonosGB)
        CargarFoco(DomicilioGB)

        LocalidadCMB.DataSource = LocalidadRN.CargarLocalidad()
        LocalidadCMB.DisplayMember = "Descripcion"
        LocalidadCMB.ValueMember = "CodLoc"
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
            MensajeTT.Show(My.Resources.ArchivoIdioma.CincoTelMax, AgregarTelBtn)
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
            TelefonoTxt.Focus()

            ListaTelefonos.RemoveAt(TelefonosDG.CurrentRow.Index)
            TelefonosDG.DataSource = Nothing
            TelefonosDG.DataSource = ListaTelefonos

            TelefonosDG.Columns(0).Visible = False
            TelefonosDG.Columns(1).Visible = False
            TelefonosDG.Columns(2).Visible = False
        End If
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim ProveedorNuevo As New ProveedorEN

        ProveedorNuevo.RazonSocial = RazonSocialTxt.Text
        ProveedorNuevo.Cuit = CuitTxt.Text
        ProveedorNuevo.CorreoElectronico = CorreoElectronicoTxt.Text
        ProveedorNuevo.CodLoc = LocalidadCMB.SelectedValue
        ProveedorNuevo.Calle = CalleTxt.Text
        ProveedorNuevo.Numero = NumeroTxt.Text
        ProveedorNuevo.Piso = PisoTxt.Text
        ProveedorNuevo.Departamento = DepartamentoTxt.Text

        ProveedorNuevo.Telefono = ListaTelefonos

        Try
            ProveedorRN.AltaProveedor(ProveedorNuevo)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            If ex.Message = My.Resources.ArchivoIdioma.ProveedorExistente Then
                If PuedeModificar = True Then
                    Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.ModificarProveedor & CuitTxt.Text & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxModificarProveedor, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                    If Resultado = Windows.Forms.DialogResult.OK Then
                        Dim frm As New ModificarProveedor
                        frm.CuitSel = CuitTxt.Text
                        Me.Dispose()
                        frm.ShowDialog()
                    Else
                        Me.Close()
                    End If
                End If
            End If
        End Try

    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub AgregarLocBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarLocBtn.Click
        Dim frm As New AltaLocalidad
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LocalidadCMB.DataSource = LocalidadRN.CargarLocalidad()
            ErrorP.SetError(AgregarLocBtn, "")
        End If
    End Sub

#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        ErrorP.SetError(TelefonoTxt, "")

        If TelefonosDG.Rows.Count < 3 Then
            ErrorP.SetError(TelefonosDG, My.Resources.ArchivoIdioma.AgregarMin3Tel)
            Resultado = False
        Else
            ErrorP.SetError(TelefonosDG, "")
        End If

        'RS
        If String.IsNullOrEmpty(RazonSocialTxt.Text) Then
            ErrorP.SetError(RazonSocialTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(RazonSocialTxt, "")
        End If

        Select Case RazonSocialTxt.Text.Length
            Case Is > 50
                ErrorP.SetError(RazonSocialTxt, My.Resources.ArchivoIdioma.Contener50Carac)
                Resultado = False
            Case 1 To 50
                ErrorP.SetError(RazonSocialTxt, "")
        End Select

        'Cuit

        If String.IsNullOrEmpty(CuitTxt.Text) Then
            ErrorP.SetError(CuitTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(CuitTxt, "")
        End If

        Select Case CuitTxt.Text.Length
            Case Is > 13
                ErrorP.SetError(CuitTxt, My.Resources.ArchivoIdioma.Contener13Carac)
                Resultado = False
            Case 1 To 13
                Dim Cuit As New Regex("(30|33)[-]([0-9]{8})[-]([0-9]{1})")

                If Not Cuit.IsMatch(CuitTxt.Text) Then
                    ErrorP.SetError(CuitTxt, My.Resources.ArchivoIdioma.FormatoCUIT)
                    Resultado = False
                Else
                    If Not ValidarCuit(CuitTxt.Text) Then
                        ErrorP.SetError(CuitTxt, My.Resources.ArchivoIdioma.ValorCUIT)
                        Resultado = False
                    End If
                End If
            Case Is = 13
                Dim Cuit As New Regex("(30|33)[-]([0-9]{8})[-]([0-9]{1})")

                If Not Cuit.IsMatch(CuitTxt.Text) Then
                    ErrorP.SetError(CuitTxt, My.Resources.ArchivoIdioma.FormatoCUIT)
                    Resultado = False
                Else
                    If Not ValidarCuit(CuitTxt.Text) Then
                        ErrorP.SetError(CuitTxt, My.Resources.ArchivoIdioma.ValorCUIT)
                        Resultado = False
                    End If
                End If
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

        'Localidad
        If LocalidadCMB.SelectedItem Is Nothing Then
            ErrorP.SetError(AgregarLocBtn, My.Resources.ArchivoIdioma.DebeAgregarLocalidad)
            Resultado = False
        End If

        'Calle
        If String.IsNullOrEmpty(CalleTxt.Text) Then
            ErrorP.SetError(CalleTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(CalleTxt, "")
        End If

        Select Case CalleTxt.Text.Length
            Case Is > 50
                ErrorP.SetError(CalleTxt, My.Resources.ArchivoIdioma.Contener50Carac)
                Resultado = False
            Case 1 To 50
                ErrorP.SetError(CalleTxt, "")
        End Select

        'Num
        If String.IsNullOrEmpty(NumeroTxt.Text) Then
            ErrorP.SetError(NumeroTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        ElseIf NumeroTxt.Text.Length > 10 Then
            ErrorP.SetError(NumeroTxt, My.Resources.ArchivoIdioma.Contener10Carac)
            Resultado = False
        End If

        'Piso
        If PisoTxt.Text.Length > 10 Then
            ErrorP.SetError(PisoTxt, My.Resources.ArchivoIdioma.Contener10Carac)
            Resultado = False
        End If

        'dpto
        If DepartamentoTxt.Text.Length > 5 Then
            ErrorP.SetError(DepartamentoTxt, My.Resources.ArchivoIdioma.Contener5Carac)
            Resultado = False
        End If

        Return Resultado
    End Function

    Private Function ValidarCuit(Cuit As String) As Boolean
        Dim CadenaEntrante As String = Cuit

        Dim Cadena As String = Cuit
        Cadena = Regex.Replace(Cadena, "[-]", "")

        Dim Sumatoria As Integer = 0
        Dim e As Integer = 6

        For i As Integer = 0 To Cadena.Length - 1
            e -= 1
            If e = 1 Then
                e = 7
            End If

            If IsNumeric(Cadena(i)) Then
                Sumatoria += (CInt(Val(Cadena(i))) * e)
            Else
                Sumatoria += (Asc(Cadena(i)) * e)
            End If
        Next

        Dim M11 As Double
        M11 = Sumatoria / 11
        Dim M11Entero As Integer = Int(M11)

        Dim ResultadoM11 As Integer

        ResultadoM11 = M11Entero * 11

        Dim Resto As Integer = Sumatoria - ResultadoM11

        If Resto = 11 Then
            Resto = 0
        End If

        If Resto = 10 Then
            Resto = 9
        End If

        Dim UltimoNumero As Integer = Convert.ToInt32(Cuit.Substring(Cuit.Length - 1, 1))

        If Resto = UltimoNumero Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub RazonSocialTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles RazonSocialTxt.TextChanged
        ErrorP.SetError(RazonSocialTxt, "")
    End Sub

    Private Sub CuitTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CuitTxt.TextChanged
        ErrorP.SetError(CuitTxt, "")
    End Sub

    Private Sub CorreoElectronicoTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CorreoElectronicoTxt.TextChanged
        ErrorP.SetError(CorreoElectronicoTxt, "")
    End Sub

    Private Sub TelefonoTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles TelefonoTxt.TextChanged
        ErrorP.SetError(TelefonosDG, "")
    End Sub

    Private Sub CalleTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CalleTxt.TextChanged
        ErrorP.SetError(CalleTxt, "")
    End Sub

    Private Sub NumeroTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles NumeroTxt.TextChanged
        ErrorP.SetError(NumeroTxt, "")
    End Sub

    Private Sub PisoTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles PisoTxt.TextChanged
        ErrorP.SetError(PisoTxt, "")
    End Sub

    Private Sub DepartamentoTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles DepartamentoTxt.TextChanged
        ErrorP.SetError(DepartamentoTxt, "")
    End Sub

    Private Sub RazonSocialTxtCalleTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles RazonSocialTxt.KeyPress, CalleTxt.KeyPress
        Dim CaracterPermitido As String = "áéúíóÁÉÍÓÚQWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890.- " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TelefonoTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TelefonoTxt.KeyPress
        Dim CaracterPermitido As String = "1234567890()- " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CuitTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CuitTxt.KeyPress
        Dim CaracteresPermitidos As String = "1234567890-" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumeroYPisoTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles NumeroTxt.KeyPress, PisoTxt.KeyPress
        Dim CaracteresPermitidos As String = "1234567890" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DepartamentoTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DepartamentoTxt.KeyPress
        Dim CaracterPermitido As String = "QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub RazonSocialTxt_Validated(sender As System.Object, e As System.EventArgs) Handles RazonSocialTxt.Validated
        RazonSocialTxt.Text = UCase(Mid(RazonSocialTxt.Text, 1, 1)) & LCase(Mid(RazonSocialTxt.Text, 2))
    End Sub

    Private Sub CalleTxt_Validated(sender As System.Object, e As System.EventArgs) Handles CalleTxt.Validated
        CalleTxt.Text = UCase(Mid(CalleTxt.Text, 1, 1)) & LCase(Mid(CalleTxt.Text, 2))
    End Sub

    Private Sub DepartamentoTxt_Validated(sender As System.Object, e As System.EventArgs) Handles DepartamentoTxt.Validated
        DepartamentoTxt.Text = UCase(Mid(DepartamentoTxt.Text, 1, 1)) & LCase(Mid(DepartamentoTxt.Text, 2))
    End Sub

    Private Sub AltaProveedor_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "103")
        End If
    End Sub

    Private Sub TelefonosDG_Click(sender As System.Object, e As System.EventArgs) Handles TelefonosDG.Click
        ErrorP.SetError(TelefonosDG, "")
    End Sub

#End Region

#Region "Mejoras"

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

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.AltaProveedorFrm

        DatosGB.Text = My.Resources.ArchivoIdioma.DatosEmpresa
        RazonSocialLbl.Text = My.Resources.ArchivoIdioma.RazonSocialGral
        CuitLbl.Text = My.Resources.ArchivoIdioma.CuitGral
        CorreoElectronicoLbl.Text = My.Resources.ArchivoIdioma.CorreoElectronicoGral

        TelefonosGB.Text = My.Resources.ArchivoIdioma.TelefonosGB
        NumeroTelLbl.Text = My.Resources.ArchivoIdioma.NumeroTelLbl
        NumeroCAB.HeaderText = My.Resources.ArchivoIdioma.NumeroTelLbl

        DomicilioGB.Text = My.Resources.ArchivoIdioma.DomicilioGB
        LocalidadLbl.Text = My.Resources.ArchivoIdioma.LocalidadLbl
        CalleLbl.Text = My.Resources.ArchivoIdioma.CalleLbl
        NumeroLbl.Text = My.Resources.ArchivoIdioma.NumeroCalleLbl
        PisoLbl.Text = My.Resources.ArchivoIdioma.PisoLbl
        DepartamentoLbl.Text = My.Resources.ArchivoIdioma.DepartamentoLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(RazonSocialTxt, My.Resources.ArchivoIdioma.TTRazonSocial)
        ControlesTP.SetToolTip(CuitTxt, My.Resources.ArchivoIdioma.TTCuit)
        ControlesTP.SetToolTip(CorreoElectronicoTxt, My.Resources.ArchivoIdioma.TTCorreoElectronico)
        ControlesTP.SetToolTip(TelefonoTxt, My.Resources.ArchivoIdioma.TTTelefonoProv)
        ControlesTP.SetToolTip(AgregarTelBtn, My.Resources.ArchivoIdioma.TTAgregarTel)
        ControlesTP.SetToolTip(QuitarTelBtn, My.Resources.ArchivoIdioma.TTQuitarTel)
        ControlesTP.SetToolTip(TelefonosDG, My.Resources.ArchivoIdioma.TTListaTel)
        ControlesTP.SetToolTip(LocalidadCMB, My.Resources.ArchivoIdioma.TTLocalidad)
        ControlesTP.SetToolTip(AgregarLocBtn, My.Resources.ArchivoIdioma.TTAgregarLocalidad)
        ControlesTP.SetToolTip(CalleTxt, My.Resources.ArchivoIdioma.TTCalleProv)
        ControlesTP.SetToolTip(NumeroTxt, My.Resources.ArchivoIdioma.TTNumeroCalleProv)
        ControlesTP.SetToolTip(PisoTxt, My.Resources.ArchivoIdioma.TTPisoProv)
        ControlesTP.SetToolTip(DepartamentoTxt, My.Resources.ArchivoIdioma.TTDepartemento)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarAltaProv)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

End Class