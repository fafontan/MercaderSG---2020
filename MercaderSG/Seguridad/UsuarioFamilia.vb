Imports Entidades
Imports Negocios
Imports Servicios
Imports Excepciones
Imports System.Text
Imports System.IO

Public Class UsuarioFamilia
    Private CadenaNoAlta As New StringBuilder
    Private CadenaAlta As New StringBuilder
    Private FamNoPatentes As New StringBuilder
    Private AccionUsuarioAlta As Boolean = True
    Private UsuAut As Autenticar = Autenticar.Instancia()
    Private UsuSel As String
    Private Contador As Integer = 0

    Private Sub FamliaUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()

        UsuarioCMB.DataSource = UsuarioRN.CargarUsuario()
        UsuarioCMB.DisplayMember = "Usuario"
        UsuarioCMB.ValueMember = "CodUsu"

        FamiliaCLB.DataSource = FamiliaRN.CargarFamiliaConPatentes()
        FamiliaCLB.DisplayMember = "Descripcion"
        FamiliaCLB.ValueMember = "CodFam"

        PanelInferior.Visible = False
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        If UsuAut.UsuarioLogueado = (UsuarioCMB.SelectedItem).Usuario And AccionUsuarioAlta = True Then
            MessageBox.Show(My.Resources.ArchivoIdioma.MismoUsuarioAltaFamilia, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LimpiarCLB()
            Exit Sub
        End If

        Dim ListaFamilia As New List(Of UsuFamEN)
        UsuSel = (UsuarioCMB.SelectedItem).Usuario
        Dim UsuEnc As String = ""

        CadenaAlta.Clear()
        CadenaNoAlta.Clear()

        UsuEnc = Seguridad.Encriptar((UsuarioCMB.SelectedItem).Usuario)

        If Me.FamiliaCLB.CheckedIndices.Count > 0 Then
            For Each item As FamiliaEN In FamiliaCLB.CheckedItems
                Dim UnUsuFam As New UsuFamEN
                UnUsuFam.CodFam = item.CodFam
                UnUsuFam.DescFam = item.Descripcion
                ListaFamilia.Add(UnUsuFam)
            Next
        Else
            MessageBox.Show(My.Resources.ArchivoIdioma.NoFamSel, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim UsuFam As New UsuarioEN
        UsuFam.UsuFamL = ListaFamilia

        Try
            UsuarioRN.AltaUsuarioFamilia(UsuEnc, UsuFam)
        Catch ex As WarningException
            If ex.Message = My.Resources.ArchivoIdioma.UsuarioDadoBaja Then
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                UsuarioCMB.DataSource = Nothing

                UsuarioCMB.DataSource = UsuarioRN.CargarUsuario()
                UsuarioCMB.DisplayMember = "Usuario"
                UsuarioCMB.ValueMember = "CodUsu"
                LimpiarCLB()

                Exit Sub
            End If

            PanelInferior.Visible = True
            Dim Opcion As Boolean
            Dim ContadorAdver As Integer = 0
            Contador = 0

            For Each item As FamiliaEN In FamiliaCLB.CheckedItems
                Opcion = True

                For Each fam As UsuFamEN In ex.MensajesUsuFam

                    If item.Descripcion = fam.DescFam Then
                        ContadorAdver += 1
                        CadenaNoAlta.Append(ContadorAdver & ") " & fam.DescFam & Environment.NewLine)
                        Opcion = False
                        Exit For
                    End If

                Next

                If Opcion Then
                    Contador += 1
                    CadenaAlta.Append(Contador & ") " & item.Descripcion & Environment.NewLine)
                End If
            Next

            LimpiarCLB()
        Catch ex As CriticalException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            LimpiarCLB()
        End Try

        Contador = 0

        For Each item As FamiliaEN In FamiliaCLB.CheckedItems
            Contador += 1
            CadenaAlta.Append(Contador & ") " & item.Descripcion & Environment.NewLine)
        Next

        PanelInferior.Visible = True

        LimpiarCLB()
    End Sub

    Private Sub ErrorLbl_Click(sender As System.Object, e As System.EventArgs) Handles InformacionLbl.Click
        Dim frm As New ResultadoFamPatUsu

        frm.TituloAltaLbl.Text = My.Resources.ArchivoIdioma.AltaUsuFam
        frm.TituloErrorLbl.Text = My.Resources.ArchivoIdioma.NoTieneFamilia1 & UsuSel & My.Resources.ArchivoIdioma.NoTieneFamilia2
        frm.LblError.Text = CadenaNoAlta.ToString()
        frm.LblAlta.Text = CadenaAlta.ToString()

        If CadenaNoAlta.Length > 0 Then
            frm.AdvertenciaPanel.Visible = True
        Else
            frm.AdvertenciaPanel.Visible = False
        End If

        If CadenaAlta.Length > 0 Then
            frm.InformacionPanel.Visible = True
        Else
            frm.InformacionPanel.Visible = False
        End If

        frm.AdvertenciaPanelPatentes.Visible = False

        frm.ShowDialog()

        PanelInferior.Visible = False
    End Sub

    Sub LimpiarCLB()
        For i As Integer = 0 To FamiliaCLB.Items.Count - 1
            FamiliaCLB.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub UsuarioFamilia_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.UsuFamSMI.Enabled = True
    End Sub

    Private Sub UsuarioFamilia_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "113")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.UsuarioFamiliaFrm

        UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
        FamiliaGB.Text = My.Resources.ArchivoIdioma.FamiliasGBTiene
        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

        InformacionLbl.Text = My.Resources.ArchivoIdioma.ResultadoOperacion
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(UsuarioCMB, My.Resources.ArchivoIdioma.TTListaUsuarios)
        ControlesTP.SetToolTip(FamiliaCLB, My.Resources.ArchivoIdioma.TTlistaFamilias)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAltaUsuFam)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub UsuarioCMB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles UsuarioCMB.SelectedIndexChanged
        LimpiarCLB()
    End Sub
End Class