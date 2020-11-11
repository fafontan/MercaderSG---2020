<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Restore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Restore))
        Me.DestinoLbl = New System.Windows.Forms.Label()
        Me.BuscarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.GuardarFD = New System.Windows.Forms.OpenFileDialog()
        Me.ArchivosLB = New System.Windows.Forms.ListBox()
        Me.RestaurarGB = New System.Windows.Forms.GroupBox()
        Me.NuevoBtn = New System.Windows.Forms.Button()
        Me.ReContraseñaZipTxt = New System.Windows.Forms.TextBox()
        Me.ContraseñaZipTxt = New System.Windows.Forms.TextBox()
        Me.ReContraseñaZipLbl = New System.Windows.Forms.Label()
        Me.ContraseñaZipLbl = New System.Windows.Forms.Label()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.RestaurarGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DestinoLbl
        '
        Me.DestinoLbl.AutoSize = True
        Me.DestinoLbl.Location = New System.Drawing.Point(6, 94)
        Me.DestinoLbl.Name = "DestinoLbl"
        Me.DestinoLbl.Size = New System.Drawing.Size(127, 15)
        Me.DestinoLbl.TabIndex = 7
        Me.DestinoLbl.Text = "Seleccionar Archivo/s"
        '
        'BuscarBtn
        '
        Me.BuscarBtn.Image = Global.MercaderSG.My.Resources.Resources.RestoreE1
        Me.BuscarBtn.Location = New System.Drawing.Point(139, 91)
        Me.BuscarBtn.Name = "BuscarBtn"
        Me.BuscarBtn.Size = New System.Drawing.Size(40, 24)
        Me.BuscarBtn.TabIndex = 2
        Me.BuscarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(9, 130)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 3
        Me.AceptarBtn.Text = "&Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'GuardarFD
        '
        Me.GuardarFD.FileName = "OpenFileDialog1"
        '
        'ArchivosLB
        '
        Me.ArchivosLB.Dock = System.Windows.Forms.DockStyle.Right
        Me.ArchivosLB.FormattingEnabled = True
        Me.ArchivosLB.ItemHeight = 15
        Me.ArchivosLB.Location = New System.Drawing.Point(287, 19)
        Me.ArchivosLB.Name = "ArchivosLB"
        Me.ArchivosLB.Size = New System.Drawing.Size(233, 138)
        Me.ArchivosLB.TabIndex = 6
        '
        'RestaurarGB
        '
        Me.RestaurarGB.Controls.Add(Me.NuevoBtn)
        Me.RestaurarGB.Controls.Add(Me.ReContraseñaZipTxt)
        Me.RestaurarGB.Controls.Add(Me.ContraseñaZipTxt)
        Me.RestaurarGB.Controls.Add(Me.ReContraseñaZipLbl)
        Me.RestaurarGB.Controls.Add(Me.ContraseñaZipLbl)
        Me.RestaurarGB.Controls.Add(Me.CancelarBtn)
        Me.RestaurarGB.Controls.Add(Me.DestinoLbl)
        Me.RestaurarGB.Controls.Add(Me.ArchivosLB)
        Me.RestaurarGB.Controls.Add(Me.BuscarBtn)
        Me.RestaurarGB.Controls.Add(Me.AceptarBtn)
        Me.RestaurarGB.Location = New System.Drawing.Point(12, 12)
        Me.RestaurarGB.Name = "RestaurarGB"
        Me.RestaurarGB.Size = New System.Drawing.Size(523, 160)
        Me.RestaurarGB.TabIndex = 11
        Me.RestaurarGB.TabStop = False
        Me.RestaurarGB.Text = "Restaurar"
        '
        'NuevoBtn
        '
        Me.NuevoBtn.Image = Global.MercaderSG.My.Resources.Resources.newPage
        Me.NuevoBtn.Location = New System.Drawing.Point(97, 130)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Size = New System.Drawing.Size(82, 24)
        Me.NuevoBtn.TabIndex = 4
        Me.NuevoBtn.Text = "Nuevo"
        Me.NuevoBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.NuevoBtn.UseVisualStyleBackColor = True
        '
        'ReContraseñaZipTxt
        '
        Me.ReContraseñaZipTxt.Location = New System.Drawing.Point(148, 56)
        Me.ReContraseñaZipTxt.Name = "ReContraseñaZipTxt"
        Me.ReContraseñaZipTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ReContraseñaZipTxt.Size = New System.Drawing.Size(119, 23)
        Me.ReContraseñaZipTxt.TabIndex = 1
        '
        'ContraseñaZipTxt
        '
        Me.ContraseñaZipTxt.Location = New System.Drawing.Point(103, 27)
        Me.ContraseñaZipTxt.Name = "ContraseñaZipTxt"
        Me.ContraseñaZipTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ContraseñaZipTxt.Size = New System.Drawing.Size(164, 23)
        Me.ContraseñaZipTxt.TabIndex = 0
        '
        'ReContraseñaZipLbl
        '
        Me.ReContraseñaZipLbl.AutoSize = True
        Me.ReContraseñaZipLbl.Location = New System.Drawing.Point(6, 59)
        Me.ReContraseñaZipLbl.Name = "ReContraseñaZipLbl"
        Me.ReContraseñaZipLbl.Size = New System.Drawing.Size(136, 15)
        Me.ReContraseñaZipLbl.TabIndex = 13
        Me.ReContraseñaZipLbl.Text = "Re-Ingresar Contraseña"
        '
        'ContraseñaZipLbl
        '
        Me.ContraseñaZipLbl.AutoSize = True
        Me.ContraseñaZipLbl.Location = New System.Drawing.Point(6, 30)
        Me.ContraseñaZipLbl.Name = "ContraseñaZipLbl"
        Me.ContraseñaZipLbl.Size = New System.Drawing.Size(90, 15)
        Me.ContraseñaZipLbl.TabIndex = 12
        Me.ContraseñaZipLbl.Text = "Contraseña ZIP"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(185, 130)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 5
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
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
        'Restore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(547, 183)
        Me.Controls.Add(Me.RestaurarGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(553, 212)
        Me.MinimumSize = New System.Drawing.Size(553, 212)
        Me.Name = "Restore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restaurar base de datos - MercaderSG"
        Me.RestaurarGB.ResumeLayout(False)
        Me.RestaurarGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DestinoLbl As System.Windows.Forms.Label
    Friend WithEvents BuscarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents GuardarFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ArchivosLB As System.Windows.Forms.ListBox
    Friend WithEvents RestaurarGB As System.Windows.Forms.GroupBox
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents ReContraseñaZipTxt As System.Windows.Forms.TextBox
    Friend WithEvents ContraseñaZipTxt As System.Windows.Forms.TextBox
    Friend WithEvents ReContraseñaZipLbl As System.Windows.Forms.Label
    Friend WithEvents ContraseñaZipLbl As System.Windows.Forms.Label
    Friend WithEvents NuevoBtn As System.Windows.Forms.Button
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
End Class
