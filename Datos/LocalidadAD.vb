Imports Entidades
Imports System.Configuration
Imports System.Data.SqlClient
Imports Excepciones

Public Class LocalidadAD
    Public Shared Sub AltaLocalidad(Localidad As LocalidadEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaLoc As String = "INSERT INTO Localidad(Provincia_CodProvincia,Descripcion,CodigoPostal) VALUES" & _
                                    "(@CodProv,@Descripcion,@CodigoPostal)"
            Dim Cmd As New SqlCommand(ConsultaLoc, Cnn)
            Cmd.Parameters.AddWithValue("@CodProv", Localidad.CodProvincia)
            Cmd.Parameters.AddWithValue("@Descripcion", Localidad.Descripcion)
            Cmd.Parameters.AddWithValue("@CodigoPostal", Localidad.CodigoPostal)

            Cmd.ExecuteNonQuery()

        End Using
    End Sub

    Public Shared Function CargarProvincia() As List(Of ProvinciaEN)
        Dim ListaProv As New List(Of ProvinciaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaProv As String = "SELECT CodProvincia,Descripcion FROM Provincia"
                Dim Cmd As New SqlCommand(ConsultaProv, Cnn)
                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnaProv As New ProvinciaEN
                    UnaProv.CodProvincia = Lector(0)
                    UnaProv.Descripcion = Lector(1)

                    ListaProv.Add(UnaProv)
                End While

                Return ListaProv
        End Using
    End Function

    Public Shared Function ValidarLocalidad(Nombre As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaLoc As String = "SELECT COUNT(*) FROM Localidad WHERE Descripcion=@Param1"
                Dim Cmd As New SqlCommand(ConsultaLoc, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Nombre)
                Dim Resultado As Integer = Cmd.ExecuteScalar()

                Return Resultado

        End Using
    End Function

    Public Shared Function CargarLocalidad() As List(Of LocalidadEN)
        Dim ListaLoc As New List(Of LocalidadEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

                Dim ConsultaLoc As String = "SELECT CodLoc,Provincia_CodProvincia,Descripcion,CodigoPostal FROM Localidad"
                Dim Cmd As New SqlCommand(ConsultaLoc, Cnn)

                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnaLocalidad As New LocalidadEN
                    UnaLocalidad.CodLoc = Lector(0)
                    UnaLocalidad.CodProvincia = Lector(1)
                    UnaLocalidad.Descripcion = Lector(2)
                    UnaLocalidad.CodigoPostal = Lector(3)

                    ListaLoc.Add(UnaLocalidad)
                End While

                Return ListaLoc
        End Using
    End Function

End Class
