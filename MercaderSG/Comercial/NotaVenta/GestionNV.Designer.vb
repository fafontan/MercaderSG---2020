<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionNV
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
        Me.AccionLbl = New System.Windows.Forms.Label()
        Me.NroNotaLbl = New System.Windows.Forms.Label()
        Me.AccionCMB = New System.Windows.Forms.ComboBox()
        Me.NroNotaTxt = New System.Windows.Forms.TextBox()
        Me.NotaGB = New System.Windows.Forms.GroupBox()
        Me.NotaVentaDG = New System.Windows.Forms.DataGridView()
        Me.NroNotaCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotaGB.SuspendLayout()
        CType(Me.NotaVentaDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccionLbl
        '
        Me.AccionLbl.AutoSize = True
        Me.AccionLbl.Location = New System.Drawing.Point(9, 19)
        Me.AccionLbl.Name = "AccionLbl"
        Me.AccionLbl.Size = New System.Drawing.Size(44, 15)
        Me.AccionLbl.TabIndex = 0
        Me.AccionLbl.Text = "Acción"
        '
        'NroNotaLbl
        '
        Me.NroNotaLbl.AutoSize = True
        Me.NroNotaLbl.Location = New System.Drawing.Point(9, 53)
        Me.NroNotaLbl.Name = "NroNotaLbl"
        Me.NroNotaLbl.Size = New System.Drawing.Size(95, 15)
        Me.NroNotaLbl.TabIndex = 1
        Me.NroNotaLbl.Text = "Número de Nota"
        '
        'AccionCMB
        '
        Me.AccionCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AccionCMB.FormattingEnabled = True
        Me.AccionCMB.Location = New System.Drawing.Point(114, 16)
        Me.AccionCMB.Name = "AccionCMB"
        Me.AccionCMB.Size = New System.Drawing.Size(136, 23)
        Me.AccionCMB.TabIndex = 0
        '
        'NroNotaTxt
        '
        Me.NroNotaTxt.Location = New System.Drawing.Point(114, 50)
        Me.NroNotaTxt.Name = "NroNotaTxt"
        Me.NroNotaTxt.Size = New System.Drawing.Size(136, 23)
        Me.NroNotaTxt.TabIndex = 1
        '
        'NotaGB
        '
        Me.NotaGB.Controls.Add(Me.NotaVentaDG)
        Me.NotaGB.Location = New System.Drawing.Point(12, 94)
        Me.NotaGB.Name = "NotaGB"
        Me.NotaGB.Size = New System.Drawing.Size(334, 173)
        Me.NotaGB.TabIndex = 47
        Me.NotaGB.TabStop = False
        Me.NotaGB.Text = "Notas de Ventas"
        '
        'NotaVentaDG
        '
        Me.NotaVentaDG.AllowUserToAddRows = False
        Me.NotaVentaDG.AllowUserToDeleteRows = False
        Me.NotaVentaDG.AllowUserToResizeColumns = False
        Me.NotaVentaDG.AllowUserToResizeRows = False
        Me.NotaVentaDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NotaVentaDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroNotaCAB, Me.FechaCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NotaVentaDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.NotaVentaDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotaVentaDG.Location = New System.Drawing.Point(3, 19)
        Me.NotaVentaDG.MultiSelect = False
        Me.NotaVentaDG.Name = "NotaVentaDG"
        Me.NotaVentaDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NotaVentaDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.NotaVentaDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.NotaVentaDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.NotaVentaDG.Size = New System.Drawing.Size(328, 151)
        Me.NotaVentaDG.StandardTab = True
        Me.NotaVentaDG.TabIndex = 3
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
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(182, 273)
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
        Me.AceptarBtn.Location = New System.Drawing.Point(94, 273)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 4
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarBtn.Location = New System.Drawing.Point(257, 45)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(89, 30)
        Me.BuscarBtn.TabIndex = 2
        Me.BuscarBtn.Text = "&Buscar"
        Me.BuscarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarBtn.UseVisualStyleBackColor = True
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
        'GestionNV
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
        Me.Name = "GestionNV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NotaGB.ResumeLayout(False)
        CType(Me.NotaVentaDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AccionLbl As System.Windows.Forms.Label
    Friend WithEvents NroNotaLbl As System.Windows.Forms.Label
    Friend WithEvents AccionCMB As System.Windows.Forms.ComboBox
    Friend WithEvents NroNotaTxt As System.Windows.Forms.TextBox
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents NotaGB As System.Windows.Forms.GroupBox
    Friend WithEvents NotaVentaDG As System.Windows.Forms.DataGridView
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents NroNotaCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
End Class
