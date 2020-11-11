<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesbloquearUsuario
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
        Me.components = New System.ComponentModel.Container()
        Me.UsuarioLbl = New System.Windows.Forms.Label()
        Me.UsuarioGB = New System.Windows.Forms.GroupBox()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.UsuarioCMB = New System.Windows.Forms.ComboBox()
        Me.DesbloquearPB = New System.Windows.Forms.PictureBox()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.UsuarioGB.SuspendLayout()
        CType(Me.DesbloquearPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsuarioLbl
        '
        Me.UsuarioLbl.AutoSize = True
        Me.UsuarioLbl.Location = New System.Drawing.Point(80, 37)
        Me.UsuarioLbl.Name = "UsuarioLbl"
        Me.UsuarioLbl.Size = New System.Drawing.Size(51, 15)
        Me.UsuarioLbl.TabIndex = 1
        Me.UsuarioLbl.Text = "Usuario"
        '
        'UsuarioGB
        '
        Me.UsuarioGB.Controls.Add(Me.CancelarBtn)
        Me.UsuarioGB.Controls.Add(Me.UsuarioCMB)
        Me.UsuarioGB.Controls.Add(Me.DesbloquearPB)
        Me.UsuarioGB.Controls.Add(Me.AceptarBtn)
        Me.UsuarioGB.Controls.Add(Me.UsuarioLbl)
        Me.UsuarioGB.Location = New System.Drawing.Point(13, 12)
        Me.UsuarioGB.Name = "UsuarioGB"
        Me.UsuarioGB.Size = New System.Drawing.Size(286, 106)
        Me.UsuarioGB.TabIndex = 3
        Me.UsuarioGB.TabStop = False
        Me.UsuarioGB.Text = "Seleccioanar Usuario"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(185, 74)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 2
        Me.CancelarBtn.Text = "&Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'UsuarioCMB
        '
        Me.UsuarioCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UsuarioCMB.FormattingEnabled = True
        Me.UsuarioCMB.Location = New System.Drawing.Point(137, 34)
        Me.UsuarioCMB.Name = "UsuarioCMB"
        Me.UsuarioCMB.Size = New System.Drawing.Size(131, 23)
        Me.UsuarioCMB.TabIndex = 0
        '
        'DesbloquearPB
        '
        Me.DesbloquearPB.Image = Global.MercaderSG.My.Resources.Resources.DesbloquearG
        Me.DesbloquearPB.Location = New System.Drawing.Point(18, 39)
        Me.DesbloquearPB.Name = "DesbloquearPB"
        Me.DesbloquearPB.Size = New System.Drawing.Size(48, 48)
        Me.DesbloquearPB.TabIndex = 18
        Me.DesbloquearPB.TabStop = False
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(97, 74)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 1
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
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
        'DesbloquearUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(312, 130)
        Me.Controls.Add(Me.UsuarioGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(318, 159)
        Me.MinimumSize = New System.Drawing.Size(318, 159)
        Me.Name = "DesbloquearUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.UsuarioGB.ResumeLayout(False)
        Me.UsuarioGB.PerformLayout()
        CType(Me.DesbloquearPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UsuarioLbl As System.Windows.Forms.Label
    Friend WithEvents UsuarioGB As System.Windows.Forms.GroupBox
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents DesbloquearPB As System.Windows.Forms.PictureBox
    Friend WithEvents UsuarioCMB As System.Windows.Forms.ComboBox
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
End Class
