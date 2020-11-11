<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscarCliente
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
        Me.ClienteGB = New System.Windows.Forms.GroupBox()
        Me.ClienteDG = New System.Windows.Forms.DataGridView()
        Me.CodCliCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazonSocialCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuitCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DireccionCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocalidadCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecargarBtn = New System.Windows.Forms.Button()
        Me.BuscarCmb = New System.Windows.Forms.ComboBox()
        Me.BuscarPorLbl = New System.Windows.Forms.Label()
        Me.BusquedaTxt = New System.Windows.Forms.TextBox()
        Me.IgualLbl = New System.Windows.Forms.Label()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ClienteGB.SuspendLayout()
        CType(Me.ClienteDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClienteGB
        '
        Me.ClienteGB.Controls.Add(Me.ClienteDG)
        Me.ClienteGB.Controls.Add(Me.RecargarBtn)
        Me.ClienteGB.Controls.Add(Me.BuscarCmb)
        Me.ClienteGB.Controls.Add(Me.BuscarPorLbl)
        Me.ClienteGB.Controls.Add(Me.BusquedaTxt)
        Me.ClienteGB.Controls.Add(Me.IgualLbl)
        Me.ClienteGB.Controls.Add(Me.BuscarBtn)
        Me.ClienteGB.Location = New System.Drawing.Point(12, 12)
        Me.ClienteGB.Name = "ClienteGB"
        Me.ClienteGB.Size = New System.Drawing.Size(580, 272)
        Me.ClienteGB.TabIndex = 52
        Me.ClienteGB.TabStop = False
        Me.ClienteGB.Text = "Seleccionar Cliente"
        '
        'ClienteDG
        '
        Me.ClienteDG.AllowUserToAddRows = False
        Me.ClienteDG.AllowUserToDeleteRows = False
        Me.ClienteDG.AllowUserToResizeColumns = False
        Me.ClienteDG.AllowUserToResizeRows = False
        Me.ClienteDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ClienteDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodCliCAB, Me.RazonSocialCAB, Me.CuitCAB, Me.DireccionCAB, Me.LocalidadCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ClienteDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.ClienteDG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ClienteDG.Location = New System.Drawing.Point(3, 78)
        Me.ClienteDG.MultiSelect = False
        Me.ClienteDG.Name = "ClienteDG"
        Me.ClienteDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ClienteDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.ClienteDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ClienteDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ClienteDG.Size = New System.Drawing.Size(574, 191)
        Me.ClienteDG.StandardTab = True
        Me.ClienteDG.TabIndex = 55
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
        'BuscarCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(604, 296)
        Me.Controls.Add(Me.ClienteGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(610, 325)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(610, 325)
        Me.Name = "BuscarCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ClienteGB.ResumeLayout(False)
        Me.ClienteGB.PerformLayout()
        CType(Me.ClienteDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ClienteGB As System.Windows.Forms.GroupBox
    Friend WithEvents BuscarCmb As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarPorLbl As System.Windows.Forms.Label
    Friend WithEvents BusquedaTxt As System.Windows.Forms.TextBox
    Friend WithEvents IgualLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents RecargarBtn As System.Windows.Forms.Button
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ClienteDG As System.Windows.Forms.DataGridView
    Friend WithEvents CodCliCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RazonSocialCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuitCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DireccionCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocalidadCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
