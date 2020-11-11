Imports Entidades
Imports Excepciones
Imports Negocios
Public Class AltaLocalidad

    Private Sub AltaLocalidad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
        CargarFoco(LocalidadGB)

        ProvinciaCMB.DataSource = LocalidadRN.CargarProvincia()
        ProvinciaCMB.DisplayMember = "Descripcion"
        ProvinciaCMB.ValueMember = "CodProvincia"
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim Localidad As New LocalidadEN
        Localidad.Descripcion = DescripcionTxt.Text
        Localidad.CodigoPostal = CodPostalTxt.Text
        Localidad.CodProvincia = ProvinciaCMB.SelectedValue

        Try
            LocalidadRN.AltaLocalidad(Localidad)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DescripcionTxt.Clear()
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK
        End Try
    End Sub


#Region "Validaciones"

    Public Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(DescripcionTxt.Text) Then
            ErrorP.SetError(DescripcionTxt, My.Resources.ArchivoIdioma.CampoVacio)
            Resultado = False
        Else
            ErrorP.SetError(DescripcionTxt, "")
        End If

        Select Case DescripcionTxt.Text.Length
            Case Is > 50
                ErrorP.SetError(DescripcionTxt, My.Resources.ArchivoIdioma.Contener50Carac)
                Resultado = False
            Case 1 To 50
                ErrorP.SetError(DescripcionTxt, "")
        End Select

        If String.IsNullOrEmpty(CodPostalTxt.Text) Then
            ErrorP.SetError(CodPostalTxt, My.Resources.ArchivoIdioma.CampoVacio)
            Resultado = False
        Else
            ErrorP.SetError(CodPostalTxt, "")
        End If

        Select Case CodPostalTxt.Text.Length
            Case Is > 10
                ErrorP.SetError(CodPostalTxt, My.Resources.ArchivoIdioma.Contener10Carac)
                Resultado = False
            Case 1 To 10
                ErrorP.SetError(CodPostalTxt, "")
        End Select

        Return Resultado
    End Function

    Private Sub DescripcionTxt_Validated(sender As System.Object, e As System.EventArgs) Handles DescripcionTxt.Validated
        DescripcionTxt.Text = UCase(Mid(DescripcionTxt.Text, 1, 1)) & LCase(Mid(DescripcionTxt.Text, 2))
    End Sub

    Private Sub DescripcionTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DescripcionTxt.KeyPress
        Dim CaracteresPermitidos As String = "áéúíóÁÉÍÓÚQWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CodPostalTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CodPostalTxt.KeyPress
        Dim CaracteresPermitidos As String = "1234567890" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DescripcionTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles DescripcionTxt.TextChanged
        ErrorP.SetError(DescripcionTxt, "")
    End Sub

    Private Sub CodPostalTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CodPostalTxt.TextChanged
        ErrorP.SetError(DescripcionTxt, "")
    End Sub

    Private Sub AltaLocalidad_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
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
        Me.Text = My.Resources.ArchivoIdioma.AltaLocalidadFrm

        LocalidadGB.Text = My.Resources.ArchivoIdioma.LocalidadLbl
        DescripcionLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl
        CodPostalLbl.Text = My.Resources.ArchivoIdioma.CodPostalLbl
        ProvinciaLbl.Text = My.Resources.ArchivoIdioma.ProvinciaLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(DescripcionTxt, My.Resources.ArchivoIdioma.TTDescripcionLoc)
        ControlesTP.SetToolTip(CodPostalTxt, My.Resources.ArchivoIdioma.TTCodPostalLoc)
        ControlesTP.SetToolTip(ProvinciaCMB, My.Resources.ArchivoIdioma.TTProvinciaLoc)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarAltaLoc)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region
    
    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub
End Class