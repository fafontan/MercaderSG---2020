<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarNV
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
        Me.NotaVentaCRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'NotaVentaCRV
        '
        Me.NotaVentaCRV.ActiveViewIndex = -1
        Me.NotaVentaCRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NotaVentaCRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.NotaVentaCRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotaVentaCRV.Location = New System.Drawing.Point(0, 0)
        Me.NotaVentaCRV.Name = "NotaVentaCRV"
        Me.NotaVentaCRV.Size = New System.Drawing.Size(642, 567)
        Me.NotaVentaCRV.TabIndex = 0
        '
        'ConsultarNV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(642, 567)
        Me.Controls.Add(Me.NotaVentaCRV)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "ConsultarNV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NotaVentaCRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
