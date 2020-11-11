Public Class DVHEN

    Sub New()

    End Sub

    Sub New(TablaM As String, ColumnaM As String)
        _tabla = TablaM
        _columna = ColumnaM
    End Sub

    Private _tabla As String
    Public Property Tabla() As String
        Get
            Return _tabla
        End Get
        Set(ByVal value As String)
            _tabla = value
        End Set
    End Property

    Private _codreg As Integer
    Public Property CodReg() As Integer
        Get
            Return _codreg
        End Get
        Set(ByVal value As Integer)
            _codreg = value
        End Set
    End Property

    Private _codaux As Integer
    Public Property CodAux() As Integer
        Get
            Return _codaux
        End Get
        Set(ByVal value As Integer)
            _codaux = value
        End Set
    End Property

    Private _colactivo As String
    Public Property ColActivo() As String
        Get
            Return _colactivo
        End Get
        Set(ByVal value As String)
            _colactivo = value
        End Set
    End Property


    Private _columna As String
    Public Property Columna() As String
        Get
            Return _columna
        End Get
        Set(ByVal value As String)
            _columna = value
        End Set
    End Property

    Private _cadena As String
    Public Property Cadena() As String
        Get
            Return _cadena
        End Get
        Set(ByVal value As String)
            _cadena = value
        End Set
    End Property


    Private _estado As Boolean
    Public Property Estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

    Private _dtintegridad As DataTable
    Public Property DtIntegridad() As DataTable
        Get
            Return _dtintegridad
        End Get
        Set(ByVal value As DataTable)
            _dtintegridad = value
        End Set
    End Property

    Private _dtintegridaddvv As DataTable
    Public Property DtIntegridadDVV() As DataTable
        Get
            Return _dtintegridaddvv
        End Get
        Set(ByVal value As DataTable)
            _dtintegridaddvv = value
        End Set
    End Property

End Class
