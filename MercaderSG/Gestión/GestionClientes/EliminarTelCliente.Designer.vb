<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EliminarTelCliente
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
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.TelefonosGB = New System.Windows.Forms.GroupBox()
        Me.TelefonosDG = New System.Windows.Forms.DataGridView()
        Me.CodTelCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodCliCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.TelefonosGB.SuspendLayout()
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.ForeColor = System.Drawing.Color.Black
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(204, 160)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 3
        Me.CancelarBtn.Text = "&Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.ForeColor = System.Drawing.Color.Black
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(116, 160)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 2
        Me.AceptarBtn.Text = "&Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'TelefonosGB
        '
        Me.TelefonosGB.Controls.Add(Me.TelefonosDG)
        Me.TelefonosGB.Location = New System.Drawing.Point(14, 14)
        Me.TelefonosGB.Margin = New System.Windows.Forms.Padding(5)
        Me.TelefonosGB.Name = "TelefonosGB"
        Me.TelefonosGB.Padding = New System.Windows.Forms.Padding(5)
        Me.TelefonosGB.Size = New System.Drawing.Size(374, 138)
        Me.TelefonosGB.TabIndex = 0
        Me.TelefonosGB.TabStop = False
        Me.TelefonosGB.Text = "Telefonos"
        '
        'TelefonosDG
        '
        Me.TelefonosDG.AllowUserToAddRows = False
        Me.TelefonosDG.AllowUserToDeleteRows = False
        Me.TelefonosDG.AllowUserToResizeRows = False
        Me.TelefonosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TelefonosDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodTelCAB, Me.CodCliCAB, Me.NumeroCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TelefonosDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.TelefonosDG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TelefonosDG.Location = New System.Drawing.Point(5, 20)
        Me.TelefonosDG.MultiSelect = False
        Me.TelefonosDG.Name = "TelefonosDG"
        Me.TelefonosDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TelefonosDG.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.TelefonosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TelefonosDG.Size = New System.Drawing.Size(364, 113)
        Me.TelefonosDG.StandardTab = True
        Me.TelefonosDG.TabIndex = 1
        '
        'CodTelCAB
        '
        Me.CodTelCAB.DataPropertyName = "CodTel"
        Me.CodTelCAB.HeaderText = "C.Telefono"
        Me.CodTelCAB.Name = "CodTelCAB"
        Me.CodTelCAB.ReadOnly = True
        '
        'CodCliCAB
        '
        Me.CodCliCAB.DataPropertyName = "CodEn"
        Me.CodCliCAB.HeaderText = "C.Cliente"
        Me.CodCliCAB.Name = "CodCliCAB"
        Me.CodCliCAB.ReadOnly = True
        '
        'NumeroCAB
        '
        Me.NumeroCAB.DataPropertyName = "Numero"
        Me.NumeroCAB.HeaderText = "Número"
        Me.NumeroCAB.Name = "NumeroCAB"
        Me.NumeroCAB.ReadOnly = True
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
        'EliminarTelCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(402, 192)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.TelefonosGB)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EliminarTelCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Eliminar número de teléfono - MercaderSG"
        Me.TelefonosGB.ResumeLayout(False)
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents TelefonosGB As System.Windows.Forms.GroupBox
    Friend WithEvents TelefonosDG As System.Windows.Forms.DataGridView
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents CodTelCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodCliCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
