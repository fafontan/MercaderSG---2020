
Public Class FamiliaEN
    Private _codfam As Integer
    Public Property CodFam() As Integer
        Get
            Return _codfam
        End Get
        Set(ByVal value As Integer)
            _codfam = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _fampatL As List(Of FamPatEN)
    Public Property FamPatL() As List(Of FamPatEN)
        Get
            Return _fampatL
        End Get
        Set(ByVal value As List(Of FamPatEN))
            _fampatL = value
        End Set
    End Property

End Class
