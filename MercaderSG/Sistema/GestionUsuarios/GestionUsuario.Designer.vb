<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionUsuario
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
        Me.UsuarioDG = New System.Windows.Forms.DataGridView()
        Me.ExportarCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportarAXLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.Parte1Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.InfoPagLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Parte2Lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RegistrosGB = New System.Windows.Forms.GroupBox()
        Me.GestionUsuariosGB = New System.Windows.Forms.GroupBox()
        Me.OperacionGB = New System.Windows.Forms.GroupBox()
        Me.AgregarBtn = New System.Windows.Forms.Button()
        Me.EliminarTelBtn = New System.Windows.Forms.Button()
        Me.ModificarBtn = New System.Windows.Forms.Button()
        Me.EliminarBtn = New System.Windows.Forms.Button()
        Me.BuscarCmb = New System.Windows.Forms.ComboBox()
        Me.BuscarPorLbl = New System.Windows.Forms.Label()
        Me.BusquedaTxt = New System.Windows.Forms.TextBox()
        Me.IgualLbl = New System.Windows.Forms.Label()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.RecargarBtn = New System.Windows.Forms.Button()
        Me.SiguienteBtn = New System.Windows.Forms.Button()
        Me.AnteriorBtn = New System.Windows.Forms.Button()
        Me.UltimoBtn = New System.Windows.Forms.Button()
        Me.PrimeroBtn = New System.Windows.Forms.Button()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.CodUsuCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApellidoCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorreoCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EdadCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.UsuarioDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExportarCMS.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.RegistrosGB.SuspendLayout()
        Me.GestionUsuariosGB.SuspendLayout()
        Me.OperacionGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'UsuarioDG
        '
        Me.UsuarioDG.AllowUserToAddRows = False
        Me.UsuarioDG.AllowUserToDeleteRows = False
        Me.UsuarioDG.AllowUserToResizeColumns = False
        Me.UsuarioDG.AllowUserToResizeRows = False
        Me.UsuarioDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UsuarioDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodUsuCAB, Me.UsuarioCAB, Me.ApellidoCAB, Me.NombreCAB, Me.CorreoCAB, Me.EdadCAB})
        Me.UsuarioDG.ContextMenuStrip = Me.ExportarCMS
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UsuarioDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.UsuarioDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UsuarioDG.Location = New System.Drawing.Point(3, 19)
        Me.UsuarioDG.MultiSelect = False
        Me.UsuarioDG.Name = "UsuarioDG"
        Me.UsuarioDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UsuarioDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.UsuarioDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.UsuarioDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UsuarioDG.Size = New System.Drawing.Size(582, 353)
        Me.UsuarioDG.StandardTab = True
        Me.UsuarioDG.TabIndex = 7
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
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Parte1Lbl, Me.InfoPagLbl, Me.Parte2Lbl})
        Me.SS.Location = New System.Drawing.Point(0, 577)
        Me.SS.Name = "SS"
        Me.SS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SS.Size = New System.Drawing.Size(612, 22)
        Me.SS.TabIndex = 57
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
        'RegistrosGB
        '
        Me.RegistrosGB.Controls.Add(Me.UsuarioDG)
        Me.RegistrosGB.Location = New System.Drawing.Point(12, 162)
        Me.RegistrosGB.Name = "RegistrosGB"
        Me.RegistrosGB.Size = New System.Drawing.Size(588, 375)
        Me.RegistrosGB.TabIndex = 59
        Me.RegistrosGB.TabStop = False
        Me.RegistrosGB.Text = "Registros"
        '
        'GestionUsuariosGB
        '
        Me.GestionUsuariosGB.Controls.Add(Me.OperacionGB)
        Me.GestionUsuariosGB.Controls.Add(Me.BuscarCmb)
        Me.GestionUsuariosGB.Controls.Add(Me.BuscarPorLbl)
        Me.GestionUsuariosGB.Controls.Add(Me.BusquedaTxt)
        Me.GestionUsuariosGB.Controls.Add(Me.IgualLbl)
        Me.GestionUsuariosGB.Controls.Add(Me.BuscarBtn)
        Me.GestionUsuariosGB.Location = New System.Drawing.Point(12, 12)
        Me.GestionUsuariosGB.Name = "GestionUsuariosGB"
        Me.GestionUsuariosGB.Size = New System.Drawing.Size(588, 141)
        Me.GestionUsuariosGB.TabIndex = 56
        Me.GestionUsuariosGB.TabStop = False
        Me.GestionUsuariosGB.Text = "Gestion de Usuarios"
        '
        'OperacionGB
        '
        Me.OperacionGB.Controls.Add(Me.AgregarBtn)
        Me.OperacionGB.Controls.Add(Me.EliminarTelBtn)
        Me.OperacionGB.Controls.Add(Me.ModificarBtn)
        Me.OperacionGB.Controls.Add(Me.EliminarBtn)
        Me.OperacionGB.Location = New System.Drawing.Point(11, 66)
        Me.OperacionGB.Name = "OperacionGB"
        Me.OperacionGB.Size = New System.Drawing.Size(571, 61)
        Me.OperacionGB.TabIndex = 56
        Me.OperacionGB.TabStop = False
        Me.OperacionGB.Text = "Operaciones"
        '
        'AgregarBtn
        '
        Me.AgregarBtn.Image = Global.MercaderSG.My.Resources.Resources.add
        Me.AgregarBtn.Location = New System.Drawing.Point(7, 22)
        Me.AgregarBtn.Name = "AgregarBtn"
        Me.AgregarBtn.Size = New System.Drawing.Size(119, 24)
        Me.AgregarBtn.TabIndex = 3
        Me.AgregarBtn.Text = "Nuevo Usuario"
        Me.AgregarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AgregarBtn.UseVisualStyleBackColor = True
        '
        'EliminarTelBtn
        '
        Me.EliminarTelBtn.Image = Global.MercaderSG.My.Resources.Resources.phone_delete
        Me.EliminarTelBtn.Location = New System.Drawing.Point(418, 22)
        Me.EliminarTelBtn.Name = "EliminarTelBtn"
        Me.EliminarTelBtn.Size = New System.Drawing.Size(145, 24)
        Me.EliminarTelBtn.TabIndex = 6
        Me.EliminarTelBtn.Text = "Eliminar Telefono/s"
        Me.EliminarTelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EliminarTelBtn.UseVisualStyleBackColor = True
        '
        'ModificarBtn
        '
        Me.ModificarBtn.Image = Global.MercaderSG.My.Resources.Resources.pencil
        Me.ModificarBtn.Location = New System.Drawing.Point(132, 22)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(141, 24)
        Me.ModificarBtn.TabIndex = 4
        Me.ModificarBtn.Text = "Modificar Usuario"
        Me.ModificarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ModificarBtn.UseVisualStyleBackColor = True
        '
        'EliminarBtn
        '
        Me.EliminarBtn.Image = Global.MercaderSG.My.Resources.Resources.delete
        Me.EliminarBtn.Location = New System.Drawing.Point(279, 22)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(133, 24)
        Me.EliminarBtn.TabIndex = 5
        Me.EliminarBtn.Text = "Eliminar Usuario"
        Me.EliminarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EliminarBtn.UseVisualStyleBackColor = True
        '
        'BuscarCmb
        '
        Me.BuscarCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BuscarCmb.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarCmb.FormattingEnabled = True
        Me.BuscarCmb.Location = New System.Drawing.Point(117, 31)
        Me.BuscarCmb.Name = "BuscarCmb"
        Me.BuscarCmb.Size = New System.Drawing.Size(121, 23)
        Me.BuscarCmb.TabIndex = 0
        '
        'BuscarPorLbl
        '
        Me.BuscarPorLbl.AutoSize = True
        Me.BuscarPorLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarPorLbl.Location = New System.Drawing.Point(32, 34)
        Me.BuscarPorLbl.Name = "BuscarPorLbl"
        Me.BuscarPorLbl.Size = New System.Drawing.Size(67, 15)
        Me.BuscarPorLbl.TabIndex = 41
        Me.BuscarPorLbl.Text = "Buscar por"
        '
        'BusquedaTxt
        '
        Me.BusquedaTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BusquedaTxt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BusquedaTxt.Location = New System.Drawing.Point(319, 31)
        Me.BusquedaTxt.Name = "BusquedaTxt"
        Me.BusquedaTxt.Size = New System.Drawing.Size(122, 23)
        Me.BusquedaTxt.TabIndex = 1
        '
        'IgualLbl
        '
        Me.IgualLbl.AutoSize = True
        Me.IgualLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgualLbl.Location = New System.Drawing.Point(256, 34)
        Me.IgualLbl.Name = "IgualLbl"
        Me.IgualLbl.Size = New System.Drawing.Size(45, 15)
        Me.IgualLbl.TabIndex = 43
        Me.IgualLbl.Text = "igual a"
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarBtn.Location = New System.Drawing.Point(468, 27)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(88, 30)
        Me.BuscarBtn.TabIndex = 2
        Me.BuscarBtn.Text = "&Buscar"
        Me.BuscarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarBtn.UseVisualStyleBackColor = True
        '
        'BGW
        '
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
        'RecargarBtn
        '
        Me.RecargarBtn.Image = Global.MercaderSG.My.Resources.Resources.RecargarE
        Me.RecargarBtn.Location = New System.Drawing.Point(290, 543)
        Me.RecargarBtn.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
        Me.RecargarBtn.Name = "RecargarBtn"
        Me.RecargarBtn.Size = New System.Drawing.Size(32, 24)
        Me.RecargarBtn.TabIndex = 8
        Me.RecargarBtn.UseVisualStyleBackColor = True
        '
        'SiguienteBtn
        '
        Me.SiguienteBtn.Image = Global.MercaderSG.My.Resources.Resources.SiguienteE
        Me.SiguienteBtn.Location = New System.Drawing.Point(340, 543)
        Me.SiguienteBtn.Name = "SiguienteBtn"
        Me.SiguienteBtn.Size = New System.Drawing.Size(32, 24)
        Me.SiguienteBtn.TabIndex = 11
        Me.SiguienteBtn.UseVisualStyleBackColor = True
        '
        'AnteriorBtn
        '
        Me.AnteriorBtn.Image = Global.MercaderSG.My.Resources.Resources.AnteriorE
        Me.AnteriorBtn.Location = New System.Drawing.Point(240, 543)
        Me.AnteriorBtn.Name = "AnteriorBtn"
        Me.AnteriorBtn.Size = New System.Drawing.Size(32, 24)
        Me.AnteriorBtn.TabIndex = 10
        Me.AnteriorBtn.UseVisualStyleBackColor = True
        '
        'UltimoBtn
        '
        Me.UltimoBtn.Image = Global.MercaderSG.My.Resources.Resources.UltimoE
        Me.UltimoBtn.Location = New System.Drawing.Point(378, 543)
        Me.UltimoBtn.Name = "UltimoBtn"
        Me.UltimoBtn.Size = New System.Drawing.Size(32, 24)
        Me.UltimoBtn.TabIndex = 12
        Me.UltimoBtn.UseVisualStyleBackColor = True
        '
        'PrimeroBtn
        '
        Me.PrimeroBtn.Image = Global.MercaderSG.My.Resources.Resources.PrimeroE
        Me.PrimeroBtn.Location = New System.Drawing.Point(202, 543)
        Me.PrimeroBtn.Name = "PrimeroBtn"
        Me.PrimeroBtn.Size = New System.Drawing.Size(32, 24)
        Me.PrimeroBtn.TabIndex = 9
        Me.PrimeroBtn.UseVisualStyleBackColor = True
        '
        'MensajeTT
        '
        Me.MensajeTT.AutomaticDelay = 100
        Me.MensajeTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.MensajeTT.ToolTipTitle = "MercaderSG"
        '
        'CodUsuCAB
        '
        Me.CodUsuCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CodUsuCAB.DataPropertyName = "CodUsu"
        Me.CodUsuCAB.HeaderText = "Código"
        Me.CodUsuCAB.Name = "CodUsuCAB"
        Me.CodUsuCAB.ReadOnly = True
        Me.CodUsuCAB.Visible = False
        Me.CodUsuCAB.Width = 70
        '
        'UsuarioCAB
        '
        Me.UsuarioCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UsuarioCAB.DataPropertyName = "Usuario"
        Me.UsuarioCAB.HeaderText = "Usuario"
        Me.UsuarioCAB.Name = "UsuarioCAB"
        Me.UsuarioCAB.ReadOnly = True
        '
        'ApellidoCAB
        '
        Me.ApellidoCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ApellidoCAB.DataPropertyName = "Apellido"
        Me.ApellidoCAB.HeaderText = "Apellido"
        Me.ApellidoCAB.Name = "ApellidoCAB"
        Me.ApellidoCAB.ReadOnly = True
        '
        'NombreCAB
        '
        Me.NombreCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NombreCAB.DataPropertyName = "Nombre"
        Me.NombreCAB.HeaderText = "Nombre"
        Me.NombreCAB.Name = "NombreCAB"
        Me.NombreCAB.ReadOnly = True
        Me.NombreCAB.Width = 105
        '
        'CorreoCAB
        '
        Me.CorreoCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CorreoCAB.DataPropertyName = "CorreoElectronico"
        Me.CorreoCAB.HeaderText = "Correo Electronico"
        Me.CorreoCAB.Name = "CorreoCAB"
        Me.CorreoCAB.ReadOnly = True
        Me.CorreoCAB.Width = 148
        '
        'EdadCAB
        '
        Me.EdadCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.EdadCAB.DataPropertyName = "Edad"
        Me.EdadCAB.HeaderText = "Edad"
        Me.EdadCAB.Name = "EdadCAB"
        Me.EdadCAB.ReadOnly = True
        Me.EdadCAB.Width = 65
        '
        'GestionUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(612, 599)
        Me.Controls.Add(Me.RecargarBtn)
        Me.Controls.Add(Me.SiguienteBtn)
        Me.Controls.Add(Me.AnteriorBtn)
        Me.Controls.Add(Me.UltimoBtn)
        Me.Controls.Add(Me.PrimeroBtn)
        Me.Controls.Add(Me.GestionUsuariosGB)
        Me.Controls.Add(Me.RegistrosGB)
        Me.Controls.Add(Me.SS)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(618, 628)
        Me.MinimumSize = New System.Drawing.Size(618, 628)
        Me.Name = "GestionUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UsuarioDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExportarCMS.ResumeLayout(False)
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.RegistrosGB.ResumeLayout(False)
        Me.GestionUsuariosGB.ResumeLayout(False)
        Me.GestionUsuariosGB.PerformLayout()
        Me.OperacionGB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsuarioDG As System.Windows.Forms.DataGridView
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents Parte1Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents InfoPagLbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Parte2Lbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RegistrosGB As System.Windows.Forms.GroupBox
    Friend WithEvents GestionUsuariosGB As System.Windows.Forms.GroupBox
    Friend WithEvents OperacionGB As System.Windows.Forms.GroupBox
    Friend WithEvents AgregarBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarTelBtn As System.Windows.Forms.Button
    Friend WithEvents ModificarBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarBtn As System.Windows.Forms.Button
    Friend WithEvents BuscarCmb As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarPorLbl As System.Windows.Forms.Label
    Friend WithEvents BusquedaTxt As System.Windows.Forms.TextBox
    Friend WithEvents IgualLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ExportarCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportarAXLSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents RecargarBtn As System.Windows.Forms.Button
    Friend WithEvents SiguienteBtn As System.Windows.Forms.Button
    Friend WithEvents AnteriorBtn As System.Windows.Forms.Button
    Friend WithEvents UltimoBtn As System.Windows.Forms.Button
    Friend WithEvents PrimeroBtn As System.Windows.Forms.Button
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents CodUsuCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApellidoCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorreoCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EdadCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
