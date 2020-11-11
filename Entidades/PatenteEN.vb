
Public Class PatenteEN
    Private _codpat As Integer
    Public Property CodPat() As Integer
        Get
            Return _codpat
        End Get
        Set(ByVal value As Integer)
            _codpat = value
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
End Class
