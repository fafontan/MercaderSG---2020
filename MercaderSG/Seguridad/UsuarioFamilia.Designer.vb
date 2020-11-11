<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsuarioFamilia
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
        Me.PanelesFLP = New System.Windows.Forms.FlowLayoutPanel()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.UsuarioCMB = New System.Windows.Forms.ComboBox()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.FamiliaGB = New System.Windows.Forms.GroupBox()
        Me.FamiliaCLB = New System.Windows.Forms.CheckedListBox()
        Me.UsuarioLbl = New System.Windows.Forms.Label()
        Me.PanelInferior = New System.Windows.Forms.Panel()
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.InformacionLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelesFLP.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.FamiliaGB.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelesFLP
        '
        Me.PanelesFLP.AutoSize = True
        Me.PanelesFLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelesFLP.Controls.Add(Me.PanelSuperior)
        Me.PanelesFLP.Controls.Add(Me.PanelInferior)
        Me.PanelesFLP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelesFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PanelesFLP.Location = New System.Drawing.Point(0, 0)
        Me.PanelesFLP.Name = "PanelesFLP"
        Me.PanelesFLP.Size = New System.Drawing.Size(262, 336)
        Me.PanelesFLP.TabIndex = 1
        '
        'PanelSuperior
        '
        Me.PanelSuperior.AutoSize = True
        Me.PanelSuperior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelSuperior.Controls.Add(Me.UsuarioCMB)
        Me.PanelSuperior.Controls.Add(Me.CancelarBtn)
        Me.PanelSuperior.Controls.Add(Me.AceptarBtn)
        Me.PanelSuperior.Controls.Add(Me.FamiliaGB)
        Me.PanelSuperior.Controls.Add(Me.UsuarioLbl)
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(3, 3)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(255, 302)
        Me.PanelSuperior.TabIndex = 0
        '
        'UsuarioCMB
        '
        Me.UsuarioCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UsuarioCMB.FormattingEnabled = True
        Me.UsuarioCMB.Location = New System.Drawing.Point(98, 13)
        Me.UsuarioCMB.Name = "UsuarioCMB"
        Me.UsuarioCMB.Size = New System.Drawing.Size(121, 23)
        Me.UsuarioCMB.TabIndex = 0
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(133, 275)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 3
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(45, 275)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 2
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'FamiliaGB
        '
        Me.FamiliaGB.Controls.Add(Me.FamiliaCLB)
        Me.FamiliaGB.Location = New System.Drawing.Point(8, 42)
        Me.FamiliaGB.Name = "FamiliaGB"
        Me.FamiliaGB.Size = New System.Drawing.Size(244, 227)
        Me.FamiliaGB.TabIndex = 3
        Me.FamiliaGB.TabStop = False
        Me.FamiliaGB.Text = "Familias"
        '
        'FamiliaCLB
        '
        Me.FamiliaCLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FamiliaCLB.FormattingEnabled = True
        Me.FamiliaCLB.Location = New System.Drawing.Point(3, 19)
        Me.FamiliaCLB.Name = "FamiliaCLB"
        Me.FamiliaCLB.Size = New System.Drawing.Size(238, 205)
        Me.FamiliaCLB.TabIndex = 1
        '
        'UsuarioLbl
        '
        Me.UsuarioLbl.AutoSize = True
        Me.UsuarioLbl.Location = New System.Drawing.Point(41, 16)
        Me.UsuarioLbl.Name = "UsuarioLbl"
        Me.UsuarioLbl.Size = New System.Drawing.Size(51, 15)
        Me.UsuarioLbl.TabIndex = 0
        Me.UsuarioLbl.Text = "Usuario"
        '
        'PanelInferior
        '
        Me.PanelInferior.AutoSize = True
        Me.PanelInferior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelInferior.Controls.Add(Me.SS)
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelInferior.Location = New System.Drawing.Point(3, 311)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(255, 22)
        Me.PanelInferior.TabIndex = 1
        '
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformacionLbl})
        Me.SS.Location = New System.Drawing.Point(0, 0)
        Me.SS.Name = "SS"
        Me.SS.Size = New System.Drawing.Size(255, 22)
        Me.SS.TabIndex = 4
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
        'UsuarioFamilia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(262, 336)
        Me.Controls.Add(Me.PanelesFLP)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "UsuarioFamilia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelesFLP.ResumeLayout(False)
        Me.PanelesFLP.PerformLayout()
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelSuperior.PerformLayout()
        Me.FamiliaGB.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        Me.PanelInferior.PerformLayout()
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelesFLP As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PanelSuperior As System.Windows.Forms.Panel
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents FamiliaGB As System.Windows.Forms.GroupBox
    Friend WithEvents FamiliaCLB As System.Windows.Forms.CheckedListBox
    Friend WithEvents UsuarioLbl As System.Windows.Forms.Label
    Friend WithEvents UsuarioCMB As System.Windows.Forms.ComboBox
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents InformacionLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PanelInferior As System.Windows.Forms.Panel
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
End Class
