Public Class InformationException
    Inherits Exception

    Public Property ListaMensajes As List(Of String)

    Public Sub New(ByVal mensaje As String)
        MyBase.New(mensaje)
    End Sub

    Public Sub New(ByVal Mensajes As List(Of String))
        ListaMensajes = Mensajes
    End Sub
End Class
