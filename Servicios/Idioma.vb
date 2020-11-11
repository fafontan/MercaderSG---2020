Imports Entidades
Imports Datos
Imports System.Threading
Imports System.Globalization
Public Class Idioma

    Public Shared Sub AplicarIdioma(ByVal IdiomaUsuario As String)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(IdiomaUsuario)
    End Sub

    Public Shared Function DetectarIdioma(ByVal IDUsuario As Integer) As Integer
        Return ServicioAD.DetectarIdioma(IDUsuario)
    End Function

    Public Shared Function ListarIdiomas() As List(Of IdiomaEN)
        Return ServicioAD.ListarIdiomas()
    End Function

End Class ' Idioma