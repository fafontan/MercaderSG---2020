<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarContrasena
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
        Me.ConAnteriorLbl = New System.Windows.Forms.Label()
        Me.ConAnteriorTxt = New System.Windows.Forms.TextBox()
        Me.NuevaContraseñaLbl = New System.Windows.Forms.Label()
        Me.ReNuevaContraseñaLbl = New System.Windows.Forms.Label()
        Me.NuevaContraseñaTxt = New System.Windows.Forms.TextBox()
        Me.ReNuevaContraseñaTxt = New System.Windows.Forms.TextBox()
        Me.ContrasenaGB = New System.Windows.Forms.GroupBox()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContrasenaGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConAnteriorLbl
        '
        Me.ConAnteriorLbl.AutoSize = True
        Me.ConAnteriorLbl.Location = New System.Drawing.Point(18, 29)
        Me.ConAnteriorLbl.Name = "ConAnteriorLbl"
        Me.ConAnteriorLbl.Size = New System.Drawing.Size(118, 15)
        Me.ConAnteriorLbl.TabIndex = 0
        Me.ConAnteriorLbl.Text = "Contraseña Anterior"
        '
        'ConAnteriorTxt
        '
        Me.ConAnteriorTxt.Location = New System.Drawing.Point(194, 26)
        Me.ConAnteriorTxt.Name = "ConAnteriorTxt"
        Me.ConAnteriorTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ConAnteriorTxt.Size = New System.Drawing.Size(169, 23)
        Me.ConAnteriorTxt.TabIndex = 1
        '
        'NuevaContraseñaLbl
        '
        Me.NuevaContraseñaLbl.AutoSize = True
        Me.NuevaContraseñaLbl.Location = New System.Drawing.Point(18, 58)
        Me.NuevaContraseñaLbl.Name = "NuevaContraseñaLbl"
        Me.NuevaContraseñaLbl.Size = New System.Drawing.Size(107, 15)
        Me.NuevaContraseñaLbl.TabIndex = 3
        Me.NuevaContraseñaLbl.Text = "Nueva Contraseña"
        '
        'ReNuevaContraseñaLbl
        '
        Me.ReNuevaContraseñaLbl.AutoSize = True
        Me.ReNuevaContraseñaLbl.Location = New System.Drawing.Point(18, 87)
        Me.ReNuevaContraseñaLbl.Name = "ReNuevaContraseñaLbl"
        Me.ReNuevaContraseñaLbl.Size = New System.Drawing.Size(171, 15)
        Me.ReNuevaContraseñaLbl.TabIndex = 4
        Me.ReNuevaContraseñaLbl.Text = "Re-Ingresar nueva contraseña"
        '
        'NuevaContraseñaTxt
        '
        Me.NuevaContraseñaTxt.Location = New System.Drawing.Point(194, 55)
        Me.NuevaContraseñaTxt.Name = "NuevaContraseñaTxt"
        Me.NuevaContraseñaTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.NuevaContraseñaTxt.Size = New System.Drawing.Size(169, 23)
        Me.NuevaContraseñaTxt.TabIndex = 2
        '
        'ReNuevaContraseñaTxt
        '
        Me.ReNuevaContraseñaTxt.Location = New System.Drawing.Point(194, 84)
        Me.ReNuevaContraseñaTxt.Name = "ReNuevaContraseñaTxt"
        Me.ReNuevaContraseñaTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ReNuevaContraseñaTxt.Size = New System.Drawing.Size(169, 23)
        Me.ReNuevaContraseñaTxt.TabIndex = 3
        '
        'ContrasenaGB
        '
        Me.ContrasenaGB.Controls.Add(Me.ConAnteriorLbl)
        Me.ContrasenaGB.Controls.Add(Me.ReNuevaContraseñaTxt)
        Me.ContrasenaGB.Controls.Add(Me.ConAnteriorTxt)
        Me.ContrasenaGB.Controls.Add(Me.NuevaContraseñaTxt)
        Me.ContrasenaGB.Controls.Add(Me.NuevaContraseñaLbl)
        Me.ContrasenaGB.Controls.Add(Me.ReNuevaContraseñaLbl)
        Me.ContrasenaGB.Location = New System.Drawing.Point(12, 12)
        Me.ContrasenaGB.Name = "ContrasenaGB"
        Me.ContrasenaGB.Size = New System.Drawing.Size(381, 124)
        Me.ContrasenaGB.TabIndex = 0
        Me.ContrasenaGB.TabStop = False
        Me.ContrasenaGB.Text = "Cambiar Contraseña"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(206, 145)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 5
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(118, 145)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 4
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
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
        'CambiarContrasena
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(406, 178)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.ContrasenaGB)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(412, 207)
        Me.MinimumSize = New System.Drawing.Size(412, 207)
        Me.Name = "CambiarContrasena"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Contraseña - MercaderSG"
        Me.ContrasenaGB.ResumeLayout(False)
        Me.ContrasenaGB.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ConAnteriorLbl As System.Windows.Forms.Label
    Friend WithEvents ConAnteriorTxt As System.Windows.Forms.TextBox
    Friend WithEvents NuevaContraseñaLbl As System.Windows.Forms.Label
    Friend WithEvents ReNuevaContraseñaLbl As System.Windows.Forms.Label
    Friend WithEvents NuevaContraseñaTxt As System.Windows.Forms.TextBox
    Friend WithEvents ReNuevaContraseñaTxt As System.Windows.Forms.TextBox
    Friend WithEvents ContrasenaGB As System.Windows.Forms.GroupBox
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
End Class
