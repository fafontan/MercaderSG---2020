Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.IO

Public Class GestionFamilia

#Region "Permisos"

    Private AltaFamilia As Boolean = False
    Private BajaFamilia As Boolean = False
    Private ModificarFamilia As Boolean = False

    Dim UsuAut As Autenticar = Autenticar.Instancia()

    Private Sub CargarPermisos()
        AltaFamilia = PermisoOK(26)
        AgregarBtn.Enabled = AltaFamilia

        ModificarFamilia = PermisoOK(27)
        ModificarBtn.Enabled = ModificarFamilia

        BajaFamilia = PermisoOK(28)
        EliminarBtn.Enabled = BajaFamilia
    End Sub

    Private Function PermisoOK(CodPat As Integer) As Boolean
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = CodPat Then
                Return True
            End If
        Next
        Return False
    End Function

#End Region

    Private Sub GestionFamilia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FamiliaDG.AutoGenerateColumns = False
        FamiliaDG.DataSource = FamiliaRN.CargarFamilia()

        AplicarIdioma()
        CargarTT()
        CargarPermisos()
    End Sub

    Private Sub AgregarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AgregarBtn.Click
        Dim frm As New AltaFamilia
        frm.PuedeModificar = ModificarFamilia

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FamiliaDG.DataSource = FamiliaRN.CargarFamilia()
        End If
    End Sub

    Private Sub ModificarBtn_Click(sender As System.Object, e As System.EventArgs) Handles ModificarBtn.Click
        If FamiliaDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoFamilias, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = FamiliaDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarFamilia, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Codigo As Integer
        Dim Descripcion As String

        Codigo = FamiliaDG.CurrentRow.Cells(0).Value
        Descripcion = FamiliaDG.CurrentRow.Cells(1).Value

        Dim frm As New ModificarFamilia
        frm.FamiliaSel = FamiliaDG.CurrentRow.Cells(1).Value

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FamiliaDG.DataSource = FamiliaRN.CargarFamilia()
        End If
    End Sub

    Private Sub EliminarBtn_Click(sender As System.Object, e As System.EventArgs) Handles EliminarBtn.Click
        If FamiliaDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoFamilias, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Fila As DataGridViewRow = FamiliaDG.CurrentRow
        If Not Fila.Selected Then
            MessageBox.Show(My.Resources.ArchivoIdioma.DebeSeleccionarFamilia, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim Codigo As Integer
        Dim Descripcion As String

        Codigo = FamiliaDG.CurrentRow.Cells(0).Value
        Descripcion = FamiliaDG.CurrentRow.Cells(1).Value

        Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.EliminarFamilia & Descripcion & My.Resources.ArchivoIdioma.Pregunta, My.Resources.ArchivoIdioma.MsgBoxEliminarFamilia, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If Resultado = Windows.Forms.DialogResult.OK Then
            Dim Familia As New FamiliaEN
            Familia.CodFam = Codigo
            Familia.Descripcion = Descripcion
            Try
                FamiliaRN.BajaFamilia(Familia)
            Catch ex As InformationException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                FamiliaDG.DataSource = FamiliaRN.CargarFamilia()
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                FamiliaDG.DataSource = FamiliaRN.CargarFamilia()
            End Try
        Else
            Exit Sub
        End If

    End Sub

    Private Sub GestionFamilia_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.GestionFamiliaSMI.Enabled = True
    End Sub

    Private Sub GestionFamilia_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "115")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.N And AltaFamilia = True Then
            AgregarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.U And ModificarFamilia = True Then
            ModificarBtn.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.D And BajaFamilia = True Then
            EliminarBtn.PerformClick()
        End If

    End Sub

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.GestionFamiliaFrm

        OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
        AgregarBtn.Text = My.Resources.ArchivoIdioma.AltaFamBtn
        ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarFamBtn
        EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarFamBtn

        RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
        CodCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        DescripcionCAB.HeaderText = My.Resources.ArchivoIdioma.DescripcionLbl
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(AgregarBtn, My.Resources.ArchivoIdioma.TTAgregarFam)
        ControlesTP.SetToolTip(ModificarBtn, My.Resources.ArchivoIdioma.TTModificarFam)
        ControlesTP.SetToolTip(EliminarBtn, My.Resources.ArchivoIdioma.TTEliminarFam)
        ControlesTP.SetToolTip(FamiliaDG, My.Resources.ArchivoIdioma.TTlistaFamilias)
    End Sub

End Class