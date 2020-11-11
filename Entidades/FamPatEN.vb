
Public Class FamPatEN
    Private _codfam As Integer
    Public Property CodFam() As Integer
        Get
            Return _codfam
        End Get
        Set(ByVal value As Integer)
            _codfam = value
        End Set
    End Property


    Private _codpat As Integer
    Public Property CodPat() As Integer
        Get
            Return _codpat
        End Get
        Set(ByVal value As Integer)
            _codpat = value
        End Set
    End Property

    Private _descfam As String
    Public Property DescFam() As String
        Get
            Return _descfam
        End Get
        Set(ByVal value As String)
            _descfam = value
        End Set
    End Property

    Private _descPat As String
    Public Property DescPat() As String
        Get
            Return _descPat
        End Get
        Set(ByVal value As String)
            _descPat = value
        End Set
    End Property



    Private _dvh As Integer
    Public Property DVH() As Integer
        Get
            Return _dvh
        End Get
        Set(ByVal value As Integer)
            _dvh = value
        End Set
    End Property

    Private _activo As Boolean
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property


End Class
