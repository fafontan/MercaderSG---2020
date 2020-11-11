<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroCriticidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroCriticidad))
        Me.CriticidadGB = New System.Windows.Forms.GroupBox()
        Me.CriticidadCMB = New System.Windows.Forms.ComboBox()
        Me.BuscarCritiBtn = New System.Windows.Forms.Button()
        Me.CriticidadLbl = New System.Windows.Forms.Label()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.CriticidadGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CriticidadGB
        '
        Me.CriticidadGB.Controls.Add(Me.CriticidadCMB)
        Me.CriticidadGB.Controls.Add(Me.BuscarCritiBtn)
        Me.CriticidadGB.Controls.Add(Me.CriticidadLbl)
        Me.CriticidadGB.Location = New System.Drawing.Point(3, 3)
        Me.CriticidadGB.Name = "CriticidadGB"
        Me.CriticidadGB.Size = New System.Drawing.Size(626, 100)
        Me.CriticidadGB.TabIndex = 1
        Me.CriticidadGB.TabStop = False
        Me.CriticidadGB.Text = "Buscar por Criticidad"
        '
        'CriticidadCMB
        '
        Me.CriticidadCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CriticidadCMB.FormattingEnabled = True
        Me.CriticidadCMB.Location = New System.Drawing.Point(249, 40)
        Me.CriticidadCMB.Name = "CriticidadCMB"
        Me.CriticidadCMB.Size = New System.Drawing.Size(100, 23)
        Me.CriticidadCMB.TabIndex = 2
        '
        'BuscarCritiBtn
        '
        Me.BuscarCritiBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarCritiBtn.Location = New System.Drawing.Point(361, 35)
        Me.BuscarCritiBtn.Name = "BuscarCritiBtn"
        Me.BuscarCritiBtn.Size = New System.Drawing.Size(84, 30)
        Me.BuscarCritiBtn.TabIndex = 3
        Me.BuscarCritiBtn.Text = "Buscar"
        Me.BuscarCritiBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarCritiBtn.UseVisualStyleBackColor = True
        '
        'CriticidadLbl
        '
        Me.CriticidadLbl.AutoSize = True
        Me.CriticidadLbl.Location = New System.Drawing.Point(182, 43)
        Me.CriticidadLbl.Name = "CriticidadLbl"
        Me.CriticidadLbl.Size = New System.Drawing.Size(61, 15)
        Me.CriticidadLbl.TabIndex = 9
        Me.CriticidadLbl.Text = "Criticidad"
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
        'ErrorP
        '
        Me.ErrorP.BlinkRate = 150
        Me.ErrorP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorP.ContainerControl = Me
        Me.ErrorP.Icon = CType(resources.GetObject("ErrorP.Icon"), System.Drawing.Icon)
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
        'FiltroCriticidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CriticidadGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FiltroCriticidad"
        Me.Size = New System.Drawing.Size(629, 113)
        Me.CriticidadGB.ResumeLayout(False)
        Me.CriticidadGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CriticidadGB As System.Windows.Forms.GroupBox
    Friend WithEvents BuscarCritiBtn As System.Windows.Forms.Button
    Friend WithEvents CriticidadLbl As System.Windows.Forms.Label
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents CriticidadCMB As System.Windows.Forms.ComboBox

End Class
