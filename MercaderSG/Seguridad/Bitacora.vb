Imports Negocios
Imports Entidades
Imports Excepciones
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.ComponentModel

Public Class Bitacora
    Private ListaBitacora As New List(Of BitacoraEN)
    Private ListaBitacoraTemp As New List(Of BitacoraEN)
    Private ListaBitacoraTempGral As New List(Of BitacoraEN)
    Private ListaBitacoraActualOrdenar As New List(Of BitacoraEN)

    Public FC As New FiltroCompleto
    Public FU As New FiltroUsuario
    Public FF As New FiltroFecha
    Public FCriti As New FiltroCriticidad

    Public NroPag As Integer = 0
    Private CantidadPaginas As Integer = 0

    Public PaginaNro As String = My.Resources.ArchivoIdioma.InfoPaginaPag
    Public PaginaDe As String = My.Resources.ArchivoIdioma.InfoPaginaDe
    Public PaginaRegistros As String = My.Resources.ArchivoIdioma.InfoPaginaReg

    Private Sub Bitacora_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()

        AplicarIdioma()
        CargarTT()

        Dim ListaUsuarios As New List(Of UsuarioEN)
        Dim UsuarioVacio As New UsuarioEN
        UsuarioVacio.CodUsu = 0
        UsuarioVacio.Usuario = ""

        Dim UsuarioSistema As New UsuarioEN
        UsuarioSistema.CodUsu = 9999
        UsuarioSistema.Usuario = "Sistema"

        ListaUsuarios = UsuarioRN.CargarUsuario()

        ListaUsuarios.Insert(0, UsuarioVacio)
        ListaUsuarios.Insert(1, UsuarioSistema)

        FC.UsuarioCMB.DataSource = ListaUsuarios
        FC.UsuarioCMB.DisplayMember = "Usuario"
        FC.UsuarioCMB.ValueMember = "CodUsu"

        FU.UsuarioCMB.DataSource = ListaUsuarios
        FU.UsuarioCMB.DisplayMember = "Usuario"
        FU.UsuarioCMB.ValueMember = "CodUsu"

        FC.CriticidadCMB.DataSource = CargarComboCriticidad()
        FC.CriticidadCMB.DisplayMember = "Descripcion"
        FC.CriticidadCMB.ValueMember = "CodCriti"

        FCriti.CriticidadCMB.DataSource = CargarComboCriticidad()
        FCriti.CriticidadCMB.DisplayMember = "Descripcion"
        FCriti.CriticidadCMB.ValueMember = "CodCriti"

        FCriti.CriticidadCMB.SelectedValue = 0
        FCriti.CriticidadCMB.SelectedValue = 0
        FC.UsuarioCMB.SelectedValue = 0
        FU.UsuarioCMB.SelectedValue = 0

        FiltroCMB.Items.Add(My.Resources.ArchivoIdioma.CompletoLbl)
        FiltroCMB.Items.Add(My.Resources.ArchivoIdioma.UsuarioLbl)
        FiltroCMB.Items.Add(My.Resources.ArchivoIdioma.CriticidadLbl)
        FiltroCMB.Items.Add(My.Resources.ArchivoIdioma.FechaLbl)

        FiltroCMB.SelectedIndex = 0

        If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        End If

        ListaBitacoraTempGral.AddRange(ListaBitacora)

        AddHandler FiltroCompleto.BotonClick, AddressOf BotonFiltroCompleto
        AddHandler FiltroUsuario.BotonClick, AddressOf BotonFiltroUsuario
        AddHandler FiltroCriticidad.BotonClick, AddressOf BotonFiltroCriticidad
        AddHandler FiltroFecha.BotonClick, AddressOf BotonFiltroFecha
    End Sub

    Public Function CargarComboCriticidad() As List(Of CriticidadEN)
        Dim ListaCriticidad As New List(Of CriticidadEN)
        Dim CritiVacia As New CriticidadEN
        CritiVacia.CodCriti = 0
        CritiVacia.Descripcion = ""
        ListaCriticidad.Add(CritiVacia)

        Dim DatosCriti1 As New CriticidadEN
        DatosCriti1.CodCriti = 1
        DatosCriti1.Descripcion = My.Resources.ArchivoIdioma.CritiAlta
        ListaCriticidad.Add(DatosCriti1)

        Dim DatosCriti2 As New CriticidadEN
        DatosCriti2.CodCriti = 2
        DatosCriti2.Descripcion = My.Resources.ArchivoIdioma.CritiMedia
        ListaCriticidad.Add(DatosCriti2)

        Dim DatosCrit3 As New CriticidadEN
        DatosCrit3.CodCriti = 3
        DatosCrit3.Descripcion = My.Resources.ArchivoIdioma.CritiBaja
        ListaCriticidad.Add(DatosCrit3)

        Return ListaCriticidad
    End Function

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        ListaBitacora = BitacoraRN.CargarBitacora()

        For i As Integer = 0 To ListaBitacora.Count - 1
            If BGW.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                BGW.ReportProgress(100 * i / ListaBitacora.Count)
            End If
        Next
    End Sub

    Private Sub BGW_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW.ProgressChanged
        BarraProgreso.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

        Parte1Lbl.Text = String.Empty
        Parte2Lbl.Text = String.Empty
        InfoPagLbl.Spring = True

        InfoPagina(1)

        BitacoraDG.AutoGenerateColumns = False
        BitacoraDG.DataSource = PaginaSig(NroPag)

        BarraProgreso.ProgressBar1.Value = 0
        BarraProgreso.Close()
    End Sub


#Region "Busquedas"

    Private Sub BotonFiltroCompleto()

        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoEventos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Fechas solo
        If FC.UsuarioCMB.SelectedValue = 0 And FC.CriticidadCMB.SelectedValue = 0 Then
            NroPag = 0
            ListaBitacoraTemp.Clear()
            ListaBitacoraTemp.AddRange(ListaBitacora)

            ListaBitacora.Clear()

            Dim FechaDesdeCom As Date = FC.DesdeComDTP.Value
            Dim FechaHastaCom As Date = FC.HastaComDTP.Value
            ListaBitacora = BitacoraRN.CargarBitacora(FechaDesdeCom, FechaHastaCom)

            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

            InfoPagina(1)

            BitacoraDG.DataSource = Nothing
            BitacoraDG.AutoGenerateColumns = False
            BitacoraDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If

            If BitacoraDG.Rows.Count = 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteEventosBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LimpiarControles()

                ListaBitacora.Clear()
                ListaBitacora.AddRange(ListaBitacoraTempGral)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
                InfoPagina(1)
                BitacoraDG.DataSource = Nothing
                BitacoraDG.DataSource = PaginaSig(NroPag)
            End If

            Exit Sub
        End If

        'Criticidad + Fechas

        If FC.UsuarioCMB.SelectedValue = 0 Then
            NroPag = 0
            ListaBitacoraTemp.Clear()
            ListaBitacoraTemp.AddRange(ListaBitacora)

            ListaBitacora.Clear()
            Dim CritiCom As Integer = CInt(FC.CriticidadCMB.SelectedValue)
            Dim FechaDesdeCom As Date = FC.DesdeComDTP.Value
            Dim FechaHastaCom As Date = FC.HastaComDTP.Value
            ListaBitacora = BitacoraRN.CargarBitacora(CritiCom, FechaDesdeCom, FechaHastaCom)

            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

            InfoPagina(1)

            BitacoraDG.DataSource = Nothing
            BitacoraDG.AutoGenerateColumns = False
            BitacoraDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If

            If BitacoraDG.Rows.Count = 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteEventosBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                LimpiarControles()
                ListaBitacora.Clear()
                ListaBitacora.AddRange(ListaBitacoraTempGral)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
                InfoPagina(1)
                BitacoraDG.DataSource = Nothing
                BitacoraDG.DataSource = PaginaSig(NroPag)
            End If


            Exit Sub
        End If

        'Usuario + Fechas

        If FC.CriticidadCMB.SelectedValue = 0 Then
            NroPag = 0
            ListaBitacoraTemp.Clear()
            ListaBitacoraTemp.AddRange(ListaBitacora)

            ListaBitacora.Clear()
            Dim UsuarioCom As String = (FC.UsuarioCMB.SelectedItem).Usuario
            Dim FechaDesdeCom As Date = FC.DesdeComDTP.Value
            Dim FechaHastaCom As Date = FC.HastaComDTP.Value
            ListaBitacora = BitacoraRN.CargarBitacora(UsuarioCom, FechaDesdeCom, FechaHastaCom)

            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

            InfoPagina(1)

            BitacoraDG.DataSource = Nothing
            BitacoraDG.AutoGenerateColumns = False
            BitacoraDG.DataSource = PaginaSig(NroPag)

            If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
                DeshabilitarPaginacion()
            Else
                HabilitarPaginacion()
            End If

            If BitacoraDG.Rows.Count = 0 Then
                MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteEventosBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LimpiarControles()

                ListaBitacora.Clear()
                ListaBitacora.AddRange(ListaBitacoraTempGral)

                NroPag = 0
                CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
                InfoPagina(1)
                BitacoraDG.DataSource = Nothing
                BitacoraDG.DataSource = PaginaSig(NroPag)
            End If


            Exit Sub
        End If

        NroPag = 0
        ListaBitacoraTemp.Clear()
        ListaBitacoraTemp.AddRange(ListaBitacora)

        ListaBitacora.Clear()

        Dim Usuario As String = (FC.UsuarioCMB.SelectedItem).Usuario
        Dim Criticidad As Integer = CInt(FC.CriticidadCMB.SelectedValue)
        Dim FechaDesde As Date = FC.DesdeComDTP.Value
        Dim FechaHasta As Date = FC.HastaComDTP.Value
        ListaBitacora = BitacoraRN.CargarBitacora(Usuario, Criticidad, FechaDesde, FechaHasta)

        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

        InfoPagina(1)

        BitacoraDG.DataSource = Nothing
        BitacoraDG.AutoGenerateColumns = False
        BitacoraDG.DataSource = PaginaSig(NroPag)

        If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteEventosBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LimpiarControles()

            ListaBitacora.Clear()
            ListaBitacora.AddRange(ListaBitacoraTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
            InfoPagina(1)
            BitacoraDG.DataSource = Nothing
            BitacoraDG.DataSource = PaginaSig(NroPag)
        End If
    End Sub

    Private Sub BotonFiltroUsuario()
        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoEventos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        NroPag = 0
        ListaBitacoraTemp.Clear()
        ListaBitacoraTemp.AddRange(ListaBitacora)

        ListaBitacora.Clear()
        Dim Usuario As String = (FU.UsuarioCMB.SelectedItem).Usuario
        ListaBitacora = BitacoraRN.CargarBitacora(Usuario)

        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

        InfoPagina(1)

        BitacoraDG.DataSource = Nothing
        BitacoraDG.AutoGenerateColumns = False
        BitacoraDG.DataSource = PaginaSig(NroPag)

        If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteEventosBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LimpiarControles()

            ListaBitacora.Clear()
            ListaBitacora.AddRange(ListaBitacoraTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
            InfoPagina(1)
            BitacoraDG.DataSource = Nothing
            BitacoraDG.DataSource = PaginaSig(NroPag)
        End If
    End Sub

    Private Sub BotonFiltroCriticidad()
        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoEventos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        NroPag = 0
        ListaBitacoraTemp.Clear()
        ListaBitacoraTemp.AddRange(ListaBitacora)

        ListaBitacora.Clear()
        Dim Criticidad As Integer = CInt(FCriti.CriticidadCMB.SelectedValue)
        ListaBitacora = BitacoraRN.CargarBitacora(Criticidad)

        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

        InfoPagina(1)

        BitacoraDG.DataSource = Nothing
        BitacoraDG.AutoGenerateColumns = False
        BitacoraDG.DataSource = PaginaSig(NroPag)

        If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteEventosBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LimpiarControles()

            ListaBitacora.Clear()
            ListaBitacora.AddRange(ListaBitacoraTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
            InfoPagina(1)
            BitacoraDG.DataSource = Nothing
            BitacoraDG.DataSource = PaginaSig(NroPag)
        End If
    End Sub

    Private Sub BotonFiltroFecha()
        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoEventos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        NroPag = 0
        ListaBitacoraTemp.Clear()
        ListaBitacoraTemp.AddRange(ListaBitacora)

        ListaBitacora.Clear()

        Dim FechaDesde As Date = FF.DesdeDTP.Value
        Dim FechaHasta As Date = FF.HastaDTP.Value
        ListaBitacora = BitacoraRN.CargarBitacora(FechaDesde, FechaHasta)

        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))

        InfoPagina(1)

        BitacoraDG.DataSource = Nothing
        BitacoraDG.AutoGenerateColumns = False
        BitacoraDG.DataSource = PaginaSig(NroPag)

        If CantidadPaginas = 1 Or BitacoraDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        If BitacoraDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteEventosBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LimpiarControles()

            ListaBitacora.Clear()
            ListaBitacora.AddRange(ListaBitacoraTempGral)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
            InfoPagina(1)
            BitacoraDG.DataSource = Nothing
            BitacoraDG.DataSource = PaginaSig(NroPag)
        End If
    End Sub

#End Region

#Region "Diseño"

    Private Sub FiltroCMB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles FiltroCMB.SelectedIndexChanged
        Select Case FiltroCMB.SelectedItem
            Case My.Resources.ArchivoIdioma.CompletoLbl
                LimpiarControles()
                PanelMedio.Controls.Clear()
                PanelMedio.Controls.Add(FC)
            Case My.Resources.ArchivoIdioma.UsuarioLbl
                LimpiarControles()
                PanelMedio.Controls.Clear()
                PanelMedio.Controls.Add(FU)
            Case My.Resources.ArchivoIdioma.CriticidadLbl
                LimpiarControles()
                PanelMedio.Controls.Clear()
                PanelMedio.Controls.Add(FCriti)
            Case My.Resources.ArchivoIdioma.FechaLbl
                LimpiarControles()
                PanelMedio.Controls.Clear()
                PanelMedio.Controls.Add(FF)
        End Select
    End Sub

    Sub HabilitarPaginacion()
        PrimeroBtn.Enabled = True
        SiguienteBtn.Enabled = True
        UltimoBtn.Enabled = True
        AnteriorBtn.Enabled = True
    End Sub

    Sub DeshabilitarPaginacion()
        PrimeroBtn.Enabled = False
        SiguienteBtn.Enabled = False
        UltimoBtn.Enabled = False
        AnteriorBtn.Enabled = False
    End Sub

    Private Sub Bitacora_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Principal.BitacoraSMI.Enabled = True
    End Sub

    Private Sub Bitacora_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim pathchm As String = Path.Combine(Application.StartupPath, "Ayuda.chm")
            Help.ShowHelp(Me, pathchm, HelpNavigator.TopicId, "106")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.E Then
            ExportarAXLSToolStripMenuItem.PerformClick()
        End If

        If e.KeyData = Keys.Control + Keys.D Then
            DepurarBtn.PerformClick()
        End If
    End Sub

    Private Sub LimpiarControles()
        'Usu
        FU.MensajeTT.Hide(FU.UsuarioCMB)
        FU.UsuarioCMB.SelectedValue = 0
        'Com
        FC.ErrorP.SetError(FC.UsuarioCMB, "")
        FC.ErrorP.SetError(FC.DesdeComDTP, "")
        FC.ErrorP.SetError(FC.CriticidadCMB, "")
        FC.CriticidadCMB.SelectedValue = 0
        FC.UsuarioCMB.SelectedValue = 0
        'Criti
        FCriti.MensajeTT.Hide(FCriti.CriticidadCMB)
        FCriti.CriticidadCMB.SelectedValue = 0
        'Fecha
        FF.ErrorP.SetError(FF.DesdeDTP, "")
    End Sub

#End Region

#Region "Paginacion"

    Function PaginaSig(NroPagActual As Integer) As List(Of BitacoraEN)
        NroPag += 1

        Dim ListaAux As New List(Of BitacoraEN)
        For Each item As BitacoraEN In ListaBitacora.Paginacion(NroPag)
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = item.Descripcion
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaAux.Add(UnEvento)
        Next

        Return ListaAux
    End Function

    Function PaginaAnt(NroPagActual As Integer) As List(Of BitacoraEN)
        NroPag -= 1

        Dim ListaAux As New List(Of BitacoraEN)
        For Each item As BitacoraEN In ListaBitacora.Paginacion(NroPag)
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = item.Descripcion
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaAux.Add(UnEvento)
        Next

        Return ListaAux
    End Function

    Private Sub SiguienteBtn_Click(sender As System.Object, e As System.EventArgs) Handles SiguienteBtn.Click
        If NroPag > CantidadPaginas - 1 Then
            SiguienteBtn.Enabled = False
            UltimoBtn.Enabled = False
        Else
            PrimeroBtn.Enabled = True
            AnteriorBtn.Enabled = True

            BitacoraDG.DataSource = Nothing
            BitacoraDG.DataSource = PaginaSig(NroPag)

            InfoPagina(NroPag)
        End If
    End Sub

    Private Sub AnteriorBtn_Click(sender As System.Object, e As System.EventArgs) Handles AnteriorBtn.Click
        If NroPag = 1 Then
            PrimeroBtn.Enabled = False
            AnteriorBtn.Enabled = False
        Else
            SiguienteBtn.Enabled = True
            UltimoBtn.Enabled = True

            BitacoraDG.DataSource = Nothing
            BitacoraDG.DataSource = PaginaAnt(NroPag)

            InfoPagina(NroPag)
        End If
    End Sub

    Private Sub PrimeroBtn_Click(sender As System.Object, e As System.EventArgs) Handles PrimeroBtn.Click
        NroPag = 0

        PrimeroBtn.Enabled = False
        AnteriorBtn.Enabled = False

        SiguienteBtn.Enabled = True
        UltimoBtn.Enabled = True

        BitacoraDG.DataSource = Nothing
        BitacoraDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub UltimoBtn_Click(sender As System.Object, e As System.EventArgs) Handles UltimoBtn.Click
        NroPag = CantidadPaginas - 1

        SiguienteBtn.Enabled = False
        UltimoBtn.Enabled = False

        PrimeroBtn.Enabled = True
        AnteriorBtn.Enabled = True

        BitacoraDG.DataSource = Nothing
        BitacoraDG.DataSource = PaginaSig(NroPag)

        InfoPagina(NroPag)
    End Sub

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        If BitacoraDG.Rows.Count = 0 Then
            DeshabilitarPaginacion()
            Exit Sub
        End If

        If CantidadPaginas = 1 Then
            DeshabilitarPaginacion()
        Else
            HabilitarPaginacion()
        End If

        ListaBitacora.Clear()
        ListaBitacora.AddRange(ListaBitacoraTempGral)

        NroPag = 0
        CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
        InfoPagina(1)
        BitacoraDG.DataSource = Nothing
        BitacoraDG.DataSource = PaginaSig(NroPag)
    End Sub

    Sub InfoPagina(NroPag As Integer)
        InfoPagLbl.Text = PaginaNro & " " & NroPag & " " & PaginaDe & " " & CantidadPaginas & " " & PaginaRegistros & " " & ListaBitacora.Count
        InfoPagLbl.TextAlign = ContentAlignment.MiddleCenter
    End Sub

#End Region

#Region "Exportar Datos"
    Private Sub ExportarAXLSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarAXLSToolStripMenuItem.Click
        If BitacoraDG.RowCount > 0 Then

            Dim Sfd As New SaveFileDialog()
            Sfd.Filter = "Excel (*.xls)|*.xls"
            Sfd.FileName = My.Resources.ArchivoIdioma.FileNameBitacoraPdfXls

            If Sfd.ShowDialog() = DialogResult.OK Then

                Dim App As New Excel.Application
                Dim WB As Excel.Workbook
                Dim WS As New Excel.Worksheet

                WB = App.Workbooks.Add()

                WS = WB.ActiveSheet

                For i As Integer = 1 To BitacoraDG.Columns.Count
                    WS.Cells(1, i) = BitacoraDG.Columns(i - 1).HeaderText
                Next

                For i As Integer = 0 To BitacoraDG.Rows.Count - 1
                    For j As Integer = 0 To BitacoraDG.Columns.Count - 1
                        WS.Cells(i + 2, j + 1) = BitacoraDG.Rows(i).Cells(j).Value.ToString()
                        WS.Cells(i + 2, 1).Font.Color = Color.Blue
                    Next
                Next

                With WS
                    With .Range(.Cells(1, 1), .Cells(1, BitacoraDG.ColumnCount)).Font
                        .Color = Color.White
                        .Bold = 1
                        .Size = 12
                    End With
                    .Range(.Cells(1, 1), .Cells(1, BitacoraDG.ColumnCount)).Interior.Color = Color.Black
                    .Columns.AutoFit()
                    .Columns.HorizontalAlignment = 2
                End With

                WB.SaveAs(Sfd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)

                WB.Close()
                Process.Start(Sfd.FileName)
            End If

        Else
            MessageBox.Show(My.Resources.ArchivoIdioma.NoRegExportar, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

#End Region

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.BitacoraFrm

        FiltroLbl.Text = My.Resources.ArchivoIdioma.FiltroLbl

        RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
        CodBitCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        FechaCAB.HeaderText = My.Resources.ArchivoIdioma.FechaLbl
        DescripcionCAB.HeaderText = My.Resources.ArchivoIdioma.DescripcionLbl
        CriticidadCAB.HeaderText = My.Resources.ArchivoIdioma.CriticidadLbl
        UsuarioCAB.HeaderText = My.Resources.ArchivoIdioma.UsuarioLbl

        DepurarBtn.Text = My.Resources.ArchivoIdioma.DepurarBitacora
    End Sub


    Private Sub CargarTT()
        ControlesTP.SetToolTip(FiltroCMB, My.Resources.ArchivoIdioma.TTFiltroBitacora)
        ControlesTP.SetToolTip(SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
        ControlesTP.SetToolTip(AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
        ControlesTP.SetToolTip(UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
        ControlesTP.SetToolTip(PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(BitacoraDG, My.Resources.ArchivoIdioma.TTListaBitacora)
    End Sub

#End Region

    Private Sub DepurarBtn_Click(sender As System.Object, e As System.EventArgs) Handles DepurarBtn.Click
        Dim ListaRegistros As New List(Of BitacoraEN)

        For Each Fila As DataGridViewRow In BitacoraDG.SelectedRows
            Dim Bitacora As New BitacoraEN
            Bitacora.CodBit = Fila.Cells(0).Value
            Bitacora.Fecha = Fila.Cells(1).Value
            Bitacora.Descripcion = Fila.Cells(2).Value
            Bitacora.Criticidad = Fila.Cells(3).Value
            Bitacora.Usuario = Fila.Cells(4).Value
            ListaRegistros.Add(Bitacora)
        Next

        Try
            BitacoraRN.DepurarBitacora(ListaRegistros)
        Catch ex As InformationException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ListaBitacora.Clear()
            ListaBitacora = BitacoraRN.CargarBitacora()

            ListaBitacoraTempGral.Clear()
            ListaBitacoraTempGral.AddRange(ListaBitacora)

            NroPag = 0
            CantidadPaginas = Math.Ceiling(Convert.ToDouble(ListaBitacora.Count / 25))
            BitacoraDG.DataSource = Nothing
            BitacoraDG.DataSource = PaginaSig(NroPag)

            If BitacoraDG.Rows.Count > 0 Then
                InfoPagina(1)
            Else
                InfoPagina(0)
            End If
        End Try

    End Sub

    Private Sub BitacoraDG_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles BitacoraDG.ColumnHeaderMouseClick
        Dim so As SortOrder = SortOrder.None

        ListaBitacoraActualOrdenar.Clear()
        For Each fila As DataGridViewRow In BitacoraDG.Rows
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = fila.Cells(0).Value
            UnEvento.Fecha = fila.Cells(1).Value
            UnEvento.Descripcion = fila.Cells(2).Value
            UnEvento.Criticidad = fila.Cells(3).Value
            UnEvento.Usuario = fila.Cells(4).Value

            ListaBitacoraActualOrdenar.Add(UnEvento)
        Next

        If BitacoraDG.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.None OrElse BitacoraDG.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.Ascending Then
            so = SortOrder.Descending
        Else
            so = SortOrder.Ascending
        End If
        'set SortGlyphDirection after databinding otherwise will always be none 
        Sort(BitacoraDG.Columns(e.ColumnIndex).Name, so)
        BitacoraDG.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = so
    End Sub

    Private Sub Sort(column As String, sortOrder__1 As SortOrder)
        Select Case column
            Case "FechaCAB"
                If True Then
                    If sortOrder__1 = SortOrder.Ascending Then
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderBy(Function(x) x.Fecha).ToList()
                    Else
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderByDescending(Function(x) x.Fecha).ToList()
                    End If
                    Exit Select
                End If
            Case "DescripcionCAB"
                If True Then
                    If sortOrder__1 = SortOrder.Ascending Then
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderBy(Function(x) x.Descripcion).ToList()
                    Else
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderByDescending(Function(x) x.Descripcion).ToList()
                    End If
                    Exit Select
                End If
            Case "CriticidadCAB"
                If True Then
                    If sortOrder__1 = SortOrder.Ascending Then
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderBy(Function(x) x.Criticidad).ToList()
                    Else
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderByDescending(Function(x) x.Criticidad).ToList()
                    End If
                    Exit Select
                End If
            Case "UsuarioCAB"
                If True Then
                    If sortOrder__1 = SortOrder.Ascending Then
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderBy(Function(x) x.Usuario).ToList()
                    Else
                        BitacoraDG.DataSource = ListaBitacoraActualOrdenar.OrderByDescending(Function(x) x.Usuario).ToList()
                    End If
                    Exit Select
                End If
        End Select

    End Sub

End Class


