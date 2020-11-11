Imports Servicios
Imports Entidades
Imports Negocios
Imports Excepciones
Public Class CambiarContrasena

    Private Sub CambiarContrasena_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()
        CargarFoco(ContrasenaGB)
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        Dim ConAnt As String = ConAnteriorTxt.Text
        Dim NuevaCon As String = NuevaContraseñaTxt.Text
        Dim ReNuevaCon As String = ReNuevaContraseñaTxt.Text
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        If NuevaCon = ReNuevaCon Then
            Try
                UsuarioRN.CambiarContraseña(UsuAut.UsuarioLogueado, ConAnt, NuevaCon)
            Catch ex As InformationException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                If ex.Message = My.Resources.ArchivoIdioma.UsuarioDadoBaja Then
                    Me.Close()
                Else
                    ConAnteriorTxt.Clear()
                End If
            End Try
        Else
            MessageBox.Show(My.Resources.ArchivoIdioma.NoCoincidenPass, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NuevaContraseñaTxt.Clear()
            ReNuevaContraseñaTxt.Clear()
        End If
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(ConAnteriorTxt.Text) And String.IsNullOrEmpty(NuevaContraseñaTxt.Text) And String.IsNullOrEmpty(ReNuevaContraseñaTxt.Text) Then
            MessageBox.Show(My.Resources.ArchivoIdioma.Completar3CamposCon, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConAnteriorTxt.Focus()
            Resultado = False

            Return Resultado
        End If

        'Contraseña Anterior
        If String.IsNullOrEmpty(ConAnteriorTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.CampoObligatorio, ConAnteriorTxt)
            ConAnteriorTxt.Focus()
            Resultado = False

            Return Resultado
        End If

        Select Case ConAnteriorTxt.Text.Length
            Case 1 To 7
                MensajeTT.Show(My.Resources.ArchivoIdioma.ContenerMenos8Carac, ConAnteriorTxt)
                ConAnteriorTxt.Focus()
                Resultado = False

                Return Resultado

            Case 8 To 12
                MensajeTT.Hide(ConAnteriorTxt)

            Case Is > 12
                MensajeTT.Show(My.Resources.ArchivoIdioma.Contener12Carac, ConAnteriorTxt)
                ConAnteriorTxt.Focus()
                Resultado = False

                Return Resultado
        End Select

        'Nueva Contraseña

        If String.IsNullOrEmpty(NuevaContraseñaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.CampoObligatorio, NuevaContraseñaTxt)
            NuevaContraseñaTxt.Focus()
            Resultado = False

            Return Resultado
        End If

        Select Case NuevaContraseñaTxt.Text.Length
            Case 1 To 7
                MensajeTT.Show(My.Resources.ArchivoIdioma.ContenerMenos8Carac, NuevaContraseñaTxt)
                NuevaContraseñaTxt.Focus()
                Resultado = False

                Return Resultado

            Case 8 To 12
                MensajeTT.Hide(NuevaContraseñaTxt)

            Case Is > 12
                MensajeTT.Show(My.Resources.ArchivoIdioma.Contener12Carac, NuevaContraseñaTxt)
                NuevaContraseñaTxt.Focus()
                Resultado = False

                Return Resultado
        End Select

        'Repetir Contraseña

        If String.IsNullOrEmpty(ReNuevaContraseñaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.CampoObligatorio, ReNuevaContraseñaTxt)
            ReNuevaContraseñaTxt.Focus()
            Resultado = False

            Return Resultado
        End If

        Select Case ReNuevaContraseñaTxt.Text.Length
            Case 1 To 7
                MensajeTT.Show(My.Resources.ArchivoIdioma.ContenerMenos8Carac, ReNuevaContraseñaTxt)
                ReNuevaContraseñaTxt.Focus()
                Resultado = False

                Return Resultado

            Case 8 To 12
                MensajeTT.Hide(ReNuevaContraseñaTxt)

            Case Is > 12
                MensajeTT.Show(My.Resources.ArchivoIdioma.Contener12Carac, ReNuevaContraseñaTxt)
                ReNuevaContraseñaTxt.Focus()
                Resultado = False

                Return Resultado
        End Select

        Return Resultado
    End Function


    Private Sub ContraseñasTxts_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ConAnteriorTxt.KeyPress, NuevaContraseñaTxt.KeyPress, ReNuevaContraseñaTxt.KeyPress
        Dim CaracteresPermitidos As String = "qwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM1234567890~!@#$%^&*()_-+={}[]\|:;<>,.?/" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracteresPermitidos.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ConAnteriorTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ConAnteriorTxt.TextChanged
        MensajeTT.Hide(ConAnteriorTxt)
    End Sub

    Private Sub NuevaContraseñaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles NuevaContraseñaTxt.TextChanged
        MensajeTT.Hide(NuevaContraseñaTxt)
    End Sub

    Private Sub ReNuevaContraseñaTxt_TextChanged(sender As System.Object, e As System.EventArgs) Handles ReNuevaContraseñaTxt.TextChanged
        MensajeTT.Hide(ReNuevaContraseñaTxt)
    End Sub

    Private Sub CambiarContrasena_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.CambiarContrasenaSMI.Enabled = True
    End Sub

    Private Sub CambiarContrasena_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        Me.Text = My.Resources.ArchivoIdioma.CambiarContraseñaFrm

        ContrasenaGB.Text = My.Resources.ArchivoIdioma.CambiarContraseña
        ConAnteriorLbl.Text = My.Resources.ArchivoIdioma.ConAnteriorLbl
        NuevaContraseñaLbl.Text = My.Resources.ArchivoIdioma.NuevaConLbl
        ReNuevaContraseñaLbl.Text = My.Resources.ArchivoIdioma.ReNuevaConLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(ConAnteriorTxt, My.Resources.ArchivoIdioma.TTConAnterior)
        ControlesTP.SetToolTip(NuevaContraseñaTxt, My.Resources.ArchivoIdioma.TTNuevaCon)
        ControlesTP.SetToolTip(ReNuevaContraseñaTxt, My.Resources.ArchivoIdioma.TTConfirmarCon)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.CambiarContraseña)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

End Class