Imports Excepciones
Imports Entidades
Imports Negocios
Imports Servicios
Imports System.IO

Public Class ModificarStock

    Public ProductoSel As String

    Private Sub ModificarStock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AplicarIdioma()
        CargarTT()
        CargarFoco(CantidadGB)

        ProductoSel = Seguridad.Encriptar(ProductoSel)
        Try
            Dim Producto As ProductoEN = ProductoRN.ObtenerProducto(ProductoSel)

            CodigoTxt.Text = Producto.CodProd
            NombreTxt.Text = Producto.Nombre
            DescripcionTxt.Text = Producto.Descripcion
            CantActualTxt.Text = Producto.Cantidad
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Dispose()
        End Try
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        Dim Producto As New ProductoEN

        Producto.CodProd = CodigoTxt.Text
        Producto.Nombre = NombreTxt.Text
        Producto.Cantidad = CantidadNuevaTxt.Text
        Try
            ProductoRN.ModificarStockProducto(Producto)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End Try
    End Sub

    Private Sub ModificarStock_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "126")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        'Cantidad
        If String.IsNullOrEmpty(CantidadNuevaTxt.Text) Then
            ErrorP.SetError(CantidadNuevaTxt, My.Resources.ArchivoIdioma.CampoObligatorio)
            Resultado = False
        Else
            'ErrorP.SetError(CantidadTxt, "")
            If Convert.ToInt32(CantidadNuevaTxt.Text) > 100 Then
                MensajeTT.Show(My.Resources.ArchivoIdioma.CantidadMayor100, CantidadNuevaTxt)
                'ErrorP.SetError(CantidadTxt, My.Resources.ArchivoIdioma.CantidadMayor100)
                Resultado = False
            End If
        End If

        Select Case CantidadNuevaTxt.Text.Length
            Case Is > 3
                ErrorP.SetError(CantidadNuevaTxt, My.Resources.ArchivoIdioma.Contener3Carac)
                Resultado = False
            Case 1 To 3
                ErrorP.SetError(CantidadNuevaTxt, "")
        End Select

        Return Resultado
    End Function

    Private Sub CantidadTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles CantNuevaTxt.TextChanged
        ErrorP.SetError(CantNuevaTxt, "")
    End Sub

    Private Sub CantidadTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CantNuevaTxt.KeyPress
        Dim CaracterPermitido As String = "1234567890" & Convert.ToChar(8)
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
        Me.Text = My.Resources.ArchivoIdioma.ModificarStockProductoFrm

        ProductoGB.Text = My.Resources.ArchivoIdioma.DatosProductoGB
        CodigoLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
        NombreLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
        DescripcionLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl

        CantidadGB.Text = My.Resources.ArchivoIdioma.CantidadGB
        CantActualLbl.Text = My.Resources.ArchivoIdioma.CantActualLbl
        CantNuevaLbl.Text = My.Resources.ArchivoIdioma.NuevoCantLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(CodigoTxt, My.Resources.ArchivoIdioma.TTCodProd)
        ControlesTP.SetToolTip(NombreTxt, My.Resources.ArchivoIdioma.TTNombreProd)
        ControlesTP.SetToolTip(DescripcionTxt, My.Resources.ArchivoIdioma.TTDescrProd)
        ControlesTP.SetToolTip(CantActualTxt, My.Resources.ArchivoIdioma.TTCantActual)
        ControlesTP.SetToolTip(CantNuevaTxt, My.Resources.ArchivoIdioma.TTNuevaCant)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarModificarPrecioProd)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub
End Class