<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionProducto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.ExportarCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportarAXLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrosGB = New System.Windows.Forms.GroupBox()
        Me.ProductosDG = New System.Windows.Forms.DataGridView()
        Me.GestionProductosGB = New System.Windows.Forms.GroupBox()
        Me.OperacionGB = New System.Windows.Forms.GroupBox()
        Me.MasBtn = New System.Windows.Forms.Button()
        Me.OpcionesCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarStockBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarPrecioBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarBtn = New System.Windows.Forms.Button()
        Me.ModificarBtn = New System.Windows.Forms.Button()
        Me.EliminarBtn = New System.Windows.Forms.Button()
        Me.BuscarCmb = New System.Windows.Forms.ComboBox()
        Me.BuscarPorLbl = New System.Windows.Forms.Label()
        Me.BusquedaTxt = New System.Windows.Forms.TextBox()
        Me.IgualLbl = New System.Windows.Forms.Label()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.Parte1Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.InfoPagLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Parte2Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RecargarBtn = New System.Windows.Forms.Button()
        Me.SiguienteBtn = New System.Windows.Forms.Button()
        Me.AnteriorBtn = New System.Windows.Forms.Button()
        Me.UltimoBtn = New System.Windows.Forms.Button()
        Me.PrimeroBtn = New System.Windows.Forms.Button()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.CodProdCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitarioCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SectorCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportarCMS.SuspendLayout()
        Me.RegistrosGB.SuspendLayout()
        CType(Me.ProductosDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GestionProductosGB.SuspendLayout()
        Me.OperacionGB.SuspendLayout()
        Me.OpcionesCMS.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.SuspendLayout()
        '
        'BGW
        '
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
        'RegistrosGB
        '
        Me.RegistrosGB.Controls.Add(Me.ProductosDG)
        Me.RegistrosGB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RegistrosGB.Location = New System.Drawing.Point(12, 159)
        Me.RegistrosGB.Name = "RegistrosGB"
        Me.RegistrosGB.Size = New System.Drawing.Size(576, 376)
        Me.RegistrosGB.TabIndex = 9
        Me.RegistrosGB.TabStop = False
        Me.RegistrosGB.Text = "Registros"
        '
        'ProductosDG
        '
        Me.ProductosDG.AllowUserToAddRows = False
        Me.ProductosDG.AllowUserToDeleteRows = False
        Me.ProductosDG.AllowUserToResizeColumns = False
        Me.ProductosDG.AllowUserToResizeRows = False
        Me.ProductosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductosDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodProdCAB, Me.NombreCAB, Me.PrecioUnitarioCAB, Me.CantidadCAB, Me.SectorCAB})
        Me.ProductosDG.ContextMenuStrip = Me.ExportarCMS
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductosDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProductosDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProductosDG.Location = New System.Drawing.Point(3, 19)
        Me.ProductosDG.MultiSelect = False
        Me.ProductosDG.Name = "ProductosDG"
        Me.ProductosDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProductosDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.ProductosDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosDG.Size = New System.Drawing.Size(570, 354)
        Me.ProductosDG.StandardTab = True
        Me.ProductosDG.TabIndex = 10
        '
        'GestionProductosGB
        '
        Me.GestionProductosGB.Controls.Add(Me.OperacionGB)
        Me.GestionProductosGB.Controls.Add(Me.BuscarCmb)
        Me.GestionProductosGB.Controls.Add(Me.BuscarPorLbl)
        Me.GestionProductosGB.Controls.Add(Me.BusquedaTxt)
        Me.GestionProductosGB.Controls.Add(Me.IgualLbl)
        Me.GestionProductosGB.Controls.Add(Me.BuscarBtn)
        Me.GestionProductosGB.Location = New System.Drawing.Point(12, 12)
        Me.GestionProductosGB.Name = "GestionProductosGB"
        Me.GestionProductosGB.Size = New System.Drawing.Size(576, 141)
        Me.GestionProductosGB.TabIndex = 0
        Me.GestionProductosGB.TabStop = False
        Me.GestionProductosGB.Text = "Gestion de Productos"
        '
        'OperacionGB
        '
        Me.OperacionGB.Controls.Add(Me.MasBtn)
        Me.OperacionGB.Controls.Add(Me.AgregarBtn)
        Me.OperacionGB.Controls.Add(Me.ModificarBtn)
        Me.OperacionGB.Controls.Add(Me.EliminarBtn)
        Me.OperacionGB.Location = New System.Drawing.Point(12, 68)
        Me.OperacionGB.Name = "OperacionGB"
        Me.OperacionGB.Size = New System.Drawing.Size(553, 65)
        Me.OperacionGB.TabIndex = 4
        Me.OperacionGB.TabStop = False
        Me.OperacionGB.Text = "Operaciones"
        '
        'MasBtn
        '
        Me.MasBtn.ContextMenuStrip = Me.OpcionesCMS
        Me.MasBtn.Image = Global.MercaderSG.My.Resources.Resources.MasOpcionesE
        Me.MasBtn.Location = New System.Drawing.Point(420, 25)
        Me.MasBtn.Name = "MasBtn"
        Me.MasBtn.Size = New System.Drawing.Size(125, 24)
        Me.MasBtn.TabIndex = 8
        Me.MasBtn.Text = "Más Opciones"
        Me.MasBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.MasBtn.UseVisualStyleBackColor = True
        '
        'OpcionesCMS
        '
        Me.OpcionesCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarStockBtn, Me.ModificarPrecioBtn})
        Me.OpcionesCMS.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.OpcionesCMS.Name = "OpcionesCMS"
        Me.OpcionesCMS.Size = New System.Drawing.Size(162, 48)
        '
        'ModificarStockBtn
        '
        Me.ModificarStockBtn.Image = Global.MercaderSG.My.Resources.Resources.StockE
        Me.ModificarStockBtn.Name = "ModificarStockBtn"
        Me.ModificarStockBtn.Size = New System.Drawing.Size(161, 22)
        Me.ModificarStockBtn.Text = "Modificar Stock"
        '
        'ModificarPrecioBtn
        '
        Me.ModificarPrecioBtn.Image = Global.MercaderSG.My.Resources.Resources.PrecioE
        Me.ModificarPrecioBtn.Name = "ModificarPrecioBtn"
        Me.ModificarPrecioBtn.Size = New System.Drawing.Size(161, 22)
        Me.ModificarPrecioBtn.Text = "Modificar Precio"
        '
        'AgregarBtn
        '
        Me.AgregarBtn.Image = Global.MercaderSG.My.Resources.Resources.add
        Me.AgregarBtn.Location = New System.Drawing.Point(8, 25)
        Me.AgregarBtn.Name = "AgregarBtn"
        Me.AgregarBtn.Size = New System.Drawing.Size(119, 24)
        Me.AgregarBtn.TabIndex = 5
        Me.AgregarBtn.Text = "Nuevo Producto"
        Me.AgregarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AgregarBtn.UseVisualStyleBackColor = True
        '
        'ModificarBtn
        '
        Me.ModificarBtn.Image = Global.MercaderSG.My.Resources.Resources.pencil
        Me.ModificarBtn.Location = New System.Drawing.Point(130, 25)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(144, 24)
        Me.ModificarBtn.TabIndex = 6
        Me.ModificarBtn.Text = "Modificar Producto"
        Me.ModificarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ModificarBtn.UseVisualStyleBackColor = True
        '
        'EliminarBtn
        '
        Me.EliminarBtn.Image = Global.MercaderSG.My.Resources.Resources.delete
        Me.EliminarBtn.Location = New System.Drawing.Point(277, 25)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(137, 24)
        Me.EliminarBtn.TabIndex = 7
        Me.EliminarBtn.Text = "Eliminar Producto"
        Me.EliminarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EliminarBtn.UseVisualStyleBackColor = True
        '
        'BuscarCmb
        '
        Me.BuscarCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BuscarCmb.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarCmb.FormattingEnabled = True
        Me.BuscarCmb.Location = New System.Drawing.Point(111, 31)
        Me.BuscarCmb.Name = "BuscarCmb"
        Me.BuscarCmb.Size = New System.Drawing.Size(121, 23)
        Me.BuscarCmb.TabIndex = 1
        '
        'BuscarPorLbl
        '
        Me.BuscarPorLbl.AutoSize = True
        Me.BuscarPorLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarPorLbl.Location = New System.Drawing.Point(26, 34)
        Me.BuscarPorLbl.Name = "BuscarPorLbl"
        Me.BuscarPorLbl.Size = New System.Drawing.Size(67, 15)
        Me.BuscarPorLbl.TabIndex = 41
        Me.BuscarPorLbl.Text = "Buscar por"
        '
        'BusquedaTxt
        '
        Me.BusquedaTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BusquedaTxt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BusquedaTxt.Location = New System.Drawing.Point(313, 31)
        Me.BusquedaTxt.Name = "BusquedaTxt"
        Me.BusquedaTxt.Size = New System.Drawing.Size(122, 23)
        Me.BusquedaTxt.TabIndex = 2
        '
        'IgualLbl
        '
        Me.IgualLbl.AutoSize = True
        Me.IgualLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgualLbl.Location = New System.Drawing.Point(250, 34)
        Me.IgualLbl.Name = "IgualLbl"
        Me.IgualLbl.Size = New System.Drawing.Size(45, 15)
        Me.IgualLbl.TabIndex = 43
        Me.IgualLbl.Text = "igual a"
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarBtn.Location = New System.Drawing.Point(462, 27)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(88, 30)
        Me.BuscarBtn.TabIndex = 3
        Me.BuscarBtn.Text = "&Buscar"
        Me.BuscarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarBtn.UseVisualStyleBackColor = True
        '
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Parte1Lbl, Me.InfoPagLbl, Me.Parte2Lbl})
        Me.SS.Location = New System.Drawing.Point(0, 577)
        Me.SS.Name = "SS"
        Me.SS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SS.Size = New System.Drawing.Size(601, 22)
        Me.SS.TabIndex = 62
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
        'RecargarBtn
        '
        Me.RecargarBtn.Image = Global.MercaderSG.My.Resources.Resources.RecargarE
        Me.RecargarBtn.Location = New System.Drawing.Point(284, 543)
        Me.RecargarBtn.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
        Me.RecargarBtn.Name = "RecargarBtn"
        Me.RecargarBtn.Size = New System.Drawing.Size(32, 24)
        Me.RecargarBtn.TabIndex = 11
        Me.RecargarBtn.UseVisualStyleBackColor = True
        '
        'SiguienteBtn
        '
        Me.SiguienteBtn.Image = Global.MercaderSG.My.Resources.Resources.SiguienteE
        Me.SiguienteBtn.Location = New System.Drawing.Point(334, 543)
        Me.SiguienteBtn.Name = "SiguienteBtn"
        Me.SiguienteBtn.Size = New System.Drawing.Size(32, 24)
        Me.SiguienteBtn.TabIndex = 14
        Me.SiguienteBtn.UseVisualStyleBackColor = True
        '
        'AnteriorBtn
        '
        Me.AnteriorBtn.Image = Global.MercaderSG.My.Resources.Resources.AnteriorE
        Me.AnteriorBtn.Location = New System.Drawing.Point(234, 543)
        Me.AnteriorBtn.Name = "AnteriorBtn"
        Me.AnteriorBtn.Size = New System.Drawing.Size(32, 24)
        Me.AnteriorBtn.TabIndex = 13
        Me.AnteriorBtn.UseVisualStyleBackColor = True
        '
        'UltimoBtn
        '
        Me.UltimoBtn.Image = Global.MercaderSG.My.Resources.Resources.UltimoE
        Me.UltimoBtn.Location = New System.Drawing.Point(372, 543)
        Me.UltimoBtn.Name = "UltimoBtn"
        Me.UltimoBtn.Size = New System.Drawing.Size(32, 24)
        Me.UltimoBtn.TabIndex = 15
        Me.UltimoBtn.UseVisualStyleBackColor = True
        '
        'PrimeroBtn
        '
        Me.PrimeroBtn.Image = Global.MercaderSG.My.Resources.Resources.PrimeroE
        Me.PrimeroBtn.Location = New System.Drawing.Point(196, 543)
        Me.PrimeroBtn.Name = "PrimeroBtn"
        Me.PrimeroBtn.Size = New System.Drawing.Size(32, 24)
        Me.PrimeroBtn.TabIndex = 12
        Me.PrimeroBtn.UseVisualStyleBackColor = True
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
        'MensajeTT
        '
        Me.MensajeTT.AutomaticDelay = 100
        Me.MensajeTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.MensajeTT.ToolTipTitle = "MercaderSG"
        '
        'CodProdCAB
        '
        Me.CodProdCAB.DataPropertyName = "CodProd"
        Me.CodProdCAB.HeaderText = "Código"
        Me.CodProdCAB.Name = "CodProdCAB"
        Me.CodProdCAB.ReadOnly = True
        Me.CodProdCAB.Visible = False
        Me.CodProdCAB.Width = 75
        '
        'NombreCAB
        '
        Me.NombreCAB.DataPropertyName = "Nombre"
        Me.NombreCAB.HeaderText = "Nombre"
        Me.NombreCAB.Name = "NombreCAB"
        Me.NombreCAB.ReadOnly = True
        Me.NombreCAB.Width = 143
        '
        'PrecioUnitarioCAB
        '
        Me.PrecioUnitarioCAB.DataPropertyName = "Precio"
        Me.PrecioUnitarioCAB.HeaderText = "Precio"
        Me.PrecioUnitarioCAB.Name = "PrecioUnitarioCAB"
        Me.PrecioUnitarioCAB.ReadOnly = True
        Me.PrecioUnitarioCAB.Width = 109
        '
        'CantidadCAB
        '
        Me.CantidadCAB.DataPropertyName = "Cantidad"
        Me.CantidadCAB.HeaderText = "Cantidad"
        Me.CantidadCAB.Name = "CantidadCAB"
        Me.CantidadCAB.ReadOnly = True
        Me.CantidadCAB.Width = 109
        '
        'SectorCAB
        '
        Me.SectorCAB.DataPropertyName = "Sector"
        Me.SectorCAB.HeaderText = "Sector"
        Me.SectorCAB.Name = "SectorCAB"
        Me.SectorCAB.ReadOnly = True
        Me.SectorCAB.Width = 146
        '
        'GestionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(601, 599)
        Me.Controls.Add(Me.RecargarBtn)
        Me.Controls.Add(Me.RegistrosGB)
        Me.Controls.Add(Me.GestionProductosGB)
        Me.Controls.Add(Me.SiguienteBtn)
        Me.Controls.Add(Me.AnteriorBtn)
        Me.Controls.Add(Me.SS)
        Me.Controls.Add(Me.UltimoBtn)
        Me.Controls.Add(Me.PrimeroBtn)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(607, 628)
        Me.MinimumSize = New System.Drawing.Size(607, 628)
        Me.Name = "GestionProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión de Productos - MercaderSG"
        Me.ExportarCMS.ResumeLayout(False)
        Me.RegistrosGB.ResumeLayout(False)
        CType(Me.ProductosDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GestionProductosGB.ResumeLayout(False)
        Me.GestionProductosGB.PerformLayout()
        Me.OperacionGB.ResumeLayout(False)
        Me.OpcionesCMS.ResumeLayout(False)
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ExportarCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportarAXLSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarBtn As System.Windows.Forms.Button
    Friend WithEvents RegistrosGB As System.Windows.Forms.GroupBox
    Friend WithEvents ProductosDG As System.Windows.Forms.DataGridView
    Friend WithEvents GestionProductosGB As System.Windows.Forms.GroupBox
    Friend WithEvents OperacionGB As System.Windows.Forms.GroupBox
    Friend WithEvents AgregarBtn As System.Windows.Forms.Button
    Friend WithEvents ModificarBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarBtn As System.Windows.Forms.Button
    Friend WithEvents BuscarCmb As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarPorLbl As System.Windows.Forms.Label
    Friend WithEvents BusquedaTxt As System.Windows.Forms.TextBox
    Friend WithEvents IgualLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents SiguienteBtn As System.Windows.Forms.Button
    Friend WithEvents AnteriorBtn As System.Windows.Forms.Button
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents Parte1Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents InfoPagLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Parte2Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UltimoBtn As System.Windows.Forms.Button
    Friend WithEvents PrimeroBtn As System.Windows.Forms.Button
    Friend WithEvents MasBtn As System.Windows.Forms.Button
    Friend WithEvents OpcionesCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificarStockBtn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarPrecioBtn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents CodProdCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitarioCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectorCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
