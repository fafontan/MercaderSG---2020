
Public Class PatUsuEN
    Private _codusu As Integer
    Public Property CodUsu() As Integer
        Get
            Return _codusu
        End Get
        Set(ByVal value As Integer)
            _codusu = value
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

    Private _usuariopat As String
    Public Property UsuarioPat() As String
        Get
            Return _usuariopat
        End Get
        Set(ByVal value As String)
            _usuariopat = value
        End Set
    End Property

    Private _descpat As String
    Public Property DescPat() As String
        Get
            Return _descpat
        End Get
        Set(ByVal value As String)
            _descpat = value
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

    Private _dvh As Integer
    Public Property DVH() As Integer
        Get
            Return _dvh
        End Get
        Set(ByVal value As Integer)
            _dvh = value
        End Set
    End Property

End Class
