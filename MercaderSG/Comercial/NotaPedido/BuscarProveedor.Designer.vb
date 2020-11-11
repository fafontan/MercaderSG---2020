<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscarProveedor
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
        Me.ProveedorDG = New System.Windows.Forms.DataGridView()
        Me.RecargarBtn = New System.Windows.Forms.Button()
        Me.BuscarCmb = New System.Windows.Forms.ComboBox()
        Me.BuscarPorLbl = New System.Windows.Forms.Label()
        Me.BusquedaTxt = New System.Windows.Forms.TextBox()
        Me.IgualLbl = New System.Windows.Forms.Label()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.CodProvCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazonSocialCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuitCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorreoElectronicoCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DireccionCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorGB.SuspendLayout()
        CType(Me.ProveedorDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProveedorGB
        '
        Me.ProveedorGB.Controls.Add(Me.ProveedorDG)
        Me.ProveedorGB.Controls.Add(Me.RecargarBtn)
        Me.ProveedorGB.Controls.Add(Me.BuscarCmb)
        Me.ProveedorGB.Controls.Add(Me.BuscarPorLbl)
        Me.ProveedorGB.Controls.Add(Me.BusquedaTxt)
        Me.ProveedorGB.Controls.Add(Me.IgualLbl)
        Me.ProveedorGB.Controls.Add(Me.BuscarBtn)
        Me.ProveedorGB.Location = New System.Drawing.Point(12, 12)
        Me.ProveedorGB.Name = "ProveedorGB"
        Me.ProveedorGB.Size = New System.Drawing.Size(580, 272)
        Me.ProveedorGB.TabIndex = 53
        Me.ProveedorGB.TabStop = False
        Me.ProveedorGB.Text = "Seleccionar Cliente"
        '
        'ProveedorDG
        '
        Me.ProveedorDG.AllowUserToAddRows = False
        Me.ProveedorDG.AllowUserToDeleteRows = False
        Me.ProveedorDG.AllowUserToResizeColumns = False
        Me.ProveedorDG.AllowUserToResizeRows = False
        Me.ProveedorDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProveedorDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodProvCAB, Me.RazonSocialCAB, Me.CuitCAB, Me.CorreoElectronicoCAB, Me.DireccionCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProveedorDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProveedorDG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProveedorDG.Location = New System.Drawing.Point(3, 77)
        Me.ProveedorDG.MultiSelect = False
        Me.ProveedorDG.Name = "ProveedorDG"
        Me.ProveedorDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProveedorDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.ProveedorDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProveedorDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProveedorDG.Size = New System.Drawing.Size(574, 192)
        Me.ProveedorDG.StandardTab = True
        Me.ProveedorDG.TabIndex = 55
        '
        'RecargarBtn
        '
        Me.RecargarBtn.Image = Global.MercaderSG.My.Resources.Resources.RecargarE
        Me.RecargarBtn.Location = New System.Drawing.Point(518, 25)
        Me.RecargarBtn.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
        Me.RecargarBtn.Name = "RecargarBtn"
        Me.RecargarBtn.Size = New System.Drawing.Size(44, 28)
        Me.RecargarBtn.TabIndex = 3
        Me.RecargarBtn.UseVisualStyleBackColor = True
        '
        'BuscarCmb
        '
        Me.BuscarCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BuscarCmb.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarCmb.FormattingEnabled = True
        Me.BuscarCmb.Location = New System.Drawing.Point(92, 29)
        Me.BuscarCmb.Name = "BuscarCmb"
        Me.BuscarCmb.Size = New System.Drawing.Size(121, 23)
        Me.BuscarCmb.TabIndex = 0
        '
        'BuscarPorLbl
        '
        Me.BuscarPorLbl.AutoSize = True
        Me.BuscarPorLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarPorLbl.Location = New System.Drawing.Point(19, 32)
        Me.BuscarPorLbl.Name = "BuscarPorLbl"
        Me.BuscarPorLbl.Size = New System.Drawing.Size(67, 15)
        Me.BuscarPorLbl.TabIndex = 52
        Me.BuscarPorLbl.Text = "Buscar por"
        '
        'BusquedaTxt
        '
        Me.BusquedaTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BusquedaTxt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BusquedaTxt.Location = New System.Drawing.Point(270, 29)
        Me.BusquedaTxt.Name = "BusquedaTxt"
        Me.BusquedaTxt.Size = New System.Drawing.Size(122, 23)
        Me.BusquedaTxt.TabIndex = 1
        '
        'IgualLbl
        '
        Me.IgualLbl.AutoSize = True
        Me.IgualLbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgualLbl.Location = New System.Drawing.Point(219, 32)
        Me.IgualLbl.Name = "IgualLbl"
        Me.IgualLbl.Size = New System.Drawing.Size(45, 15)
        Me.IgualLbl.TabIndex = 54
        Me.IgualLbl.Text = "igual a"
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BuscarBtn.Location = New System.Drawing.Point(412, 24)
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
        'CodProvCAB
        '
        Me.CodProvCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CodProvCAB.DataPropertyName = "CodProv"
        Me.CodProvCAB.HeaderText = "Código"
        Me.CodProvCAB.Name = "CodProvCAB"
        Me.CodProvCAB.ReadOnly = True
        Me.CodProvCAB.Visible = False
        Me.CodProvCAB.Width = 70
        '
        'RazonSocialCAB
        '
        Me.RazonSocialCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.RazonSocialCAB.DataPropertyName = "RazonSocial"
        Me.RazonSocialCAB.HeaderText = "Razon Social"
        Me.RazonSocialCAB.Name = "RazonSocialCAB"
        Me.RazonSocialCAB.ReadOnly = True
        Me.RazonSocialCAB.Width = 105
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
        'CorreoElectronicoCAB
        '
        Me.CorreoElectronicoCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CorreoElectronicoCAB.DataPropertyName = "CorreoElectronico"
        Me.CorreoElectronicoCAB.HeaderText = "Correo Electronico"
        Me.CorreoElectronicoCAB.Name = "CorreoElectronicoCAB"
        Me.CorreoElectronicoCAB.ReadOnly = True
        Me.CorreoElectronicoCAB.Width = 155
        '
        'DireccionCAB
        '
        Me.DireccionCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DireccionCAB.DataPropertyName = "Direccion"
        Me.DireccionCAB.HeaderText = "Dirección"
        Me.DireccionCAB.Name = "DireccionCAB"
        Me.DireccionCAB.ReadOnly = True
        Me.DireccionCAB.Width = 122
        '
        'BuscarProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(604, 296)
        Me.Controls.Add(Me.ProveedorGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(610, 325)
        Me.MinimumSize = New System.Drawing.Size(610, 325)
        Me.Name = "BuscarProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Proveedor"
        Me.ProveedorGB.ResumeLayout(False)
        Me.ProveedorGB.PerformLayout()
        CType(Me.ProveedorDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProveedorGB As System.Windows.Forms.GroupBox
    Friend WithEvents RecargarBtn As System.Windows.Forms.Button
    Friend WithEvents BuscarCmb As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarPorLbl As System.Windows.Forms.Label
    Friend WithEvents BusquedaTxt As System.Windows.Forms.TextBox
    Friend WithEvents IgualLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ProveedorDG As System.Windows.Forms.DataGridView
    Friend WithEvents CodProvCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RazonSocialCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuitCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorreoElectronicoCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DireccionCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
