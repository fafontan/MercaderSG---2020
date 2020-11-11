Imports System.Configuration
Imports System.Diagnostics
Imports Entidades
Imports Negocios
Imports Servicios
Imports System.IO
Imports System.Text
Imports Excepciones

Friend Class SubMain
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        AddHandler Application.ThreadException, AddressOf Application_ThreadException

        Dim ListaTablas As New List(Of DVHEN)
        Dim ListaErrorInt As New List(Of ErrorIntegridadEN)

        Dim DtErrorInt As New DataTable
        DtErrorInt.Columns.Add("Tabla", GetType(String))
        DtErrorInt.Columns.Add("CodReg", GetType(Integer))
        DtErrorInt.Columns.Add("CodAux", GetType(Integer))
        DtErrorInt.Columns.Add("ValorDVH", GetType(Integer))

        Dim DtErrorIntDVV As New DataTable
        DtErrorIntDVV.Columns.Add("Tabla", GetType(String))

        Dim TablaBit As New DVHEN("Bitacora", "CodBit")
        ListaTablas.Add(TablaBit)
        Dim TablaCli As New DVHEN("Cliente", "CodCli")
        ListaTablas.Add(TablaCli)
        Dim TablaFamPat As New DVHEN("Fam_Pat", "Familia_CodFam")
        ListaTablas.Add(TablaFamPat)
        Dim TablaHP As New DVHEN("Historico_Precio", "CodHist")
        ListaTablas.Add(TablaHP)
        Dim TablaProd As New DVHEN("Producto", "CodProd")
        ListaTablas.Add(TablaProd)
        Dim TablaUsuFam As New DVHEN("Usu_Fam", "Usuario_CodUsu")
        ListaTablas.Add(TablaUsuFam)
        Dim TablaUsuPat As New DVHEN("Usu_Pat", "Usuario_CodUsu")
        ListaTablas.Add(TablaUsuPat)
        Dim TablaUsuario As New DVHEN("Usuario", "CodUsu")
        ListaTablas.Add(TablaUsuario)

        Dim DatosTabla As New DVHEN
        DatosTabla.DtIntegridad = DtErrorInt
        DatosTabla.DtIntegridadDVV = DtErrorIntDVV

        For Each item As DVHEN In ListaTablas
            DatosTabla.Tabla = item.Tabla
            DatosTabla.Columna = item.Columna
            Try
                Dim ErrorInt As New ErrorIntegridadEN
                ErrorInt = Integridad.VerificarIntegridad(DatosTabla)
                If Not String.IsNullOrEmpty(ErrorInt.Tabla) Then
                    ListaErrorInt.Add(ErrorInt)
                End If
            Catch ex As CriticalException
                MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next

        If ListaErrorInt.Count > 0 Then
            MessageBox.Show(My.Resources.ArchivoIdioma.ErrorIntegridad, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim frm As New LogIn
        frm.ListaErrorInt = ListaErrorInt
        frm.DtErrorIntegridad = DatosTabla.DtIntegridad
        frm.DtErrorIntegridadDVV = DatosTabla.DtIntegridadDVV
        frm.ShowDialog()
        Application.Run()
    End Sub

    Private Shared Sub Application_ThreadException(sender As Object, e As Threading.ThreadExceptionEventArgs)
        Dim FS As New FileStream("InformeErrores.txt", FileMode.Append)
        Dim SW As New StreamWriter(FS)

        SW.WriteLine("-----------------------------------------------------")
        SW.WriteLine("")
        SW.WriteLine("Fecha: " & DateTime.Now)
        SW.WriteLine("Mensaje: " & e.Exception.Message)
        SW.WriteLine("Pila de llamadas: " & e.Exception.StackTrace)
        SW.WriteLine("Aplicación:" & e.Exception.Source)
        SW.WriteLine("")
        SW.Close()
        FS.Close()

        MessageBox.Show(e.Exception.Message, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class
