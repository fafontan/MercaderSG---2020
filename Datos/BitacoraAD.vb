Imports Entidades
Imports System.Data.SqlClient
Imports System.Configuration
Imports Excepciones

Public Class BitacoraAD

    ''' <summary>
    ''' Obtiene los eventos realizados en el sistema.
    ''' </summary>
    ''' <returns>List(Of BitacoraEN)</returns>
    ''' <history>Federico Fontan - Diploma 2016</history>
    Public Shared Function CargarBitacora() As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()


            Dim ConsultaCarga As String = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " &
                                    "FROM Bitacora"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnEvento As New BitacoraEN
                UnEvento.CodBit = Lector(0)
                UnEvento.Fecha = Lector(1)
                UnEvento.Descripcion = Lector(2)
                UnEvento.Criticidad = Lector(3)
                UnEvento.Usuario = Lector(4)

                ListaBitacora.Add(UnEvento)
            End While

        End Using

        Return ListaBitacora
    End Function

    ''' <summary>
    ''' Obtiene los eventos realizados en el sistema por un usuario.
    ''' </summary>
    ''' <param name="Usuario">Usuario</param>
    ''' <returns>List(Of BitacoraEN)</returns>
    ''' <history>Federico Fontan - Diploma 2016</history>
    Public Shared Function CargarBitacora(ByVal Usuario As String) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()


            Dim ConsultaCarga As String = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " &
                                        "FROM Bitacora WHERE Usuario=@Param1"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario)
            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnEvento As New BitacoraEN
                UnEvento.CodBit = Lector(0)
                UnEvento.Fecha = Lector(1)
                UnEvento.Descripcion = Lector(2)
                UnEvento.Criticidad = Lector(3)
                UnEvento.Usuario = Lector(4)

                ListaBitacora.Add(UnEvento)
            End While

        End Using

        Return ListaBitacora
    End Function

    ''' <summary>
    ''' Obtiene los eventos realizados en el sistema por un nivel de criticidad.
    ''' </summary>
    ''' <param name="Criticidad">Criticidad</param>
    ''' <returns>List(Of BitacoraEN)</returns>
    ''' <history>Federico Fontan - Diploma 2016</history>
    Public Shared Function CargarBitacora(ByVal Criticidad As Integer) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()


            Dim ConsultaCarga As String = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " &
                                        "FROM Bitacora WHERE Criticidad=@Param1"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Criticidad)
            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnEvento As New BitacoraEN
                UnEvento.CodBit = Lector(0)
                UnEvento.Fecha = Lector(1)
                UnEvento.Descripcion = Lector(2)
                UnEvento.Criticidad = Lector(3)
                UnEvento.Usuario = Lector(4)

                ListaBitacora.Add(UnEvento)
            End While

        End Using

        Return ListaBitacora
    End Function

    ''' <summary>
    ''' Obtiene los eventos realizados en el sistema dentro de un rango de fechas.
    ''' </summary>
    ''' <param name="FechaDesde">Fecha Desde</param>
    ''' <param name="FechaHasta">Fecha Hasta</param>
    ''' <returns>List(Of BitacoraEN)</returns>
    ''' <history>Federico Fontan - Diploma 2016</history>
    Public Shared Function CargarBitacora(ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()


            Dim ConsultaCarga As String = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " &
                                        "FROM Bitacora WHERE CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param1 " &
                                            "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param2"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", FechaDesde)
            Cmd.Parameters.AddWithValue("@Param2", FechaHasta)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnEvento As New BitacoraEN
                UnEvento.CodBit = Lector(0)
                UnEvento.Fecha = Lector(1)
                UnEvento.Descripcion = Lector(2)
                UnEvento.Criticidad = Lector(3)
                UnEvento.Usuario = Lector(4)

                ListaBitacora.Add(UnEvento)
            End While

        End Using

        Return ListaBitacora
    End Function

    ''' <summary>
    ''' Obtiene los eventos realizados en el sistema por filtro completo.
    ''' </summary>
    ''' <param name="Usuario">Usuario</param>
    ''' <param name="Criticidad">Criticidad</param>
    ''' <param name="FechaDesde">Fecha Desde</param>
    ''' <param name="FechaHasta">Fecha Hasta</param>
    ''' <returns>List(Of BitacoraEN)</returns>
    ''' <history>Federico Fontan - Diploma 2016</history>
    Public Shared Function CargarBitacora(ByVal Usuario As String, ByVal Criticidad As Integer, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCarga As String = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " &
                            "FROM Bitacora WHERE Usuario=@Param1 AND Criticidad=@Param2 " &
                                "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param3 " &
                                    "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param4"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Usuario)
            Cmd.Parameters.AddWithValue("@Param2", Criticidad)
            Cmd.Parameters.AddWithValue("@Param3", FechaDesde)
            Cmd.Parameters.AddWithValue("@Param4", FechaHasta)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnEvento As New BitacoraEN
                UnEvento.CodBit = Lector(0)
                UnEvento.Fecha = Lector(1)
                UnEvento.Descripcion = Lector(2)
                UnEvento.Criticidad = Lector(3)
                UnEvento.Usuario = Lector(4)

                ListaBitacora.Add(UnEvento)
            End While
        End Using

        Return ListaBitacora
    End Function

    ''' <summary>
    ''' Graba en la base de datos un evento realizado en el sistema.
    ''' </summary>
    ''' <param name="Bitacora">Entidad Bitacora</param>
    ''' <history>Federico Fontan - Diploma 2016</history>
    Public Shared Sub GrabarBitacora(ByVal Bitacora As BitacoraEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaBitacora As String = "INSERT INTO Bitacora(Fecha,Descripcion,Criticidad," & _
                                                "Usuario,DVH) VALUES (GETDATE(),@Descripcion,@Criticidad," & _
                                                    "@Usuario,0) SELECT SCOPE_IDENTITY()"
                Dim Cmd As New SqlCommand(ConsultaBitacora, Cnn)
                Cmd.Parameters.AddWithValue("@Descripcion", Bitacora.Descripcion)
                Cmd.Parameters.AddWithValue("@Criticidad", Bitacora.Criticidad)
                Cmd.Parameters.AddWithValue("@Usuario", Bitacora.Usuario)

                Bitacora.CodBit = Cmd.ExecuteScalar()
        End Using
    End Sub

    Public Shared Function CargarBitacora(ByVal Usuario As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()


            Dim ConsultaCarga As String = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " &
                                            "FROM Bitacora WHERE Usuario=@Param1 " &
                                                "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param2 " &
                                                    "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param3"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Usuario)
                Cmd.Parameters.AddWithValue("@Param2", FechaDesde)
                Cmd.Parameters.AddWithValue("@Param3", FechaHasta)

                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnEvento As New BitacoraEN
                    UnEvento.CodBit = Lector(0)
                    UnEvento.Fecha = Lector(1)
                    UnEvento.Descripcion = Lector(2)
                    UnEvento.Criticidad = Lector(3)
                    UnEvento.Usuario = Lector(4)

                    ListaBitacora.Add(UnEvento)
                End While

        End Using

        Return ListaBitacora
    End Function

    Public Shared Function CargarBitacora(ByVal Criticidad As Integer, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of BitacoraEN)
        Dim ListaBitacora As New List(Of BitacoraEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()


            Dim ConsultaCarga As String = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " &
                                            "FROM Bitacora WHERE Criticidad=@Param1 " &
                                                "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param2 " &
                                                    "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param3"
            Dim Cmd As New SqlCommand(ConsultaCarga, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Criticidad)
                Cmd.Parameters.AddWithValue("@Param2", FechaDesde)
                Cmd.Parameters.AddWithValue("@Param3", FechaHasta)

                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnEvento As New BitacoraEN
                    UnEvento.CodBit = Lector(0)
                    UnEvento.Fecha = Lector(1)
                    UnEvento.Descripcion = Lector(2)
                    UnEvento.Criticidad = Lector(3)
                    UnEvento.Usuario = Lector(4)

                    ListaBitacora.Add(UnEvento)
                End While
           
        End Using

        Return ListaBitacora
    End Function

    Public Shared Function DepurarBitacora(ListaRegistros As List(Of BitacoraEN)) As Integer
        Dim TotalDVH As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            For Each item As BitacoraEN In ListaRegistros
                Dim ConsultaAlta As String = "INSERT INTO Historico_Bitacora(CodBitacora,Fecha,Descripcion,Criticidad," & _
                                                "Usuario) VALUES (@Param1,@Param2,@Param3," & _
                                                    "@Param4,@Param5)"
                Dim CmdAlta As New SqlCommand(ConsultaAlta, Cnn)
                CmdAlta.Parameters.AddWithValue("@Param1", item.CodBit)
                CmdAlta.Parameters.AddWithValue("@Param2", item.Fecha)
                CmdAlta.Parameters.AddWithValue("@Param3", item.Descripcion)
                CmdAlta.Parameters.AddWithValue("@Param4", item.Criticidad)
                CmdAlta.Parameters.AddWithValue("@Param5", item.Usuario)
                CmdAlta.ExecuteNonQuery()
            Next

            For Each item As BitacoraEN In ListaRegistros
                Dim ConsultaDVH As String = "SELECT DVH FROM Bitacora WHERE CodBit=@Param1"
                Dim CmdDVH As New SqlCommand(ConsultaDVH, Cnn)
                CmdDVH.Parameters.AddWithValue("@Param1", item.CodBit)

                TotalDVH += CInt(CmdDVH.ExecuteScalar())

                Dim ConsultaBaja As String = "DELETE FROM Bitacora WHERE CodBit=@Param1"
                Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", item.CodBit)
                Cmd.ExecuteNonQuery()
            Next
        End Using

        Return TotalDVH
    End Function


End Class ' BitacoraAD