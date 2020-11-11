Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.Text.RegularExpressions

Public Class BuscarProveedor

    Dim ListaProv As New List(Of ProveedorEN)
    Dim ListaProvTemp As New List(Of ProveedorEN)
    Dim ListaProvTempGral As New List(Of ProveedorEN)

    Dim NroPag As Integer = 0

    Private _provsel As ProveedorEN
    Public Property ProvSel() As ProveedorEN
        Get
            Return _provsel
        End Get
        Set(ByVal value As ProveedorEN)
            _provsel = value
        End Set
    End Property

    Private Sub BuscarProveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()

        CargarTT()
        AplicarIdioma()
        CargarFoco(ProveedorGB)

        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBCuit)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBRazonSocial)

        BuscarCmb.SelectedIndex = 0

        ListaProvTempGral.AddRange(ListaProv)
    End Sub

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        ListaProv = ProveedorRN.CargarProveedor()
        For i As Integer = 0 To ListaProv.Count - 1
            If BGW.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                BGW.ReportProgress(100 * i / ListaProv.Count)
            End If
        Next
    End Sub

    Private Sub BGW_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW.ProgressChanged
        BarraProgreso.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        ProveedorDG.AutoGenerateColumns = False
        ProveedorDG.DataSource = PaginaSig(NroPag)

        BarraProgreso.ProgressBar1.Value = 0
        BarraProgreso.Close()
    End Sub

    Function PaginaSig(NroPagActual As Integer) As List(Of ProveedorEN)

        Dim ListaAux As New List(Of ProveedorEN)
        For Each item As ProveedorEN In ListaProv.Paginacion(NroPag)
            Dim UnProveedor As New ProveedorEN
            UnProveedor.CodProv = item.CodProv
            UnProveedor.RazonSocial = item.RazonSocial
            UnProveedor.Cuit = item.Cuit
            UnProveedor.Direccion = item.Direccion
            UnProveedor.CorreoElectronico = item.CorreoElectronico
            UnProveedor.Activo = item.Activo

            ListaAux.Add(UnProveedor)
        Next

        Return ListaAux
    End Function

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        ListaProv.Clear()
        ListaProv.AddRange(ListaProvTempGral)

        NroPag = 0
        ProveedorDG.DataSource = Nothing
        ProveedorDG.DataSource = PaginaSig(NroPag)
    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click

        NroPag = 0

        ListaProvTemp.Clear()
        ListaProvTemp.AddRange(ListaProv)

        ListaProv.Clear()

        Try
            ListaProv = ProveedorRN.BuscarProveedor(BuscarCmb.SelectedItem, BusquedaTxt.Text)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaProv.Clear()
            ListaProv.AddRange(ListaProvTempGral)

            NroPag = 0
            ProveedorDG.DataSource = Nothing
            ProveedorDG.DataSource = PaginaSig(NroPag)
        End Try

        ProveedorDG.DataSource = Nothing
        ProveedorDG.AutoGenerateColumns = False
        ProveedorDG.DataSource = PaginaSig(NroPag)

        If ProveedorDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteProvBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaProv.Clear()
            ListaProv.AddRange(ListaProvTempGral)

            NroPag = 0
            ProveedorDG.DataSource = Nothing
            ProveedorDG.DataSource = PaginaSig(NroPag)
        End If

    End Sub

    Private Sub ProveedorDG_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProveedorDG.CellDoubleClick
        _provsel = DirectCast(ProveedorDG.CurrentRow.DataBoundItem, ProveedorEN)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BuscarProveedor_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Validaciones"

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(BusquedaTxt.Text) Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.BusquedaVacia, BusquedaTxt)
            BusquedaTxt.Clear()
            BusquedaTxt.Focus()
            Resultado = False
        End If

        Select Case BuscarCmb.SelectedItem
            Case My.Resources.ArchivoIdioma.CMBCuit

                Select Case BusquedaTxt.Text.Length
                    Case Is > 13
                        MensajeTT.Show(My.Resources.ArchivoIdioma.Contener13Carac, BusquedaTxt)
                        BusquedaTxt.Focus()
                        Resultado = False
                    Case 1 To 13
                        Dim Cuit As New Regex("([0-9]{2})[-]([0-9]{8})[-]([0-9]{1})")

                        If Not Cuit.IsMatch(BusquedaTxt.Text) Then
                            MensajeTT.Show(My.Resources.ArchivoIdioma.FormatoCUIT, BusquedaTxt)
                            BusquedaTxt.Focus()
                            Resultado = False
                        End If
                    Case Is = 13
                        Dim Cuit As New Regex("([0-9]{2})[-]([0-9]{8})[-]([0-9]{1})")

                        If Not Cuit.IsMatch(BusquedaTxt.Text) Then
                            MensajeTT.Show(My.Resources.ArchivoIdioma.FormatoCUIT, BusquedaTxt)
                            BusquedaTxt.Focus()
                            Resultado = False
                        End If
                End Select

            Case My.Resources.ArchivoIdioma.CMBRazonSocial
                If BusquedaTxt.Text.Length > 50 Then
                    MensajeTT.Show(My.Resources.ArchivoIdioma.Contener50Carac, BusquedaTxt)
                    BusquedaTxt.Focus()
                    Resultado = False
                End If
        End Select
        Return Resultado
    End Function

#End Region

#Region "Idioma y TT"

    Public Sub AplicarIdioma()
        Me.Text = My.Resources.ArchivoIdioma.BuscarProveedorFrm

        ProveedorGB.Text = My.Resources.ArchivoIdioma.SeleccionarProv
        BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
        IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        CodProvCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        RazonSocialCAB.HeaderText = My.Resources.ArchivoIdioma.RazonSocialGral
        CuitCAB.HeaderText = My.Resources.ArchivoIdioma.CuitGral
        DireccionCAB.HeaderText = My.Resources.ArchivoIdioma.DireccionCAB
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BusquedaTxt, My.Resources.ArchivoIdioma.TTBuscarProvTxt)
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarProv)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(ProveedorDG, My.Resources.ArchivoIdioma.TTListaProveedor)
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

    Private Sub ProveedorDG_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            _provsel = DirectCast(ProveedorDG.CurrentRow.DataBoundItem, ProveedorEN)
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

End Class