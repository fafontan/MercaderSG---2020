
Public Class TelefonoEN
    Private _codtel As Integer
    Public Property CodTel() As Integer
        Get
            Return _codtel
        End Get
        Set(ByVal value As Integer)
            _codtel = value
        End Set
    End Property

    Private _coden As Integer
    Public Property CodEn() As Integer
        Get
            Return _coden
        End Get
        Set(ByVal value As Integer)
            _coden = value
        End Set
    End Property

    Private _numero As String
    Public Property Numero() As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            _numero = value
        End Set
    End Property

End Class
