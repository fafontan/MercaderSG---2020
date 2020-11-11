<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroFecha
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroFecha))
        Me.FechasGB = New System.Windows.Forms.GroupBox()
        Me.HastaDTP = New System.Windows.Forms.DateTimePicker()
        Me.DesdeDTP = New System.Windows.Forms.DateTimePicker()
        Me.BuscarFechaBtn = New System.Windows.Forms.Button()
        Me.HastaLbl = New System.Windows.Forms.Label()
        Me.DesdeLbl = New System.Windows.Forms.Label()
        Me.MensajeTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.FechasGB.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FechasGB
        '
        Me.FechasGB.Controls.Add(Me.HastaDTP)
        Me.FechasGB.Controls.Add(Me.DesdeDTP)
        Me.FechasGB.Controls.Add(Me.BuscarFechaBtn)
        Me.FechasGB.Controls.Add(Me.HastaLbl)
        Me.FechasGB.Controls.Add(Me.DesdeLbl)
        Me.FechasGB.Location = New System.Drawing.Point(3, 3)
        Me.FechasGB.Name = "FechasGB"
        Me.FechasGB.Size = New System.Drawing.Size(626, 100)
        Me.FechasGB.TabIndex = 1
        Me.FechasGB.TabStop = False
        Me.FechasGB.Text = "Buscar por Fechas"
        '
        'HastaDTP
        '
        Me.HastaDTP.Checked = False
        Me.HastaDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.HastaDTP.Location = New System.Drawing.Point(319, 37)
        Me.HastaDTP.Name = "HastaDTP"
        Me.HastaDTP.Size = New System.Drawing.Size(100, 23)
        Me.HastaDTP.TabIndex = 3
        '
        'DesdeDTP
        '
        Me.DesdeDTP.Checked = False
        Me.DesdeDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DesdeDTP.Location = New System.Drawing.Point(146, 37)
        Me.DesdeDTP.Name = "DesdeDTP"
        Me.DesdeDTP.Size = New System.Drawing.Size(100, 23)
        Me.DesdeDTP.TabIndex = 2
        '
        'BuscarFechaBtn
        '
        Me.BuscarFechaBtn.Image = Global.MercaderSG.My.Resources.Resources.BuscarE
        Me.BuscarFechaBtn.Location = New System.Drawing.Point(452, 35)
        Me.BuscarFechaBtn.Name = "BuscarFechaBtn"
        Me.BuscarFechaBtn.Size = New System.Drawing.Size(84, 30)
        Me.BuscarFechaBtn.TabIndex = 4
        Me.BuscarFechaBtn.Text = "Buscar"
        Me.BuscarFechaBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BuscarFechaBtn.UseVisualStyleBackColor = True
        '
        'HastaLbl
        '
        Me.HastaLbl.AutoSize = True
        Me.HastaLbl.Location = New System.Drawing.Point(266, 43)
        Me.HastaLbl.Name = "HastaLbl"
        Me.HastaLbl.Size = New System.Drawing.Size(39, 15)
        Me.HastaLbl.TabIndex = 12
        Me.HastaLbl.Text = "Hasta"
        '
        'DesdeLbl
        '
        Me.DesdeLbl.AutoSize = True
        Me.DesdeLbl.Location = New System.Drawing.Point(90, 43)
        Me.DesdeLbl.Name = "DesdeLbl"
        Me.DesdeLbl.Size = New System.Drawing.Size(40, 15)
        Me.DesdeLbl.TabIndex = 11
        Me.DesdeLbl.Text = "Desde"
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
        'FiltroFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FechasGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FiltroFecha"
        Me.Size = New System.Drawing.Size(629, 113)
        Me.FechasGB.ResumeLayout(False)
        Me.FechasGB.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FechasGB As System.Windows.Forms.GroupBox
    Friend WithEvents HastaDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents DesdeDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents BuscarFechaBtn As System.Windows.Forms.Button
    Friend WithEvents HastaLbl As System.Windows.Forms.Label
    Friend WithEvents DesdeLbl As System.Windows.Forms.Label
    Friend WithEvents MensajeTT As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip

End Class
