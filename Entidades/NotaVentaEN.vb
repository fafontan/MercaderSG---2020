
Public Class NotaVentaEN
    Private _codnot As Integer
    Public Property CodNot() As Integer
        Get
            Return _codnot
        End Get
        Set(ByVal value As Integer)
            _codnot = value
        End Set
    End Property

    Private _nronota As String
    Public Property NroNota() As String
        Get
            Return _nronota
        End Get
        Set(ByVal value As String)
            _nronota = value
        End Set
    End Property

    Private _codcli As Integer
    Public Property CodCli() As Integer
        Get
            Return _codcli
        End Get
        Set(ByVal value As Integer)
            _codcli = value
        End Set
    End Property


    Private _fecha As String
    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property

    Private _activo As String
    Public Property Activo() As String
        Get
            Return _activo
        End Get
        Set(ByVal value As String)
            _activo = value
        End Set
    End Property

    Private _detalle As List(Of DetalleEN)
    Public Property Detalle() As List(Of DetalleEN)
        Get
            Return _detalle
        End Get
        Set(ByVal value As List(Of DetalleEN))
            _detalle = value
        End Set
    End Property


End Class
