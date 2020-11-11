<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Backup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Backup))
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.DestinoLbl = New System.Windows.Forms.Label()
        Me.VolumenLbl = New System.Windows.Forms.Label()
        Me.VolumenNUD = New System.Windows.Forms.NumericUpDown()
        Me.RutaTxt = New System.Windows.Forms.TextBox()
        Me.AbrirFD = New System.Windows.Forms.FolderBrowserDialog()
        Me.BackupGB = New System.Windows.Forms.GroupBox()
        Me.ReContraseñaZipTxt = New System.Windows.Forms.TextBox()
        Me.ContraseñaZipTxt = New System.Windows.Forms.TextBox()
        Me.NombreZipTxt = New System.Windows.Forms.TextBox()
        Me.ReContraseñaZipLbl = New System.Windows.Forms.Label()
        Me.ContraseñaZipLbl = New System.Windows.Forms.Label()
        Me.NombreZipLbl = New System.Windows.Forms.Label()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.VolumenNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BackupGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(83, 236)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 6
        Me.AceptarBtn.Text = "&Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.folder_database
        Me.BuscarBtn.Location = New System.Drawing.Point(277, 27)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(29, 24)
        Me.BuscarBtn.TabIndex = 1
        Me.BuscarBtn.UseVisualStyleBackColor = True
        '
        'DestinoLbl
        '
        Me.DestinoLbl.AutoSize = True
        Me.DestinoLbl.Location = New System.Drawing.Point(12, 30)
        Me.DestinoLbl.Name = "DestinoLbl"
        Me.DestinoLbl.Size = New System.Drawing.Size(48, 15)
        Me.DestinoLbl.TabIndex = 2
        Me.DestinoLbl.Text = "Destino"
        '
        'VolumenLbl
        '
        Me.VolumenLbl.AutoSize = True
        Me.VolumenLbl.Location = New System.Drawing.Point(12, 180)
        Me.VolumenLbl.Name = "VolumenLbl"
        Me.VolumenLbl.Size = New System.Drawing.Size(42, 15)
        Me.VolumenLbl.TabIndex = 3
        Me.VolumenLbl.Text = "Partes"
        '
        'VolumenNUD
        '
        Me.VolumenNUD.Location = New System.Drawing.Point(60, 178)
        Me.VolumenNUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.VolumenNUD.Name = "VolumenNUD"
        Me.VolumenNUD.Size = New System.Drawing.Size(46, 23)
        Me.VolumenNUD.TabIndex = 5
        Me.VolumenNUD.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'RutaTxt
        '
        Me.RutaTxt.Location = New System.Drawing.Point(95, 27)
        Me.RutaTxt.Name = "RutaTxt"
        Me.RutaTxt.ReadOnly = True
        Me.RutaTxt.Size = New System.Drawing.Size(176, 23)
        Me.RutaTxt.TabIndex = 0
        '
        'BackupGB
        '
        Me.BackupGB.Controls.Add(Me.ReContraseñaZipTxt)
        Me.BackupGB.Controls.Add(Me.ContraseñaZipTxt)
        Me.BackupGB.Controls.Add(Me.NombreZipTxt)
        Me.BackupGB.Controls.Add(Me.ReContraseñaZipLbl)
        Me.BackupGB.Controls.Add(Me.ContraseñaZipLbl)
        Me.BackupGB.Controls.Add(Me.NombreZipLbl)
        Me.BackupGB.Controls.Add(Me.RutaTxt)
        Me.BackupGB.Controls.Add(Me.VolumenNUD)
        Me.BackupGB.Controls.Add(Me.BuscarBtn)
        Me.BackupGB.Controls.Add(Me.VolumenLbl)
        Me.BackupGB.Controls.Add(Me.DestinoLbl)
        Me.BackupGB.Location = New System.Drawing.Point(12, 12)
        Me.BackupGB.Name = "BackupGB"
        Me.BackupGB.Size = New System.Drawing.Size(312, 218)
        Me.BackupGB.TabIndex = 0
        Me.BackupGB.TabStop = False
        Me.BackupGB.Text = "Copia de Seguridad"
        '
        'ReContraseñaZipTxt
        '
        Me.ReContraseñaZipTxt.Location = New System.Drawing.Point(154, 141)
        Me.ReContraseñaZipTxt.Name = "ReContraseñaZipTxt"
        Me.ReContraseñaZipTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ReContraseñaZipTxt.Size = New System.Drawing.Size(117, 23)
        Me.ReContraseñaZipTxt.TabIndex = 4
        '
        'ContraseñaZipTxt
        '
        Me.ContraseñaZipTxt.Location = New System.Drawing.Point(109, 104)
        Me.ContraseñaZipTxt.Name = "ContraseñaZipTxt"
        Me.ContraseñaZipTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ContraseñaZipTxt.Size = New System.Drawing.Size(162, 23)
        Me.ContraseñaZipTxt.TabIndex = 3
        '
        'NombreZipTxt
        '
        Me.NombreZipTxt.Location = New System.Drawing.Point(109, 65)
        Me.NombreZipTxt.Name = "NombreZipTxt"
        Me.NombreZipTxt.Size = New System.Drawing.Size(162, 23)
        Me.NombreZipTxt.TabIndex = 2
        '
        'ReContraseñaZipLbl
        '
        Me.ReContraseñaZipLbl.AutoSize = True
        Me.ReContraseñaZipLbl.Location = New System.Drawing.Point(12, 144)
        Me.ReContraseñaZipLbl.Name = "ReContraseñaZipLbl"
        Me.ReContraseñaZipLbl.Size = New System.Drawing.Size(136, 15)
        Me.ReContraseñaZipLbl.TabIndex = 8
        Me.ReContraseñaZipLbl.Text = "Re-Ingresar Contraseña"
        '
        'ContraseñaZipLbl
        '
        Me.ContraseñaZipLbl.AutoSize = True
        Me.ContraseñaZipLbl.Location = New System.Drawing.Point(12, 107)
        Me.ContraseñaZipLbl.Name = "ContraseñaZipLbl"
        Me.ContraseñaZipLbl.Size = New System.Drawing.Size(90, 15)
        Me.ContraseñaZipLbl.TabIndex = 7
        Me.ContraseñaZipLbl.Text = "Contraseña ZIP"
        '
        'NombreZipLbl
        '
        Me.NombreZipLbl.AutoSize = True
        Me.NombreZipLbl.Location = New System.Drawing.Point(12, 68)
        Me.NombreZipLbl.Name = "NombreZipLbl"
        Me.NombreZipLbl.Size = New System.Drawing.Size(90, 15)
        Me.NombreZipLbl.TabIndex = 6
        Me.NombreZipLbl.Text = "Nombre del ZIP"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(171, 236)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 7
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
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
        'ErrorP
        '
        Me.ErrorP.BlinkRate = 150
        Me.ErrorP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorP.ContainerControl = Me
        Me.ErrorP.Icon = CType(resources.GetObject("ErrorP.Icon"), System.Drawing.Icon)
        '
        'Backup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(336, 269)
        Me.Controls.Add(Me.BackupGB)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(342, 298)
        Me.MinimumSize = New System.Drawing.Size(342, 298)
        Me.Name = "Backup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.VolumenNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BackupGB.ResumeLayout(False)
        Me.BackupGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents DestinoLbl As System.Windows.Forms.Label
    Friend WithEvents VolumenLbl As System.Windows.Forms.Label
    Friend WithEvents VolumenNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents RutaTxt As System.Windows.Forms.TextBox
    Friend WithEvents AbrirFD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BackupGB As System.Windows.Forms.GroupBox
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents ReContraseñaZipLbl As System.Windows.Forms.Label
    Friend WithEvents ContraseñaZipLbl As System.Windows.Forms.Label
    Friend WithEvents NombreZipLbl As System.Windows.Forms.Label
    Friend WithEvents ReContraseñaZipTxt As System.Windows.Forms.TextBox
    Friend WithEvents ContraseñaZipTxt As System.Windows.Forms.TextBox
    Friend WithEvents NombreZipTxt As System.Windows.Forms.TextBox
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
End Class
