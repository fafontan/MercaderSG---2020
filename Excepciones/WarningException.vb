Imports Entidades
Public Class WarningException
    Inherits Exception

    Public Property ListaMensajes As List(Of String)
    Public Property MensajesFamPat As List(Of FamPatEN)
    Public Property MensajesUsuFam As List(Of UsuFamEN)

    Public Sub New(ByVal mensaje As String)
        MyBase.New(mensaje)
    End Sub

    Public Sub New(ByVal Mensajes As List(Of FamPatEN))
        MensajesFamPat = Mensajes
    End Sub

    Public Sub New(ByVal Mensajes As List(Of UsuFamEN))
        MensajesUsuFam = Mensajes
    End Sub
End Class
