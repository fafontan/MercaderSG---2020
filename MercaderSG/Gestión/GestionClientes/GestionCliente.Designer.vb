<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionCliente
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
        Me.BusquedaTxt = New System.Windows.Forms.TextBox()
        Me.IgualLbl = New System.Windows.Forms.Label()
        Me.BuscarCmb = New System.Windows.Forms.ComboBox()
        Me.BuscarPorLbl = New System.Windows.Forms.Label()
        Me.ClienteDG = New System.Windows.Forms.DataGridView()
        Me.CodCliCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazonSocialCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuitCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DireccionCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocalidadCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportarCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportarAXLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.GestionClientesGB = New System.Windows.Forms.GroupBox()
        Me.OperacionGB = New System.Windows.Forms.GroupBox()
        Me.AgregarBtn = New System.Windows.Forms.Button()
        Me.EliminarTelBtn = New System.Windows.Forms.Button()
        Me.ModificarBtn = New System.Windows.Forms.Button()
        Me.EliminarBtn = New System.Windows.Forms.Button()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.RegistrosGB = New System.Windows.Forms.GroupBox()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.Parte1Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.InfoPagLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Parte2Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RecargarBtn = New System.Windows.Forms.Button()
        Me.SiguienteBtn = New System.Windows.Forms.Button()
        Me.AnteriorBtn = New System.Windows.Forms.Button()
        Me.UltimoBtn = New System.Windows.Forms.Button()
        Me.PrimeroBtn = New System.Windows.Forms.Button()
        CType(Me.ClienteDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExportarCMS.SuspendLayout()
        Me.GestionClientesGB.SuspendLayout()
        Me.OperacionGB.SuspendLayout()
        Me.RegistrosGB.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.SuspendLayout()
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
        'ClienteDG
        '
        Me.ClienteDG.AllowUserToAddRows = False
        Me.ClienteDG.AllowUserToDeleteRows = False
        Me.ClienteDG.AllowUserToResizeColumns = False
        Me.ClienteDG.AllowUserToResizeRows = False
        Me.ClienteDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ClienteDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodCliCAB, Me.RazonSocialCAB, Me.CuitCAB, Me.DireccionCAB, Me.LocalidadCAB})
        Me.ClienteDG.ContextMenuStrip = Me.ExportarCMS
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ClienteDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.ClienteDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClienteDG.Location = New System.Drawing.Point(3, 19)
        Me.ClienteDG.MultiSelect = False
        Me.ClienteDG.Name = "ClienteDG"
        Me.ClienteDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ClienteDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.ClienteDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ClienteDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ClienteDG.Size = New System.Drawing.Size(570, 348)
        Me.ClienteDG.StandardTab = True
        Me.ClienteDG.TabIndex = 10
        '
        'CodCliCAB
        '
        Me.CodCliCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CodCliCAB.DataPropertyName = "CodCli"
        Me.CodCliCAB.HeaderText = "Código"
        Me.CodCliCAB.Name = "CodCliCAB"
        Me.CodCliCAB.ReadOnly = True
        Me.CodCliCAB.Visible = False
        Me.CodCliCAB.Width = 87
        '
        'RazonSocialCAB
        '
        Me.RazonSocialCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.RazonSocialCAB.DataPropertyName = "RazonSocial"
        Me.RazonSocialCAB.HeaderText = "Razon Social"
        Me.RazonSocialCAB.Name = "RazonSocialCAB"
        Me.RazonSocialCAB.ReadOnly = True
        Me.RazonSocialCAB.Width = 125
        '
        'CuitCAB
        '
        Me.CuitCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CuitCAB.DataPropertyName = "Cuit"
        Me.CuitCAB.HeaderText = "CUIT"
        Me.CuitCAB.Name = "CuitCAB"
        Me.CuitCAB.ReadOnly = True
        Me.CuitCAB.Width = 130
        '
        'DireccionCAB
        '
        Me.DireccionCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DireccionCAB.DataPropertyName = "Direccion"
        Me.DireccionCAB.HeaderText = "Dirección"
        Me.DireccionCAB.Name = "DireccionCAB"
        Me.DireccionCAB.ReadOnly = True
        Me.DireccionCAB.Width = 137
        '
        'LocalidadCAB
        '
        Me.LocalidadCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.LocalidadCAB.DataPropertyName = "Localidad"
        Me.LocalidadCAB.HeaderText = "Localidad"
        Me.LocalidadCAB.Name = "LocalidadCAB"
        Me.LocalidadCAB.ReadOnly = True
        Me.LocalidadCAB.Width = 117
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
        Me.ExportarAXLSToolStripMenuItem.Name = "Exportar"
        Me.ExportarAXLSToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ExportarAXLSToolStripMenuItem.Text = "Exportar"
        '
        'BGW
        '
        '
        'GestionClientesGB
        '
        Me.GestionClientesGB.Controls.Add(Me.OperacionGB)
        Me.GestionClientesGB.Controls.Add(Me.BuscarCmb)
        Me.GestionClientesGB.Controls.Add(Me.BuscarPorLbl)
        Me.GestionClientesGB.Controls.Add(Me.BusquedaTxt)
        Me.GestionClientesGB.Controls.Add(Me.IgualLbl)
        Me.GestionClientesGB.Controls.Add(Me.BuscarBtn)
        Me.GestionClientesGB.Location = New System.Drawing.Point(12, 12)
        Me.GestionClientesGB.Name = "GestionClientesGB"
        Me.GestionClientesGB.Size = New System.Drawing.Size(576, 141)
        Me.GestionClientesGB.TabIndex = 0
        Me.GestionClientesGB.TabStop = False
        Me.GestionClientesGB.Text = "Gestion de Clientes"
        '
        'OperacionGB
        '
        Me.OperacionGB.Controls.Add(Me.AgregarBtn)
        Me.OperacionGB.Controls.Add(Me.EliminarTelBtn)
        Me.OperacionGB.Controls.Add(Me.ModificarBtn)
        Me.OperacionGB.Controls.Add(Me.EliminarBtn)
        Me.OperacionGB.Location = New System.Drawing.Point(13, 66)
        Me.OperacionGB.Name = "OperacionGB"
        Me.OperacionGB.Size = New System.Drawing.Size(553, 61)
        Me.OperacionGB.TabIndex = 4
        Me.OperacionGB.TabStop = False
        Me.OperacionGB.Text = "Operaciones"
        '
        'AgregarBtn
        '
        Me.AgregarBtn.Image = Global.MercaderSG.My.Resources.Resources.add
        Me.AgregarBtn.Location = New System.Drawing.Point(13, 22)
        Me.AgregarBtn.Name = "AgregarBtn"
        Me.AgregarBtn.Size = New System.Drawing.Size(110, 24)
        Me.AgregarBtn.TabIndex = 5
        Me.AgregarBtn.Text = "Nuevo Cliente"
        Me.AgregarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AgregarBtn.UseVisualStyleBackColor = True
        '
        'EliminarTelBtn
        '
        Me.EliminarTelBtn.Image = Global.MercaderSG.My.Resources.Resources.phone_delete
        Me.EliminarTelBtn.Location = New System.Drawing.Point(394, 22)
        Me.EliminarTelBtn.Name = "EliminarTelBtn"
        Me.EliminarTelBtn.Size = New System.Drawing.Size(145, 24)
        Me.EliminarTelBtn.TabIndex = 8
        Me.EliminarTelBtn.Text = "Eliminar Telefono/s"
        Me.EliminarTelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EliminarTelBtn.UseVisualStyleBackColor = True
        '
        'ModificarBtn
        '
        Me.ModificarBtn.Image = Global.MercaderSG.My.Resources.Resources.pencil
        Me.ModificarBtn.Location = New System.Drawing.Point(129, 22)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(131, 24)
        Me.ModificarBtn.TabIndex = 6
        Me.ModificarBtn.Text = "Modificar Cliente"
        Me.ModificarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ModificarBtn.UseVisualStyleBackColor = True
        '
        'EliminarBtn
        '
        Me.EliminarBtn.Image = Global.MercaderSG.My.Resources.Resources.delete
        Me.EliminarBtn.Location = New System.Drawing.Point(266, 22)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(122, 24)
        Me.EliminarBtn.TabIndex = 7
        Me.EliminarBtn.Text = "Eliminar Cliente"
        Me.EliminarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EliminarBtn.UseVisualStyleBackColor = True
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
        'RegistrosGB
        '
        Me.RegistrosGB.Controls.Add(Me.ClienteDG)
        Me.RegistrosGB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RegistrosGB.Location = New System.Drawing.Point(12, 159)
        Me.RegistrosGB.Name = "RegistrosGB"
        Me.RegistrosGB.Size = New System.Drawing.Size(576, 370)
        Me.RegistrosGB.TabIndex = 9
        Me.RegistrosGB.TabStop = False
        Me.RegistrosGB.Text = "Registros"
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
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Parte1Lbl, Me.InfoPagLbl, Me.Parte2Lbl})
        Me.SS.Location = New System.Drawing.Point(0, 567)
        Me.SS.Name = "SS"
        Me.SS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SS.Size = New System.Drawing.Size(591, 22)
        Me.SS.TabIndex = 63
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
        Me.RecargarBtn.Location = New System.Drawing.Point(284, 540)
        Me.RecargarBtn.Margin = New System.Windows.Forms.Padding(15, 11, 15, 11)
        Me.RecargarBtn.Name = "RecargarBtn"
        Me.RecargarBtn.Size = New System.Drawing.Size(32, 24)
        Me.RecargarBtn.TabIndex = 11
        Me.RecargarBtn.UseVisualStyleBackColor = True
        '
        'SiguienteBtn
        '
        Me.SiguienteBtn.Image = Global.MercaderSG.My.Resources.Resources.SiguienteE
        Me.SiguienteBtn.Location = New System.Drawing.Point(334, 540)
        Me.SiguienteBtn.Margin = New System.Windows.Forms.Padding(3, 11, 3, 11)
        Me.SiguienteBtn.Name = "SiguienteBtn"
        Me.SiguienteBtn.Size = New System.Drawing.Size(32, 24)
        Me.SiguienteBtn.TabIndex = 14
        Me.SiguienteBtn.UseVisualStyleBackColor = True
        '
        'AnteriorBtn
        '
        Me.AnteriorBtn.Image = Global.MercaderSG.My.Resources.Resources.AnteriorE
        Me.AnteriorBtn.Location = New System.Drawing.Point(234, 540)
        Me.AnteriorBtn.Margin = New System.Windows.Forms.Padding(3, 11, 3, 11)
        Me.AnteriorBtn.Name = "AnteriorBtn"
        Me.AnteriorBtn.Size = New System.Drawing.Size(32, 24)
        Me.AnteriorBtn.TabIndex = 13
        Me.AnteriorBtn.UseVisualStyleBackColor = True
        '
        'UltimoBtn
        '
        Me.UltimoBtn.Image = Global.MercaderSG.My.Resources.Resources.UltimoE
        Me.UltimoBtn.Location = New System.Drawing.Point(372, 540)
        Me.UltimoBtn.Margin = New System.Windows.Forms.Padding(3, 11, 3, 11)
        Me.UltimoBtn.Name = "UltimoBtn"
        Me.UltimoBtn.Size = New System.Drawing.Size(32, 24)
        Me.UltimoBtn.TabIndex = 15
        Me.UltimoBtn.UseVisualStyleBackColor = True
        '
        'PrimeroBtn
        '
        Me.PrimeroBtn.Image = Global.MercaderSG.My.Resources.Resources.PrimeroE
        Me.PrimeroBtn.Location = New System.Drawing.Point(196, 540)
        Me.PrimeroBtn.Margin = New System.Windows.Forms.Padding(3, 11, 3, 11)
        Me.PrimeroBtn.Name = "PrimeroBtn"
        Me.PrimeroBtn.Size = New System.Drawing.Size(32, 24)
        Me.PrimeroBtn.TabIndex = 12
        Me.PrimeroBtn.UseVisualStyleBackColor = True
        '
        'GestionCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(591, 589)
        Me.Controls.Add(Me.SS)
        Me.Controls.Add(Me.RecargarBtn)
        Me.Controls.Add(Me.RegistrosGB)
        Me.Controls.Add(Me.SiguienteBtn)
        Me.Controls.Add(Me.GestionClientesGB)
        Me.Controls.Add(Me.AnteriorBtn)
        Me.Controls.Add(Me.UltimoBtn)
        Me.Controls.Add(Me.PrimeroBtn)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(607, 628)
        Me.MinimumSize = New System.Drawing.Size(607, 628)
        Me.Name = "GestionCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestión de Clientes - MercaderSG"
        CType(Me.ClienteDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExportarCMS.ResumeLayout(False)
        Me.GestionClientesGB.ResumeLayout(False)
        Me.GestionClientesGB.PerformLayout()
        Me.OperacionGB.ResumeLayout(False)
        Me.RegistrosGB.ResumeLayout(False)
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AgregarBtn As System.Windows.Forms.Button
    Friend WithEvents ModificarBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarBtn As System.Windows.Forms.Button
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarTelBtn As System.Windows.Forms.Button
    Friend WithEvents BusquedaTxt As System.Windows.Forms.TextBox
    Friend WithEvents IgualLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarCmb As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarPorLbl As System.Windows.Forms.Label
    Friend WithEvents ClienteDG As System.Windows.Forms.DataGridView
    Friend WithEvents SiguienteBtn As System.Windows.Forms.Button
    Friend WithEvents AnteriorBtn As System.Windows.Forms.Button
    Friend WithEvents PrimeroBtn As System.Windows.Forms.Button
    Friend WithEvents UltimoBtn As System.Windows.Forms.Button
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents GestionClientesGB As System.Windows.Forms.GroupBox
    Friend WithEvents OperacionGB As System.Windows.Forms.GroupBox
    Friend WithEvents RegistrosGB As System.Windows.Forms.GroupBox
    Friend WithEvents ExportarCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportarAXLSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents RecargarBtn As System.Windows.Forms.Button
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents Parte1Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents InfoPagLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Parte2Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CodCliCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RazonSocialCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuitCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DireccionCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocalidadCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
