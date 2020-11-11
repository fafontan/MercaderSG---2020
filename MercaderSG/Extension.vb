Module Extension
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Paginacion(Of TSource)(source As IEnumerable(Of TSource), Pagina As Integer) As IEnumerable(Of TSource)
        Const CantidadRegPag As Integer = 25
        Return source.Skip((Pagina - 1) * CantidadRegPag).Take(CantidadRegPag)
    End Function
End Module
