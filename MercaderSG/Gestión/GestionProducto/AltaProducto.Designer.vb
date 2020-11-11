<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaProducto))
        Me.NombreLbl = New System.Windows.Forms.Label()
        Me.DescripcionLbl = New System.Windows.Forms.Label()
        Me.SectorLbl = New System.Windows.Forms.Label()
        Me.PrecioLbl = New System.Windows.Forms.Label()
        Me.CantidadLbl = New System.Windows.Forms.Label()
        Me.ProductoGB = New System.Windows.Forms.GroupBox()
        Me.PrecioTxt = New System.Windows.Forms.NumericUpDown()
        Me.ACBtn = New System.Windows.Forms.Button()
        Me.DescripcionTxt = New System.Windows.Forms.TextBox()
        Me.CantidadTxt = New System.Windows.Forms.TextBox()
        Me.NombreTxt = New System.Windows.Forms.TextBox()
        Me.SectorCMB = New System.Windows.Forms.ComboBox()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProductoGB.SuspendLayout()
        CType(Me.PrecioTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NombreLbl
        '
        Me.NombreLbl.AutoSize = True
        Me.NombreLbl.Location = New System.Drawing.Point(18, 34)
        Me.NombreLbl.Name = "NombreLbl"
        Me.NombreLbl.Size = New System.Drawing.Size(50, 15)
        Me.NombreLbl.TabIndex = 0
        Me.NombreLbl.Text = "Nombre"
        '
        'DescripcionLbl
        '
        Me.DescripcionLbl.AutoSize = True
        Me.DescripcionLbl.Location = New System.Drawing.Point(18, 92)
        Me.DescripcionLbl.Name = "DescripcionLbl"
        Me.DescripcionLbl.Size = New System.Drawing.Size(73, 15)
        Me.DescripcionLbl.TabIndex = 1
        Me.DescripcionLbl.Text = "Descripcion"
        '
        'SectorLbl
        '
        Me.SectorLbl.AutoSize = True
        Me.SectorLbl.Location = New System.Drawing.Point(18, 63)
        Me.SectorLbl.Name = "SectorLbl"
        Me.SectorLbl.Size = New System.Drawing.Size(41, 15)
        Me.SectorLbl.TabIndex = 2
        Me.SectorLbl.Text = "Sector"
        '
        'PrecioLbl
        '
        Me.PrecioLbl.AutoSize = True
        Me.PrecioLbl.Location = New System.Drawing.Point(234, 34)
        Me.PrecioLbl.Name = "PrecioLbl"
        Me.PrecioLbl.Size = New System.Drawing.Size(42, 15)
        Me.PrecioLbl.TabIndex = 3
        Me.PrecioLbl.Text = "Precio"
        '
        'CantidadLbl
        '
        Me.CantidadLbl.AutoSize = True
        Me.CantidadLbl.Location = New System.Drawing.Point(234, 63)
        Me.CantidadLbl.Name = "CantidadLbl"
        Me.CantidadLbl.Size = New System.Drawing.Size(56, 15)
        Me.CantidadLbl.TabIndex = 4
        Me.CantidadLbl.Text = "Cantidad"
        '
        'ProductoGB
        '
        Me.ProductoGB.Controls.Add(Me.PrecioTxt)
        Me.ProductoGB.Controls.Add(Me.ACBtn)
        Me.ProductoGB.Controls.Add(Me.DescripcionTxt)
        Me.ProductoGB.Controls.Add(Me.CantidadTxt)
        Me.ProductoGB.Controls.Add(Me.NombreTxt)
        Me.ProductoGB.Controls.Add(Me.SectorCMB)
        Me.ProductoGB.Controls.Add(Me.NombreLbl)
        Me.ProductoGB.Controls.Add(Me.CantidadLbl)
        Me.ProductoGB.Controls.Add(Me.DescripcionLbl)
        Me.ProductoGB.Controls.Add(Me.PrecioLbl)
        Me.ProductoGB.Controls.Add(Me.SectorLbl)
        Me.ProductoGB.Location = New System.Drawing.Point(12, 12)
        Me.ProductoGB.Name = "ProductoGB"
        Me.ProductoGB.Size = New System.Drawing.Size(417, 173)
        Me.ProductoGB.TabIndex = 0
        Me.ProductoGB.TabStop = False
        Me.ProductoGB.Text = "Datos del producto"
        '
        'PrecioTxt
        '
        Me.PrecioTxt.DecimalPlaces = 2
        Me.PrecioTxt.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.PrecioTxt.Location = New System.Drawing.Point(296, 32)
        Me.PrecioTxt.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.PrecioTxt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PrecioTxt.Name = "PrecioTxt"
        Me.PrecioTxt.Size = New System.Drawing.Size(100, 23)
        Me.PrecioTxt.TabIndex = 3
        Me.PrecioTxt.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ACBtn
        '
        Me.ACBtn.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACBtn.ForeColor = System.Drawing.Color.SteelBlue
        Me.ACBtn.Location = New System.Drawing.Point(61, 110)
        Me.ACBtn.Name = "ACBtn"
        Me.ACBtn.Size = New System.Drawing.Size(28, 22)
        Me.ACBtn.TabIndex = 5
        Me.ACBtn.Text = "AC"
        Me.ACBtn.UseVisualStyleBackColor = True
        '
        'DescripcionTxt
        '
        Me.DescripcionTxt.Location = New System.Drawing.Point(95, 89)
        Me.DescripcionTxt.Multiline = True
        Me.DescripcionTxt.Name = "DescripcionTxt"
        Me.DescripcionTxt.Size = New System.Drawing.Size(301, 71)
        Me.DescripcionTxt.TabIndex = 6
        '
        'CantidadTxt
        '
        Me.CantidadTxt.Location = New System.Drawing.Point(296, 60)
        Me.CantidadTxt.Name = "CantidadTxt"
        Me.CantidadTxt.Size = New System.Drawing.Size(100, 23)
        Me.CantidadTxt.TabIndex = 4
        '
        'NombreTxt
        '
        Me.NombreTxt.Location = New System.Drawing.Point(95, 31)
        Me.NombreTxt.Name = "NombreTxt"
        Me.NombreTxt.Size = New System.Drawing.Size(116, 23)
        Me.NombreTxt.TabIndex = 1
        '
        'SectorCMB
        '
        Me.SectorCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SectorCMB.FormattingEnabled = True
        Me.SectorCMB.Location = New System.Drawing.Point(95, 60)
        Me.SectorCMB.Name = "SectorCMB"
        Me.SectorCMB.Size = New System.Drawing.Size(116, 23)
        Me.SectorCMB.TabIndex = 2
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
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(223, 191)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 24)
        Me.CancelarBtn.TabIndex = 8
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarBtn.UseVisualStyleBackColor = True
        '
        'AceptarBtn
        '
        Me.AceptarBtn.Image = Global.MercaderSG.My.Resources.Resources.accept
        Me.AceptarBtn.Location = New System.Drawing.Point(135, 191)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 7
        Me.AceptarBtn.Text = "Aceptar"
        Me.AceptarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AceptarBtn.UseVisualStyleBackColor = True
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
        'AltaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(441, 221)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.ProductoGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(447, 250)
        Me.MinimumSize = New System.Drawing.Size(447, 250)
        Me.Name = "AltaProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Producto - MercaderSG"
        Me.ProductoGB.ResumeLayout(False)
        Me.ProductoGB.PerformLayout()
        CType(Me.PrecioTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NombreLbl As System.Windows.Forms.Label
    Friend WithEvents DescripcionLbl As System.Windows.Forms.Label
    Friend WithEvents SectorLbl As System.Windows.Forms.Label
    Friend WithEvents PrecioLbl As System.Windows.Forms.Label
    Friend WithEvents CantidadLbl As System.Windows.Forms.Label
    Friend WithEvents ProductoGB As System.Windows.Forms.GroupBox
    Friend WithEvents DescripcionTxt As System.Windows.Forms.TextBox
    Friend WithEvents CantidadTxt As System.Windows.Forms.TextBox
    Friend WithEvents NombreTxt As System.Windows.Forms.TextBox
    Friend WithEvents SectorCMB As System.Windows.Forms.ComboBox
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents ACBtn As System.Windows.Forms.Button
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents PrecioTxt As System.Windows.Forms.NumericUpDown
End Class
