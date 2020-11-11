<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsuarioPatente
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
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.FLP = New System.Windows.Forms.FlowLayoutPanel()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.PatDenegadasGB = New System.Windows.Forms.GroupBox()
        Me.PatDenegadasCLB = New System.Windows.Forms.CheckedListBox()
        Me.UsuariosCMB = New System.Windows.Forms.ComboBox()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.UsuarioLbl = New System.Windows.Forms.Label()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.DenPatentesGB = New System.Windows.Forms.GroupBox()
        Me.DenPatentesCLB = New System.Windows.Forms.CheckedListBox()
        Me.PatentesGB = New System.Windows.Forms.GroupBox()
        Me.PatentesCLB = New System.Windows.Forms.CheckedListBox()
        Me.PanelInferior = New System.Windows.Forms.Panel()
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.InformacionLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.FLP.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PatDenegadasGB.SuspendLayout()
        Me.DenPatentesGB.SuspendLayout()
        Me.PatentesGB.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.SuspendLayout()
        '
        'MensajeTT
        '
        Me.MensajeTT.AutomaticDelay = 100
        Me.MensajeTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.MensajeTT.ToolTipTitle = "MercaderSG"
        '
        'FLP
        '
        Me.FLP.AutoSize = True
        Me.FLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FLP.Controls.Add(Me.PanelSuperior)
        Me.FLP.Controls.Add(Me.PanelInferior)
        Me.FLP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FLP.Location = New System.Drawing.Point(0, 0)
        Me.FLP.Name = "FLP"
        Me.FLP.Size = New System.Drawing.Size(804, 359)
        Me.FLP.TabIndex = 0
        '
        'PanelSuperior
        '
        Me.PanelSuperior.AutoSize = True
        Me.PanelSuperior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelSuperior.Controls.Add(Me.PatDenegadasGB)
        Me.PanelSuperior.Controls.Add(Me.UsuariosCMB)
        Me.PanelSuperior.Controls.Add(Me.BuscarBtn)
        Me.PanelSuperior.Controls.Add(Me.UsuarioLbl)
        Me.PanelSuperior.Controls.Add(Me.CancelarBtn)
        Me.PanelSuperior.Controls.Add(Me.AceptarBtn)
        Me.PanelSuperior.Controls.Add(Me.DenPatentesGB)
        Me.PanelSuperior.Controls.Add(Me.PatentesGB)
        Me.PanelSuperior.Location = New System.Drawing.Point(3, 3)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(797, 325)
        Me.PanelSuperior.TabIndex = 0
        '
        'PatDenegadasGB
        '
        Me.PatDenegadasGB.Controls.Add(Me.PatDenegadasCLB)
        Me.PatDenegadasGB.Location = New System.Drawing.Point(267, 49)
        Me.PatDenegadasGB.Name = "PatDenegadasGB"
        Me.PatDenegadasGB.Size = New System.Drawing.Size(261, 242)
        Me.PatDenegadasGB.TabIndex = 12
        Me.PatDenegadasGB.TabStop = False
        Me.PatDenegadasGB.Text = "Patentes Denegadas (Asignar)"
        '
        'PatDenegadasCLB
        '
        Me.PatDenegadasCLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PatDenegadasCLB.FormattingEnabled = True
        Me.PatDenegadasCLB.Location = New System.Drawing.Point(3, 19)
        Me.PatDenegadasCLB.Name = "PatDenegadasCLB"
        Me.PatDenegadasCLB.Size = New System.Drawing.Size(255, 220)
        Me.PatDenegadasCLB.TabIndex = 3
        '
        'UsuariosCMB
        '
        Me.UsuariosCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UsuariosCMB.FormattingEnabled = True
        Me.UsuariosCMB.Location = New System.Drawing.Point(351, 10)
        Me.UsuariosCMB.Name = "UsuariosCMB"
        Me.UsuariosCMB.Size = New System.Drawing.Size(121, 23)
        Me.UsuariosCMB.TabIndex = 0
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.search
        Me.BuscarBtn.Location = New System.Drawing.Point(478, 10)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(24, 23)
        Me.BuscarBtn.TabIndex = 1
        Me.BuscarBtn.UseVisualStyleBackColor = True
        '
        'UsuarioLbl
        '
        Me.UsuarioLbl.AutoSize = True
        Me.UsuarioLbl.Location = New System.Drawing.Point(294, 14)
        Me.UsuarioLbl.Name = "UsuarioLbl"
        Me.UsuarioLbl.Size = New System.Drawing.Size(51, 15)
        Me.UsuarioLbl.TabIndex = 14
        Me.UsuarioLbl.Text = "Usuario"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(401, 298)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 6
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(313, 298)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 5
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'DenPatentesGB
        '
        Me.DenPatentesGB.Controls.Add(Me.DenPatentesCLB)
        Me.DenPatentesGB.Location = New System.Drawing.Point(533, 49)
        Me.DenPatentesGB.Name = "DenPatentesGB"
        Me.DenPatentesGB.Size = New System.Drawing.Size(261, 242)
        Me.DenPatentesGB.TabIndex = 10
        Me.DenPatentesGB.TabStop = False
        Me.DenPatentesGB.Text = "Denegar Patentes"
        '
        'DenPatentesCLB
        '
        Me.DenPatentesCLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DenPatentesCLB.FormattingEnabled = True
        Me.DenPatentesCLB.Location = New System.Drawing.Point(3, 19)
        Me.DenPatentesCLB.Name = "DenPatentesCLB"
        Me.DenPatentesCLB.Size = New System.Drawing.Size(255, 220)
        Me.DenPatentesCLB.TabIndex = 4
        '
        'PatentesGB
        '
        Me.PatentesGB.Controls.Add(Me.PatentesCLB)
        Me.PatentesGB.Location = New System.Drawing.Point(3, 49)
        Me.PatentesGB.Name = "PatentesGB"
        Me.PatentesGB.Size = New System.Drawing.Size(261, 242)
        Me.PatentesGB.TabIndex = 11
        Me.PatentesGB.TabStop = False
        Me.PatentesGB.Text = "Asignar Patentes"
        '
        'PatentesCLB
        '
        Me.PatentesCLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PatentesCLB.FormattingEnabled = True
        Me.PatentesCLB.Location = New System.Drawing.Point(3, 19)
        Me.PatentesCLB.Name = "PatentesCLB"
        Me.PatentesCLB.Size = New System.Drawing.Size(255, 220)
        Me.PatentesCLB.TabIndex = 2
        '
        'PanelInferior
        '
        Me.PanelInferior.AutoSize = True
        Me.PanelInferior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelInferior.Controls.Add(Me.SS)
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelInferior.Location = New System.Drawing.Point(3, 334)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(797, 22)
        Me.PanelInferior.TabIndex = 1
        '
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformacionLbl})
        Me.SS.Location = New System.Drawing.Point(0, 0)
        Me.SS.Name = "SS"
        Me.SS.Size = New System.Drawing.Size(797, 22)
        Me.SS.TabIndex = 6
        Me.SS.Text = "StatusStrip1"
        '
        'InformacionLbl
        '
        Me.InformacionLbl.ActiveLinkColor = System.Drawing.Color.Blue
        Me.InformacionLbl.Image = Global.MercaderSG.My.Resources.Resources.InfoDocE
        Me.InformacionLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InformacionLbl.IsLink = True
        Me.InformacionLbl.Name = "InformacionLbl"
        Me.InformacionLbl.Size = New System.Drawing.Size(159, 17)
        Me.InformacionLbl.Text = "Resultado de la operación"
        Me.InformacionLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.InformacionLbl.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
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
        'UsuarioPatente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(804, 359)
        Me.Controls.Add(Me.FLP)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "UsuarioPatente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.FLP.ResumeLayout(False)
        Me.FLP.PerformLayout()
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelSuperior.PerformLayout()
        Me.PatDenegadasGB.ResumeLayout(False)
        Me.DenPatentesGB.ResumeLayout(False)
        Me.PatentesGB.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        Me.PanelInferior.PerformLayout()
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents FLP As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PanelSuperior As System.Windows.Forms.Panel
    Friend WithEvents PanelInferior As System.Windows.Forms.Panel
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents DenPatentesGB As System.Windows.Forms.GroupBox
    Friend WithEvents DenPatentesCLB As System.Windows.Forms.CheckedListBox
    Friend WithEvents PatentesGB As System.Windows.Forms.GroupBox
    Friend WithEvents PatentesCLB As System.Windows.Forms.CheckedListBox
    Friend WithEvents UsuariosCMB As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents UsuarioLbl As System.Windows.Forms.Label
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents InformacionLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PatDenegadasGB As System.Windows.Forms.GroupBox
    Friend WithEvents PatDenegadasCLB As System.Windows.Forms.CheckedListBox
End Class
