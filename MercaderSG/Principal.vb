Imports Entidades
Imports Servicios
Imports Negocios
Imports System.Text
Imports System.Threading
Imports System.Globalization

Public Class Principal

#Region "Declaraciones"
    Public Shared ListaErrorInt As New List(Of ErrorIntegridadEN)
    Public Shared DtErrorIntegridad As DataTable
    Public Shared DtErrorIntegridadDVV As DataTable

    Private UsuAut As Autenticar = Autenticar.Instancia()

    Private CadenaTablas As New StringBuilder
    Private EstadoIntegridad As Boolean = False
    Private ListaFormsNombres As New List(Of String)
    Private ListaFormsNombresTT As New List(Of String)

    Private GestionCliFrm As New GestionCliente
    Private GestionProvFrm As New GestionProveedor
    Private GestionProdFrm As New GestionProducto
    Private GestionNVFrm As New GestionNV
    Private NVFrm As New NotaVenta
    Private GestionNPFrm As New GestionNP
    Private NPFrm As New NotaPedido
    Private GestionUsuFrm As New GestionUsuario
    Private GestionFamFrm As New GestionFamilia
    Private DesbloquearUsuFrm As New DesbloquearUsuario
    Private ResetearPassFrm As New ResetearContrasena
    Private BackUpFrm As New Backup
    Private RestoreFrm As New Restore
    Private BitacoraFrm As New Bitacora
    Private PatFamFrm As New FamiliaPatente
    Private UsuFamFrm As New UsuarioFamilia
    Private UsuPatFrm As New UsuarioPatente
    Private CambiarPass As New CambiarContrasena
#End Region

#Region "Permisos"

    Private Sub CargarPermisos()

        Me.GenerarNVSMI.Enabled = PermisoOK(18)

        Me.GenerarNPSMI.Enabled = PermisoOK(21)

        Me.DesbloquearUsuarioSMI.Enabled = PermisoOK(29)

        Me.ResetearContrasenaSMI.Enabled = PermisoOK(30)

        Me.BackupSMI.Enabled = PermisoOK(31)

        Me.RestoreSMI.Enabled = PermisoOK(32)

        Me.BitacoraSMI.Enabled = PermisoOK(33)

        Me.UsuFamSMI.Enabled = PermisoOK(36)

        EstadoIntegridad = PermisoOK(39)

    End Sub

    Private Sub HabilitarBotones()
        Dim Contador As Integer = 1
        Dim ListaGestion As New List(Of Integer)

        'GestionCli
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 1 Or fila.Item(0) = 2 Or fila.Item(0) = 3 Or fila.Item(0) = 4 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            GestionClienteSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'GestionProd
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 5 Or fila.Item(0) = 6 Or fila.Item(0) = 7 Or fila.Item(0) = 8 Or fila.Item(0) = 9 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            GestionProductoSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'GestionProv
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 10 Or fila.Item(0) = 11 Or fila.Item(0) = 12 Or fila.Item(0) = 13 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            GestionProveedorSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'GestionNV

        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 14 Or fila.Item(0) = 15 Or fila.Item(0) = 16 Or fila.Item(0) = 17 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            GestionNVSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'GestionNP
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 19 Or fila.Item(0) = 20 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            GestionNPSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'GestionUsu

        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 22 Or fila.Item(0) = 23 Or fila.Item(0) = 24 Or fila.Item(0) = 25 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            GestionUsuarioSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'GestionFam
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 26 Or fila.Item(0) = 27 Or fila.Item(0) = 28 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            GestionFamiliaSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'Patente-Familia
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 34 Or fila.Item(0) = 35 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            PatFamSMI.Enabled = False
        End If

        ListaGestion.Clear()

        'Patente-Usuario
        For Each fila As DataRow In UsuAut.dtPatUsu.Rows
            If fila.Item(0) = 37 Or fila.Item(0) = 38 Then
                ListaGestion.Add(Contador)
            End If
        Next

        If ListaGestion.Count = 0 Then
            PatUsuSMI.Enabled = False
        End If

        ListaGestion.Clear()

        If GenerarNVSMI.Enabled = False And GestionNVSMI.Enabled = False Then
            NotaVentaSMI.Enabled = False
        End If

        If GenerarNPSMI.Enabled = False And GestionNPSMI.Enabled = False Then
            NotaPedidoSMI.Enabled = False
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

    Private Sub ControlarIntegridad()
        If ListaErrorInt.Count > 0 Then

            If EstadoIntegridad = True Then
                RecalcularDVSMI.Enabled = True
            Else
                RecalcularDVSMI.Enabled = False
            End If

            CadenaTablas.Append(My.Resources.ArchivoIdioma.DeshabiltarForms & Environment.NewLine & Environment.NewLine)

            Dim Contador As Integer = 1
            Dim EstadoSistema As Boolean = False
            Dim EstadoMensaje As Boolean = False

            For Each item As ErrorIntegridadEN In ListaErrorInt
                If item.Tabla = "Cliente" Then
                    If GestionClienteSMI.Enabled = True Then
                        GestionClienteSMI.Enabled = False
                        CadenaTablas.Append(Contador & ") " & My.Resources.ArchivoIdioma.GestionClienteFrm & Environment.NewLine)
                        EstadoMensaje = True
                        Contador += 1
                    End If

                    If GenerarNVSMI.Enabled = True Then
                        GenerarNVSMI.Enabled = False
                        CadenaTablas.Append(Contador & ") " & My.Resources.ArchivoIdioma.AltaNotaVentaFrm & Environment.NewLine)
                        EstadoMensaje = True
                        Contador += 1
                    End If
                    Continue For
                End If

                If item.Tabla = "Producto" Or item.Tabla = "Historico_Precio" Then
                    If GestionProductoSMI.Enabled = True Then
                        GestionProductoSMI.Enabled = False
                        CadenaTablas.Append(Contador & ") " & My.Resources.ArchivoIdioma.GestionProductosFrm & Environment.NewLine)
                        EstadoMensaje = True
                        Contador += 1
                    End If

                    If GenerarNPSMI.Enabled = True Then
                        GenerarNPSMI.Enabled = False
                        CadenaTablas.Append(Contador & ") " & My.Resources.ArchivoIdioma.AltaNotaPedidoFrm & Environment.NewLine)
                        EstadoMensaje = True
                        Contador += 1
                    End If

                    If GenerarNVSMI.Enabled = True Then
                        GenerarNVSMI.Enabled = False
                        CadenaTablas.Append(Contador & ") " & My.Resources.ArchivoIdioma.AltaNotaVentaFrm & Environment.NewLine)
                        EstadoMensaje = True
                        Contador += 1
                    End If

                    Continue For
                End If

                If item.Tabla = "Bitacora" Then
                    If BitacoraSMI.Enabled = True Then
                        BitacoraSMI.Enabled = False
                        CadenaTablas.Append(Contador & ") " & My.Resources.ArchivoIdioma.BitacoraFrm & Environment.NewLine)
                        EstadoMensaje = True
                        Contador += 1
                    End If
                    Continue For
                End If

                If item.Tabla = "Usuario" Then
                    If GestionUsuarioSMI.Enabled = True Then
                        GestionUsuarioSMI.Enabled = False
                        CadenaTablas.Append(Contador & ") " & My.Resources.ArchivoIdioma.GestionUsuarioForm & Environment.NewLine)
                        EstadoMensaje = True
                        Contador += 1
                    End If

                    Continue For
                End If

                If item.Tabla = "Usu_Pat" Or item.Tabla = "Usu_Fam" Or item.Tabla = "Fam_Pat" Then
                    If PatUsuSMI.Enabled = True Then
                        PatUsuSMI.Enabled = False
                    End If

                    If PatFamSMI.Enabled = True Then
                        PatFamSMI.Enabled = False
                    End If

                    If UsuFamSMI.Enabled = True Then
                        UsuFamSMI.Enabled = False
                    End If

                    EstadoMensaje = False
                    EstadoSistema = True
                    CadenaTablas.Clear()
                    CadenaTablas.Append(My.Resources.ArchivoIdioma.SistemaBloqueadoCompleto & Environment.NewLine & My.Resources.ArchivoIdioma.SistemaBloqueadoCompleto2)
                    BloquearSistema()
                    Exit For
                End If
            Next

            If EstadoSistema = True Then
                'CadenaTablas.Append(Environment.NewLine & My.Resources.ArchivoIdioma.ErrorIntegridadSistema)
                MessageBox.Show(CadenaTablas.ToString(), My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If EstadoMensaje = True Then
                MessageBox.Show(CadenaTablas.ToString(), My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'If EstadoMensaje = False Then
            '    MessageBox.Show(My.Resources.ArchivoIdioma.HayErrorIntegridad, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    If RecalcularDVSMI.Enabled = True Then
            '        RecalcularDVSMI.PerformClick()
            '    End If
            'End If
        Else
            RecalcularDVSMI.Enabled = False
        End If
    End Sub

#End Region

    Private Sub Principal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each item As Control In Me.Controls
            If TypeOf item Is MdiClient Then
                item.BackColor = Color.WhiteSmoke
            End If
        Next

        AplicarIdioma(True, ListaFormsNombres)

        If UsuAut.dtPatUsu.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.ElUsuario & UsuAut.UsuarioLogueado & My.Resources.ArchivoIdioma.NoPermisosLogin, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BloquearSistema()
        Else
            CargarPermisos()
            HabilitarBotones()

            ControlarIntegridad()
        End If
    End Sub

#Region "Idioma"
    Private Sub AplicarIdioma(Estado As Boolean, ListaForms As List(Of String))
        If Estado Then
            'Principal
            Me.Text = My.Resources.ArchivoIdioma.PrincipalForm
            GestionSMI.Text = My.Resources.ArchivoIdioma.GestionPFrm
            GestionClienteSMI.Text = My.Resources.ArchivoIdioma.ClientePFrm
            GestionProductoSMI.Text = My.Resources.ArchivoIdioma.ProductoPFrm
            GestionProveedorSMI.Text = My.Resources.ArchivoIdioma.ProveedorPFrm
            ComercialSMI.Text = My.Resources.ArchivoIdioma.ComercialPFrm
            NotaPedidoSMI.Text = My.Resources.ArchivoIdioma.NPPFrm
            NotaVentaSMI.Text = My.Resources.ArchivoIdioma.NVPfrm
            GenerarNPSMI.Text = My.Resources.ArchivoIdioma.GenerarNotasPFrm
            GestionNPSMI.Text = My.Resources.ArchivoIdioma.GestionPFrm
            GenerarNVSMI.Text = My.Resources.ArchivoIdioma.GenerarNotasPFrm
            GestionNVSMI.Text = My.Resources.ArchivoIdioma.GestionPFrm
            SistemaSMI.Text = My.Resources.ArchivoIdioma.SistemaPFrm
            GestionUsuarioSMI.Text = My.Resources.ArchivoIdioma.GestionUsuPfrm
            GestionFamiliaSMI.Text = My.Resources.ArchivoIdioma.GestionFamPfrm
            DesbloquearUsuarioSMI.Text = My.Resources.ArchivoIdioma.DesbloquearPfrm
            ResetearContrasenaSMI.Text = My.Resources.ArchivoIdioma.ResetearPfrm
            SeguridadSMI.Text = My.Resources.ArchivoIdioma.SeguridadPfrm
            BackupSMI.Text = My.Resources.ArchivoIdioma.BackupPfrm
            RestoreSMI.Text = My.Resources.ArchivoIdioma.RestorePfrm
            BitacoraSMI.Text = My.Resources.ArchivoIdioma.BitacoraPfrm
            PatFamSMI.Text = My.Resources.ArchivoIdioma.PatFamPfrm
            UsuFamSMI.Text = My.Resources.ArchivoIdioma.UsuFamPfrm
            PatUsuSMI.Text = My.Resources.ArchivoIdioma.PatUsuPfrm
            RecalcularDVSMI.Text = My.Resources.ArchivoIdioma.RecalcularPfrm
            PanelSMI.Text = My.Resources.ArchivoIdioma.PanelPfrm
            IdiomaSMI.Text = My.Resources.ArchivoIdioma.IdiomaPfrm
            EspanolSMI.Text = My.Resources.ArchivoIdioma.EspanolPfrm
            InglesSMI.Text = My.Resources.ArchivoIdioma.InglesPfrm
            CambiarContrasenaSMI.Text = My.Resources.ArchivoIdioma.CambiarPassPfrm
            SalirSMI.Text = My.Resources.ArchivoIdioma.SalirPfrm
        Else
            For Each item As String In ListaForms
                If item = "Principal" Then
                    Me.Text = My.Resources.ArchivoIdioma.PrincipalForm
                    GestionSMI.Text = My.Resources.ArchivoIdioma.GestionPFrm
                    GestionClienteSMI.Text = My.Resources.ArchivoIdioma.ClientePFrm
                    GestionProductoSMI.Text = My.Resources.ArchivoIdioma.ProductoPFrm
                    GestionProveedorSMI.Text = My.Resources.ArchivoIdioma.ProveedorPFrm
                    ComercialSMI.Text = My.Resources.ArchivoIdioma.ComercialPFrm
                    NotaPedidoSMI.Text = My.Resources.ArchivoIdioma.NPPFrm
                    NotaVentaSMI.Text = My.Resources.ArchivoIdioma.NVPfrm
                    GenerarNPSMI.Text = My.Resources.ArchivoIdioma.GenerarNotasPFrm
                    GestionNPSMI.Text = My.Resources.ArchivoIdioma.GestionPFrm
                    GenerarNVSMI.Text = My.Resources.ArchivoIdioma.GenerarNotasPFrm
                    GestionNVSMI.Text = My.Resources.ArchivoIdioma.GestionPFrm
                    SistemaSMI.Text = My.Resources.ArchivoIdioma.SistemaPFrm
                    GestionUsuarioSMI.Text = My.Resources.ArchivoIdioma.GestionUsuPfrm
                    GestionFamiliaSMI.Text = My.Resources.ArchivoIdioma.GestionFamPfrm
                    DesbloquearUsuarioSMI.Text = My.Resources.ArchivoIdioma.DesbloquearPfrm
                    ResetearContrasenaSMI.Text = My.Resources.ArchivoIdioma.ResetearPfrm
                    SeguridadSMI.Text = My.Resources.ArchivoIdioma.SeguridadPfrm
                    BackupSMI.Text = My.Resources.ArchivoIdioma.BackupPfrm
                    RestoreSMI.Text = My.Resources.ArchivoIdioma.RestorePfrm
                    BitacoraSMI.Text = My.Resources.ArchivoIdioma.BitacoraPfrm
                    PatFamSMI.Text = My.Resources.ArchivoIdioma.PatFamPfrm
                    UsuFamSMI.Text = My.Resources.ArchivoIdioma.UsuFamPfrm
                    PatUsuSMI.Text = My.Resources.ArchivoIdioma.PatUsuPfrm
                    RecalcularDVSMI.Text = My.Resources.ArchivoIdioma.RecalcularPfrm
                    PanelSMI.Text = My.Resources.ArchivoIdioma.PanelPfrm
                    IdiomaSMI.Text = My.Resources.ArchivoIdioma.IdiomaPfrm
                    EspanolSMI.Text = My.Resources.ArchivoIdioma.EspanolPfrm
                    InglesSMI.Text = My.Resources.ArchivoIdioma.InglesPfrm
                    CambiarContrasenaSMI.Text = My.Resources.ArchivoIdioma.CambiarPassPfrm
                    SalirSMI.Text = My.Resources.ArchivoIdioma.SalirPfrm
                    Continue For
                End If

                If item = "GestionCliente" Then
                    If (Not (GestionCliFrm.IsHandleCreated)) Then
                        GestionCliFrm = New GestionCliente
                    End If

                    GestionCliFrm.GestionClientesGB.Text = My.Resources.ArchivoIdioma.GestionClienteGB
                    GestionCliFrm.BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
                    GestionCliFrm.BuscarCmb.Items(0) = My.Resources.ArchivoIdioma.CMBCuit
                    GestionCliFrm.BuscarCmb.Items(1) = My.Resources.ArchivoIdioma.CMBRazonSocial
                    GestionCliFrm.IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
                    GestionCliFrm.BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    GestionCliFrm.OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
                    GestionCliFrm.AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarCliBtn
                    GestionCliFrm.ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarCliBtn
                    GestionCliFrm.EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarCliBtn
                    GestionCliFrm.EliminarTelBtn.Text = My.Resources.ArchivoIdioma.EliminarTelBtn

                    GestionCliFrm.RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
                    GestionCliFrm.CodCliCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
                    GestionCliFrm.RazonSocialCAB.HeaderText = My.Resources.ArchivoIdioma.RazonSocialGral
                    GestionCliFrm.CuitCAB.HeaderText = My.Resources.ArchivoIdioma.CuitGral
                    GestionCliFrm.DireccionCAB.HeaderText = My.Resources.ArchivoIdioma.DireccionCAB
                    GestionCliFrm.LocalidadCAB.HeaderText = My.Resources.ArchivoIdioma.LocalidadLbl

                    GestionCliFrm.PaginaNro = My.Resources.ArchivoIdioma.InfoPaginaPag
                    GestionCliFrm.PaginaDe = My.Resources.ArchivoIdioma.InfoPaginaDe
                    GestionCliFrm.PaginaRegistros = My.Resources.ArchivoIdioma.InfoPaginaReg

                    If GestionCliFrm.ClienteDG.Rows.Count = 0 Then
                        GestionCliFrm.InfoPagina(0)
                    Else
                        GestionCliFrm.InfoPagina(GestionCliFrm.NroPag)
                    End If

                    Continue For
                End If

                If item = "GestionProducto" Then
                    If (Not (GestionProdFrm.IsHandleCreated)) Then
                        GestionProdFrm = New GestionProducto
                    End If

                    GestionProdFrm.Text = My.Resources.ArchivoIdioma.GestionProductosFrm

                    GestionProdFrm.GestionProductosGB.Text = My.Resources.ArchivoIdioma.GestionProductosGB
                    GestionProdFrm.BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
                    GestionProdFrm.BuscarCmb.Items(0) = My.Resources.ArchivoIdioma.CMBNombre
                    GestionProdFrm.BuscarCmb.Items(1) = My.Resources.ArchivoIdioma.CMBSector
                    GestionProdFrm.IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
                    GestionProdFrm.BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    GestionProdFrm.OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
                    GestionProdFrm.AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarProdBtn
                    GestionProdFrm.ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarProdBtn
                    GestionProdFrm.EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarProdBtn
                    GestionProdFrm.MasBtn.Text = My.Resources.ArchivoIdioma.MasOpcionesBtn
                    GestionProdFrm.ModificarStockBtn.Text = My.Resources.ArchivoIdioma.ModificarStockBtn
                    GestionProdFrm.ModificarPrecioBtn.Text = My.Resources.ArchivoIdioma.ModificarPrecioBtn

                    GestionProdFrm.RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
                    GestionProdFrm.CodProdCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
                    GestionProdFrm.NombreCAB.HeaderText = My.Resources.ArchivoIdioma.CMBNombre
                    GestionProdFrm.PrecioUnitarioCAB.HeaderText = My.Resources.ArchivoIdioma.Precio
                    GestionProdFrm.CantidadCAB.HeaderText = My.Resources.ArchivoIdioma.Cantidad
                    GestionProdFrm.SectorCAB.HeaderText = My.Resources.ArchivoIdioma.CMBSector

                    GestionProdFrm.PaginaNro = My.Resources.ArchivoIdioma.InfoPaginaPag
                    GestionProdFrm.PaginaDe = My.Resources.ArchivoIdioma.InfoPaginaDe
                    GestionProdFrm.PaginaRegistros = My.Resources.ArchivoIdioma.InfoPaginaReg

                    If GestionProdFrm.ProductosDG.Rows.Count = 0 Then
                        GestionProdFrm.InfoPagina(0)
                    Else
                        GestionProdFrm.InfoPagina(GestionProdFrm.NroPag)
                    End If

                    Continue For
                End If

                If item = "GestionProveedor" Then
                    If (Not (GestionProvFrm.IsHandleCreated)) Then
                        GestionProvFrm = New GestionProveedor
                    End If

                    GestionProvFrm.Text = My.Resources.ArchivoIdioma.GestionProveedorFrm

                    GestionProvFrm.GestionProveedoresGB.Text = My.Resources.ArchivoIdioma.GestionProveedorGB
                    GestionProvFrm.BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
                    GestionProvFrm.BuscarCmb.Items(0) = My.Resources.ArchivoIdioma.CMBCuit
                    GestionProvFrm.BuscarCmb.Items(1) = My.Resources.ArchivoIdioma.CMBRazonSocial
                    GestionProvFrm.IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
                    GestionProvFrm.BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    GestionProvFrm.OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
                    GestionProvFrm.AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarProvBtn
                    GestionProvFrm.ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarProvBtn
                    GestionProvFrm.EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarProvBtn
                    GestionProvFrm.EliminarTelBtn.Text = My.Resources.ArchivoIdioma.EliminarTelBtn

                    GestionProvFrm.RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
                    GestionProvFrm.CodProvCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
                    GestionProvFrm.RazonSocialCAB.HeaderText = My.Resources.ArchivoIdioma.RazonSocialGral
                    GestionProvFrm.CuitCAB.HeaderText = My.Resources.ArchivoIdioma.CuitGral
                    GestionProvFrm.CorreoElectronicoCAB.HeaderText = My.Resources.ArchivoIdioma.CorreoElectronicoGral
                    GestionProvFrm.DireccionCAB.HeaderText = My.Resources.ArchivoIdioma.DireccionCAB

                    GestionProvFrm.PaginaNro = My.Resources.ArchivoIdioma.InfoPaginaPag
                    GestionProvFrm.PaginaDe = My.Resources.ArchivoIdioma.InfoPaginaDe
                    GestionProvFrm.PaginaRegistros = My.Resources.ArchivoIdioma.InfoPaginaReg

                    If GestionProvFrm.ProveedorDG.Rows.Count = 0 Then
                        GestionProvFrm.InfoPagina(0)
                    Else
                        GestionProvFrm.InfoPagina(GestionProvFrm.NroPag)
                    End If

                    Continue For
                End If

                If item = "GestionNV" Then
                    If (Not (GestionNVFrm.IsHandleCreated)) Then
                        GestionNVFrm = New GestionNV
                    End If

                    GestionNVFrm.Text = My.Resources.ArchivoIdioma.GestionNVFrm
                    GestionNVFrm.AccionLbl.Text = My.Resources.ArchivoIdioma.AccionLbl

                    GestionNVFrm.AccionCMB.Items.Clear()

                    If GestionNVFrm.ConsultarNota = True Then
                        GestionNVFrm.AccionCMB.Items.Add(My.Resources.ArchivoIdioma.ConsultarNV)
                    End If

                    If GestionNVFrm.ConsultaRemitoNV = True Then
                        GestionNVFrm.AccionCMB.Items.Add(My.Resources.ArchivoIdioma.ConsultarRemNV)
                    End If

                    If GestionNVFrm.GenerarRemitoNV = True Then
                        GestionNVFrm.AccionCMB.Items.Add(My.Resources.ArchivoIdioma.GenerarRemito)
                    End If

                    If GestionNVFrm.BajaNV = True Then
                        GestionNVFrm.AccionCMB.Items.Add(My.Resources.ArchivoIdioma.BajaNotaVenta)
                    End If

                    GestionNVFrm.AccionCMB.SelectedIndex = 0

                    GestionNVFrm.NroNotaLbl.Text = My.Resources.ArchivoIdioma.NumeroNota
                    GestionNVFrm.BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    GestionNVFrm.NotaGB.Text = My.Resources.ArchivoIdioma.NotaVentaGB
                    GestionNVFrm.NroNotaCAB.HeaderText = My.Resources.ArchivoIdioma.NroNotaCAB
                    GestionNVFrm.FechaCAB.HeaderText = My.Resources.ArchivoIdioma.FechaLbl

                    GestionNVFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    GestionNVFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

                    Continue For
                End If

                If item = "NotaVenta" Then
                    If (Not (NVFrm.IsHandleCreated)) Then
                        NVFrm = New NotaVenta
                    End If
                    NVFrm.Text = My.Resources.ArchivoIdioma.AltaNotaVentaFrm

                    NVFrm.ClienteGB.Text = My.Resources.ArchivoIdioma.DatosClienteGB
                    NVFrm.CodCliLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
                    NVFrm.CuitLbl.Text = My.Resources.ArchivoIdioma.CuitGral
                    NVFrm.DireccionLbl.Text = My.Resources.ArchivoIdioma.DireccionCAB
                    NVFrm.RazonSocialLbl.Text = My.Resources.ArchivoIdioma.RazonSocialGral
                    NVFrm.ActivoLbl.Text = My.Resources.ArchivoIdioma.ActivoLbl
                    NVFrm.FechaEmiLbl.Text = My.Resources.ArchivoIdioma.FechaEmiForm

                    NVFrm.ProductoGB.Text = My.Resources.ArchivoIdioma.DatosProductoGB
                    NVFrm.CodProdLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
                    NVFrm.NombreProdLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
                    NVFrm.DescProdLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl
                    NVFrm.PrecioLbl.Text = My.Resources.ArchivoIdioma.Precio
                    NVFrm.CantidadLbl.Text = My.Resources.ArchivoIdioma.Cantidad

                    NVFrm.NotaVentaGB.Text = My.Resources.ArchivoIdioma.DetalleNotaVenta
                    NVFrm.CodProdCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
                    NVFrm.NombreCAB.HeaderText = My.Resources.ArchivoIdioma.CMBNombre
                    NVFrm.PrecioCAB.HeaderText = My.Resources.ArchivoIdioma.Precio
                    NVFrm.CantidadCAB.HeaderText = My.Resources.ArchivoIdioma.Cantidad

                    NVFrm.AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarGral
                    NVFrm.EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarGral
                    NVFrm.NuevoBtn.Text = My.Resources.ArchivoIdioma.NuevoGral
                    NVFrm.TotalLbl.Text = My.Resources.ArchivoIdioma.TotalLbl
                    NVFrm.GenerarBtn.Text = My.Resources.ArchivoIdioma.GenerarNotasPFrm

                    Continue For
                End If

                If item = "GestionNP" Then
                    If (Not (GestionNPFrm.IsHandleCreated)) Then
                        GestionNPFrm = New GestionNP
                    End If

                    GestionNPFrm.Text = My.Resources.ArchivoIdioma.GestionNPFrm
                    GestionNPFrm.AccionLbl.Text = My.Resources.ArchivoIdioma.AccionLbl

                    GestionNPFrm.AccionCMB.Items.Clear()

                    If GestionNPFrm.ConsultarNota = True Then
                        GestionNPFrm.AccionCMB.Items.Add(My.Resources.ArchivoIdioma.ConsultarNP)
                    End If

                    If GestionNPFrm.BajaNP = True Then
                        GestionNPFrm.AccionCMB.Items.Add(My.Resources.ArchivoIdioma.BajaNotaPed)
                    End If

                    GestionNPFrm.AccionCMB.SelectedIndex = 0

                    GestionNPFrm.NroNotaLbl.Text = My.Resources.ArchivoIdioma.NumeroNota
                    GestionNPFrm.BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    GestionNPFrm.NotaGB.Text = My.Resources.ArchivoIdioma.NotaPedidoGB
                    GestionNPFrm.NroNotaCAB.HeaderText = My.Resources.ArchivoIdioma.NroNotaCAB
                    GestionNPFrm.FechaCAB.HeaderText = My.Resources.ArchivoIdioma.FechaLbl

                    GestionNPFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    GestionNPFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
                    Continue For
                End If

                If item = "NotaPedido" Then
                    If (Not (NPFrm.IsHandleCreated)) Then
                        NPFrm = New NotaPedido
                    End If
                    NPFrm.Text = My.Resources.ArchivoIdioma.AltaNotaPedidoFrm

                    NPFrm.ProveedorGB.Text = My.Resources.ArchivoIdioma.DatosProveedorGB
                    NPFrm.CodProvLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
                    NPFrm.CuitLbl.Text = My.Resources.ArchivoIdioma.CuitGral
                    NPFrm.DireccionLbl.Text = My.Resources.ArchivoIdioma.DireccionCAB
                    NPFrm.RazonSocialLbl.Text = My.Resources.ArchivoIdioma.RazonSocialGral
                    NPFrm.ActivoLbl.Text = My.Resources.ArchivoIdioma.ActivoLbl
                    NPFrm.FechaEmiLbl.Text = My.Resources.ArchivoIdioma.FechaEmiForm

                    NPFrm.ProductoGB.Text = My.Resources.ArchivoIdioma.DatosProductoGB
                    NPFrm.CodProdLbl.Text = My.Resources.ArchivoIdioma.CodigoCAB
                    NPFrm.NombreProdLbl.Text = My.Resources.ArchivoIdioma.CMBNombre
                    NPFrm.DescProdLbl.Text = My.Resources.ArchivoIdioma.DescripcionLbl
                    NPFrm.PrecioLbl.Text = My.Resources.ArchivoIdioma.Precio
                    NPFrm.CantidadLbl.Text = My.Resources.ArchivoIdioma.Cantidad

                    NPFrm.NotaVentaGB.Text = My.Resources.ArchivoIdioma.DetalleNotaVenta
                    NPFrm.CodProdCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
                    NPFrm.NombreCAB.HeaderText = My.Resources.ArchivoIdioma.CMBNombre
                    NPFrm.PrecioCAB.HeaderText = My.Resources.ArchivoIdioma.Precio
                    NPFrm.CantidadCAB.HeaderText = My.Resources.ArchivoIdioma.Cantidad

                    NPFrm.AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarGral
                    NPFrm.EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarGral
                    NPFrm.NuevoBtn.Text = My.Resources.ArchivoIdioma.NuevoGral
                    NPFrm.TotalLbl.Text = My.Resources.ArchivoIdioma.TotalLbl
                    NPFrm.GenerarBtn.Text = My.Resources.ArchivoIdioma.GenerarNotasPFrm

                    Continue For
                End If

                If item = "GestionUsuario" Then
                    If (Not (GestionUsuFrm.IsHandleCreated)) Then
                        GestionUsuFrm = New GestionUsuario
                    End If
                    GestionUsuFrm.Text = My.Resources.ArchivoIdioma.GestionUsuarioForm

                    GestionUsuFrm.GestionUsuariosGB.Text = My.Resources.ArchivoIdioma.GestionUsuariosGB
                    GestionUsuFrm.BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
                    GestionUsuFrm.BuscarCmb.Items(0) = My.Resources.ArchivoIdioma.CMBUsuario
                    GestionUsuFrm.BuscarCmb.Items(1) = My.Resources.ArchivoIdioma.CMBApellido
                    GestionUsuFrm.BuscarCmb.Items(2) = My.Resources.ArchivoIdioma.CMBNombre
                    GestionUsuFrm.IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
                    GestionUsuFrm.BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    GestionUsuFrm.OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
                    GestionUsuFrm.AgregarBtn.Text = My.Resources.ArchivoIdioma.AgregarUsuBtn
                    GestionUsuFrm.ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarUsuBtn
                    GestionUsuFrm.EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarUsuBtn
                    GestionUsuFrm.EliminarTelBtn.Text = My.Resources.ArchivoIdioma.EliminarTelBtn

                    GestionUsuFrm.RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
                    GestionUsuFrm.CodUsuCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioCodigoCAB
                    GestionUsuFrm.UsuarioCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioUsuarioCAB
                    GestionUsuFrm.ApellidoCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioApellidoCAB
                    GestionUsuFrm.NombreCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioNombreCAB
                    GestionUsuFrm.CorreoCAB.HeaderText = My.Resources.ArchivoIdioma.CorreoElectronicoGral
                    GestionUsuFrm.EdadCAB.HeaderText = My.Resources.ArchivoIdioma.DGGestionUsuarioEdadCAB

                    GestionUsuFrm.PaginaNro = My.Resources.ArchivoIdioma.InfoPaginaPag
                    GestionUsuFrm.PaginaDe = My.Resources.ArchivoIdioma.InfoPaginaDe
                    GestionUsuFrm.PaginaRegistros = My.Resources.ArchivoIdioma.InfoPaginaReg

                    If GestionUsuFrm.UsuarioDG.Rows.Count = 0 Then
                        GestionUsuFrm.InfoPagina(0)
                    Else
                        GestionUsuFrm.InfoPagina(GestionUsuFrm.NroPag)
                    End If

                    Continue For
                End If

                If item = "GestionFamilia" Then
                    If (Not (GestionFamFrm.IsHandleCreated)) Then
                        GestionFamFrm = New GestionFamilia
                    End If
                    GestionFamFrm.Text = My.Resources.ArchivoIdioma.GestionFamiliaFrm

                    GestionFamFrm.OperacionGB.Text = My.Resources.ArchivoIdioma.OperacionesGB
                    GestionFamFrm.AgregarBtn.Text = My.Resources.ArchivoIdioma.AltaFamBtn
                    GestionFamFrm.ModificarBtn.Text = My.Resources.ArchivoIdioma.ModificarFamBtn
                    GestionFamFrm.EliminarBtn.Text = My.Resources.ArchivoIdioma.EliminarFamBtn

                    GestionFamFrm.RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
                    GestionFamFrm.CodCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
                    GestionFamFrm.DescripcionCAB.HeaderText = My.Resources.ArchivoIdioma.DescripcionLbl

                    Continue For
                End If

                If item = "DesbloquearUsuario" Then
                    If (Not (DesbloquearUsuFrm.IsHandleCreated)) Then
                        DesbloquearUsuFrm = New DesbloquearUsuario
                    End If
                    DesbloquearUsuFrm.Text = My.Resources.ArchivoIdioma.DesbloquearUsuarioFrm

                    DesbloquearUsuFrm.UsuarioGB.Text = My.Resources.ArchivoIdioma.SeleccionarUsuarioGB
                    DesbloquearUsuFrm.UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl

                    DesbloquearUsuFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    DesbloquearUsuFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

                    Continue For
                End If

                If item = "ResetearContrasena" Then
                    If (Not (ResetearPassFrm.IsHandleCreated)) Then
                        ResetearPassFrm = New ResetearContrasena
                    End If
                    ResetearPassFrm.Text = My.Resources.ArchivoIdioma.ResetearContraseñaFrm

                    ResetearPassFrm.UsuarioGB.Text = My.Resources.ArchivoIdioma.SeleccionarUsuarioGB
                    ResetearPassFrm.UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl

                    ResetearPassFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    ResetearPassFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
                    Continue For
                End If

                If item = "Backup" Then
                    If (Not (BackUpFrm.IsHandleCreated)) Then
                        BackUpFrm = New Backup
                    End If
                    BackUpFrm.Text = My.Resources.ArchivoIdioma.BackupFrm

                    BackUpFrm.BackupGB.Text = My.Resources.ArchivoIdioma.Backup
                    BackUpFrm.DestinoLbl.Text = My.Resources.ArchivoIdioma.DestinoLbl
                    BackUpFrm.VolumenLbl.Text = My.Resources.ArchivoIdioma.VolumenLbl

                    BackUpFrm.NombreZipLbl.Text = My.Resources.ArchivoIdioma.NombreZip
                    BackUpFrm.ContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ContraseñaZip
                    BackUpFrm.ReContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ReContraseñaZip

                    BackUpFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    BackUpFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

                    Continue For
                End If

                If item = "Restore" Then
                    If (Not (RestoreFrm.IsHandleCreated)) Then
                        RestoreFrm = New Restore
                    End If
                    RestoreFrm.Text = My.Resources.ArchivoIdioma.RestoreFrm

                    RestoreFrm.RestaurarGB.Text = My.Resources.ArchivoIdioma.RestoreGB
                    RestoreFrm.DestinoLbl.Text = My.Resources.ArchivoIdioma.DestinoRestoreLbl
                    RestoreFrm.ContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ContraseñaZip
                    RestoreFrm.ReContraseñaZipLbl.Text = My.Resources.ArchivoIdioma.ReContraseñaZip
                    RestoreFrm.NuevoBtn.Text = My.Resources.ArchivoIdioma.NuevoGral

                    RestoreFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    RestoreFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

                    Continue For
                End If

                If item = "Bitacora" Then
                    If (Not (BitacoraFrm.IsHandleCreated)) Then
                        BitacoraFrm = New Bitacora
                    End If
                    BitacoraFrm.Text = My.Resources.ArchivoIdioma.BitacoraFrm

                    BitacoraFrm.FiltroLbl.Text = My.Resources.ArchivoIdioma.FiltroLbl

                    BitacoraFrm.FiltroCMB.Items(0) = My.Resources.ArchivoIdioma.CompletoLbl
                    BitacoraFrm.FiltroCMB.Items(1) = My.Resources.ArchivoIdioma.UsuarioLbl
                    BitacoraFrm.FiltroCMB.Items(2) = My.Resources.ArchivoIdioma.CriticidadLbl
                    BitacoraFrm.FiltroCMB.Items(3) = My.Resources.ArchivoIdioma.FechaLbl

                    BitacoraFrm.RegistrosGB.Text = My.Resources.ArchivoIdioma.RegistrosGB
                    BitacoraFrm.CodBitCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
                    BitacoraFrm.FechaCAB.HeaderText = My.Resources.ArchivoIdioma.FechaLbl
                    BitacoraFrm.DescripcionCAB.HeaderText = My.Resources.ArchivoIdioma.DescripcionLbl
                    BitacoraFrm.CriticidadCAB.HeaderText = My.Resources.ArchivoIdioma.CriticidadLbl
                    BitacoraFrm.UsuarioCAB.HeaderText = My.Resources.ArchivoIdioma.UsuarioLbl

                    BitacoraFrm.DepurarBtn.Text = My.Resources.ArchivoIdioma.DepurarBitacora

                    BitacoraFrm.PaginaNro = My.Resources.ArchivoIdioma.InfoPaginaPag
                    BitacoraFrm.PaginaDe = My.Resources.ArchivoIdioma.InfoPaginaDe
                    BitacoraFrm.PaginaRegistros = My.Resources.ArchivoIdioma.InfoPaginaReg

                    If BitacoraFrm.BitacoraDG.Rows.Count = 0 Then
                        BitacoraFrm.InfoPagina(0)
                    Else
                        BitacoraFrm.InfoPagina(BitacoraFrm.NroPag)
                    End If

                    'FiltroCompleto
                    BitacoraFrm.FC.CompletoGB.Text = My.Resources.ArchivoIdioma.FCompletoGB
                    BitacoraFrm.FC.DesdeComLbl.Text = My.Resources.ArchivoIdioma.FechaDesdeLbl
                    BitacoraFrm.FC.HastaComLbl.Text = My.Resources.ArchivoIdioma.FechaHastaLbl
                    BitacoraFrm.FC.UsuComLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
                    BitacoraFrm.FC.CritiComLbl.Text = My.Resources.ArchivoIdioma.CriticidadLbl
                    BitacoraFrm.FC.BuscarComBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn
                    BitacoraFrm.FC.CriticidadCMB.DataSource = Nothing
                    BitacoraFrm.FC.CriticidadCMB.DataSource = BitacoraFrm.CargarComboCriticidad()
                    BitacoraFrm.FC.CriticidadCMB.DisplayMember = "Descripcion"
                    BitacoraFrm.FC.CriticidadCMB.ValueMember = "CodCriti"

                    'FiltroCriticidad
                    BitacoraFrm.FCriti.CriticidadGB.Text = My.Resources.ArchivoIdioma.CriticidadGB
                    BitacoraFrm.FCriti.CriticidadLbl.Text = My.Resources.ArchivoIdioma.CriticidadLbl
                    BitacoraFrm.FCriti.BuscarCritiBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn
                    BitacoraFrm.FCriti.CriticidadCMB.DataSource = Nothing
                    BitacoraFrm.FCriti.CriticidadCMB.DataSource = BitacoraFrm.CargarComboCriticidad()
                    BitacoraFrm.FCriti.CriticidadCMB.DisplayMember = "Descripcion"
                    BitacoraFrm.FCriti.CriticidadCMB.ValueMember = "CodCriti"


                    'FiltroUsuario
                    BitacoraFrm.FU.UsuarioGB.Text = My.Resources.ArchivoIdioma.UsuarioGBBit
                    BitacoraFrm.FU.UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
                    BitacoraFrm.FU.BuscarUsuBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    'FiltroFechas
                    BitacoraFrm.FF.FechasGB.Text = My.Resources.ArchivoIdioma.FechasGB
                    BitacoraFrm.FF.DesdeLbl.Text = My.Resources.ArchivoIdioma.FechaDesdeLbl
                    BitacoraFrm.FF.HastaLbl.Text = My.Resources.ArchivoIdioma.FechaHastaLbl
                    BitacoraFrm.FF.BuscarFechaBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

                    Continue For
                End If

                If item = "FamiliaPatente" Then
                    If (Not (PatFamFrm.IsHandleCreated)) Then
                        PatFamFrm = New FamiliaPatente
                    End If
                    PatFamFrm.Text = My.Resources.ArchivoIdioma.PatenteFamiliaFrm

                    PatFamFrm.FamiliaLbl.Text = My.Resources.ArchivoIdioma.FamiliaLbl
                    PatFamFrm.PatentesNoGB.Text = My.Resources.ArchivoIdioma.PatentesNoFamLbl
                    PatFamFrm.PatentesGB.Text = My.Resources.ArchivoIdioma.PatentesFamLbl

                    PatFamFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    PatFamFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

                    PatFamFrm.InformacionLbl.Text = My.Resources.ArchivoIdioma.ResultadoOperacion
                    Continue For
                End If

                If item = "UsuarioFamilia" Then
                    If (Not (UsuFamFrm.IsHandleCreated)) Then
                        UsuFamFrm = New UsuarioFamilia
                    End If
                    UsuFamFrm.Text = My.Resources.ArchivoIdioma.UsuarioFamiliaFrm

                    UsuFamFrm.UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
                    UsuFamFrm.FamiliaGB.Text = My.Resources.ArchivoIdioma.FamiliasGBTiene
                    UsuFamFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    UsuFamFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

                    UsuFamFrm.InformacionLbl.Text = My.Resources.ArchivoIdioma.ResultadoOperacion
                    Continue For
                End If

                If item = "UsuarioPatente" Then
                    If (Not (UsuPatFrm.IsHandleCreated)) Then
                        UsuPatFrm = New UsuarioPatente
                    End If
                    UsuPatFrm.Text = My.Resources.ArchivoIdioma.UsuarioPatenteFrm

                    UsuPatFrm.UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
                    UsuPatFrm.PatentesGB.Text = My.Resources.ArchivoIdioma.PatentesUsuLbl
                    UsuPatFrm.PatDenegadasGB.Text = My.Resources.ArchivoIdioma.PatentesDenegadasUsu
                    UsuPatFrm.DenPatentesGB.Text = My.Resources.ArchivoIdioma.PatentesNoUsuLbl

                    UsuPatFrm.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    UsuPatFrm.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn

                    UsuPatFrm.InformacionLbl.Text = My.Resources.ArchivoIdioma.ResultadoOperacion

                    Continue For
                End If

                If item = "CambiarContrasena" Then
                    If (Not (CambiarPass.IsHandleCreated)) Then
                        CambiarPass = New CambiarContrasena
                    End If

                    CambiarPass.Text = My.Resources.ArchivoIdioma.CambiarContraseñaFrm

                    CambiarPass.ContrasenaGB.Text = My.Resources.ArchivoIdioma.CambiarContraseña
                    CambiarPass.ConAnteriorLbl.Text = My.Resources.ArchivoIdioma.ConAnteriorLbl
                    CambiarPass.NuevaContraseñaLbl.Text = My.Resources.ArchivoIdioma.NuevaConLbl
                    CambiarPass.ReNuevaContraseñaLbl.Text = My.Resources.ArchivoIdioma.ReNuevaConLbl

                    CambiarPass.AceptarBtn.Text = My.Resources.ArchivoIdioma.AceptarBtn
                    CambiarPass.CancelarBtn.Text = My.Resources.ArchivoIdioma.CancelarBtn
                End If

            Next
        End If
    End Sub

    Private Sub CargarTT(ListaFormsNombreTT As List(Of String))

        For Each item As String In ListaFormsNombreTT
            If item = "GestionCliente" Then
                If (Not (GestionCliFrm.IsHandleCreated)) Then
                    GestionCliFrm = New GestionCliente
                End If

                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.AgregarBtn, My.Resources.ArchivoIdioma.TTClienteAltaBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.ModificarBtn, My.Resources.ArchivoIdioma.TTClienteModificarBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.EliminarBtn, My.Resources.ArchivoIdioma.TTClienteEliminarBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.EliminarTelBtn, My.Resources.ArchivoIdioma.TTEliminarTelBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
                GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.ClienteDG, My.Resources.ArchivoIdioma.TTListaClientes)


                Continue For
            End If

            If item = "GestionProducto" Then
                If (Not (GestionProdFrm.IsHandleCreated)) Then
                    GestionProdFrm = New GestionProducto
                End If

                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.AgregarBtn, My.Resources.ArchivoIdioma.TTProductoAltaBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.ModificarBtn, My.Resources.ArchivoIdioma.TTProductoModificarBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.EliminarBtn, My.Resources.ArchivoIdioma.TTProductoEliminarBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.MasBtn, My.Resources.ArchivoIdioma.TTMasOpciones)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
                GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.ProductosDG, My.Resources.ArchivoIdioma.TTListaProducto)

                Continue For
            End If

            If item = "GestionProveedor" Then
                If (Not (GestionProvFrm.IsHandleCreated)) Then
                    GestionProvFrm = New GestionProveedor
                End If

                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.AgregarBtn, My.Resources.ArchivoIdioma.TTProveedorAltaBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.ModificarBtn, My.Resources.ArchivoIdioma.TTProveedorModificarBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.EliminarBtn, My.Resources.ArchivoIdioma.TTProveedorEliminarBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.EliminarTelBtn, My.Resources.ArchivoIdioma.TTEliminarTelBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
                GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.ProveedorDG, My.Resources.ArchivoIdioma.TTListaProveedor)

                Continue For
            End If

            If item = "GestionNV" Then
                If (Not (GestionNVFrm.IsHandleCreated)) Then
                    GestionNVFrm = New GestionNV
                End If

                GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.AccionCMB, My.Resources.ArchivoIdioma.TTListaAcciones)
                GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.NroNotaTxt, My.Resources.ArchivoIdioma.TTNroNotaVenta)
                GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarNotaVenta)
                GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.NotaVentaDG, My.Resources.ArchivoIdioma.TTListaNotaVenta)
                GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTRealizarAccion)
                GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)

                Continue For
            End If

            If item = "NotaVenta" Then
                If (Not (NVFrm.IsHandleCreated)) Then
                    NVFrm = New NotaVenta
                End If
                NVFrm.ControlesTP.SetToolTip(NVFrm.CodCliTxt, My.Resources.ArchivoIdioma.TTCodCli)
                NVFrm.ControlesTP.SetToolTip(NVFrm.BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarCliNotas)
                NVFrm.ControlesTP.SetToolTip(NVFrm.CuitTxt, My.Resources.ArchivoIdioma.TTCuit)
                NVFrm.ControlesTP.SetToolTip(NVFrm.DireccionTxt, My.Resources.ArchivoIdioma.TTDireccionCli)
                NVFrm.ControlesTP.SetToolTip(NVFrm.RazonSocialTxt, My.Resources.ArchivoIdioma.TTRazonSocial)
                NVFrm.ControlesTP.SetToolTip(NVFrm.FechaDTP, My.Resources.ArchivoIdioma.TTFechaEmisionNota)

                NVFrm.ControlesTP.SetToolTip(NVFrm.CodProdTxt, My.Resources.ArchivoIdioma.TTCodProd)
                NVFrm.ControlesTP.SetToolTip(NVFrm.BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarProdNota)
                NVFrm.ControlesTP.SetToolTip(NVFrm.NombreProdTxt, My.Resources.ArchivoIdioma.TTNombreProd)
                NVFrm.ControlesTP.SetToolTip(NVFrm.DescProdTxt, My.Resources.ArchivoIdioma.TTDescrProd)
                NVFrm.ControlesTP.SetToolTip(NVFrm.PrecioTxt, My.Resources.ArchivoIdioma.TTPrecioProd)
                NVFrm.ControlesTP.SetToolTip(NVFrm.CantidadTxt, My.Resources.ArchivoIdioma.TTIngreseCantidad)

                NVFrm.ControlesTP.SetToolTip(NVFrm.DetalleDG, My.Resources.ArchivoIdioma.TTListaProductoNV)

                NVFrm.ControlesTP.SetToolTip(NVFrm.AgregarBtn, My.Resources.ArchivoIdioma.TTAgregarDetalle)
                NVFrm.ControlesTP.SetToolTip(NVFrm.EliminarBtn, My.Resources.ArchivoIdioma.TTEliminarDetalle)
                NVFrm.ControlesTP.SetToolTip(NVFrm.NuevoBtn, My.Resources.ArchivoIdioma.TTNuevoDetalle)
                NVFrm.ControlesTP.SetToolTip(NVFrm.GenerarBtn, My.Resources.ArchivoIdioma.TTGenerarNotaVenta)

                Continue For
            End If

            If item = "GestionNP" Then
                If (Not (GestionNPFrm.IsHandleCreated)) Then
                    GestionNPFrm = New GestionNP
                End If
                GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.AccionCMB, My.Resources.ArchivoIdioma.TTListaAcciones)
                GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.NroNotaTxt, My.Resources.ArchivoIdioma.TTNroNotaPedido)
                GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarNotaPedido)
                GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.NotaPedidoDG, My.Resources.ArchivoIdioma.TTListaNotaPedido)
                GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTRealizarAccion)
                GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)

                Continue For
            End If

            If item = "NotaPedido" Then
                If (Not (NPFrm.IsHandleCreated)) Then
                    NPFrm = New NotaPedido
                End If
                NPFrm.ControlesTP.SetToolTip(NPFrm.CodProvTxt, My.Resources.ArchivoIdioma.TTCodProv)
                NPFrm.ControlesTP.SetToolTip(NPFrm.BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarProvNotas)
                NPFrm.ControlesTP.SetToolTip(NPFrm.CuitTxt, My.Resources.ArchivoIdioma.TTCuit)
                NPFrm.ControlesTP.SetToolTip(NPFrm.DireccionTxt, My.Resources.ArchivoIdioma.TTDireccionProv)
                NPFrm.ControlesTP.SetToolTip(NPFrm.RazonSocialTxt, My.Resources.ArchivoIdioma.TTRazonSocial)
                NPFrm.ControlesTP.SetToolTip(NPFrm.FechaDTP, My.Resources.ArchivoIdioma.TTFechaEmisionNP)

                NPFrm.ControlesTP.SetToolTip(NPFrm.CodProdTxt, My.Resources.ArchivoIdioma.TTCodProd)
                NPFrm.ControlesTP.SetToolTip(NPFrm.BuscarProdBtn, My.Resources.ArchivoIdioma.TTBuscarProdNota)
                NPFrm.ControlesTP.SetToolTip(NPFrm.NombreProdTxt, My.Resources.ArchivoIdioma.TTNombreProd)
                NPFrm.ControlesTP.SetToolTip(NPFrm.DescProdTxt, My.Resources.ArchivoIdioma.TTDescrProd)
                NPFrm.ControlesTP.SetToolTip(NPFrm.PrecioTxt, My.Resources.ArchivoIdioma.TTPrecioProd)
                NPFrm.ControlesTP.SetToolTip(NPFrm.CantidadTxt, My.Resources.ArchivoIdioma.TTIngreseCantidad)

                NPFrm.ControlesTP.SetToolTip(NPFrm.DetalleDG, My.Resources.ArchivoIdioma.TTListaProductoNP)

                NPFrm.ControlesTP.SetToolTip(NPFrm.AgregarBtn, My.Resources.ArchivoIdioma.TTAgregarDetalle)
                NPFrm.ControlesTP.SetToolTip(NPFrm.EliminarBtn, My.Resources.ArchivoIdioma.TTEliminarDetalle)
                NPFrm.ControlesTP.SetToolTip(NPFrm.NuevoBtn, My.Resources.ArchivoIdioma.TTNuevoDetalle)
                NPFrm.ControlesTP.SetToolTip(NPFrm.GenerarBtn, My.Resources.ArchivoIdioma.TTGenerarNotaPedido)

                Continue For
            End If

            If item = "GestionUsuario" Then
                If (Not (GestionUsuFrm.IsHandleCreated)) Then
                    GestionUsuFrm = New GestionUsuario
                End If
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.AgregarBtn, My.Resources.ArchivoIdioma.TTUsuarioAltaBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.ModificarBtn, My.Resources.ArchivoIdioma.TTUsuarioModificarBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.EliminarBtn, My.Resources.ArchivoIdioma.TTUsuarioEliminarBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.EliminarTelBtn, My.Resources.ArchivoIdioma.TTEliminarTelBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
                GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.UsuarioDG, My.Resources.ArchivoIdioma.TTListaUsuarios)

                Continue For
            End If

            If item = "GestionFamilia" Then
                If (Not (GestionFamFrm.IsHandleCreated)) Then
                    GestionFamFrm = New GestionFamilia
                End If
                GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.AgregarBtn, My.Resources.ArchivoIdioma.TTAgregarFam)
                GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.ModificarBtn, My.Resources.ArchivoIdioma.TTModificarFam)
                GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.EliminarBtn, My.Resources.ArchivoIdioma.TTEliminarFam)
                GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.FamiliaDG, My.Resources.ArchivoIdioma.TTlistaFamilias)

                Continue For
            End If

            If item = "DesbloquearUsuario" Then
                If (Not (DesbloquearUsuFrm.IsHandleCreated)) Then
                    DesbloquearUsuFrm = New DesbloquearUsuario
                End If
                DesbloquearUsuFrm.ControlesTP.SetToolTip(DesbloquearUsuFrm.UsuarioCMB, My.Resources.ArchivoIdioma.TTListaUsuBloqueados)
                DesbloquearUsuFrm.ControlesTP.SetToolTip(DesbloquearUsuFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarDesbloquearUsu)
                DesbloquearUsuFrm.ControlesTP.SetToolTip(DesbloquearUsuFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)

                Continue For
            End If

            If item = "ResetearContrasena" Then
                If (Not (ResetearPassFrm.IsHandleCreated)) Then
                    ResetearPassFrm = New ResetearContrasena
                End If
                ResetearPassFrm.ControlesTP.SetToolTip(ResetearPassFrm.UsuarioCMB, My.Resources.ArchivoIdioma.TTListaUsuarios)
                ResetearPassFrm.ControlesTP.SetToolTip(ResetearPassFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTAceptarResetearContraseña)
                ResetearPassFrm.ControlesTP.SetToolTip(ResetearPassFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
                Continue For
            End If

            If item = "Backup" Then
                If (Not (BackUpFrm.IsHandleCreated)) Then
                    BackUpFrm = New Backup
                End If
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.RutaTxt, My.Resources.ArchivoIdioma.TTRuta)
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarRutaBK)
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.VolumenNUD, My.Resources.ArchivoIdioma.TTVolumenes)
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.NombreZipTxt, My.Resources.ArchivoIdioma.TTNombreZip)
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.ContraseñaZipTxt, My.Resources.ArchivoIdioma.TTContraseñaZip)
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.ReContraseñaZipTxt, My.Resources.ArchivoIdioma.TTReContraseñaZip)
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTGenerarBackup)
                BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)

                Continue For
            End If

            If item = "Restore" Then
                If (Not (RestoreFrm.IsHandleCreated)) Then
                    RestoreFrm = New Restore
                End If
                RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarBAK)
                RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.ArchivosLB, My.Resources.ArchivoIdioma.TTArchivosBAKR)
                RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.ContraseñaZipTxt, My.Resources.ArchivoIdioma.TTContraseñaZip)
                RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.ReContraseñaZipTxt, My.Resources.ArchivoIdioma.TTReContraseñaZip)
                RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.NuevoBtn, My.Resources.ArchivoIdioma.NuevoRestoreLimpiar)
                RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTGenerarRestore)
                RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)

                Continue For
            End If

            If item = "Bitacora" Then
                If (Not (BitacoraFrm.IsHandleCreated)) Then
                    BitacoraFrm = New Bitacora
                End If
                BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.FiltroCMB, My.Resources.ArchivoIdioma.TTFiltroBitacora)
                BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.SiguienteBtn, My.Resources.ArchivoIdioma.TTSiguienteBtn)
                BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.AnteriorBtn, My.Resources.ArchivoIdioma.TTAnteriorBtn)
                BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.UltimoBtn, My.Resources.ArchivoIdioma.TTUltimoBtn)
                BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.PrimeroBtn, My.Resources.ArchivoIdioma.TTPrimeraBtn)
                BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
                BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.BitacoraDG, My.Resources.ArchivoIdioma.TTListaBitacora)

                'FiltroCompleto
                BitacoraFrm.FC.ControlesTP.SetToolTip(BitacoraFrm.FC.BuscarComBtn, My.Resources.ArchivoIdioma.TTBuscarCompleto)

                'FiltroCriticidad
                BitacoraFrm.FCriti.ControlesTP.SetToolTip(BitacoraFrm.FCriti.BuscarCritiBtn, My.Resources.ArchivoIdioma.TTBuscarCriticidad)

                'FiltroUsuario
                BitacoraFrm.FU.ControlesTP.SetToolTip(BitacoraFrm.FU.BuscarUsuBtn, My.Resources.ArchivoIdioma.TTBuscarUsuarios)

                'FiltroFechas
                BitacoraFrm.FF.ControlesTP.SetToolTip(BitacoraFrm.FF.BuscarFechaBtn, My.Resources.ArchivoIdioma.TTBuscarFechas)

                Continue For
            End If

            If item = "FamiliaPatente" Then
                If (Not (PatFamFrm.IsHandleCreated)) Then
                    PatFamFrm = New FamiliaPatente
                End If
                PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.FamiliaCMB, My.Resources.ArchivoIdioma.TTFamiliaCMB)
                PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarFam)
                PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.PatentesCLB, My.Resources.ArchivoIdioma.TTPatentesNoFam)
                PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.DenPatentesCLB, My.Resources.ArchivoIdioma.TTPatentesFam)
                PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTAltaBajaPatFam)
                PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
                Continue For
            End If

            If item = "UsuarioFamilia" Then
                If (Not (UsuFamFrm.IsHandleCreated)) Then
                    UsuFamFrm = New UsuarioFamilia
                End If
                UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.UsuarioCMB, My.Resources.ArchivoIdioma.TTListaUsuarios)
                UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.FamiliaCLB, My.Resources.ArchivoIdioma.TTlistaFamilias)
                UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTAltaUsuFam)
                UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
                Continue For
            End If

            If item = "UsuarioPatente" Then
                If (Not (UsuPatFrm.IsHandleCreated)) Then
                    UsuPatFrm = New UsuarioPatente
                End If
                UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.UsuariosCMB, My.Resources.ArchivoIdioma.TTListaUsuarios)
                UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarUsuariosPat)
                UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.DenPatentesCLB, My.Resources.ArchivoIdioma.TTPatentesNoUsu)
                UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.PatDenegadasCLB, My.Resources.ArchivoIdioma.TTPatDenegadasUsu)
                UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.PatentesCLB, My.Resources.ArchivoIdioma.TTPatentesUsu)
                UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.AceptarBtn, My.Resources.ArchivoIdioma.TTAltaBajaPatUsu)
                UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)

                Continue For
            End If

            If item = "CambiarContrasena" Then
                If (Not (CambiarPass.IsHandleCreated)) Then
                    CambiarPass = New CambiarContrasena
                End If

                CambiarPass.ControlesTP.SetToolTip(CambiarPass.ConAnteriorTxt, My.Resources.ArchivoIdioma.TTConAnterior)
                CambiarPass.ControlesTP.SetToolTip(CambiarPass.NuevaContraseñaTxt, My.Resources.ArchivoIdioma.TTNuevaCon)
                CambiarPass.ControlesTP.SetToolTip(CambiarPass.ReNuevaContraseñaTxt, My.Resources.ArchivoIdioma.TTConfirmarCon)
                CambiarPass.ControlesTP.SetToolTip(CambiarPass.AceptarBtn, My.Resources.ArchivoIdioma.CambiarContraseña)
                CambiarPass.ControlesTP.SetToolTip(CambiarPass.CancelarBtn, My.Resources.ArchivoIdioma.TTCancelarBtn)
            End If

        Next

    End Sub

#End Region

#Region "Botones"
    Private Sub GestionClienteSMI_Click(sender As System.Object, e As System.EventArgs) Handles GestionClienteSMI.Click
        If (Not (GestionCliFrm.IsHandleCreated)) Then
            GestionCliFrm = New GestionCliente
        End If

        GestionCliFrm.MdiParent = Me
        GestionCliFrm.StartPosition = FormStartPosition.CenterScreen
        GestionCliFrm.Show()

        GestionClienteSMI.Enabled = False
    End Sub

    Private Sub GestionProveedorSMI_Click(sender As System.Object, e As System.EventArgs) Handles GestionProveedorSMI.Click
        If (Not (GestionProvFrm.IsHandleCreated)) Then
            GestionProvFrm = New GestionProveedor
        End If
        GestionProvFrm.MdiParent = Me
        GestionProvFrm.StartPosition = FormStartPosition.CenterScreen
        GestionProvFrm.Show()

        GestionProveedorSMI.Enabled = False
    End Sub

    Private Sub GestionProductoSMI_Click(sender As System.Object, e As System.EventArgs) Handles GestionProductoSMI.Click
        If (Not (GestionProdFrm.IsHandleCreated)) Then
            GestionProdFrm = New GestionProducto
        End If
        GestionProdFrm.MdiParent = Me
        GestionProdFrm.StartPosition = FormStartPosition.CenterScreen
        GestionProdFrm.Show()

        GestionProductoSMI.Enabled = False
    End Sub

    Private Sub GestionNVSMI_Click(sender As System.Object, e As System.EventArgs) Handles GestionNVSMI.Click
        If (Not (GestionNVFrm.IsHandleCreated)) Then
            GestionNVFrm = New GestionNV
        End If
        GestionNVFrm.MdiParent = Me
        GestionNVFrm.StartPosition = FormStartPosition.CenterScreen
        GestionNVFrm.Show()

        GestionNVSMI.Enabled = False
    End Sub

    Private Sub GenerarNVSMI_Click(sender As System.Object, e As System.EventArgs) Handles GenerarNVSMI.Click
        If (Not (NVFrm.IsHandleCreated)) Then
            NVFrm = New NotaVenta
        End If
        NVFrm.MdiParent = Me
        NVFrm.StartPosition = FormStartPosition.CenterScreen
        NVFrm.Show()

        GenerarNVSMI.Enabled = False
    End Sub

    Private Sub GestionNPSMI_Click(sender As System.Object, e As System.EventArgs) Handles GestionNPSMI.Click
        If (Not (GestionNPFrm.IsHandleCreated)) Then
            GestionNPFrm = New GestionNP
        End If
        GestionNPFrm.MdiParent = Me
        GestionNPFrm.StartPosition = FormStartPosition.CenterParent
        GestionNPFrm.Show()

        GestionNPSMI.Enabled = False
    End Sub

    Private Sub GenerarNPSMI_Click(sender As System.Object, e As System.EventArgs) Handles GenerarNPSMI.Click
        If (Not (NPFrm.IsHandleCreated)) Then
            NPFrm = New NotaPedido
        End If
        NPFrm.MdiParent = Me
        NPFrm.StartPosition = FormStartPosition.CenterScreen
        NPFrm.Show()

        GenerarNPSMI.Enabled = False
    End Sub

    Private Sub GestionUsuarioSMI_Click(sender As System.Object, e As System.EventArgs) Handles GestionUsuarioSMI.Click
        If (Not (GestionUsuFrm.IsHandleCreated)) Then
            GestionUsuFrm = New GestionUsuario
        End If
        GestionUsuFrm.MdiParent = Me
        GestionUsuFrm.StartPosition = FormStartPosition.CenterScreen
        GestionUsuFrm.Show()

        GestionUsuarioSMI.Enabled = False
    End Sub

    Private Sub GestionFamiliaSMI_Click(sender As System.Object, e As System.EventArgs) Handles GestionFamiliaSMI.Click
        If (Not (GestionFamFrm.IsHandleCreated)) Then
            GestionFamFrm = New GestionFamilia
        End If
        GestionFamFrm.MdiParent = Me
        GestionFamFrm.StartPosition = FormStartPosition.CenterScreen
        GestionFamFrm.Show()

        GestionFamiliaSMI.Enabled = False
    End Sub

    Private Sub DesbloquearUsuarioSMI_Click(sender As System.Object, e As System.EventArgs) Handles DesbloquearUsuarioSMI.Click
        If (Not (DesbloquearUsuFrm.IsHandleCreated)) Then
            DesbloquearUsuFrm = New DesbloquearUsuario
        End If
        DesbloquearUsuFrm.MdiParent = Me
        DesbloquearUsuFrm.StartPosition = FormStartPosition.CenterScreen
        DesbloquearUsuFrm.Show()

        If DesbloquearUsuFrm.UsuarioCMB.Items.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoUsuBloqueados, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DesbloquearUsuFrm.Close()
            DesbloquearUsuarioSMI.Enabled = True
            Exit Sub
        End If

        DesbloquearUsuarioSMI.Enabled = False
    End Sub

    Private Sub ResetearContrasenaSMI_Click(sender As System.Object, e As System.EventArgs) Handles ResetearContrasenaSMI.Click
        If (Not (ResetearPassFrm.IsHandleCreated)) Then
            ResetearPassFrm = New ResetearContrasena
        End If
        ResetearPassFrm.MdiParent = Me
        ResetearPassFrm.StartPosition = FormStartPosition.CenterScreen
        ResetearPassFrm.Show()

        ResetearContrasenaSMI.Enabled = False
    End Sub

    Private Sub BackupSMI_Click(sender As System.Object, e As System.EventArgs) Handles BackupSMI.Click
        If (Not (BackUpFrm.IsHandleCreated)) Then
            BackUpFrm = New Backup
        End If
        BackUpFrm.MdiParent = Me
        BackUpFrm.StartPosition = FormStartPosition.CenterScreen
        BackUpFrm.Show()

        BackupSMI.Enabled = False
    End Sub

    Private Sub RestoreSMI_Click(sender As System.Object, e As System.EventArgs) Handles RestoreSMI.Click
        If (Not (RestoreFrm.IsHandleCreated)) Then
            RestoreFrm = New Restore
        End If
        RestoreFrm.MdiParent = Me
        RestoreFrm.StartPosition = FormStartPosition.CenterScreen
        RestoreFrm.Show()

        RestoreSMI.Enabled = False
    End Sub

    Private Sub BitacoraSMI_Click(sender As System.Object, e As System.EventArgs) Handles BitacoraSMI.Click
        If (Not (BitacoraFrm.IsHandleCreated)) Then
            BitacoraFrm = New Bitacora
        End If
        BitacoraFrm.MdiParent = Me
        BitacoraFrm.StartPosition = FormStartPosition.CenterScreen
        BitacoraFrm.Show()

        BitacoraSMI.Enabled = False
    End Sub

    Private Sub PatFamSMI_Click(sender As System.Object, e As System.EventArgs) Handles PatFamSMI.Click
        If (Not (PatFamFrm.IsHandleCreated)) Then
            PatFamFrm = New FamiliaPatente
        End If
        PatFamFrm.MdiParent = Me
        PatFamFrm.StartPosition = FormStartPosition.CenterScreen
        PatFamFrm.Show()

        PatFamSMI.Enabled = False
    End Sub

    Private Sub UsuFamSMI_Click(sender As System.Object, e As System.EventArgs) Handles UsuFamSMI.Click
        If (Not (UsuFamFrm.IsHandleCreated)) Then
            UsuFamFrm = New UsuarioFamilia
        End If
        UsuFamFrm.MdiParent = Me
        UsuFamFrm.StartPosition = FormStartPosition.CenterScreen
        UsuFamFrm.Show()

        UsuFamSMI.Enabled = False
    End Sub

    Private Sub PatUsuSMI_Click(sender As System.Object, e As System.EventArgs) Handles PatUsuSMI.Click
        If (Not (UsuPatFrm.IsHandleCreated)) Then
            UsuPatFrm = New UsuarioPatente
        End If
        UsuPatFrm.MdiParent = Me
        UsuPatFrm.StartPosition = FormStartPosition.CenterScreen
        UsuPatFrm.Show()

        PatUsuSMI.Enabled = False
    End Sub

    Private Sub RecalcularDVSMI_Click(sender As System.Object, e As System.EventArgs) Handles RecalcularDVSMI.Click
        Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.PregDV, My.Resources.ArchivoIdioma.PreguntaTituDV, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If Resultado = Windows.Forms.DialogResult.OK Then

            'DVH
            Integridad.RecalcularDVH(DtErrorIntegridad)
            'DVV
            Integridad.RecalcularDVV(DtErrorIntegridadDVV)

            MessageBox.Show(My.Resources.ArchivoIdioma.VerificoIntegridad, My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            RecalcularDVSMI.Enabled = False
        Else
            Exit Sub
        End If
    End Sub

    Private Sub EspanolSMI_Click(sender As System.Object, e As System.EventArgs) Handles EspanolSMI.Click
        Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.CambiarIdiomaESP, My.Resources.ArchivoIdioma.CambiarIdioma, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Resultado = Windows.Forms.DialogResult.OK Then
            EspanolSMI.Enabled = False
            InglesSMI.Enabled = True

            ListaFormsNombres.Clear()
            ListaFormsNombresTT.Clear()
            For Each f As Form In Application.OpenForms
                ListaFormsNombres.Add(f.Name)
                ListaFormsNombresTT.Add(f.Name)
            Next

            Idioma.AplicarIdioma("es-AR")

            AplicarIdioma(False, ListaFormsNombres)
            CargarTT(ListaFormsNombresTT)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub InglesSMI_Click(sender As System.Object, e As System.EventArgs) Handles InglesSMI.Click
        Dim Resultado As DialogResult = MessageBox.Show(My.Resources.ArchivoIdioma.CambiarIdiomaUS, My.Resources.ArchivoIdioma.CambiarIdioma, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Resultado = Windows.Forms.DialogResult.OK Then
            EspanolSMI.Enabled = True
            InglesSMI.Enabled = False

            ListaFormsNombres.Clear()
            ListaFormsNombresTT.Clear()
            For Each f As Form In Application.OpenForms
                ListaFormsNombres.Add(f.Name)
                ListaFormsNombresTT.Add(f.Name)
            Next

            Idioma.AplicarIdioma("en-US")

            AplicarIdioma(False, ListaFormsNombres)
            CargarTT(ListaFormsNombresTT)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub CambiarContrasenaSMI_Click(sender As System.Object, e As System.EventArgs) Handles CambiarContrasenaSMI.Click
        If (Not (CambiarPass.IsHandleCreated)) Then
            CambiarPass = New CambiarContrasena
        End If
        CambiarPass.MdiParent = Me
        CambiarPass.StartPosition = FormStartPosition.CenterScreen
        CambiarPass.Show()

        CambiarContrasenaSMI.Enabled = False
    End Sub

    Private Sub SalirSMI_Click(sender As System.Object, e As System.EventArgs) Handles SalirSMI.Click
        Me.Close()
    End Sub

    Private Sub Principal_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Application.OpenForms.Count - 1 <> 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.FormulariosAbiertos, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        Else
            Dim UsuAut As Autenticar = Autenticar.Instancia()
            LogOut.CerrarSesion(UsuAut.UsuarioLogueado)
            Application.Exit()
            'Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-AR")

            'Dim frm As New LogIn
            'frm.Show()
        End If
    End Sub
#End Region

#Region "Validaciones"

    Private Sub BloquearSistema()
        GestionSMI.Enabled = False
        ComercialSMI.Enabled = False
        If EstadoIntegridad = True Then
            BackupSMI.Enabled = False
            RestoreSMI.Enabled = False
            BitacoraSMI.Enabled = False
            PatFamSMI.Enabled = False
            PatUsuSMI.Enabled = False
            UsuFamSMI.Enabled = False
            RecalcularDVSMI.Enabled = True
        Else
            SeguridadSMI.Enabled = False
        End If
        SistemaSMI.Enabled = False
        IdiomaSMI.Enabled = False
        CambiarContrasenaSMI.Enabled = False
    End Sub

    Private Sub Principal_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Control + Keys.G And Not GestionSMI.Enabled = False Then
            GestionSMI.ShowDropDown()
        End If

        If e.KeyData = Keys.Control + Keys.C And Not ComercialSMI.Enabled = False Then
            ComercialSMI.ShowDropDown()
        End If

        If e.KeyData = Keys.Control + Keys.S And Not SistemaSMI.Enabled = False Then
            SistemaSMI.ShowDropDown()
        End If

        If e.KeyData = Keys.Control + Keys.Alt + Keys.S And Not SeguridadSMI.Enabled = False Then
            SeguridadSMI.ShowDropDown()
        End If

        If e.KeyData = Keys.Control + Keys.P And Not PanelSMI.Enabled = False Then
            PanelSMI.ShowDropDown()
        End If

    End Sub

#End Region

End Class