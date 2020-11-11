Imports Entidades
Imports Negocios
Imports Servicios
Imports Excepciones
Imports System.IO

Public Class ModificarFamilia
    Dim CodigoFamilia As Integer
    Public FamiliaSel As String

    Private Sub ModificarFamilia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FamiliaSel = Seguridad.Encriptar(FamiliaSel)

        Dim Familia As FamiliaEN = FamiliaRN.ObtenerFamilia(FamiliaSel)
        DescripcionTxt.Text = Familia.Descripcion
        CodigoFamilia = Familia.CodFam

        AplicarIdioma()
        CargarTT()
    End Sub

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.ModificarFamFrm

        DescripcionLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl
        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(DescripcionTxt, My.Resources.ArchivoIdioma.TTDescripcionModFam)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTModificarFam)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim Familia As New FamiliaEN
        Familia.CodFam = CodigoFamilia
        Familia.Descripcion = DescripcionTxt.Text

        Try
            FamiliaRN.ModificarFamilia(Familia)
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

    Private Sub ModificarFamilia_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "122")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(DescripcionTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.CampoVacio, DescripcionTxt)
            Resultado = False
            Return Resultado
        End If

        If DescripcionTxt.Text.Length > 25 Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.Contener25Num, DescripcionTxt)
            Resultado = False
            Return Resultado
        End If

        Return Resultado
    End Function

    Private Sub DescripcionTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles DescripcionTxt.TextChanged
        MensajeTT.Hide(DescripcionTxt)
    End Sub

    Private Sub DescripcionTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DescripcionTxt.KeyPress
        Dim CaracteresPosibles As String = "qwertyuiopasdfghjklñzxcvbnmáéíúóQWERTYUIOPASDFGHJKLÑZXCVBNMÁÉÍÚÓ-_12334567890" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracteresPosibles.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DescripcionTxt_Validated(sender As System.Object, e As System.EventArgs) Handles DescripcionTxt.Validated
        DescripcionTxt.Text = UCase(Mid(DescripcionTxt.Text, 1, 1)) & LCase(Mid(DescripcionTxt.Text, 2))
    End Sub
End Class