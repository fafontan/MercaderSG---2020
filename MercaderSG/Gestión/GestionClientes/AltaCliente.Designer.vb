<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaCliente))
        Me.DatosGB = New System.Windows.Forms.GroupBox()
        Me.CuitTxt = New System.Windows.Forms.TextBox()
        Me.TelefonosGB = New System.Windows.Forms.GroupBox()
        Me.NumeroTelLbl = New System.Windows.Forms.Label()
        Me.TelefonoTxt = New System.Windows.Forms.TextBox()
        Me.QuitarTelBtn = New System.Windows.Forms.Button()
        Me.AgregarTelBtn = New System.Windows.Forms.Button()
        Me.TelefonosDG = New System.Windows.Forms.DataGridView()
        Me.NumeroCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazonSocialTxt = New System.Windows.Forms.TextBox()
        Me.CuitLbl = New System.Windows.Forms.Label()
        Me.RazonSocialLbl = New System.Windows.Forms.Label()
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
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.DatosGB.SuspendLayout()
        Me.TelefonosGB.SuspendLayout()
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DomicilioGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatosGB
        '
        Me.DatosGB.Controls.Add(Me.CuitTxt)
        Me.DatosGB.Controls.Add(Me.TelefonosGB)
        Me.DatosGB.Controls.Add(Me.RazonSocialTxt)
        Me.DatosGB.Controls.Add(Me.CuitLbl)
        Me.DatosGB.Controls.Add(Me.RazonSocialLbl)
        Me.DatosGB.Location = New System.Drawing.Point(12, 12)
        Me.DatosGB.Name = "DatosGB"
        Me.DatosGB.Size = New System.Drawing.Size(257, 255)
        Me.DatosGB.TabIndex = 0
        Me.DatosGB.TabStop = False
        Me.DatosGB.Text = "Datos de la Empresa"
        '
        'CuitTxt
        '
        Me.CuitTxt.Location = New System.Drawing.Point(114, 55)
        Me.CuitTxt.Name = "CuitTxt"
        Me.CuitTxt.Size = New System.Drawing.Size(121, 23)
        Me.CuitTxt.TabIndex = 2
        '
        'TelefonosGB
        '
        Me.TelefonosGB.Controls.Add(Me.NumeroTelLbl)
        Me.TelefonosGB.Controls.Add(Me.TelefonoTxt)
        Me.TelefonosGB.Controls.Add(Me.QuitarTelBtn)
        Me.TelefonosGB.Controls.Add(Me.AgregarTelBtn)
        Me.TelefonosGB.Controls.Add(Me.TelefonosDG)
        Me.TelefonosGB.Location = New System.Drawing.Point(10, 84)
        Me.TelefonosGB.Name = "TelefonosGB"
        Me.TelefonosGB.Size = New System.Drawing.Size(231, 161)
        Me.TelefonosGB.TabIndex = 3
        Me.TelefonosGB.TabStop = False
        Me.TelefonosGB.Text = "Telefonos"
        '
        'NumeroTelLbl
        '
        Me.NumeroTelLbl.AutoSize = True
        Me.NumeroTelLbl.Location = New System.Drawing.Point(7, 23)
        Me.NumeroTelLbl.Name = "NumeroTelLbl"
        Me.NumeroTelLbl.Size = New System.Drawing.Size(50, 15)
        Me.NumeroTelLbl.TabIndex = 5
        Me.NumeroTelLbl.Text = "Numero"
        '
        'TelefonoTxt
        '
        Me.TelefonoTxt.Location = New System.Drawing.Point(63, 20)
        Me.TelefonoTxt.Name = "TelefonoTxt"
        Me.TelefonoTxt.Size = New System.Drawing.Size(111, 23)
        Me.TelefonoTxt.TabIndex = 4
        '
        'QuitarTelBtn
        '
        Me.QuitarTelBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitarTelBtn.Location = New System.Drawing.Point(196, 48)
        Me.QuitarTelBtn.Name = "QuitarTelBtn"
        Me.QuitarTelBtn.Size = New System.Drawing.Size(29, 23)
        Me.QuitarTelBtn.TabIndex = 6
        Me.QuitarTelBtn.Text = "-"
        Me.QuitarTelBtn.UseVisualStyleBackColor = True
        '
        'AgregarTelBtn
        '
        Me.AgregarTelBtn.Location = New System.Drawing.Point(196, 19)
        Me.AgregarTelBtn.Name = "AgregarTelBtn"
        Me.AgregarTelBtn.Size = New System.Drawing.Size(29, 23)
        Me.AgregarTelBtn.TabIndex = 5
        Me.AgregarTelBtn.Text = "+"
        Me.AgregarTelBtn.UseVisualStyleBackColor = True
        '
        'TelefonosDG
        '
        Me.TelefonosDG.AllowUserToAddRows = False
        Me.TelefonosDG.AllowUserToDeleteRows = False
        Me.TelefonosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TelefonosDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumeroCAB})
        Me.TelefonosDG.Location = New System.Drawing.Point(10, 52)
        Me.TelefonosDG.Name = "TelefonosDG"
        Me.TelefonosDG.Size = New System.Drawing.Size(176, 104)
        Me.TelefonosDG.StandardTab = True
        Me.TelefonosDG.TabIndex = 7
        '
        'NumeroCAB
        '
        Me.NumeroCAB.HeaderText = "Número"
        Me.NumeroCAB.Name = "NumeroCAB"
        '
        'RazonSocialTxt
        '
        Me.RazonSocialTxt.Location = New System.Drawing.Point(114, 26)
        Me.RazonSocialTxt.Name = "RazonSocialTxt"
        Me.RazonSocialTxt.Size = New System.Drawing.Size(121, 23)
        Me.RazonSocialTxt.TabIndex = 1
        '
        'CuitLbl
        '
        Me.CuitLbl.AutoSize = True
        Me.CuitLbl.Location = New System.Drawing.Point(16, 58)
        Me.CuitLbl.Name = "CuitLbl"
        Me.CuitLbl.Size = New System.Drawing.Size(32, 15)
        Me.CuitLbl.TabIndex = 2
        Me.CuitLbl.Text = "CUIT"
        '
        'RazonSocialLbl
        '
        Me.RazonSocialLbl.AutoSize = True
        Me.RazonSocialLbl.Location = New System.Drawing.Point(16, 29)
        Me.RazonSocialLbl.Name = "RazonSocialLbl"
        Me.RazonSocialLbl.Size = New System.Drawing.Size(77, 15)
        Me.RazonSocialLbl.TabIndex = 0
        Me.RazonSocialLbl.Text = "Razón Social"
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
        Me.DomicilioGB.Location = New System.Drawing.Point(12, 273)
        Me.DomicilioGB.Name = "DomicilioGB"
        Me.DomicilioGB.Size = New System.Drawing.Size(257, 178)
        Me.DomicilioGB.TabIndex = 8
        Me.DomicilioGB.TabStop = False
        Me.DomicilioGB.Text = "Domicilio"
        '
        'DepartamentoLbl
        '
        Me.DepartamentoLbl.AutoSize = True
        Me.DepartamentoLbl.Location = New System.Drawing.Point(23, 145)
        Me.DepartamentoLbl.Name = "DepartamentoLbl"
        Me.DepartamentoLbl.Size = New System.Drawing.Size(85, 15)
        Me.DepartamentoLbl.TabIndex = 16
        Me.DepartamentoLbl.Text = "Departamento"
        '
        'DepartamentoTxt
        '
        Me.DepartamentoTxt.Location = New System.Drawing.Point(114, 142)
        Me.DepartamentoTxt.Name = "DepartamentoTxt"
        Me.DepartamentoTxt.Size = New System.Drawing.Size(58, 23)
        Me.DepartamentoTxt.TabIndex = 14
        '
        'AgregarLocBtn
        '
        Me.AgregarLocBtn.Location = New System.Drawing.Point(200, 19)
        Me.AgregarLocBtn.Name = "AgregarLocBtn"
        Me.AgregarLocBtn.Size = New System.Drawing.Size(29, 23)
        Me.AgregarLocBtn.TabIndex = 10
        Me.AgregarLocBtn.Text = "+"
        Me.AgregarLocBtn.UseVisualStyleBackColor = True
        '
        'CalleLbl
        '
        Me.CalleLbl.AutoSize = True
        Me.CalleLbl.Location = New System.Drawing.Point(22, 58)
        Me.CalleLbl.Name = "CalleLbl"
        Me.CalleLbl.Size = New System.Drawing.Size(35, 15)
        Me.CalleLbl.TabIndex = 3
        Me.CalleLbl.Text = "Calle"
        '
        'NumeroLbl
        '
        Me.NumeroLbl.AutoSize = True
        Me.NumeroLbl.Location = New System.Drawing.Point(22, 87)
        Me.NumeroLbl.Name = "NumeroLbl"
        Me.NumeroLbl.Size = New System.Drawing.Size(50, 15)
        Me.NumeroLbl.TabIndex = 4
        Me.NumeroLbl.Text = "Numero"
        '
        'LocalidadCMB
        '
        Me.LocalidadCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LocalidadCMB.FormattingEnabled = True
        Me.LocalidadCMB.Location = New System.Drawing.Point(90, 19)
        Me.LocalidadCMB.Name = "LocalidadCMB"
        Me.LocalidadCMB.Size = New System.Drawing.Size(100, 23)
        Me.LocalidadCMB.TabIndex = 9
        '
        'PisoLbl
        '
        Me.PisoLbl.AutoSize = True
        Me.PisoLbl.Location = New System.Drawing.Point(22, 116)
        Me.PisoLbl.Name = "PisoLbl"
        Me.PisoLbl.Size = New System.Drawing.Size(31, 15)
        Me.PisoLbl.TabIndex = 5
        Me.PisoLbl.Text = "Piso"
        '
        'PisoTxt
        '
        Me.PisoTxt.Location = New System.Drawing.Point(80, 113)
        Me.PisoTxt.Name = "PisoTxt"
        Me.PisoTxt.Size = New System.Drawing.Size(58, 23)
        Me.PisoTxt.TabIndex = 13
        '
        'LocalidadLbl
        '
        Me.LocalidadLbl.AutoSize = True
        Me.LocalidadLbl.Location = New System.Drawing.Point(23, 22)
        Me.LocalidadLbl.Name = "LocalidadLbl"
        Me.LocalidadLbl.Size = New System.Drawing.Size(61, 15)
        Me.LocalidadLbl.TabIndex = 13
        Me.LocalidadLbl.Text = "Localidad"
        '
        'CalleTxt
        '
        Me.CalleTxt.Location = New System.Drawing.Point(80, 55)
        Me.CalleTxt.Name = "CalleTxt"
        Me.CalleTxt.Size = New System.Drawing.Size(110, 23)
        Me.CalleTxt.TabIndex = 11
        '
        'NumeroTxt
        '
        Me.NumeroTxt.Location = New System.Drawing.Point(80, 84)
        Me.NumeroTxt.Name = "NumeroTxt"
        Me.NumeroTxt.Size = New System.Drawing.Size(58, 23)
        Me.NumeroTxt.TabIndex = 12
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(55, 458)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 15
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(143, 458)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 16
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
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
        'MensajeTT
        '
        Me.MensajeTT.AutomaticDelay = 100
        Me.MensajeTT.AutoPopDelay = 5000
        Me.MensajeTT.InitialDelay = 1000
        Me.MensajeTT.ReshowDelay = 500
        Me.MensajeTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.MensajeTT.ToolTipTitle = "MercaderSG"
        '
        'AltaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(281, 489)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.DomicilioGB)
        Me.Controls.Add(Me.DatosGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(287, 518)
        Me.MinimumSize = New System.Drawing.Size(287, 518)
        Me.Name = "AltaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Cliente - MercaderSG"
        Me.DatosGB.ResumeLayout(False)
        Me.DatosGB.PerformLayout()
        Me.TelefonosGB.ResumeLayout(False)
        Me.TelefonosGB.PerformLayout()
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DomicilioGB.ResumeLayout(False)
        Me.DomicilioGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DatosGB As System.Windows.Forms.GroupBox
    Friend WithEvents RazonSocialTxt As System.Windows.Forms.TextBox
    Friend WithEvents CuitLbl As System.Windows.Forms.Label
    Friend WithEvents RazonSocialLbl As System.Windows.Forms.Label
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
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents TelefonosGB As System.Windows.Forms.GroupBox
    Friend WithEvents NumeroTelLbl As System.Windows.Forms.Label
    Friend WithEvents TelefonoTxt As System.Windows.Forms.TextBox
    Friend WithEvents QuitarTelBtn As System.Windows.Forms.Button
    Friend WithEvents AgregarTelBtn As System.Windows.Forms.Button
    Friend WithEvents TelefonosDG As System.Windows.Forms.DataGridView
    Friend WithEvents NumeroCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CuitTxt As System.Windows.Forms.TextBox
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
End Class
