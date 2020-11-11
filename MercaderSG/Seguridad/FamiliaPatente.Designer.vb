<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FamiliaPatente
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
        Me.PanelFLP = New System.Windows.Forms.FlowLayoutPanel()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.PatentesGB = New System.Windows.Forms.GroupBox()
        Me.DenPatentesCLB = New System.Windows.Forms.CheckedListBox()
        Me.FamiliaCMB = New System.Windows.Forms.ComboBox()
        Me.FamiliaLbl = New System.Windows.Forms.Label()
        Me.PatentesNoGB = New System.Windows.Forms.GroupBox()
        Me.PatentesCLB = New System.Windows.Forms.CheckedListBox()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.PanelInferior = New System.Windows.Forms.Panel()
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.InformacionLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelFLP.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PatentesGB.SuspendLayout()
        Me.PatentesNoGB.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelFLP
        '
        Me.PanelFLP.AutoSize = True
        Me.PanelFLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelFLP.Controls.Add(Me.PanelSuperior)
        Me.PanelFLP.Controls.Add(Me.PanelInferior)
        Me.PanelFLP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PanelFLP.Location = New System.Drawing.Point(0, 0)
        Me.PanelFLP.Name = "PanelFLP"
        Me.PanelFLP.Size = New System.Drawing.Size(558, 345)
        Me.PanelFLP.TabIndex = 23
        '
        'PanelSuperior
        '
        Me.PanelSuperior.AutoSize = True
        Me.PanelSuperior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelSuperior.Controls.Add(Me.BuscarBtn)
        Me.PanelSuperior.Controls.Add(Me.PatentesGB)
        Me.PanelSuperior.Controls.Add(Me.FamiliaCMB)
        Me.PanelSuperior.Controls.Add(Me.FamiliaLbl)
        Me.PanelSuperior.Controls.Add(Me.PatentesNoGB)
        Me.PanelSuperior.Controls.Add(Me.CancelarBtn)
        Me.PanelSuperior.Controls.Add(Me.AceptarBtn)
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(3, 3)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(550, 311)
        Me.PanelSuperior.TabIndex = 21
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.search
        Me.BuscarBtn.Location = New System.Drawing.Point(354, 9)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(24, 23)
        Me.BuscarBtn.TabIndex = 1
        Me.BuscarBtn.UseVisualStyleBackColor = True
        '
        'PatentesGB
        '
        Me.PatentesGB.Controls.Add(Me.DenPatentesCLB)
        Me.PatentesGB.Location = New System.Drawing.Point(278, 38)
        Me.PatentesGB.Name = "PatentesGB"
        Me.PatentesGB.Size = New System.Drawing.Size(269, 240)
        Me.PatentesGB.TabIndex = 7
        Me.PatentesGB.TabStop = False
        Me.PatentesGB.Text = "Patentes que posee la familia (Baja)"
        '
        'DenPatentesCLB
        '
        Me.DenPatentesCLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DenPatentesCLB.FormattingEnabled = True
        Me.DenPatentesCLB.Location = New System.Drawing.Point(3, 19)
        Me.DenPatentesCLB.Name = "DenPatentesCLB"
        Me.DenPatentesCLB.Size = New System.Drawing.Size(263, 218)
        Me.DenPatentesCLB.TabIndex = 3
        '
        'FamiliaCMB
        '
        Me.FamiliaCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FamiliaCMB.FormattingEnabled = True
        Me.FamiliaCMB.Location = New System.Drawing.Point(227, 9)
        Me.FamiliaCMB.Name = "FamiliaCMB"
        Me.FamiliaCMB.Size = New System.Drawing.Size(121, 23)
        Me.FamiliaCMB.TabIndex = 0
        '
        'FamiliaLbl
        '
        Me.FamiliaLbl.AutoSize = True
        Me.FamiliaLbl.Location = New System.Drawing.Point(172, 12)
        Me.FamiliaLbl.Name = "FamiliaLbl"
        Me.FamiliaLbl.Size = New System.Drawing.Size(49, 15)
        Me.FamiliaLbl.TabIndex = 5
        Me.FamiliaLbl.Text = "Familia"
        '
        'PatentesNoGB
        '
        Me.PatentesNoGB.Controls.Add(Me.PatentesCLB)
        Me.PatentesNoGB.Location = New System.Drawing.Point(3, 38)
        Me.PatentesNoGB.Name = "PatentesNoGB"
        Me.PatentesNoGB.Size = New System.Drawing.Size(269, 240)
        Me.PatentesNoGB.TabIndex = 0
        Me.PatentesNoGB.TabStop = False
        Me.PatentesNoGB.Text = "Patentes que no posee la familia (Alta)"
        '
        'PatentesCLB
        '
        Me.PatentesCLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PatentesCLB.FormattingEnabled = True
        Me.PatentesCLB.Location = New System.Drawing.Point(3, 19)
        Me.PatentesCLB.Name = "PatentesCLB"
        Me.PatentesCLB.Size = New System.Drawing.Size(263, 218)
        Me.PatentesCLB.TabIndex = 2
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(279, 284)
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
        Me.AceptarBtn.Location = New System.Drawing.Point(191, 284)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 4
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'PanelInferior
        '
        Me.PanelInferior.Controls.Add(Me.SS)
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelInferior.Location = New System.Drawing.Point(3, 320)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(550, 22)
        Me.PanelInferior.TabIndex = 23
        '
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformacionLbl})
        Me.SS.Location = New System.Drawing.Point(0, 0)
        Me.SS.Name = "SS"
        Me.SS.Size = New System.Drawing.Size(550, 22)
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
        'FamiliaPatente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(558, 345)
        Me.Controls.Add(Me.PanelFLP)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FamiliaPatente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelFLP.ResumeLayout(False)
        Me.PanelFLP.PerformLayout()
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelSuperior.PerformLayout()
        Me.PatentesGB.ResumeLayout(False)
        Me.PatentesNoGB.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        Me.PanelInferior.PerformLayout()
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelFLP As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PanelInferior As System.Windows.Forms.Panel
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents InformacionLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PanelSuperior As System.Windows.Forms.Panel
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents PatentesGB As System.Windows.Forms.GroupBox
    Friend WithEvents DenPatentesCLB As System.Windows.Forms.CheckedListBox
    Friend WithEvents FamiliaCMB As System.Windows.Forms.ComboBox
    Friend WithEvents FamiliaLbl As System.Windows.Forms.Label
    Friend WithEvents PatentesNoGB As System.Windows.Forms.GroupBox
    Friend WithEvents PatentesCLB As System.Windows.Forms.CheckedListBox
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
End Class
