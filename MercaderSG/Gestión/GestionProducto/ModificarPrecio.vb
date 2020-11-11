Imports Excepciones
Imports Entidades
Imports Negocios
Imports Servicios
Imports System.Text
Imports System.IO

Public Class ModificarPrecio

    Public ProductoSel As String

    Private Sub ModificarPrecio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AplicarIdioma()
        CargarTT()
        CargarFoco(PrecioGB)

        ProductoSel = Seguridad.Encriptar(ProductoSel)
        Try
            Dim Producto As ProductoEN = ProductoRN.ObtenerProducto(ProductoSel)

            CodigoTxt.Text = Producto.CodProd
            NombreTxt.Text = Producto.Nombre
            DescripcionTxt.Text = Producto.Descripcion
            PrecioActualTxt.Text = Producto.Precio

            NuevoPrecioTxt.Value = PrecioActualTxt.Text
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Dispose()
        End Try
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim Producto As New ProductoEN

        Producto.CodProd = CodigoTxt.Text
        Producto.Precio = NuevoPrecioTxt.Value.ToString()

        Dim CadenaMensaje As New StringBuilder
        CadenaMensaje.Append(My.Resources.ArchivoIdioma.PregPrecioCorrecto & Environment.NewLine)
        CadenaMensaje.Append(Environment.NewLine)
        CadenaMensaje.Append(My.Resources.ArchivoIdioma.FormatoPrecioCorrecto & Environment.NewLine)
        CadenaMensaje.Append(My.Resources.ArchivoIdioma.FormatoPrecioCorrectoDec)

        Dim Resultado As DialogResult = MessageBox.Show(CadenaMensaje.ToString(), My.Resources.ArchivoIdioma.Precio & " - MercaderSG", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Resultado = Windows.Forms.DialogResult.OK Then
            Try
                ProductoRN.ModificarPrecioProducto(Producto)
            Catch ex As InformationException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ModificarPrecio_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "123")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        'Precio
        If String.IsNullOrEmpty(NuevoPrecioTxt.Text) Then
            ErrorP.SetError(NuevoPrecioTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            ErrorP.SetError(NuevoPrecioTxt, "")
        End If

        Select Case NuevoPrecioTxt.Text.Length
            Case Is > 9
                ErrorP.SetError(NuevoPrecioTxt, My.Resources.ArchivoIdioma.Contener9Carac)
                Resultado = False
            Case 1 To 9
                ErrorP.SetError(NuevoPrecioTxt, "")
        End Select

        Return Resultado
    End Function

    Private Sub NuevoPrecioTxt_TextChanged(sender As System.Object, e As System.EventArgs)
        ErrorP.SetError(NuevoPrecioTxt, "")
    End Sub

    Private Sub NuevoPrecioTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim CaracterPermitido As String = "QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890-.,_[]|\/#() " & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
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
            If (TypeOf (Ctrl) Is System.Windows.Forms.TextBox) And Not Ctrl.Enabled = False Then
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
        Me.Text = My.Resources.ArchivoIdioma.ModificarPrecioProductoFrm

        ProductoGB.Text = My.Resources.ArchivoIdioma.DatosProductoGB
        CodigoLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
        NombreLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
        DescripcionLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl

        PrecioGB.Text = My.Resources.ArchivoIdioma.NuevoPrecioLbl
        PrecioActualLbl.Text = My.Resources.ArchivoIdioma.PrecioActualLbl
        NuevoPrecioLbl.Text = My.Resources.ArchivoIdioma.NuevoPrecioLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(CodigoTxt, My.Resources.ArchivoIdioma.TTCodProd)
        ControlesTP.SetToolTip(NombreTxt, My.Resources.ArchivoIdioma.TTNombreProd)
        ControlesTP.SetToolTip(DescripcionTxt, My.Resources.ArchivoIdioma.TTDescrProd)
        ControlesTP.SetToolTip(PrecioActualTxt, My.Resources.ArchivoIdioma.TTPrecioActual)
        ControlesTP.SetToolTip(NuevoPrecioTxt, My.Resources.ArchivoIdioma.TTNuevoPrecio)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarModificarPrecioProd)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub
End Class