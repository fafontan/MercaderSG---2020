Imports System.Configuration

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogIn
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
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.UsuarioLbl = New System.Windows.Forms.Label()
        Me.ContraseñaLbl = New System.Windows.Forms.Label()
        Me.UsuarioTxt = New System.Windows.Forms.TextBox()
        Me.ContraseñaTxt = New System.Windows.Forms.TextBox()
        Me.LoginPB = New System.Windows.Forms.PictureBox()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.CancelarBtn = New System.Windows.Forms.Button()
        CType(Me.LoginPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(171, 102)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 2
        Me.AceptarBtn.Text = "&Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'UsuarioLbl
        '
        Me.UsuarioLbl.AutoSize = True
        Me.UsuarioLbl.Location = New System.Drawing.Point(88, 32)
        Me.UsuarioLbl.Name = "UsuarioLbl"
        Me.UsuarioLbl.Size = New System.Drawing.Size(51, 15)
        Me.UsuarioLbl.TabIndex = 2
        Me.UsuarioLbl.Text = "Usuario"
        '
        'ContraseñaLbl
        '
        Me.ContraseñaLbl.AutoSize = True
        Me.ContraseñaLbl.Location = New System.Drawing.Point(88, 65)
        Me.ContraseñaLbl.Name = "ContraseñaLbl"
        Me.ContraseñaLbl.Size = New System.Drawing.Size(70, 15)
        Me.ContraseñaLbl.TabIndex = 3
        Me.ContraseñaLbl.Text = "Contraseña"
        '
        'UsuarioTxt
        '
        Me.UsuarioTxt.Location = New System.Drawing.Point(171, 29)
        Me.UsuarioTxt.Name = "UsuarioTxt"
        Me.UsuarioTxt.Size = New System.Drawing.Size(168, 23)
        Me.UsuarioTxt.TabIndex = 0
        '
        'ContraseñaTxt
        '
        Me.ContraseñaTxt.Location = New System.Drawing.Point(171, 63)
        Me.ContraseñaTxt.Name = "ContraseñaTxt"
        Me.ContraseñaTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ContraseñaTxt.Size = New System.Drawing.Size(168, 23)
        Me.ContraseñaTxt.TabIndex = 1
        '
        'LoginPB
        '
        Me.LoginPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LoginPB.Image = Global.MercaderSG.My.Resources.Resources.LogInE
        Me.LoginPB.Location = New System.Drawing.Point(18, 22)
        Me.LoginPB.Name = "LoginPB"
        Me.LoginPB.Size = New System.Drawing.Size(64, 64)
        Me.LoginPB.TabIndex = 6
        Me.LoginPB.TabStop = False
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
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(257, 102)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 7
        Me.CancelarBtn.Text = "&Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'LogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(359, 142)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.LoginPB)
        Me.Controls.Add(Me.UsuarioLbl)
        Me.Controls.Add(Me.UsuarioTxt)
        Me.Controls.Add(Me.ContraseñaTxt)
        Me.Controls.Add(Me.ContraseñaLbl)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(365, 171)
        Me.MinimumSize = New System.Drawing.Size(365, 171)
        Me.Name = "LogIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Sesión - MercaderSG"
        CType(Me.LoginPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents UsuarioLbl As System.Windows.Forms.Label
    Friend WithEvents ContraseñaLbl As System.Windows.Forms.Label
    Friend WithEvents UsuarioTxt As System.Windows.Forms.TextBox
    Friend WithEvents ContraseñaTxt As System.Windows.Forms.TextBox
    Friend WithEvents LoginPB As System.Windows.Forms.PictureBox
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
End Class
