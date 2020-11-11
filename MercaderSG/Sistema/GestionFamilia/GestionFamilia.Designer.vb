<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionFamilia
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
        Me.OperacionGB = New System.Windows.Forms.GroupBox()
        Me.AgregarBtn = New System.Windows.Forms.Button()
        Me.ModificarBtn = New System.Windows.Forms.Button()
        Me.EliminarBtn = New System.Windows.Forms.Button()
        Me.RegistrosGB = New System.Windows.Forms.GroupBox()
        Me.FamiliaDG = New System.Windows.Forms.DataGridView()
        Me.CodCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlesTP = New System.Windows.Forms.ToolTip(Me.components)
        Me.OperacionGB.SuspendLayout()
        Me.RegistrosGB.SuspendLayout()
        CType(Me.FamiliaDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OperacionGB
        '
        Me.OperacionGB.Controls.Add(Me.AgregarBtn)
        Me.OperacionGB.Controls.Add(Me.ModificarBtn)
        Me.OperacionGB.Controls.Add(Me.EliminarBtn)
        Me.OperacionGB.Location = New System.Drawing.Point(12, 12)
        Me.OperacionGB.Name = "OperacionGB"
        Me.OperacionGB.Size = New System.Drawing.Size(408, 61)
        Me.OperacionGB.TabIndex = 0
        Me.OperacionGB.TabStop = False
        Me.OperacionGB.Text = "Operaciones"
        '
        'AgregarBtn
        '
        Me.AgregarBtn.Image = Global.MercaderSG.My.Resources.Resources.add
        Me.AgregarBtn.Location = New System.Drawing.Point(12, 22)
        Me.AgregarBtn.Name = "AgregarBtn"
        Me.AgregarBtn.Size = New System.Drawing.Size(110, 24)
        Me.AgregarBtn.TabIndex = 1
        Me.AgregarBtn.Text = "Nueva Familia"
        Me.AgregarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AgregarBtn.UseVisualStyleBackColor = True
        '
        'ModificarBtn
        '
        Me.ModificarBtn.Image = Global.MercaderSG.My.Resources.Resources.pencil
        Me.ModificarBtn.Location = New System.Drawing.Point(128, 22)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(131, 24)
        Me.ModificarBtn.TabIndex = 2
        Me.ModificarBtn.Text = "Modificar Familia"
        Me.ModificarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ModificarBtn.UseVisualStyleBackColor = True
        '
        'EliminarBtn
        '
        Me.EliminarBtn.Image = Global.MercaderSG.My.Resources.Resources.delete
        Me.EliminarBtn.Location = New System.Drawing.Point(265, 22)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(132, 24)
        Me.EliminarBtn.TabIndex = 3
        Me.EliminarBtn.Text = "Eliminar Familia"
        Me.EliminarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EliminarBtn.UseVisualStyleBackColor = True
        '
        'RegistrosGB
        '
        Me.RegistrosGB.Controls.Add(Me.FamiliaDG)
        Me.RegistrosGB.Location = New System.Drawing.Point(12, 79)
        Me.RegistrosGB.Name = "RegistrosGB"
        Me.RegistrosGB.Size = New System.Drawing.Size(408, 196)
        Me.RegistrosGB.TabIndex = 58
        Me.RegistrosGB.TabStop = False
        Me.RegistrosGB.Text = "Registros"
        '
        'FamiliaDG
        '
        Me.FamiliaDG.AllowUserToAddRows = False
        Me.FamiliaDG.AllowUserToDeleteRows = False
        Me.FamiliaDG.AllowUserToResizeColumns = False
        Me.FamiliaDG.AllowUserToResizeRows = False
        Me.FamiliaDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FamiliaDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodCAB, Me.DescripcionCAB})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FamiliaDG.DefaultCellStyle = DataGridViewCellStyle1
        Me.FamiliaDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FamiliaDG.Location = New System.Drawing.Point(3, 19)
        Me.FamiliaDG.MultiSelect = False
        Me.FamiliaDG.Name = "FamiliaDG"
        Me.FamiliaDG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FamiliaDG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.FamiliaDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.FamiliaDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.FamiliaDG.Size = New System.Drawing.Size(402, 174)
        Me.FamiliaDG.StandardTab = True
        Me.FamiliaDG.TabIndex = 4
        '
        'CodCAB
        '
        Me.CodCAB.DataPropertyName = "CodFam"
        Me.CodCAB.HeaderText = "Código"
        Me.CodCAB.Name = "CodCAB"
        Me.CodCAB.ReadOnly = True
        '
        'DescripcionCAB
        '
        Me.DescripcionCAB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionCAB.DataPropertyName = "Descripcion"
        Me.DescripcionCAB.HeaderText = "Descripcion"
        Me.DescripcionCAB.Name = "DescripcionCAB"
        Me.DescripcionCAB.ReadOnly = True
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
        'GestionFamilia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(433, 288)
        Me.Controls.Add(Me.RegistrosGB)
        Me.Controls.Add(Me.OperacionGB)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(439, 317)
        Me.MinimumSize = New System.Drawing.Size(439, 317)
        Me.Name = "GestionFamilia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.OperacionGB.ResumeLayout(False)
        Me.RegistrosGB.ResumeLayout(False)
        CType(Me.FamiliaDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OperacionGB As System.Windows.Forms.GroupBox
    Friend WithEvents AgregarBtn As System.Windows.Forms.Button
    Friend WithEvents ModificarBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarBtn As System.Windows.Forms.Button
    Friend WithEvents RegistrosGB As System.Windows.Forms.GroupBox
    Friend WithEvents FamiliaDG As System.Windows.Forms.DataGridView
    Friend WithEvents ControlesTP As System.Windows.Forms.ToolTip
    Friend WithEvents CodCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCAB As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
