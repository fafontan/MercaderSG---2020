<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultadoFamPatUsu
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
        Me.TituloErrorLbl = New System.Windows.Forms.Label()
        Me.TituloAltaLbl = New System.Windows.Forms.Label()
        Me.FLP = New System.Windows.Forms.FlowLayoutPanel()
        Me.InformacionPanel = New System.Windows.Forms.Panel()
        Me.LblAlta = New System.Windows.Forms.TextBox()
        Me.AltaPB = New System.Windows.Forms.PictureBox()
        Me.AdvertenciaPanel = New System.Windows.Forms.Panel()
        Me.LblError = New System.Windows.Forms.TextBox()
        Me.AdvertenciaPB = New System.Windows.Forms.PictureBox()
        Me.AdvertenciaPanelPatentes = New System.Windows.Forms.Panel()
        Me.CausaLbl = New System.Windows.Forms.Label()
        Me.LblErrorEliminarPermisos = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TituloNoAltaPermisosLbl = New System.Windows.Forms.Label()
        Me.FLP.SuspendLayout()
        Me.InformacionPanel.SuspendLayout()
        CType(Me.AltaPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AdvertenciaPanel.SuspendLayout()
        CType(Me.AdvertenciaPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AdvertenciaPanelPatentes.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TituloErrorLbl
        '
        Me.TituloErrorLbl.AutoSize = True
        Me.TituloErrorLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TituloErrorLbl.Location = New System.Drawing.Point(9, 6)
        Me.TituloErrorLbl.Name = "TituloErrorLbl"
        Me.TituloErrorLbl.Size = New System.Drawing.Size(50, 15)
        Me.TituloErrorLbl.TabIndex = 1
        Me.TituloErrorLbl.Text = "tituBaja"
        '
        'TituloAltaLbl
        '
        Me.TituloAltaLbl.AutoSize = True
        Me.TituloAltaLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TituloAltaLbl.Location = New System.Drawing.Point(9, 4)
        Me.TituloAltaLbl.Name = "TituloAltaLbl"
        Me.TituloAltaLbl.Size = New System.Drawing.Size(49, 15)
        Me.TituloAltaLbl.TabIndex = 3
        Me.TituloAltaLbl.Text = "tituAlta"
        '
        'FLP
        '
        Me.FLP.AutoSize = True
        Me.FLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FLP.Controls.Add(Me.InformacionPanel)
        Me.FLP.Controls.Add(Me.AdvertenciaPanel)
        Me.FLP.Controls.Add(Me.AdvertenciaPanelPatentes)
        Me.FLP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FLP.Location = New System.Drawing.Point(0, 0)
        Me.FLP.Name = "FLP"
        Me.FLP.Size = New System.Drawing.Size(278, 406)
        Me.FLP.TabIndex = 4
        '
        'InformacionPanel
        '
        Me.InformacionPanel.AutoSize = True
        Me.InformacionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.InformacionPanel.BackColor = System.Drawing.SystemColors.Control
        Me.InformacionPanel.Controls.Add(Me.LblAlta)
        Me.InformacionPanel.Controls.Add(Me.AltaPB)
        Me.InformacionPanel.Controls.Add(Me.TituloAltaLbl)
        Me.InformacionPanel.Location = New System.Drawing.Point(5, 5)
        Me.InformacionPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.InformacionPanel.Name = "InformacionPanel"
        Me.InformacionPanel.Size = New System.Drawing.Size(268, 115)
        Me.InformacionPanel.TabIndex = 4
        '
        'LblAlta
        '
        Me.LblAlta.AcceptsTab = True
        Me.LblAlta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblAlta.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblAlta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlta.Location = New System.Drawing.Point(54, 39)
        Me.LblAlta.Multiline = True
        Me.LblAlta.Name = "LblAlta"
        Me.LblAlta.ReadOnly = True
        Me.LblAlta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LblAlta.Size = New System.Drawing.Size(211, 73)
        Me.LblAlta.TabIndex = 7
        '
        'AltaPB
        '
        Me.AltaPB.Image = Global.MercaderSG.My.Resources.Resources.InformationE32
        Me.AltaPB.Location = New System.Drawing.Point(12, 39)
        Me.AltaPB.Margin = New System.Windows.Forms.Padding(3, 20, 3, 3)
        Me.AltaPB.Name = "AltaPB"
        Me.AltaPB.Size = New System.Drawing.Size(33, 33)
        Me.AltaPB.TabIndex = 4
        Me.AltaPB.TabStop = False
        '
        'AdvertenciaPanel
        '
        Me.AdvertenciaPanel.AutoSize = True
        Me.AdvertenciaPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AdvertenciaPanel.BackColor = System.Drawing.SystemColors.Control
        Me.AdvertenciaPanel.Controls.Add(Me.LblError)
        Me.AdvertenciaPanel.Controls.Add(Me.AdvertenciaPB)
        Me.AdvertenciaPanel.Controls.Add(Me.TituloErrorLbl)
        Me.AdvertenciaPanel.Location = New System.Drawing.Point(5, 130)
        Me.AdvertenciaPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.AdvertenciaPanel.Name = "AdvertenciaPanel"
        Me.AdvertenciaPanel.Size = New System.Drawing.Size(268, 117)
        Me.AdvertenciaPanel.TabIndex = 5
        '
        'LblError
        '
        Me.LblError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblError.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblError.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblError.Location = New System.Drawing.Point(54, 41)
        Me.LblError.Multiline = True
        Me.LblError.Name = "LblError"
        Me.LblError.ReadOnly = True
        Me.LblError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LblError.Size = New System.Drawing.Size(211, 73)
        Me.LblError.TabIndex = 8
        '
        'AdvertenciaPB
        '
        Me.AdvertenciaPB.Image = Global.MercaderSG.My.Resources.Resources.AdvertenciaE32
        Me.AdvertenciaPB.Location = New System.Drawing.Point(12, 41)
        Me.AdvertenciaPB.Margin = New System.Windows.Forms.Padding(3, 20, 3, 3)
        Me.AdvertenciaPB.Name = "AdvertenciaPB"
        Me.AdvertenciaPB.Size = New System.Drawing.Size(33, 33)
        Me.AdvertenciaPB.TabIndex = 2
        Me.AdvertenciaPB.TabStop = False
        '
        'AdvertenciaPanelPatentes
        '
        Me.AdvertenciaPanelPatentes.AutoSize = True
        Me.AdvertenciaPanelPatentes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AdvertenciaPanelPatentes.BackColor = System.Drawing.SystemColors.Control
        Me.AdvertenciaPanelPatentes.Controls.Add(Me.CausaLbl)
        Me.AdvertenciaPanelPatentes.Controls.Add(Me.LblErrorEliminarPermisos)
        Me.AdvertenciaPanelPatentes.Controls.Add(Me.PictureBox1)
        Me.AdvertenciaPanelPatentes.Controls.Add(Me.TituloNoAltaPermisosLbl)
        Me.AdvertenciaPanelPatentes.Location = New System.Drawing.Point(5, 257)
        Me.AdvertenciaPanelPatentes.Margin = New System.Windows.Forms.Padding(5)
        Me.AdvertenciaPanelPatentes.Name = "AdvertenciaPanelPatentes"
        Me.AdvertenciaPanelPatentes.Size = New System.Drawing.Size(268, 136)
        Me.AdvertenciaPanelPatentes.TabIndex = 9
        '
        'CausaLbl
        '
        Me.CausaLbl.AutoSize = True
        Me.CausaLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CausaLbl.Location = New System.Drawing.Point(9, 121)
        Me.CausaLbl.Name = "CausaLbl"
        Me.CausaLbl.Size = New System.Drawing.Size(46, 15)
        Me.CausaLbl.TabIndex = 9
        Me.CausaLbl.Text = "CAUSA"
        '
        'LblErrorEliminarPermisos
        '
        Me.LblErrorEliminarPermisos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblErrorEliminarPermisos.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblErrorEliminarPermisos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblErrorEliminarPermisos.Location = New System.Drawing.Point(54, 41)
        Me.LblErrorEliminarPermisos.Multiline = True
        Me.LblErrorEliminarPermisos.Name = "LblErrorEliminarPermisos"
        Me.LblErrorEliminarPermisos.ReadOnly = True
        Me.LblErrorEliminarPermisos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LblErrorEliminarPermisos.Size = New System.Drawing.Size(211, 73)
        Me.LblErrorEliminarPermisos.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MercaderSG.My.Resources.Resources.AdvertenciaE32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 41)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 20, 3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'TituloNoAltaPermisosLbl
        '
        Me.TituloNoAltaPermisosLbl.AutoSize = True
        Me.TituloNoAltaPermisosLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TituloNoAltaPermisosLbl.Location = New System.Drawing.Point(9, 6)
        Me.TituloNoAltaPermisosLbl.Name = "TituloNoAltaPermisosLbl"
        Me.TituloNoAltaPermisosLbl.Size = New System.Drawing.Size(116, 15)
        Me.TituloNoAltaPermisosLbl.TabIndex = 1
        Me.TituloNoAltaPermisosLbl.Text = "tituBajaNoPermisos"
        '
        'ResultadoFamPatUsu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(278, 406)
        Me.Controls.Add(Me.FLP)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ResultadoFamPatUsu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.FLP.ResumeLayout(False)
        Me.FLP.PerformLayout()
        Me.InformacionPanel.ResumeLayout(False)
        Me.InformacionPanel.PerformLayout()
        CType(Me.AltaPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdvertenciaPanel.ResumeLayout(False)
        Me.AdvertenciaPanel.PerformLayout()
        CType(Me.AdvertenciaPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdvertenciaPanelPatentes.ResumeLayout(False)
        Me.AdvertenciaPanelPatentes.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TituloErrorLbl As System.Windows.Forms.Label
    Friend WithEvents TituloAltaLbl As System.Windows.Forms.Label
    Friend WithEvents FLP As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents InformacionPanel As System.Windows.Forms.Panel
    Friend WithEvents AltaPB As System.Windows.Forms.PictureBox
    Friend WithEvents AdvertenciaPanel As System.Windows.Forms.Panel
    Friend WithEvents AdvertenciaPB As System.Windows.Forms.PictureBox
    Friend WithEvents LblAlta As System.Windows.Forms.TextBox
    Friend WithEvents LblError As System.Windows.Forms.TextBox
    Friend WithEvents AdvertenciaPanelPatentes As System.Windows.Forms.Panel
    Friend WithEvents LblErrorEliminarPermisos As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TituloNoAltaPermisosLbl As System.Windows.Forms.Label
    Friend WithEvents CausaLbl As System.Windows.Forms.Label
End Class
