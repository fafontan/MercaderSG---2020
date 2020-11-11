Imports Entidades
Imports Datos
Imports Servicios
Imports Excepciones
Public Class BitacoraRN

    ''' <summary>
    ''' Obtiene los eventos realizados en el sistema.
    ''' </summary>
    ''' <remarks>En este método se desencripta la descripción de cada evento.</remarks>
    ''' <returns>List(Of BitacoraEN)</returns>
    ''' <history>Federico Fontan - Diploma 2016</history>
    Public Shared Function CargarBitacora() As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)
        Dim ListaBitacoraProcesada As New List(Of BitacoraEN)

        ListaBitacora = BitacoraAD.CargarBitacora()

        For Each item As BitacoraEN In ListaBitacora
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion)
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaBitacoraProcesada.Add(UnEvento)
        Next

        Return ListaBitacoraProcesada
    End Function

    Public Shared Function CargarBitacora(ByVal Usuario As String) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)
        Dim ListaBitacoraProcesada As New List(Of BitacoraEN)

        ListaBitacora = BitacoraAD.CargarBitacora(Usuario)

        For Each item As BitacoraEN In ListaBitacora
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion)
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaBitacoraProcesada.Add(UnEvento)
        Next

        Return ListaBitacoraProcesada
    End Function

    ''' 
    ''' <param name="criticidad"></param>
    Public Shared Function CargarBitacora(ByVal Criticidad As Integer) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)
        Dim ListaBitacoraProcesada As New List(Of BitacoraEN)

        ListaBitacora = BitacoraAD.CargarBitacora(Criticidad)

        For Each item As BitacoraEN In ListaBitacora
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion)
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaBitacoraProcesada.Add(UnEvento)
        Next

        Return ListaBitacoraProcesada
    End Function

    ''' 
    ''' <param name="FechaDesde"></param>
    ''' <param name="FechaHasta"></param>
    Public Shared Function CargarBitacora(ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)
        Dim ListaBitacoraProcesada As New List(Of BitacoraEN)

        ListaBitacora = BitacoraAD.CargarBitacora(FechaDesde, FechaHasta)

        For Each item As BitacoraEN In ListaBitacora
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion)
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaBitacoraProcesada.Add(UnEvento)
        Next

        Return ListaBitacoraProcesada
    End Function

    ''' 
    ''' <param name="usuario"></param>
    ''' <param name="criticidad"></param>
    ''' <param name="FechaDesde"></param>
    ''' <param name="FechaHasta"></param>
    Public Shared Function CargarBitacora(ByVal Usuario As String, ByVal Criticidad As Integer, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)
        Dim ListaBitacoraProcesada As New List(Of BitacoraEN)

        ListaBitacora = BitacoraAD.CargarBitacora(Usuario, Criticidad, FechaDesde, FechaHasta)

        For Each item As BitacoraEN In ListaBitacora
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion)
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaBitacoraProcesada.Add(UnEvento)
        Next

        Return ListaBitacoraProcesada
    End Function

    Public Shared Function CargarBitacora(ByVal Usuario As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)
        Dim ListaBitacoraProcesada As New List(Of BitacoraEN)

        ListaBitacora = BitacoraAD.CargarBitacora(Usuario, FechaDesde, FechaHasta)

        For Each item As BitacoraEN In ListaBitacora
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion)
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaBitacoraProcesada.Add(UnEvento)
        Next

        Return ListaBitacoraProcesada
    End Function

    Public Shared Function CargarBitacora(ByVal Criticidad As Integer, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)
        Dim ListaBitacoraProcesada As New List(Of BitacoraEN)

        ListaBitacora = BitacoraAD.CargarBitacora(Criticidad, FechaDesde, FechaHasta)

        For Each item As BitacoraEN In ListaBitacora
            Dim UnEvento As New BitacoraEN
            UnEvento.CodBit = item.CodBit
            UnEvento.Fecha = item.Fecha
            UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion)
            UnEvento.Criticidad = item.Criticidad
            UnEvento.Usuario = item.Usuario

            ListaBitacoraProcesada.Add(UnEvento)
        Next

        Return ListaBitacoraProcesada
    End Function

    Public Shared Sub DepurarBitacora(ListaRegistros As List(Of BitacoraEN))

        Dim ValorDVHTotal As Integer = BitacoraAD.DepurarBitacora(ListaRegistros)
        Dim UsuAut As Autenticar = Autenticar.Instancia()

        Dim DVVDatosCliente As New DVVEN
        DVVDatosCliente.Tabla = "Bitacora"
        DVVDatosCliente.TipoAccion = "Eliminar"
        DVVDatosCliente.ValorDVH = ValorDVHTotal
        Integridad.GrabarDVV(DVVDatosCliente)

        Dim Bitacora As New BitacoraEN

        Bitacora.Descripcion = Seguridad.Encriptar("Depuró la Bitácora con un total de " & ListaRegistros.Count & " registro/s.")
        Bitacora.Criticidad = 2
        Bitacora.Usuario = UsuAut.UsuarioLogueado

        BitacoraAD.GrabarBitacora(Bitacora)

        Dim DVHDatosBitacora As New DVHEN
        DVHDatosBitacora.Tabla = "Bitacora"
        DVHDatosBitacora.CodReg = Bitacora.CodBit

        Dim DVHBitacora As Integer = Integridad.CalcularDVH(DVHDatosBitacora)
        Dim DVHAntiguo As Integer = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora)

        Dim DVVDatosBitacora As New DVVEN
        DVVDatosBitacora.Tabla = "Bitacora"
        DVVDatosBitacora.ValorDVH = DVHBitacora
        DVVDatosBitacora.TipoAccion = "Alta"
        Integridad.GrabarDVV(DVVDatosBitacora)

        Throw New InformationException(My.Resources.ArchivoIdioma.DepurarBitacora)
    End Sub

End Class ' BitacoraRN