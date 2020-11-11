<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaLocalidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaLocalidad))
        Me.LocalidadGB = New System.Windows.Forms.GroupBox()
        Me.ProvinciaCMB = New System.Windows.Forms.ComboBox()
        Me.CodPostalTxt = New System.Windows.Forms.TextBox()
        Me.DescripcionTxt = New System.Windows.Forms.TextBox()
        Me.ProvinciaLbl = New System.Windows.Forms.Label()
        Me.CodPostalLbl = New System.Windows.Forms.Label()
        Me.DescripcionLbl = New System.Windows.Forms.Label()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LocalidadGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LocalidadGB
        '
        Me.LocalidadGB.Controls.Add(Me.ProvinciaCMB)
        Me.LocalidadGB.Controls.Add(Me.CodPostalTxt)
        Me.LocalidadGB.Controls.Add(Me.DescripcionTxt)
        Me.LocalidadGB.Controls.Add(Me.ProvinciaLbl)
        Me.LocalidadGB.Controls.Add(Me.CodPostalLbl)
        Me.LocalidadGB.Controls.Add(Me.DescripcionLbl)
        Me.LocalidadGB.Location = New System.Drawing.Point(12, 12)
        Me.LocalidadGB.Name = "LocalidadGB"
        Me.LocalidadGB.Size = New System.Drawing.Size(246, 129)
        Me.LocalidadGB.TabIndex = 0
        Me.LocalidadGB.TabStop = False
        Me.LocalidadGB.Text = "Localidad"
        '
        'ProvinciaCMB
        '
        Me.ProvinciaCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProvinciaCMB.FormattingEnabled = True
        Me.ProvinciaCMB.Location = New System.Drawing.Point(106, 91)
        Me.ProvinciaCMB.Name = "ProvinciaCMB"
        Me.ProvinciaCMB.Size = New System.Drawing.Size(119, 23)
        Me.ProvinciaCMB.TabIndex = 3
        '
        'CodPostalTxt
        '
        Me.CodPostalTxt.Location = New System.Drawing.Point(106, 60)
        Me.CodPostalTxt.Name = "CodPostalTxt"
        Me.CodPostalTxt.Size = New System.Drawing.Size(72, 23)
        Me.CodPostalTxt.TabIndex = 2
        '
        'DescripcionTxt
        '
        Me.DescripcionTxt.Location = New System.Drawing.Point(106, 28)
        Me.DescripcionTxt.Name = "DescripcionTxt"
        Me.DescripcionTxt.Size = New System.Drawing.Size(119, 23)
        Me.DescripcionTxt.TabIndex = 1
        '
        'ProvinciaLbl
        '
        Me.ProvinciaLbl.AutoSize = True
        Me.ProvinciaLbl.Location = New System.Drawing.Point(9, 91)
        Me.ProvinciaLbl.Name = "ProvinciaLbl"
        Me.ProvinciaLbl.Size = New System.Drawing.Size(60, 15)
        Me.ProvinciaLbl.TabIndex = 2
        Me.ProvinciaLbl.Text = "Provincia"
        '
        'CodPostalLbl
        '
        Me.CodPostalLbl.AutoSize = True
        Me.CodPostalLbl.Location = New System.Drawing.Point(9, 63)
        Me.CodPostalLbl.Name = "CodPostalLbl"
        Me.CodPostalLbl.Size = New System.Drawing.Size(83, 15)
        Me.CodPostalLbl.TabIndex = 1
        Me.CodPostalLbl.Text = "Codigo Postal"
        '
        'DescripcionLbl
        '
        Me.DescripcionLbl.AutoSize = True
        Me.DescripcionLbl.Location = New System.Drawing.Point(9, 31)
        Me.DescripcionLbl.Name = "DescripcionLbl"
        Me.DescripcionLbl.Size = New System.Drawing.Size(73, 15)
        Me.DescripcionLbl.TabIndex = 0
        Me.DescripcionLbl.Text = "Descripcion"
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(49, 147)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 4
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(137, 147)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 5
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'MensajeTT
        '
        Me.MensajeTT.AutomaticDelay = 100
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
        'AltaLocalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(270, 178)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.LocalidadGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(276, 207)
        Me.MinimumSize = New System.Drawing.Size(276, 207)
        Me.Name = "AltaLocalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Localidad - MercaderSG"
        Me.LocalidadGB.ResumeLayout(False)
        Me.LocalidadGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LocalidadGB As System.Windows.Forms.GroupBox
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents ProvinciaCMB As System.Windows.Forms.ComboBox
    Friend WithEvents CodPostalTxt As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionTxt As System.Windows.Forms.TextBox
    Friend WithEvents ProvinciaLbl As System.Windows.Forms.Label
    Friend WithEvents CodPostalLbl As System.Windows.Forms.Label
    Friend WithEvents DescripcionLbl As System.Windows.Forms.Label
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
End Class
