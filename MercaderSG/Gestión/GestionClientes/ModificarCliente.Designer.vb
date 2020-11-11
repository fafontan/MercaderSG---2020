<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarCliente))
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.DomicilioGB = New System.Windows.Forms.GroupBox()
        Me.DepartamentoLbl = New System.Windows.Forms.Label()
        Me.DepartamentoTxt = New System.Windows.Forms.TextBox()
        Me.AgregarLocBtn = New System.Windows.Forms.Button()
        Me.CalleLbl = New System.Windows.Forms.Label()
        Me.NumeroLbl = New System.Windows.Forms.Label()
        Me.LocalidadCMB = New System.Windows.Forms.ComboBox()
        Me.PisoLbl = New System.Windows.Forms.Label()
        Me.PisoTxt = New System.Windows.Forms.TextBox()
        Me.LocalidadLbl = New System.Windows.Forms.Label()
        Me.CalleTxt = New System.Windows.Forms.TextBox()
        Me.NumeroTxt = New System.Windows.Forms.TextBox()
        Me.DatosGB = New System.Windows.Forms.GroupBox()
        Me.CuitTxt = New System.Windows.Forms.TextBox()
        Me.RazonSocialTxt = New System.Windows.Forms.TextBox()
        Me.RazonSocialLbl = New System.Windows.Forms.Label()
        Me.CuitLbl = New System.Windows.Forms.Label()
        Me.TelefonosGB = New System.Windows.Forms.GroupBox()
        Me.TelefonosDG = New System.Windows.Forms.DataGridView()
        Me.TelefonoCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.DomicilioGB.SuspendLayout()
        Me.DatosGB.SuspendLayout()
        Me.TelefonosGB.SuspendLayout()
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(142, 469)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 13
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(54, 469)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 12
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'DomicilioGB
        '
        Me.DomicilioGB.Controls.Add(Me.DepartamentoLbl)
        Me.DomicilioGB.Controls.Add(Me.DepartamentoTxt)
        Me.DomicilioGB.Controls.Add(Me.AgregarLocBtn)
        Me.DomicilioGB.Controls.Add(Me.CalleLbl)
        Me.DomicilioGB.Controls.Add(Me.NumeroLbl)
        Me.DomicilioGB.Controls.Add(Me.LocalidadCMB)
        Me.DomicilioGB.Controls.Add(Me.PisoLbl)
        Me.DomicilioGB.Controls.Add(Me.PisoTxt)
        Me.DomicilioGB.Controls.Add(Me.LocalidadLbl)
        Me.DomicilioGB.Controls.Add(Me.CalleTxt)
        Me.DomicilioGB.Controls.Add(Me.NumeroTxt)
        Me.DomicilioGB.Location = New System.Drawing.Point(12, 107)
        Me.DomicilioGB.Name = "DomicilioGB"
        Me.DomicilioGB.Size = New System.Drawing.Size(255, 180)
        Me.DomicilioGB.TabIndex = 3
        Me.DomicilioGB.TabStop = False
        Me.DomicilioGB.Text = "Domicilio"
        '
        'DepartamentoLbl
        '
        Me.DepartamentoLbl.AutoSize = True
        Me.DepartamentoLbl.Location = New System.Drawing.Point(12, 147)
        Me.DepartamentoLbl.Name = "DepartamentoLbl"
        Me.DepartamentoLbl.Size = New System.Drawing.Size(85, 15)
        Me.DepartamentoLbl.TabIndex = 16
        Me.DepartamentoLbl.Text = "Departamento"
        '
        'DepartamentoTxt
        '
        Me.DepartamentoTxt.Location = New System.Drawing.Point(103, 144)
        Me.DepartamentoTxt.Name = "DepartamentoTxt"
        Me.DepartamentoTxt.Size = New System.Drawing.Size(58, 23)
        Me.DepartamentoTxt.TabIndex = 9
        '
        'AgregarLocBtn
        '
        Me.AgregarLocBtn.Location = New System.Drawing.Point(197, 23)
        Me.AgregarLocBtn.Name = "AgregarLocBtn"
        Me.AgregarLocBtn.Size = New System.Drawing.Size(29, 23)
        Me.AgregarLocBtn.TabIndex = 5
        Me.AgregarLocBtn.Text = "+"
        Me.AgregarLocBtn.UseVisualStyleBackColor = True
        '
        'CalleLbl
        '
        Me.CalleLbl.AutoSize = True
        Me.CalleLbl.Location = New System.Drawing.Point(13, 60)
        Me.CalleLbl.Name = "CalleLbl"
        Me.CalleLbl.Size = New System.Drawing.Size(35, 15)
        Me.CalleLbl.TabIndex = 3
        Me.CalleLbl.Text = "Calle"
        '
        'NumeroLbl
        '
        Me.NumeroLbl.AutoSize = True
        Me.NumeroLbl.Location = New System.Drawing.Point(12, 90)
        Me.NumeroLbl.Name = "NumeroLbl"
        Me.NumeroLbl.Size = New System.Drawing.Size(50, 15)
        Me.NumeroLbl.TabIndex = 4
        Me.NumeroLbl.Text = "Numero"
        '
        'LocalidadCMB
        '
        Me.LocalidadCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LocalidadCMB.FormattingEnabled = True
        Me.LocalidadCMB.Location = New System.Drawing.Point(80, 23)
        Me.LocalidadCMB.Name = "LocalidadCMB"
        Me.LocalidadCMB.Size = New System.Drawing.Size(100, 23)
        Me.LocalidadCMB.TabIndex = 4
        '
        'PisoLbl
        '
        Me.PisoLbl.AutoSize = True
        Me.PisoLbl.Location = New System.Drawing.Point(12, 118)
        Me.PisoLbl.Name = "PisoLbl"
        Me.PisoLbl.Size = New System.Drawing.Size(31, 15)
        Me.PisoLbl.TabIndex = 5
        Me.PisoLbl.Text = "Piso"
        '
        'PisoTxt
        '
        Me.PisoTxt.Location = New System.Drawing.Point(70, 115)
        Me.PisoTxt.Name = "PisoTxt"
        Me.PisoTxt.Size = New System.Drawing.Size(58, 23)
        Me.PisoTxt.TabIndex = 8
        '
        'LocalidadLbl
        '
        Me.LocalidadLbl.AutoSize = True
        Me.LocalidadLbl.Location = New System.Drawing.Point(13, 26)
        Me.LocalidadLbl.Name = "LocalidadLbl"
        Me.LocalidadLbl.Size = New System.Drawing.Size(61, 15)
        Me.LocalidadLbl.TabIndex = 13
        Me.LocalidadLbl.Text = "Localidad"
        '
        'CalleTxt
        '
        Me.CalleTxt.Location = New System.Drawing.Point(70, 57)
        Me.CalleTxt.Name = "CalleTxt"
        Me.CalleTxt.Size = New System.Drawing.Size(100, 23)
        Me.CalleTxt.TabIndex = 6
        '
        'NumeroTxt
        '
        Me.NumeroTxt.Location = New System.Drawing.Point(70, 86)
        Me.NumeroTxt.Name = "NumeroTxt"
        Me.NumeroTxt.Size = New System.Drawing.Size(58, 23)
        Me.NumeroTxt.TabIndex = 7
        '
        'DatosGB
        '
        Me.DatosGB.Controls.Add(Me.CuitTxt)
        Me.DatosGB.Controls.Add(Me.RazonSocialTxt)
        Me.DatosGB.Controls.Add(Me.RazonSocialLbl)
        Me.DatosGB.Controls.Add(Me.CuitLbl)
        Me.DatosGB.Location = New System.Drawing.Point(12, 12)
        Me.DatosGB.Name = "DatosGB"
        Me.DatosGB.Size = New System.Drawing.Size(255, 89)
        Me.DatosGB.TabIndex = 0
        Me.DatosGB.TabStop = False
        Me.DatosGB.Text = "Datos de la Empresa"
        '
        'CuitTxt
        '
        Me.CuitTxt.Location = New System.Drawing.Point(114, 51)
        Me.CuitTxt.Name = "CuitTxt"
        Me.CuitTxt.ReadOnly = True
        Me.CuitTxt.Size = New System.Drawing.Size(121, 23)
        Me.CuitTxt.TabIndex = 2
        '
        'RazonSocialTxt
        '
        Me.RazonSocialTxt.Location = New System.Drawing.Point(114, 22)
        Me.RazonSocialTxt.Name = "RazonSocialTxt"
        Me.RazonSocialTxt.Size = New System.Drawing.Size(121, 23)
        Me.RazonSocialTxt.TabIndex = 1
        '
        'RazonSocialLbl
        '
        Me.RazonSocialLbl.AutoSize = True
        Me.RazonSocialLbl.Location = New System.Drawing.Point(18, 25)
        Me.RazonSocialLbl.Name = "RazonSocialLbl"
        Me.RazonSocialLbl.Size = New System.Drawing.Size(77, 15)
        Me.RazonSocialLbl.TabIndex = 0
        Me.RazonSocialLbl.Text = "Razon Social"
        '
        'CuitLbl
        '
        Me.CuitLbl.AutoSize = True
        Me.CuitLbl.Location = New System.Drawing.Point(18, 54)
        Me.CuitLbl.Name = "CuitLbl"
        Me.CuitLbl.Size = New System.Drawing.Size(32, 15)
        Me.CuitLbl.TabIndex = 2
        Me.CuitLbl.Text = "CUIT"
        '
        'TelefonosGB
        '
        Me.TelefonosGB.Controls.Add(Me.TelefonosDG)
        Me.TelefonosGB.Location = New System.Drawing.Point(12, 293)
        Me.TelefonosGB.Name = "TelefonosGB"
        Me.TelefonosGB.Size = New System.Drawing.Size(255, 170)
        Me.TelefonosGB.TabIndex = 10
        Me.TelefonosGB.TabStop = False
        Me.TelefonosGB.Text = "Telefonos"
        '
        'TelefonosDG
        '
        Me.TelefonosDG.AllowUserToAddRows = False
        Me.TelefonosDG.AllowUserToDeleteRows = False
        Me.TelefonosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TelefonosDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TelefonoCAB, Me.ClienteCAB, Me.NumeroCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TelefonosDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.TelefonosDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TelefonosDG.Location = New System.Drawing.Point(3, 19)
        Me.TelefonosDG.Name = "TelefonosDG"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TelefonosDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.TelefonosDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TelefonosDG.Size = New System.Drawing.Size(249, 148)
        Me.TelefonosDG.TabIndex = 11
        '
        'TelefonoCAB
        '
        Me.TelefonoCAB.DataPropertyName = "CodTel"
        Me.TelefonoCAB.HeaderText = "C.Teléfono"
        Me.TelefonoCAB.Name = "TelefonoCAB"
        Me.TelefonoCAB.Width = 75
        '
        'ClienteCAB
        '
        Me.ClienteCAB.DataPropertyName = "CodEn"
        Me.ClienteCAB.HeaderText = "C.Cliente"
        Me.ClienteCAB.Name = "ClienteCAB"
        Me.ClienteCAB.Visible = False
        '
        'NumeroCAB
        '
        Me.NumeroCAB.DataPropertyName = "Numero"
        Me.NumeroCAB.HeaderText = "Número"
        Me.NumeroCAB.Name = "NumeroCAB"
        Me.NumeroCAB.Width = 117
        '
        'ErrorP
        '
        Me.ErrorP.BlinkRate = 150
        Me.ErrorP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorP.ContainerControl = Me
        Me.ErrorP.Icon = CType(resources.GetObject("ErrorP.Icon"), System.Drawing.Icon)
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
        'ModificarCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(279, 503)
        Me.Controls.Add(Me.TelefonosGB)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.DomicilioGB)
        Me.Controls.Add(Me.DatosGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(285, 532)
        Me.MinimumSize = New System.Drawing.Size(285, 532)
        Me.Name = "ModificarCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Cliente - MercaderSG"
        Me.DomicilioGB.ResumeLayout(False)
        Me.DomicilioGB.PerformLayout()
        Me.DatosGB.ResumeLayout(False)
        Me.DatosGB.PerformLayout()
        Me.TelefonosGB.ResumeLayout(False)
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents DomicilioGB As System.Windows.Forms.GroupBox
    Friend WithEvents DepartamentoLbl As System.Windows.Forms.Label
    Friend WithEvents DepartamentoTxt As System.Windows.Forms.TextBox
    Friend WithEvents AgregarLocBtn As System.Windows.Forms.Button
    Friend WithEvents CalleLbl As System.Windows.Forms.Label
    Friend WithEvents NumeroLbl As System.Windows.Forms.Label
    Friend WithEvents LocalidadCMB As System.Windows.Forms.ComboBox
    Friend WithEvents PisoLbl As System.Windows.Forms.Label
    Friend WithEvents PisoTxt As System.Windows.Forms.TextBox
    Friend WithEvents LocalidadLbl As System.Windows.Forms.Label
    Friend WithEvents CalleTxt As System.Windows.Forms.TextBox
    Friend WithEvents NumeroTxt As System.Windows.Forms.TextBox
    Friend WithEvents DatosGB As System.Windows.Forms.GroupBox
    Friend WithEvents CuitTxt As System.Windows.Forms.TextBox
    Friend WithEvents TelefonosGB As System.Windows.Forms.GroupBox
    Friend WithEvents RazonSocialTxt As System.Windows.Forms.TextBox
    Friend WithEvents CuitLbl As System.Windows.Forms.Label
    Friend WithEvents RazonSocialLbl As System.Windows.Forms.Label
    Friend WithEvents TelefonosDG As System.Windows.Forms.DataGridView
    Friend WithEvents TelefonoCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClienteCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
End Class
