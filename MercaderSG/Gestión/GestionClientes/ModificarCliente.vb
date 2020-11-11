Imports Servicios
Imports Negocios
Imports Excepciones
Imports Entidades
Imports System.Text.RegularExpressions
Imports System.IO

Public Class ModificarCliente
    Dim CodigoCliente As Integer
    Public ClienteSel As String
    Public EstadoCliente As Boolean = False

    Private Sub ModificarCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AplicarIdioma()
        CargarTT()
        CargarFoco(DatosGB)
        CargarFoco(DomicilioGB)
        CargarFoco(TelefonosGB)

        ClienteSel = Seguridad.Encriptar(ClienteSel)

        LocalidadCMB.DataSource = LocalidadRN.CargarLocalidad()
        LocalidadCMB.DisplayMember = "Descripcion"
        LocalidadCMB.ValueMember = "CodLoc"

        Try
            Dim Cliente As ClienteEN = ClienteRN.ObtenerCliente(ClienteSel)
            CuitTxt.Text = Cliente.Cuit
            RazonSocialTxt.Text = Cliente.RazonSocial
            LocalidadCMB.SelectedValue = Cliente.CodLoc
            CalleTxt.Text = Cliente.Calle
            NumeroTxt.Text = Cliente.Numero
            PisoTxt.Text = Cliente.Piso
            DepartamentoTxt.Text = Cliente.Departamento

            CodigoCliente = Cliente.CodCli


            TelefonosDG.AutoGenerateColumns = False
            TelefonosDG.DataSource = ClienteRN.ObtenerTelefonoCliente(CodigoCliente)

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

        Dim ClienteCuit As String = CuitTxt.Text
        ClienteCuit = Seguridad.Encriptar(ClienteCuit)

        Dim Cliente As New ClienteEN
        Cliente.CodCli = CodigoCliente
        Cliente.Cuit = ClienteCuit
        Cliente.RazonSocial = RazonSocialTxt.Text
        Cliente.CodLoc = LocalidadCMB.SelectedValue
        Cliente.Calle = CalleTxt.Text
        Cliente.Numero = NumeroTxt.Text
        Cliente.Piso = PisoTxt.Text
        Cliente.Departamento = DepartamentoTxt.Text

        Cliente.Telefono = ListaTelefono

        Try
            ClienteRN.ModificarCliente(Cliente)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End Try
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub AgregarLocBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarLocBtn.Click
        Dim frm As New AltaLocalidad
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LocalidadCMB.Focus()
            LocalidadCMB.DataSource = LocalidadRN.CargarLocalidad()
            ErrorP.SetError(AgregarLocBtn, "")
        End If
    End Sub

#Region "Validaciones"
    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

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

    Private Sub TelefonosDG_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles TelefonosDG.EditingControlShowing
        Dim Celda As TextBox = CType(e.Control, TextBox)
        AddHandler Celda.KeyPress, AddressOf Celda_Keypress
    End Sub

    Private Sub Celda_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim CaracterPermitido As String = "1234567890()- " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub RazonSocialCalleTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles RazonSocialTxt.KeyPress, CalleTxt.KeyPress
        Dim CaracterPermitido As String = "QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890.-áéúíóÁÉÍÓÚ " & Convert.ToChar(8)
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

    Private Sub ModificarCliente_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "121")
        End If
    End Sub
#End Region

#Region "MEjoras"
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
        Me.Text = My.Resources.ArchivoIdioma.ModificarClienteFrm

        DatosGB.Text = My.Resources.ArchivoIdioma.DatosEmpresa
        RazonSocialLbl.Text = My.Resources.ArchivoIdioma.RazonSocialGral
        CuitLbl.Text = My.Resources.ArchivoIdioma.CuitGral

        TelefonosGB.Text = My.Resources.ArchivoIdioma.TelefonosGB
        TelefonoCAB.HeaderText = My.Resources.ArchivoIdioma.CodTelefono
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
        ControlesTP.SetToolTip(TelefonosDG, My.Resources.ArchivoIdioma.TTListaTel)
        ControlesTP.SetToolTip(LocalidadCMB, My.Resources.ArchivoIdioma.TTLocalidad)
        ControlesTP.SetToolTip(AgregarLocBtn, My.Resources.ArchivoIdioma.TTAgregarLocalidad)
        ControlesTP.SetToolTip(CalleTxt, My.Resources.ArchivoIdioma.TTCalleCli)
        ControlesTP.SetToolTip(NumeroTxt, My.Resources.ArchivoIdioma.TTNumeroCalleCli)
        ControlesTP.SetToolTip(PisoTxt, My.Resources.ArchivoIdioma.TTPisoCli)
        ControlesTP.SetToolTip(DepartamentoTxt, My.Resources.ArchivoIdioma.TTDepartemento)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarModCli)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

End Class