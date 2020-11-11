<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaUsuario))
        Me.DatosGB = New System.Windows.Forms.GroupBox()
        Me.FechaNacDTP = New System.Windows.Forms.DateTimePicker()
        Me.TelefonosGB = New System.Windows.Forms.GroupBox()
        Me.NumeroLbl = New System.Windows.Forms.Label()
        Me.TelefonoTxt = New System.Windows.Forms.TextBox()
        Me.QuitarTelBtn = New System.Windows.Forms.Button()
        Me.AgregarTelBtn = New System.Windows.Forms.Button()
        Me.TelefonosDG = New System.Windows.Forms.DataGridView()
        Me.NumeroCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaNacLbl = New System.Windows.Forms.Label()
        Me.NombreTxt = New System.Windows.Forms.TextBox()
        Me.ApellidoTxt = New System.Windows.Forms.TextBox()
        Me.ApellidoLbl = New System.Windows.Forms.Label()
        Me.NombreLbl = New System.Windows.Forms.Label()
        Me.UsuarioGB = New System.Windows.Forms.GroupBox()
        Me.IdiomaCMB = New System.Windows.Forms.ComboBox()
        Me.IdiomaLbl = New System.Windows.Forms.Label()
        Me.CorreoElectronicoTxt = New System.Windows.Forms.TextBox()
        Me.UsuarioTxt = New System.Windows.Forms.TextBox()
        Me.UsuarioLbl = New System.Windows.Forms.Label()
        Me.CorreoElectronicoLbl = New System.Windows.Forms.Label()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DatosGB.SuspendLayout()
        Me.TelefonosGB.SuspendLayout()
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UsuarioGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatosGB
        '
        Me.DatosGB.Controls.Add(Me.FechaNacDTP)
        Me.DatosGB.Controls.Add(Me.TelefonosGB)
        Me.DatosGB.Controls.Add(Me.FechaNacLbl)
        Me.DatosGB.Controls.Add(Me.NombreTxt)
        Me.DatosGB.Controls.Add(Me.ApellidoTxt)
        Me.DatosGB.Controls.Add(Me.ApellidoLbl)
        Me.DatosGB.Controls.Add(Me.NombreLbl)
        Me.DatosGB.Location = New System.Drawing.Point(13, 135)
        Me.DatosGB.Name = "DatosGB"
        Me.DatosGB.Size = New System.Drawing.Size(274, 289)
        Me.DatosGB.TabIndex = 6
        Me.DatosGB.TabStop = False
        Me.DatosGB.Text = "Datos Personales"
        '
        'FechaNacDTP
        '
        Me.FechaNacDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaNacDTP.Location = New System.Drawing.Point(161, 87)
        Me.FechaNacDTP.Name = "FechaNacDTP"
        Me.FechaNacDTP.Size = New System.Drawing.Size(92, 23)
        Me.FechaNacDTP.TabIndex = 5
        Me.FechaNacDTP.Value = New Date(2013, 7, 22, 0, 0, 0, 0)
        '
        'TelefonosGB
        '
        Me.TelefonosGB.Controls.Add(Me.NumeroLbl)
        Me.TelefonosGB.Controls.Add(Me.TelefonoTxt)
        Me.TelefonosGB.Controls.Add(Me.QuitarTelBtn)
        Me.TelefonosGB.Controls.Add(Me.AgregarTelBtn)
        Me.TelefonosGB.Controls.Add(Me.TelefonosDG)
        Me.TelefonosGB.Location = New System.Drawing.Point(18, 116)
        Me.TelefonosGB.Name = "TelefonosGB"
        Me.TelefonosGB.Size = New System.Drawing.Size(233, 161)
        Me.TelefonosGB.TabIndex = 26
        Me.TelefonosGB.TabStop = False
        Me.TelefonosGB.Text = "Telefonos"
        '
        'NumeroLbl
        '
        Me.NumeroLbl.AutoSize = True
        Me.NumeroLbl.Location = New System.Drawing.Point(12, 23)
        Me.NumeroLbl.Name = "NumeroLbl"
        Me.NumeroLbl.Size = New System.Drawing.Size(50, 15)
        Me.NumeroLbl.TabIndex = 5
        Me.NumeroLbl.Text = "Numero"
        '
        'TelefonoTxt
        '
        Me.TelefonoTxt.Location = New System.Drawing.Point(68, 20)
        Me.TelefonoTxt.Name = "TelefonoTxt"
        Me.TelefonoTxt.Size = New System.Drawing.Size(107, 23)
        Me.TelefonoTxt.TabIndex = 6
        '
        'QuitarTelBtn
        '
        Me.QuitarTelBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitarTelBtn.Location = New System.Drawing.Point(196, 52)
        Me.QuitarTelBtn.Name = "QuitarTelBtn"
        Me.QuitarTelBtn.Size = New System.Drawing.Size(29, 23)
        Me.QuitarTelBtn.TabIndex = 8
        Me.QuitarTelBtn.Text = "-"
        Me.QuitarTelBtn.UseVisualStyleBackColor = True
        '
        'AgregarTelBtn
        '
        Me.AgregarTelBtn.Location = New System.Drawing.Point(196, 20)
        Me.AgregarTelBtn.Name = "AgregarTelBtn"
        Me.AgregarTelBtn.Size = New System.Drawing.Size(29, 23)
        Me.AgregarTelBtn.TabIndex = 7
        Me.AgregarTelBtn.Text = "+"
        Me.AgregarTelBtn.UseVisualStyleBackColor = True
        '
        'TelefonosDG
        '
        Me.TelefonosDG.AllowUserToAddRows = False
        Me.TelefonosDG.AllowUserToDeleteRows = False
        Me.TelefonosDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TelefonosDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumeroCAB})
        Me.TelefonosDG.Location = New System.Drawing.Point(14, 52)
        Me.TelefonosDG.Name = "TelefonosDG"
        Me.TelefonosDG.Size = New System.Drawing.Size(176, 104)
        Me.TelefonosDG.StandardTab = True
        Me.TelefonosDG.TabIndex = 9
        '
        'NumeroCAB
        '
        Me.NumeroCAB.HeaderText = "Número"
        Me.NumeroCAB.Name = "NumeroCAB"
        '
        'FechaNacLbl
        '
        Me.FechaNacLbl.AutoSize = True
        Me.FechaNacLbl.Location = New System.Drawing.Point(15, 93)
        Me.FechaNacLbl.Name = "FechaNacLbl"
        Me.FechaNacLbl.Size = New System.Drawing.Size(121, 15)
        Me.FechaNacLbl.TabIndex = 23
        Me.FechaNacLbl.Text = "Fecha de Nacimiento"
        '
        'NombreTxt
        '
        Me.NombreTxt.Location = New System.Drawing.Point(97, 58)
        Me.NombreTxt.Name = "NombreTxt"
        Me.NombreTxt.Size = New System.Drawing.Size(156, 23)
        Me.NombreTxt.TabIndex = 4
        '
        'ApellidoTxt
        '
        Me.ApellidoTxt.Location = New System.Drawing.Point(96, 29)
        Me.ApellidoTxt.Name = "ApellidoTxt"
        Me.ApellidoTxt.Size = New System.Drawing.Size(157, 23)
        Me.ApellidoTxt.TabIndex = 3
        '
        'ApellidoLbl
        '
        Me.ApellidoLbl.AutoSize = True
        Me.ApellidoLbl.Location = New System.Drawing.Point(15, 29)
        Me.ApellidoLbl.Name = "ApellidoLbl"
        Me.ApellidoLbl.Size = New System.Drawing.Size(53, 15)
        Me.ApellidoLbl.TabIndex = 1
        Me.ApellidoLbl.Text = "Apellido"
        '
        'NombreLbl
        '
        Me.NombreLbl.AutoSize = True
        Me.NombreLbl.Location = New System.Drawing.Point(15, 61)
        Me.NombreLbl.Name = "NombreLbl"
        Me.NombreLbl.Size = New System.Drawing.Size(50, 15)
        Me.NombreLbl.TabIndex = 2
        Me.NombreLbl.Text = "Nombre"
        '
        'UsuarioGB
        '
        Me.UsuarioGB.Controls.Add(Me.IdiomaCMB)
        Me.UsuarioGB.Controls.Add(Me.IdiomaLbl)
        Me.UsuarioGB.Controls.Add(Me.CorreoElectronicoTxt)
        Me.UsuarioGB.Controls.Add(Me.UsuarioTxt)
        Me.UsuarioGB.Controls.Add(Me.UsuarioLbl)
        Me.UsuarioGB.Controls.Add(Me.CorreoElectronicoLbl)
        Me.UsuarioGB.Location = New System.Drawing.Point(13, 11)
        Me.UsuarioGB.Name = "UsuarioGB"
        Me.UsuarioGB.Size = New System.Drawing.Size(274, 118)
        Me.UsuarioGB.TabIndex = 1
        Me.UsuarioGB.TabStop = False
        Me.UsuarioGB.Text = "Usuario"
        '
        'IdiomaCMB
        '
        Me.IdiomaCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IdiomaCMB.FormattingEnabled = True
        Me.IdiomaCMB.Location = New System.Drawing.Point(86, 82)
        Me.IdiomaCMB.Name = "IdiomaCMB"
        Me.IdiomaCMB.Size = New System.Drawing.Size(59, 23)
        Me.IdiomaCMB.TabIndex = 2
        '
        'IdiomaLbl
        '
        Me.IdiomaLbl.AutoSize = True
        Me.IdiomaLbl.Location = New System.Drawing.Point(21, 85)
        Me.IdiomaLbl.Name = "IdiomaLbl"
        Me.IdiomaLbl.Size = New System.Drawing.Size(46, 15)
        Me.IdiomaLbl.TabIndex = 11
        Me.IdiomaLbl.Text = "Idioma"
        '
        'CorreoElectronicoTxt
        '
        Me.CorreoElectronicoTxt.Location = New System.Drawing.Point(142, 50)
        Me.CorreoElectronicoTxt.Name = "CorreoElectronicoTxt"
        Me.CorreoElectronicoTxt.Size = New System.Drawing.Size(111, 23)
        Me.CorreoElectronicoTxt.TabIndex = 1
        '
        'UsuarioTxt
        '
        Me.UsuarioTxt.Location = New System.Drawing.Point(142, 21)
        Me.UsuarioTxt.Name = "UsuarioTxt"
        Me.UsuarioTxt.Size = New System.Drawing.Size(111, 23)
        Me.UsuarioTxt.TabIndex = 0
        '
        'UsuarioLbl
        '
        Me.UsuarioLbl.AutoSize = True
        Me.UsuarioLbl.Location = New System.Drawing.Point(18, 25)
        Me.UsuarioLbl.Name = "UsuarioLbl"
        Me.UsuarioLbl.Size = New System.Drawing.Size(112, 15)
        Me.UsuarioLbl.TabIndex = 0
        Me.UsuarioLbl.Text = "Nombre de usuario"
        '
        'CorreoElectronicoLbl
        '
        Me.CorreoElectronicoLbl.AutoSize = True
        Me.CorreoElectronicoLbl.Location = New System.Drawing.Point(18, 53)
        Me.CorreoElectronicoLbl.Name = "CorreoElectronicoLbl"
        Me.CorreoElectronicoLbl.Size = New System.Drawing.Size(109, 15)
        Me.CorreoElectronicoLbl.TabIndex = 6
        Me.CorreoElectronicoLbl.Text = "Correo Electronico"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(153, 433)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 11
        Me.CancelarBtn.Text = "&Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(65, 433)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 10
        Me.AceptarBtn.Text = "&Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
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
        'AltaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(300, 467)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.DatosGB)
        Me.Controls.Add(Me.UsuarioGB)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(306, 496)
        Me.MinimumSize = New System.Drawing.Size(306, 496)
        Me.Name = "AltaUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.DatosGB.ResumeLayout(False)
        Me.DatosGB.PerformLayout()
        Me.TelefonosGB.ResumeLayout(False)
        Me.TelefonosGB.PerformLayout()
        CType(Me.TelefonosDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UsuarioGB.ResumeLayout(False)
        Me.UsuarioGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents DatosGB As System.Windows.Forms.GroupBox
    Friend WithEvents TelefonosGB As System.Windows.Forms.GroupBox
    Friend WithEvents QuitarTelBtn As System.Windows.Forms.Button
    Friend WithEvents AgregarTelBtn As System.Windows.Forms.Button
    Friend WithEvents TelefonosDG As System.Windows.Forms.DataGridView
    Friend WithEvents FechaNacLbl As System.Windows.Forms.Label
    Friend WithEvents NombreTxt As System.Windows.Forms.TextBox
    Friend WithEvents ApellidoTxt As System.Windows.Forms.TextBox
    Friend WithEvents ApellidoLbl As System.Windows.Forms.Label
    Friend WithEvents NombreLbl As System.Windows.Forms.Label
    Friend WithEvents UsuarioGB As System.Windows.Forms.GroupBox
    Friend WithEvents IdiomaCMB As System.Windows.Forms.ComboBox
    Friend WithEvents IdiomaLbl As System.Windows.Forms.Label
    Friend WithEvents CorreoElectronicoTxt As System.Windows.Forms.TextBox
    Friend WithEvents UsuarioTxt As System.Windows.Forms.TextBox
    Friend WithEvents UsuarioLbl As System.Windows.Forms.Label
    Friend WithEvents CorreoElectronicoLbl As System.Windows.Forms.Label
    Friend WithEvents FechaNacDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents NumeroLbl As System.Windows.Forms.Label
    Friend WithEvents TelefonoTxt As System.Windows.Forms.TextBox
    Friend WithEvents NumeroCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
End Class
