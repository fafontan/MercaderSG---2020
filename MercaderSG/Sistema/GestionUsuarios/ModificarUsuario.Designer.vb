<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarUsuario))
        Me.UsuarioLbl = New System.Windows.Forms.Label()
        Me.UsuarioTxt = New System.Windows.Forms.TextBox()
        Me.DatosPersonalesGB = New System.Windows.Forms.GroupBox()
        Me.FechaNacDTP = New System.Windows.Forms.DateTimePicker()
        Me.FechaNacLbl = New System.Windows.Forms.Label()
        Me.ApellidoTxt = New System.Windows.Forms.TextBox()
        Me.TelefonosGB = New System.Windows.Forms.GroupBox()
        Me.TelefonosDG = New System.Windows.Forms.DataGridView()
        Me.TelefonoCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreTxt = New System.Windows.Forms.TextBox()
        Me.ApellidoLbl = New System.Windows.Forms.Label()
        Me.NombreLbl = New System.Windows.Forms.Label()
        Me.IdiomaCMB = New System.Windows.Forms.ComboBox()
        Me.IdiomaLbl = New System.Windows.Forms.Label()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.UsuarioGB = New System.Windows.Forms.GroupBox()
        Me.CorreoElectronicoTxt = New System.Windows.Forms.TextBox()
        Me.CorreoElectronicoLbl = New System.Windows.Forms.Label()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DatosPersonalesGB.SuspendLayout()
        Me.TelefonosGB.SuspendLayout()
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UsuarioGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsuarioLbl
        '
        Me.UsuarioLbl.AutoSize = True
        Me.UsuarioLbl.Location = New System.Drawing.Point(13, 25)
        Me.UsuarioLbl.Name = "UsuarioLbl"
        Me.UsuarioLbl.Size = New System.Drawing.Size(113, 15)
        Me.UsuarioLbl.TabIndex = 0
        Me.UsuarioLbl.Text = "Nombre de Usuario"
        '
        'UsuarioTxt
        '
        Me.UsuarioTxt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsuarioTxt.Location = New System.Drawing.Point(125, 22)
        Me.UsuarioTxt.Name = "UsuarioTxt"
        Me.UsuarioTxt.ReadOnly = True
        Me.UsuarioTxt.Size = New System.Drawing.Size(116, 23)
        Me.UsuarioTxt.TabIndex = 0
        Me.UsuarioTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DatosPersonalesGB
        '
        Me.DatosPersonalesGB.Controls.Add(Me.FechaNacDTP)
        Me.DatosPersonalesGB.Controls.Add(Me.FechaNacLbl)
        Me.DatosPersonalesGB.Controls.Add(Me.ApellidoTxt)
        Me.DatosPersonalesGB.Controls.Add(Me.TelefonosGB)
        Me.DatosPersonalesGB.Controls.Add(Me.NombreTxt)
        Me.DatosPersonalesGB.Controls.Add(Me.ApellidoLbl)
        Me.DatosPersonalesGB.Controls.Add(Me.NombreLbl)
        Me.DatosPersonalesGB.Location = New System.Drawing.Point(12, 136)
        Me.DatosPersonalesGB.Name = "DatosPersonalesGB"
        Me.DatosPersonalesGB.Size = New System.Drawing.Size(263, 275)
        Me.DatosPersonalesGB.TabIndex = 2
        Me.DatosPersonalesGB.TabStop = False
        Me.DatosPersonalesGB.Text = "Datos Personales"
        '
        'FechaNacDTP
        '
        Me.FechaNacDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaNacDTP.Location = New System.Drawing.Point(140, 83)
        Me.FechaNacDTP.Name = "FechaNacDTP"
        Me.FechaNacDTP.Size = New System.Drawing.Size(101, 23)
        Me.FechaNacDTP.TabIndex = 5
        Me.FechaNacDTP.Value = New Date(2013, 7, 22, 0, 0, 0, 0)
        '
        'FechaNacLbl
        '
        Me.FechaNacLbl.AutoSize = True
        Me.FechaNacLbl.Location = New System.Drawing.Point(13, 89)
        Me.FechaNacLbl.Name = "FechaNacLbl"
        Me.FechaNacLbl.Size = New System.Drawing.Size(121, 15)
        Me.FechaNacLbl.TabIndex = 33
        Me.FechaNacLbl.Text = "Fecha de Nacimiento"
        '
        'ApellidoTxt
        '
        Me.ApellidoTxt.Location = New System.Drawing.Point(86, 25)
        Me.ApellidoTxt.Name = "ApellidoTxt"
        Me.ApellidoTxt.Size = New System.Drawing.Size(155, 23)
        Me.ApellidoTxt.TabIndex = 3
        '
        'TelefonosGB
        '
        Me.TelefonosGB.Controls.Add(Me.TelefonosDG)
        Me.TelefonosGB.Location = New System.Drawing.Point(6, 122)
        Me.TelefonosGB.Name = "TelefonosGB"
        Me.TelefonosGB.Size = New System.Drawing.Size(250, 145)
        Me.TelefonosGB.TabIndex = 17
        Me.TelefonosGB.TabStop = False
        Me.TelefonosGB.Text = "Telefonos"
        '
        'TelefonosDG
        '
        Me.TelefonosDG.AllowUserToAddRows = False
        Me.TelefonosDG.AllowUserToDeleteRows = False
        Me.TelefonosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TelefonosDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TelefonoCAB, Me.UsuarioCAB, Me.NumeroCAB})
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
        Me.TelefonosDG.Size = New System.Drawing.Size(244, 123)
        Me.TelefonosDG.TabIndex = 6
        '
        'TelefonoCAB
        '
        Me.TelefonoCAB.DataPropertyName = "CodTel"
        Me.TelefonoCAB.HeaderText = "C.Teléfono"
        Me.TelefonoCAB.Name = "TelefonoCAB"
        Me.TelefonoCAB.Width = 75
        '
        'UsuarioCAB
        '
        Me.UsuarioCAB.DataPropertyName = "CodEn"
        Me.UsuarioCAB.HeaderText = "C.Usuario"
        Me.UsuarioCAB.Name = "UsuarioCAB"
        Me.UsuarioCAB.Visible = False
        '
        'NumeroCAB
        '
        Me.NumeroCAB.DataPropertyName = "Numero"
        Me.NumeroCAB.HeaderText = "Número"
        Me.NumeroCAB.Name = "NumeroCAB"
        Me.NumeroCAB.Width = 105
        '
        'NombreTxt
        '
        Me.NombreTxt.Location = New System.Drawing.Point(86, 54)
        Me.NombreTxt.Name = "NombreTxt"
        Me.NombreTxt.Size = New System.Drawing.Size(155, 23)
        Me.NombreTxt.TabIndex = 4
        '
        'ApellidoLbl
        '
        Me.ApellidoLbl.AutoSize = True
        Me.ApellidoLbl.Location = New System.Drawing.Point(13, 28)
        Me.ApellidoLbl.Name = "ApellidoLbl"
        Me.ApellidoLbl.Size = New System.Drawing.Size(53, 15)
        Me.ApellidoLbl.TabIndex = 28
        Me.ApellidoLbl.Text = "Apellido"
        '
        'NombreLbl
        '
        Me.NombreLbl.AutoSize = True
        Me.NombreLbl.Location = New System.Drawing.Point(13, 57)
        Me.NombreLbl.Name = "NombreLbl"
        Me.NombreLbl.Size = New System.Drawing.Size(50, 15)
        Me.NombreLbl.TabIndex = 29
        Me.NombreLbl.Text = "Nombre"
        '
        'IdiomaCMB
        '
        Me.IdiomaCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IdiomaCMB.FormattingEnabled = True
        Me.IdiomaCMB.Location = New System.Drawing.Point(75, 81)
        Me.IdiomaCMB.Name = "IdiomaCMB"
        Me.IdiomaCMB.Size = New System.Drawing.Size(59, 23)
        Me.IdiomaCMB.TabIndex = 2
        '
        'IdiomaLbl
        '
        Me.IdiomaLbl.AutoSize = True
        Me.IdiomaLbl.Location = New System.Drawing.Point(13, 84)
        Me.IdiomaLbl.Name = "IdiomaLbl"
        Me.IdiomaLbl.Size = New System.Drawing.Size(46, 15)
        Me.IdiomaLbl.TabIndex = 34
        Me.IdiomaLbl.Text = "Idioma"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(143, 417)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 8
        Me.CancelarBtn.Text = "&Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(55, 417)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 7
        Me.AceptarBtn.Text = "&Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'UsuarioGB
        '
        Me.UsuarioGB.Controls.Add(Me.CorreoElectronicoTxt)
        Me.UsuarioGB.Controls.Add(Me.CorreoElectronicoLbl)
        Me.UsuarioGB.Controls.Add(Me.IdiomaCMB)
        Me.UsuarioGB.Controls.Add(Me.IdiomaLbl)
        Me.UsuarioGB.Controls.Add(Me.UsuarioTxt)
        Me.UsuarioGB.Controls.Add(Me.UsuarioLbl)
        Me.UsuarioGB.Location = New System.Drawing.Point(12, 12)
        Me.UsuarioGB.Name = "UsuarioGB"
        Me.UsuarioGB.Size = New System.Drawing.Size(263, 118)
        Me.UsuarioGB.TabIndex = 32
        Me.UsuarioGB.TabStop = False
        Me.UsuarioGB.Text = "Usuario"
        '
        'CorreoElectronicoTxt
        '
        Me.CorreoElectronicoTxt.Location = New System.Drawing.Point(125, 52)
        Me.CorreoElectronicoTxt.Name = "CorreoElectronicoTxt"
        Me.CorreoElectronicoTxt.Size = New System.Drawing.Size(116, 23)
        Me.CorreoElectronicoTxt.TabIndex = 1
        '
        'CorreoElectronicoLbl
        '
        Me.CorreoElectronicoLbl.AutoSize = True
        Me.CorreoElectronicoLbl.Location = New System.Drawing.Point(13, 55)
        Me.CorreoElectronicoLbl.Name = "CorreoElectronicoLbl"
        Me.CorreoElectronicoLbl.Size = New System.Drawing.Size(109, 15)
        Me.CorreoElectronicoLbl.TabIndex = 37
        Me.CorreoElectronicoLbl.Text = "Correo Electronico"
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
        'ErrorP
        '
        Me.ErrorP.BlinkRate = 150
        Me.ErrorP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorP.ContainerControl = Me
        Me.ErrorP.Icon = CType(resources.GetObject("ErrorP.Icon"), System.Drawing.Icon)
        '
        'ModificarUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(287, 447)
        Me.Controls.Add(Me.UsuarioGB)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.DatosPersonalesGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(293, 476)
        Me.MinimumSize = New System.Drawing.Size(293, 476)
        Me.Name = "ModificarUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.DatosPersonalesGB.ResumeLayout(False)
        Me.DatosPersonalesGB.PerformLayout()
        Me.TelefonosGB.ResumeLayout(False)
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UsuarioGB.ResumeLayout(False)
        Me.UsuarioGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UsuarioLbl As System.Windows.Forms.Label
    Friend WithEvents UsuarioTxt As System.Windows.Forms.TextBox
    Friend WithEvents DatosPersonalesGB As System.Windows.Forms.GroupBox
    Friend WithEvents NombreTxt As System.Windows.Forms.TextBox
    Friend WithEvents ApellidoTxt As System.Windows.Forms.TextBox
    Friend WithEvents ApellidoLbl As System.Windows.Forms.Label
    Friend WithEvents NombreLbl As System.Windows.Forms.Label
    Friend WithEvents IdiomaCMB As System.Windows.Forms.ComboBox
    Friend WithEvents IdiomaLbl As System.Windows.Forms.Label
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents TelefonosGB As System.Windows.Forms.GroupBox
    Friend WithEvents TelefonosDG As System.Windows.Forms.DataGridView
    Friend WithEvents UsuarioGB As System.Windows.Forms.GroupBox
    Friend WithEvents CorreoElectronicoTxt As System.Windows.Forms.TextBox
    Friend WithEvents CorreoElectronicoLbl As System.Windows.Forms.Label
    Friend WithEvents TelefonoCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaNacDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents FechaNacLbl As System.Windows.Forms.Label
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
End Class
