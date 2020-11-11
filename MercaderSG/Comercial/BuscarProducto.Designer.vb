<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscarProducto
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
        Me.RecargarBtn = New System.Windows.Forms.Button()
        Me.ProductoGB = New System.Windows.Forms.GroupBox()
        Me.ProductosDG = New System.Windows.Forms.DataGridView()
        Me.CodProdCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitarioCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SectorCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuscarCmb = New System.Windows.Forms.ComboBox()
        Me.BuscarPorLbl = New System.Windows.Forms.Label()
        Me.BusquedaTxt = New System.Windows.Forms.TextBox()
        Me.IgualLbl = New System.Windows.Forms.Label()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProductoGB.SuspendLayout()
        CType(Me.ProductosDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RecargarBtn
        '
        Me.RecargarBtn.Image = Global.MercaderSG.My.Resources.Resources.RecargarE
        Me.RecargarBtn.Location = New System.Drawing.Point(512, 28)
        Me.RecargarBtn.Margin = New System.Windows.Forms.Padding(17, 3, 17, 3)
        Me.RecargarBtn.Name = "RecargarBtn"
        Me.RecargarBtn.Size = New System.Drawing.Size(44, 28)
        Me.RecargarBtn.TabIndex = 3
        Me.RecargarBtn.UseVisualStyleBackColor = True
        '
        'ProductoGB
        '
        Me.ProductoGB.Controls.Add(Me.ProductosDG)
        Me.ProductoGB.Controls.Add(Me.BuscarCmb)
        Me.ProductoGB.Controls.Add(Me.BuscarPorLbl)
        Me.ProductoGB.Controls.Add(Me.BusquedaTxt)
        Me.ProductoGB.Controls.Add(Me.IgualLbl)
        Me.ProductoGB.Controls.Add(Me.BuscarBtn)
        Me.ProductoGB.Controls.Add(Me.RecargarBtn)
        Me.ProductoGB.Location = New System.Drawing.Point(12, 16)
        Me.ProductoGB.Name = "ProductoGB"
        Me.ProductoGB.Size = New System.Drawing.Size(576, 299)
        Me.ProductoGB.TabIndex = 65
        Me.ProductoGB.TabStop = False
        Me.ProductoGB.Text = "Seleccionar Producto"
        '
        'ProductosDG
        '
        Me.ProductosDG.AllowUserToAddRows = False
        Me.ProductosDG.AllowUserToDeleteRows = False
        Me.ProductosDG.AllowUserToResizeColumns = False
        Me.ProductosDG.AllowUserToResizeRows = False
        Me.ProductosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductosDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodProdCAB, Me.NombreCAB, Me.PrecioUnitarioCAB, Me.CantidadCAB, Me.SectorCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductosDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProductosDG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProductosDG.Location = New System.Drawing.Point(3, 77)
        Me.ProductosDG.MultiSelect = False
        Me.ProductosDG.Name = "ProductosDG"
        Me.ProductosDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProductosDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.ProductosDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosDG.Size = New System.Drawing.Size(570, 219)
        Me.ProductosDG.StandardTab = True
        Me.ProductosDG.TabIndex = 69
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
        'BuscarCmb
        '
        Me.BuscarCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BuscarCmb.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarCmb.FormattingEnabled = True
        Me.BuscarCmb.Location = New System.Drawing.Point(88, 30)
        Me.BuscarCmb.Name = "BuscarCmb"
        Me.BuscarCmb.Size = New System.Drawing.Size(121, 23)
        Me.BuscarCmb.TabIndex = 0
        '
        'BuscarPorLbl
        '
        Me.BuscarPorLbl.AutoSize = True
        Me.BuscarPorLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarPorLbl.Location = New System.Drawing.Point(15, 33)
        Me.BuscarPorLbl.Name = "BuscarPorLbl"
        Me.BuscarPorLbl.Size = New System.Drawing.Size(67, 15)
        Me.BuscarPorLbl.TabIndex = 66
        Me.BuscarPorLbl.Text = "Buscar por"
        '
        'BusquedaTxt
        '
        Me.BusquedaTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BusquedaTxt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BusquedaTxt.Location = New System.Drawing.Point(266, 30)
        Me.BusquedaTxt.Name = "BusquedaTxt"
        Me.BusquedaTxt.Size = New System.Drawing.Size(122, 23)
        Me.BusquedaTxt.TabIndex = 1
        '
        'IgualLbl
        '
        Me.IgualLbl.AutoSize = True
        Me.IgualLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgualLbl.Location = New System.Drawing.Point(215, 33)
        Me.IgualLbl.Name = "IgualLbl"
        Me.IgualLbl.Size = New System.Drawing.Size(45, 15)
        Me.IgualLbl.TabIndex = 68
        Me.IgualLbl.Text = "igual a"
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarBtn.Location = New System.Drawing.Point(404, 26)
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
        'MensajeTT
        '
        Me.MensajeTT.AutomaticDelay = 100
        Me.MensajeTT.AutoPopDelay = 5000
        Me.MensajeTT.InitialDelay = 1000
        Me.MensajeTT.ReshowDelay = 500
        Me.MensajeTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.MensajeTT.ToolTipTitle = "MercaderSG"
        '
        'BuscarProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(601, 327)
        Me.Controls.Add(Me.ProductoGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(607, 356)
        Me.MinimumSize = New System.Drawing.Size(607, 356)
        Me.Name = "BuscarProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ProductoGB.ResumeLayout(False)
        Me.ProductoGB.PerformLayout()
        CType(Me.ProductosDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RecargarBtn As System.Windows.Forms.Button
    Friend WithEvents ProductoGB As System.Windows.Forms.GroupBox
    Friend WithEvents BuscarCmb As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarPorLbl As System.Windows.Forms.Label
    Friend WithEvents BusquedaTxt As System.Windows.Forms.TextBox
    Friend WithEvents IgualLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ProductosDG As System.Windows.Forms.DataGridView
    Friend WithEvents CodProdCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitarioCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectorCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
