Public Class UsuFamEN
    Private _codusu As Integer
    Public Property CodUsu() As Integer
        Get
            Return _codusu
        End Get
        Set(ByVal value As Integer)
            _codusu = value
        End Set
    End Property


    Private _codfam As Integer
    Public Property CodFam() As Integer
        Get
            Return _codfam
        End Get
        Set(ByVal value As Integer)
            _codfam = value
        End Set
    End Property

    Private _listapatentes As List(Of Integer)
    Public Property ListaPatentes() As List(Of Integer)
        Get
            Return _listapatentes
        End Get
        Set(ByVal value As List(Of Integer))
            _listapatentes = value
        End Set
    End Property



    Private _usuariofam As String
    Public Property UsuarioFam() As String
        Get
            Return _usuariofam
        End Get
        Set(ByVal value As String)
            _usuariofam = value
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

    Private _notienepat As Boolean
    Public Property NoTienePat() As Boolean
        Get
            Return _notienepat
        End Get
        Set(ByVal value As Boolean)
            _notienepat = value
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
