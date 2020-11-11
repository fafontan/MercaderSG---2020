<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bitacora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bitacora))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ExportarCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportarAXLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.DepurarBtn = New System.Windows.Forms.Button()
        Me.FiltroLbl = New System.Windows.Forms.Label()
        Me.FiltroCMB = New System.Windows.Forms.ComboBox()
        Me.PanelMedio = New System.Windows.Forms.Panel()
        Me.PanelInferior = New System.Windows.Forms.Panel()
        Me.RecargarBtn = New System.Windows.Forms.Button()
        Me.SiguienteBtn = New System.Windows.Forms.Button()
        Me.AnteriorBtn = New System.Windows.Forms.Button()
        Me.UltimoBtn = New System.Windows.Forms.Button()
        Me.PrimeroBtn = New System.Windows.Forms.Button()
        Me.RegistrosGB = New System.Windows.Forms.GroupBox()
        Me.BitacoraDG = New System.Windows.Forms.DataGridView()
        Me.CodBitCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CriticidadCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelStatus = New System.Windows.Forms.Panel()
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.Parte1Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.InfoPagLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Parte2Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ExportarCMS.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        Me.RegistrosGB.SuspendLayout()
        CType(Me.BitacoraDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelStatus.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExportarCMS
        '
        Me.ExportarCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAXLSToolStripMenuItem})
        Me.ExportarCMS.Name = "ExportarCMS"
        Me.ExportarCMS.Size = New System.Drawing.Size(149, 26)
        '
        'ExportarAXLSToolStripMenuItem
        '
        Me.ExportarAXLSToolStripMenuItem.Image = Global.MercaderSG.My.Resources.Resources.ExcelE
        Me.ExportarAXLSToolStripMenuItem.Name = "ExportarAXLSToolStripMenuItem"
        Me.ExportarAXLSToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ExportarAXLSToolStripMenuItem.Text = "Exportar a XLS"
        '
        'BGW
        '
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
        'ErrorP
        '
        Me.ErrorP.BlinkRate = 150
        Me.ErrorP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorP.ContainerControl = Me
        Me.ErrorP.Icon = CType(resources.GetObject("ErrorP.Icon"), System.Drawing.Icon)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Controls.Add(Me.DepurarBtn)
        Me.PanelSuperior.Controls.Add(Me.FiltroLbl)
        Me.PanelSuperior.Controls.Add(Me.FiltroCMB)
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(633, 46)
        Me.PanelSuperior.TabIndex = 998
        '
        'DepurarBtn
        '
        Me.DepurarBtn.Image = Global.MercaderSG.My.Resources.Resources.Clear
        Me.DepurarBtn.Location = New System.Drawing.Point(458, 9)
        Me.DepurarBtn.Name = "DepurarBtn"
        Me.DepurarBtn.Size = New System.Drawing.Size(133, 29)
        Me.DepurarBtn.TabIndex = 13
        Me.DepurarBtn.Text = "Depurar Bitácora"
        Me.DepurarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.DepurarBtn.UseVisualStyleBackColor = True
        '
        'FiltroLbl
        '
        Me.FiltroLbl.AutoSize = True
        Me.FiltroLbl.Location = New System.Drawing.Point(225, 16)
        Me.FiltroLbl.Name = "FiltroLbl"
        Me.FiltroLbl.Size = New System.Drawing.Size(37, 15)
        Me.FiltroLbl.TabIndex = 68
        Me.FiltroLbl.Text = "Filtro"
        '
        'FiltroCMB
        '
        Me.FiltroCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FiltroCMB.FormattingEnabled = True
        Me.FiltroCMB.Location = New System.Drawing.Point(268, 12)
        Me.FiltroCMB.Name = "FiltroCMB"
        Me.FiltroCMB.Size = New System.Drawing.Size(140, 23)
        Me.FiltroCMB.TabIndex = 0
        '
        'PanelMedio
        '
        Me.PanelMedio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelMedio.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMedio.Location = New System.Drawing.Point(0, 46)
        Me.PanelMedio.Name = "PanelMedio"
        Me.PanelMedio.Size = New System.Drawing.Size(633, 113)
        Me.PanelMedio.TabIndex = 999
        '
        'PanelInferior
        '
        Me.PanelInferior.Controls.Add(Me.RecargarBtn)
        Me.PanelInferior.Controls.Add(Me.SiguienteBtn)
        Me.PanelInferior.Controls.Add(Me.AnteriorBtn)
        Me.PanelInferior.Controls.Add(Me.UltimoBtn)
        Me.PanelInferior.Controls.Add(Me.PrimeroBtn)
        Me.PanelInferior.Controls.Add(Me.RegistrosGB)
        Me.PanelInferior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelInferior.Location = New System.Drawing.Point(0, 159)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(633, 415)
        Me.PanelInferior.TabIndex = 1000
        '
        'RecargarBtn
        '
        Me.RecargarBtn.Image = Global.MercaderSG.My.Resources.Resources.RecargarE
        Me.RecargarBtn.Location = New System.Drawing.Point(298, 383)
        Me.RecargarBtn.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
        Me.RecargarBtn.Name = "RecargarBtn"
        Me.RecargarBtn.Size = New System.Drawing.Size(32, 24)
        Me.RecargarBtn.TabIndex = 8
        Me.RecargarBtn.UseVisualStyleBackColor = True
        '
        'SiguienteBtn
        '
        Me.SiguienteBtn.Image = Global.MercaderSG.My.Resources.Resources.SiguienteE
        Me.SiguienteBtn.Location = New System.Drawing.Point(348, 383)
        Me.SiguienteBtn.Name = "SiguienteBtn"
        Me.SiguienteBtn.Size = New System.Drawing.Size(32, 24)
        Me.SiguienteBtn.TabIndex = 11
        Me.SiguienteBtn.UseVisualStyleBackColor = True
        '
        'AnteriorBtn
        '
        Me.AnteriorBtn.Image = Global.MercaderSG.My.Resources.Resources.AnteriorE
        Me.AnteriorBtn.Location = New System.Drawing.Point(248, 383)
        Me.AnteriorBtn.Name = "AnteriorBtn"
        Me.AnteriorBtn.Size = New System.Drawing.Size(32, 24)
        Me.AnteriorBtn.TabIndex = 10
        Me.AnteriorBtn.UseVisualStyleBackColor = True
        '
        'UltimoBtn
        '
        Me.UltimoBtn.Image = Global.MercaderSG.My.Resources.Resources.UltimoE
        Me.UltimoBtn.Location = New System.Drawing.Point(386, 383)
        Me.UltimoBtn.Name = "UltimoBtn"
        Me.UltimoBtn.Size = New System.Drawing.Size(32, 24)
        Me.UltimoBtn.TabIndex = 12
        Me.UltimoBtn.UseVisualStyleBackColor = True
        '
        'PrimeroBtn
        '
        Me.PrimeroBtn.Image = Global.MercaderSG.My.Resources.Resources.PrimeroE
        Me.PrimeroBtn.Location = New System.Drawing.Point(210, 383)
        Me.PrimeroBtn.Name = "PrimeroBtn"
        Me.PrimeroBtn.Size = New System.Drawing.Size(32, 24)
        Me.PrimeroBtn.TabIndex = 9
        Me.PrimeroBtn.UseVisualStyleBackColor = True
        '
        'RegistrosGB
        '
        Me.RegistrosGB.Controls.Add(Me.BitacoraDG)
        Me.RegistrosGB.Location = New System.Drawing.Point(3, 6)
        Me.RegistrosGB.Name = "RegistrosGB"
        Me.RegistrosGB.Size = New System.Drawing.Size(626, 371)
        Me.RegistrosGB.TabIndex = 19
        Me.RegistrosGB.TabStop = False
        Me.RegistrosGB.Text = "Registros"
        '
        'BitacoraDG
        '
        Me.BitacoraDG.AllowUserToAddRows = False
        Me.BitacoraDG.AllowUserToDeleteRows = False
        Me.BitacoraDG.AllowUserToResizeColumns = False
        Me.BitacoraDG.AllowUserToResizeRows = False
        Me.BitacoraDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BitacoraDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodBitCAB, Me.FechaCAB, Me.DescripcionCAB, Me.CriticidadCAB, Me.UsuarioCAB})
        Me.BitacoraDG.ContextMenuStrip = Me.ExportarCMS
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.BitacoraDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.BitacoraDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BitacoraDG.Location = New System.Drawing.Point(3, 19)
        Me.BitacoraDG.Name = "BitacoraDG"
        Me.BitacoraDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BitacoraDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.BitacoraDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BitacoraDG.Size = New System.Drawing.Size(620, 349)
        Me.BitacoraDG.StandardTab = True
        Me.BitacoraDG.TabIndex = 7
        '
        'CodBitCAB
        '
        Me.CodBitCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CodBitCAB.DataPropertyName = "CodBit"
        Me.CodBitCAB.HeaderText = "Código"
        Me.CodBitCAB.Name = "CodBitCAB"
        Me.CodBitCAB.ReadOnly = True
        Me.CodBitCAB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.CodBitCAB.Visible = False
        Me.CodBitCAB.Width = 80
        '
        'FechaCAB
        '
        Me.FechaCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FechaCAB.DataPropertyName = "Fecha"
        Me.FechaCAB.HeaderText = "Fecha"
        Me.FechaCAB.Name = "FechaCAB"
        Me.FechaCAB.ReadOnly = True
        Me.FechaCAB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.FechaCAB.Width = 125
        '
        'DescripcionCAB
        '
        Me.DescripcionCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DescripcionCAB.DataPropertyName = "Descripcion"
        Me.DescripcionCAB.HeaderText = "Descripción"
        Me.DescripcionCAB.Name = "DescripcionCAB"
        Me.DescripcionCAB.ReadOnly = True
        Me.DescripcionCAB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DescripcionCAB.Width = 228
        '
        'CriticidadCAB
        '
        Me.CriticidadCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CriticidadCAB.DataPropertyName = "Criticidad"
        Me.CriticidadCAB.HeaderText = "Criticidad"
        Me.CriticidadCAB.Name = "CriticidadCAB"
        Me.CriticidadCAB.ReadOnly = True
        Me.CriticidadCAB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.CriticidadCAB.Width = 80
        '
        'UsuarioCAB
        '
        Me.UsuarioCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UsuarioCAB.DataPropertyName = "Usuario"
        Me.UsuarioCAB.HeaderText = "Usuario"
        Me.UsuarioCAB.Name = "UsuarioCAB"
        Me.UsuarioCAB.ReadOnly = True
        Me.UsuarioCAB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.UsuarioCAB.Width = 125
        '
        'PanelStatus
        '
        Me.PanelStatus.Controls.Add(Me.SS)
        Me.PanelStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelStatus.Location = New System.Drawing.Point(0, 572)
        Me.PanelStatus.Name = "PanelStatus"
        Me.PanelStatus.Size = New System.Drawing.Size(633, 27)
        Me.PanelStatus.TabIndex = 1001
        '
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Parte1Lbl, Me.InfoPagLbl, Me.Parte2Lbl})
        Me.SS.Location = New System.Drawing.Point(0, 5)
        Me.SS.Name = "SS"
        Me.SS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SS.Size = New System.Drawing.Size(633, 22)
        Me.SS.TabIndex = 65
        Me.SS.Text = "StatusStrip1"
        '
        'Parte1Lbl
        '
        Me.Parte1Lbl.Name = "Parte1Lbl"
        Me.Parte1Lbl.Size = New System.Drawing.Size(17, 17)
        Me.Parte1Lbl.Text = "--"
        '
        'InfoPagLbl
        '
        Me.InfoPagLbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.InfoPagLbl.Name = "InfoPagLbl"
        Me.InfoPagLbl.Size = New System.Drawing.Size(17, 17)
        Me.InfoPagLbl.Text = "xx"
        '
        'Parte2Lbl
        '
        Me.Parte2Lbl.Name = "Parte2Lbl"
        Me.Parte2Lbl.Size = New System.Drawing.Size(17, 17)
        Me.Parte2Lbl.Text = "--"
        '
        'Bitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(633, 599)
        Me.Controls.Add(Me.PanelStatus)
        Me.Controls.Add(Me.PanelInferior)
        Me.Controls.Add(Me.PanelMedio)
        Me.Controls.Add(Me.PanelSuperior)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(639, 628)
        Me.MinimumSize = New System.Drawing.Size(639, 628)
        Me.Name = "Bitacora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bitácora - MercaderSG"
        Me.ExportarCMS.ResumeLayout(False)
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelSuperior.PerformLayout()
        Me.PanelInferior.ResumeLayout(False)
        Me.RegistrosGB.ResumeLayout(False)
        CType(Me.BitacoraDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelStatus.ResumeLayout(False)
        Me.PanelStatus.PerformLayout()
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ExportarCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportarAXLSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents PanelInferior As System.Windows.Forms.Panel
    Friend WithEvents PanelMedio As System.Windows.Forms.Panel
    Friend WithEvents PanelSuperior As System.Windows.Forms.Panel
    Friend WithEvents PanelStatus As System.Windows.Forms.Panel
    Friend WithEvents FiltroLbl As System.Windows.Forms.Label
    Friend WithEvents FiltroCMB As System.Windows.Forms.ComboBox
    Friend WithEvents RegistrosGB As System.Windows.Forms.GroupBox
    Friend WithEvents BitacoraDG As System.Windows.Forms.DataGridView
    Friend WithEvents RecargarBtn As System.Windows.Forms.Button
    Friend WithEvents SiguienteBtn As System.Windows.Forms.Button
    Friend WithEvents AnteriorBtn As System.Windows.Forms.Button
    Friend WithEvents UltimoBtn As System.Windows.Forms.Button
    Friend WithEvents PrimeroBtn As System.Windows.Forms.Button
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents Parte1Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents InfoPagLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Parte2Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DepurarBtn As System.Windows.Forms.Button
    Friend WithEvents CodBitCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CriticidadCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
