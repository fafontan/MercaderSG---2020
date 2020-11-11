Imports Servicios
Imports Entidades
Imports Negocios
Imports Excepciones
Imports System.Text
Imports System.IO

Public Class AltaProducto
    Public PuedeModificar As Boolean = False

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim UnProducto As New ProductoEN

        UnProducto.Nombre = NombreTxt.Text
        UnProducto.Precio = PrecioTxt.Value.ToString()
        UnProducto.Sector = SectorCMB.SelectedItem
        UnProducto.Cantidad = CantidadTxt.Text
        UnProducto.Descripcion = DescripcionTxt.Text

        Dim CadenaMensaje As New StringBuilder
        CadenaMensaje.Append(My.Resources.ArchivoIdioma.PregPrecioCorrecto & Environment.NewLine)
        CadenaMensaje.Append(Environment.NewLine)
        CadenaMensaje.Append(My.Resources.ArchivoIdioma.FormatoPrecioCorrecto & Environment.NewLine)
        CadenaMensaje.Append(My.Resources.ArchivoIdioma.FormatoPrecioCorrectoDec)

        Dim Resultado As DialogResult = MessageBox.Show(CadenaMensaje.ToString(), My.Resources.ArchivoIdioma.Precio & " - MercaderSG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Resultado = Windows.Forms.DialogResult.OK Then
            Try
                ProductoRN.AltaProducto(UnProducto)
            Catch ex As InformationException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                If ex.Message = My.Resources.ArchivoIdioma.ProductoExistente Then
                    If PuedeModificar = True Then
                        Dim ResultadoMensaje As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.ModificarProducto & NombreTxt.Text & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxModificarProducto, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                        If ResultadoMensaje = Windows.Forms.DialogResult.OK Then
                            Dim frm As New ModificarProducto
                            frm.ProductoSel = NombreTxt.Text
                            Me.Dispose()
                            frm.ShowDialog()
                        Else
                            Me.Close()
                        End If
                    End If
                End If
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ACBtn_Click(sender As System.Object, e As System.EventArgs) Handles ACBtn.Click
        ErrorP.SetError(DescripcionTxt, "")
        DescripcionTxt.Clear()
        DescripcionTxt.Text = My.Resources.ArchivoIdioma.ACDescProd & SectorCMB.SelectedItem
    End Sub

    Private Sub AltaProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()
        CargarFoco(ProductoGB)

        SectorCMB.Items.Add("Farmaceutico")
        SectorCMB.Items.Add("Quimico")
        SectorCMB.Items.Add("Alimenticio")

        SectorCMB.SelectedIndex = 0
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

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

        'Precio
        If String.IsNullOrEmpty(PrecioTxt.Text) Then
            ErrorP.SetError(PrecioTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(PrecioTxt, "")
        End If

        Select Case PrecioTxt.Text.Length
            Case Is > 9
                ErrorP.SetError(PrecioTxt, My.Resources.ArchivoIdioma.Contener9Carac)
                Resultado = False
            Case 1 To 9
                ErrorP.SetError(PrecioTxt, "")
        End Select


        'Cantidad
        If String.IsNullOrEmpty(CantidadTxt.Text) Then
            ErrorP.SetError(CantidadTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(CantidadTxt, "")
        End If

        Select Case CantidadTxt.Text.Length
            Case Is > 3
                ErrorP.SetError(CantidadTxt, My.Resources.ArchivoIdioma.Contener3Carac)
                Resultado = False
            Case 1 To 3
                ErrorP.SetError(CantidadTxt, "")
        End Select

        'Descripcion
        If String.IsNullOrEmpty(DescripcionTxt.Text) Then
            ErrorP.SetError(DescripcionTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(DescripcionTxt, "")
        End If

        Select Case DescripcionTxt.Text.Length
            Case Is > 100
                ErrorP.SetError(DescripcionTxt, My.Resources.ArchivoIdioma.Contener100Carac)
                Resultado = False
            Case 1 To 100
                ErrorP.SetError(DescripcionTxt, "")
        End Select

        Return Resultado
    End Function


    Private Sub NombreTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles NombreTxt.TextChanged
        ErrorP.SetError(NombreTxt, "")
    End Sub

    Private Sub PrecioTxt_TextChanged(sender As System.Object, e As System.EventArgs)
        ErrorP.SetError(PrecioTxt, "")
    End Sub

    Private Sub CantidadTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CantidadTxt.TextChanged
        ErrorP.SetError(CantidadTxt, "")
    End Sub

    Private Sub DescripcionTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles DescripcionTxt.TextChanged
        ErrorP.SetError(DescripcionTxt, "")
    End Sub

    Private Sub NombreTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles NombreTxt.KeyPress
        Dim CaracterPermitido As String = "QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890áéúíóÁÉÍÓÚ-.,_[]|\/#() " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub PrecioTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim CaracterPermitido As String = "1234567890.," & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CantidadTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadTxt.KeyPress
        Dim CaracterPermitido As String = "1234567890" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DescripcionTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DescripcionTxt.KeyPress
        Dim CaracterPermitido As String = "áéúíóÁÉÍÓÚQWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890-.,_[]|\/#() " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DescripcionTxt_Validated(sender As System.Object, e As System.EventArgs) Handles DescripcionTxt.Validated
        DescripcionTxt.Text = UCase(Mid(DescripcionTxt.Text, 1, 1)) & LCase(Mid(DescripcionTxt.Text, 2))
    End Sub

    Private Sub AltaProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "102")
        End If

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
        Me.Text = My.Resources.ArchivoIdioma.AltaProductoFrm

        ProductoGB.Text = My.Resources.ArchivoIdioma.DatosProductoGB
        NombreLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
        SectorLbl.Text = My.Resources.ArchivoIdioma.CMBSector
        PrecioLbl.Text = My.Resources.ArchivoIdioma.Precio
        CantidadLbl.Text = My.Resources.ArchivoIdioma.Cantidad
        DescripcionLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(NombreTxt, My.Resources.ArchivoIdioma.TTNombreProd)
        ControlesTP.SetToolTip(SectorCMB, My.Resources.ArchivoIdioma.TTSectorProd)
        ControlesTP.SetToolTip(PrecioTxt, My.Resources.ArchivoIdioma.TTPrecioProd)
        ControlesTP.SetToolTip(CantidadTxt, My.Resources.ArchivoIdioma.TTCantidadProd)
        ControlesTP.SetToolTip(DescripcionTxt, My.Resources.ArchivoIdioma.TTDescrProd)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarAltaProd)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
        ControlesTP.SetToolTip(ACBtn, My.Resources.ArchivoIdioma.TTAutoCompletar)
    End Sub

#End Region

    Private Sub PrecioTxt_Validated(sender As System.Object, e As System.EventArgs)

    End Sub

End Class