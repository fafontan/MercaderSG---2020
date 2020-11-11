Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports System.Text.RegularExpressions

Public Class BuscarCliente

    Dim ListaClientes As New List(Of ClienteEN)
    Dim ListaClientesTemp As New List(Of ClienteEN)
    Dim ListaClientesTempGral As New List(Of ClienteEN)

    Dim NroPag As Integer = 0

    Private _clientesel As ClienteEN
    Public Property ClienteSel() As ClienteEN
        Get
            Return _clientesel
        End Get
        Set(ByVal value As ClienteEN)
            _clientesel = value
        End Set
    End Property


    Private Sub BuscarCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()

        BarraProgreso.ShowDialog()

        CargarTT()
        AplicarIdioma()
        CargarFoco(ClienteGB)

        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBCuit)
        BuscarCmb.Items.Add(My.Resources.ArchivoIdioma.CMBRazonSocial)

        BuscarCmb.SelectedIndex = 0

        ListaClientesTempGral.AddRange(ListaClientes)
    End Sub

    Private Sub BGW_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        ListaClientes = ClienteRN.CargarCliente()
        For i As Integer = 0 To ListaClientes.Count - 1
            If BGW.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                BGW.ReportProgress(100 * i / ListaClientes.Count)
            End If
        Next
    End Sub

    Private Sub BGW_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW.ProgressChanged
        BarraProgreso.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        ClienteDG.AutoGenerateColumns = False
        ClienteDG.DataSource = PaginaSig(NroPag)

        BarraProgreso.ProgressBar1.Value = 0
        BarraProgreso.Close()
    End Sub

    Function PaginaSig(NroPagActual As Integer) As List(Of ClienteEN)

        Dim ListaAux As New List(Of ClienteEN)
        For Each item As ClienteEN In ListaClientes.Paginacion(NroPag)
            Dim UnCliente As New ClienteEN
            UnCliente.CodCli = item.CodCli
            UnCliente.RazonSocial = item.RazonSocial
            UnCliente.Cuit = item.Cuit
            UnCliente.Direccion = item.Direccion
            UnCliente.Activo = item.Activo
            UnCliente.Localidad = item.Localidad

            ListaAux.Add(UnCliente)
        Next

        Return ListaAux
    End Function

    Private Sub RecargarBtn_Click(sender As System.Object, e As System.EventArgs) Handles RecargarBtn.Click
        ListaClientes.Clear()
        ListaClientes.AddRange(ListaClientesTempGral)

        NroPag = 0
        ClienteDG.DataSource = Nothing
        ClienteDG.DataSource = PaginaSig(NroPag)
    End Sub

    Private Sub BuscarBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarBtn.Click

        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        NroPag = 0

        ListaClientesTemp.Clear()
        ListaClientesTemp.AddRange(ListaClientes)

        ListaClientes.Clear()
        Try
            ListaClientes = ClienteRN.BuscarCliente(BuscarCmb.SelectedItem, BusquedaTxt.Text)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaClientes.Clear()
            ListaClientes.AddRange(ListaClientesTempGral)

            NroPag = 0
            ClienteDG.DataSource = Nothing
            ClienteDG.DataSource = PaginaSig(NroPag)
        End Try

        ClienteDG.DataSource = Nothing
        ClienteDG.AutoGenerateColumns = False
        ClienteDG.DataSource = PaginaSig(NroPag)

        If ClienteDG.Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.NoExisteCliBusqueda, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BusquedaTxt.Clear()

            ListaClientes.Clear()
            ListaClientes.AddRange(ListaClientesTempGral)

            NroPag = 0
            ClienteDG.DataSource = Nothing
            ClienteDG.DataSource = PaginaSig(NroPag)
        End If
    End Sub

    Private Sub ClienteDG_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ClienteDG.CellDoubleClick
        _clientesel = DirectCast(ClienteDG.CurrentRow.DataBoundItem, ClienteEN)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BuscarCliente_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#Region "Validaciones"

    Public Function ConsistenciaDatos() As Boolean
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
        Me.Text = My.Resources.ArchivoIdioma.BuscarClienteFrm

        ClienteGB.Text = My.Resources.ArchivoIdioma.SeleccionarCli
        BuscarPorLbl.Text = My.Resources.ArchivoIdioma.BuscarPorLbl
        IgualLbl.Text = My.Resources.ArchivoIdioma.IgualALbl
        BuscarBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn

        CodCliCAB.HeaderText = My.Resources.ArchivoIdioma.CodigoCAB
        RazonSocialCAB.HeaderText = My.Resources.ArchivoIdioma.RazonSocialGral
        CuitCAB.HeaderText = My.Resources.ArchivoIdioma.CuitGral
        DireccionCAB.HeaderText = My.Resources.ArchivoIdioma.DireccionCAB
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BusquedaTxt, My.Resources.ArchivoIdioma.TTBuscarCliTxt)
        ControlesTP.SetToolTip(BuscarBtn, My.Resources.ArchivoIdioma.TTBuscarCli)
        ControlesTP.SetToolTip(RecargarBtn, My.Resources.ArchivoIdioma.TTRecargarBtn)
        ControlesTP.SetToolTip(ClienteDG, My.Resources.ArchivoIdioma.TTListaClientes)
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

    Private Sub ClienteDG_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ClienteDG.KeyDown
        If e.KeyCode = Keys.Enter Then
            _clientesel = DirectCast(ClienteDG.CurrentRow.DataBoundItem, ClienteEN)
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class