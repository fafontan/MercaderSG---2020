Imports Negocios
Imports Entidades
Imports Servicios
Imports Excepciones
Imports System.Text
Imports System.IO

Public Class FamiliaPatente
    Private DenPat As New StringBuilder
    Private AsigPat As New StringBuilder
    Private PatNoDenegadas As New StringBuilder
    Private DescFamSel As String

#Region "Permisos"

    Private AccionUsuarioAlta As Boolean = False
    Private AccionUsuarioBaja As Boolean = False
    Dim UsuAut As Autenticar = Autenticar.Instancia()

    Private Sub CargarPermisos()
        If PermisoOK(34) Then
            AccionUsuarioAlta = True
        End If

        If PermisoOK(35) Then
            AccionUsuarioBaja = True
        End If
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

    Private Sub FamiliaPatente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()
        CargarPermisos()
        AceptarBtn.Enabled = False
        PanelInferior.Visible = False

        FamiliaCMB.DataSource = FamiliaRN.CargarFamilia()
        FamiliaCMB.DisplayMember = "Descripcion"
        FamiliaCMB.ValueMember = "CodFam"

        If FamiliaCMB.Items.Count = 0 Then
            BuscarBtn.Enabled = False
        Else
            BuscarBtn.Enabled = True
        End If
    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click
        DescFamSel = (FamiliaCMB.SelectedItem).Descripcion
        CargarPatentes(DescFamSel)
    End Sub

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click

        Dim ListaPatentesADenegar As New List(Of FamPatEN)
        Dim Numero As Integer = 1

        If PatentesCLB.CheckedItems.Count = 0 And DenPatentesCLB.CheckedItems.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoPatSel, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If PatenteRN.ObtenerPatentesFamilia((FamiliaCMB.SelectedItem).CodFam) = False And PatentesCLB.CheckedItems.Count = 1 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.MasUnaPat, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ListaPatentesADenegar.Clear()
        For Each item As PatenteEN In DenPatentesCLB.CheckedItems
            Dim UnaPatFam As New FamPatEN
            UnaPatFam.CodPat = item.CodPat
            UnaPatFam.DescPat = item.Descripcion
            UnaPatFam.Activo = True

            ListaPatentesADenegar.Add(UnaPatFam)
        Next

        AsigPat.Clear()
        DenPat.Clear()
        PatNoDenegadas.Clear()

        'Lista Patente para alta
        Dim ListaPatenes As New List(Of FamPatEN)
        Dim CodFamSel As Integer = 0

        CodFamSel = FamiliaCMB.SelectedValue
        DescFamSel = (FamiliaCMB.SelectedItem).Descripcion

        For Each item As PatenteEN In Me.PatentesCLB.CheckedItems
            Dim UnaFamPat As New FamPatEN
            UnaFamPat.CodFam = CodFamSel
            UnaFamPat.CodPat = item.CodPat
            UnaFamPat.DescPat = item.Descripcion

            ListaPatenes.Add(UnaFamPat)
        Next

        Dim FamPat As New FamiliaEN
        FamPat.FamPatL = ListaPatenes

        'Lista Patentes a Denegar
        Dim ListaPatentesBaja As New List(Of FamPatEN)

        For Each item As PatenteEN In DenPatentesCLB.CheckedItems
            Dim UnaFamPat As New FamPatEN
            UnaFamPat.CodFam = CodFamSel
            UnaFamPat.CodPat = item.CodPat
            UnaFamPat.DescPat = item.Descripcion

            ListaPatentesBaja.Add(UnaFamPat)
        Next

        Dim BajaFamPat As New FamiliaEN
        BajaFamPat.FamPatL = ListaPatentesBaja

        'Alta y Baja
        If AccionUsuarioAlta = True And AccionUsuarioBaja = True Then
            Try
                FamiliaRN.AltaFamiliaPatente(FamPat)
                FamiliaRN.BajaFamiliaPatente(DescFamSel, BajaFamPat)
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                FamiliaCMB.DataSource = Nothing

                FamiliaCMB.DataSource = FamiliaRN.CargarFamilia()
                FamiliaCMB.DisplayMember = "Descripcion"
                FamiliaCMB.ValueMember = "CodFam"
                LimpiarCLB()
                Exit Sub
            End Try

            For Each item As PatenteEN In PatentesCLB.CheckedItems
                AsigPat.Append(Numero & ") " & item.Descripcion & Environment.NewLine)
                Numero += 1
            Next

            CargarPatentes(DescFamSel)
            LimpiarCLB()

            Numero = 1
            For Each ItemPat As PatenteEN In DenPatentesCLB.Items
                For Each ItemDen As FamPatEN In ListaPatentesADenegar
                    If ItemPat.CodPat = ItemDen.CodPat Then
                        PatNoDenegadas.Append(Numero & ") " & ItemPat.Descripcion & Environment.NewLine())
                        Numero += 1
                        ItemDen.Activo = False
                    End If
                Next
            Next

            Numero = 1
            For Each item As FamPatEN In ListaPatentesADenegar
                If item.Activo = True Then
                    DenPat.Append(Numero & ") " & item.DescPat & Environment.NewLine)
                    Numero += 1
                End If
            Next

            PanelInferior.Visible = True
            Exit Sub
        End If

        'Alta Solo
        If AccionUsuarioAlta = True And AccionUsuarioBaja = False Then
            If DenPatentesCLB.CheckedItems.Count > 0 And PatentesCLB.CheckedItems.Count > 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoTienePermisoBajaPatFam & Environment.NewLine & My.Resources.ArchivoIdioma.NoTienePermisoBajaPatFam2, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf DenPatentesCLB.CheckedItems.Count > 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoPermisosBajaPatenteFamilia, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                For i As Integer = 0 To DenPatentesCLB.Items.Count - 1
                    DenPatentesCLB.SetItemChecked(i, False)
                Next

                Exit Sub
            End If

            Try
                FamiliaRN.AltaFamiliaPatente(FamPat)
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                FamiliaCMB.DataSource = Nothing

                FamiliaCMB.DataSource = FamiliaRN.CargarFamilia()
                FamiliaCMB.DisplayMember = "Descripcion"
                FamiliaCMB.ValueMember = "CodFam"
                LimpiarCLB()
                Exit Sub
            End Try

            For Each item As PatenteEN In PatentesCLB.CheckedItems
                AsigPat.Append(Numero & ") " & item.Descripcion & Environment.NewLine)
                Numero += 1
            Next

            PanelInferior.Visible = True
            CargarPatentes(DescFamSel)
            LimpiarCLB()

            Exit Sub
        End If

        'Baja Solo
        If AccionUsuarioAlta = False And AccionUsuarioBaja = True Then
            If PatentesCLB.CheckedItems.Count > 0 And DenPatentesCLB.CheckedItems.Count > 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoTienePermisoAltaPatFam & Environment.NewLine & My.Resources.ArchivoIdioma.NoTienePermisoAltaPatFam2, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf PatentesCLB.CheckedItems.Count > 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoPermisosAltaPatenteFamilia, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                For i As Integer = 0 To PatentesCLB.Items.Count - 1
                    PatentesCLB.SetItemChecked(i, False)
                Next

                Exit Sub
            End If

            Try
                FamiliaRN.BajaFamiliaPatente(DescFamSel, BajaFamPat)
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                FamiliaCMB.DataSource = Nothing

                FamiliaCMB.DataSource = FamiliaRN.CargarFamilia()
                FamiliaCMB.DisplayMember = "Descripcion"
                FamiliaCMB.ValueMember = "CodFam"
                LimpiarCLB()
                Exit Sub
            End Try

            CargarPatentes(DescFamSel)
            LimpiarCLB()

            Numero = 1
            For Each ItemPat As PatenteEN In DenPatentesCLB.Items
                For Each ItemDen As FamPatEN In ListaPatentesADenegar
                    If ItemPat.CodPat = ItemDen.CodPat Then
                        PatNoDenegadas.Append(Numero & ") " & ItemPat.Descripcion & Environment.NewLine())
                        Numero += 1
                        ItemDen.Activo = False
                    End If
                Next
            Next

            Numero = 1
            For Each item As FamPatEN In ListaPatentesADenegar
                If item.Activo = True Then
                    DenPat.Append(Numero & ") " & item.DescPat & Environment.NewLine)
                    Numero += 1
                End If
            Next

            PanelInferior.Visible = True
            Exit Sub
        End If
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Private Sub ErrorLbl_Click(sender As System.Object, e As System.EventArgs) Handles InformacionLbl.Click
        Dim frm As New ResultadoFamPatUsu

        frm.TituloAltaLbl.Text = My.Resources.ArchivoIdioma.AltaFamPat & DescFamSel
        frm.LblAlta.Text = AsigPat.ToString()

        frm.TituloErrorLbl.Text = My.Resources.ArchivoIdioma.NoTienePatente1 & DescFamSel
        frm.LblError.Text = DenPat.ToString()

        frm.TituloNoAltaPermisosLbl.Text = My.Resources.ArchivoIdioma.PatentesNoEliminadasFam
        frm.LblErrorEliminarPermisos.Text = PatNoDenegadas.ToString()
        frm.CausaLbl.Text = My.Resources.ArchivoIdioma.CausaFam

        '
        If DenPat.Length > 0 Then
            frm.AdvertenciaPanel.Visible = True
        Else
            frm.AdvertenciaPanel.Visible = False
        End If

        '
        If AsigPat.Length > 0 Then
            frm.InformacionPanel.Visible = True
        Else
            frm.InformacionPanel.Visible = False
        End If

        '
        If PatNoDenegadas.Length > 0 Then
            frm.AdvertenciaPanelPatentes.Visible = True
        Else
            frm.AdvertenciaPanelPatentes.Visible = False
        End If

        frm.ShowDialog()

        PanelInferior.Visible = False
    End Sub

#Region "Validaciones y Cargas"

    Sub LimpiarCLB()
        For i As Integer = 0 To PatentesCLB.Items.Count - 1
            PatentesCLB.SetItemChecked(i, False)
        Next

        For i As Integer = 0 To DenPatentesCLB.Items.Count - 1
            DenPatentesCLB.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub FamiliaPatente_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.PatFamSMI.Enabled = True
    End Sub

    Private Sub FamiliaPatente_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "130")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub CargarPatentes(ByVal Fam As String)
        Try
            PatentesCLB.DataSource = PatenteRN.CargarNoPatentesFamilia(Fam)
            PatentesCLB.DisplayMember = "Descripcion"
            PatentesCLB.ValueMember = "CodPat"
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            FamiliaCMB.DataSource = Nothing

            FamiliaCMB.DataSource = FamiliaRN.CargarFamilia()
            FamiliaCMB.DisplayMember = "Descripcion"
            FamiliaCMB.ValueMember = "CodFam"

            Exit Sub
        End Try

        DenPatentesCLB.DataSource = PatenteRN.CargarPatentesFamilia(Fam)
        DenPatentesCLB.DisplayMember = "Descripcion"
        DenPatentesCLB.ValueMember = "CodPat"

        AceptarBtn.Enabled = True
    End Sub

#End Region

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.PatenteFamiliaFrm

        FamiliaLbl.Text = My.Resources.ArchivoIdioma.FamiliaLbl
        PatentesNoGB.Text = My.Resources.ArchivoIdioma.PatentesNoFamLbl
        PatentesGB.Text = My.Resources.ArchivoIdioma.PatentesFamLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

        InformacionLbl.Text = My.Resources.ArchivoIdioma.ResultadoOperacion
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(FamiliaCMB, My.Resources.ArchivoIdioma.TTFamiliaCMB)
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarFam)
        ControlesTP.SetToolTip(PatentesCLB, My.Resources.ArchivoIdioma.TTPatentesNoFam)
        ControlesTP.SetToolTip(DenPatentesCLB, My.Resources.ArchivoIdioma.TTPatentesFam)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAltaBajaPatFam)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

End Class