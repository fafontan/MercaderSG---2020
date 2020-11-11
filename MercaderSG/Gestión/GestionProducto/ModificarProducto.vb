Imports Excepciones
Imports Entidades
Imports Negocios
Imports Servicios
Imports System.IO

Public Class ModificarProducto

    Public ProductoSel As String
    Private ProductoGuardo As String

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub ModificarProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CargarTT()
        AplicarIdioma()
        CargarFoco(ProductoGB)

        SectorCMB.Items.Add("Farmaceutico")
        SectorCMB.Items.Add("Quimico")
        SectorCMB.Items.Add("Alimenticio")

        ProductoGuardo = ProductoSel

        ProductoSel = Seguridad.Encriptar(ProductoSel)
        Try
            Dim Producto As ProductoEN = ProductoRN.ObtenerProducto(ProductoSel)

            CodigoTxt.Text = Producto.CodProd
            NombreTxt.Text = Producto.Nombre
            SectorCMB.SelectedItem = Producto.Sector
            DescripcionTxt.Text = Producto.Descripcion
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
        Producto.Nombre = NombreTxt.Text
        Producto.Sector = SectorCMB.SelectedItem
        Producto.Descripcion = DescripcionTxt.Text
        Try
            ProductoRN.ModificarProducto(Producto)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            If ex.Message = My.Resources.ArchivoIdioma.NombreProductoExistente Then
                NombreTxt.Text = ProductoGuardo
                NombreTxt.Select()
            Else
                Me.Close()
            End If
        End Try
    End Sub

    Private Sub ModificarProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "124")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
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

    Private Sub DescripcionTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles DescripcionTxt.TextChanged
        ErrorP.SetError(DescripcionTxt, "")
    End Sub

    Private Sub NombreTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles NombreTxt.KeyPress
        Dim CaracterPermitido As String = "áéúíóÁÉÍÓÚQWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm1234567890-.,_[]|\/#() " & Convert.ToChar(8)
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
        Me.Text = My.Resources.ArchivoIdioma.ModificarProductoFrm

        ProductoGB.Text = My.Resources.ArchivoIdioma.DatosProductoGB
        CodigoLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
        NombreLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
        SectorLbl.Text = My.Resources.ArchivoIdioma.CMBSector
        DescripcionLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(CodigoTxt, My.Resources.ArchivoIdioma.TTCodProd)
        ControlesTP.SetToolTip(NombreTxt, My.Resources.ArchivoIdioma.TTNombreProd)
        ControlesTP.SetToolTip(SectorCMB, My.Resources.ArchivoIdioma.TTSectorProd)
        ControlesTP.SetToolTip(DescripcionTxt, My.Resources.ArchivoIdioma.TTDescrProd)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarModificarProd)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

End Class