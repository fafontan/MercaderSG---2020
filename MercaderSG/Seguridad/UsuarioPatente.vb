Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.Text
Imports System.IO

Public Class UsuarioPatente
    Private AsigPat As New StringBuilder
    Private DenPat As New StringBuilder
    Private PatNoDenegadas As New StringBuilder
    Private UsuAut As Autenticar = Autenticar.Instancia()

    Private UsuSel As String

#Region "Permisos"

    Private AccionUsuarioAlta As Boolean = False
    Private AccionUsuarioBaja As Boolean = False

    Private Sub CargarPermisos()
        If PermisoOK(37) Then
            AccionUsuarioAlta = True
        End If

        If PermisoOK(38) Then
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

    Private Sub AceptarBtn_Click(sender As System.Object, e As System.EventArgs) Handles AceptarBtn.Click
        Dim ListaPatentesADenegar As New List(Of PatUsuEN)
        Dim Numero As Integer = 1

        If DenPatentesCLB.CheckedItems.Count = 0 And PatentesCLB.CheckedItems.Count = 0 And PatDenegadasCLB.CheckedItems.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoPatSel, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If UsuAut.UsuarioLogueado = (UsuariosCMB.SelectedItem).Usuario And AccionUsuarioAlta = True And PatDenegadasCLB.CheckedItems.Count > 0 And PatentesCLB.CheckedItems.Count > 0 Or _
            UsuAut.UsuarioLogueado = (UsuariosCMB.SelectedItem).Usuario And AccionUsuarioAlta = True And PatDenegadasCLB.CheckedItems.Count > 0 Or _
            UsuAut.UsuarioLogueado = (UsuariosCMB.SelectedItem).Usuario And AccionUsuarioAlta = True And PatentesCLB.CheckedItems.Count > 0 Then

            MessageBox.Show(My.Resources.ArchivoIdioma.MismoUsuarioAltaPatentes, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            For i As Integer = 0 To PatentesCLB.Items.Count - 1
                PatentesCLB.SetItemChecked(i, False)
            Next

            For i As Integer = 0 To PatDenegadasCLB.Items.Count - 1
                PatDenegadasCLB.SetItemChecked(i, False)
            Next

            Exit Sub
        End If

        ListaPatentesADenegar.Clear()
        For Each item As PatenteEN In DenPatentesCLB.CheckedItems
            Dim UnaPatUsu As New PatUsuEN
            UnaPatUsu.CodPat = item.CodPat
            UnaPatUsu.DescPat = item.Descripcion
            UnaPatUsu.Activo = True

            ListaPatentesADenegar.Add(UnaPatUsu)
        Next

        AsigPat.Clear()
        DenPat.Clear()
        PatNoDenegadas.Clear()

        'Lista patentes para Alta
        Dim UsuEnc As String
        UsuEnc = Seguridad.Encriptar((UsuariosCMB.SelectedItem).Usuario)
        Dim ListaPatentes As New List(Of PatUsuEN)

        For Each item As PatenteEN In PatentesCLB.CheckedItems
            Dim UnaPatente As New PatUsuEN
            UnaPatente.CodPat = item.CodPat
            UnaPatente.DescPat = item.Descripcion

            ListaPatentes.Add(UnaPatente)
        Next

        For Each item As PatenteEN In PatDenegadasCLB.CheckedItems
            Dim UnaPatente As New PatUsuEN
            UnaPatente.CodPat = item.CodPat
            UnaPatente.DescPat = item.Descripcion

            ListaPatentes.Add(UnaPatente)
        Next

        Dim PatUsu As New UsuarioEN
        PatUsu.UsuPatL = ListaPatentes

        'Lista Patentes a denegar
        Dim ListaPatentesDen As New List(Of PatUsuEN)

        For Each item As PatenteEN In DenPatentesCLB.CheckedItems
            Dim UnaPatente As New PatUsuEN
            UnaPatente.CodPat = item.CodPat
            UnaPatente.DescPat = item.Descripcion

            ListaPatentesDen.Add(UnaPatente)
        Next

        Dim DenPatUsu As New UsuarioEN
        DenPatUsu.UsuPatL = ListaPatentesDen


        'Acciones
        'Alta y Denegar
        If AccionUsuarioAlta = True And AccionUsuarioBaja = True Then
            Try
                UsuarioRN.AltaPatenteUsuario(UsuEnc, PatUsu)
                UsuarioRN.DenegarPatenteUsuario(UsuEnc, DenPatUsu)
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                UsuariosCMB.DataSource = Nothing

                UsuariosCMB.DataSource = UsuarioRN.CargarUsuario()
                UsuariosCMB.DisplayMember = "Usuario"
                UsuariosCMB.ValueMember = "CodUsu"

                LimpiarCLB()
                Exit Sub
            End Try

            For Each item As PatenteEN In PatentesCLB.CheckedItems
                AsigPat.Append(Numero & ") " & item.Descripcion & Environment.NewLine)
                Numero += 1
            Next

            For Each item As PatenteEN In PatDenegadasCLB.CheckedItems
                AsigPat.Append(Numero & ") " & item.Descripcion & Environment.NewLine)
                Numero += 1
            Next

            CargarPatentes(UsuEnc)
            LimpiarCLB()

            Numero = 1
            For Each ItemPat As PatenteEN In DenPatentesCLB.Items
                For Each ItemDen As PatUsuEN In ListaPatentesADenegar
                    If ItemPat.CodPat = ItemDen.CodPat Then
                        PatNoDenegadas.Append(Numero & ") " & ItemPat.Descripcion & Environment.NewLine())
                        Numero += 1
                        ItemDen.Activo = False
                    End If
                Next
            Next

            Numero = 1
            For Each item As PatUsuEN In ListaPatentesADenegar
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
            If DenPatentesCLB.CheckedItems.Count > 0 And PatDenegadasCLB.CheckedItems.Count > 0 And PatentesCLB.CheckedItems.Count > 0 Or _
                DenPatentesCLB.CheckedItems.Count > 0 And PatentesCLB.CheckedItems.Count > 0 Or _
                PatDenegadasCLB.CheckedItems.Count > 0 And DenPatentesCLB.CheckedItems.Count > 0 Then

                MessageBox.Show(My.Resources.ArchivoIdioma.NoTienePermisoBajaPatUsu & Environment.NewLine & My.Resources.ArchivoIdioma.NoTienePermisoBajaPatUsu2, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf DenPatentesCLB.CheckedItems.Count > 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoPermisosBajaPatente, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                For i As Integer = 0 To DenPatentesCLB.Items.Count - 1
                    DenPatentesCLB.SetItemChecked(i, False)
                Next

                Exit Sub
            End If
            Try
                UsuarioRN.AltaPatenteUsuario(UsuEnc, PatUsu)
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                UsuariosCMB.DataSource = Nothing

                UsuariosCMB.DataSource = UsuarioRN.CargarUsuario()
                UsuariosCMB.DisplayMember = "Usuario"
                UsuariosCMB.ValueMember = "CodUsu"

                LimpiarCLB()
                Exit Sub
            End Try

            For Each item As PatenteEN In PatentesCLB.CheckedItems
                AsigPat.Append(Numero & ") " & item.Descripcion & Environment.NewLine)
                Numero += 1
            Next

            For Each item As PatenteEN In PatDenegadasCLB.CheckedItems
                AsigPat.Append(Numero & ") " & item.Descripcion & Environment.NewLine)
                Numero += 1
            Next

            PanelInferior.Visible = True
            CargarPatentes(UsuEnc)
            LimpiarCLB()
            Exit Sub
        End If

        'Denegar Solo
        If AccionUsuarioAlta = False And AccionUsuarioBaja = True Then
            If DenPatentesCLB.CheckedItems.Count > 0 And PatDenegadasCLB.CheckedItems.Count > 0 And PatentesCLB.CheckedItems.Count > 0 Or _
                DenPatentesCLB.CheckedItems.Count > 0 And PatentesCLB.CheckedItems.Count > 0 Or _
                PatDenegadasCLB.CheckedItems.Count > 0 And DenPatentesCLB.CheckedItems.Count > 0 Then

                MessageBox.Show(My.Resources.ArchivoIdioma.NoTienePermisoAltaPatUsu & Environment.NewLine & My.Resources.ArchivoIdioma.NoTienePermisoAltaPatUsu2, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf PatentesCLB.CheckedItems.Count > 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoPermisosAltaPatente, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                For i As Integer = 0 To PatentesCLB.Items.Count - 1
                    PatentesCLB.SetItemChecked(i, False)
                Next

                Exit Sub
            ElseIf PatDenegadasCLB.CheckedItems.Count > 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoPermisosAltaPatente, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                For i As Integer = 0 To PatentesCLB.Items.Count - 1
                    PatDenegadasCLB.SetItemChecked(i, False)
                Next

                Exit Sub
            End If

            Try
                UsuarioRN.DenegarPatenteUsuario(UsuEnc, DenPatUsu)
            Catch ex As WarningException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                UsuariosCMB.DataSource = Nothing

                UsuariosCMB.DataSource = UsuarioRN.CargarUsuario()
                UsuariosCMB.DisplayMember = "Usuario"
                UsuariosCMB.ValueMember = "CodUsu"

                LimpiarCLB()
                Exit Sub
            End Try

            CargarPatentes(UsuEnc)
            LimpiarCLB()

            Numero = 1
            For Each ItemPat As PatenteEN In DenPatentesCLB.Items
                For Each ItemDen As PatUsuEN In ListaPatentesADenegar
                    If ItemPat.CodPat = ItemDen.CodPat Then
                        PatNoDenegadas.Append(Numero & ") " & ItemPat.Descripcion & Environment.NewLine())
                        Numero += 1
                        ItemDen.Activo = False
                    End If
                Next
            Next

            Numero = 1
            For Each item As PatUsuEN In ListaPatentesADenegar
                If item.Activo = True Then
                    DenPat.Append(Numero & ") " & item.DescPat & Environment.NewLine)
                    Numero += 1
                End If
            Next

            PanelInferior.Visible = True

            Exit Sub
        End If

    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click
        PanelInferior.Visible = False

        Dim UsuEnc As String
        UsuEnc = Seguridad.Encriptar((UsuariosCMB.SelectedItem).Usuario)

        CargarPatentes(UsuEnc)
    End Sub

    Private Sub UsuarioPatente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarTT()
        AplicarIdioma()

        UsuariosCMB.DataSource = UsuarioRN.CargarUsuario()
        UsuariosCMB.DisplayMember = "Usuario"
        UsuariosCMB.ValueMember = "CodUsu"
        AceptarBtn.Enabled = False
        CargarPermisos()
        PanelInferior.Visible = False
    End Sub

    Private Sub CancelarBtn_Click(sender As System.Object, e As System.EventArgs) Handles CancelarBtn.Click
        Me.Close()
    End Sub

    Sub CargarPatentes(ByVal UsuEnc As String)
        Try
            PatentesCLB.DataSource = PatenteRN.CargarPatente(UsuEnc)
            PatentesCLB.DisplayMember = "Descripcion"
            PatentesCLB.ValueMember = "CodPat"
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UsuariosCMB.DataSource = Nothing

            UsuariosCMB.DataSource = UsuarioRN.CargarUsuario()
            UsuariosCMB.DisplayMember = "Usuario"
            UsuariosCMB.ValueMember = "CodUsu"

            Exit Sub
        End Try

        DenPatentesCLB.DataSource = PatenteRN.CargarPatenteUsuario(UsuEnc)
        DenPatentesCLB.DisplayMember = "Descripcion"
        DenPatentesCLB.ValueMember = "CodPat"

        PatDenegadasCLB.DataSource = PatenteRN.CargarPatentesDenegadasUsuario(UsuEnc)
        PatDenegadasCLB.DisplayMember = "Descripcion"
        PatDenegadasCLB.ValueMember = "CodPat"

        AceptarBtn.Enabled = True
    End Sub

    Private Sub InformacionLbl_Click(sender As System.Object, e As System.EventArgs) Handles InformacionLbl.Click
        Dim frm As New ResultadoFamPatUsu

        frm.TituloAltaLbl.Text = My.Resources.ArchivoIdioma.PatOk & (UsuariosCMB.SelectedItem).Usuario
        frm.LblAlta.Text = AsigPat.ToString()

        frm.TituloErrorLbl.Text = My.Resources.ArchivoIdioma.DenegarPatOk
        frm.LblError.Text = DenPat.ToString()

        frm.TituloNoAltaPermisosLbl.Text = My.Resources.ArchivoIdioma.PatentesNoDenegadasUsu
        frm.LblErrorEliminarPermisos.Text = PatNoDenegadas.ToString()
        frm.CausaLbl.Text = My.Resources.ArchivoIdioma.CausaUsu

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

    Private Sub LimpiarCLB()
        For i As Integer = 0 To PatentesCLB.Items.Count - 1
            PatentesCLB.SetItemChecked(i, False)
        Next

        For i As Integer = 0 To PatDenegadasCLB.Items.Count - 1
            PatDenegadasCLB.SetItemChecked(i, False)
        Next

        For i As Integer = 0 To DenPatentesCLB.Items.Count - 1
            DenPatentesCLB.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub UsuarioPatente_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.PatUsuSMI.Enabled = True
    End Sub

    Private Sub UsuarioPatente_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "131")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.UsuarioPatenteFrm

        UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
        PatentesGB.Text = My.Resources.ArchivoIdioma.PatentesUsuLbl
        PatDenegadasGB.Text = My.Resources.ArchivoIdioma.PatentesDenegadasUsu
        DenPatentesGB.Text = My.Resources.ArchivoIdioma.PatentesNoUsuLbl

        AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
        CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

        InformacionLbl.Text = My.Resources.ArchivoIdioma.ResultadoOperacion
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(UsuariosCMB, My.Resources.ArchivoIdioma.TTListaUsuarios)
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarUsuariosPat)
        ControlesTP.SetToolTip(DenPatentesCLB, My.Resources.ArchivoIdioma.TTPatentesNoUsu)
        ControlesTP.SetToolTip(PatDenegadasCLB, My.Resources.ArchivoIdioma.TTPatDenegadasUsu)
        ControlesTP.SetToolTip(PatentesCLB, My.Resources.ArchivoIdioma.TTPatentesUsu)
        ControlesTP.SetToolTip(AceptarBtn, My.Resources.ArchivoIdioma.TTAltaBajaPatUsu)
        ControlesTP.SetToolTip(CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
    End Sub

#End Region

    Private Sub UsuariosCMB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles UsuariosCMB.SelectedIndexChanged
        LimpiarCLB()
    End Sub
End Class