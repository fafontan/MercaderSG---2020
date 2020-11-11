<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroCompleto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroCompleto))
        Me.CompletoGB = New System.Windows.Forms.GroupBox()
        Me.CriticidadCMB = New System.Windows.Forms.ComboBox()
        Me.UsuarioCMB = New System.Windows.Forms.ComboBox()
        Me.HastaComDTP = New System.Windows.Forms.DateTimePicker()
        Me.DesdeComDTP = New System.Windows.Forms.DateTimePicker()
        Me.BuscarComBtn = New System.Windows.Forms.Button()
        Me.CritiComLbl = New System.Windows.Forms.Label()
        Me.UsuComLbl = New System.Windows.Forms.Label()
        Me.HastaComLbl = New System.Windows.Forms.Label()
        Me.DesdeComLbl = New System.Windows.Forms.Label()
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.CompletoGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CompletoGB
        '
        Me.CompletoGB.Controls.Add(Me.CriticidadCMB)
        Me.CompletoGB.Controls.Add(Me.UsuarioCMB)
        Me.CompletoGB.Controls.Add(Me.HastaComDTP)
        Me.CompletoGB.Controls.Add(Me.DesdeComDTP)
        Me.CompletoGB.Controls.Add(Me.BuscarComBtn)
        Me.CompletoGB.Controls.Add(Me.CritiComLbl)
        Me.CompletoGB.Controls.Add(Me.UsuComLbl)
        Me.CompletoGB.Controls.Add(Me.HastaComLbl)
        Me.CompletoGB.Controls.Add(Me.DesdeComLbl)
        Me.CompletoGB.Location = New System.Drawing.Point(3, 3)
        Me.CompletoGB.Name = "CompletoGB"
        Me.CompletoGB.Size = New System.Drawing.Size(626, 100)
        Me.CompletoGB.TabIndex = 1
        Me.CompletoGB.TabStop = False
        Me.CompletoGB.Text = "Filtro Completo"
        '
        'CriticidadCMB
        '
        Me.CriticidadCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CriticidadCMB.FormattingEnabled = True
        Me.CriticidadCMB.Location = New System.Drawing.Point(337, 69)
        Me.CriticidadCMB.Name = "CriticidadCMB"
        Me.CriticidadCMB.Size = New System.Drawing.Size(100, 23)
        Me.CriticidadCMB.TabIndex = 5
        '
        'UsuarioCMB
        '
        Me.UsuarioCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UsuarioCMB.FormattingEnabled = True
        Me.UsuarioCMB.Location = New System.Drawing.Point(147, 69)
        Me.UsuarioCMB.Name = "UsuarioCMB"
        Me.UsuarioCMB.Size = New System.Drawing.Size(100, 23)
        Me.UsuarioCMB.TabIndex = 4
        '
        'HastaComDTP
        '
        Me.HastaComDTP.Checked = False
        Me.HastaComDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.HastaComDTP.Location = New System.Drawing.Point(337, 27)
        Me.HastaComDTP.Name = "HastaComDTP"
        Me.HastaComDTP.Size = New System.Drawing.Size(100, 23)
        Me.HastaComDTP.TabIndex = 3
        '
        'DesdeComDTP
        '
        Me.DesdeComDTP.Checked = False
        Me.DesdeComDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DesdeComDTP.Location = New System.Drawing.Point(147, 27)
        Me.DesdeComDTP.Name = "DesdeComDTP"
        Me.DesdeComDTP.Size = New System.Drawing.Size(100, 23)
        Me.DesdeComDTP.TabIndex = 2
        '
        'BuscarComBtn
        '
        Me.BuscarComBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarComBtn.Location = New System.Drawing.Point(452, 46)
        Me.BuscarComBtn.Name = "BuscarComBtn"
        Me.BuscarComBtn.Size = New System.Drawing.Size(84, 30)
        Me.BuscarComBtn.TabIndex = 6
        Me.BuscarComBtn.Text = "Buscar"
        Me.BuscarComBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarComBtn.UseVisualStyleBackColor = True
        '
        'CritiComLbl
        '
        Me.CritiComLbl.AutoSize = True
        Me.CritiComLbl.Location = New System.Drawing.Point(266, 72)
        Me.CritiComLbl.Name = "CritiComLbl"
        Me.CritiComLbl.Size = New System.Drawing.Size(61, 15)
        Me.CritiComLbl.TabIndex = 3
        Me.CritiComLbl.Text = "Criticidad"
        '
        'UsuComLbl
        '
        Me.UsuComLbl.AutoSize = True
        Me.UsuComLbl.Location = New System.Drawing.Point(90, 72)
        Me.UsuComLbl.Name = "UsuComLbl"
        Me.UsuComLbl.Size = New System.Drawing.Size(51, 15)
        Me.UsuComLbl.TabIndex = 2
        Me.UsuComLbl.Text = "Usuario"
        '
        'HastaComLbl
        '
        Me.HastaComLbl.AutoSize = True
        Me.HastaComLbl.Location = New System.Drawing.Point(268, 33)
        Me.HastaComLbl.Name = "HastaComLbl"
        Me.HastaComLbl.Size = New System.Drawing.Size(39, 15)
        Me.HastaComLbl.TabIndex = 1
        Me.HastaComLbl.Text = "Hasta"
        '
        'DesdeComLbl
        '
        Me.DesdeComLbl.AutoSize = True
        Me.DesdeComLbl.Location = New System.Drawing.Point(90, 33)
        Me.DesdeComLbl.Name = "DesdeComLbl"
        Me.DesdeComLbl.Size = New System.Drawing.Size(40, 15)
        Me.DesdeComLbl.TabIndex = 0
        Me.DesdeComLbl.Text = "Desde"
        '
        'ErrorP
        '
        Me.ErrorP.BlinkRate = 150
        Me.ErrorP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorP.ContainerControl = Me
        Me.ErrorP.Icon = CType(resources.GetObject("ErrorP.Icon"), System.Drawing.Icon)
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
        'FiltroCompleto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CompletoGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FiltroCompleto"
        Me.Size = New System.Drawing.Size(629, 113)
        Me.CompletoGB.ResumeLayout(False)
        Me.CompletoGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CompletoGB As System.Windows.Forms.GroupBox
    Friend WithEvents HastaComDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents DesdeComDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents BuscarComBtn As System.Windows.Forms.Button
    Friend WithEvents CritiComLbl As System.Windows.Forms.Label
    Friend WithEvents UsuComLbl As System.Windows.Forms.Label
    Friend WithEvents HastaComLbl As System.Windows.Forms.Label
    Friend WithEvents DesdeComLbl As System.Windows.Forms.Label
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents UsuarioCMB As System.Windows.Forms.ComboBox
    Friend WithEvents CriticidadCMB As System.Windows.Forms.ComboBox

End Class
