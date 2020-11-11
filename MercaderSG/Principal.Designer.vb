<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Me.MenuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.GestionSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionClienteSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionProductoSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionProveedorSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComercialSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaVentaSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionNVSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarNVSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaPedidoSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionNPSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarNPSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SistemaSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionUsuarioSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionFamiliaSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesbloquearUsuarioSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetearContrasenaSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeguridadSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.BitacoraSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatFamSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuFamSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatUsuSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecalcularDVSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.IdiomaSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.EspanolSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.InglesSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarContrasenaSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuPrincipal
        '
        Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionSMI, Me.ComercialSMI, Me.SistemaSMI, Me.SeguridadSMI, Me.PanelSMI})
        Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuPrincipal.Name = "MenuPrincipal"
        Me.MenuPrincipal.Size = New System.Drawing.Size(685, 24)
        Me.MenuPrincipal.TabIndex = 1
        Me.MenuPrincipal.Text = "MenuStrip1"
        '
        'GestionSMI
        '
        Me.GestionSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionClienteSMI, Me.GestionProductoSMI, Me.GestionProveedorSMI})
        Me.GestionSMI.Name = "GestionSMI"
        Me.GestionSMI.ShortcutKeyDisplayString = ""
        Me.GestionSMI.Size = New System.Drawing.Size(59, 20)
        Me.GestionSMI.Text = "Gestión"
        '
        'GestionClienteSMI
        '
        Me.GestionClienteSMI.Image = Global.MercaderSG.My.Resources.Resources.ClienteE
        Me.GestionClienteSMI.Name = "GestionClienteSMI"
        Me.GestionClienteSMI.ShortcutKeyDisplayString = ""
        Me.GestionClienteSMI.Size = New System.Drawing.Size(152, 22)
        Me.GestionClienteSMI.Text = "Clientes"
        '
        'GestionProductoSMI
        '
        Me.GestionProductoSMI.Image = Global.MercaderSG.My.Resources.Resources.package
        Me.GestionProductoSMI.Name = "GestionProductoSMI"
        Me.GestionProductoSMI.Size = New System.Drawing.Size(152, 22)
        Me.GestionProductoSMI.Text = "Productos"
        '
        'GestionProveedorSMI
        '
        Me.GestionProveedorSMI.Image = Global.MercaderSG.My.Resources.Resources.ProveedorE
        Me.GestionProveedorSMI.Name = "GestionProveedorSMI"
        Me.GestionProveedorSMI.Size = New System.Drawing.Size(152, 22)
        Me.GestionProveedorSMI.Text = "Proveedores"
        '
        'ComercialSMI
        '
        Me.ComercialSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotaVentaSMI, Me.NotaPedidoSMI})
        Me.ComercialSMI.Name = "ComercialSMI"
        Me.ComercialSMI.Size = New System.Drawing.Size(73, 20)
        Me.ComercialSMI.Text = "Comercial"
        '
        'NotaVentaSMI
        '
        Me.NotaVentaSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionNVSMI, Me.GenerarNVSMI})
        Me.NotaVentaSMI.Image = Global.MercaderSG.My.Resources.Resources.page_green
        Me.NotaVentaSMI.Name = "NotaVentaSMI"
        Me.NotaVentaSMI.Size = New System.Drawing.Size(156, 22)
        Me.NotaVentaSMI.Text = "Nota de Venta"
        '
        'GestionNVSMI
        '
        Me.GestionNVSMI.Image = Global.MercaderSG.My.Resources.Resources.GestionNV
        Me.GestionNVSMI.Name = "GestionNVSMI"
        Me.GestionNVSMI.Size = New System.Drawing.Size(152, 22)
        Me.GestionNVSMI.Text = "Gestion"
        '
        'GenerarNVSMI
        '
        Me.GenerarNVSMI.Image = Global.MercaderSG.My.Resources.Resources.page_add
        Me.GenerarNVSMI.Name = "GenerarNVSMI"
        Me.GenerarNVSMI.Size = New System.Drawing.Size(152, 22)
        Me.GenerarNVSMI.Text = "Generar"
        '
        'NotaPedidoSMI
        '
        Me.NotaPedidoSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionNPSMI, Me.GenerarNPSMI})
        Me.NotaPedidoSMI.Image = Global.MercaderSG.My.Resources.Resources.page
        Me.NotaPedidoSMI.Name = "NotaPedidoSMI"
        Me.NotaPedidoSMI.Size = New System.Drawing.Size(156, 22)
        Me.NotaPedidoSMI.Text = "Nota de Pedido"
        '
        'GestionNPSMI
        '
        Me.GestionNPSMI.Image = Global.MercaderSG.My.Resources.Resources.GestionNV
        Me.GestionNPSMI.Name = "GestionNPSMI"
        Me.GestionNPSMI.Size = New System.Drawing.Size(152, 22)
        Me.GestionNPSMI.Text = "Gestion"
        '
        'GenerarNPSMI
        '
        Me.GenerarNPSMI.Image = Global.MercaderSG.My.Resources.Resources.page_add
        Me.GenerarNPSMI.Name = "GenerarNPSMI"
        Me.GenerarNPSMI.Size = New System.Drawing.Size(152, 22)
        Me.GenerarNPSMI.Text = "Generar"
        '
        'SistemaSMI
        '
        Me.SistemaSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionUsuarioSMI, Me.GestionFamiliaSMI, Me.DesbloquearUsuarioSMI, Me.ResetearContrasenaSMI})
        Me.SistemaSMI.Name = "SistemaSMI"
        Me.SistemaSMI.Size = New System.Drawing.Size(60, 20)
        Me.SistemaSMI.Text = "Sistema"
        '
        'GestionUsuarioSMI
        '
        Me.GestionUsuarioSMI.Image = Global.MercaderSG.My.Resources.Resources.group_user
        Me.GestionUsuarioSMI.Name = "GestionUsuarioSMI"
        Me.GestionUsuarioSMI.Size = New System.Drawing.Size(183, 22)
        Me.GestionUsuarioSMI.Text = "Gestión de Usuarios"
        '
        'GestionFamiliaSMI
        '
        Me.GestionFamiliaSMI.Image = Global.MercaderSG.My.Resources.Resources.FamiliaE
        Me.GestionFamiliaSMI.Name = "GestionFamiliaSMI"
        Me.GestionFamiliaSMI.Size = New System.Drawing.Size(183, 22)
        Me.GestionFamiliaSMI.Text = "Gestión de Familias"
        '
        'DesbloquearUsuarioSMI
        '
        Me.DesbloquearUsuarioSMI.Image = Global.MercaderSG.My.Resources.Resources.DesbloImg
        Me.DesbloquearUsuarioSMI.Name = "DesbloquearUsuarioSMI"
        Me.DesbloquearUsuarioSMI.Size = New System.Drawing.Size(183, 22)
        Me.DesbloquearUsuarioSMI.Text = "Desbloquear Usuario"
        '
        'ResetearContrasenaSMI
        '
        Me.ResetearContrasenaSMI.Image = Global.MercaderSG.My.Resources.Resources.ResetearPass
        Me.ResetearContrasenaSMI.Name = "ResetearContrasenaSMI"
        Me.ResetearContrasenaSMI.Size = New System.Drawing.Size(183, 22)
        Me.ResetearContrasenaSMI.Text = "Resetear Contraseña"
        '
        'SeguridadSMI
        '
        Me.SeguridadSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupSMI, Me.RestoreSMI, Me.BitacoraSMI, Me.PatFamSMI, Me.UsuFamSMI, Me.PatUsuSMI, Me.RecalcularDVSMI})
        Me.SeguridadSMI.Name = "SeguridadSMI"
        Me.SeguridadSMI.Size = New System.Drawing.Size(72, 20)
        Me.SeguridadSMI.Text = "Seguridad"
        '
        'BackupSMI
        '
        Me.BackupSMI.Image = Global.MercaderSG.My.Resources.Resources.database_save
        Me.BackupSMI.Name = "BackupSMI"
        Me.BackupSMI.Size = New System.Drawing.Size(203, 22)
        Me.BackupSMI.Text = "Copia de Seguridad - BD"
        '
        'RestoreSMI
        '
        Me.RestoreSMI.Image = Global.MercaderSG.My.Resources.Resources.RestoreE
        Me.RestoreSMI.Name = "RestoreSMI"
        Me.RestoreSMI.Size = New System.Drawing.Size(203, 22)
        Me.RestoreSMI.Text = "Restaurar - BD"
        '
        'BitacoraSMI
        '
        Me.BitacoraSMI.Image = Global.MercaderSG.My.Resources.Resources.BitacoraE
        Me.BitacoraSMI.Name = "BitacoraSMI"
        Me.BitacoraSMI.Size = New System.Drawing.Size(203, 22)
        Me.BitacoraSMI.Text = "Bitacora"
        '
        'PatFamSMI
        '
        Me.PatFamSMI.Image = Global.MercaderSG.My.Resources.Resources.Permisos
        Me.PatFamSMI.Name = "PatFamSMI"
        Me.PatFamSMI.Size = New System.Drawing.Size(203, 22)
        Me.PatFamSMI.Text = "Patente - Familia"
        '
        'UsuFamSMI
        '
        Me.UsuFamSMI.Image = Global.MercaderSG.My.Resources.Resources.Permisos
        Me.UsuFamSMI.Name = "UsuFamSMI"
        Me.UsuFamSMI.Size = New System.Drawing.Size(203, 22)
        Me.UsuFamSMI.Text = "Usuario - Familia"
        '
        'PatUsuSMI
        '
        Me.PatUsuSMI.Image = Global.MercaderSG.My.Resources.Resources.Permisos
        Me.PatUsuSMI.Name = "PatUsuSMI"
        Me.PatUsuSMI.Size = New System.Drawing.Size(203, 22)
        Me.PatUsuSMI.Text = "Patente - Usuario"
        '
        'RecalcularDVSMI
        '
        Me.RecalcularDVSMI.Image = Global.MercaderSG.My.Resources.Resources.Calcular
        Me.RecalcularDVSMI.Name = "RecalcularDVSMI"
        Me.RecalcularDVSMI.Size = New System.Drawing.Size(203, 22)
        Me.RecalcularDVSMI.Text = "Recalcular DV"
        '
        'PanelSMI
        '
        Me.PanelSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IdiomaSMI, Me.CambiarContrasenaSMI, Me.SalirSMI})
        Me.PanelSMI.Name = "PanelSMI"
        Me.PanelSMI.Size = New System.Drawing.Size(48, 20)
        Me.PanelSMI.Text = "Panel"
        '
        'IdiomaSMI
        '
        Me.IdiomaSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EspanolSMI, Me.InglesSMI})
        Me.IdiomaSMI.Image = Global.MercaderSG.My.Resources.Resources.IdiomaE
        Me.IdiomaSMI.Name = "IdiomaSMI"
        Me.IdiomaSMI.Size = New System.Drawing.Size(182, 22)
        Me.IdiomaSMI.Text = "Idioma"
        '
        'EspanolSMI
        '
        Me.EspanolSMI.Image = Global.MercaderSG.My.Resources.Resources.ar
        Me.EspanolSMI.Name = "EspanolSMI"
        Me.EspanolSMI.Size = New System.Drawing.Size(108, 22)
        Me.EspanolSMI.Text = "ES-AR"
        '
        'InglesSMI
        '
        Me.InglesSMI.Image = Global.MercaderSG.My.Resources.Resources.us
        Me.InglesSMI.Name = "InglesSMI"
        Me.InglesSMI.Size = New System.Drawing.Size(108, 22)
        Me.InglesSMI.Text = "EN-US"
        '
        'CambiarContrasenaSMI
        '
        Me.CambiarContrasenaSMI.Image = Global.MercaderSG.My.Resources.Resources.CambiarPassE
        Me.CambiarContrasenaSMI.Name = "CambiarContrasenaSMI"
        Me.CambiarContrasenaSMI.Size = New System.Drawing.Size(182, 22)
        Me.CambiarContrasenaSMI.Text = "Cambiar Contraseña"
        '
        'SalirSMI
        '
        Me.SalirSMI.Image = Global.MercaderSG.My.Resources.Resources.SalirE
        Me.SalirSMI.Name = "SalirSMI"
        Me.SalirSMI.Size = New System.Drawing.Size(182, 22)
        Me.SalirSMI.Text = "Salir"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(685, 677)
        Me.Controls.Add(Me.MenuPrincipal)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuPrincipal
        Me.MinimumSize = New System.Drawing.Size(691, 706)
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal - MercaderSG"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuPrincipal.ResumeLayout(False)
        Me.MenuPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents GestionClienteSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionProveedorSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionProductoSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComercialSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotaVentaSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionNVSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerarNVSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotaPedidoSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionNPSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerarNPSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SistemaSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionUsuarioSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionFamiliaSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesbloquearUsuarioSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetearContrasenaSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeguridadSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BitacoraSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatFamSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuFamSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatUsuSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IdiomaSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EspanolSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InglesSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarContrasenaSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecalcularDVSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestionSMI As System.Windows.Forms.ToolStripMenuItem
End Class
