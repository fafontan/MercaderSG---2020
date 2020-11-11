<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotaPedido
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
        Me.ProveedorGB = New System.Windows.Forms.GroupBox()
        Me.EstadoCB = New System.Windows.Forms.CheckBox()
        Me.FechaDTP = New System.Windows.Forms.DateTimePicker()
        Me.FechaEmiLbl = New System.Windows.Forms.Label()
        Me.ActivoLbl = New System.Windows.Forms.Label()
        Me.DireccionLbl = New System.Windows.Forms.Label()
        Me.DireccionTxt = New System.Windows.Forms.TextBox()
        Me.CuitTxt = New System.Windows.Forms.TextBox()
        Me.CuitLbl = New System.Windows.Forms.Label()
        Me.RazonSocialTxt = New System.Windows.Forms.TextBox()
        Me.RazonSocialLbl = New System.Windows.Forms.Label()
        Me.BuscarCliBtn = New System.Windows.Forms.Button()
        Me.CodProvTxt = New System.Windows.Forms.TextBox()
        Me.CodProvLbl = New System.Windows.Forms.Label()
        Me.ProductoGB = New System.Windows.Forms.GroupBox()
        Me.PrecioTxt = New System.Windows.Forms.TextBox()
        Me.CantidadTxt = New System.Windows.Forms.TextBox()
        Me.CantidadLbl = New System.Windows.Forms.Label()
        Me.PrecioLbl = New System.Windows.Forms.Label()
        Me.DescProdTxt = New System.Windows.Forms.TextBox()
        Me.DescProdLbl = New System.Windows.Forms.Label()
        Me.NombreProdTxt = New System.Windows.Forms.TextBox()
        Me.NombreProdLbl = New System.Windows.Forms.Label()
        Me.BuscarProdBtn = New System.Windows.Forms.Button()
        Me.CodProdTxt = New System.Windows.Forms.TextBox()
        Me.CodProdLbl = New System.Windows.Forms.Label()
        Me.NotaVentaGB = New System.Windows.Forms.GroupBox()
        Me.GenerarBtn = New System.Windows.Forms.Button()
        Me.DetalleDG = New System.Windows.Forms.DataGridView()
        Me.CodProdCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NuevoBtn = New System.Windows.Forms.Button()
        Me.EliminarBtn = New System.Windows.Forms.Button()
        Me.TotalTxt = New System.Windows.Forms.TextBox()
        Me.AgregarBtn = New System.Windows.Forms.Button()
        Me.TotalLbl = New System.Windows.Forms.Label()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProveedorGB.SuspendLayout()
        Me.ProductoGB.SuspendLayout()
        Me.NotaVentaGB.SuspendLayout()
        CType(Me.DetalleDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProveedorGB
        '
        Me.ProveedorGB.Controls.Add(Me.EstadoCB)
        Me.ProveedorGB.Controls.Add(Me.FechaDTP)
        Me.ProveedorGB.Controls.Add(Me.FechaEmiLbl)
        Me.ProveedorGB.Controls.Add(Me.ActivoLbl)
        Me.ProveedorGB.Controls.Add(Me.DireccionLbl)
        Me.ProveedorGB.Controls.Add(Me.DireccionTxt)
        Me.ProveedorGB.Controls.Add(Me.CuitTxt)
        Me.ProveedorGB.Controls.Add(Me.CuitLbl)
        Me.ProveedorGB.Controls.Add(Me.RazonSocialTxt)
        Me.ProveedorGB.Controls.Add(Me.RazonSocialLbl)
        Me.ProveedorGB.Controls.Add(Me.BuscarCliBtn)
        Me.ProveedorGB.Controls.Add(Me.CodProvTxt)
        Me.ProveedorGB.Controls.Add(Me.CodProvLbl)
        Me.ProveedorGB.Location = New System.Drawing.Point(12, 12)
        Me.ProveedorGB.Name = "ProveedorGB"
        Me.ProveedorGB.Size = New System.Drawing.Size(630, 124)
        Me.ProveedorGB.TabIndex = 12
        Me.ProveedorGB.TabStop = False
        Me.ProveedorGB.Text = "Datos Proveedor"
        '
        'EstadoCB
        '
        Me.EstadoCB.AutoCheck = False
        Me.EstadoCB.AutoSize = True
        Me.EstadoCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EstadoCB.ForeColor = System.Drawing.Color.SteelBlue
        Me.EstadoCB.Location = New System.Drawing.Point(469, 36)
        Me.EstadoCB.Name = "EstadoCB"
        Me.EstadoCB.Size = New System.Drawing.Size(12, 11)
        Me.EstadoCB.TabIndex = 5
        Me.EstadoCB.UseVisualStyleBackColor = True
        '
        'FechaDTP
        '
        Me.FechaDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaDTP.Location = New System.Drawing.Point(522, 74)
        Me.FechaDTP.Name = "FechaDTP"
        Me.FechaDTP.Size = New System.Drawing.Size(90, 23)
        Me.FechaDTP.TabIndex = 6
        '
        'FechaEmiLbl
        '
        Me.FechaEmiLbl.AutoSize = True
        Me.FechaEmiLbl.Location = New System.Drawing.Point(417, 77)
        Me.FechaEmiLbl.Name = "FechaEmiLbl"
        Me.FechaEmiLbl.Size = New System.Drawing.Size(86, 15)
        Me.FechaEmiLbl.TabIndex = 11
        Me.FechaEmiLbl.Text = "Fecha Emision"
        '
        'ActivoLbl
        '
        Me.ActivoLbl.AutoSize = True
        Me.ActivoLbl.Location = New System.Drawing.Point(417, 34)
        Me.ActivoLbl.Name = "ActivoLbl"
        Me.ActivoLbl.Size = New System.Drawing.Size(44, 15)
        Me.ActivoLbl.TabIndex = 13
        Me.ActivoLbl.Text = "Estado"
        '
        'DireccionLbl
        '
        Me.DireccionLbl.AutoSize = True
        Me.DireccionLbl.Location = New System.Drawing.Point(204, 32)
        Me.DireccionLbl.Name = "DireccionLbl"
        Me.DireccionLbl.Size = New System.Drawing.Size(60, 15)
        Me.DireccionLbl.TabIndex = 10
        Me.DireccionLbl.Text = "Direccion"
        '
        'DireccionTxt
        '
        Me.DireccionTxt.Location = New System.Drawing.Point(297, 29)
        Me.DireccionTxt.Name = "DireccionTxt"
        Me.DireccionTxt.ReadOnly = True
        Me.DireccionTxt.Size = New System.Drawing.Size(100, 23)
        Me.DireccionTxt.TabIndex = 3
        '
        'CuitTxt
        '
        Me.CuitTxt.Location = New System.Drawing.Point(80, 74)
        Me.CuitTxt.Name = "CuitTxt"
        Me.CuitTxt.ReadOnly = True
        Me.CuitTxt.Size = New System.Drawing.Size(100, 23)
        Me.CuitTxt.TabIndex = 2
        '
        'CuitLbl
        '
        Me.CuitLbl.AutoSize = True
        Me.CuitLbl.Location = New System.Drawing.Point(19, 77)
        Me.CuitLbl.Name = "CuitLbl"
        Me.CuitLbl.Size = New System.Drawing.Size(32, 15)
        Me.CuitLbl.TabIndex = 5
        Me.CuitLbl.Text = "CUIT"
        '
        'RazonSocialTxt
        '
        Me.RazonSocialTxt.Location = New System.Drawing.Point(297, 74)
        Me.RazonSocialTxt.Name = "RazonSocialTxt"
        Me.RazonSocialTxt.ReadOnly = True
        Me.RazonSocialTxt.Size = New System.Drawing.Size(100, 23)
        Me.RazonSocialTxt.TabIndex = 4
        '
        'RazonSocialLbl
        '
        Me.RazonSocialLbl.AutoSize = True
        Me.RazonSocialLbl.Location = New System.Drawing.Point(204, 77)
        Me.RazonSocialLbl.Name = "RazonSocialLbl"
        Me.RazonSocialLbl.Size = New System.Drawing.Size(77, 15)
        Me.RazonSocialLbl.TabIndex = 3
        Me.RazonSocialLbl.Text = "Razon Social"
        '
        'BuscarCliBtn
        '
        Me.BuscarCliBtn.Image = Global.MercaderSG.My.Resources.Resources.search
        Me.BuscarCliBtn.Location = New System.Drawing.Point(144, 29)
        Me.BuscarCliBtn.Name = "BuscarCliBtn"
        Me.BuscarCliBtn.Size = New System.Drawing.Size(36, 23)
        Me.BuscarCliBtn.TabIndex = 1
        Me.BuscarCliBtn.UseVisualStyleBackColor = True
        '
        'CodProvTxt
        '
        Me.CodProvTxt.Location = New System.Drawing.Point(80, 29)
        Me.CodProvTxt.Name = "CodProvTxt"
        Me.CodProvTxt.ReadOnly = True
        Me.CodProvTxt.Size = New System.Drawing.Size(58, 23)
        Me.CodProvTxt.TabIndex = 0
        '
        'CodProvLbl
        '
        Me.CodProvLbl.AutoSize = True
        Me.CodProvLbl.Location = New System.Drawing.Point(19, 32)
        Me.CodProvLbl.Name = "CodProvLbl"
        Me.CodProvLbl.Size = New System.Drawing.Size(45, 15)
        Me.CodProvLbl.TabIndex = 0
        Me.CodProvLbl.Text = "Codigo"
        '
        'ProductoGB
        '
        Me.ProductoGB.Controls.Add(Me.PrecioTxt)
        Me.ProductoGB.Controls.Add(Me.CantidadTxt)
        Me.ProductoGB.Controls.Add(Me.CantidadLbl)
        Me.ProductoGB.Controls.Add(Me.PrecioLbl)
        Me.ProductoGB.Controls.Add(Me.DescProdTxt)
        Me.ProductoGB.Controls.Add(Me.DescProdLbl)
        Me.ProductoGB.Controls.Add(Me.NombreProdTxt)
        Me.ProductoGB.Controls.Add(Me.NombreProdLbl)
        Me.ProductoGB.Controls.Add(Me.BuscarProdBtn)
        Me.ProductoGB.Controls.Add(Me.CodProdTxt)
        Me.ProductoGB.Controls.Add(Me.CodProdLbl)
        Me.ProductoGB.Location = New System.Drawing.Point(12, 142)
        Me.ProductoGB.Name = "ProductoGB"
        Me.ProductoGB.Size = New System.Drawing.Size(630, 118)
        Me.ProductoGB.TabIndex = 15
        Me.ProductoGB.TabStop = False
        Me.ProductoGB.Text = "Datos Producto"
        '
        'PrecioTxt
        '
        Me.PrecioTxt.Location = New System.Drawing.Point(544, 28)
        Me.PrecioTxt.Name = "PrecioTxt"
        Me.PrecioTxt.ReadOnly = True
        Me.PrecioTxt.Size = New System.Drawing.Size(68, 23)
        Me.PrecioTxt.TabIndex = 11
        '
        'CantidadTxt
        '
        Me.CantidadTxt.Location = New System.Drawing.Point(544, 75)
        Me.CantidadTxt.Name = "CantidadTxt"
        Me.CantidadTxt.Size = New System.Drawing.Size(68, 23)
        Me.CantidadTxt.TabIndex = 12
        '
        'CantidadLbl
        '
        Me.CantidadLbl.AutoSize = True
        Me.CantidadLbl.Location = New System.Drawing.Point(482, 78)
        Me.CantidadLbl.Name = "CantidadLbl"
        Me.CantidadLbl.Size = New System.Drawing.Size(56, 15)
        Me.CantidadLbl.TabIndex = 13
        Me.CantidadLbl.Text = "Cantidad"
        '
        'PrecioLbl
        '
        Me.PrecioLbl.AutoSize = True
        Me.PrecioLbl.Location = New System.Drawing.Point(482, 33)
        Me.PrecioLbl.Name = "PrecioLbl"
        Me.PrecioLbl.Size = New System.Drawing.Size(42, 15)
        Me.PrecioLbl.TabIndex = 12
        Me.PrecioLbl.Text = "Precio"
        '
        'DescProdTxt
        '
        Me.DescProdTxt.Location = New System.Drawing.Point(287, 31)
        Me.DescProdTxt.Multiline = True
        Me.DescProdTxt.Name = "DescProdTxt"
        Me.DescProdTxt.ReadOnly = True
        Me.DescProdTxt.Size = New System.Drawing.Size(158, 68)
        Me.DescProdTxt.TabIndex = 10
        '
        'DescProdLbl
        '
        Me.DescProdLbl.AutoSize = True
        Me.DescProdLbl.Location = New System.Drawing.Point(208, 32)
        Me.DescProdLbl.Name = "DescProdLbl"
        Me.DescProdLbl.Size = New System.Drawing.Size(73, 15)
        Me.DescProdLbl.TabIndex = 10
        Me.DescProdLbl.Text = "Descripcion"
        '
        'NombreProdTxt
        '
        Me.NombreProdTxt.Location = New System.Drawing.Point(80, 76)
        Me.NombreProdTxt.Name = "NombreProdTxt"
        Me.NombreProdTxt.ReadOnly = True
        Me.NombreProdTxt.Size = New System.Drawing.Size(100, 23)
        Me.NombreProdTxt.TabIndex = 9
        '
        'NombreProdLbl
        '
        Me.NombreProdLbl.AutoSize = True
        Me.NombreProdLbl.Location = New System.Drawing.Point(21, 79)
        Me.NombreProdLbl.Name = "NombreProdLbl"
        Me.NombreProdLbl.Size = New System.Drawing.Size(50, 15)
        Me.NombreProdLbl.TabIndex = 8
        Me.NombreProdLbl.Text = "Nombre"
        '
        'BuscarProdBtn
        '
        Me.BuscarProdBtn.Image = Global.MercaderSG.My.Resources.Resources.search
        Me.BuscarProdBtn.Location = New System.Drawing.Point(144, 28)
        Me.BuscarProdBtn.Name = "BuscarProdBtn"
        Me.BuscarProdBtn.Size = New System.Drawing.Size(36, 23)
        Me.BuscarProdBtn.TabIndex = 8
        Me.BuscarProdBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarProdBtn.UseVisualStyleBackColor = True
        '
        'CodProdTxt
        '
        Me.CodProdTxt.Location = New System.Drawing.Point(80, 28)
        Me.CodProdTxt.Name = "CodProdTxt"
        Me.CodProdTxt.ReadOnly = True
        Me.CodProdTxt.Size = New System.Drawing.Size(58, 23)
        Me.CodProdTxt.TabIndex = 7
        '
        'CodProdLbl
        '
        Me.CodProdLbl.AutoSize = True
        Me.CodProdLbl.Location = New System.Drawing.Point(19, 31)
        Me.CodProdLbl.Name = "CodProdLbl"
        Me.CodProdLbl.Size = New System.Drawing.Size(45, 15)
        Me.CodProdLbl.TabIndex = 5
        Me.CodProdLbl.Text = "Codigo"
        '
        'NotaVentaGB
        '
        Me.NotaVentaGB.Controls.Add(Me.GenerarBtn)
        Me.NotaVentaGB.Controls.Add(Me.DetalleDG)
        Me.NotaVentaGB.Controls.Add(Me.NuevoBtn)
        Me.NotaVentaGB.Controls.Add(Me.EliminarBtn)
        Me.NotaVentaGB.Controls.Add(Me.TotalTxt)
        Me.NotaVentaGB.Controls.Add(Me.AgregarBtn)
        Me.NotaVentaGB.Controls.Add(Me.TotalLbl)
        Me.NotaVentaGB.Location = New System.Drawing.Point(12, 266)
        Me.NotaVentaGB.Name = "NotaVentaGB"
        Me.NotaVentaGB.Size = New System.Drawing.Size(630, 195)
        Me.NotaVentaGB.TabIndex = 16
        Me.NotaVentaGB.TabStop = False
        Me.NotaVentaGB.Text = "Detalle Nota de Venta"
        '
        'GenerarBtn
        '
        Me.GenerarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.GenerarBtn.Location = New System.Drawing.Point(504, 163)
        Me.GenerarBtn.Name = "GenerarBtn"
        Me.GenerarBtn.Size = New System.Drawing.Size(92, 23)
        Me.GenerarBtn.TabIndex = 18
        Me.GenerarBtn.Text = "Generar"
        Me.GenerarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.GenerarBtn.UseVisualStyleBackColor = True
        '
        'DetalleDG
        '
        Me.DetalleDG.AllowUserToAddRows = False
        Me.DetalleDG.AllowUserToDeleteRows = False
        Me.DetalleDG.AllowUserToResizeColumns = False
        Me.DetalleDG.AllowUserToResizeRows = False
        Me.DetalleDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DetalleDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodProdCAB, Me.NombreCAB, Me.PrecioCAB, Me.CantidadCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DetalleDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.DetalleDG.Dock = System.Windows.Forms.DockStyle.Left
        Me.DetalleDG.Location = New System.Drawing.Point(3, 19)
        Me.DetalleDG.MultiSelect = False
        Me.DetalleDG.Name = "DetalleDG"
        Me.DetalleDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DetalleDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DetalleDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DetalleDG.Size = New System.Drawing.Size(461, 173)
        Me.DetalleDG.TabIndex = 13
        '
        'CodProdCAB
        '
        Me.CodProdCAB.DataPropertyName = "CodProd"
        Me.CodProdCAB.HeaderText = "Código"
        Me.CodProdCAB.Name = "CodProdCAB"
        Me.CodProdCAB.ReadOnly = True
        '
        'NombreCAB
        '
        Me.NombreCAB.DataPropertyName = "NombreProducto"
        Me.NombreCAB.HeaderText = "Nombre"
        Me.NombreCAB.Name = "NombreCAB"
        Me.NombreCAB.ReadOnly = True
        '
        'PrecioCAB
        '
        Me.PrecioCAB.DataPropertyName = "Precio"
        Me.PrecioCAB.HeaderText = "Precio"
        Me.PrecioCAB.Name = "PrecioCAB"
        Me.PrecioCAB.ReadOnly = True
        '
        'CantidadCAB
        '
        Me.CantidadCAB.DataPropertyName = "Cantidad"
        Me.CantidadCAB.HeaderText = "Cantidad"
        Me.CantidadCAB.Name = "CantidadCAB"
        Me.CantidadCAB.ReadOnly = True
        '
        'NuevoBtn
        '
        Me.NuevoBtn.Image = Global.MercaderSG.My.Resources.Resources.newPage
        Me.NuevoBtn.Location = New System.Drawing.Point(504, 80)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Size = New System.Drawing.Size(92, 24)
        Me.NuevoBtn.TabIndex = 16
        Me.NuevoBtn.Text = "Nuevo"
        Me.NuevoBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.NuevoBtn.UseVisualStyleBackColor = True
        '
        'EliminarBtn
        '
        Me.EliminarBtn.Image = Global.MercaderSG.My.Resources.Resources.delete
        Me.EliminarBtn.Location = New System.Drawing.Point(504, 51)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(92, 24)
        Me.EliminarBtn.TabIndex = 15
        Me.EliminarBtn.Text = "Eliminar"
        Me.EliminarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EliminarBtn.UseVisualStyleBackColor = True
        '
        'TotalTxt
        '
        Me.TotalTxt.Location = New System.Drawing.Point(504, 134)
        Me.TotalTxt.Name = "TotalTxt"
        Me.TotalTxt.ReadOnly = True
        Me.TotalTxt.Size = New System.Drawing.Size(92, 23)
        Me.TotalTxt.TabIndex = 17
        Me.TotalTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AgregarBtn
        '
        Me.AgregarBtn.Image = Global.MercaderSG.My.Resources.Resources.add
        Me.AgregarBtn.Location = New System.Drawing.Point(504, 21)
        Me.AgregarBtn.Name = "AgregarBtn"
        Me.AgregarBtn.Size = New System.Drawing.Size(92, 24)
        Me.AgregarBtn.TabIndex = 14
        Me.AgregarBtn.Text = "Agregar"
        Me.AgregarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AgregarBtn.UseVisualStyleBackColor = True
        '
        'TotalLbl
        '
        Me.TotalLbl.AutoSize = True
        Me.TotalLbl.Location = New System.Drawing.Point(532, 116)
        Me.TotalLbl.Name = "TotalLbl"
        Me.TotalLbl.Size = New System.Drawing.Size(39, 15)
        Me.TotalLbl.TabIndex = 3
        Me.TotalLbl.Text = "TOTAL"
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
        'NotaPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(655, 473)
        Me.Controls.Add(Me.NotaVentaGB)
        Me.Controls.Add(Me.ProductoGB)
        Me.Controls.Add(Me.ProveedorGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(661, 502)
        Me.MinimumSize = New System.Drawing.Size(661, 502)
        Me.Name = "NotaPedido"
        Me.ProveedorGB.ResumeLayout(False)
        Me.ProveedorGB.PerformLayout()
        Me.ProductoGB.ResumeLayout(False)
        Me.ProductoGB.PerformLayout()
        Me.NotaVentaGB.ResumeLayout(False)
        Me.NotaVentaGB.PerformLayout()
        CType(Me.DetalleDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProveedorGB As System.Windows.Forms.GroupBox
    Friend WithEvents EstadoCB As System.Windows.Forms.CheckBox
    Friend WithEvents FechaDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents FechaEmiLbl As System.Windows.Forms.Label
    Friend WithEvents ActivoLbl As System.Windows.Forms.Label
    Friend WithEvents DireccionLbl As System.Windows.Forms.Label
    Friend WithEvents DireccionTxt As System.Windows.Forms.TextBox
    Friend WithEvents CuitTxt As System.Windows.Forms.TextBox
    Friend WithEvents CuitLbl As System.Windows.Forms.Label
    Friend WithEvents RazonSocialTxt As System.Windows.Forms.TextBox
    Friend WithEvents RazonSocialLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarCliBtn As System.Windows.Forms.Button
    Friend WithEvents CodProvTxt As System.Windows.Forms.TextBox
    Friend WithEvents CodProvLbl As System.Windows.Forms.Label
    Friend WithEvents ProductoGB As System.Windows.Forms.GroupBox
    Friend WithEvents PrecioTxt As System.Windows.Forms.TextBox
    Friend WithEvents CantidadTxt As System.Windows.Forms.TextBox
    Friend WithEvents CantidadLbl As System.Windows.Forms.Label
    Friend WithEvents PrecioLbl As System.Windows.Forms.Label
    Friend WithEvents DescProdTxt As System.Windows.Forms.TextBox
    Friend WithEvents DescProdLbl As System.Windows.Forms.Label
    Friend WithEvents NombreProdTxt As System.Windows.Forms.TextBox
    Friend WithEvents NombreProdLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarProdBtn As System.Windows.Forms.Button
    Friend WithEvents CodProdTxt As System.Windows.Forms.TextBox
    Friend WithEvents CodProdLbl As System.Windows.Forms.Label
    Friend WithEvents NotaVentaGB As System.Windows.Forms.GroupBox
    Friend WithEvents GenerarBtn As System.Windows.Forms.Button
    Friend WithEvents DetalleDG As System.Windows.Forms.DataGridView
    Friend WithEvents CodProdCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NuevoBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarBtn As System.Windows.Forms.Button
    Friend WithEvents TotalTxt As System.Windows.Forms.TextBox
    Friend WithEvents AgregarBtn As System.Windows.Forms.Button
    Friend WithEvents TotalLbl As System.Windows.Forms.Label
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
End Class
