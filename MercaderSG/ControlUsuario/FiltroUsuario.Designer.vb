<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroUsuario
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Me.UsuarioGB = New System.Windows.Forms.GroupBox()
        Me.UsuarioCMB = New System.Windows.Forms.ComboBox()
        Me.BuscarUsuBtn = New System.Windows.Forms.Button()
        Me.UsuarioLbl = New System.Windows.Forms.Label()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.UsuarioGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'UsuarioGB
        '
        Me.UsuarioGB.Controls.Add(Me.UsuarioCMB)
        Me.UsuarioGB.Controls.Add(Me.BuscarUsuBtn)
        Me.UsuarioGB.Controls.Add(Me.UsuarioLbl)
        Me.UsuarioGB.Location = New System.Drawing.Point(2, 3)
        Me.UsuarioGB.Name = "UsuarioGB"
        Me.UsuarioGB.Size = New System.Drawing.Size(626, 100)
        Me.UsuarioGB.TabIndex = 1
        Me.UsuarioGB.TabStop = False
        Me.UsuarioGB.Text = "Buscar por Usuario"
        '
        'UsuarioCMB
        '
        Me.UsuarioCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UsuarioCMB.FormattingEnabled = True
        Me.UsuarioCMB.Location = New System.Drawing.Point(239, 40)
        Me.UsuarioCMB.Name = "UsuarioCMB"
        Me.UsuarioCMB.Size = New System.Drawing.Size(106, 23)
        Me.UsuarioCMB.TabIndex = 2
        '
        'BuscarUsuBtn
        '
        Me.BuscarUsuBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarUsuBtn.Location = New System.Drawing.Point(361, 35)
        Me.BuscarUsuBtn.Name = "BuscarUsuBtn"
        Me.BuscarUsuBtn.Size = New System.Drawing.Size(84, 30)
        Me.BuscarUsuBtn.TabIndex = 3
        Me.BuscarUsuBtn.Text = "Buscar"
        Me.BuscarUsuBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarUsuBtn.UseVisualStyleBackColor = True
        '
        'UsuarioLbl
        '
        Me.UsuarioLbl.AutoSize = True
        Me.UsuarioLbl.Location = New System.Drawing.Point(182, 43)
        Me.UsuarioLbl.Name = "UsuarioLbl"
        Me.UsuarioLbl.Size = New System.Drawing.Size(51, 15)
        Me.UsuarioLbl.TabIndex = 11
        Me.UsuarioLbl.Text = "Usuario"
        '
        'MensajeTT
        '
        Me.MensajeTT.AutomaticDelay = 100
        Me.MensajeTT.AutoPopDelay = 5000
        Me.MensajeTT.InitialDelay = 1000
        Me.MensajeTT.ReshowDelay = 500
        Me.MensajeTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.MensajeTT.ToolTipTitle = "MercaderSG"
        '
        'ControlesTP
        '
        Me.ControlesTP.AutoPopDelay = 5000
        Me.ControlesTP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ControlesTP.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ControlesTP.InitialDelay = 100
        Me.ControlesTP.ReshowDelay = 100
        Me.ControlesTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ControlesTP.ToolTipTitle = "MercaderSG"
        '
        'FiltroUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UsuarioGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FiltroUsuario"
        Me.Size = New System.Drawing.Size(629, 113)
        Me.UsuarioGB.ResumeLayout(False)
        Me.UsuarioGB.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UsuarioGB As System.Windows.Forms.GroupBox
    Friend WithEvents BuscarUsuBtn As System.Windows.Forms.Button
    Friend WithEvents UsuarioLbl As System.Windows.Forms.Label
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents UsuarioCMB As System.Windows.Forms.ComboBox

End Class
