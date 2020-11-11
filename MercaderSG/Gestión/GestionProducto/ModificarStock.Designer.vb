<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarStock))
        Me.ProductoGB = New System.Windows.Forms.GroupBox()
        Me.CantidadGB = New System.Windows.Forms.GroupBox()
        Me.CantidadNuevaTxt = New System.Windows.Forms.TextBox()
        Me.CantNuevaLbl = New System.Windows.Forms.Label()
        Me.CantActualLbl = New System.Windows.Forms.Label()
        Me.CantActualTxt = New System.Windows.Forms.TextBox()
        Me.CodigoTxt = New System.Windows.Forms.TextBox()
        Me.DescripcionTxt = New System.Windows.Forms.TextBox()
        Me.NombreTxt = New System.Windows.Forms.TextBox()
        Me.NombreLbl = New System.Windows.Forms.Label()
        Me.DescripcionLbl = New System.Windows.Forms.Label()
        Me.CodigoLbl = New System.Windows.Forms.Label()
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.AceptarBtn = New System.Windows.Forms.Button()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.CantNuevaTxt = New System.Windows.Forms.TextBox()
        Me.CantidadLbl = New System.Windows.Forms.Label()
        Me.ProductoGB.SuspendLayout()
        Me.CantidadGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProductoGB
        '
        Me.ProductoGB.Controls.Add(Me.CantidadGB)
        Me.ProductoGB.Controls.Add(Me.CodigoTxt)
        Me.ProductoGB.Controls.Add(Me.DescripcionTxt)
        Me.ProductoGB.Controls.Add(Me.NombreTxt)
        Me.ProductoGB.Controls.Add(Me.NombreLbl)
        Me.ProductoGB.Controls.Add(Me.DescripcionLbl)
        Me.ProductoGB.Controls.Add(Me.CodigoLbl)
        Me.ProductoGB.Location = New System.Drawing.Point(12, 12)
        Me.ProductoGB.Name = "ProductoGB"
        Me.ProductoGB.Size = New System.Drawing.Size(310, 288)
        Me.ProductoGB.TabIndex = 0
        Me.ProductoGB.TabStop = False
        Me.ProductoGB.Text = "Datos del producto"
        '
        'CantidadGB
        '
        Me.CantidadGB.Controls.Add(Me.CantidadNuevaTxt)
        Me.CantidadGB.Controls.Add(Me.CantNuevaLbl)
        Me.CantidadGB.Controls.Add(Me.CantActualLbl)
        Me.CantidadGB.Controls.Add(Me.CantActualTxt)
        Me.CantidadGB.Location = New System.Drawing.Point(18, 166)
        Me.CantidadGB.Name = "CantidadGB"
        Me.CantidadGB.Size = New System.Drawing.Size(272, 107)
        Me.CantidadGB.TabIndex = 4
        Me.CantidadGB.TabStop = False
        Me.CantidadGB.Text = "Stock Producto"
        '
        'CantidadNuevaTxt
        '
        Me.CantidadNuevaTxt.Location = New System.Drawing.Point(110, 66)
        Me.CantidadNuevaTxt.Name = "CantidadNuevaTxt"
        Me.CantidadNuevaTxt.Size = New System.Drawing.Size(95, 23)
        Me.CantidadNuevaTxt.TabIndex = 6
        '
        'CantNuevaLbl
        '
        Me.CantNuevaLbl.AutoSize = True
        Me.CantNuevaLbl.Location = New System.Drawing.Point(10, 69)
        Me.CantNuevaLbl.Name = "CantNuevaLbl"
        Me.CantNuevaLbl.Size = New System.Drawing.Size(56, 15)
        Me.CantNuevaLbl.TabIndex = 8
        Me.CantNuevaLbl.Text = "Cantidad"
        '
        'CantActualLbl
        '
        Me.CantActualLbl.AutoSize = True
        Me.CantActualLbl.Location = New System.Drawing.Point(10, 30)
        Me.CantActualLbl.Name = "CantActualLbl"
        Me.CantActualLbl.Size = New System.Drawing.Size(94, 15)
        Me.CantActualLbl.TabIndex = 3
        Me.CantActualLbl.Text = "Cantidad Actual"
        '
        'CantActualTxt
        '
        Me.CantActualTxt.Location = New System.Drawing.Point(110, 27)
        Me.CantActualTxt.Name = "CantActualTxt"
        Me.CantActualTxt.ReadOnly = True
        Me.CantActualTxt.Size = New System.Drawing.Size(95, 23)
        Me.CantActualTxt.TabIndex = 5
        '
        'CodigoTxt
        '
        Me.CodigoTxt.Location = New System.Drawing.Point(93, 31)
        Me.CodigoTxt.Name = "CodigoTxt"
        Me.CodigoTxt.ReadOnly = True
        Me.CodigoTxt.Size = New System.Drawing.Size(116, 23)
        Me.CodigoTxt.TabIndex = 1
        '
        'DescripcionTxt
        '
        Me.DescripcionTxt.Location = New System.Drawing.Point(93, 89)
        Me.DescripcionTxt.Multiline = True
        Me.DescripcionTxt.Name = "DescripcionTxt"
        Me.DescripcionTxt.ReadOnly = True
        Me.DescripcionTxt.Size = New System.Drawing.Size(198, 71)
        Me.DescripcionTxt.TabIndex = 3
        '
        'NombreTxt
        '
        Me.NombreTxt.Location = New System.Drawing.Point(93, 60)
        Me.NombreTxt.Name = "NombreTxt"
        Me.NombreTxt.ReadOnly = True
        Me.NombreTxt.Size = New System.Drawing.Size(116, 23)
        Me.NombreTxt.TabIndex = 2
        '
        'NombreLbl
        '
        Me.NombreLbl.AutoSize = True
        Me.NombreLbl.Location = New System.Drawing.Point(16, 63)
        Me.NombreLbl.Name = "NombreLbl"
        Me.NombreLbl.Size = New System.Drawing.Size(50, 15)
        Me.NombreLbl.TabIndex = 0
        Me.NombreLbl.Text = "Nombre"
        '
        'DescripcionLbl
        '
        Me.DescripcionLbl.AutoSize = True
        Me.DescripcionLbl.Location = New System.Drawing.Point(16, 97)
        Me.DescripcionLbl.Name = "DescripcionLbl"
        Me.DescripcionLbl.Size = New System.Drawing.Size(73, 15)
        Me.DescripcionLbl.TabIndex = 1
        Me.DescripcionLbl.Text = "Descripcion"
        '
        'CodigoLbl
        '
        Me.CodigoLbl.AutoSize = True
        Me.CodigoLbl.Location = New System.Drawing.Point(16, 34)
        Me.CodigoLbl.Name = "CodigoLbl"
        Me.CodigoLbl.Size = New System.Drawing.Size(45, 15)
        Me.CodigoLbl.TabIndex = 2
        Me.CodigoLbl.Text = "Código"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.Image = Global.MercaderSG.My.Resources.Resources.CancelBtn
        Me.CancelarBtn.Location = New System.Drawing.Point(170, 306)
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
        Me.AceptarBtn.Location = New System.Drawing.Point(82, 306)
        Me.AceptarBtn.Name = "AceptarBtn"
        Me.AceptarBtn.Size = New System.Drawing.Size(82, 24)
        Me.AceptarBtn.TabIndex = 7
        Me.AceptarBtn.Text = "Aceptar"
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
        'ErrorP
        '
        Me.ErrorP.BlinkRate = 150
        Me.ErrorP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorP.ContainerControl = Me
        Me.ErrorP.Icon = CType(resources.GetObject("ErrorP.Icon"), System.Drawing.Icon)
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
        'CantNuevaTxt
        '
        Me.CantNuevaTxt.Location = New System.Drawing.Point(110, 66)
        Me.CantNuevaTxt.Name = "CantNuevaTxt"
        Me.CantNuevaTxt.Size = New System.Drawing.Size(95, 20)
        Me.CantNuevaTxt.TabIndex = 9
        '
        'CantidadLbl
        '
        Me.CantidadLbl.AutoSize = True
        Me.CantidadLbl.Location = New System.Drawing.Point(10, 69)
        Me.CantidadLbl.Name = "CantidadLbl"
        Me.CantidadLbl.Size = New System.Drawing.Size(56, 15)
        Me.CantidadLbl.TabIndex = 8
        Me.CantidadLbl.Text = "Cantidad"
        '
        'ModificarStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(334, 336)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.AceptarBtn)
        Me.Controls.Add(Me.ProductoGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ModificarStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ProductoGB.ResumeLayout(False)
        Me.ProductoGB.PerformLayout()
        Me.CantidadGB.ResumeLayout(False)
        Me.CantidadGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProductoGB As System.Windows.Forms.GroupBox
    Friend WithEvents CantidadGB As System.Windows.Forms.GroupBox
    Friend WithEvents CantidadNuevaTxt As System.Windows.Forms.TextBox
    Friend WithEvents CantNuevaLbl As System.Windows.Forms.Label
    Friend WithEvents CantActualLbl As System.Windows.Forms.Label
    Friend WithEvents CantActualTxt As System.Windows.Forms.TextBox
    Friend WithEvents CodigoTxt As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionTxt As System.Windows.Forms.TextBox
    Friend WithEvents NombreTxt As System.Windows.Forms.TextBox
    Friend WithEvents NombreLbl As System.Windows.Forms.Label
    Friend WithEvents DescripcionLbl As System.Windows.Forms.Label
    Friend WithEvents CodigoLbl As System.Windows.Forms.Label
    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents AceptarBtn As System.Windows.Forms.Button
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents CantNuevaTxt As System.Windows.Forms.TextBox
    Friend WithEvents CantidadLbl As System.Windows.Forms.Label
End Class
