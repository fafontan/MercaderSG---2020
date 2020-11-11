<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionNP
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
        Me.NotaGB = New System.Windows.Forms.GroupBox()
        Me.NotaPedidoDG = New System.Windows.Forms.DataGridView()
        Me.NroNotaCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.NroNotaTxt = New System.Windows.Forms.TextBox()
        Me.AccionCMB = New System.Windows.Forms.ComboBox()
        Me.NroNotaLbl = New System.Windows.Forms.Label()
        Me.AccionLbl = New System.Windows.Forms.Label()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotaGB.SuspendLayout()
        CType(Me.NotaPedidoDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(184, 271)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 5
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(96, 271)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 4
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'NotaGB
        '
        Me.NotaGB.Controls.Add(Me.NotaPedidoDG)
        Me.NotaGB.Location = New System.Drawing.Point(14, 92)
        Me.NotaGB.Name = "NotaGB"
        Me.NotaGB.Size = New System.Drawing.Size(334, 173)
        Me.NotaGB.TabIndex = 55
        Me.NotaGB.TabStop = False
        Me.NotaGB.Text = "Notas de Pedido"
        '
        'NotaPedidoDG
        '
        Me.NotaPedidoDG.AllowUserToAddRows = False
        Me.NotaPedidoDG.AllowUserToDeleteRows = False
        Me.NotaPedidoDG.AllowUserToResizeColumns = False
        Me.NotaPedidoDG.AllowUserToResizeRows = False
        Me.NotaPedidoDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NotaPedidoDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroNotaCAB, Me.FechaCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NotaPedidoDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.NotaPedidoDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotaPedidoDG.Location = New System.Drawing.Point(3, 19)
        Me.NotaPedidoDG.MultiSelect = False
        Me.NotaPedidoDG.Name = "NotaPedidoDG"
        Me.NotaPedidoDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NotaPedidoDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.NotaPedidoDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.NotaPedidoDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.NotaPedidoDG.Size = New System.Drawing.Size(328, 151)
        Me.NotaPedidoDG.StandardTab = True
        Me.NotaPedidoDG.TabIndex = 3
        '
        'NroNotaCAB
        '
        Me.NroNotaCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NroNotaCAB.DataPropertyName = "NroNota"
        Me.NroNotaCAB.HeaderText = "Nro_Nota"
        Me.NroNotaCAB.Name = "NroNotaCAB"
        Me.NroNotaCAB.ReadOnly = True
        Me.NroNotaCAB.Width = 140
        '
        'FechaCAB
        '
        Me.FechaCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FechaCAB.DataPropertyName = "Fecha"
        Me.FechaCAB.HeaderText = "Fecha"
        Me.FechaCAB.Name = "FechaCAB"
        Me.FechaCAB.ReadOnly = True
        Me.FechaCAB.Width = 125
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarBtn.Location = New System.Drawing.Point(259, 43)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(89, 30)
        Me.BuscarBtn.TabIndex = 2
        Me.BuscarBtn.Text = "&Buscar"
        Me.BuscarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarBtn.UseVisualStyleBackColor = True
        '
        'NroNotaTxt
        '
        Me.NroNotaTxt.Location = New System.Drawing.Point(116, 48)
        Me.NroNotaTxt.Name = "NroNotaTxt"
        Me.NroNotaTxt.Size = New System.Drawing.Size(136, 23)
        Me.NroNotaTxt.TabIndex = 1
        '
        'AccionCMB
        '
        Me.AccionCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AccionCMB.FormattingEnabled = True
        Me.AccionCMB.Location = New System.Drawing.Point(116, 14)
        Me.AccionCMB.Name = "AccionCMB"
        Me.AccionCMB.Size = New System.Drawing.Size(136, 23)
        Me.AccionCMB.TabIndex = 0
        '
        'NroNotaLbl
        '
        Me.NroNotaLbl.AutoSize = True
        Me.NroNotaLbl.Location = New System.Drawing.Point(11, 51)
        Me.NroNotaLbl.Name = "NroNotaLbl"
        Me.NroNotaLbl.Size = New System.Drawing.Size(95, 15)
        Me.NroNotaLbl.TabIndex = 51
        Me.NroNotaLbl.Text = "Número de Nota"
        '
        'AccionLbl
        '
        Me.AccionLbl.AutoSize = True
        Me.AccionLbl.Location = New System.Drawing.Point(11, 17)
        Me.AccionLbl.Name = "AccionLbl"
        Me.AccionLbl.Size = New System.Drawing.Size(44, 15)
        Me.AccionLbl.TabIndex = 50
        Me.AccionLbl.Text = "Acción"
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
        'GestionNP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 308)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.NotaGB)
        Me.Controls.Add(Me.BuscarBtn)
        Me.Controls.Add(Me.NroNotaTxt)
        Me.Controls.Add(Me.AccionCMB)
        Me.Controls.Add(Me.NroNotaLbl)
        Me.Controls.Add(Me.AccionLbl)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(364, 337)
        Me.MinimumSize = New System.Drawing.Size(364, 337)
        Me.Name = "GestionNP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GestionNP"
        Me.NotaGB.ResumeLayout(False)
        CType(Me.NotaPedidoDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents NotaGB As System.Windows.Forms.GroupBox
    Friend WithEvents NotaPedidoDG As System.Windows.Forms.DataGridView
    Friend WithEvents NroNotaCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents NroNotaTxt As System.Windows.Forms.TextBox
    Friend WithEvents AccionCMB As System.Windows.Forms.ComboBox
    Friend WithEvents NroNotaLbl As System.Windows.Forms.Label
    Friend WithEvents AccionLbl As System.Windows.Forms.Label
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
End Class
