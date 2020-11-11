<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarRemito
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
        Me.RemitoCRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'RemitoCRV
        '
        Me.RemitoCRV.ActiveViewIndex = -1
        Me.RemitoCRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RemitoCRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.RemitoCRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RemitoCRV.Location = New System.Drawing.Point(0, 0)
        Me.RemitoCRV.Name = "RemitoCRV"
        Me.RemitoCRV.Size = New System.Drawing.Size(577, 480)
        Me.RemitoCRV.TabIndex = 0
        '
        'ConsultarRemito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 480)
        Me.Controls.Add(Me.RemitoCRV)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "ConsultarRemito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RemitoCRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
