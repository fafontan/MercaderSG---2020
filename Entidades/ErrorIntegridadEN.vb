Public Class ErrorIntegridadEN
    Private _coden As Integer
    Public Property CodEn() As Integer
        Get
            Return _coden
        End Get
        Set(ByVal value As Integer)
            _coden = value
        End Set
    End Property

    Private _tabla As String
    Public Property Tabla() As String
        Get
            Return _tabla
        End Get
        Set(ByVal value As String)
            _tabla = value
        End Set
    End Property

    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _estadomensaje As Boolean
    Public Property EstadoMensaje() As Boolean
        Get
            Return _estadomensaje
        End Get
        Set(ByVal value As Boolean)
            _estadomensaje = value
        End Set
    End Property



End Class
