<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarNP
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NotaPedidoCRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'NotaPedidoCRV
        '
        Me.NotaPedidoCRV.ActiveViewIndex = -1
        Me.NotaPedidoCRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NotaPedidoCRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.NotaPedidoCRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotaPedidoCRV.Location = New System.Drawing.Point(0, 0)
        Me.NotaPedidoCRV.Name = "NotaPedidoCRV"
        Me.NotaPedidoCRV.Size = New System.Drawing.Size(609, 546)
        Me.NotaPedidoCRV.TabIndex = 0
        '
        'ConsultarNP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(609, 546)
        Me.Controls.Add(Me.NotaPedidoCRV)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ConsultarNP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConsultarNP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NotaPedidoCRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
